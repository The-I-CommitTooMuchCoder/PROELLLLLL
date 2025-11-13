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
using Word = Microsoft.Office.Interop.Word;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            dgvStudents.CurrentCellDirtyStateChanged += dgvStudents_CurrentCellDirtyStateChanged;
        }

        string connectionString = ConnectionString.conn;
        bool isHidden = false;
        int shownX;
        int hiddenX;
        int slideSpeed = 12; // pixels per tick (adjust for smoothness)
        private void ExportToWord()
        {
            try
            {
                // Create Word app & document
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();

                // Add title
                Word.Paragraph header = doc.Content.Paragraphs.Add();
                header.Range.Text = "Active Students";
                header.Range.Font.Bold = 1;
                header.Range.Font.Size = 11;
                header.Range.InsertParagraphAfter();

                // Get visible (bound) columns count
                int colCount = dgvStudents.Columns.Count;

                // Filter only active rows
                var activeRows = dgvStudents.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["Active"].Value) == true)
                    .ToList();

                if (activeRows.Count == 0)
                {
                    MessageBox.Show("No active students found to export.");
                    return;
                }

                // Add table (rows + header)
                Word.Table table = doc.Tables.Add(header.Range, activeRows.Count + 1, colCount);
                table.Borders.Enable = 1;

                // Header row
                for (int c = 0; c < colCount; c++)
                {
                    table.Cell(1, c + 1).Range.Text = dgvStudents.Columns[c].HeaderText;
                    table.Cell(1, c + 1).Range.Bold = 1;
                }

                // Fill rows with data
                int rowIndex = 2;
                foreach (DataGridViewRow row in activeRows)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        table.Cell(rowIndex, c + 1).Range.Text = row.Cells[c].Value?.ToString() ?? "";
                    }
                    rowIndex++;
                }

                // Show Word document
                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting: " + ex.Message);
            }
        }

        private void StudentDash_Load(object sender, EventArgs e)
        {
            lblActstud.Text = $"{UserSession.FirstName} {UserSession.LastName}";
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
            dgvStudents.CurrentCellDirtyStateChanged += dgvStudents_CurrentCellDirtyStateChanged;
            dgvStudents.CellValueChanged += dgvStudents_CellValueChanged;
            LoadStudents();
            CountStudents();
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

        private void Edit()
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);

            UpdateStudents update = new UpdateStudents(studentID);
            update.ShowDialog();
            LoadStudents();
        }

        private void Delete()
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this student?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.ExecuteNonQuery();
                }

                AddLog("DELETE", $"Deleted student ID: {studentID}");
                MessageBox.Show("Student deleted successfully!");
                LoadStudents();
                CountStudents();
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

        private void Search()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }       
        }

        private void dgvStudents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.Columns[e.ColumnIndex].Name == "Active")
            {
                int studentID = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value);
                bool newStatus = Convert.ToBoolean(dgvStudents.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_ActiveStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }

                AddLog("UPDATE", $"Changed student ID {studentID} Active status to {newStatus}");
                CountStudents();
            }
        }

        private void dgvStudents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStudents.IsCurrentCellDirty)
            {
                dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("F_AllStudents", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
                
                dgvStudents.ReadOnly = false;
                dgvStudents.Columns["StudentID"].ReadOnly = true; 
                dgvStudents.Columns["Active"].ReadOnly = false;
            }
        }

        private void CountStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CountActS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = (int)cmd.ExecuteScalar();
                lblActSub.Text = $"Active Students: {count}";
            }
        }

        private void btnStudentD_Click(object sender, EventArgs e)
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

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.Columns[e.ColumnIndex].Name == "Active")
            {
                int studentID = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value);
                bool newStatus = Convert.ToBoolean(dgvStudents.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_ActiveStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }

                AddLog("UPDATE", $"Set student ID {studentID} active status to {newStatus}");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudents addStudent = new AddStudents();
            addStudent.Show();
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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

        private void btnToggle_Click(object sender, EventArgs e)
        {
            timerSideBar.Start();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dsh = new Dashboard();
            dsh.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}