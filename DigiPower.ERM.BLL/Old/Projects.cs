using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Projects 的摘要说明。
	/// </summary>
	public class Projects
	{
		private readonly ERM.DAL.Projects dal=new ERM.DAL.Projects();
		public Projects()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string projectno)
		{
			return dal.Exists(projectno);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.T_Projects model)
		{
			dal.Add(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(ERM.MDL.T_Projects model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string projectno)
		{
			dal.Delete(projectno);
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.T_Projects GetModel(string projectno)
		{
			return dal.GetModel(projectno);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public ERM.MDL.T_Projects GetModelByCache(string projectno)
		{
			string CacheKey = "ProjectsModel-" + projectno;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(projectno);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ERM.MDL.T_Projects)objModel;
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
		public List<ERM.MDL.T_Projects> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<ERM.MDL.T_Projects> modelList = new List<ERM.MDL.T_Projects>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				ERM.MDL.T_Projects model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new ERM.MDL.T_Projects();
					model.address=ds.Tables[0].Rows[n]["address"].ToString();
					if(ds.Tables[0].Rows[n]["area1"].ToString()!="")
					{
						model.area1=decimal.Parse(ds.Tables[0].Rows[n]["area1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["area2"].ToString()!="")
					{
						model.area2=decimal.Parse(ds.Tables[0].Rows[n]["area2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["begindate"].ToString()!="")
					{
						model.begindate=DateTime.Parse(ds.Tables[0].Rows[n]["begindate"].ToString());
					}
					model.bgyfmj=ds.Tables[0].Rows[n]["bgyfmj"].ToString();
					if(ds.Tables[0].Rows[n]["bjdate"].ToString()!="")
					{
						model.bjdate=DateTime.Parse(ds.Tables[0].Rows[n]["bjdate"].ToString());
					}
					model.category=ds.Tables[0].Rows[n]["category"].ToString();
					model.cfmj=ds.Tables[0].Rows[n]["cfmj"].ToString();
					if(ds.Tables[0].Rows[n]["createdate"].ToString()!="")
					{
						model.createdate=DateTime.Parse(ds.Tables[0].Rows[n]["createdate"].ToString());
					}
					model.district=ds.Tables[0].Rows[n]["district"].ToString();
					model.dxsmj=ds.Tables[0].Rows[n]["dxsmj"].ToString();
					if(ds.Tables[0].Rows[n]["enddate"].ToString()!="")
					{
						model.enddate=DateTime.Parse(ds.Tables[0].Rows[n]["enddate"].ToString());
					}
					if(ds.Tables[0].Rows[n]["floors1"].ToString()!="")
					{
						model.floors1=int.Parse(ds.Tables[0].Rows[n]["floors1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["floors2"].ToString()!="")
					{
						model.floors2=int.Parse(ds.Tables[0].Rows[n]["floors2"].ToString());
					}
					model.ghcode=ds.Tables[0].Rows[n]["ghcode"].ToString();
					if(ds.Tables[0].Rows[n]["high"].ToString()!="")
					{
						model.high=decimal.Parse(ds.Tables[0].Rows[n]["high"].ToString());
					}
					model.hjqk=ds.Tables[0].Rows[n]["hjqk"].ToString();
					model.jldwshr=ds.Tables[0].Rows[n]["jldwshr"].ToString();
					model.jsdwshr=ds.Tables[0].Rows[n]["jsdwshr"].ToString();
					model.passwd=ds.Tables[0].Rows[n]["passwd"].ToString();
					if(ds.Tables[0].Rows[n]["price1"].ToString()!="")
					{
						model.price1=decimal.Parse(ds.Tables[0].Rows[n]["price1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["price2"].ToString()!="")
					{
						model.price2=decimal.Parse(ds.Tables[0].Rows[n]["price2"].ToString());
					}
					model.projectname=ds.Tables[0].Rows[n]["projectname"].ToString();
					model.projectno=ds.Tables[0].Rows[n]["projectno"].ToString();
					model.projecttype=ds.Tables[0].Rows[n]["projecttype"].ToString();
					model.qtyfmj=ds.Tables[0].Rows[n]["qtyfmj"].ToString();
					model.sgbzz=ds.Tables[0].Rows[n]["sgbzz"].ToString();
					model.sgcode=ds.Tables[0].Rows[n]["sgcode"].ToString();
					model.stru=ds.Tables[0].Rows[n]["stru"].ToString();
					model.syyfmj=ds.Tables[0].Rows[n]["syyfmj"].ToString();
					model.tbr=ds.Tables[0].Rows[n]["tbr"].ToString();
					if(ds.Tables[0].Rows[n]["tempid"].ToString()!="")
					{
						model.tempid=int.Parse(ds.Tables[0].Rows[n]["tempid"].ToString());
					}
					model.ts1=ds.Tables[0].Rows[n]["ts1"].ToString();
					model.ts2=ds.Tables[0].Rows[n]["ts2"].ToString();
					model.ts3=ds.Tables[0].Rows[n]["ts3"].ToString();
					model.ts4=ds.Tables[0].Rows[n]["ts4"].ToString();
					model.tstotal=ds.Tables[0].Rows[n]["tstotal"].ToString();
					model.ydpzcode=ds.Tables[0].Rows[n]["ydpzcode"].ToString();
					model.ydxkcode=ds.Tables[0].Rows[n]["ydxkcode"].ToString();
					model.zjy=ds.Tables[0].Rows[n]["zjy"].ToString();
					model.zygz=ds.Tables[0].Rows[n]["zygz"].ToString();
					model.zzmj=ds.Tables[0].Rows[n]["zzmj"].ToString();
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
