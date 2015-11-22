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
    public partial class Form1 : Form
    {

        DBEngine db = new DBEngine();
        List<AudioType> audios;
        List<LogAudioDetection> logAudios;

        public Form1()
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
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void cmbxAlarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked Alrt");
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            const int MAX_PROCESS = 6;                        
            Thread[] workerThread = new Thread[MAX_PROCESS];
            for (int i = 0; i < MAX_PROCESS; i++)
            {
                Console.WriteLine("Running thread " + (i + 1));
                workerThread[i] = new Thread(new Worker(i + 1).DoWork);
                workerThread[i].Start();
                Thread.Sleep(2000);
            }            
        }

       
    }

}
