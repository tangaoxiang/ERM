using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���FileZrz ��ժҪ˵����
	/// </summary>
	public class FileZrz
	{
		private readonly ERM.DAL.FileZrz dal=new ERM.DAL.FileZrz();
		public FileZrz()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.FileZrz model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.FileZrz model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			dal.Delete(id);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.FileZrz Find(int id)
		{
			return dal.Find(id);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.FileZrz GetModelByCache(int id)
		{
			string CacheKey = "FileZrzModel-" + id;
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
			return (ERM.MDL.FileZrz)objModel;
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
		public List<ERM.MDL.FileZrz> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.FileZrz> modelList = new List<ERM.MDL.FileZrz>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.FileZrz model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.FileZrz();
					model.fileid=ds.Tables[0].Rows[n]["fileid"].ToString();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					model.treepath=ds.Tables[0].Rows[n]["treepath"].ToString();
					model.zezzzfw=ds.Tables[0].Rows[n]["zezzzfw"].ToString();
					model.zrzbsm=ds.Tables[0].Rows[n]["zrzbsm"].ToString();
					model.zrzlb=ds.Tables[0].Rows[n]["zrzlb"].ToString();
					model.zrzmc=ds.Tables[0].Rows[n]["zrzmc"].ToString();
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
