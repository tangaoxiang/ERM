using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类NewFileRecording_Templet 的摘要说明。
	/// </summary>
	public class NewFileRecording_Templet
	{
		private readonly ERM.DAL.NewFileRecording_Templet dal=new ERM.DAL.NewFileRecording_Templet();
		public NewFileRecording_Templet()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			return dal.Exists(id);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.NewFileRecording_Templet model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.NewFileRecording_Templet model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string id)
		{
			dal.Delete(id);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.NewFileRecording_Templet Find(string id)
		{
			return dal.Find(id);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.NewFileRecording_Templet GetModelByCache(string id)
		{
			string CacheKey = "NewFileRecording_TempletModel-" + id;
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
			return (ERM.MDL.NewFileRecording_Templet)objModel;
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
		public List<ERM.MDL.NewFileRecording_Templet> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.NewFileRecording_Templet> modelList = new List<ERM.MDL.NewFileRecording_Templet>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.NewFileRecording_Templet model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.NewFileRecording_Templet();
					model.id=ds.Tables[0].Rows[n]["id"].ToString();
					model.ptreepath=ds.Tables[0].Rows[n]["ptreepath"].ToString();
					model.table_name=ds.Tables[0].Rows[n]["table_name"].ToString();
					model.title=ds.Tables[0].Rows[n]["title"].ToString();
					model.treepath=ds.Tables[0].Rows[n]["treepath"].ToString();
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
