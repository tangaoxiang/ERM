using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//�����������
namespace ERM.DAL
{
	/// <summary>
	/// ���ݷ�����docType��
	/// </summary>
	public class docType
	{
		public docType()
		{}
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from docType");
			strSql.Append(" where code='"+code+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ERM.MDL.docType model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.code != null)
			{
				strSql1.Append("code,");
				strSql2.Append("'"+model.code+"',");
			}
			if (model.DocType != null)
			{
				strSql1.Append("docType,");
                strSql2.Append("'" + model.DocType + "',");
			}
			strSql.Append("insert into docType(");
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
		public void Update(ERM.MDL.docType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update docType set ");
			strSql.Append("code='"+model.code+"',");
            strSql.Append("docType='" + model.DocType + "'");
			strSql.Append(" where code='"+ model.code+"' ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from docType ");
			strSql.Append(" where code='"+code+"' " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ERM.MDL.docType Find(string code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" code,docType ");
			strSql.Append(" from docType ");
			strSql.Append(" where code='"+code+"' " );
			ERM.MDL.docType model=new ERM.MDL.docType();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.code=ds.Tables[0].Rows[0]["code"].ToString();
                model.DocType = ds.Tables[0].Rows[0]["docType"].ToString();
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
			strSql.Append("select code,docType ");
			strSql.Append(" FROM docType ");
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
