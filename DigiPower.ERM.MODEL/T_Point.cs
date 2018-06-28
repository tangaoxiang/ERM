using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERM.MDL
{
    [Serializable]
    public class T_Point
    {
        public string ID { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public int OrderIndex { get; set; }

        public string ProjectNo { get; set; }
    }
}
