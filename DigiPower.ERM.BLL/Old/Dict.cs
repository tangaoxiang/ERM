using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���Dict ��ժҪ˵����
	/// </summary>
	public class Dict
	{
		private readonly ERM.DAL.Dict dal=new ERM.DAL.Dict();
		public Dict()
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
		public void Add(ERM.MDL.Dict model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.Dict model)
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
		public ERM.MDL.Dict GetModel(int ID)
		{
			return dal.GetModel(ID);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.Dict GetModelByCache(int ID)
		{
			string CacheKey = "DictModel-" + ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.Dict)objModel;
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
		public List<ERM.MDL.Dict> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.Dict> modelList = new List<ERM.MDL.Dict>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.Dict model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.Dict();
					model.DisplayName=ds.Tables[0].Rows[n]["DisplayName"].ToString();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.KeyWord=ds.Tables[0].Rows[n]["KeyWord"].ToString();
					if(ds.Tables[0].Rows[n]["OrderIndex"].ToString()!="")
					{
						model.OrderIndex=int.Parse(ds.Tables[0].Rows[n]["OrderIndex"].ToString());
					}
					model.ValueName=ds.Tables[0].Rows[n]["ValueName"].ToString();
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
