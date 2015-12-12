namespace WindowsFormsApplication1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblJudul = new System.Windows.Forms.Label();
            this.cmbxAlarm = new System.Windows.Forms.ComboBox();
            this.ckLisBxSensor = new System.Windows.Forms.CheckedListBox();
            this.btnTestAlem = new System.Windows.Forms.Button();
            this.dtgLogMessage = new System.Windows.Forms.DataGridView();
            this.dtgcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgcWaktu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgcMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpbControlLog = new System.Windows.Forms.GroupBox();
            this.btnDeleteAllLog = new System.Windows.Forms.Button();
            this.btnDeleteLog = new System.Windows.Forms.Button();
            this.grpbSuaraAlarm = new System.Windows.Forms.GroupBox();
            this.alertPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.grpbPendeteksianSuara = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLogMessage)).BeginInit();
            this.grpbControlLog.SuspendLayout();
            this.grpbSuaraAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertPlayer)).BeginInit();
            this.grpbPendeteksianSuara.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(119, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(38, 21);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(224, 20);
            this.lblJudul.TabIndex = 2;
            this.lblJudul.Text = "Sistem Pengawasan Suara";
            // 
            // cmbxAlarm
            // 
            this.cmbxAlarm.FormattingEnabled = true;
            this.cmbxAlarm.Location = new System.Drawing.Point(6, 19);
            this.cmbxAlarm.Name = "cmbxAlarm";
            this.cmbxAlarm.Size = new System.Drawing.Size(188, 21);
            this.cmbxAlarm.TabIndex = 6;
            this.cmbxAlarm.Text = "--SELECT---";
            this.cmbxAlarm.SelectedIndexChanged += new System.EventHandler(this.cmbxAlarm_SelectedIndexChanged);
            // 
            // ckLisBxSensor
            // 
            this.ckLisBxSensor.FormattingEnabled = true;
            this.ckLisBxSensor.Location = new System.Drawing.Point(6, 48);
            this.ckLisBxSensor.Name = "ckLisBxSensor";
            this.ckLisBxSensor.Size = new System.Drawing.Size(188, 124);
            this.ckLisBxSensor.TabIndex = 7;
            // 
            // btnTestAlem
            // 
            this.btnTestAlem.Location = new System.Drawing.Point(6, 46);
            this.btnTestAlem.Name = "btnTestAlem";
            this.btnTestAlem.Size = new System.Drawing.Size(75, 23);
            this.btnTestAlem.TabIndex = 8;
            this.btnTestAlem.Text = "Test Suara Alarm";
            this.btnTestAlem.UseVisualStyleBackColor = true;
            this.btnTestAlem.Click += new System.EventHandler(this.btnTestAlem_Click);
            // 
            // dtgLogMessage
            // 
            this.dtgLogMessage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgLogMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLogMessage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtgcNo,
            this.dtgcCode,
            this.dtgcWaktu,
            this.dtgcMessage});
            this.dtgLogMessage.Location = new System.Drawing.Point(6, 39);
            this.dtgLogMessage.Name = "dtgLogMessage";
            this.dtgLogMessage.Size = new System.Drawing.Size(753, 286);
            this.dtgLogMessage.TabIndex = 11;
            this.dtgLogMessage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
            // 
            // dtgcNo
            // 
            this.dtgcNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dtgcNo.HeaderText = "No";
            this.dtgcNo.MinimumWidth = 2;
            this.dtgcNo.Name = "dtgcNo";
            this.dtgcNo.ReadOnly = true;
            this.dtgcNo.Width = 46;
            // 
            // dtgcCode
            // 
            this.dtgcCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dtgcCode.HeaderText = "Kode";
            this.dtgcCode.Name = "dtgcCode";
            this.dtgcCode.ReadOnly = true;
            this.dtgcCode.Width = 57;
            // 
            // dtgcWaktu
            // 
            this.dtgcWaktu.HeaderText = "Waktu";
            this.dtgcWaktu.Name = "dtgcWaktu";
            // 
            // dtgcMessage
            // 
            this.dtgcMessage.HeaderText = "Pesan";
            this.dtgcMessage.Name = "dtgcMessage";
            this.dtgcMessage.ReadOnly = true;
            // 
            // grpbControlLog
            // 
            this.grpbControlLog.Controls.Add(this.btnDeleteAllLog);
            this.grpbControlLog.Controls.Add(this.btnDeleteLog);
            this.grpbControlLog.Controls.Add(this.dtgLogMessage);
            this.grpbControlLog.Location = new System.Drawing.Point(227, 92);
            this.grpbControlLog.Name = "grpbControlLog";
            this.grpbControlLog.Size = new System.Drawing.Size(766, 331);
            this.grpbControlLog.TabIndex = 12;
            this.grpbControlLog.TabStop = false;
            this.grpbControlLog.Text = "Log Aktivitas Aplikasi";
            // 
            // btnDeleteAllLog
            // 
            this.btnDeleteAllLog.Location = new System.Drawing.Point(87, 15);
            this.btnDeleteAllLog.Name = "btnDeleteAllLog";
            this.btnDeleteAllLog.Size = new System.Drawing.Size(107, 23);
            this.btnDeleteAllLog.TabIndex = 1;
            this.btnDeleteAllLog.Text = "Hapus Semua Log";
            this.btnDeleteAllLog.UseVisualStyleBackColor = true;
            this.btnDeleteAllLog.Click += new System.EventHandler(this.btnDeleteAllLog_Click);
            // 
            // btnDeleteLog
            // 
            this.btnDeleteLog.Location = new System.Drawing.Point(6, 15);
            this.btnDeleteLog.Name = "btnDeleteLog";
            this.btnDeleteLog.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLog.TabIndex = 0;
            this.btnDeleteLog.Text = "Hapus Log";
            this.btnDeleteLog.UseVisualStyleBackColor = true;
            this.btnDeleteLog.Click += new System.EventHandler(this.btnDeleteLog_Click);
            // 
            // grpbSuaraAlarm
            // 
            this.grpbSuaraAlarm.Controls.Add(this.alertPlayer);
            this.grpbSuaraAlarm.Controls.Add(this.cmbxAlarm);
            this.grpbSuaraAlarm.Controls.Add(this.btnTestAlem);
            this.grpbSuaraAlarm.Location = new System.Drawing.Point(21, 281);
            this.grpbSuaraAlarm.Name = "grpbSuaraAlarm";
            this.grpbSuaraAlarm.Size = new System.Drawing.Size(200, 142);
            this.grpbSuaraAlarm.TabIndex = 13;
            this.grpbSuaraAlarm.TabStop = false;
            this.grpbSuaraAlarm.Text = "SuaraAlarm";
            // 
            // alertPlayer
            // 
            this.alertPlayer.Enabled = true;
            this.alertPlayer.Location = new System.Drawing.Point(6, 75);
            this.alertPlayer.Name = "alertPlayer";
            this.alertPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("alertPlayer.OcxState")));
            this.alertPlayer.Size = new System.Drawing.Size(188, 61);
            this.alertPlayer.TabIndex = 9;
            // 
            // grpbPendeteksianSuara
            // 
            this.grpbPendeteksianSuara.Controls.Add(this.btnStart);
            this.grpbPendeteksianSuara.Controls.Add(this.btnStop);
            this.grpbPendeteksianSuara.Controls.Add(this.ckLisBxSensor);
            this.grpbPendeteksianSuara.Location = new System.Drawing.Point(21, 92);
            this.grpbPendeteksianSuara.Name = "grpbPendeteksianSuara";
            this.grpbPendeteksianSuara.Size = new System.Drawing.Size(200, 183);
            this.grpbPendeteksianSuara.TabIndex = 14;
            this.grpbPendeteksianSuara.TabStop = false;
            this.grpbPendeteksianSuara.Text = "PendeteksianSuara";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1005, 435);
            this.Controls.Add(this.grpbPendeteksianSuara);
            this.Controls.Add(this.grpbSuaraAlarm);
            this.Controls.Add(this.grpbControlLog);
            this.Controls.Add(this.lblJudul);
            this.Name = "MainForm";
            this.Text = "Sound Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.dtgLogMessage)).EndInit();
            this.grpbControlLog.ResumeLayout(false);
            this.grpbSuaraAlarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alertPlayer)).EndInit();
            this.grpbPendeteksianSuara.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.ComboBox cmbxAlarm;
        private System.Windows.Forms.CheckedListBox ckLisBxSensor;
        private System.Windows.Forms.Button btnTestAlem;
        private System.Windows.Forms.DataGridView dtgLogMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgcWaktu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtgcMessage;
        private System.Windows.Forms.GroupBox grpbControlLog;
        private System.Windows.Forms.Button btnDeleteAllLog;
        private System.Windows.Forms.Button btnDeleteLog;
        private System.Windows.Forms.GroupBox grpbSuaraAlarm;
        private System.Windows.Forms.GroupBox grpbPendeteksianSuara;
        private AxWMPLib.AxWindowsMediaPlayer alertPlayer;
    }
}

