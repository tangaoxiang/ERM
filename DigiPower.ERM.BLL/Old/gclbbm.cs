using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
    /// <summary>
    /// 业务逻辑类gclbbm 的摘要说明。
    /// </summary>
    public class gclbbm
    {
        private readonly ERM.DAL.gclbbm dal = new ERM.DAL.gclbbm();
        public gclbbm()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string gclbbm)
        {
            return dal.Exists(gclbbm);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.gclbbm model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.gclbbm model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string gclbbm)
        {
            dal.Delete(gclbbm);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.gclbbm Find(string gclbbm)
        {
            return dal.Find(gclbbm);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ERM.MDL.gclbbm GetModelByCache(string gclbbm)
        {
            string CacheKey = "gclbbmModel-" + gclbbm;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.Find(gclbbm);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ERM.MDL.gclbbm)objModel;
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
        public List<ERM.MDL.gclbbm> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<ERM.MDL.gclbbm> modelList = new List<ERM.MDL.gclbbm>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                ERM.MDL.gclbbm model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ERM.MDL.gclbbm();
                    model.flmc = ds.Tables[0].Rows[n]["flmc"].ToString();
                    model.flms = ds.Tables[0].Rows[n]["flms"].ToString();
                    model.Gclbbm = ds.Tables[0].Rows[n]["gclbbm"].ToString();
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
