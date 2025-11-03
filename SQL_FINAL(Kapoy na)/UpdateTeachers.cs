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
using System.Xml.Linq;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class UpdateTeachers : Form
    {
        int teacherID;
        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        public UpdateTeachers(int id, string fname, string lname, string gender, string dept, string subj, string user, string pass)
        {
            InitializeComponent();
            teacherID = id;

            // Preload values into textboxes
            txtFirstN.Text = fname;
            txtLastN.Text = lname;
            txtUser.Text = user;
            txtPass.Text = pass;
            cmbDepartment.Text = dept;
            cmbSub.Text = subj;
            if (gender == "Male") rdbMale.Checked = true;
            else rdbFemale.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string gender = rdbMale.Checked ? "Male" : "Female";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("F_UpdateTeacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastN.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@Subject", cmbSub.Text);
                cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Teacher updated successfully!", "Success");
            this.Close();
        }
    }
}
