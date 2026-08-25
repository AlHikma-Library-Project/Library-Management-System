using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmBooks : Form
    {
        // رقم الكتاب الذي تم اختياره من الجدول
        private int selectedBookId = 0;

        public FrmBooks()
        {
            InitializeComponent();
        }

        // ==========================================
        // تحميل التصنيفات
        // ==========================================
        private void LoadCategories()
        {
            if (cmbCategory.Items.Count == 0)
            {
                cmbCategory.Items.Add("Programming");
                cmbCategory.Items.Add("Database");
                cmbCategory.Items.Add("Networking");
                cmbCategory.Items.Add("Science");
                cmbCategory.Items.Add("Business");
                cmbCategory.Items.Add("Fiction");
                cmbCategory.Items.Add("Other");
            }
        }

        // ==========================================
        // تحميل الكتب من قاعدة البيانات
        // ==========================================
        private void LoadBooks()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    string sql =
                        @"SELECT
                            BookId,
                            Title,
                            Author,
                            Category,
                            Quantity,
                            Available
                          FROM Books
                          ORDER BY BookId DESC";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, con))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvBooks.DataSource = table;
                    }
                }

                dgvBooks.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading books: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // التحقق من المدخلات
        // ==========================================
        private bool ValidateFields()
        {
            if (txtBook.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter book title."
                );

                txtBook.Focus();

                return false;
            }

            if (txtAuthor.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter author name."
                );

                txtAuthor.Focus();

                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a category."
                );

                cmbCategory.Focus();

                return false;
            }

            int quantity;

            if (!int.TryParse(
                txtQty.Text.Trim(),
                out quantity))
            {
                MessageBox.Show(
                    "Quantity must be a number."
                );

                txtQty.Focus();

                return false;
            }

            if (quantity <= 0)
            {
                MessageBox.Show(
                    "Quantity must be greater than 0."
                );

                txtQty.Focus();

                return false;
            }

            return true;
        }

        // ==========================================
        // تنظيف الحقول
        // ==========================================
        private void ClearFields()
        {
            selectedBookId = 0;

            txtBook.Clear();

            txtAuthor.Clear();

            cmbCategory.SelectedIndex = -1;

            txtQty.Clear();

            chkAvailable.Checked = true;

            dgvBooks.ClearSelection();

            txtBook.Focus();
        }

        // ==========================================
        // الحدث الصحيح عند فتح FrmBooks
        // ==========================================
        private void FrmBooks_Load(
            object sender,
            EventArgs e)
        {
            LoadCategories();

            LoadBooks();

            chkAvailable.Checked = true;
        }

        // ==========================================
        // الحدث القديم المرتبط بالـ Designer
        // لا تحذفه الآن
        // ==========================================
        private void _Load(
            object sender,
            EventArgs e)
        {
            LoadCategories();

            LoadBooks();

            chkAvailable.Checked = true;
        }

        // ==========================================
        // إضافة كتاب
        // ==========================================
        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateFields())
            {
                return;
            }

            try
            {
                int quantity =
                    int.Parse(txtQty.Text.Trim());

                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    string sql =
                        @"INSERT INTO Books
                          (
                              Title,
                              Author,
                              Category,
                              Quantity,
                              Available
                          )
                          VALUES
                          (
                              @title,
                              @author,
                              @category,
                              @quantity,
                              @available
                          )";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@title",
                            txtBook.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@author",
                            txtAuthor.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@category",
                            cmbCategory.Text
                        );

                        cmd.Parameters.AddWithValue(
                            "@quantity",
                            quantity
                        );

                        cmd.Parameters.AddWithValue(
                            "@available",
                            chkAvailable.Checked
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearFields();

                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding book: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // تعديل كتاب
        // ==========================================
        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show(
                    "Please select a book first."
                );

                return;
            }

            if (!ValidateFields())
            {
                return;
            }

            try
            {
                int quantity =
                    int.Parse(txtQty.Text.Trim());

                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    string sql =
                        @"UPDATE Books
                          SET
                              Title = @title,
                              Author = @author,
                              Category = @category,
                              Quantity = @quantity,
                              Available = @available
                          WHERE BookId = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@title",
                            txtBook.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@author",
                            txtAuthor.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@category",
                            cmbCategory.Text
                        );

                        cmd.Parameters.AddWithValue(
                            "@quantity",
                            quantity
                        );

                        cmd.Parameters.AddWithValue(
                            "@available",
                            chkAvailable.Checked
                        );

                        cmd.Parameters.AddWithValue(
                            "@id",
                            selectedBookId
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearFields();

                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating book: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // حذف كتاب
        // ==========================================
        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (selectedBookId == 0)
            {
                MessageBox.Show(
                    "Please select a book first."
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this book?",
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

                    // التحقق من وجود استعارات مرتبطة بالكتاب
                    string checkSql =
                        @"SELECT COUNT(*)
                          FROM Borrowings
                          WHERE BookId = @id";

                    using (SqlCommand checkCmd =
                        new SqlCommand(
                            checkSql,
                            con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@id",
                            selectedBookId
                        );

                        int borrowingCount =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar()
                            );

                        if (borrowingCount > 0)
                        {
                            MessageBox.Show(
                                "This book cannot be deleted because it has borrowing records.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }
                    }

                    string sql =
                        @"DELETE FROM Books
                          WHERE BookId = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            selectedBookId
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearFields();

                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting book: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // مسح الحقول
        // ==========================================
        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        // ==========================================
        // اختيار كتاب من DataGridView
        // ==========================================
        private void dgvBooks_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvBooks.Rows[e.RowIndex];

            selectedBookId =
                Convert.ToInt32(
                    row.Cells["BookId"].Value
                );

            txtBook.Text =
                row.Cells["Title"]
                   .Value
                   .ToString();

            txtAuthor.Text =
                row.Cells["Author"]
                   .Value
                   .ToString();

            cmbCategory.Text =
                row.Cells["Category"]
                   .Value
                   .ToString();

            txtQty.Text =
                row.Cells["Quantity"]
                   .Value
                   .ToString();

            chkAvailable.Checked =
                Convert.ToBoolean(
                    row.Cells["Available"].Value
                );
        }

        // ==========================================
        // Events قديمة مرتبطة بالـ Designer
        // اتركها كما هي
        // ==========================================

        private void label1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblQty_Click(
            object sender,
            EventArgs e)
        {
        }

        private void pnlBookInfo_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblInfo_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblBookTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblAuthor_Click(
            object sender,
            EventArgs e)
        {
        }

        private void txtQty_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void lblTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void chkAvailable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}