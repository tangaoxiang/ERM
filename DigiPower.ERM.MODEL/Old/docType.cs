using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����docType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class docType
	{
		public docType()
		{}
		private string _code;
		private string _doctype;
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
		public string DocType
		{
			set{ _doctype=value;}
			get{return _doctype;}
		}
	}
}
