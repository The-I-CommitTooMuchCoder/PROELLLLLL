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
    public partial class AddS : Form
    {
        public AddS()
        {
            InitializeComponent();
        }
        
        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check for missing info
            if (txtFirstN.Text == "" || txtLastN.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information");
                return;
            }

            // Gender validation
            string gender = rdbMale.Checked ? "Male" : (rdbFemale.Checked ? "Female" : "");
            if (gender == "")
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            int age = 0;
            try
            {
                age = Convert.ToInt32(txtAge.Text);
            }
            catch
            {
                MessageBox.Show("Please enter numbers only in Age.");
                return;
            }

            // Save to SQL
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_AddS", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastN.Text);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhonenum.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@TermLevel", cmbTerm.Text);
                    cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                    cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AddLog("CREATE", $"Added new student: {txtFirstN.Text} {txtLastN.Text}");

                    ClearFields();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error");
                }

            }
        }

        private void AddLog(string action, string desc)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand log = new SqlCommand("F_Log", con);
                log.CommandType = System.Data.CommandType.StoredProcedure;
                log.Parameters.AddWithValue("@ActionType", action);
                log.Parameters.AddWithValue("@Description", desc);
                log.ExecuteNonQuery();
            }
        }
        private void ClearFields()
        {
            txtFirstN.Clear();
            txtLastN.Clear();
            txtAge.Clear();
            txtAdd.Clear();
            txtPhonenum.Clear();
            txtEmail.Clear();
            txtUser.Clear();
            txtPass.Clear();
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            cmbTerm.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbCourse.SelectedIndex = -1;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDash sd = new StudentDash();
            sd.Show();
        }
    }
}
