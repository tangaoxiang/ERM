using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����PageSize ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class PageSize
	{
		public PageSize()
		{}
		private int _isdefault;
		private int _pages;
		private int _pfloat;
		private int? _pid;
		private string _ptype;
		/// <summary>
		/// 
		/// </summary>
		public int IsDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Pages
		{
			set{ _pages=value;}
			get{return _pages;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Pfloat
		{
			set{ _pfloat=value;}
			get{return _pfloat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PTYPE
		{
			set{ _ptype=value;}
			get{return _ptype;}
		}
	}
}
