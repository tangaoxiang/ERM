using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_Settings
    {
        public String ID { set; get; }
        public String AppTitle { set; get; }
        public String PromptTitle { set; get; }
        public String UserTitle { set; get; }
        public String UserTitle2 { set; get; }
        public String Ver { set; get; }
        public Int32? defaultTempID { set; get; }
        public String ServerAddr { set; get; }
        public String port { set; get; }
        public Int32? timeout { set; get; }
    }
}
