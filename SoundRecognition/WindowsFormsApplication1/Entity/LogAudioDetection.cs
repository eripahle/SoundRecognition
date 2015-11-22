using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entity
{
    class LogAudioDetection
    {
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


    }
}
