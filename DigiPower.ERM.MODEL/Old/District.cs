using System;
namespace ERM.MDL
{
    /// <summary>
    /// ʵ����District ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class District
    {
        public District()
        { }
        private string _districtname;
        private int? _districtid;
        private int _orderindex;
        private int _tempid;
        /// <summary>
        /// 
        /// </summary>
        public string DistrictName
        {
            set { _districtname = value; }
            get { return _districtname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DistrictID
        {
            set { _districtid = value; }
            get { return _districtid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderIndex
        {
            set { _orderindex = value; }
            get { return _orderindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TempID
        {
            set { _tempid = value; }
            get { return _tempid; }
        }
    }
}
