using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类NewFileRecording_Templet 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class NewFileRecording_Templet
	{
		public NewFileRecording_Templet()
		{}
		private string _id;
		private string _ptreepath;
		private string _table_name;
		private string _title;
		private string _treepath;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ptreepath
		{
			set{ _ptreepath=value;}
			get{return _ptreepath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string table_name
		{
			set{ _table_name=value;}
			get{return _table_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string treepath
		{
			set{ _treepath=value;}
			get{return _treepath;}
		}
	}
}
