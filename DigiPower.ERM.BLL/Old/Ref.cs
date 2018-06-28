using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���Ref ��ժҪ˵����
	/// </summary>
	public class Ref
	{
		private readonly ERM.DAL.Ref dal=new ERM.DAL.Ref();
		public Ref()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RefID)
		{
			return dal.Exists(RefID);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.Ref model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.Ref model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int RefID)
		{
			dal.Delete(RefID);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.Ref Find(int RefID)
		{
			return dal.Find(RefID);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.Ref GetModelByCache(int RefID)
		{
			string CacheKey = "RefModel-" + RefID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(RefID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.Ref)objModel;
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
		public List<ERM.MDL.Ref> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.Ref> modelList = new List<ERM.MDL.Ref>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.Ref model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.Ref();
					model.keyWord=ds.Tables[0].Rows[n]["keyWord"].ToString();
					if(ds.Tables[0].Rows[n]["orderindex"].ToString()!="")
					{
						model.orderindex=int.Parse(ds.Tables[0].Rows[n]["orderindex"].ToString());
					}
					if(ds.Tables[0].Rows[n]["RefID"].ToString()!="")
					{
						model.RefID=int.Parse(ds.Tables[0].Rows[n]["RefID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["tempid"].ToString()!="")
					{
						model.tempid=int.Parse(ds.Tables[0].Rows[n]["tempid"].ToString());
					}
					model.title=ds.Tables[0].Rows[n]["title"].ToString();
					if(ds.Tables[0].Rows[n]["visible"].ToString()!="")
					{
						model.visible=int.Parse(ds.Tables[0].Rows[n]["visible"].ToString());
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
