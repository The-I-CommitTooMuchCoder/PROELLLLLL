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
    public partial class RenewPassword : Form
    {
        public RenewPassword()
        {
            InitializeComponent();
        }
        string connectionString = ConnectionString.conn;

        private void label2_Click(object sender, EventArgs e)
        {
            Login lOGIN = new Login();
            lOGIN.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRenew_Click_1(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string newPass = txtNewPass.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("F_ResetPass", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Input parameters
                        cmd.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = user;
                        cmd.Parameters.Add("@NewPassword", System.Data.SqlDbType.NVarChar, 100).Value = newPass;

                        // Output parameter
                        SqlParameter resultParam = new SqlParameter("@Result", System.Data.SqlDbType.Int);
                        resultParam.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(resultParam);

                        cmd.ExecuteNonQuery();

                        int result = (int)cmd.Parameters["@Result"].Value;

                        if (result == 1)
                        {
                            MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Login loginForm = new Login();
                            loginForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
