using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// ҵ���߼���Item ��ժҪ˵����
	/// </summary>
	public class Item
	{
		private readonly ERM.DAL.Item dal=new ERM.DAL.Item();
		public Item()
		{}
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(ERM.MDL.T_Item model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ERM.MDL.T_Item model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {
            dal.Delete(id);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ERM.MDL.T_Item GetModel(string id)
        {
            return dal.GetModel(id);
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
        public List<ERM.MDL.T_Item> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<ERM.MDL.T_Item> modelList = new List<ERM.MDL.T_Item>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                ERM.MDL.T_Item model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ERM.MDL.T_Item();
                    model.ProjectNO = ds.Tables[0].Rows[n]["ProjectNO"].ToString();
                    model.AllCost = ds.Tables[0].Rows[n]["AllCost"].ToString();
                    model.Approvedate = ds.Tables[0].Rows[n]["Approvedate"].ToString();
                    model.BuildingDensity = ds.Tables[0].Rows[n]["BuildingDensity"].ToString();
                    model.CollectionType = ds.Tables[0].Rows[n]["CollectionType"].ToString();
                    model.ConstructionAreaSum = ds.Tables[0].Rows[n]["ConstructionAreaSum"].ToString();
                    model.ConstructionProjectAdd = ds.Tables[0].Rows[n]["ConstructionProjectAdd"].ToString();
                    model.ConStructionProjectName = ds.Tables[0].Rows[n]["ConStructionProjectName"].ToString();
                    model.ConstructionScale = ds.Tables[0].Rows[n]["ConstructionScale"].ToString();
                    model.CreateUnit = ds.Tables[0].Rows[n]["CreateUnit"].ToString();
                    model.FinishDate = ds.Tables[0].Rows[n]["FinishDate"].ToString();
                    model.GreenFar = ds.Tables[0].Rows[n]["GreenFar"].ToString();
                    model.ItemFzr = ds.Tables[0].Rows[n]["ItemFzr"].ToString();
                    model.OriginalSoiType = ds.Tables[0].Rows[n]["OriginalSoiType"].ToString();
                    model.ProjectCost = ds.Tables[0].Rows[n]["ProjectCost"].ToString();
                    model.ProjectSettlement = ds.Tables[0].Rows[n]["ProjectSettlement"].ToString();
                    model.ProjectType = ds.Tables[0].Rows[n]["ProjectType"].ToString();
                    model.Respective = ds.Tables[0].Rows[n]["Respective"].ToString();
                    model.StartDate = ds.Tables[0].Rows[n]["StartDate"].ToString();
                    model.UseSoiArea = ds.Tables[0].Rows[n]["UseSoiArea"].ToString();
                    model.UseSoiAreaSum = ds.Tables[0].Rows[n]["UseSoiAreaSum"].ToString();
                    model.UseSoiType = ds.Tables[0].Rows[n]["UseSoiType"].ToString();
                    model.VolumeFar = ds.Tables[0].Rows[n]["VolumeFar"].ToString();
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
