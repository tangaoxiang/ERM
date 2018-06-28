using System;
using System.Collections.Generic;
using System.Text;
using Digi.DBUtility;//请先添加引用
using ERM.MDL;
namespace ERM.CBLL
{
   public class District
    {
        /// <summary>
        /// 是否存在该区域名称
        /// </summary>
       public bool Exists(string DistrictName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from District");
            strSql.Append(" where DistrictName='" + DistrictName + "'");
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该区域名称
        /// </summary>
        public bool Exists(string DistrictName,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from District");
            strSql.Append(" where DistrictName='" + DistrictName + "' and DistrictID<>" + id);
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.District model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update District set ");
            strSql.Append("DistrictName='" + model.DistrictName + "',");
            strSql.Append("OrderIndex=" + model.OrderIndex + ",");
            strSql.Append("TempID=" + model.TempID + "");
            strSql.Append(" where DistrictID=" + model.DistrictID + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
       /// <summary>
       /// 获得下一个序号
       /// </summary>
       /// <returns></returns>
       public int GetNextOrderIndex()
       {
           string strSql = "select max(orderindex)  from District";
           object obj = DbHelperOleDb.GetSingle(strSql);
           if (obj == null)
               return 1;
           else
           {
               return Convert.ToInt32(obj) + 1;
           }
       }
    }
}
