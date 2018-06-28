using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类final_file 的摘要说明。
	/// </summary>
	public class final_file
	{
		private readonly ERM.DAL.final_file dal=new ERM.DAL.final_file();
		public final_file()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string FileID)
		{
			return dal.Exists(FileID);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.final_file model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.final_file model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string FileID)
		{
			dal.Delete(FileID);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.final_file Find(string FileID)
		{
			return dal.Find(FileID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.final_file GetModelByCache(string FileID)
		{
			string CacheKey = "final_fileModel-" + FileID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(FileID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.final_file)objModel;
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
		public List<ERM.MDL.final_file> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.final_file> modelList = new List<ERM.MDL.final_file>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.final_file model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.final_file();
					model.bgqx=ds.Tables[0].Rows[n]["bgqx"].ToString();
					model.bz=ds.Tables[0].Rows[n]["bz"].ToString();
					model.bzdw=ds.Tables[0].Rows[n]["bzdw"].ToString();
					if(ds.Tables[0].Rows[n]["CreateDate"].ToString()!="")
					{
						model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[n]["CreateDate"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CreateDate2"].ToString()!="")
					{
						model.CreateDate2=DateTime.Parse(ds.Tables[0].Rows[n]["CreateDate2"].ToString());
					}
					model.dw=ds.Tables[0].Rows[n]["dw"].ToString();
					model.fbl=ds.Tables[0].Rows[n]["fbl"].ToString();
					model.FileID=ds.Tables[0].Rows[n]["FileID"].ToString();
					model.filepath=ds.Tables[0].Rows[n]["filepath"].ToString();
					model.fileStatus=ds.Tables[0].Rows[n]["fileStatus"].ToString();
					model.gg=ds.Tables[0].Rows[n]["gg"].ToString();
					model.mj=ds.Tables[0].Rows[n]["mj"].ToString();
					model.parentid=ds.Tables[0].Rows[n]["parentid"].ToString();
					model.ProjectNO=ds.Tables[0].Rows[n]["ProjectNO"].ToString();
					model.psdd=ds.Tables[0].Rows[n]["psdd"].ToString();
					if(ds.Tables[0].Rows[n]["pssj"].ToString()!="")
					{
						model.pssj=DateTime.Parse(ds.Tables[0].Rows[n]["pssj"].ToString());
					}
					model.psz=ds.Tables[0].Rows[n]["psz"].ToString();
					model.PtreePath=ds.Tables[0].Rows[n]["PtreePath"].ToString();
					model.sb=ds.Tables[0].Rows[n]["sb"].ToString();
					if(ds.Tables[0].Rows[n]["sl"].ToString()!="")
					{
						model.sl=int.Parse(ds.Tables[0].Rows[n]["sl"].ToString());
					}
					model.TreePath=ds.Tables[0].Rows[n]["TreePath"].ToString();
					model.wh=ds.Tables[0].Rows[n]["wh"].ToString();
					model.wjbsm=ds.Tables[0].Rows[n]["wjbsm"].ToString();
					model.wjcj=ds.Tables[0].Rows[n]["wjcj"].ToString();
					model.wjdx=ds.Tables[0].Rows[n]["wjdx"].ToString();
					model.wjgbdm=ds.Tables[0].Rows[n]["wjgbdm"].ToString();
					model.wjgs=ds.Tables[0].Rows[n]["wjgs"].ToString();
					model.wjlxdm=ds.Tables[0].Rows[n]["wjlxdm"].ToString();
					model.wjmc=ds.Tables[0].Rows[n]["wjmc"].ToString();
					model.wjtm=ds.Tables[0].Rows[n]["wjtm"].ToString();
					model.xjpp=ds.Tables[0].Rows[n]["xjpp"].ToString();
					model.xjxh=ds.Tables[0].Rows[n]["xjxh"].ToString();
					model.zrr=ds.Tables[0].Rows[n]["zrr"].ToString();
					model.ztlx=ds.Tables[0].Rows[n]["ztlx"].ToString();
                    model.zpz = ds.Tables[0].Rows[n]["zpz"].ToString();
                    model.tzz = ds.Tables[0].Rows[n]["tzz"].ToString();
                    model.wzz = ds.Tables[0].Rows[n]["wzz"].ToString();
                    model.dpz = ds.Tables[0].Rows[n]["dpz"].ToString();
                    model.dtz = ds.Tables[0].Rows[n]["dtz"].ToString();
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
