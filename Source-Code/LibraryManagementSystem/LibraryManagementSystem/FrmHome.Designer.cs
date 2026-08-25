namespace LibraryManagementSystem
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlBooks = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.lblBooksText = new System.Windows.Forms.Label();
            this.pnlMembers = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblTotalMembers = new System.Windows.Forms.Label();
            this.lblMembersText = new System.Windows.Forms.Label();
            this.pnlBorrowed = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblBorrowed = new System.Windows.Forms.Label();
            this.lblBorrowedText = new System.Windows.Forms.Label();
            this.pnlAvailable = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblAvailableText = new System.Windows.Forms.Label();
            this.lblRecent = new System.Windows.Forms.Label();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnlBorrowed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pnlAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.Navy;
            this.lblDashboard.Location = new System.Drawing.Point(330, 9);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(211, 50);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DimGray;
            this.lblWelcome.Location = new System.Drawing.Point(227, 59);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(363, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome to Library Management System";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // pnlBooks
            // 
            this.pnlBooks.BackColor = System.Drawing.Color.White;
            this.pnlBooks.Controls.Add(this.pictureBox3);
            this.pnlBooks.Controls.Add(this.lblTotalBooks);
            this.pnlBooks.Controls.Add(this.lblBooksText);
            this.pnlBooks.Location = new System.Drawing.Point(232, 87);
            this.pnlBooks.Name = "pnlBooks";
            this.pnlBooks.Size = new System.Drawing.Size(211, 106);
            this.pnlBooks.TabIndex = 2;
            this.pnlBooks.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(14, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBooks.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalBooks.Location = new System.Drawing.Point(118, 40);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(47, 35);
            this.lblTotalBooks.TabIndex = 1;
            this.lblTotalBooks.Text = "0";
            this.lblTotalBooks.Click += new System.EventHandler(this.lblTotalBooks_Click);
            // 
            // lblBooksText
            // 
            this.lblBooksText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksText.Location = new System.Drawing.Point(56, 9);
            this.lblBooksText.Name = "lblBooksText";
            this.lblBooksText.Size = new System.Drawing.Size(155, 25);
            this.lblBooksText.TabIndex = 0;
            this.lblBooksText.Text = "Total Books";
            this.lblBooksText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMembers
            // 
            this.pnlMembers.BackColor = System.Drawing.Color.White;
            this.pnlMembers.Controls.Add(this.pictureBox4);
            this.pnlMembers.Controls.Add(this.lblTotalMembers);
            this.pnlMembers.Controls.Add(this.lblMembersText);
            this.pnlMembers.Location = new System.Drawing.Point(476, 87);
            this.pnlMembers.Name = "pnlMembers";
            this.pnlMembers.Size = new System.Drawing.Size(211, 106);
            this.pnlMembers.TabIndex = 3;
            this.pnlMembers.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(20, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // lblTotalMembers
            // 
            this.lblTotalMembers.AutoSize = true;
            this.lblTotalMembers.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMembers.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalMembers.Location = new System.Drawing.Point(113, 37);
            this.lblTotalMembers.Name = "lblTotalMembers";
            this.lblTotalMembers.Size = new System.Drawing.Size(33, 38);
            this.lblTotalMembers.TabIndex = 1;
            this.lblTotalMembers.Text = "0";
            // 
            // lblMembersText
            // 
            this.lblMembersText.AutoSize = true;
            this.lblMembersText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembersText.Location = new System.Drawing.Point(42, 9);
            this.lblMembersText.Name = "lblMembersText";
            this.lblMembersText.Size = new System.Drawing.Size(134, 23);
            this.lblMembersText.TabIndex = 0;
            this.lblMembersText.Text = " Total Members";
            // 
            // pnlBorrowed
            // 
            this.pnlBorrowed.BackColor = System.Drawing.Color.White;
            this.pnlBorrowed.Controls.Add(this.pictureBox5);
            this.pnlBorrowed.Controls.Add(this.lblBorrowed);
            this.pnlBorrowed.Controls.Add(this.lblBorrowedText);
            this.pnlBorrowed.Location = new System.Drawing.Point(232, 209);
            this.pnlBorrowed.Name = "pnlBorrowed";
            this.pnlBorrowed.Size = new System.Drawing.Size(211, 105);
            this.pnlBorrowed.TabIndex = 0;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(17, 41);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // lblBorrowed
            // 
            this.lblBorrowed.AutoSize = true;
            this.lblBorrowed.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowed.ForeColor = System.Drawing.Color.Navy;
            this.lblBorrowed.Location = new System.Drawing.Point(118, 36);
            this.lblBorrowed.Name = "lblBorrowed";
            this.lblBorrowed.Size = new System.Drawing.Size(41, 38);
            this.lblBorrowed.TabIndex = 1;
            this.lblBorrowed.Text = " 0";
            this.lblBorrowed.Click += new System.EventHandler(this.lblBorrowed_Click);
            // 
            // lblBorrowedText
            // 
            this.lblBorrowedText.AutoSize = true;
            this.lblBorrowedText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowedText.Location = new System.Drawing.Point(46, 9);
            this.lblBorrowedText.Name = "lblBorrowedText";
            this.lblBorrowedText.Size = new System.Drawing.Size(142, 23);
            this.lblBorrowedText.TabIndex = 0;
            this.lblBorrowedText.Text = "Borrowed Books";
            // 
            // pnlAvailable
            // 
            this.pnlAvailable.BackColor = System.Drawing.Color.White;
            this.pnlAvailable.Controls.Add(this.pictureBox6);
            this.pnlAvailable.Controls.Add(this.lblAvailable);
            this.pnlAvailable.Controls.Add(this.lblAvailableText);
            this.pnlAvailable.ForeColor = System.Drawing.Color.White;
            this.pnlAvailable.Location = new System.Drawing.Point(476, 209);
            this.pnlAvailable.Name = "pnlAvailable";
            this.pnlAvailable.Size = new System.Drawing.Size(211, 105);
            this.pnlAvailable.TabIndex = 4;
            this.pnlAvailable.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAvailable_Paint);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(20, 41);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.ForeColor = System.Drawing.Color.Navy;
            this.lblAvailable.Location = new System.Drawing.Point(113, 36);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(33, 38);
            this.lblAvailable.TabIndex = 1;
            this.lblAvailable.Text = "0";
            this.lblAvailable.Click += new System.EventHandler(this.lblAvailable_Click);
            // 
            // lblAvailableText
            // 
            this.lblAvailableText.AutoSize = true;
            this.lblAvailableText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableText.ForeColor = System.Drawing.Color.Black;
            this.lblAvailableText.Location = new System.Drawing.Point(60, 9);
            this.lblAvailableText.Name = "lblAvailableText";
            this.lblAvailableText.Size = new System.Drawing.Size(137, 23);
            this.lblAvailableText.TabIndex = 0;
            this.lblAvailableText.Text = "Available Books";
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecent.ForeColor = System.Drawing.Color.Navy;
            this.lblRecent.Location = new System.Drawing.Point(235, 317);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(216, 31);
            this.lblRecent.TabIndex = 5;
            this.lblRecent.Text = "Recent Borrowings";
            // 
            // dgvRecent
            // 
            this.dgvRecent.AllowUserToAddRows = false;
            this.dgvRecent.AllowUserToDeleteRows = false;
            this.dgvRecent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecent.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecent.Location = new System.Drawing.Point(124, 351);
            this.dgvRecent.MultiSelect = false;
            this.dgvRecent.Name = "dgvRecent";
            this.dgvRecent.ReadOnly = true;
            this.dgvRecent.RowHeadersVisible = false;
            this.dgvRecent.RowHeadersWidth = 51;
            this.dgvRecent.RowTemplate.Height = 24;
            this.dgvRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecent.Size = new System.Drawing.Size(540, 180);
            this.dgvRecent.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 282);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(232, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvRecent);
            this.Controls.Add(this.lblRecent);
            this.Controls.Add(this.pnlAvailable);
            this.Controls.Add(this.pnlBorrowed);
            this.Controls.Add(this.pnlMembers);
            this.Controls.Add(this.pnlBooks);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.pnlBooks.ResumeLayout(false);
            this.pnlBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlMembers.ResumeLayout(false);
            this.pnlMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnlBorrowed.ResumeLayout(false);
            this.pnlBorrowed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.pnlAvailable.ResumeLayout(false);
            this.pnlAvailable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlBooks;
        private System.Windows.Forms.Panel pnlMembers;
        private System.Windows.Forms.Panel pnlBorrowed;
        private System.Windows.Forms.Panel pnlAvailable;
        private System.Windows.Forms.Label lblBooksText;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblTotalMembers;
        private System.Windows.Forms.Label lblMembersText;
        private System.Windows.Forms.Label lblBorrowed;
        private System.Windows.Forms.Label lblBorrowedText;
        private System.Windows.Forms.Label lblAvailableText;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.DataGridView dgvRecent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}