using System;
using System.Collections.Generic;
using System.Text;
using Digi.DBUtility;//�����������
using ERM.MDL;
using System.Data;
namespace ERM.CBLL
{
    public class PageSize
    {
        /// <summary>
        /// �����ǰĬ�ϵ�
        /// </summary>
        public void ClearDefault()
        {
            string sql = "update pagesize set isdefault=0";
            DbHelperOleDb.ExecuteSql(sql);
        }
        /// <summary>
        /// ������ݼ�
        /// </summary>
        /// <returns></returns>
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PID ,PTYPE,Pages,Pfloat,IsDefault");
            strSql.Append(" FROM PageSize ");
            return DbHelperOleDb.Query(strSql.ToString());
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ERM.MDL.PageSize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PageSize set ");
            strSql.Append("IsDefault=" + model.IsDefault + ",");
            strSql.Append("Pages=" + model.Pages + ",");
            strSql.Append("Pfloat=" + model.Pfloat + ",");
            strSql.Append("PTYPE='" + model.PTYPE + "'");
            strSql.Append(" where PID=" + model.PID + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        public DataSet GetPageSizePTYPE(string PTYPE)
        {
            string strSql = "select PID ,PTYPE,Pages,Pfloat,IsDefault FROM PageSize  where PTYPE='" + PTYPE + "'"; 
            return DbHelperOleDb.Query(strSql.ToString());
        }
    }
}
