using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmMembers : Form
    {
        // رقم العضو المحدد من الجدول
        private int selectedMemberId = 0;

        public FrmMembers()
        {
            InitializeComponent();
        }

        // ==========================================
        // تحميل الصفحة
        // ==========================================
        private void FrmMembers_Load(object sender, EventArgs e)
        {
            LoadGender();
            LoadMembers();
        }

        // ==========================================
        // تحميل الجنس
        // ==========================================
        private void LoadGender()
        {
            if (cmbMemberGender.Items.Count == 0)
            {
                cmbMemberGender.Items.Add("Male");
                cmbMemberGender.Items.Add("Female");
            }
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
                        @"SELECT
                            MemberId,
                            Name,
                            Phone,
                            Email,
                            Gender
                          FROM Members
                          ORDER BY MemberId DESC";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(sql, con))
                    {
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dgvMembers.DataSource = table;
                    }
                }

                dgvMembers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading members: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // التحقق من البيانات
        // ==========================================
        private bool ValidateFields()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter member name."
                );

                txtName.Focus();
                return false;
            }

            if (txtMemberPhone.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter phone number."
                );

                txtMemberPhone.Focus();
                return false;
            }

            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter email."
                );

                txtEmail.Focus();
                return false;
            }

            if (cmbMemberGender.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select gender."
                );

                cmbMemberGender.Focus();
                return false;
            }

            return true;
        }

        // ==========================================
        // تنظيف الحقول
        // ==========================================
        private void ClearFields()
        {
            selectedMemberId = 0;

            txtName.Clear();
            txtMemberPhone.Clear();
            txtEmail.Clear();

            cmbMemberGender.SelectedIndex = -1;

            dgvMembers.ClearSelection();

            txtName.Focus();
        }

        // ==========================================
        // ADD
        // ==========================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
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
                        @"INSERT INTO Members
                          (
                              Name,
                              Phone,
                              Email,
                              Gender
                          )
                          VALUES
                          (
                              @name,
                              @phone,
                              @email,
                              @gender
                          )";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@name",
                            txtName.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@phone",
                            txtMemberPhone.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@email",
                            txtEmail.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@gender",
                            cmbMemberGender.Text
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Member added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearFields();
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error adding member: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // UPDATE
        // ==========================================
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        // ==========================================
        // DELETE
        // ==========================================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show(
                    "Please select a member first."
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this member?",
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

                    // التأكد من عدم وجود استعارات مرتبطة بالعضو
                    string checkSql =
                        @"SELECT COUNT(*)
                          FROM Borrowings
                          WHERE MemberId = @id";

                    using (SqlCommand checkCmd =
                        new SqlCommand(checkSql, con))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@id",
                            selectedMemberId
                        );

                        int count =
                            Convert.ToInt32(
                                checkCmd.ExecuteScalar()
                            );

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "This member cannot be deleted because there are borrowing records.",
                                "Delete Not Allowed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            return;
                        }
                    }

                    string sql =
                        @"DELETE FROM Members
                          WHERE MemberId = @id";

                    using (SqlCommand cmd =
                        new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            selectedMemberId
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Member deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ClearFields();
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting member: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // CLEAR
        // ==========================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // ==========================================
        // اختيار عضو من DataGridView
        // ==========================================
        private void dgvMembers_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvMembers.Rows[e.RowIndex];

            selectedMemberId =
                Convert.ToInt32(
                    row.Cells["MemberId"].Value
                );

            txtName.Text =
                row.Cells["Name"].Value.ToString();

            txtMemberPhone.Text =
                row.Cells["Phone"].Value.ToString();

            txtEmail.Text =
                row.Cells["Email"].Value.ToString();

            cmbMemberGender.Text =
                row.Cells["Gender"].Value.ToString();
        }

        // ==========================================
        // أحداث قديمة مرتبطة بالـ Designer
        // لا تحذفها
        // ==========================================
        private void pnlMemberInfo_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void lblName_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblSub_Click(object sender, EventArgs e)
        {

        }

        private void lblGender_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void cmbMemberGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}