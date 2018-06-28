/***************************************************************************
 * 
 *       功能：     道路工程实体类
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

    /// <summary>
    /// T_Project_RoadLamp 
    /// </summary>
    [Serializable]
    public class T_Project_RoadLamp
    {
        private string _id;
        private string _projectid;
        private string _dlgg;
        private string _dlcd;
        private string _xbxh;
        private string _ldxs_st;
        private string _ldxs_mt;
        private string _dgzs;
        private string _dggd;
        private string _ggds;
        private string _ggdgd;
        private string _gylx;
        private string _gl;
        private string _djzl;
        private string _dgjjl;
        private string _djbc;
        private string _jxj;
        private string _remark;
        private int _gcys;


        /// 主键
        ///</sumary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ProjectID
        {
            get { return _projectid; }
            set { _projectid = value; }
        }
        [Description("工程预算")]
        public int GCYS
        {
            get { return _gcys; }
            set { _gcys = value; }
        }
        [DescriptionAttribute("电缆规格")]
        public string DLGG
        {
            get { return _dlgg; }
            set { _dlgg = value; }
        }

        [DescriptionAttribute("电缆长度")]
        public string DLCD
        {
            get { return _dlcd; }
            set { _dlcd = value; }
        }

        [DescriptionAttribute("箱变型号")]
        public string XBXH
        {
            get { return _xbxh; }
            set { _xbxh = value; }
        }

        [DescriptionAttribute("路灯形式—单头")]
        public string LDXS_ST
        {
            get { return _ldxs_st; }
            set { _ldxs_st = value; }
        }

        [DescriptionAttribute("路灯形式-双头")]
        public string LDXS_MT
        {
            get { return _ldxs_mt; }
            set { _ldxs_mt = value; }
        }

        [DescriptionAttribute("灯杆总数")]
        public string DGZS
        {
            get { return _dgzs; }
            set { _dgzs = value; }
        }

        [DescriptionAttribute("灯杆高度")]
        public string DGGD
        {
            get { return _dggd; }
            set { _dggd = value; }
        }

        [DescriptionAttribute("高杆灯数")]
        public string GGDS
        {
            get { return _ggds; }
            set { _ggds = value; }
        }

        [DescriptionAttribute("高杆灯高度")]
        public string GGDGD
        {
            get { return _ggdgd; }
            set { _ggdgd = value; }
        }

        [DescriptionAttribute("光源类型")]
        public string GYLX
        {
            get { return _gylx; }
            set { _gylx = value; }
        }

        [DescriptionAttribute("功率")]
        public string GL
        {
            get { return _gl; }
            set { _gl = value; }
        }

        [DescriptionAttribute("灯具类型")]
        public string DJZL
        {
            get { return _djzl; }
            set { _djzl = value; }
        }

        [DescriptionAttribute("灯杆间距")]
        public string DGJJL
        {
            get { return _dgjjl; }
            set { _dgjjl = value; }
        }

        [DescriptionAttribute("灯具臂长")]
        public string DJBC
        {
            get { return _djbc; }
            set { _djbc = value; }
        }

        [DescriptionAttribute("接线井")]
        public string JXJ
        {
            get { return _jxj; }
            set { _jxj = value; }
        }

        [DescriptionAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public int DLMJ { get; set; }

        public string DLDJ { get; set; }

        public int LK { get; set; }

        public string ZL { get; set; }

        public string ZD { get; set; }

        public int GCJS { get; set; }

        public int ZCD { get; set; }

        public int DLZCD { get; set; }

        public string HJQK { get; set; }

        public string GCQD { get; set; }

        public string GCZD { get; set; }
    }
}
