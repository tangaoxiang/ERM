using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Units 的摘要说明。
	/// </summary>
	public class Units
	{
		private readonly ERM.DAL.Units dal=new ERM.DAL.Units();
		public Units()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string unitid)
		{
			return dal.Exists(unitid);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.T_Units model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.T_Units model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string unitid)
		{
			dal.Delete(unitid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.T_Units GetModel(string unitid)
		{
			return dal.GetModel(unitid);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.T_Units GetModelByCache(string unitid)
		{
			string CacheKey = "UnitsModel-" + unitid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(unitid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.T_Units)objModel;
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
		public List<ERM.MDL.T_Units> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.T_Units> modelList = new List<ERM.MDL.T_Units>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.T_Units model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.T_Units();
					model.addr=ds.Tables[0].Rows[n]["addr"].ToString();
					model.dwmc=ds.Tables[0].Rows[n]["dwmc"].ToString();
					model.fax=ds.Tables[0].Rows[n]["fax"].ToString();
					model.fzr=ds.Tables[0].Rows[n]["fzr"].ToString();
					model.fzrzs=ds.Tables[0].Rows[n]["fzrzs"].ToString();
					model.projectno=ds.Tables[0].Rows[n]["projectno"].ToString();
					model.remark=ds.Tables[0].Rows[n]["remark"].ToString();
					model.tel=ds.Tables[0].Rows[n]["tel"].ToString();
					model.unitid=ds.Tables[0].Rows[n]["unitid"].ToString();
					model.unittype=ds.Tables[0].Rows[n]["unittype"].ToString();
					model.xmjl=ds.Tables[0].Rows[n]["xmjl"].ToString();
					model.zrzbsm=ds.Tables[0].Rows[n]["zrzbsm"].ToString();
					model.zrzlb=ds.Tables[0].Rows[n]["zrzlb"].ToString();
					model.zrzmc=ds.Tables[0].Rows[n]["zrzmc"].ToString();
					model.zrzzzfw=ds.Tables[0].Rows[n]["zrzzzfw"].ToString();
					model.zzdj=ds.Tables[0].Rows[n]["zzdj"].ToString();
					model.zzzh=ds.Tables[0].Rows[n]["zzzh"].ToString();
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
