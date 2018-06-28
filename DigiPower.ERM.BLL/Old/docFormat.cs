using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类docFormat 的摘要说明。
	/// </summary>
	public class docFormat
	{
		private readonly ERM.DAL.docFormat dal=new ERM.DAL.docFormat();
		public docFormat()
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
		public void Add(ERM.MDL.docFormat model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.docFormat model)
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
		public ERM.MDL.docFormat Find(string code)
		{
			return dal.Find(code);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.docFormat GetModelByCache(string code)
		{
			string CacheKey = "docFormatModel-" + code;
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
			return (ERM.MDL.docFormat)objModel;
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
		public List<ERM.MDL.docFormat> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.docFormat> modelList = new List<ERM.MDL.docFormat>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.docFormat model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.docFormat();
					model.code=ds.Tables[0].Rows[n]["code"].ToString();
					model.typename=ds.Tables[0].Rows[n]["typename"].ToString();
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
