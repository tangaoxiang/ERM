using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类NewFileRecording_Templet。
	/// </summary>
	public class NewFileRecording_Templet
	{
		public NewFileRecording_Templet()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewFileRecording_Templet");
			strSql.Append(" where id='"+id+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.NewFileRecording_Templet model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.id != null)
			{
				strSql1.Append("id,");
				strSql2.Append("'"+model.id+"',");
			}
			if (model.ptreepath != null)
			{
				strSql1.Append("ptreepath,");
				strSql2.Append("'"+model.ptreepath+"',");
			}
			if (model.table_name != null)
			{
				strSql1.Append("table_name,");
				strSql2.Append("'"+model.table_name+"',");
			}
			if (model.title != null)
			{
				strSql1.Append("title,");
				strSql2.Append("'"+model.title+"',");
			}
			if (model.treepath != null)
			{
				strSql1.Append("treepath,");
				strSql2.Append("'"+model.treepath+"',");
			}
			strSql.Append("insert into NewFileRecording_Templet(");
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
		public void Update(ERM.MDL.NewFileRecording_Templet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewFileRecording_Templet set ");
			if (model.id != null)
			{
				strSql.Append("id='"+model.id+"',");
			}
			if (model.ptreepath != null)
			{
				strSql.Append("ptreepath='"+model.ptreepath+"',");
			}
			if (model.table_name != null)
			{
				strSql.Append("table_name='"+model.table_name+"',");
			}
			if (model.title != null)
			{
				strSql.Append("title='"+model.title+"',");
			}
			if (model.treepath != null)
			{
				strSql.Append("treepath='"+model.treepath+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id='"+ model.id+"' ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewFileRecording_Templet ");
			strSql.Append(" where id='"+id+"' " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.NewFileRecording_Templet Find(string id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,ptreepath,table_name,title,treepath ");
			strSql.Append(" from NewFileRecording_Templet ");
			strSql.Append(" where id='"+id+"' " );
			ERM.MDL.NewFileRecording_Templet model=new ERM.MDL.NewFileRecording_Templet();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.id=ds.Tables[0].Rows[0]["id"].ToString();
				model.ptreepath=ds.Tables[0].Rows[0]["ptreepath"].ToString();
				model.table_name=ds.Tables[0].Rows[0]["table_name"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.treepath=ds.Tables[0].Rows[0]["treepath"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,ptreepath,table_name,title,treepath ");
			strSql.Append(" FROM NewFileRecording_Templet ");
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
