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
        bool isHidden = false;
        int shownX;
        int hiddenX;
        int slideSpeed = 12; // pixels per tick (adjust for smoothness)

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

        private void OpenLogs()
        {
            Logs lOGS = new Logs();
            lOGS.Show();
            this.Hide();
        }

        private void Logout()
        {
            // Show a message box and get the user's choice
            DialogResult result = MessageBox.Show(
                "Are you really sure you want to log out?",
                "Notice",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information
            );

            // Check the result
            if (result == DialogResult.OK)
            {
                // Clear user session
                UserSession.FirstName = null;
                UserSession.LastName = null;
                UserSession.ProfilePath = null;

                // Show login form
                Login login = new Login();
                login.Show();

                // Hide current form
                this.Hide();
            }
            // else do nothing (user cancelled)
        }

        private void LOGS_Load(object sender, EventArgs e)
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
            OpenLogs();
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
            OpenLogs();
        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            Logout();
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

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dsh = new Dashboard();
            dsh.Show();
            this.Hide();
        }
    }
}
