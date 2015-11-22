namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.btnstart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblJudul = new System.Windows.Forms.Label();
            this.labelSubjudul1 = new System.Windows.Forms.Label();
            this.labelSubjudul2 = new System.Windows.Forms.Label();
            this.cmbxAlarm = new System.Windows.Forms.ComboBox();
            this.ckLisBxSensor = new System.Windows.Forms.CheckedListBox();
            this.btnTestAlem = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(402, 35);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(75, 23);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(488, 35);
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
            // labelSubjudul1
            // 
            this.labelSubjudul1.AutoSize = true;
            this.labelSubjudul1.Location = new System.Drawing.Point(39, 74);
            this.labelSubjudul1.Name = "labelSubjudul1";
            this.labelSubjudul1.Size = new System.Drawing.Size(103, 13);
            this.labelSubjudul1.TabIndex = 3;
            this.labelSubjudul1.Text = "Pendeteksian Suara";
            // 
            // labelSubjudul2
            // 
            this.labelSubjudul2.AutoSize = true;
            this.labelSubjudul2.Location = new System.Drawing.Point(39, 196);
            this.labelSubjudul2.Name = "labelSubjudul2";
            this.labelSubjudul2.Size = new System.Drawing.Size(63, 13);
            this.labelSubjudul2.TabIndex = 4;
            this.labelSubjudul2.Text = "Suara alarm";
            // 
            // cmbxAlarm
            // 
            this.cmbxAlarm.FormattingEnabled = true;
            this.cmbxAlarm.Items.AddRange(new object[] {
            "Alert1",
            "Alert2",
            "Alert3"});
            this.cmbxAlarm.Location = new System.Drawing.Point(42, 212);
            this.cmbxAlarm.Name = "cmbxAlarm";
            this.cmbxAlarm.Size = new System.Drawing.Size(125, 21);
            this.cmbxAlarm.TabIndex = 6;
            this.cmbxAlarm.SelectedIndexChanged += new System.EventHandler(this.cmbxAlarm_SelectedIndexChanged);
            // 
            // ckLisBxSensor
            // 
            this.ckLisBxSensor.FormattingEnabled = true;
            this.ckLisBxSensor.Location = new System.Drawing.Point(42, 90);
            this.ckLisBxSensor.Name = "ckLisBxSensor";
            this.ckLisBxSensor.Size = new System.Drawing.Size(120, 94);
            this.ckLisBxSensor.TabIndex = 7;
            // 
            // btnTestAlem
            // 
            this.btnTestAlem.Location = new System.Drawing.Point(42, 254);
            this.btnTestAlem.Name = "btnTestAlem";
            this.btnTestAlem.Size = new System.Drawing.Size(75, 23);
            this.btnTestAlem.TabIndex = 8;
            this.btnTestAlem.Text = "Test Suara Alarm";
            this.btnTestAlem.UseVisualStyleBackColor = true;
            this.btnTestAlem.Click += new System.EventHandler(this.btnTestAlem_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(227, 93);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(336, 184);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Log Aktifitas Aplikasi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(575, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnTestAlem);
            this.Controls.Add(this.ckLisBxSensor);
            this.Controls.Add(this.cmbxAlarm);
            this.Controls.Add(this.labelSubjudul2);
            this.Controls.Add(this.labelSubjudul1);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnstart);
            this.Name = "Form1";
            this.Text = "Sound Recognition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label labelSubjudul1;
        private System.Windows.Forms.Label labelSubjudul2;
        private System.Windows.Forms.ComboBox cmbxAlarm;
        private System.Windows.Forms.CheckedListBox ckLisBxSensor;
        private System.Windows.Forms.Button btnTestAlem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}

