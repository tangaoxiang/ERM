using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����Dict ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class Dict
	{
		public Dict()
		{}
		private string _displayname;
		private int? _id;
		private string _keyword;
		private int _orderindex;
		private string _valuename;
		/// <summary>
		/// 
		/// </summary>
		public string DisplayName
		{
			set{ _displayname=value;}
			get{return _displayname;}
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
		public string KeyWord
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderIndex
		{
			set{ _orderindex=value;}
			get{return _orderindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ValueName
		{
			set{ _valuename=value;}
			get{return _valuename;}
		}
	}
}
