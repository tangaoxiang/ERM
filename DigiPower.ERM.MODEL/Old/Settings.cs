using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类Settings 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Settings
	{
		public Settings()
		{}
		private string _apptitle;
		private int _defaulttempid;
		private int? _id;
		private string _port;
		private string _prompttitle;
		private string _serveraddr;
		private int _timeout;
		private string _usertitle;
		private string _ver;
        private string _usertitle2;
		/// <summary>
		/// 
		/// </summary>
		public string AppTitle
		{
			set{ _apptitle=value;}
			get{return _apptitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int defaultTempID
		{
			set{ _defaulttempid=value;}
			get{return _defaulttempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string port
		{
			set{ _port=value;}
			get{return _port;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PromptTitle
		{
			set{ _prompttitle=value;}
			get{return _prompttitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ServerAddr
		{
			set{ _serveraddr=value;}
			get{return _serveraddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int timeout
		{
			set{ _timeout=value;}
			get{return _timeout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserTitle
		{
			set{ _usertitle=value;}
			get{return _usertitle;}
		}
        public string UserTitle2
        {
            set { _usertitle2 = value; }
            get { return _usertitle2; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Ver
		{
			set{ _ver=value;}
			get{return _ver;}
		}
	}
}
