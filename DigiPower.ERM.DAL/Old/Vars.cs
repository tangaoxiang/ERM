using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Vars。
	/// </summary>
	public class Vars
	{
		public Vars()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int varID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Vars");
			strSql.Append(" where varID="+varID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Vars model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.varID != null)
			{
				strSql1.Append("varID,");
				strSql2.Append(""+model.varID+",");
			}
			if (model.varName != null)
			{
				strSql1.Append("varName,");
				strSql2.Append("'"+model.varName+"',");
			}
			if (model.varTitle != null)
			{
				strSql1.Append("varTitle,");
				strSql2.Append("'"+model.varTitle+"',");
			}
			strSql.Append("insert into Vars(");
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
		public void Update(ERM.MDL.Vars model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Vars set ");
			strSql.Append("varID="+model.varID+",");
			strSql.Append("varName='"+model.varName+"',");
			strSql.Append("varTitle='"+model.varTitle+"'");
			strSql.Append(" where varID="+ model.varID+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int varID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Vars ");
			strSql.Append(" where varID="+varID+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Vars Find(int varID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" varID,varName,varTitle ");
			strSql.Append(" from Vars ");
			strSql.Append(" where varID="+varID+" " );
			ERM.MDL.Vars model=new ERM.MDL.Vars();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["varID"].ToString()!="")
				{
					model.varID=int.Parse(ds.Tables[0].Rows[0]["varID"].ToString());
				}
				model.varName=ds.Tables[0].Rows[0]["varName"].ToString();
				model.varTitle=ds.Tables[0].Rows[0]["varTitle"].ToString();
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
			strSql.Append("select varID,varName,varTitle ");
			strSql.Append(" FROM Vars ");
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
