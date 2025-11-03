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
using System.Windows.Forms.DataVisualization.Charting;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class Dashboard : Form
    {
        string connectionString = ConnectionString.conn;
        bool isHidden = false;
        int shownX;
        int hiddenX;
        int slideSpeed = 12; // pixels per tick (adjust for smoothness)

        private void Logout()
        {
            MessageBox.Show("Are you really sure to log out?", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult == DialogResult.OK) 
            {
                UserSession.FirstName = null;
                UserSession.LastName = null;
                UserSession.ProfilePath = null;

                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {

            }
        }

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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{UserSession.FirstName} {UserSession.LastName}";

            shownX = pDash.Left;                // visible position
            hiddenX = pDash.Left - 130;  // completely hidden off-screen
            timerSideBar.Interval = 10;              // controls animation speed

            if (!string.IsNullOrEmpty(UserSession.ProfilePath) && File.Exists(UserSession.ProfilePath))
            {
                picProfile.Image = new Bitmap(UserSession.ProfilePath);
            }
            else
            {
                picProfile.Image = null;
            }
            LoadStudentChart();
            LoadTeacherChart();
        }

        public Dashboard()
        {
            InitializeComponent();
        }
        private void LoadStudentChart()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int active = Convert.ToInt32(reader["ActiveStudents"]);
                    int inactive = Convert.ToInt32(reader["InactiveStudents"]);

                    chartStudents.Series.Clear();
                    Series series = new Series("Students");
                    series.ChartType = SeriesChartType.Pie;
                    series.Points.AddXY("Active", active);
                    series.Points.AddXY("Inactive", inactive);
                    chartStudents.Series.Add(series);
                }
            }
        }
        private void LoadTeacherChart()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CTeachers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int active = Convert.ToInt32(reader["ActiveTeachers"]);
                    int inactive = Convert.ToInt32(reader["InactiveTeachers"]);

                    chartTeachers.Series.Clear();
                    Series series = new Series("Teachers");
                    series.ChartType = SeriesChartType.Pie;
                    series.Points.AddXY("Active", active);
                    series.Points.AddXY("Inactive", inactive);
                    chartTeachers.Series.Add(series);
                }
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            timerSideBar.Start();
            
        }

        private void timerSideBar_Tick(object sender, EventArgs e)
        {
            if (isHidden)
            {
                // Slide in (move right)
                pDash.Left += slideSpeed;

                if (pDash.Left >= shownX)
                {
                    pDash.Left = shownX;
                    timerSideBar.Stop();
                    isHidden = false;
                }
            }
            else
            {
                // Slide out (move left)
                pDash.Left -= slideSpeed;

                if (pDash.Left <= hiddenX)
                {
                    pDash.Left = hiddenX;
                    timerSideBar.Stop();
                    isHidden = true;
                }
            }
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

        private void picProfile_Click(object sender, EventArgs e)
        {

        }

        private void pBoxCont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void btnStudentD_Click_1(object sender, EventArgs e)
        {
            Student();
        }

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
    }
}
