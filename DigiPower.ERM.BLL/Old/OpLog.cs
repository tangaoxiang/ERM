using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类OpLog 的摘要说明。
	/// </summary>
	public class OpLog
	{
		private readonly ERM.DAL.OpLog dal=new ERM.DAL.OpLog();
		public OpLog()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.OpLog model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.OpLog model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			dal.Delete(id);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.OpLog Find(int id)
		{
			return dal.Find(id);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.OpLog GetModelByCache(int id)
		{
			string CacheKey = "OpLogModel-" + id;
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
			return (ERM.MDL.OpLog)objModel;
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
		public List<ERM.MDL.OpLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.OpLog> modelList = new List<ERM.MDL.OpLog>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.OpLog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.OpLog();
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					model.OpDate=ds.Tables[0].Rows[n]["OpDate"].ToString();
					model.OpDesc=ds.Tables[0].Rows[n]["OpDesc"].ToString();
					model.OpWork=ds.Tables[0].Rows[n]["OpWork"].ToString();
					model.tableName=ds.Tables[0].Rows[n]["tableName"].ToString();
					model.tablePk=ds.Tables[0].Rows[n]["tablePk"].ToString();
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
