using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Attachment 的摘要说明。
	/// </summary>
	public class Attachment
	{
		private readonly ERM.DAL.Attachment dal=new ERM.DAL.Attachment();
		public Attachment()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int attachid)
		{
			return dal.Exists(attachid);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Attachment model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.Attachment model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int attachid)
		{
			dal.Delete(attachid);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Attachment Find(int attachid)
		{
			return dal.Find(attachid);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.Attachment GetModelByCache(int attachid)
		{
			string CacheKey = "AttachmentModel-" + attachid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.Find(attachid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.Attachment)objModel;
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
		public List<ERM.MDL.Attachment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.Attachment> modelList = new List<ERM.MDL.Attachment>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.Attachment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.Attachment();
					model.ArchiveID=ds.Tables[0].Rows[n]["ArchiveID"].ToString();
					if(ds.Tables[0].Rows[n]["attachid"].ToString()!="")
					{
						model.attachid=int.Parse(ds.Tables[0].Rows[n]["attachid"].ToString());
					}
					model.docFormat=ds.Tables[0].Rows[n]["docFormat"].ToString();
					model.docType=ds.Tables[0].Rows[n]["docType"].ToString();
					if(ds.Tables[0].Rows[n]["DocYs"].ToString()!="")
					{
						model.DocYs=int.Parse(ds.Tables[0].Rows[n]["DocYs"].ToString());
					}
					model.Draft=ds.Tables[0].Rows[n]["Draft"].ToString();
					model.ext=ds.Tables[0].Rows[n]["ext"].ToString();
					model.fileID=ds.Tables[0].Rows[n]["fileID"].ToString();
					if(ds.Tables[0].Rows[n]["FileOrderIndex"].ToString()!="")
					{
						model.FileOrderIndex=int.Parse(ds.Tables[0].Rows[n]["FileOrderIndex"].ToString());
					}
					model.filepath=ds.Tables[0].Rows[n]["filepath"].ToString();
					model.fileTreePath=ds.Tables[0].Rows[n]["fileTreePath"].ToString();
					if(ds.Tables[0].Rows[n]["OrderIndex2"].ToString()!="")
					{
						model.OrderIndex2=int.Parse(ds.Tables[0].Rows[n]["OrderIndex2"].ToString());
					}
					model.OriOpenPro=ds.Tables[0].Rows[n]["OriOpenPro"].ToString();
					model.ProjectNO=ds.Tables[0].Rows[n]["ProjectNO"].ToString();
					model.title=ds.Tables[0].Rows[n]["title"].ToString();
					model.wjly=ds.Tables[0].Rows[n]["wjly"].ToString();
					model.yswjpath=ds.Tables[0].Rows[n]["yswjpath"].ToString();
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
