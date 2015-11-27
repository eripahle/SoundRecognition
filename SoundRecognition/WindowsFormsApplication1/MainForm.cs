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
            
        }

        private void InitializeSystemApps()
        {
            db.OpenConnection();
            audios = db.getAllAudioType();
            foreach (AudioType audio in audios)
            {
                ckLisBxSensor.Items.Add(audio.Type_name ,false);
            }

            logAudios = db.getAllLogAudioDetectionShortByDateForListView();
            foreach (LogAudioDetection logAudio in logAudios)
            {
                Console.WriteLine(logAudio.LogId + " - " +                     
                    logAudio.FingerprintId.AudioType.Type_name +" - "+
                    logAudio.LogDetectionTime+" - "+
                    logAudio.LogMessage+" - "+
                    logAudio.LogSeenStatus);
            }
        }

    

        private void btnTestAlem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test Alert");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Stop recording");
            for (int i = 0; i < MAX_PROCESS; i++) worker[i].RequestStop();
            Console.WriteLine("Closing connection");
            db.CloseConnection();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void cmbxAlarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked Alrt");
        }

        private delegate void ProcessDelegate(ListViewItem listViewItem);

        private void btnstart_Click(object sender, EventArgs e)
        {
            
            workerThread = new Thread[MAX_PROCESS];
            worker = new Worker[MAX_PROCESS];
            for (int i = 0; i < MAX_PROCESS; i++)
            {

                //send notification to listview
                ListViewItem logItem = new ListViewItem();

                logItem.SubItems.Add("Hooray Message");
                //Console.WriteLine("log Item : " + logItem.ToString());

                this.lstLog.Items.Add(logItem);
                logItem = null;
                

                Console.WriteLine("Running thread " + (i + 1));

                worker[i] = new Worker(i + 1);
                worker[i].lstLog = this.lstLog;

                worker[i].processDelegate = new Worker.ProcessDelegate(addListItem);
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

        private void addListItem(String valueItem)
        {
            Console.WriteLine("Value Item : " + valueItem);
            //this.lstLog.Items.Add(lstItemLog);
            this.lstLog.Items.Add(valueItem,3);
        }

        private void lstLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}
