using System;
using System.Data;
using System.Collections.Generic;

namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Vars 的摘要说明。
	/// </summary>
	public class Vars
	{
		private readonly ERM.DAL.Vars dal=new ERM.DAL.Vars();
		public Vars()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int varID)
		{
			return dal.Exists(varID);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Vars model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.Vars model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int varID)
		{
			dal.Delete(varID);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Vars Find(int varID)
		{
			return dal.Find(varID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
	}
}
