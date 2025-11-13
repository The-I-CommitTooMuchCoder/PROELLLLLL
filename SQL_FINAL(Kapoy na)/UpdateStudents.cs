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
    
    public partial class UpdateStudents : Form
    {
        string connectionString = ConnectionString.conn;
        int studentID;
        public UpdateStudents(int id)
        {
            InitializeComponent();
            studentID = id;
        }
     
        private void UpdateS_Load(object sender, EventArgs e) 
        { 
       
            LoadStudentData();

        }

        private void LoadStudentData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students WHERE StudentID = @StudentID", con);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFirstN.Text = dr["FirstName"].ToString();
                    txtLastN.Text = dr["LastName"].ToString();
                    txtAge.Text = dr["Age"].ToString();
                    txtAdd.Text = dr["Address"].ToString();
                    txtPhonenum.Text = dr["Phone"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtUser.Text = dr["Username"].ToString();
                    txtPass.Text = dr["Password"].ToString();
                    cmbDepartment.Text = dr["Department"].ToString();
                    cmbCourse.Text = dr["Course"].ToString();
                    cmbTerm.Text = dr["TermLevel"].ToString();

                    string gender = dr["Gender"].ToString();
                    if (gender == "Male") rdbMale.Checked = true;
                    else if (gender == "Female") rdbFemale.Checked = true;
                }
                con.Close();

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string gender = rdbMale.Checked ? "Male" : (rdbFemale.Checked ? "Female" : "");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("F_UpdateS", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastN.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhonenum.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@Course", cmbCourse.Text);
                cmd.Parameters.AddWithValue("@TermLevel", cmbTerm.Text);
                cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            StudentDashboard studentDash = new StudentDashboard();
            studentDash.Show();
            this.Close();
        }
    }
}
