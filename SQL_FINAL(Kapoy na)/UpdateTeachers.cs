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
        string connectionString = ConnectionString.conn;

        public UpdateTeachers(int id/*, string fname, string lname, string gender, string dept, string subj, string user, string pass*/)
        {
            InitializeComponent();
            teacherID = id;

            //// Preload values into textboxes
            //txtFirstN.Text = fname;
            //txtLastN.Text = lname;
            //txtUser.Text = user;
            //txtPass.Text = pass;
            //cmbDepartment.Text = dept;
            //cmbSub.Text = subj;
            //if (gender == "Male") rdbMale.Checked = true;
            //else rdbFemale.Checked = true;
        }

        private void LoadTeacherData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Teachers WHERE TeacherID = @TeacherID", con);
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFirstN.Text = dr["FirstName"].ToString();
                    txtLastN.Text = dr["LastName"].ToString();
                    string gender = dr["Gender"].ToString();
                    if (gender == "Male") rdbMale.Checked = true;
                    else if (gender == "Female") rdbFemale.Checked = true;
                    cmbSub.Text = dr["Subject"].ToString();
                    cmbDepartment.Text = dr["Department"].ToString();
                    txtUser.Text = dr["Username"].ToString();
                    txtPass.Text = dr["Password"].ToString();

                }
                con.Close();

            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("F_UpdateT", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Add parameters to the command
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastN.Text);
                cmd.Parameters.AddWithValue("@Gender", rdbMale.Checked ? "M" : "F"); // Assuming rdbMale and rdbFemale are radio buttons
                cmd.Parameters.AddWithValue("@Department", cmbDepartment.Text);
                cmd.Parameters.AddWithValue("@Subject", cmbSub.Text);
                cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                con.Open();
                // Execute the command to update data
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    // Update was successful, fetch and display the updated data
                    using (SqlConnection con2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand("SELECT FirstName, LastName, Gender, Department, Subject, Username, Password FROM Teachers WHERE TeacherID = @TeacherID", con2);
                        cmd2.Parameters.AddWithValue("@TeacherID", teacherID);

                        con2.Open();
                        SqlDataReader dr = cmd2.ExecuteReader();
                        if (dr.Read())
                        {
                            txtFirstN.Text = dr["FirstName"].ToString();
                            txtLastN.Text = dr["LastName"].ToString();
                            string gender = dr["Gender"].ToString();
                            if (gender == "M") rdbMale.Checked = true;
                            else if (gender == "F") rdbFemale.Checked = true;
                            cmbDepartment.Text = dr["Department"].ToString();
                            cmbSub.Text = dr["Subject"].ToString();
                            txtUser.Text = dr["Username"].ToString();
                            txtPass.Text = dr["Password"].ToString();
                        }
                        dr.Close();
                        con2.Close();
                    }

                    MessageBox.Show("Teacher updated successfully!", "Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No rows were updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTeachers_Load(object sender, EventArgs e)
        {
            LoadTeacherData();
        }
    }
}
