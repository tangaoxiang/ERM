using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����docFormat ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class docFormat
	{
		public docFormat()
		{}
		private string _code;
		private string _typename;
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typename
		{
			set{ _typename=value;}
			get{return _typename;}
		}
	}
}
