using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����docDraft ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class docDraft
	{
		public docDraft()
		{}
		private string _code;
		private string _draft;
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
		public string draft
		{
			set{ _draft=value;}
			get{return _draft;}
		}
	}
}
