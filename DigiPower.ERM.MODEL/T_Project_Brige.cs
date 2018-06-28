/***************************************************************************
 * 
 *       功能：     市政桥梁工程实体类
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
    /// T_Project_Brige 
    /// </summary>
    [Serializable]
    public class T_Project_Brige
    {
        private string _id;
        private string _projectid;
        private string _sturucttype;
        private string _level;
        private string _longs;
        private string _width;
        private string _kj;
        private string _jk;
        private string _jcxs;
        private string _sbgz;
        private string _xbgz;
        private string _mcxs;
        private string _acjgxs;
        private string _dz;
        private string _ssf;
        private string _remark;
        private string _hz;
        private string _gcys;
        private string _gcjs;
        private string _zcd;
        private string _lb;
        private string _kz;
        private string _gczl;
        private string _hjqk;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
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
        [DescriptionAttribute("荷载")]
        public string HZ
        {
            get { return _hz; }
            set { _hz = value; }
        }

        [DescriptionAttribute("项目编号")]
        public string ProjectID
        {
            get { return _projectid; }
            set { _projectid = value; }
        }
        [DescriptionAttribute("构造类型")]
        public string StuructType
        {
            get { return _sturucttype; }
            set { _sturucttype = value; }
        }
        [DescriptionAttribute("等级")]
        public string Level
        {
            get { return _level; }
            set { _level = value; }
        }
        [DescriptionAttribute("长度")]
        public string Longs
        {
            get { return _longs; }
            set { _longs = value; }
        }
        [DescriptionAttribute("宽度")]
        public string Width
        {
            get { return _width; }
            set { _width = value; }
        }
        [DescriptionAttribute("跨径")]
        public string KJ
        {
            get { return _kj; }
            set { _kj = value; }
        }
        [DescriptionAttribute("净空")]
        public string JK
        {
            get { return _jk; }
            set { _jk = value; }
        }
        [DescriptionAttribute("基础形式")]
        public string JCXS
        {
            get { return _jcxs; }
            set { _jcxs = value; }
        }
        [DescriptionAttribute("上部构造")]
        public string SBGZ
        {
            get { return _sbgz; }
            set { _sbgz = value; }
        }
        [DescriptionAttribute("下部构造")]
        public string XBGZ
        {
            get { return _xbgz; }
            set { _xbgz = value; }
        }
        [DescriptionAttribute("面层形式")]
        public string MCXS
        {
            get { return _mcxs; }
            set { _mcxs = value; }
        }
        [DescriptionAttribute("人行道、安全带结构形式")]
        public string ACJGXS
        {
            get { return _acjgxs; }
            set { _acjgxs = value; }
        }
        [DescriptionAttribute("灯柱")]
        public string DZ
        {
            get { return _dz; }
            set { _dz = value; }
        }
        [DescriptionAttribute("伸缩缝")]
        public string SSF
        {
            get { return _ssf; }
            set { _ssf = value; }
        }
        [DescriptionAttribute("备注")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        [DescriptionAttribute("桥梁类别")]
        public string LB
        {
            get { return _lb; }
            set { _lb = value; }
        }

        [DescriptionAttribute("抗震等级")]
        public string KZ
        {
            get { return _kz; }
            set { _kz = value; }
        }

        [DescriptionAttribute("总长度")]
        public string ZCD
        {
            get { return _zcd; }
            set { _zcd = value; }
        }

        [DescriptionAttribute("获奖情况")]
        public string HJQK
        {
            get { return _hjqk; }
            set { _hjqk = value; }
        }

        [DescriptionAttribute("工程质量")]
        public string GCZL
        {
            get { return _gczl; }
            set { _gczl = value; }
        }
    }
}
