using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using ERM.MDL;
namespace ERM.BLL
{
    /// <summary>
    /// ҵ���߼���FileRecording_Templet ��ժҪ˵����
    /// </summary>
    public class FileRecording_Templet
    {
        private readonly ERM.DAL.FileRecording_Templet dal = new ERM.DAL.FileRecording_Templet();
        public FileRecording_Templet()
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
        public void Add(ERM.MDL.T_FileList model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ERM.MDL.T_FileList model)
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
        public ERM.MDL.T_FileList Find(string id, string ProjectNO)
        {
            return dal.Find(id, ProjectNO);
        }
        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public ERM.MDL.T_FileList GetModelByCache(string id, string ProjectNO)
        {
            string CacheKey = "FileRecording_TempletModel-" + id + ProjectNO;
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
            return (ERM.MDL.T_FileList)objModel;
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
        public List<ERM.MDL.T_FileList> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<ERM.MDL.T_FileList> modelList = new List<ERM.MDL.T_FileList>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                ERM.MDL.T_FileList model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ERM.MDL.T_FileList();
                    model.cjdag = ds.Tables[0].Rows[n]["cjdag"].ToString();
                    model.datawindow_id = ds.Tables[0].Rows[n]["datawindow_id"].ToString();
                    model.extension1 = ds.Tables[0].Rows[n]["extension1"].ToString();
                    model.extension2 = ds.Tables[0].Rows[n]["extension2"].ToString();
                    model.extension3 = ds.Tables[0].Rows[n]["extension3"].ToString();
                    model.gclx = ds.Tables[0].Rows[n]["gclx"].ToString();
                    model.gdwj = ds.Tables[0].Rows[n]["gdwj"].ToString();
                    model.id = ds.Tables[0].Rows[n]["id"].ToString();
                    if (ds.Tables[0].Rows[n]["isvisible"].ToString() != "")
                    {
                        model.isvisible = int.Parse(ds.Tables[0].Rows[n]["isvisible"].ToString());
                    }
                    model.jldw = ds.Tables[0].Rows[n]["jldw"].ToString();
                    model.jsdw = ds.Tables[0].Rows[n]["jsdw"].ToString();
                    if (ds.Tables[0].Rows[n]["orderindex"].ToString() != "")
                    {
                        model.OrderIndex = int.Parse(ds.Tables[0].Rows[n]["orderindex"].ToString());
                    }
                    model.ProjectNO = ds.Tables[0].Rows[n]["ProjectNO"].ToString();
                    model.pTreePath = ds.Tables[0].Rows[n]["pTreePath"].ToString();
                    if (ds.Tables[0].Rows[n]["selected"].ToString() != "")
                    {
                        model.selected = int.Parse(ds.Tables[0].Rows[n]["selected"].ToString());
                    }
                    model.sgdw = ds.Tables[0].Rows[n]["sgdw"].ToString();
                    model.sjdw = ds.Tables[0].Rows[n]["sjdw"].ToString();
                    model.table_name = ds.Tables[0].Rows[n]["table_name"].ToString();
                    model.table_standerd = ds.Tables[0].Rows[n]["table_standerd"].ToString();
                    model.TreePath = ds.Tables[0].Rows[n]["TreePath"].ToString();
                    model.wjmj = ds.Tables[0].Rows[n]["wjmj"].ToString();
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
    }
}
