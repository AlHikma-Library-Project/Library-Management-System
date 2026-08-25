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
            CloseChildForms();

            FrmMembers members = new FrmMembers();

            members.MdiParent = this;
            members.FormBorderStyle = FormBorderStyle.None;
            members.Dock = DockStyle.Fill;

            members.Show();
        }

        // =========================================
        // Borrowing
        // =========================================
        // سنربط صفحة Borrowing هنا لاحقًا

        // =========================================
        // Reports
        // =========================================
        private void btnReports_Click(object sender, EventArgs e)
        {
            // Employee لا يملك صلاحية Reports
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

            // إغلاق الصفحة الحالية
            CloseChildForms();

            // فتح صفحة Reports
            FrmReports reports = new FrmReports();

            reports.MdiParent = this;
            reports.FormBorderStyle = FormBorderStyle.None;
            reports.Dock = DockStyle.Fill;

            reports.Show();
        }

        // =========================================
        // Logout
        // =========================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================
        // Events قديمة مرتبطة بالـDesigner
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
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            CloseChildForms();

            FrmBorrow borrow = new FrmBorrow();

            borrow.MdiParent = this;
            borrow.FormBorderStyle = FormBorderStyle.None;
            borrow.Dock = DockStyle.Fill;

            borrow.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }
    }
}