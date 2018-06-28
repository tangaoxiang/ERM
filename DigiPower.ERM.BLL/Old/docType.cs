using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类docType 的摘要说明。
	/// </summary>
	public class docType
	{
		private readonly ERM.DAL.docType dal=new ERM.DAL.docType();
		public docType()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string code)
		{
			return dal.Exists(code);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.docType model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.docType model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string code)
		{
			dal.Delete(code);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.docType Find(string code)
		{
			return dal.Find(code);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.docType GetModelByCache(string code)
		{
			string CacheKey = "docTypeModel-" + code;
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
			return (ERM.MDL.docType)objModel;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ERM.MDL.docType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.docType> modelList = new List<ERM.MDL.docType>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.docType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.docType();
					model.code=ds.Tables[0].Rows[n]["code"].ToString();
					model.DocType=ds.Tables[0].Rows[n]["docType"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
	}
}
