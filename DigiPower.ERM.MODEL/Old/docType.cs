using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类docType 。(属性说明自动提取数据库字段的描述信息)
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
