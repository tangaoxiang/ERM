using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����wjssgclx ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class wjssgclx
	{
		public wjssgclx()
		{}
		private string _id;
		private int? _id2;
		private string _projectcode;
		private string _projectname;
		private string _ptreepath;
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
		public int? id2
		{
			set{ _id2=value;}
			get{return _id2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectCode
		{
			set{ _projectcode=value;}
			get{return _projectcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectName
		{
			set{ _projectname=value;}
			get{return _projectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PTreePath
		{
			set{ _ptreepath=value;}
			get{return _ptreepath;}
		}
	}
}
