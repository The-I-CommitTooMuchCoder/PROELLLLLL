using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void label2_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRenew_Click_1(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string newPass = txtPass.Text.Trim();

            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information");
                return;
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_ResetPass", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@NewPassword", txtPass.Text);

                    // Execute
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Back to Login Form
                    LOGIN lOGIN = new LOGIN();
                    lOGIN.Show();
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error");
                }
            }
        }

        private Color defaultBackForeColor;
        private Color defaultBackFillColor;
        private Color defaultRenewForeColor;
        private Color defaultRenewFillColor;

        private void btnRenew_MouseHover(object sender, EventArgs e)
        {
            defaultRenewForeColor = btnRenew.ForeColor;
            defaultRenewFillColor = btnRenew.BackColor;

            btnRenew.ForeColor = Color.White;
            btnRenew.FillColor = Color.DarkOrchid;
        }

        private void btnRenew_MouseLeave(object sender, EventArgs e)
        {
            btnRenew.FillColor = defaultRenewFillColor;
            btnRenew.ForeColor = defaultRenewForeColor;
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            defaultBackForeColor = btnBack.ForeColor;
            defaultBackFillColor = btnBack.BackColor;

            btnBack.ForeColor = Color.OrangeRed;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.White;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.BorderThickness = 2;
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            txtNewPass.BorderThickness = 2;
        }

        private void guna2CheckBox1_CheckStateChanged(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = !guna2CheckBox1.Checked;
        }
    }
}
