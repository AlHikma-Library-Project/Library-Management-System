using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        // =========================================
        // عند فتح Dashboard
        // =========================================
        private void FrmHome_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        // =========================================
        // تحديث Dashboard
        // =========================================
        public void RefreshDashboard()
        {
            LoadDashboard();
            LoadRecentBorrowings();
        }

        // =========================================
        // تحميل أرقام Dashboard
        // =========================================
        private void LoadDashboard()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    // -------------------------
                    // Total Books
                    // -------------------------
                    using (SqlCommand cmdBooks =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM Books",
                            con))
                    {
                        lblTotalBooks.Text =
                            cmdBooks.ExecuteScalar().ToString();
                    }

                    // -------------------------
                    // Total Members
                    // -------------------------
                    using (SqlCommand cmdMembers =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM Members",
                            con))
                    {
                        lblTotalMembers.Text =
                            cmdMembers.ExecuteScalar().ToString();
                    }

                    // -------------------------
                    // Borrowed Books
                    // -------------------------
                    using (SqlCommand cmdBorrowed =
                        new SqlCommand(
                            @"SELECT COUNT(*)
                              FROM Borrowings
                              WHERE Status = 'Borrowed'",
                            con))
                    {
                        lblBorrowed.Text =
                            cmdBorrowed.ExecuteScalar().ToString();
                    }

                    // -------------------------
                    // Available Books
                    // -------------------------
                    using (SqlCommand cmdAvailable =
                        new SqlCommand(
                            @"SELECT COUNT(*)
                              FROM Books
                              WHERE Available = 1",
                            con))
                    {
                        lblAvailable.Text =
                            cmdAvailable.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading dashboard: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // تحميل أحدث عمليات الاستعارة
        // =========================================
        private void LoadRecentBorrowings()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    string sql =
                        @"SELECT TOP 10
                            b.BorrowId AS [ID],
                            bk.Title AS [Book Title],
                            m.Name AS [Member],
                            b.BorrowDate AS [Borrow Date],
                            b.ReturnDate AS [Return Date],
                            b.Status AS [Status]
                          FROM Borrowings b

                          INNER JOIN Books bk
                              ON b.BookId = bk.BookId

                          INNER JOIN Members m
                              ON b.MemberId = m.MemberId

                          ORDER BY b.BorrowId DESC";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, con))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvRecent.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading recent borrowings: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // Events قديمة مرتبطة بالـ Designer
        // لا تحذفها
        // =========================================

        private void lblDashboard_Click(object sender, EventArgs e)
        {
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void lblTotalBooks_Click(object sender, EventArgs e)
        {
        }

        private void pnlAvailable_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lblBorrowed_Click(object sender, EventArgs e)
        {
        }

        private void lblAvailable_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}