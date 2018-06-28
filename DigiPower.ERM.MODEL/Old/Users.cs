using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类Users 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Users
	{
		public Users()
		{}
		private string _fullname;
		private string _login;
		private string _password;
		private string _phone;
		private int _sh;
		private int _theme;
		private string _title;
		private string _units;
		private string _unitstype;
		private int? _userid;
		/// <summary>
		/// 
		/// </summary>
		public string fullname
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string login
		{
			set{ _login=value;}
			get{return _login;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int sh
		{
			set{ _sh=value;}
			get{return _sh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int theme
		{
			set{ _theme=value;}
			get{return _theme;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string units
		{
			set{ _units=value;}
			get{return _units;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unitstype
		{
			set{ _unitstype=value;}
			get{return _unitstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
	}
}
