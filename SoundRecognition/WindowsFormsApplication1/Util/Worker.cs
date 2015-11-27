using System;
using System.Drawing;
using System.IO;
using Accord.Audio;
using Accord.Audio.Formats;
using Accord.DirectSound;
using Accord.Audio.Filters;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Util
{
    public class Worker
    {

        public MainForm mainForm { get; set; }
        public ListView lstLog { get; set; }

        private MemoryStream stream;

        private IAudioSource source;
        private IAudioOutput output;

        private WaveEncoder encoder;
        private WaveDecoder decoder;

        private float[] current;

        private int frames;
        private int samples;
        private int duration;

        private Boolean status = false;

        private volatile bool _shouldStop;
        public int p{get; set;}


        private const string RECOGNIZER_APP = "\"D:\\fingerprint_recognizer_incrabbit.jar\"";
        private const string jarLoc = "\"c:\\Program Files\\Java\\jre8\\bin\\java.exe\"";
        private const string JAVA_LOCATION = "\"C:\\Program Files\\Java\\jdk1.8.0_20\\bin\\java.exe\"";

        public delegate void ProcessDelegate(String valueItem);
        public ProcessDelegate processDelegate { get; set; }


        public Worker(int p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public Boolean getStatus()
        {
            return status;
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }


        // This method will be called when the thread is started. 
        public void DoWork()
        {
            RabbitMQ rabbitMQ = new RabbitMQ();
            String messageSimilarity;
            
            while (!_shouldStop) { 
                startReq();                
                Thread.Sleep(6000);
                stopReq(p);
                
                //algoritma pattern matching
                //status = return value pemanggilan aplikasi pattern matching;                 
                //string strCmdText;
                //strCmdText = jarLoc + RECOGNIZER_APP+" D:\\file"+p+".wav";
                //Console.WriteLine("strCmdText : " + strCmdText);

                ///System.Diagnostics.Process process = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = false;
                processStartInfo.FileName = JAVA_LOCATION;
                processStartInfo.Arguments = "-jar " + RECOGNIZER_APP + " D:\\file" + p + ".wav";
                //processStartInfo.Arguments = "-version";
                //process.FileName = "java";
                //process.Arguments = "-version";

                Console.WriteLine("java locaton : "+JAVA_LOCATION);
                Process startProcess =  System.Diagnostics.Process.Start(processStartInfo);
                startProcess.WaitForExit();

                Console.Write("Waiting for message from queue : "); //lanjutan pesan ini ada di dalam method rabbitMQ.receive
                messageSimilarity = rabbitMQ.receive("file"+p+ ".wav");

                //Console.WriteLine("For queue : "+p+".wav");
                Console.WriteLine("Message Similarity : " + messageSimilarity);
                //MessageBox.Show(messageSimilarity);
                Console.WriteLine("req " + p + " archived");

                //send notification to listview
                ListViewItem logItem = new ListViewItem();

                logItem.SubItems.Add("Hooray Message");
                //Console.WriteLine("log Item : " + logItem.ToString());
                //Console.WriteLine("lstLog : " + lstLog.ToString());
                //lstLog.Items.Add(logItem);
                lstLog.Invoke(processDelegate, messageSimilarity);
                logItem = null;
                //ringing an alert
            }

        }
        public void RequestStop(int counter)
        {
            stopReq(counter);
        }
        // Volatile is used as hint to the compiler that this data 
        // member will be accessed by multiple threads. 



        private void stopReq(int counter)
        {
            if (source != null)
            {
                // If we were recording
                source.SignalToStop();
                source.WaitForStop();
            }
            if (output != null)
            {
                // If we were playing
                output.SignalToStop();
                output.WaitForStop();
            }
            // Also zero out the buffers and screen
            Array.Clear(current, 0, current.Length);

            stream.Position = 0;
            FileStream file = new FileStream("D:\\file" + counter + ".wav", FileMode.Create, FileAccess.Write);
            stream.WriteTo(file);
        }

        private void startReq()
        {
            // Create capture device
            source = new AudioCaptureDevice()
            {
                // Listen on 22050 Hz
                DesiredFrameSize = 4096,
                SampleRate = 22050,

                // We will be reading 16-bit PCM
                Format = SampleFormat.Format16Bit
            };

            // Wire up some events
            source.NewFrame += source_NewFrame;
            source.AudioSourceError += source_AudioSourceError;

            // Create buffer for wavechart control
            current = new float[source.DesiredFrameSize];

            // Create stream to store file
            stream = new MemoryStream();
            encoder = new WaveEncoder(stream);

            // Start
            source.Start();

        }
        private void source_AudioSourceError(object sender, AudioSourceErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }

        private void source_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Save current frame
            eventArgs.Signal.CopyTo(current);

            // Update waveform
            //updateWaveform(current, eventArgs.Signal.Length);

            // Save to memory
            encoder.Encode(eventArgs.Signal);

            // Update counters
            duration += eventArgs.Signal.Duration;
            samples += eventArgs.Signal.Samples;
            frames += eventArgs.Signal.Length;
        }

    }
}
