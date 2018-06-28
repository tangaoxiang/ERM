using System;
using System.Collections.Generic;
using System.Text;
using Digi.DBUtility;//�����������
using ERM.MDL;
namespace ERM.CBLL
{
   public class District
    {
        /// <summary>
        /// �Ƿ���ڸ���������
        /// </summary>
       public bool Exists(string DistrictName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from District");
            strSql.Append(" where DistrictName='" + DistrictName + "'");
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// �Ƿ���ڸ���������
        /// </summary>
        public bool Exists(string DistrictName,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from District");
            strSql.Append(" where DistrictName='" + DistrictName + "' and DistrictID<>" + id);
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// ����һ������
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
       /// �����һ�����
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
