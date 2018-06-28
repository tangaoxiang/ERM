using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
    /// <summary>
    /// ҵ���߼���Cell_Templet ��ժҪ˵����
    /// </summary>
    public class Cell_Templet
    {
        private readonly ERM.DAL.Cell_Templet dal = new ERM.DAL.Cell_Templet();
        public Cell_Templet()
        { }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string id, string ProjectNO)
        {
            return dal.Exists(id, ProjectNO);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(ERM.MDL.T_CellFile model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ERM.MDL.T_CellFile model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string id, string ProjectNO)
        {
            dal.Delete(id, ProjectNO);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ERM.MDL.T_CellFile Find(string id, string ProjectNO)
        {
            return dal.Find(id, ProjectNO);
        }
        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
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
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// ��������б�
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
