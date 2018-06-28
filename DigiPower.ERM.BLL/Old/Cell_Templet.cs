using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
    /// <summary>
    /// 业务逻辑类Cell_Templet 的摘要说明。
    /// </summary>
    public class Cell_Templet
    {
        private readonly ERM.DAL.Cell_Templet dal = new ERM.DAL.Cell_Templet();
        public Cell_Templet()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id, string ProjectNO)
        {
            return dal.Exists(id, ProjectNO);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.T_CellFile model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.T_CellFile model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id, string ProjectNO)
        {
            dal.Delete(id, ProjectNO);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.T_CellFile Find(string id, string ProjectNO)
        {
            return dal.Find(id, ProjectNO);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ERM.MDL.T_CellFile GetModelByCache(string id, string ProjectNO)
        {
            string CacheKey = "Cell_TempletModel-" + id + ProjectNO;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.Find(id, ProjectNO);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ERM.MDL.T_CellFile)objModel;
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
        public List<ERM.MDL.T_CellFile> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<ERM.MDL.T_CellFile> modelList = new List<ERM.MDL.T_CellFile>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                ERM.MDL.T_CellFile model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ERM.MDL.T_CellFile();
                    model.codeno = ds.Tables[0].Rows[n]["codeno"].ToString();
                    if (ds.Tables[0].Rows[n]["codetype"].ToString() != "")
                    {
                        model.codetype = int.Parse(ds.Tables[0].Rows[n]["codetype"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["customdefine"].ToString() != "")
                    {
                        model.customdefine = int.Parse(ds.Tables[0].Rows[n]["customdefine"].ToString());
                    }
                    model.examplepath = ds.Tables[0].Rows[n]["examplepath"].ToString();
                    model.fbmc = ds.Tables[0].Rows[n]["fbmc"].ToString();
                    model.filepath = ds.Tables[0].Rows[n]["filepath"].ToString();
                    model.fxmc = ds.Tables[0].Rows[n]["fxmc"].ToString();
                    model.id = ds.Tables[0].Rows[n]["id"].ToString();
                    if (ds.Tables[0].Rows[n]["isvisible"].ToString() != "")
                    {
                        model.isvisible = int.Parse(ds.Tables[0].Rows[n]["isvisible"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["orderindex"].ToString() != "")
                    {
                        model.orderindex = int.Parse(ds.Tables[0].Rows[n]["orderindex"].ToString());
                    }
                    model.parentid = ds.Tables[0].Rows[n]["parentid"].ToString();
                    model.ProjectNO = ds.Tables[0].Rows[n]["ProjectNO"].ToString();
                    model.PTreePath = ds.Tables[0].Rows[n]["PTreePath"].ToString();
                    model.title = ds.Tables[0].Rows[n]["title"].ToString();
                    model.TreePath = ds.Tables[0].Rows[n]["TreePath"].ToString();
                    if (ds.Tables[0].Rows[n]["ys"].ToString() != "")
                    {
                        model.ys = int.Parse(ds.Tables[0].Rows[n]["ys"].ToString());
                    }
                    model.zfbmc = ds.Tables[0].Rows[n]["zfbmc"].ToString();
                    model.zrr = ds.Tables[0].Rows[n]["zrr"].ToString();
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
        public MDL.T_CellFile GetMaxByParentID(string parentid)
        {
            MDL.T_CellFile mdl = new ERM.MDL.T_CellFile();
            DataSet ds1 = dal.GetMaxByParentID(parentid);
            if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                mdl = dal.Find(ds1.Tables[0].Rows[0]["id"].ToString(), ds1.Tables[0].Rows[0]["ProjectNO"].ToString());
            }            
            return mdl;
        }
    }
}
