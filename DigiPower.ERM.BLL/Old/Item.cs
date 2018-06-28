using System;
using System.Data;
using System.Collections.Generic;
using ERM.MDL;
namespace ERM.BLL
{
	/// <summary>
	/// 业务逻辑类Item 的摘要说明。
	/// </summary>
	public class Item
	{
		private readonly ERM.DAL.Item dal=new ERM.DAL.Item();
		public Item()
		{}
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
        public void Add(ERM.MDL.T_Item model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.T_Item model)
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
        public ERM.MDL.T_Item GetModel(string id)
        {
            return dal.GetModel(id);
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
