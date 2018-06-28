using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类docDraft 。(属性说明自动提取数据库字段的描述信息)
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
