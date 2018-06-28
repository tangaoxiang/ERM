using System;
namespace ERM.MDL
{
	/// <summary>
	/// 实体类ArchiveTemps 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class ArchiveTemps
	{
		public ArchiveTemps()
		{}
		private string _cell_templet_name;
		private string _cell_templet_table;
		private string _filerecording_templet_table;
		private int _isdefault;
		private int _orderindex;
		private string _recording_templet_name;
		private int? _tempid;
		private string _usertitle;
		private int _visible;
		/// <summary>
		/// 
		/// </summary>
		public string Cell_Templet_Name
		{
			set{ _cell_templet_name=value;}
			get{return _cell_templet_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cell_Templet_Table
		{
			set{ _cell_templet_table=value;}
			get{return _cell_templet_table;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fileRecording_Templet_Table
		{
			set{ _filerecording_templet_table=value;}
			get{return _filerecording_templet_table;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isDefault
		{
			set{ _isdefault=value;}
			get{return _isdefault;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int orderindex
		{
			set{ _orderindex=value;}
			get{return _orderindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Recording_Templet_Name
		{
			set{ _recording_templet_name=value;}
			get{return _recording_templet_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? tempid
		{
			set{ _tempid=value;}
			get{return _tempid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserTitle
		{
			set{ _usertitle=value;}
			get{return _usertitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int visible
		{
			set{ _visible=value;}
			get{return _visible;}
		}
	}
}
