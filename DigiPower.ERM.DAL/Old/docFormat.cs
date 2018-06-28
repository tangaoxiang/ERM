using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//�����������
namespace ERM.DAL
{
	/// <summary>
	/// ���ݷ�����docFormat��
	/// </summary>
	public class docFormat
	{
		public docFormat()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from docFormat");
			strSql.Append(" where code='"+code+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.docFormat model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.code != null)
			{
				strSql1.Append("code,");
				strSql2.Append("'"+model.code+"',");
			}
			if (model.typename != null)
			{
				strSql1.Append("typename,");
				strSql2.Append("'"+model.typename+"',");
			}
			strSql.Append("insert into docFormat(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ERM.MDL.docFormat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update docFormat set ");
			strSql.Append("code='"+model.code+"',");
			strSql.Append("typename='"+model.typename+"'");
			strSql.Append(" where code='"+ model.code+"' ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from docFormat ");
			strSql.Append(" where code='"+code+"' " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.docFormat Find(string code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" code,typename ");
			strSql.Append(" from docFormat ");
			strSql.Append(" where code='"+code+"' " );
			ERM.MDL.docFormat model=new ERM.MDL.docFormat();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.code=ds.Tables[0].Rows[0]["code"].ToString();
				model.typename=ds.Tables[0].Rows[0]["typename"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select code,typename ");
			strSql.Append(" FROM docFormat ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}
		/*
		*/
	}
}
