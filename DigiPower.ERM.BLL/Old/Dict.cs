using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Dict 的摘要说明。
	/// </summary>
	public class Dict
	{
		private readonly ERM.DAL.Dict dal=new ERM.DAL.Dict();
		public Dict()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Dict model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.Dict model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			dal.Delete(ID);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Dict GetModel(int ID)
		{
			return dal.GetModel(ID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
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
