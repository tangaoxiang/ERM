using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_FileListTemplate
    {
        public string FileID { set; get; }
        public string ParentID { set; get; }
        public string gdwj { set; get; }

        public int OrderIndex { get; set; }

        public int isvisible { get; set; }
        public string ParentID_OLD { get; set; }

        public string jsdw { get; set; }

        public string sgdw { get; set; }
        public string sjdw { get; set; }
        public string jldw { get; set; }

        public string cjdag { get; set; }

        public string datawindow_id { get; set; }

        public string table_name { get; set; }

        public string table_standerd { get; set; }

        public string extension1 { get; set; }

        public string extension2 { get; set; }
        public string extension3 { get; set; }
        public string selected { get; set; }
        public string wjmj { get; set; }
        public string gclx { get; set; }
        /// <summary>
        /// 归档类别
        /// </summary>
        public string GDID { set; get; }

        /// <summary>
        /// 工程类型
        /// </summary>
        public string ProjectCategory { set; get; }

    }
}
