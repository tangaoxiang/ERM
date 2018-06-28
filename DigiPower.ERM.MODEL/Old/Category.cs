using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类Category 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class Category
	{
		public Category()
		{}
		private int? _id;
		private int _parentid;
		private string _title;
		/// <summary>
		/// 
		/// </summary>
		public int? id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parentid
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
	}
}
