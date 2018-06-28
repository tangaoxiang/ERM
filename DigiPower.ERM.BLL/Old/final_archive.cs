using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类final_archive 的摘要说明。
	/// </summary>
	public class final_archive
	{
		private readonly ERM.DAL.final_archive dal=new ERM.DAL.final_archive();
		public final_archive()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ArchiveID)
		{
			return dal.Exists(ArchiveID);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.final_archive model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.final_archive model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ArchiveID)
		{
			dal.Delete(ArchiveID);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.final_archive Find(string ArchiveID)
		{
			return dal.Find(ArchiveID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.final_archive GetModelByCache(string ArchiveID)
		{
			string CacheKey = "final_archiveModel-" + ArchiveID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(ArchiveID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.final_archive)objModel;
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
		public List<ERM.MDL.final_archive> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.final_archive> modelList = new List<ERM.MDL.final_archive>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.final_archive model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.final_archive();
					model.ajlx=ds.Tables[0].Rows[n]["ajlx"].ToString();
					model.ajs=ds.Tables[0].Rows[n]["ajs"].ToString();
					model.ajtm=ds.Tables[0].Rows[n]["ajtm"].ToString();
					model.ArchiveID=ds.Tables[0].Rows[n]["ArchiveID"].ToString();
					model.bgqx=ds.Tables[0].Rows[n]["bgqx"].ToString();
					model.bz=ds.Tables[0].Rows[n]["bz"].ToString();
					model.bzdw=ds.Tables[0].Rows[n]["bzdw"].ToString();
					model.bzrq=ds.Tables[0].Rows[n]["bzrq"].ToString();
					model.cdh=ds.Tables[0].Rows[n]["cdh"].ToString();
					model.cpz=ds.Tables[0].Rows[n]["cpz"].ToString();
					model.dh=ds.Tables[0].Rows[n]["dh"].ToString();
					model.dw=ds.Tables[0].Rows[n]["dw"].ToString();
					model.gpz=ds.Tables[0].Rows[n]["gpz"].ToString();
					model.ljr=ds.Tables[0].Rows[n]["ljr"].ToString();
					model.lxdh=ds.Tables[0].Rows[n]["lxdh"].ToString();
					model.lydh=ds.Tables[0].Rows[n]["lydh"].ToString();
					model.mj=ds.Tables[0].Rows[n]["mj"].ToString();
					if(ds.Tables[0].Rows[n]["orderindex"].ToString()!="")
					{
						model.orderindex=int.Parse(ds.Tables[0].Rows[n]["orderindex"].ToString());
					}
					model.p=ds.Tables[0].Rows[n]["p"].ToString();
					model.ProjectNO=ds.Tables[0].Rows[n]["ProjectNO"].ToString();
					model.qt=ds.Tables[0].Rows[n]["qt"].ToString();
					model.sl=ds.Tables[0].Rows[n]["sl"].ToString();
					model.swp=ds.Tables[0].Rows[n]["swp"].ToString();
					model.ysfw=ds.Tables[0].Rows[n]["ysfw"].ToString();
					model.z=ds.Tables[0].Rows[n]["z"].ToString();
					model.zpz=ds.Tables[0].Rows[n]["zpz"].ToString();
                    model.tzz = ds.Tables[0].Rows[n]["tzz"].ToString();
                    model.wzz = ds.Tables[0].Rows[n]["wzz"].ToString();
                    model.dpz = ds.Tables[0].Rows[n]["dpz"].ToString();
                    model.dtz = ds.Tables[0].Rows[n]["dtz"].ToString();
                    model.jhlx = ds.Tables[0].Rows[n]["jhlx"].ToString();
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
