using System;
namespace ERM.MDL
{
	/// <summary>
	/// ʵ����gclbbm ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class gclbbm
	{
		public gclbbm()
		{}
		private string _flmc;
		private string _flms;
		private string _gclbbm;
		/// <summary>
		/// 
		/// </summary>
		public string flmc
		{
			set{ _flmc=value;}
			get{return _flmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string flms
		{
			set{ _flms=value;}
			get{return _flms;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Gclbbm
		{
			set{ _gclbbm=value;}
			get{return _gclbbm;}
		}
	}
}
