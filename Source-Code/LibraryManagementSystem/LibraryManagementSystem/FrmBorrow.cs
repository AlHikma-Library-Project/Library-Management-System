using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmBorrow : Form
    {
        private int selectedBorrowId = 0;
        private int selectedBookId = 0;

        public FrmBorrow()
        {
            InitializeComponent();
        }

        // ==========================================
        // عند فتح الصفحة
        // ==========================================
        private void FrmBorrow_Load(object sender, EventArgs e)
        {
            LoadMembers();
            LoadBooks();
            LoadStatus();
            LoadBorrowings();

            dtpBorrowDate.Value = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today;
        }

        // ==========================================
        // تحميل الأعضاء
        // ==========================================
        private void LoadMembers()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    string sql =
                        "SELECT MemberId, Name FROM Members ORDER BY Name";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, con);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    cmbMember.DataSource = table;
                    cmbMember.DisplayMember = "Name";
                    cmbMember.ValueMember = "MemberId";

                    cmbMember.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading members: " + ex.Message
                );
            }
        }

        // ==========================================
        // تحميل الكتب
        // ==========================================
        private void LoadBooks()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    string sql =
                        @"SELECT BookId, Title
                          FROM Books
                          ORDER BY Title";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, con);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    cmbBook.DataSource = table;
                    cmbBook.DisplayMember = "Title";
                    cmbBook.ValueMember = "BookId";

                    cmbBook.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading books: " + ex.Message
                );
            }
        }

        // ==========================================
        // تحميل الحالات
        // ==========================================
        private void LoadStatus()
        {
            if (cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.Add("Borrowed");
                cmbStatus.Items.Add("Returned");
            }

            cmbStatus.SelectedIndex = 0;
        }

        // ==========================================
        // عرض عمليات الاستعارة
        // ==========================================
        private void LoadBorrowings()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    string sql =
                        @"SELECT
                            br.BorrowId,
                            br.MemberId,
                            br.BookId,
                            m.Name AS Member,
                            b.Title AS Book,
                            br.BorrowDate,
                            br.ReturnDate,
                            br.Status
                          FROM Borrowings br

                          INNER JOIN Members m
                              ON br.MemberId = m.MemberId

                          INNER JOIN Books b
                              ON br.BookId = b.BookId

                          ORDER BY br.BorrowId DESC";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, con);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvBorrowings.DataSource = table;

                    // إخفاء المفاتيح التي لا نحتاج عرضها
                    if (dgvBorrowings.Columns["MemberId"] != null)
                        dgvBorrowings.Columns["MemberId"].Visible = false;

                    if (dgvBorrowings.Columns["BookId"] != null)
                        dgvBorrowings.Columns["BookId"].Visible = false;
                }

                dgvBorrowings.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading borrowings: " + ex.Message
                );
            }
        }

        // ==========================================
        // التحقق من البيانات
        // ==========================================
        private bool ValidateBorrow()
        {
            if (cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a member.");
                cmbMember.Focus();
                return false;
            }

            if (cmbBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a book.");
                cmbBook.Focus();
                return false;
            }

            return true;
        }

        // ==========================================
        // استعارة كتاب
        // ==========================================
        private void btnBorrowBook_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateBorrow())
            {
                return;
            }

            int memberId =
                Convert.ToInt32(cmbMember.SelectedValue);

            int bookId =
                Convert.ToInt32(cmbBook.SelectedValue);

            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    // التأكد من توفر الكتاب
                    string checkSql =
                        @"SELECT Quantity
                          FROM Books
                          WHERE BookId = @bookId";

                    int quantity;

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkSql, con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@bookId",
                            bookId
                        );

                        object result =
                            checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show(
                                "Book was not found."
                            );

                            return;
                        }

                        quantity =
                            Convert.ToInt32(result);
                    }

                    if (quantity <= 0)
                    {
                        MessageBox.Show(
                            "This book is not available."
                        );

                        return;
                    }

                    // منع العضو من استعارة نفس الكتاب مرتين
                    string duplicateSql =
                        @"SELECT COUNT(*)
                          FROM Borrowings
                          WHERE MemberId = @memberId
                          AND BookId = @bookId
                          AND Status = 'Borrowed'";

                    using (SqlCommand duplicateCmd =
                        new SqlCommand(duplicateSql, con))
                    {
                        duplicateCmd.Parameters.AddWithValue(
                            "@memberId",
                            memberId
                        );

                        duplicateCmd.Parameters.AddWithValue(
                            "@bookId",
                            bookId
                        );

                        int count =
                            Convert.ToInt32(
                                duplicateCmd.ExecuteScalar()
                            );

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This member already borrowed this book."
                            );

                            return;
                        }
                    }

                    // تسجيل الاستعارة
                    string insertSql =
                        @"INSERT INTO Borrowings
                          (
                              BookId,
                              MemberId,
                              BorrowDate,
                              ReturnDate,
                              Status
                          )
                          VALUES
                          (
                              @bookId,
                              @memberId,
                              @borrowDate,
                              NULL,
                              'Borrowed'
                          )";

                    using (SqlCommand cmd =
                        new SqlCommand(insertSql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@bookId",
                            bookId
                        );

                        cmd.Parameters.AddWithValue(
                            "@memberId",
                            memberId
                        );

                        cmd.Parameters.AddWithValue(
                            "@borrowDate",
                            dtpBorrowDate.Value.Date
                        );

                        cmd.ExecuteNonQuery();
                    }

                    // إنقاص الكمية
                    string updateBookSql =
                        @"UPDATE Books
                          SET Quantity = Quantity - 1,
                              Available =
                              CASE
                                  WHEN Quantity - 1 > 0
                                  THEN 1
                                  ELSE 0
                              END
                          WHERE BookId = @bookId";

                    using (SqlCommand cmd =
                        new SqlCommand(updateBookSql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@bookId",
                            bookId
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book borrowed successfully."
                );

                ClearFields();
                LoadBooks();
                LoadBorrowings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error borrowing book: " + ex.Message
                );
            }
        }

        // ==========================================
        // إرجاع كتاب
        // ==========================================
        private void btnReturnBook_Click(
            object sender,
            EventArgs e)
        {
            if (selectedBorrowId == 0)
            {
                MessageBox.Show(
                    "Please select a borrowing record first."
                );

                return;
            }

            if (cmbStatus.Text == "Returned")
            {
                MessageBox.Show(
                    "This book has already been returned."
                );

                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    string returnSql =
                        @"UPDATE Borrowings
                          SET ReturnDate = @returnDate,
                              Status = 'Returned'
                          WHERE BorrowId = @borrowId";

                    using (SqlCommand cmd =
                        new SqlCommand(returnSql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@returnDate",
                            dtpReturnDate.Value.Date
                        );

                        cmd.Parameters.AddWithValue(
                            "@borrowId",
                            selectedBorrowId
                        );

                        cmd.ExecuteNonQuery();
                    }

                    // إعادة نسخة للكمية
                    string bookSql =
                        @"UPDATE Books
                          SET Quantity = Quantity + 1,
                              Available = 1
                          WHERE BookId = @bookId";

                    using (SqlCommand cmd =
                        new SqlCommand(bookSql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@bookId",
                            selectedBookId
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book returned successfully."
                );

                ClearFields();
                LoadBooks();
                LoadBorrowings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error returning book: " + ex.Message
                );
            }
        }

        // ==========================================
        // حذف سجل استعارة
        // ==========================================
        private void btnDeleteBorrow_Click(
            object sender,
            EventArgs e)
        {
            if (selectedBorrowId == 0)
            {
                MessageBox.Show(
                    "Please select a borrowing record first."
                );

                return;
            }

            if (cmbStatus.Text == "Borrowed")
            {
                MessageBox.Show(
                    "Return the book before deleting the borrowing record."
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    string sql =
                        @"DELETE FROM Borrowings
                          WHERE BorrowId = @borrowId";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@borrowId",
                            selectedBorrowId
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Borrowing record deleted successfully."
                );

                ClearFields();
                LoadBorrowings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting record: " + ex.Message
                );
            }
        }

        // ==========================================
        // تنظيف الحقول
        // ==========================================
        private void ClearFields()
        {
            selectedBorrowId = 0;
            selectedBookId = 0;

            cmbMember.SelectedIndex = -1;
            cmbBook.SelectedIndex = -1;

            dtpBorrowDate.Value = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today;

            cmbStatus.SelectedIndex = 0;

            dgvBorrowings.ClearSelection();
        }

        private void btnClearBorrow_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }
        private void lblInfo_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        // ==========================================
        // اختيار سجل من الجدول
        // ==========================================
        private void dgvBorrowings_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvBorrowings.Rows[e.RowIndex];

            selectedBorrowId =
                Convert.ToInt32(
                    row.Cells["BorrowId"].Value
                );

            selectedBookId =
                Convert.ToInt32(
                    row.Cells["BookId"].Value
                );

            cmbMember.SelectedValue =
                Convert.ToInt32(
                    row.Cells["MemberId"].Value
                );

            cmbBook.SelectedValue =
                selectedBookId;

            dtpBorrowDate.Value =
                Convert.ToDateTime(
                    row.Cells["BorrowDate"].Value
                );

            if (row.Cells["ReturnDate"].Value != DBNull.Value)
            {
                dtpReturnDate.Value =
                    Convert.ToDateTime(
                        row.Cells["ReturnDate"].Value
                    );
            }
            else
            {
                dtpReturnDate.Value =
                    DateTime.Today;
            }

            cmbStatus.Text =
                row.Cells["Status"].Value.ToString();
        }

        private void dgvBorrowings_CellClicks(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblMember_Click(object sender, EventArgs e)
        {

        }

        private void pi(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pnlBorrowInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}