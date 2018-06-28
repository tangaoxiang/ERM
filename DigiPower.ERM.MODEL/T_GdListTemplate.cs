using System;
using System.Collections.Generic;
using System.Text;

namespace ERM.MDL
{
    [Serializable]
    public partial class T_GdListTemplate
    {
        public string ID { set; get; }
        public string GdName { set; get; }
        public Int32? OrderIndex { set; get; }
        public Int32 IsShow { set; get; }

        /// <summary>
        /// 工程类型
        /// </summary>
        public string ProjectCategory { get; set; }
    }
}
