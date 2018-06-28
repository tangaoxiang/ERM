using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_CellFileTemplate
    {
        public String FileID { set; get; }
        public String CellID { set; get; }
        public String MyID { set; get; }
        public String parentid { set; get; }
        public String codeno { set; get; }
        public String title { set; get; }
        public String filepath { set; get; }
        public Int32? isvisible { set; get; }
        public Int32 orderindex { set; get; }
    }
}
