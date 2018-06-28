using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;

namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���District ��ժҪ˵����
	/// </summary>
	public class District
	{
		private readonly ERM.DAL.District dal=new ERM.DAL.District();
		public District()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int DistrictID)
		{
			return dal.Exists(DistrictID);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.District model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.District model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int DistrictID)
		{
			dal.Delete(DistrictID);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.District Find(int DistrictID)
		{
			return dal.Find(DistrictID);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.District GetModelByCache(int DistrictID)
		{
			string CacheKey = "DistrictModel-" + DistrictID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(DistrictID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.District)objModel;
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
		public List<ERM.MDL.District> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.District> modelList = new List<ERM.MDL.District>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.District model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.District();
                    model.DistrictName = ds.Tables[0].Rows[n]["DistrictName"].ToString();
					if(ds.Tables[0].Rows[n]["DistrictID"].ToString()!="")
					{
						model.DistrictID=int.Parse(ds.Tables[0].Rows[n]["DistrictID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["OrderIndex"].ToString()!="")
					{
						model.OrderIndex=int.Parse(ds.Tables[0].Rows[n]["OrderIndex"].ToString());
					}
					if(ds.Tables[0].Rows[n]["TempID"].ToString()!="")
					{
						model.TempID=int.Parse(ds.Tables[0].Rows[n]["TempID"].ToString());
					}
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
