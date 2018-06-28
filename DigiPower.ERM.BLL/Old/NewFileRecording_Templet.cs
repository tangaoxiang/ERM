using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���NewFileRecording_Templet ��ժҪ˵����
	/// </summary>
	public class NewFileRecording_Templet
	{
		private readonly ERM.DAL.NewFileRecording_Templet dal=new ERM.DAL.NewFileRecording_Templet();
		public NewFileRecording_Templet()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.NewFileRecording_Templet model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.NewFileRecording_Templet model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string id)
		{
			dal.Delete(id);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.NewFileRecording_Templet Find(string id)
		{
			return dal.Find(id);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.NewFileRecording_Templet GetModelByCache(string id)
		{
			string CacheKey = "NewFileRecording_TempletModel-" + id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.NewFileRecording_Templet)objModel;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<ERM.MDL.NewFileRecording_Templet> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.NewFileRecording_Templet> modelList = new List<ERM.MDL.NewFileRecording_Templet>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.NewFileRecording_Templet model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.NewFileRecording_Templet();
					model.id=ds.Tables[0].Rows[n]["id"].ToString();
					model.ptreepath=ds.Tables[0].Rows[n]["ptreepath"].ToString();
					model.table_name=ds.Tables[0].Rows[n]["table_name"].ToString();
					model.title=ds.Tables[0].Rows[n]["title"].ToString();
					model.treepath=ds.Tables[0].Rows[n]["treepath"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		/// <summary>
		/// ��������б�
		/// </summary>
	}
}
