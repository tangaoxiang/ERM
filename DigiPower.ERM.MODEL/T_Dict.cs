using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_Dict
    {
        public Int32 ID { set; get; }
        public String KeyWord { set; get; }
        public String DisplayName { set; get; }
        public String ValueName { set; get; }
        public Int32? OrderIndex { set; get; }
    }
}
