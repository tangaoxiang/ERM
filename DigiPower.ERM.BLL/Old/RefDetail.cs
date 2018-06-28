using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���RefDetail ��ժҪ˵����
	/// </summary>
	public class RefDetail
	{
		private readonly ERM.DAL.RefDetail dal=new ERM.DAL.RefDetail();
		public RefDetail()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string keyWord,int nodeid)
		{
			return dal.Exists(keyWord,nodeid);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.RefDetail model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.RefDetail model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string keyWord,int nodeid)
		{
			dal.Delete(keyWord,nodeid);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.RefDetail Find(string keyWord,int nodeid)
		{
			return dal.Find(keyWord,nodeid);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.RefDetail GetModelByCache(string keyWord,int nodeid)
		{
			string CacheKey = "RefDetailModel-" + keyWord+nodeid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(keyWord,nodeid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.RefDetail)objModel;
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
		public List<ERM.MDL.RefDetail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.RefDetail> modelList = new List<ERM.MDL.RefDetail>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.RefDetail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.RefDetail();
					model.content=ds.Tables[0].Rows[n]["content"].ToString();
					if(ds.Tables[0].Rows[n]["imageindex"].ToString()!="")
					{
						model.imageindex=int.Parse(ds.Tables[0].Rows[n]["imageindex"].ToString());
					}
					model.keyWord=ds.Tables[0].Rows[n]["keyWord"].ToString();
					if(ds.Tables[0].Rows[n]["layer"].ToString()!="")
					{
						model.layer=int.Parse(ds.Tables[0].Rows[n]["layer"].ToString());
					}
					if(ds.Tables[0].Rows[n]["nodeid"].ToString()!="")
					{
						model.nodeid=int.Parse(ds.Tables[0].Rows[n]["nodeid"].ToString());
					}
					if(ds.Tables[0].Rows[n]["parentid"].ToString()!="")
					{
						model.parentid=int.Parse(ds.Tables[0].Rows[n]["parentid"].ToString());
					}
					model.title=ds.Tables[0].Rows[n]["title"].ToString();
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
