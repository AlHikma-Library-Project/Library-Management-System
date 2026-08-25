using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pnlLeft_BackColorChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void lblPass_Click(object sender, EventArgs e)
        {
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
        }

        private void PicBooks_Click(object sender, EventArgs e)
        {
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShow.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try
            {
                string role = null;

                using (SqlConnection con = new SqlConnection(DB.ConStr))
                {
                    con.Open();

                    string sql =
                        "SELECT Role FROM Users " +
                        "WHERE Username = @user AND Password = @pass";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@user",
                            txtUser.Text.Trim()
                        );

                        cmd.Parameters.AddWithValue(
                            "@pass",
                            txtPass.Text
                        );

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                role = reader["Role"].ToString();
                            }
                        }
                    }
                }

                if (role != null)
                {
                    this.Hide();

                    FrmMain main = new FrmMain(role);
                    main.ShowDialog();

                    this.Show();

                    txtPass.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid username or password."
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message
                );
            }
        }
    }
}