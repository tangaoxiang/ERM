using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_Projects
    {
        public String ItemID { set; get; }
        public String ProjectNO { set; get; }
        public String district { set; get; }
        public String projectname { set; get; }
        public String address { set; get; }
        public String category { set; get; }
        public String stru { set; get; }
        public String projecttype { set; get; }
        public String high { set; get; }
        public String floors1 { set; get; }
        public String floors2 { set; get; }
        public String area1 { set; get; }
        public String area2 { set; get; }
        public String ydpzcode { set; get; }
        public String ydxkcode { set; get; }
        public String ghcode { set; get; }
        public String sgcode { set; get; }
        public Double? price1 { set; get; }
        public Double? price2 { set; get; }
        public String begindate { set; get; }
        public String bjdate { set; get; }
        public String passwd { set; get; }
        public String enddate { set; get; }
        public Int32? tempid { set; get; }
        public String hjqk { set; get; }
        public String zzmj { set; get; }
        public String bgyfmj { set; get; }
        public String syyfmj { set; get; }
        public String cfmj { set; get; }
        public String dxsmj { set; get; }
        public String qtyfmj { set; get; }
        public String ts1 { set; get; }
        public String ts2 { set; get; }
        public String ts3 { set; get; }
        public String ts4 { set; get; }
        public String tstotal { set; get; }
        public String zygz { set; get; }
        public String zjy { set; get; }
        public String sgbzz { set; get; }
        public String tbr { set; get; }
        public String jsdwshr { set; get; }
        public String jldwshr { set; get; }
        public String createdate { set; get; }
        /// <summary>
        /// 案卷挡号
        /// </summary>
        public String ajdh { set; get; }
        public String ts5 { set; get; }
        public String kzsfcd { set; get; }
        public String ztcw { set; get; }
        public String dstcw { set; get; }
        public String dxtcw { set; get; }
        public String jsdwyjr { set; get; }
        public String sfz { set; get; }
        public String tel { set; get; }
        public String yjdw { set; get; }
        public String zlr { set; get; }
        public String zlrq { set; get; }

        [DescriptionAttribute("工程类别 traffic:市政交通|brige:桥梁|roadLamp:路灯|buildding:建筑")]
        public string ProjectCategory { get; set; }

        [DescriptionAttribute("起点坐标X")]
        public string Start_X { get; set; }

        [DescriptionAttribute("起点坐标Y")]
        public string Start_Y { get; set; }

        [DescriptionAttribute("终点坐标X")]
        public string End_X { get; set; }
        [DescriptionAttribute("终点坐标Y")]
        public string End_Y { get; set; }

        public string shr { get; set; }
        public string shrq { get; set; }

        public string XMJL { get; set; }
        public string XCJL { get; set; }
    }
}
