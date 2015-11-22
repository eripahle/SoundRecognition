using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entity
{
    class FingerPrint
    {
        private String fingerPrintId;

        public String FingerPrintId
        {
            get { return fingerPrintId; }
            set { fingerPrintId = value; }
        }

        private AudioType audioType;
        internal AudioType AudioType
        {
            get { return audioType; }
            set { audioType = value; }
        }

        private String fingerPrintName;

        public String FingerPrintName
        {
            get { return fingerPrintName; }
            set { fingerPrintName = value; }
        }

        private Byte[] fingerPrintData;

        public Byte[] FingerPrintData
        {
            get { return fingerPrintData; }
            set { fingerPrintData = value; }
        }
        
    }
}
