using System;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmMain : Form
    {
        private string userRole;

        public FrmMain(string role)
        {
            InitializeComponent();

            userRole = role;

            // عرض دور المستخدم
            lblRole.Text = "Role: " + role;

            // الصلاحيات
            if (role == "Employee")
            {
                btnReports.Enabled = false;
            }
            else if (role == "Admin")
            {
                btnReports.Enabled = true;
            }
        }

        // =========================================
        // عند فتح FrmMain
        // =========================================
        private void FrmMain_Load(object sender, EventArgs e)
        {
            OpenHome();
        }

        // =========================================
        // إغلاق أي صفحة مفتوحة
        // =========================================
        private void CloseChildForms()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        // =========================================
        // فتح Dashboard
        // =========================================
        private void OpenHome()
        {
            CloseChildForms();

            FrmHome home = new FrmHome();

            home.MdiParent = this;
            home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;

            home.Show();

            // تحديث بيانات Dashboard
            home.RefreshDashboard();
        }

        // =========================================
        // Dashboard
        // =========================================
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenHome();
        }

        // =========================================
        // Books
        // =========================================
        private void btnBooks_Click(object sender, EventArgs e)
        {
            CloseChildForms();

            FrmBooks books = new FrmBooks();

            books.MdiParent = this;
            books.FormBorderStyle = FormBorderStyle.None;
            books.Dock = DockStyle.Fill;

            books.Show();
        }

        // =========================================
        // Members
        // =========================================
        private void btnMembers_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Members page will be added next.",
                "Members",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================
        // Borrowing
        // =========================================
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Borrowing page will be added later.",
                "Borrowing",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================
        // Reports
        // =========================================
        private void btnReports_Click(object sender, EventArgs e)
        {
            if (userRole == "Employee")
            {
                MessageBox.Show(
                    "You do not have permission to open reports.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Reports page will be added later.",
                "Reports",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================
        // Logout
        // =========================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================
        // Events قديمة مرتبطة بالـ Designer
        // لا تحذفها
        // =========================================
        private void lblRole_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }
    }
}