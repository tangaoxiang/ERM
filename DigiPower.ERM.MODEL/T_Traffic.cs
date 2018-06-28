/***************************************************************************
 * 
 *       功能：     市政交通实体类
 *       作者：     tangyaoxiang
 *       日期：     2017-4-11
 * 
 *       修改日期： 
 *       修改人：
 *       修改内容：
 * 
 * *************************************************************************/
namespace ERM.MDL
{
    using System;
    using System.ComponentModel;

    [Serializable]
    public partial class T_Traffic
    {
        private string _id;
        private string _road_level;
        private string _longcount;
        private string _width;
        private string _hz;
        private string _jcxs;
        private string _mcxs;
        private string _kj;
        private string _ks;
        private string _zpws;
        private string _pwdj;
        private string _projectid;
        private string _remark;
        private string _gcys;
        private string _gcjs;
        private string _startx;
        private string _starty;
        private string _endx;
        private string _endy;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [Description("坐标点X")]
        public string STARTX
        {
            get { return _startx; }
            set { _startx = value; }
        }

        [Description("坐标点Y")]
        public string STARTY
        {
            get { return _starty; }
            set { _starty = value; }
        }
        [Description("坐标点X")]
        public string ENDX
        {
            get { return _endx; }
            set { _endx = value; }
        }

        [Description("坐标点Y")]
        public string ENDY
        {
            get { return _endy; }
            set { _endy = value; }
        }

        [Description("工程预算")]
        public string GCYS
        {
            get { return _gcys; }
            set { _gcys = value; }
        }

        [Description("工程结算")]
        public string GCJS
        {
            get { return _gcjs; }
            set { _gcjs = value; }
        }

        [Description("道路级别")]
        public string Road_Level
        {
            get { return _road_level; }
            set { _road_level = value; }
        }

        [DescriptionAttribute("总长度")]
        public string LongCount
        {
            get { return _longcount; }
            set { _longcount = value; }
        }

        [DescriptionAttribute("宽度")]
        public string Width
        {
            get { return _width; }
            set { _width = value; }
        }

        [DescriptionAttribute("荷载")]
        public string HZ
        {
            get { return _hz; }
            set { _hz = value; }
        }

        [DescriptionAttribute("基础形式")]
        public string JCXS
        {
            get { return _jcxs; }
            set { _jcxs = value; }
        }

        [DescriptionAttribute("面层形式")]
        public string MCXS
        {
            get { return _mcxs; }
            set { _mcxs = value; }
        }

        [DescriptionAttribute("跨径")]
        public string KJ
        {
            get { return _kj; }
            set { _kj = value; }
        }

        [DescriptionAttribute("孔数")]
        public string KS
        {
            get { return _ks; }
            set { _ks = value; }
        }

        [DescriptionAttribute("总泊位数")]
        public string ZPWS
        {
            get { return _zpws; }
            set { _zpws = value; }
        }

        [DescriptionAttribute("泊位吨级")]
        public string PWDJ
        {
            get { return _pwdj; }
            set { _pwdj = value; }
        }

        [DescriptionAttribute("项目编号")]
        public string ProjectID
        {
            get { return _projectid; }
            set { _projectid = value; }
        }

        [DescriptionAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string HJQK { get; set; }
        public int CD { get; set; }
        public string GG { get; set; }

        public string ZL { get; set; }

        public string SGYL { get; set; }

        public string CZ { get; set; }
    }
}
