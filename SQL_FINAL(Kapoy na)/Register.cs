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
    public partial class Register : Form
    {
        string selectedImagePath = "";
        public Register()
        {
            InitializeComponent();
        }


        string connectionString = ConnectionString.conn;

        private void Profilepic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName; // save path
                Profilepic.Image = new Bitmap(selectedImagePath); // preview in PictureBox
            }
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtFirstName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information");
                return;
            }

            string email = txtEmail.Text.Trim();

            if (!email.ToLower().Contains("@"))
            {
                MessageBox.Show("Please enter a valid email!");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_Register", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    if (string.IsNullOrEmpty(selectedImagePath))
                    {
                        cmd.Parameters.AddWithValue("@ProfilePic", DBNull.Value); // no picture
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProfilePic", selectedImagePath); // save the path
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Go back to login form
                    Login lOGIN = new Login();
                    lOGIN.Show();
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error");
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login lOGIN = new Login();
            lOGIN.Show();
            this.Hide();
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            txtFirstName.BorderThickness = 2;
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            txtLastName.BorderThickness= 2;
        }

        private void txtAge_Enter(object sender, EventArgs e)
        {
            txtAge.BorderThickness = 2;
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            txtAddress.BorderThickness = 2;
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            txtPhone.BorderThickness = 2;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BorderThickness = 2;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.BorderThickness = 2;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BorderThickness = 2;
        }

        private void cbShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !cbShowPass.Checked;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        }

        private Color defaultRegFillColor;
        private Color defaultRegForeColor;

        private Color defaultClearFillColor;
        private Color defaultClearForeColor;

        private void btnRegister_MouseHover(object sender, EventArgs e)
        {
            defaultRegForeColor = btnRegister.ForeColor;
            defaultRegFillColor = btnRegister.BackColor;

            btnRegister.ForeColor = Color.White;
            btnRegister.FillColor = Color.SlateBlue;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.ForeColor = defaultRegFillColor;
            btnRegister.FillColor = defaultRegFillColor;
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            defaultClearForeColor = btnClear.ForeColor;
            defaultClearFillColor = btnClear.BackColor;

            btnClear.ForeColor = Color.OrangeRed;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.ForeColor = defaultClearForeColor;
            btnClear.FillColor = defaultClearFillColor;
        }
    }
}
