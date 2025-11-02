using Guna.UI2.WinForms;
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
    public partial class LOGIN : Form
    {
        int attempts = 0;
        public LOGIN()
        {
            InitializeComponent();
        }

        string connectionString = ConnectionString.conn;


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPass forgot = new ForgotPass();
            forgot.Show();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" && txtPass.Text == "")
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("F_Login", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Check if admin exists
                        if (dt.Rows.Count > 0)
                        {
                            string fname = dt.Rows[0]["FirstName"].ToString();
                            string lname = dt.Rows[0]["LastName"].ToString();
                            string photoPath = dt.Rows[0]["ProfilePic"].ToString();

                            UserSession.FirstName = fname;
                            UserSession.LastName = lname;
                            UserSession.ProfilePath = photoPath;

                            MessageBox.Show("Welcome, " + fname + "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Show Dashboard
                            Dashboard dashboard = new Dashboard();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            attempts++;
                            MessageBox.Show($"Invalid username or password. Attempt: {attempts}/3", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Exit after 3 failed attempts
                            if (attempts >= 3)
                            {
                                MessageBox.Show("You have reached the maximum number of login attempts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Application.Exit();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database Error: " + ex.Message);
                    }
                }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Color defaultExitForeColor;
        private Color defaultExitFillColor;
        private Color defaultLoginForeColor;
        private Color defaultLoginFillColor;
        private Color defaultRegFillColor;
        private Color defaultRegForeColor;

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            defaultExitForeColor = btnExit.ForeColor;
            defaultExitFillColor = btnExit.BackColor;

            btnExit.ForeColor = Color.OrangeRed;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = defaultExitForeColor;
            btnExit.FillColor = defaultExitFillColor;
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            defaultLoginForeColor = btnLogin.ForeColor;
            defaultLoginFillColor = btnLogin.BackColor;

            btnLogin.ForeColor = Color.White;
            btnLogin.FillColor = Color.DarkOrchid;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = defaultLoginForeColor;
            btnLogin.FillColor = defaultLoginFillColor;
        }
        private void btnRegister_MouseHover(object sender, EventArgs e)
        {
            defaultRegForeColor = btnRegister.ForeColor;
            defaultRegFillColor = btnRegister.BackColor;

            btnRegister.ForeColor = Color.White;
            btnRegister.FillColor = Color.SlateBlue;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUser.BorderThickness = 2;
            
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.BorderThickness = 2;
        }

        private void cbShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !cbShowPass.Checked;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.ForeColor = defaultRegFillColor;
            btnRegister.FillColor = defaultRegFillColor;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }
    }
}
