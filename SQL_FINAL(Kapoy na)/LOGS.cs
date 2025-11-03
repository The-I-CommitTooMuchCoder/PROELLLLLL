using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
        }

        string connectionString =ConnectionString.conn;
        private void Student()
        {
            StudentDashboard studentDash = new StudentDashboard();
            studentDash.Show();
            this.Hide();
        }

        private void Teacher()
        {
            this.Hide();
            TeacherDashboard teacherDash = new TeacherDashboard();
            teacherDash.Show();
        }
        private void Subject()
        {
            SubjectsDashboard sUBJECT = new SubjectsDashboard();
            sUBJECT.Show();
            this.Hide();
        }

        private void Logs()
        {
            Logs lOGS = new Logs();
            lOGS.Show();
            this.Hide();
        }

        private void Logout()
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void LOGS_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{UserSession.FirstName} {UserSession.LastName}";

            if (!string.IsNullOrEmpty(UserSession.ProfilePath) && File.Exists(UserSession.ProfilePath))
            {
                picProfile.Image = new Bitmap(UserSession.ProfilePath);
            }
            else
            {
                picProfile.Image = null; // or a default picture
            }
            LoadLogs();
        }
        private void LoadLogs()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("F_AllLogs", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLogs.DataSource = dt;

                dgvLogs.Columns["LogID"].HeaderText = "ID";
                dgvLogs.Columns["ActionType"].HeaderText = "Action";
                dgvLogs.Columns["Description"].HeaderText = "Description";
                dgvLogs.Columns["DateLogged"].HeaderText = "Date & Time";

                dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("F_SearchLogs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLogs.DataSource = dt;
            }
        }

        private void btnStudentD_Click_1(object sender, EventArgs e)
        {
            Student();        }

        private void btnTeacherD_Click(object sender, EventArgs e)
        {
            Teacher();
        }

        private void btnSubjectD_Click(object sender, EventArgs e)
        {
            Subject();
        }

        private void btnLogsD_Click(object sender, EventArgs e)
        {
            Logs();
        }

        private void btnLogOutD_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void pBoxStudent_Click(object sender, EventArgs e)
        {
            Student();
        }

        private void ppBoxTeacher_Click(object sender, EventArgs e)
        {
            Teacher();
        }

        private void pBoxSubject_Click(object sender, EventArgs e)
        {
            Subject();
        }

        private void pBoxLogs_Click(object sender, EventArgs e)
        {
            Logs();
        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
