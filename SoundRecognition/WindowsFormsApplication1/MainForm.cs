using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using WindowsFormsApplication1.Entity;
using WindowsFormsApplication1.Util;



namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {

        DBEngine db = new DBEngine();
        List<AudioType> audios;
        List<LogAudioDetection> logAudios;
        Thread[] workerThread;
        Worker[] worker;
        const int MAX_PROCESS = 6;


        public MainForm()
        {
            InitializeComponent();
            InitializeSystemApps();
            initCustom();
            
        }

        private void initCustom()
        {
            this.dtgLogMessage.DefaultCellStyle.WrapMode = DataGridViewTriState.True; //cell width wrap text
            this.dtgcMessage.Width = this.dtgLogMessage.Width - this.dtgcCode.Width - this.dtgcNo.Width-this.dtgcWaktu.Width;
            this.btnStop.Enabled = false;
         


            //add items with its value into cmbxAlarm (combobox alarm)
            cmbxAlarm.Items.Add(new AlertSound("Alert1", "Alert1.mp3"));
            cmbxAlarm.Items.Add(new AlertSound("Alert2", "Alert2.mp3"));
            cmbxAlarm.Items.Add(new AlertSound("Alert3", "Alert3.mp3"));
        }


        private void InitializeSystemApps()
        {
            db.OpenConnection();
            audios = db.getAllAudioType();
            foreach (AudioType audio in audios)
            {
                ckLisBxSensor.Items.Add(audio.Type_name ,false);
            }

            logAudios = db.getAllLogAudioDetectionShortByDateForDataGrid();
            foreach (LogAudioDetection logAudio in logAudios)
            {
                Console.WriteLine(logAudio.LogId + " - " +                     
                    logAudio.FingerprintId.AudioType.Type_name +" - "+
                    logAudio.LogDetectionTime+" - "+
                    logAudio.LogMessage+" - "+
                    logAudio.LogSeenStatus);
            }
            //db.CloseConnection();

            logAudios = db.getAllLogAudioDetectionShortByDateForDataGrid();
            addDataGridItem(logAudios);

            this.alertPlayer.uiMode = "none";
        }

    

        private void btnTestAlem_Click(object sender, EventArgs e)
        {
            if(this.cmbxAlarm.SelectedItem != null)
            {
                Console.WriteLine("Clicked Alrt : " + (this.cmbxAlarm.SelectedItem as AlertSound).value);
                AlertSoundManager alertSoundManager = new AlertSoundManager();
                alertSoundManager.alertSound = (AlertSound)this.cmbxAlarm.SelectedItem;
                Thread t = new Thread(alertSoundManager.play);
                t.Start();
                //t.Join();
            }


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            PleaseWaitWorker pleaseWaitWorker = new PleaseWaitWorker();
            PleaseWaitForm pleaseWaitForm = new PleaseWaitForm();
            pleaseWaitWorker.pleaseWaitForm.ShowInTaskbar = false;
            pleaseWaitWorker.pleaseWaitForm.StartPosition = FormStartPosition.Manual; //manual artinya diatur oleh Location
            int XPoint = this.Location.X + this.Width / 2 - pleaseWaitWorker.pleaseWaitForm.Width / 2;
            int YPoint = this.Location.Y + this.Height / 2 - pleaseWaitWorker.pleaseWaitForm.Height / 2;
            pleaseWaitWorker.pleaseWaitForm.Location = new Point(XPoint, YPoint);

            Thread pleaseWaitThread = new Thread(pleaseWaitWorker.Show);
            pleaseWaitThread.Start();

            Console.WriteLine("Stop recording");
            WaitAllThreadStop();
            Console.WriteLine("Closing connection");
            db.CloseConnection();

            pleaseWaitForm.Dispose();
            pleaseWaitThread.Abort();

            //TODO : Clear all queue in RabbitMQ

            this.btnStart.Enabled = true;
            this.ckLisBxSensor.Enabled = true;
            this.btnStart.FlatStyle = FlatStyle.Standard;
            this.btnStart.BackColor = SystemColors.ButtonFace;
            this.btnStop.Enabled = false;
            

        }

        private void WaitAllThreadStop()
        {
            for (int i = 0; i < MAX_PROCESS; i++)
            {
                worker[i].RequestStop();
                workerThread[i].Abort();
            }
            
            Boolean alive = true;
            int nAlive = 0;
            while (alive)
            {
                nAlive = 0;
                for (int j = 0; j < MAX_PROCESS; j++)
                {
                    if (workerThread[j].IsAlive)
                    {
                        nAlive++;
                    }
                }
                Console.WriteLine("nAlive : " + nAlive);
                if (nAlive == 0) { alive = false;  }
            }
            


        }

        private void cmbxAlarm_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (ckLisBxSensor.CheckedItems.Count != 0)
            {
                this.btnStart.BackColor = Color.Yellow; //mengubah warna button start
                this.btnStart.FlatStyle = FlatStyle.Flat; //mengubah bentuk button start
                this.btnStart.Enabled = false; //disabling button start
                this.btnStop.Enabled = true; //enabling button stop
                this.ckLisBxSensor.Enabled = false; //disabling ckeckbox sensor

                workerThread = new Thread[MAX_PROCESS];
                worker = new Worker[MAX_PROCESS];
                for (int i = 0; i < MAX_PROCESS; i++)
                {


                    Console.WriteLine("Running thread " + (i + 1));

                    worker[i] = new Worker(i + 1);
                    worker[i].dtgLogMessage = this.dtgLogMessage;

                    worker[i].processDelegate = new Worker.ProcessDelegate(addDataGridItem);

                    workerThread[i] = new Thread(worker[i].DoWork);

                    /*
                    ListViewItem lstLogItem = new ListViewItem();
                    lstLogItem.SubItems.Add("This is a message");
                    addListItem(lstLogItem);
                    */

                    workerThread[i].Start();
                    Thread.Sleep(2000);
                }
            }
            else
            {
                MessageBox.Show(Messages.ERROR_ZERO_CHECKED, Messages.TYPE_ERROR); ;
            }
            
        }

        private void addDataGridItem(List<LogAudioDetection> contentMessage)
        {
            Console.WriteLine("Value Item : " + contentMessage);
            int idxLastRow = this.dtgLogMessage.RowCount;
            foreach(LogAudioDetection data in contentMessage)
            {
                string[] rowData = { (idxLastRow++).ToString(), data.LogId,data.LogDetectionTime, data.LogMessage };
                this.dtgLogMessage.Rows.Add(rowData);
                this.dtgLogMessage.Rows[idxLastRow-2].DefaultCellStyle.BackColor = Color.Gray;
            }

        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            this.dtgLogMessage.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteLog_Click(object sender, EventArgs e)
        {
            if(this.dtgLogMessage.RowCount > 1)
            {
                List<int> idxToDelete = new List<int>();
                int idxSelected;
                Boolean exist;
                foreach (DataGridViewCell toDeleteRow in this.dtgLogMessage.SelectedCells)
                {
                    idxSelected = toDeleteRow.RowIndex;
                    exist = false;
                    foreach(int i in idxToDelete)
                    {
                        if (i == idxSelected)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        idxToDelete.Add(idxSelected);
                    }
                    
                }

                foreach(int i in idxToDelete)
                {
                    this.dtgLogMessage.Rows.RemoveAt(i);
                }

                //reset row number
                resetLogTableRowNumber();
            }
        }

        private void resetLogTableRowNumber()
        {
            DataGridViewRowCollection dataGridViewRow = this.dtgLogMessage.Rows;

            foreach(DataGridViewRow dataRow in dataGridViewRow)
            {
                dataRow.Cells[0].Value = (dataRow.Index + 1);
            }
            
        }

        private void btnDeleteAllLog_Click(object sender, EventArgs e)
        {
            this.dtgLogMessage.Rows.Clear();
        }
    }

}
