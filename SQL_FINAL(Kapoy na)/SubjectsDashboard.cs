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
    public partial class SubjectsDashboard : Form
    {
        public SubjectsDashboard()
        {
            InitializeComponent();
            dgvSubjects.CurrentCellDirtyStateChanged += dgvSubjects_CurrentCellDirtyStateChanged;
            dgvSubjects.CellValueChanged += dgvSubjects_CellValueChanged;
        }

        string connectionString = ConnectionString.conn;
        bool isHidden = false;
        int shownX;
        int hiddenX;
        int slideSpeed = 12; // pixels per tick (adjust for smoothness)
        private void ExportToWord(string columnName)
        {
            try
            {
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();

                // Add title
                Word.Paragraph header = doc.Content.Paragraphs.Add();
                header.Range.Text = $"Data from column: {columnName}";
                header.Range.Font.Bold = 1;
                header.Range.Font.Size = 14;
                header.Range.InsertParagraphAfter();

                // Add table with 1 column
                int rowCount = dgvSubjects.Rows.Count - 1; // minus new row
                Word.Table table = doc.Tables.Add(header.Range, rowCount + 1, 1);
                table.Borders.Enable = 1;

                // Header row
                table.Cell(1, 1).Range.Text = columnName;
                table.Cell(1, 1).Range.Bold = 1;

                // Fill rows
                int rowIndex = 2;
                foreach (DataGridViewRow row in dgvSubjects.Rows)
                {
                    if (row.IsNewRow) continue;

                    table.Cell(rowIndex, 1).Range.Text = row.Cells[columnName].Value?.ToString();
                    rowIndex++;
                }

                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting: " + ex.Message);
            }
        }

        private void Subjects_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{UserSession.FirstName} {UserSession.LastName}";

            if (!string.IsNullOrEmpty(UserSession.ProfilePath) && File.Exists(UserSession.ProfilePath))
            {
                picProfile.Image = new Bitmap(UserSession.ProfilePath);
            }
            else
            {
                picProfile.Image = null; 
            }
            LoadSubjects();
            CountSubjects();
        }

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



        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void LoadSubjects()
        {
            shownX = pDash.Left;                // visible position
            hiddenX = pDash.Left - 130;  // completely hidden off-screen
            timerSideBar.Interval = 10;              // controls animation speed

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("F_AllSub", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubjects.DataSource = dt;

                dgvSubjects.ReadOnly = false;
                if (dgvSubjects.Columns.Contains("Active"))
                {
                    dgvSubjects.Columns["Active"].ReadOnly = false;
                }
            }
        }
        private void CountSubjects()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CountActSubjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = (int)cmd.ExecuteScalar();
                lblActSub.Text = $"Active Subjects: {count}";
            }
        }
        private void dgvSubjects_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.IsCurrentCellDirty)
                dgvSubjects.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvSubjects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSubjects.Columns[e.ColumnIndex].Name == "Active")
            {
                int subjectID = Convert.ToInt32(dgvSubjects.Rows[e.RowIndex].Cells["SubjectID"].Value);
                bool newStatus = Convert.ToBoolean(dgvSubjects.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_UpdateActiveSubject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }

                CountSubjects();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubjects.DataSource = dt;
            }
        }

        private void Add()
        {
            AddSubjects add = new AddSubjects();
            add.ShowDialog();
            LoadSubjects();
            CountSubjects();
        }

        private void Updates()
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            int subjectID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["SubjectID"].Value);
            string code = dgvSubjects.SelectedRows[0].Cells["SubjectCode"].Value.ToString();
            string name = dgvSubjects.SelectedRows[0].Cells["SubjectName"].Value.ToString();
            string teacherName = dgvSubjects.SelectedRows[0].Cells["TeacherName"].Value.ToString();
            string studentName = dgvSubjects.SelectedRows[0].Cells["StudentName"].Value.ToString();
            bool active = Convert.ToBoolean(dgvSubjects.SelectedRows[0].Cells["Active"].Value);

            UpdateSubjects upd = new UpdateSubjects(subjectID, code, name, teacherName, studentName);
            upd.ShowDialog();
            LoadSubjects();

        }

        private void Delete()
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            int subjectID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["SubjectID"].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this subject?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteSubject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Subject deleted successfully!");
                LoadSubjects();
                CountSubjects();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string selectedColumn = dgvSubjects.SelectedCells[0].OwningColumn.Name;
            ExportToWord(selectedColumn);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Updates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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
