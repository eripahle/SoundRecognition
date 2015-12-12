using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Accord.Audio;
using Accord.Audio.Formats;
using Accord.DirectSound;
using Accord.Audio.Filters;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApplication1.Entity;

namespace WindowsFormsApplication1.Util
{
    public class Worker
    {

      
        public DataGridView dtgLogMessage { get; set; }

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

        public delegate void ProcessDelegate(List<LogAudioDetection> valueItem);
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
                Thread.Sleep(3000);
                stopReq(p);
                
                //algoritma pattern matching
            
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.FileName = JAVA_LOCATION;
                processStartInfo.Arguments = "-jar " + RECOGNIZER_APP + " D:\\file" + p + ".wav";
           
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
          
                //send message to datagrid view in main form 
                List<LogAudioDetection> log = ParseMessage(messageSimilarity);
                if(log != null) dtgLogMessage.Invoke(processDelegate, log);
                logItem = null;

                //ringing an alert                
            }

        }

        private  List<LogAudioDetection> ParseMessage(string rawMessage)
        {
            if(rawMessage != "")
            {
                string[] messageSeparator = { "||" };

                String[] rawLogAudioMessage = rawMessage.Split(messageSeparator, StringSplitOptions.None);

                string message = "";
                List<LogAudioDetection> log = new List<LogAudioDetection>();
                for(int i=0; i<rawLogAudioMessage.Length-1;i++){
                    message = rawLogAudioMessage[i];
                    Console.WriteLine("In Worker :");
                    Console.WriteLine(message);
                    string[] resultItem = message.Split('#');
                    LogAudioDetection item = new LogAudioDetection();
                    item.FingerprintId.FingerPrintId=resultItem[0];
                    item.CreateMessageSoundDetected(new string[] { resultItem[1], resultItem[2] });

                    DateTime current = DateTime.Now;
                    item.LogDetectionTime = current.ToString();
                    item.LogSeenStatus = "false";
                    
                    String messageCode = ""+current.Year;
                    messageCode += GenerateStringNumber(current.Month);
                    messageCode += GenerateStringNumber(current.Day);
                    messageCode += GenerateStringNumber(current.Hour);
                    messageCode += GenerateStringNumber(current.Minute);
                    messageCode += GenerateStringNumber(current.Second);
                    item.LogId = messageCode;

                    log.Add(item);
                }

                return log;
            }
            else
            {
                return null;
            }
        }

        private string GenerateStringNumber(int num)
        {
            if (num < 10) return "0" + num;
            else return "" + num;
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
