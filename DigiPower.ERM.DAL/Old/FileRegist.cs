using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//�����������
using System.Data.SqlClient;
namespace ERM.DAL
{
    public class FileRegist
    {
        public FileRegist()
        {
        }
        /// <summary>
        /// ��ȡģ�漶������Ϣ
        /// </summary>
        /// <param name="Sql">��ѯ���</param>
        /// <returns>��ѯ�����</returns>
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
        /// ��ȡ�ύ��ĵ����ļ��б�·������
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
