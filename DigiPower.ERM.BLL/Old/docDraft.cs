using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���docDraft ��ժҪ˵����
	/// </summary>
	public class docDraft
	{
		private readonly ERM.DAL.docDraft dal=new ERM.DAL.docDraft();
		public docDraft()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string code)
		{
			return dal.Exists(code);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.docDraft model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.docDraft model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string code)
		{
			dal.Delete(code);
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.docDraft Find(string code)
		{
			return dal.Find(code);
		}
		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public ERM.MDL.docDraft GetModelByCache(string code)
		{
			string CacheKey = "docDraftModel-" + code;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(code);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.docDraft)objModel;
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
		public List<ERM.MDL.docDraft> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.docDraft> modelList = new List<ERM.MDL.docDraft>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.docDraft model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.docDraft();
					model.code=ds.Tables[0].Rows[n]["code"].ToString();
					model.draft=ds.Tables[0].Rows[n]["draft"].ToString();
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
