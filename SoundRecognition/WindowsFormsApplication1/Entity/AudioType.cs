using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entity
{
    class AudioType
    {
        private String type_id;
        private String type_name;

        public String Type_name
        {
            get { return type_name; }
            set { type_name = value; }
        }

        public String Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }
                              
    }
}
