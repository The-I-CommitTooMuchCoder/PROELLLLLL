namespace SQL_FINAL_Kapoy_na_
{
    partial class TeacherDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherDashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActTeac = new System.Windows.Forms.Label();
            this.pDash = new System.Windows.Forms.Panel();
            this.btnLogOutD = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogsD = new Guna.UI2.WinForms.Guna2Button();
            this.btnSubjectD = new Guna.UI2.WinForms.Guna2Button();
            this.btnTeacherD = new Guna.UI2.WinForms.Guna2Button();
            this.btnStudentD = new Guna.UI2.WinForms.Guna2Button();
            this.pIcons = new System.Windows.Forms.Panel();
            this.btnToggle = new Guna.UI2.WinForms.Guna2Button();
            this.pBoxExit = new System.Windows.Forms.PictureBox();
            this.pBoxLogs = new System.Windows.Forms.PictureBox();
            this.pBoxSubject = new System.Windows.Forms.PictureBox();
            this.ppBoxTeacher = new System.Windows.Forms.PictureBox();
            this.pBoxStudent = new System.Windows.Forms.PictureBox();
            this.btndashboard = new System.Windows.Forms.Button();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.dgvTeachers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.timerSideBar = new System.Windows.Forms.Timer(this.components);
            this.pDash.SuspendLayout();
            this.pIcons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppBoxTeacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(661, 62);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 25);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(160, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 38);
            this.label1.TabIndex = 12;
            this.label1.Text = "Teacher Dashboard";
            // 
            // lblActTeac
            // 
            this.lblActTeac.AutoSize = true;
            this.lblActTeac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.lblActTeac.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblActTeac.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblActTeac.Location = new System.Drawing.Point(163, 68);
            this.lblActTeac.Name = "lblActTeac";
            this.lblActTeac.Size = new System.Drawing.Size(54, 19);
            this.lblActTeac.TabIndex = 15;
            this.lblActTeac.Text = "label2";
            // 
            // pDash
            // 
            this.pDash.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pDash.Controls.Add(this.btnLogOutD);
            this.pDash.Controls.Add(this.btnLogsD);
            this.pDash.Controls.Add(this.btnSubjectD);
            this.pDash.Controls.Add(this.btnTeacherD);
            this.pDash.Controls.Add(this.btnStudentD);
            this.pDash.Controls.Add(this.pIcons);
            this.pDash.Controls.Add(this.btndashboard);
            this.pDash.Controls.Add(this.picProfile);
            this.pDash.Location = new System.Drawing.Point(0, 0);
            this.pDash.Name = "pDash";
            this.pDash.Size = new System.Drawing.Size(199, 567);
            this.pDash.TabIndex = 23;
            // 
            // btnLogOutD
            // 
            this.btnLogOutD.Animated = true;
            this.btnLogOutD.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOutD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOutD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOutD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOutD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOutD.FillColor = System.Drawing.Color.Transparent;
            this.btnLogOutD.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLogOutD.ForeColor = System.Drawing.Color.Tomato;
            this.btnLogOutD.Location = new System.Drawing.Point(3, 500);
            this.btnLogOutD.Name = "btnLogOutD";
            this.btnLogOutD.Size = new System.Drawing.Size(134, 51);
            this.btnLogOutD.TabIndex = 29;
            this.btnLogOutD.Text = "LOGOUT";
            this.btnLogOutD.UseTransparentBackground = true;
            this.btnLogOutD.Click += new System.EventHandler(this.btnLogOutD_Click);
            // 
            // btnLogsD
            // 
            this.btnLogsD.Animated = true;
            this.btnLogsD.BackColor = System.Drawing.Color.Transparent;
            this.btnLogsD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogsD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogsD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogsD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogsD.FillColor = System.Drawing.Color.Transparent;
            this.btnLogsD.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnLogsD.ForeColor = System.Drawing.Color.White;
            this.btnLogsD.Location = new System.Drawing.Point(3, 364);
            this.btnLogsD.Name = "btnLogsD";
            this.btnLogsD.Size = new System.Drawing.Size(134, 51);
            this.btnLogsD.TabIndex = 28;
            this.btnLogsD.Text = "LOGS";
            this.btnLogsD.UseTransparentBackground = true;
            this.btnLogsD.Click += new System.EventHandler(this.btnLogsD_Click);
            // 
            // btnSubjectD
            // 
            this.btnSubjectD.Animated = true;
            this.btnSubjectD.BackColor = System.Drawing.Color.Transparent;
            this.btnSubjectD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSubjectD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSubjectD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSubjectD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSubjectD.FillColor = System.Drawing.Color.Transparent;
            this.btnSubjectD.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSubjectD.ForeColor = System.Drawing.Color.White;
            this.btnSubjectD.Location = new System.Drawing.Point(3, 296);
            this.btnSubjectD.Name = "btnSubjectD";
            this.btnSubjectD.Size = new System.Drawing.Size(134, 51);
            this.btnSubjectD.TabIndex = 27;
            this.btnSubjectD.Text = "SUBJECT";
            this.btnSubjectD.UseTransparentBackground = true;
            this.btnSubjectD.Click += new System.EventHandler(this.btnSubjectD_Click);
            // 
            // btnTeacherD
            // 
            this.btnTeacherD.Animated = true;
            this.btnTeacherD.BackColor = System.Drawing.Color.Transparent;
            this.btnTeacherD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTeacherD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTeacherD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTeacherD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTeacherD.FillColor = System.Drawing.Color.Transparent;
            this.btnTeacherD.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnTeacherD.ForeColor = System.Drawing.Color.White;
            this.btnTeacherD.Location = new System.Drawing.Point(3, 228);
            this.btnTeacherD.Name = "btnTeacherD";
            this.btnTeacherD.Size = new System.Drawing.Size(134, 51);
            this.btnTeacherD.TabIndex = 26;
            this.btnTeacherD.Text = "TEACHER";
            this.btnTeacherD.UseTransparentBackground = true;
            this.btnTeacherD.Click += new System.EventHandler(this.btnTeacherD_Click);
            // 
            // btnStudentD
            // 
            this.btnStudentD.Animated = true;
            this.btnStudentD.BackColor = System.Drawing.Color.Transparent;
            this.btnStudentD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStudentD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStudentD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStudentD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStudentD.FillColor = System.Drawing.Color.Transparent;
            this.btnStudentD.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnStudentD.ForeColor = System.Drawing.Color.White;
            this.btnStudentD.Location = new System.Drawing.Point(3, 160);
            this.btnStudentD.Name = "btnStudentD";
            this.btnStudentD.Size = new System.Drawing.Size(134, 51);
            this.btnStudentD.TabIndex = 25;
            this.btnStudentD.Text = "STUDENT";
            this.btnStudentD.UseTransparentBackground = true;
            // 
            // pIcons
            // 
            this.pIcons.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pIcons.Controls.Add(this.btnToggle);
            this.pIcons.Controls.Add(this.pBoxExit);
            this.pIcons.Controls.Add(this.pBoxLogs);
            this.pIcons.Controls.Add(this.pBoxSubject);
            this.pIcons.Controls.Add(this.ppBoxTeacher);
            this.pIcons.Controls.Add(this.pBoxStudent);
            this.pIcons.Location = new System.Drawing.Point(140, 0);
            this.pIcons.Name = "pIcons";
            this.pIcons.Size = new System.Drawing.Size(57, 572);
            this.pIcons.TabIndex = 19;
            // 
            // btnToggle
            // 
            this.btnToggle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToggle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToggle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToggle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToggle.FillColor = System.Drawing.Color.Transparent;
            this.btnToggle.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 8.25F);
            this.btnToggle.ForeColor = System.Drawing.Color.White;
            this.btnToggle.Location = new System.Drawing.Point(10, 12);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(43, 46);
            this.btnToggle.TabIndex = 24;
            this.btnToggle.Text = "<";
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // pBoxExit
            // 
            this.pBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("pBoxExit.Image")));
            this.pBoxExit.Location = new System.Drawing.Point(2, 500);
            this.pBoxExit.Name = "pBoxExit";
            this.pBoxExit.Padding = new System.Windows.Forms.Padding(5);
            this.pBoxExit.Size = new System.Drawing.Size(52, 51);
            this.pBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxExit.TabIndex = 23;
            this.pBoxExit.TabStop = false;
            // 
            // pBoxLogs
            // 
            this.pBoxLogs.BackColor = System.Drawing.Color.Transparent;
            this.pBoxLogs.Image = ((System.Drawing.Image)(resources.GetObject("pBoxLogs.Image")));
            this.pBoxLogs.Location = new System.Drawing.Point(2, 364);
            this.pBoxLogs.Name = "pBoxLogs";
            this.pBoxLogs.Padding = new System.Windows.Forms.Padding(3);
            this.pBoxLogs.Size = new System.Drawing.Size(52, 51);
            this.pBoxLogs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxLogs.TabIndex = 22;
            this.pBoxLogs.TabStop = false;
            // 
            // pBoxSubject
            // 
            this.pBoxSubject.BackColor = System.Drawing.Color.Transparent;
            this.pBoxSubject.Image = ((System.Drawing.Image)(resources.GetObject("pBoxSubject.Image")));
            this.pBoxSubject.Location = new System.Drawing.Point(2, 296);
            this.pBoxSubject.Name = "pBoxSubject";
            this.pBoxSubject.Padding = new System.Windows.Forms.Padding(5);
            this.pBoxSubject.Size = new System.Drawing.Size(52, 51);
            this.pBoxSubject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxSubject.TabIndex = 20;
            this.pBoxSubject.TabStop = false;
            // 
            // ppBoxTeacher
            // 
            this.ppBoxTeacher.BackColor = System.Drawing.Color.Transparent;
            this.ppBoxTeacher.Image = ((System.Drawing.Image)(resources.GetObject("ppBoxTeacher.Image")));
            this.ppBoxTeacher.Location = new System.Drawing.Point(2, 228);
            this.ppBoxTeacher.Name = "ppBoxTeacher";
            this.ppBoxTeacher.Padding = new System.Windows.Forms.Padding(7);
            this.ppBoxTeacher.Size = new System.Drawing.Size(52, 51);
            this.ppBoxTeacher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ppBoxTeacher.TabIndex = 19;
            this.ppBoxTeacher.TabStop = false;
            // 
            // pBoxStudent
            // 
            this.pBoxStudent.BackColor = System.Drawing.Color.Transparent;
            this.pBoxStudent.Image = ((System.Drawing.Image)(resources.GetObject("pBoxStudent.Image")));
            this.pBoxStudent.Location = new System.Drawing.Point(2, 160);
            this.pBoxStudent.Name = "pBoxStudent";
            this.pBoxStudent.Size = new System.Drawing.Size(52, 51);
            this.pBoxStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxStudent.TabIndex = 18;
            this.pBoxStudent.TabStop = false;
            this.pBoxStudent.Click += new System.EventHandler(this.pBoxStudent_Click);
            // 
            // btndashboard
            // 
            this.btndashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndashboard.FlatAppearance.BorderSize = 0;
            this.btndashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashboard.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndashboard.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btndashboard.Location = new System.Drawing.Point(13, 21);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Size = new System.Drawing.Size(115, 28);
            this.btndashboard.TabIndex = 17;
            this.btndashboard.Text = "DASHBOARD";
            this.btndashboard.UseVisualStyleBackColor = true;
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.picProfile.Location = new System.Drawing.Point(28, 58);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(85, 85);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfile.TabIndex = 2;
            this.picProfile.TabStop = false;
            // 
            // dgvTeachers
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTeachers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeachers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTeachers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeachers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeachers.Location = new System.Drawing.Point(150, 94);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.RowHeadersVisible = false;
            this.dgvTeachers.Size = new System.Drawing.Size(720, 413);
            this.dgvTeachers.TabIndex = 24;
            this.dgvTeachers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTeachers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTeachers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTeachers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTeachers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeachers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvTeachers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTeachers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTeachers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTeachers.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvTeachers.ThemeStyle.ReadOnly = false;
            this.dgvTeachers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTeachers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTeachers.ThemeStyle.RowsStyle.Height = 22;
            this.dgvTeachers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTeachers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(922, 567);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 25;
            this.guna2PictureBox2.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Animated = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Tomato;
            this.btnDelete.Location = new System.Drawing.Point(738, 513);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(128, 48);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Animated = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.Transparent;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(336, 513);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(128, 48);
            this.btnEdit.TabIndex = 30;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(150, 513);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(128, 48);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "ADD";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Animated = true;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.Transparent;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(542, 513);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(128, 48);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.lblName);
            this.guna2Panel1.Location = new System.Drawing.Point(698, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(202, 31);
            this.guna2Panel1.TabIndex = 32;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(3, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(196, 14);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "W";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerSideBar
            // 
            this.timerSideBar.Tick += new System.EventHandler(this.timerSideBar_Tick);
            // 
            // TeacherDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 567);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.pDash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblActTeac);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvTeachers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.guna2PictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TeacherDash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherDash";
            this.Load += new System.EventHandler(this.TeacherDash_Load);
            this.pDash.ResumeLayout(false);
            this.pIcons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppBoxTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActTeac;
        private System.Windows.Forms.Panel pDash;
        private Guna.UI2.WinForms.Guna2Button btnLogOutD;
        private Guna.UI2.WinForms.Guna2Button btnLogsD;
        private Guna.UI2.WinForms.Guna2Button btnSubjectD;
        private Guna.UI2.WinForms.Guna2Button btnTeacherD;
        private Guna.UI2.WinForms.Guna2Button btnStudentD;
        private System.Windows.Forms.Panel pIcons;
        private Guna.UI2.WinForms.Guna2Button btnToggle;
        private System.Windows.Forms.PictureBox pBoxExit;
        private System.Windows.Forms.PictureBox pBoxLogs;
        private System.Windows.Forms.PictureBox pBoxSubject;
        private System.Windows.Forms.PictureBox ppBoxTeacher;
        private System.Windows.Forms.PictureBox pBoxStudent;
        private System.Windows.Forms.Button btndashboard;
        private System.Windows.Forms.PictureBox picProfile;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTeachers;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Timer timerSideBar;
    }
}