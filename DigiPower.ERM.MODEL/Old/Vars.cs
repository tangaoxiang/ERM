using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类Vars 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Vars
	{
		public Vars()
		{}
		private int _varid;
		private string _varname;
		private string _vartitle;
		/// <summary>
		/// 
		/// </summary>
		public int varID
		{
			set{ _varid=value;}
			get{return _varid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string varName
		{
			set{ _varname=value;}
			get{return _varname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string varTitle
		{
			set{ _vartitle=value;}
			get{return _vartitle;}
		}
	}
}
