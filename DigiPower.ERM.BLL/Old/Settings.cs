using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���Settings ��ժҪ˵����
	/// </summary>
	public class Settings
	{
		private readonly ERM.DAL.Settings dal=new ERM.DAL.Settings();
		public Settings()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.Settings model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.Settings model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			dal.Delete(ID);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.Settings Find(int ID)
		{
			return dal.Find(ID);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.Settings GetModelByCache(int ID)
		{
			string CacheKey = "SettingsModel-" + ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.Settings)objModel;
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
		public List<ERM.MDL.Settings> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.Settings> modelList = new List<ERM.MDL.Settings>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.Settings model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.Settings();
					model.AppTitle=ds.Tables[0].Rows[n]["AppTitle"].ToString();
					if(ds.Tables[0].Rows[n]["defaultTempID"].ToString()!="")
					{
						model.defaultTempID=int.Parse(ds.Tables[0].Rows[n]["defaultTempID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.port=ds.Tables[0].Rows[n]["port"].ToString();
					model.PromptTitle=ds.Tables[0].Rows[n]["PromptTitle"].ToString();
					model.ServerAddr=ds.Tables[0].Rows[n]["ServerAddr"].ToString();
					if(ds.Tables[0].Rows[n]["timeout"].ToString()!="")
					{
						model.timeout=int.Parse(ds.Tables[0].Rows[n]["timeout"].ToString());
					}
					model.UserTitle=ds.Tables[0].Rows[n]["UserTitle"].ToString();
					model.Ver=ds.Tables[0].Rows[n]["Ver"].ToString();
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
