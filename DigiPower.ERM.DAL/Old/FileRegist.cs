using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
using System.Data.SqlClient;
namespace ERM.DAL
{
    public class FileRegist
    {
        public FileRegist()
        {
        }
        /// <summary>
        /// 获取模版级的树信息
        /// </summary>
        /// <param name="Sql">查询语句</param>
        /// <returns>查询结果集</returns>
        public DataSet GetTreeForTemplate(string Sql)
        {
            try
            {
                return DbHelperOleDb.Query(Sql);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取提交后的电子文件列表路径集合
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public DataSet GetDocuments(string Sql)
        {
            try
            {
                return DbHelperOleDb.Query(Sql);
            }
            catch
            {
                return null;
            }
        }
    }
} 
