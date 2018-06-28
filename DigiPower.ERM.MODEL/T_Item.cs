using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_Item
    {
        public String AllCost { set; get; }
        public String Approvedate { set; get; }
        public String BuildingDensity { set; get; }
        public String CollectionType { set; get; }
        public String ConstructionAreaSum { set; get; }
        public String ConstructionProjectAdd { set; get; }
        public String ConStructionProjectName { set; get; }
        public String ConstructionScale { set; get; }
        public String CreateUnit { set; get; }
        public String FinishDate { set; get; }
        public String GreenFar { set; get; }
        public String ItemFzr { set; get; }
        public String ItemID { set; get; }
        public String OriginalSoiType { set; get; }
        public String ProjectCost { set; get; }
        public String ProjectSettlement { set; get; }
        public String ProjectType { set; get; }
        public String Respective { set; get; }
        public String StartDate { set; get; }
        public String UseSoiArea { set; get; }
        public String UseSoiAreaSum { set; get; }
        public String UseSoiType { set; get; }
        public String VolumeFar { set; get; }
        public String ds { set; get; }
        [Description("批准单位")]
        public String pzdw { set; get; }
        [Description("批准号")]
        public String pzh { set; get; }
        [Description("总长度")]
        public string zcd { get; set; }

        public string Tlcrnx { get; set; }

        public string YdghxkCode { get; set; }

        public string TlsyCode { get; set; }

        public string XmCode { get; set; }
    }
}
