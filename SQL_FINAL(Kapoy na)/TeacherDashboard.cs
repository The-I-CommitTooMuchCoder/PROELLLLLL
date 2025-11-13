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
    public partial class TeacherDashboard : Form
    {
        string connectionString = ConnectionString.conn;
        public TeacherDashboard()
        {
            InitializeComponent();
            dgvTeachers.CurrentCellDirtyStateChanged += dgvTeachers_CurrentCellDirtyStateChanged;
            dgvTeachers.CellValueChanged += dgvTeachers_CellValueChanged;
        }

        private void ExportToWord()
        {
            try
            {
                // Create Word app & document
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();

                // Add title
                Word.Paragraph header = doc.Content.Paragraphs.Add();
                header.Range.Text = "Active Teachers";
                header.Range.Font.Bold = 1;
                header.Range.Font.Size = 11;
                header.Range.InsertParagraphAfter();

                // Get visible (bound) columns count
                int colCount = dgvTeachers.Columns.Count;

                // Filter only active rows
                var activeRows = dgvTeachers.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["Active"].Value) == true)
                    .ToList();

                if (activeRows.Count == 0)
                {
                    MessageBox.Show("No active teachers found to export.");
                    return;
                }

                // Add table (rows + header)
                Word.Table table = doc.Tables.Add(header.Range, activeRows.Count + 1, colCount);
                table.Borders.Enable = 1;

                // Header row
                for (int c = 0; c < colCount; c++)
                {
                    table.Cell(1, c + 1).Range.Text = dgvTeachers.Columns[c].HeaderText;
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

        private void TeacherDash_Load(object sender, EventArgs e)
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
            LoadTeachers();
            CountTeachers();
        }
        private void LoadTeachers()
        {
            shownX = pDash.Left;                // visible position
            hiddenX = pDash.Left - 130;  // completely hidden off-screen
            timerSideBar.Interval = 10;              // controls animation speed

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("F_AllTeachers", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTeachers.DataSource = dt;

                dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTeachers.ReadOnly = false;
                dgvTeachers.Columns["TeacherID"].ReadOnly = true;
                dgvTeachers.Columns["Active"].ReadOnly = false;
                dgvTeachers.Columns["Active"].HeaderText = "Active";

                //con.Open();
                //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Teachers ORDER BY TeacherID DESC", con);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //dgvTeachers.DataSource = dt;

                //dgvTeachers.Columns["TeacherID"].ReadOnly = true;
                //dgvTeachers.Columns["Active"].ReadOnly = false;

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

        private void dgvTeachers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTeachers.IsCurrentCellDirty)
                dgvTeachers.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvTeachers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTeachers.Columns[e.ColumnIndex].Name == "Active")
            {
                int teacherID = Convert.ToInt32(dgvTeachers.Rows[e.RowIndex].Cells["TeacherID"].Value);
                bool newStatus = Convert.ToBoolean(dgvTeachers.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_UpActStatusT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }

                AddLog("UPDATE", $"Changed teacher {teacherID} active status to {newStatus}");
                CountTeachers();
            }
        }
        private void CountTeachers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CountActT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = (int)cmd.ExecuteScalar();
                lblActTeac.Text = $"Active Teachers: {count}";
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTeachers.DataSource = dt;
            }
        }

        private void Add()
        {
            AddTeachers add = new AddTeachers();
            add.ShowDialog();
            LoadTeachers();
            CountTeachers();
        }

        private void Updates()
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to update.");
                return;
            }

            DataGridViewRow row = dgvTeachers.SelectedRows[0];
            int teacherID = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["TeacherID"].Value);

            UpdateTeachers update = new UpdateTeachers(teacherID);

            update.ShowDialog();
            LoadTeachers(); // reload grid after editing
        }

        private void Delete()
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a teacher to delete.");
                return;
            }

            int teacherID = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["TeacherID"].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirm Delete",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteTeacher", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                    cmd.ExecuteNonQuery();
                }

                AddLog("DELETE", $"Deleted teacher ID {teacherID}");
                MessageBox.Show("Teacher deleted successfully!");
                LoadTeachers();
                CountTeachers();
            }
        }
        private void AddLog(string action, string desc)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand log = new SqlCommand("F_Log", con);
                log.CommandType = CommandType.StoredProcedure;
                log.Parameters.AddWithValue("@ActionType", action);
                log.Parameters.AddWithValue("@Description", desc);
                log.ExecuteNonQuery();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Add();
        }

        private void pBoxStudent_Click(object sender, EventArgs e)
        {
            Student();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Updates();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExportToWord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
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

        bool isHidden = false;
        int shownX;
        int hiddenX;
        int slideSpeed = 12; // pixels per tick (adjust for smoothness)

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

        private void btnStudentD_Click(object sender, EventArgs e)
        {
            Student();
        }
    }
}
