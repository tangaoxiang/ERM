using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Item。
	/// </summary>
	public class Item
	{
		public Item()
		{}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Item");
            strSql.Append(" where id=" + id + " ");
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.T_Item model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.AllCost != null)
            {
                strSql1.Append("AllCost,");
                strSql2.Append("'" + model.AllCost + "',");
            }
            if (model.AllCost != null)
            {
                strSql1.Append("ProjectNO,");
                strSql2.Append("'" + model.ProjectNO + "',");
            }
            if (model.Approvedate != null)
            {
                strSql1.Append("Approvedate,");
                strSql2.Append("'" + model.Approvedate + "',");
            }
            if (model.BuildingDensity != null)
            {
                strSql1.Append("BuildingDensity,");
                strSql2.Append("'" + model.BuildingDensity + "',");
            }
            if (model.CollectionType != null)
            {
                strSql1.Append("CollectionType,");
                strSql2.Append("'" + model.CollectionType + "',");
            }
            if (model.ConstructionAreaSum != null)
            {
                strSql1.Append("ConstructionAreaSum,");
                strSql2.Append("'" + model.ConstructionAreaSum + "',");
            }
            if (model.ConstructionProjectAdd != null)
            {
                strSql1.Append("ConstructionProjectAdd,");
                strSql2.Append("'" + model.ConstructionProjectAdd + "',");
            }
            if (model.ConStructionProjectName != null)
            {
                strSql1.Append("ConStructionProjectName,");
                strSql2.Append("'" + model.ConStructionProjectName + "',");
            }
            if (model.ConstructionScale != null)
            {
                strSql1.Append("ConstructionScale,");
                strSql2.Append("'" + model.ConstructionScale + "',");
            }
            if (model.CreateUnit != null)
            {
                strSql1.Append("CreateUnit,");
                strSql2.Append("'" + model.CreateUnit + "',");
            }
            if (model.FinishDate != null)
            {
                strSql1.Append("FinishDate,");
                strSql2.Append("'" + model.FinishDate + "',");
            }
            if (model.GreenFar != null)
            {
                strSql1.Append("GreenFar,");
                strSql2.Append("'" + model.GreenFar + "',");
            }
            if (model.ItemFzr != null)
            {
                strSql1.Append("ItemFzr,");
                strSql2.Append("'" + model.ItemFzr + "',");
            }
            if (model.OriginalSoiType != null)
            {
                strSql1.Append("OriginalSoiType,");
                strSql2.Append("'" + model.OriginalSoiType + "',");
            }
            if (model.ProjectCost != null)
            {
                strSql1.Append("ProjectCost,");
                strSql2.Append("'" + model.ProjectCost + "',");
            }
            if (model.ProjectSettlement != null)
            {
                strSql1.Append("ProjectSettlement,");
                strSql2.Append("'" + model.ProjectSettlement + "',");
            }
            if (model.ProjectType != null)
            {
                strSql1.Append("ProjectType,");
                strSql2.Append("'" + model.ProjectType + "',");
            }
            if (model.Respective != null)
            {
                strSql1.Append("Respective,");
                strSql2.Append("'" + model.Respective + "',");
            }
            if (model.StartDate != null)
            {
                strSql1.Append("StartDate,");
                strSql2.Append("'" + model.StartDate + "',");
            }
            if (model.UseSoiArea != null)
            {
                strSql1.Append("UseSoiArea,");
                strSql2.Append("'" + model.UseSoiArea + "',");
            }
            if (model.UseSoiAreaSum != null)
            {
                strSql1.Append("UseSoiAreaSum,");
                strSql2.Append("'" + model.UseSoiAreaSum + "',");
            }
            if (model.UseSoiType != null)
            {
                strSql1.Append("UseSoiType,");
                strSql2.Append("'" + model.UseSoiType + "',");
            }
            if (model.VolumeFar != null)
            {
                strSql1.Append("VolumeFar,");
                strSql2.Append("'" + model.VolumeFar + "',");
            }
            strSql.Append("insert into Item(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.T_Item model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Item set ");
            strSql.Append("AllCost='" + model.AllCost + "',");
            strSql.Append("ProjectNO='" + model.ProjectNO + "',");
            strSql.Append("Approvedate='" + model.Approvedate + "',");
            strSql.Append("BuildingDensity='" + model.BuildingDensity + "',");
            strSql.Append("CollectionType='" + model.CollectionType + "',");
            strSql.Append("ConstructionAreaSum='" + model.ConstructionAreaSum + "',");
            strSql.Append("ConstructionProjectAdd='" + model.ConstructionProjectAdd + "',");
            strSql.Append("ConStructionProjectName='" + model.ConStructionProjectName + "',");
            strSql.Append("ConstructionScale='" + model.ConstructionScale + "',");
            strSql.Append("CreateUnit='" + model.CreateUnit + "',");
            strSql.Append("FinishDate='" + model.FinishDate + "',");
            strSql.Append("GreenFar='" + model.GreenFar + "',");
            strSql.Append("ItemFzr='" + model.ItemFzr + "',");
            strSql.Append("OriginalSoiType='" + model.OriginalSoiType + "',");
            strSql.Append("ProjectCost='" + model.ProjectCost + "',");
            strSql.Append("ProjectSettlement='" + model.ProjectSettlement + "',");
            strSql.Append("ProjectType='" + model.ProjectType + "',");
            strSql.Append("Respective='" + model.Respective + "',");
            strSql.Append("StartDate='" + model.StartDate + "',");
            strSql.Append("UseSoiArea='" + model.UseSoiArea + "',");
            strSql.Append("UseSoiAreaSum='" + model.UseSoiAreaSum + "',");
            strSql.Append("UseSoiType='" + model.UseSoiType + "',");
            strSql.Append("VolumeFar='" + model.VolumeFar + "'");
            strSql.Append(" where ProjectNO='" + model.ProjectNO + "'");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Item ");
            strSql.Append(" where id=" + id + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.T_Item GetModel(string ProjectNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" AllCost,ProjectNO,Approvedate,BuildingDensity,CollectionType,ConstructionAreaSum,ConstructionProjectAdd,ConStructionProjectName,ConstructionScale,CreateUnit,FinishDate,GreenFar,ItemFzr,OriginalSoiType,ProjectCost,ProjectSettlement,ProjectType,Respective,StartDate,UseSoiArea,UseSoiAreaSum,UseSoiType,VolumeFar ");
            strSql.Append(" from Item ");
            strSql.Append(" where ProjectNO='" + ProjectNO + "'");
            ERM.MDL.T_Item model = new ERM.MDL.T_Item();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AllCost = ds.Tables[0].Rows[0]["AllCost"].ToString();
                model.ProjectNO = ds.Tables[0].Rows[0]["ProjectNO"].ToString();
                model.Approvedate = ds.Tables[0].Rows[0]["Approvedate"].ToString();
                model.BuildingDensity = ds.Tables[0].Rows[0]["BuildingDensity"].ToString();
                model.CollectionType = ds.Tables[0].Rows[0]["CollectionType"].ToString();
                model.ConstructionAreaSum = ds.Tables[0].Rows[0]["ConstructionAreaSum"].ToString();
                model.ConstructionProjectAdd = ds.Tables[0].Rows[0]["ConstructionProjectAdd"].ToString();
                model.ConStructionProjectName = ds.Tables[0].Rows[0]["ConStructionProjectName"].ToString();
                model.ConstructionScale = ds.Tables[0].Rows[0]["ConstructionScale"].ToString();
                model.CreateUnit = ds.Tables[0].Rows[0]["CreateUnit"].ToString();
                model.FinishDate = ds.Tables[0].Rows[0]["FinishDate"].ToString();
                model.GreenFar = ds.Tables[0].Rows[0]["GreenFar"].ToString();                
                model.ItemFzr = ds.Tables[0].Rows[0]["ItemFzr"].ToString();
                model.OriginalSoiType = ds.Tables[0].Rows[0]["OriginalSoiType"].ToString();
                model.ProjectCost = ds.Tables[0].Rows[0]["ProjectCost"].ToString();
                model.ProjectSettlement = ds.Tables[0].Rows[0]["ProjectSettlement"].ToString();
                model.ProjectType = ds.Tables[0].Rows[0]["ProjectType"].ToString();
                model.Respective = ds.Tables[0].Rows[0]["Respective"].ToString();
                model.StartDate = ds.Tables[0].Rows[0]["StartDate"].ToString();
                model.UseSoiArea = ds.Tables[0].Rows[0]["UseSoiArea"].ToString();
                model.UseSoiAreaSum = ds.Tables[0].Rows[0]["UseSoiAreaSum"].ToString();
                model.UseSoiType = ds.Tables[0].Rows[0]["UseSoiType"].ToString();
                model.VolumeFar = ds.Tables[0].Rows[0]["VolumeFar"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AllCost,ProjectNO,Approvedate,BuildingDensity,CollectionType,ConstructionAreaSum,ConstructionProjectAdd,ConStructionProjectName,ConstructionScale,CreateUnit,FinishDate,GreenFar,id,ItemFzr,OriginalSoiType,ProjectCost,ProjectSettlement,ProjectType,Respective,StartDate,UseSoiArea,UseSoiAreaSum,UseSoiType,VolumeFar ");
            strSql.Append(" FROM Item ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }
        /*
        */
	}
}
