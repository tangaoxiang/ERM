using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_CellAndEFile
    {
        public String CellID { set; get; }
        public String FileID { set; get; }
        public String id { set; get; }
        public String ProjectNO { set; get; }
        public String TreePath { set; get; }
        public String parentid { set; get; }
        public String PTreePath { set; get; }
        public String title { set; get; }
        public String filepath { set; get; }
        public String examplepath { set; get; }
        public String codeno { set; get; }
        public Int32 customdefine { set; get; }
        public String zrr { set; get; }
        public Int32 codetype { set; get; }
        public String fbmc { set; get; }
        public String fxmc { set; get; }
        public String zfbmc { set; get; }
        public Int32 ys { set; get; }
        public Int32 isvisible { set; get; }
        public Int32 orderindex { set; get; }
        public Int32 DoStatus { set; get; }
        public Int32 attachid { set; get; }
        public String fileTreePath { set; get; }
        public String zrzbsm { set; get; }
        public String zrzlb { set; get; }
        public String zrzmc { set; get; }
        public String zezzzfw { set; get; }
        public String ext { set; get; }
        public String wjly { set; get; }
        public Int32? DocYs { set; get; }
        public String yswjpath { set; get; }
        public String docType { set; get; }
        public String docFormat { set; get; }
        public String Draft { set; get; }
        public String OriOpenPro { set; get; }
        public Boolean EFileType { set; get; }
        public String FileType { set; get; }
        public String GdFileID { set; get; }
        public Int32 GdOrderIndex { set; get; }
    }
}
