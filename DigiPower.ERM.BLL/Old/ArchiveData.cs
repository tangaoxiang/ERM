using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
    /// <summary>
    /// 业务逻辑类ArchiveData 的摘要说明。
    /// </summary>
    public class ArchiveData
    {
        private readonly ERM.DAL.ArchiveData dal = new ERM.DAL.ArchiveData();
        public ArchiveData()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.ArchiveData model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.ArchiveData model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.ArchiveData Find(int id)
        {
            return dal.Find(id);
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public ERM.MDL.ArchiveData GetModelByCache(int id)
        {
            string CacheKey = "ArchiveDataModel-" + id;
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
                catch { }
            }
            return (ERM.MDL.ArchiveData)objModel;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList22(string strWhere)
        {
            return dal.GetList22(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ERM.MDL.ArchiveData> GetModelList22(string strWhere)
        {
            DataSet ds = dal.GetList22(strWhere);
            List<ERM.MDL.ArchiveData> modelList = new List<ERM.MDL.ArchiveData>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                ERM.MDL.ArchiveData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ERM.MDL.ArchiveData();
                    model.cellCreatedate = ds.Tables[0].Rows[n]["cellCreatedate"].ToString();
                    model.cellParentid = ds.Tables[0].Rows[n]["cellParentid"].ToString();
                    if (ds.Tables[0].Rows[n]["codetype"].ToString() != "")
                    {
                        model.codetype = int.Parse(ds.Tables[0].Rows[n]["codetype"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["customdefine"].ToString() != "")
                    {
                        model.customdefine = int.Parse(ds.Tables[0].Rows[n]["customdefine"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["docstatus"].ToString() != "")
                    {
                        model.docstatus = int.Parse(ds.Tables[0].Rows[n]["docstatus"].ToString());
                    }
                    model.examplepath = ds.Tables[0].Rows[n]["examplepath"].ToString();
                    model.fbmc = ds.Tables[0].Rows[n]["fbmc"].ToString();
                    model.filepath = ds.Tables[0].Rows[n]["filepath"].ToString();
                    model.fxmc = ds.Tables[0].Rows[n]["fxmc"].ToString();
                    if (ds.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["orderindex"].ToString() != "")
                    {
                        model.orderindex = int.Parse(ds.Tables[0].Rows[n]["orderindex"].ToString());
                    }
                    model.ProjectNO = ds.Tables[0].Rows[n]["ProjectNO"].ToString();
                    model.ptreepath = ds.Tables[0].Rows[n]["ptreepath"].ToString();
                    model.title = ds.Tables[0].Rows[n]["title"].ToString();
                    model.treepath = ds.Tables[0].Rows[n]["treepath"].ToString();
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
        public DataSet GetAllList22()
        {
            return GetList22("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
    }
}
