using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entity
{
    public class LogAudioDetection
    {
        private String msgSoundDetectedFormat= "Terdeteksi suara {0} dengan tingkat kesamaan {1:0.0} ";
        private String logId;

        public String LogId
        {
            get { return logId; }
            set { logId = value; }
        }
        private FingerPrint fingerprintId;

        public FingerPrint FingerprintId
        {
            get { return fingerprintId; }
            set { fingerprintId = value; }
        }
        
        private String logDetectionTime;

        public String LogDetectionTime
        {
            get { return logDetectionTime; }
            set { logDetectionTime = value; }
        }
        private String logSeenStatus;

        public String LogSeenStatus
        {
            get { return logSeenStatus; }
            set { logSeenStatus = value; }
        }
        private String logMessage;

        public String LogMessage
        {
            get { return logMessage; }
            set { logMessage = value; }
        }

        public LogAudioDetection()
        {
            fingerprintId = new FingerPrint();
        }

        public void CreateMessageSoundDetected (String[] parameters)
        {
            this.logMessage = string.Format(this.msgSoundDetectedFormat, parameters[0], parameters[1]);
        }


    }
}
