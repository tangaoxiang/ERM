/***************************************************************************
 * 
 *       功能：     交通单项工程明细附加实体
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
    /// T_Traffic_Detail 
    /// </summary>
    [Serializable]
    public partial class T_Traffic_Detail
    {
        private string _id;
        private string _trafficid;
        private string _types;
        private string _zcd;
        private string _gj;
        private string _cz;
        private string _zhxs;
        private string _jmcc;
        private string _jcxs;

        ///<sumary>
        /// 主键
        ///</sumary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string TrafficID
        {
            get { return _trafficid; }
            set { _trafficid = value; }
        }
        [DescriptionAttribute("交通类型 gsg:给水管|ysg:雨水管|wsg:污水管|ddsd:电力遂道|zh:综合管沟|dl:电缆沟|yl:预留沟")]
        public string Types
        {
            get { return _types; }
            set { _types = value; }
        }
        [DescriptionAttribute("总长度")]
        public string ZCD
        {
            get { return _zcd; }
            set { _zcd = value; }
        }

        [DescriptionAttribute("管径")]
        public string GJ
        {
            get { return _gj; }
            set { _gj = value; }
        }

        [DescriptionAttribute("材质")]
        public string CZ
        {
            get { return _cz; }
            set { _cz = value; }
        }

        [DescriptionAttribute("支护形式")]
        public string ZHXS
        {
            get { return _zhxs; }
            set { _zhxs = value; }
        }

        [DescriptionAttribute("截面尺寸")]
        public string JMCC
        {
            get { return _jmcc; }
            set { _jmcc = value; }
        }

        [DescriptionAttribute("基础形式")]
        public string JCXS
        {
            get { return _jcxs; }
            set { _jcxs = value; }
        }
    }
}
