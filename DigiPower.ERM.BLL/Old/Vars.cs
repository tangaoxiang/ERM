using System;
using System.Data;
using System.Collections.Generic;

namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���Vars ��ժҪ˵����
	/// </summary>
	public class Vars
	{
		private readonly ERM.DAL.Vars dal=new ERM.DAL.Vars();
		public Vars()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int varID)
		{
			return dal.Exists(varID);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.Vars model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.Vars model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int varID)
		{
			dal.Delete(varID);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.Vars Find(int varID)
		{
			return dal.Find(varID);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.Vars GetModelByCache(int varID)
		{
			string CacheKey = "VarsModel-" + varID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(varID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.Vars)objModel;
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
		public List<ERM.MDL.Vars> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.Vars> modelList = new List<ERM.MDL.Vars>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.Vars model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.Vars();
					if(ds.Tables[0].Rows[n]["varID"].ToString()!="")
					{
						model.varID=int.Parse(ds.Tables[0].Rows[n]["varID"].ToString());
					}
					model.varName=ds.Tables[0].Rows[n]["varName"].ToString();
					model.varTitle=ds.Tables[0].Rows[n]["varTitle"].ToString();
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
	}
}
