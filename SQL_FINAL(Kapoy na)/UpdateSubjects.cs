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
    public partial class UpdateSubjects : Form
    {
        int subjectID;
        string connectionString = ConnectionString.conn;

        public UpdateSubjects(int id, string code, string name, string teacherName, string studentName)
        {
            InitializeComponent();
            subjectID = id;          
            txtSubCode.Text = code;
            txtSubName.Text = name;
            cmbTeacher.Text = teacherName;
            cmbStudents.Text = studentName;
            LoadTeachers();
            LoadStudents();

        }
        private void LoadTeachers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TeacherID, FirstName + ' ' + LastName AS FullName FROM Teachers WHERE Active = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTeacher.DisplayMember = "FullName";
                cmbTeacher.ValueMember = "TeacherID";
                cmbTeacher.DataSource = dt;
            }
        }

        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT StudentID, FirstName + ' ' + LastName AS FullName FROM Students WHERE Active = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbStudents.DisplayMember = "FullName";
                cmbStudents.ValueMember = "StudentID";
                cmbStudents.DataSource = dt;
            }
        }
        private void AddLog(string action, string desc)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_Log", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionType", action);
                cmd.Parameters.AddWithValue("@Description", desc);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubCode.Text) || string.IsNullOrEmpty(txtSubName.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int teacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
            int studentID = Convert.ToInt32(cmbStudents.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Update the Subjects table
                SqlCommand cmd = new SqlCommand("F_UpdateSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                cmd.Parameters.AddWithValue("@SubjectCode", txtSubCode.Text);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubName.Text);
                cmd.Parameters.AddWithValue("@Active", 1);
                cmd.ExecuteNonQuery();

                // Update linked Teacher
                SqlCommand delT = new SqlCommand("DELETE FROM TeacherSubjects WHERE SubjectID = @SID", con);
                delT.Parameters.AddWithValue("@SID", subjectID);
                delT.ExecuteNonQuery();

                SqlCommand insT = new SqlCommand("INSERT INTO TeacherSubjects (TeacherID, SubjectID) VALUES (@TID, @SID)", con);
                insT.Parameters.AddWithValue("@TID", teacherID);
                insT.Parameters.AddWithValue("@SID", subjectID);
                insT.ExecuteNonQuery();

                // Update linked Student
                SqlCommand delS = new SqlCommand("DELETE FROM StudentSubjects WHERE SubjectID = @SID", con);
                delS.Parameters.AddWithValue("@SID", subjectID);
                delS.ExecuteNonQuery();

                SqlCommand insS = new SqlCommand("INSERT INTO StudentSubjects (StudentID, SubjectID) VALUES (@STID, @SID)", con);
                insS.Parameters.AddWithValue("@STID", studentID);
                insS.Parameters.AddWithValue("@SID", subjectID);
                insS.ExecuteNonQuery();

                // Log update
                AddLog("UPDATE", $"Updated Subject {txtSubCode.Text} ({txtSubName.Text})");

                MessageBox.Show("Subject updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
