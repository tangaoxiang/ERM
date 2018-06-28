using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类docFormat 。(属性说明自动提取数据库字段的描述信息)
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
