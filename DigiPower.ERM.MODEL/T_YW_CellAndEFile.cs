using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_YW_CellAndEFile
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String ID { set; get; }

        /// <summary>
        /// 文件ID
        /// </summary>
        public String FileID { set; get; } 
     
        /// <summary>
        /// 工程编号
        /// </summary>
        public String ProjectNO { set; get; }

        /// <summary>
        /// 创建人
        /// </summary>
        public String CreateUser { set; get; }

         /// <summary>
         /// 创建时间
         /// </summary>
        public String CreateDate { set; get; }

        /// <summary>
        /// 文件格式
        /// </summary>
        public String FileFormat { set; get; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public String FileName { set; get; }

        /// <summary>
        /// 文件大小KB
        /// </summary>
        public Int32? FileSize { set; get; } 

        /// <summary>
        /// 操作方式
        /// </summary>
        public String OperationType { set; get; }
       
        /// <summary>
        /// 原文对应的电子文件信息
        /// </summary>
        public String CellID { set; get; }       
        
    }
}
