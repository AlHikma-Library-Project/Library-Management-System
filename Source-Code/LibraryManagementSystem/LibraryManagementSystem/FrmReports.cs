using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        // =========================================
        // عند فتح الصفحة
        // =========================================
        private void FrmReports_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Clear();

            cmbReportType.Items.Add("All Borrowings");
            cmbReportType.Items.Add("Borrowed");
            cmbReportType.Items.Add("Returned");

            cmbReportType.SelectedIndex = 0;

            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;

            LoadStatistics();
            GenerateReport();
        }

        // =========================================
        // تحميل الإحصائيات
        // =========================================
        private void LoadStatistics()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    // Total Books
                    using (SqlCommand cmd =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM Books",
                            con))
                    {
                        lblTotalBooks.Text =
                            cmd.ExecuteScalar().ToString();
                    }

                    // Total Members
                    using (SqlCommand cmd =
                        new SqlCommand(
                            "SELECT COUNT(*) FROM Members",
                            con))
                    {
                        lblTotalMembers.Text =
                            cmd.ExecuteScalar().ToString();
                    }

                    // Borrowed
                    using (SqlCommand cmd =
                        new SqlCommand(
                            @"SELECT COUNT(*)
                              FROM Borrowings
                              WHERE Status = 'Borrowed'",
                            con))
                    {
                        lblBorrowed.Text =
                            cmd.ExecuteScalar().ToString();
                    }

                    // Returned
                    using (SqlCommand cmd =
                        new SqlCommand(
                            @"SELECT COUNT(*)
                              FROM Borrowings
                              WHERE Status = 'Returned'",
                            con))
                    {
                        lblReturned.Text =
                            cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading statistics: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // زر Generate Report
        // =========================================
        private void btnGenerate_Click(
            object sender,
            EventArgs e)
        {
            GenerateReport();
        }

        // =========================================
        // إنشاء التقرير
        // =========================================
        private void GenerateReport()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(DB.ConStr))
                {
                    string sql =
                        @"SELECT
                            br.BorrowId AS [ID],
                            m.Name AS [Member],
                            b.Title AS [Book],
                            br.BorrowDate AS [Borrow Date],
                            br.ReturnDate AS [Return Date],
                            br.Status AS [Status]
                          FROM Borrowings br

                          INNER JOIN Members m
                              ON br.MemberId = m.MemberId

                          INNER JOIN Books b
                              ON br.BookId = b.BookId

                          WHERE
                              br.BorrowDate >= @fromDate
                              AND br.BorrowDate < @toDate
                          ";

                    // =====================================
                    // تحديد نوع التقرير
                    // =====================================
                    if (cmbReportType.Text == "Borrowed")
                    {
                        sql +=
                            " AND br.Status = 'Borrowed' ";
                    }
                    else if (cmbReportType.Text == "Returned")
                    {
                        sql +=
                            " AND br.Status = 'Returned' ";
                    }

                    sql +=
                        " ORDER BY br.BorrowId DESC";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@fromDate",
                            dtpFromDate.Value.Date
                        );

                        cmd.Parameters.AddWithValue(
                            "@toDate",
                            dtpToDate.Value.Date.AddDays(1)
                        );

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable table =
                                new DataTable();

                            adapter.Fill(table);

                            dgvReports.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error generating report: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // Export Report
        // =========================================
        private void btnExport_Click(
            object sender,
            EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no data to export.",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            SaveFileDialog saveDialog =
                new SaveFileDialog();

            saveDialog.Filter =
                "CSV File (*.csv)|*.csv";

            saveDialog.Title =
                "Export Library Report";

            saveDialog.FileName =
                "Library_Report.csv";

            if (saveDialog.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            try
            {
                StringBuilder csv =
                    new StringBuilder();

                // Headers
                for (int i = 0;
                     i < dgvReports.Columns.Count;
                     i++)
                {
                    csv.Append(
                        dgvReports.Columns[i].HeaderText
                    );

                    if (i <
                        dgvReports.Columns.Count - 1)
                    {
                        csv.Append(",");
                    }
                }

                csv.AppendLine();

                // Rows
                foreach (DataGridViewRow row
                    in dgvReports.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }

                    for (int i = 0;
                         i < dgvReports.Columns.Count;
                         i++)
                    {
                        string value =
                            row.Cells[i].Value == null
                            ? ""
                            : row.Cells[i].Value
                                .ToString();

                        value =
                            value.Replace(
                                "\"",
                                "\"\""
                            );

                        csv.Append(
                            "\"" + value + "\""
                        );

                        if (i <
                            dgvReports.Columns.Count - 1)
                        {
                            csv.Append(",");
                        }
                    }

                    csv.AppendLine();
                }

                File.WriteAllText(
                    saveDialog.FileName,
                    csv.ToString(),
                    Encoding.UTF8
                );

                MessageBox.Show(
                    "Report exported successfully.",
                    "Export",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error exporting report: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================
        // Events قديمة مرتبطة بالـDesigner
        // =========================================

        private void lblTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblSub_Click(
            object sender,
            EventArgs e)
        {
        }
        private void pnlTotalBooks_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void pnlFilters_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void dgvReports_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void lblMembersText_Click(object sender, EventArgs e)
        {

        }
    }
}