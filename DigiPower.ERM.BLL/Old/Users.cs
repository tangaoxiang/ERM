using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Users 的摘要说明。
	/// </summary>
	public class Users
	{
		private readonly ERM.DAL.Users dal=new ERM.DAL.Users();
		public Users()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			return dal.Exists(userid);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Users model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.Users model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			dal.Delete(userid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Users GetModel(int userid)
		{
			return dal.GetModel(userid);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.Users GetModelByCache(int userid)
		{
			string CacheKey = "UsersModel-" + userid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(userid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.Users)objModel;
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
		public List<ERM.MDL.Users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.Users> modelList = new List<ERM.MDL.Users>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.Users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.Users();
					model.fullname=ds.Tables[0].Rows[n]["fullname"].ToString();
					model.login=ds.Tables[0].Rows[n]["login"].ToString();
					model.password=ds.Tables[0].Rows[n]["password"].ToString();
					model.phone=ds.Tables[0].Rows[n]["phone"].ToString();
					if(ds.Tables[0].Rows[n]["sh"].ToString()!="")
					{
						model.sh=int.Parse(ds.Tables[0].Rows[n]["sh"].ToString());
					}
					if(ds.Tables[0].Rows[n]["theme"].ToString()!="")
					{
						model.theme=int.Parse(ds.Tables[0].Rows[n]["theme"].ToString());
					}
					model.title=ds.Tables[0].Rows[n]["title"].ToString();
					model.units=ds.Tables[0].Rows[n]["units"].ToString();
					model.unitstype=ds.Tables[0].Rows[n]["unitstype"].ToString();
					if(ds.Tables[0].Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(ds.Tables[0].Rows[n]["userid"].ToString());
					}
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
