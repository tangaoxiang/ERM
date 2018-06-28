using System;
using System.Data;
using System.IO;
using System.Reflection;
using IBatisNet.Common;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using IBatisNet.DataMapper.Configuration.Statements;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ERM.DAL
{
    public class MyBatis
    {
        public static ISqlMapper SqlMapInterface;
        private static readonly object syncObj = new object();
        /// <summary>
        /// ����ģʽ
        /// </summary>
        static MyBatis()
        {
            if (SqlMapInterface == null)
            {
                lock (syncObj)
                {
                    if (SqlMapInterface == null)
                    {
                        Assembly assembly = Assembly.Load("ERM.DAL");
                        Stream stream = assembly.GetManifestResourceStream("ERM.DAL.sqlmap.config");
                        DomSqlMapBuilder builder = new DomSqlMapBuilder();
                        try
                        {
                            SqlMapInterface = builder.Configure(stream);
                            SqlMapInterface.DataSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Environment.CurrentDirectory + "\\db\\ERMDB.mdb;Persist Security Info=False";
                        }
                        catch 
                        {   
                        }
                    }
                }
            }
        }
        /**/
        /// <summary>
        /// �õ����������SQL
        /// </summary>
        public static string QueryForSql(string tag, object paramObject)
        {
            IStatement statement = SqlMapInterface.GetMappedStatement(tag).Statement;
            IMappedStatement mapStatement = SqlMapInterface.GetMappedStatement(tag);
            ISqlMapSession session = new SqlMapSession(SqlMapInterface);
            RequestScope request = statement.Sql.GetRequestScope(mapStatement, paramObject, session);
            return request.PreparedStatement.PreparedSql;
        }
        protected static IDbCommand GetDbCommand(string tag, object paramObject)
        {
            IMappedStatement statement = SqlMapInterface.GetMappedStatement(tag);
            if (!SqlMapInterface.IsSessionStarted)
            {
                SqlMapInterface.OpenConnection();
            }
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, paramObject, SqlMapInterface.LocalSession);
            statement.PreparedCommand.Create(request, SqlMapInterface.LocalSession, statement.Statement, paramObject);
            IDbCommand command = SqlMapInterface.LocalSession.CreateCommand(CommandType.Text);
            command.CommandText = request.IDbCommand.CommandText;
            foreach (IDataParameter pa in request.IDbCommand.Parameters)
            {
                IDbDataParameter para = SqlMapInterface.LocalSession.CreateDataParameter();
                para.ParameterName = pa.ParameterName;
                para.Value = pa.Value;
                command.Parameters.Add(para);
            }
            return command;
        }
        public static DataSet QueryForDataSet(string tag, object paramObject)
        {
            DataSet ds = new DataSet();
            IDbCommand command = GetDbCommand(tag, paramObject);
            SqlMapInterface.LocalSession.CreateDataAdapter(command).Fill(ds);
            return ds;
        }

        /// <summary>
        /// ͨ�õ���DataTable�ķ�ʽ�õ�Select�Ľ��(xml�ļ��в���Ҫʹ��$��ǵ�ռλ����)
        /// </summary>
        /// <param name="tag">���ID</param>
        /// <param name="paramObject">�������Ҫ�Ĳ���</param>
        /// <returns>�õ���DataTable</returns>
        public static DataTable QueryForDataTable(string tag, object paramObject)
        {
            return QueryForDataSet(tag, paramObject).Tables[0];
        }
        /// <summary>
        /// ���ڷ�ҳ�ؼ�ʹ��
        /// </summary>
        /// <param name="tag">���ID</param>
        /// <param name="paramObject">�������Ҫ�Ĳ���</param>
        /// <param name="PageSize">ÿҳ��ʾ��Ŀ</param>
        /// <param name="curPage">��ǰҳ</param>
        /// <param name="recCount">��¼����</param>
        /// <returns>�õ���DataTable</returns>
        public static DataTable QueryForDataTable(string tag, object paramObject, int PageSize, int curPage, out int recCount)
        {
            IDataReader dr = null;
            bool isSessionLocal = false;
            string sql = QueryForSql(tag, paramObject);
            string strCount = "select count(*) " + sql.Substring(sql.ToLower().IndexOf("from"));
            IDalSession session = SqlMapInterface.LocalSession;
            DataTable dt = new DataTable();
            if (session == null)
            {
                session = new SqlMapSession(SqlMapInterface);
                session.OpenConnection();
                isSessionLocal = true;
            }
            try
            {
                IDbCommand cmdCount = GetDbCommand(tag, paramObject);
                cmdCount.Connection = session.Connection;
                cmdCount.CommandText = strCount;
                object count = cmdCount.ExecuteScalar();
                recCount = Convert.ToInt32(count);
                IDbCommand cmd = GetDbCommand(tag, paramObject);
                cmd.Connection = session.Connection;
                dr = cmd.ExecuteReader();
                dt = QueryForPaging(dr, PageSize, curPage);
            }
            finally
            {
                if (isSessionLocal)
                {
                    session.CloseConnection();
                }
            }
            return dt;
        }
        /// <summary>
        /// ȡ�غ�������������
        /// </summary>
        /// <param name="dataReader"></param>
        /// <param name="PageSize"></param>
        /// <param name="curPage"></param>
        /// <returns></returns>
        protected static DataTable QueryForPaging(IDataReader dataReader, int PageSize, int curPage)
        {
            DataTable dt;
            dt = new DataTable();
            int colCount = dataReader.FieldCount;
            for (int i = 0; i < colCount; i++)
            {
                dt.Columns.Add(new DataColumn(dataReader.GetName(i), dataReader.GetFieldType(i)));
            }
            object[] vald = new object[colCount];
            int iCount = 0; // ��ʱ��¼����
            while (dataReader.Read())
            {
                if (iCount >= PageSize * (curPage - 1) && iCount < PageSize * curPage)
                {
                    for (int i = 0; i < colCount; i++)
                        vald[i] = dataReader.GetValue(i);
                    dt.Rows.Add(vald);
                }
                else if (iCount > PageSize * curPage)
                {
                    break;
                }
                iCount++; // ��ʱ��¼��������
            }
            if (!dataReader.IsClosed)
            {
                dataReader.Close();
                dataReader.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// ��ѯSQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet QueueyForSql(string sql){
            DataSet ds = null;
            using (OleDbConnection conn = new OleDbConnection(SqlMapInterface.DataSource.ConnectionString))
            {
                if (conn.State== ConnectionState.Closed)
                {
                    conn.Open();
                }

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                OleDbDataAdapter sda = new OleDbDataAdapter();
                sda.SelectCommand = cmd;

                ds = new DataSet();
                sda.Fill(ds);
            }

            return ds;     
        }
    }
}
