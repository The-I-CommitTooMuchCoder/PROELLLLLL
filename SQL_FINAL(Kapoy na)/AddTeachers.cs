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
    public partial class AddTeachers : Form
    {
        public AddTeachers()
        {
            InitializeComponent();
        }
        string connectionString = ConnectionString.conn;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstN.Text) ||
                string.IsNullOrWhiteSpace(txtLastN.Text) ||
                string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                cmbSub.SelectedIndex == -1 ||
                cmbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information");
                return;
            }

            string gender = rdbMale.Checked ? "Male" : (rdbFemale.Checked ? "Female" : "");
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender.", "Validation Error");
                return;
            }

            // Insert into DB
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_AddT", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastN.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@Subject", cmbSub.Text);
                cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Teacher added successfully!", "Success");
                    AddLog("CREATE", $"Added new teacher: {txtFirstN.Text} {txtLastN.Text}");
                    ClearFields();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
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
            txtUser.Clear();
            txtPass.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbSub.SelectedIndex = -1;
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
