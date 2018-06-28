using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
    /// <summary>
    /// 业务逻辑类PageSize 的摘要说明。
    /// </summary>
    public class PageSize
    {
        private readonly ERM.DAL.PageSize dal = new ERM.DAL.PageSize();
        public PageSize()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PID)
        {
            return dal.Exists(PID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.PageSize model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.PageSize model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int PID)
        {
            dal.Delete(PID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.PageSize Find(int PID)
        {
            return dal.Find(PID);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ERM.MDL.PageSize GetModelByCache(int PID)
        {
            string CacheKey = "PageSizeModel-" + PID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.Find(PID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ERM.MDL.PageSize)objModel;
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
        public List<ERM.MDL.PageSize> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<ERM.MDL.PageSize> modelList = new List<ERM.MDL.PageSize>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                ERM.MDL.PageSize model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ERM.MDL.PageSize();
                    if (ds.Tables[0].Rows[n]["IsDefault"].ToString() != "")
                    {
                        model.IsDefault = int.Parse(ds.Tables[0].Rows[n]["IsDefault"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Pages"].ToString() != "")
                    {
                        model.Pages = int.Parse(ds.Tables[0].Rows[n]["Pages"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Pfloat"].ToString() != "")
                    {
                        model.Pfloat = int.Parse(ds.Tables[0].Rows[n]["Pfloat"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["PID"].ToString() != "")
                    {
                        model.PID = int.Parse(ds.Tables[0].Rows[n]["PID"].ToString());
                    }
                    model.PTYPE = ds.Tables[0].Rows[n]["PTYPE"].ToString();
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
        /// 得到插入的最大值
        /// </summary>
        /// <returns></returns>
        public int GetPageSizeMaxId()
        {
            return dal.GetPageSizeMaxId();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
    }
}
