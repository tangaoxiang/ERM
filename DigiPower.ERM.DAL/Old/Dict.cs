using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Dict。
	/// </summary>
	public class Dict
	{
		public Dict()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Dict");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Dict model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.DisplayName != null)
			{
				strSql1.Append("DisplayName,");
				strSql2.Append("'"+model.DisplayName+"',");
			}
			if (model.ID != null)
			{
				strSql1.Append("ID,");
				strSql2.Append(""+model.ID+",");
			}
			if (model.KeyWord != null)
			{
				strSql1.Append("KeyWord,");
				strSql2.Append("'"+model.KeyWord+"',");
			}
			if (model.OrderIndex != null)
			{
				strSql1.Append("OrderIndex,");
				strSql2.Append(""+model.OrderIndex+",");
			}
			if (model.ValueName != null)
			{
				strSql1.Append("ValueName,");
				strSql2.Append("'"+model.ValueName+"',");
			}
			strSql.Append("insert into Dict(");
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
		public void Update(ERM.MDL.Dict model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dict set ");
			strSql.Append("DisplayName='"+model.DisplayName+"',");
			strSql.Append("ID="+model.ID+",");
			strSql.Append("KeyWord='"+model.KeyWord+"',");
			strSql.Append("OrderIndex="+model.OrderIndex+",");
			strSql.Append("ValueName='"+model.ValueName+"'");
			strSql.Append(" where ID="+ model.ID+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dict ");
			strSql.Append(" where ID="+ID+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Dict GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" DisplayName,ID,KeyWord,OrderIndex,ValueName ");
			strSql.Append(" from Dict ");
			strSql.Append(" where ID="+ID+" " );
			ERM.MDL.Dict model=new ERM.MDL.Dict();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.DisplayName=ds.Tables[0].Rows[0]["DisplayName"].ToString();
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.KeyWord=ds.Tables[0].Rows[0]["KeyWord"].ToString();
				if(ds.Tables[0].Rows[0]["OrderIndex"].ToString()!="")
				{
					model.OrderIndex=int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
				}
				model.ValueName=ds.Tables[0].Rows[0]["ValueName"].ToString();
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
			strSql.Append("select DisplayName,ID,KeyWord,OrderIndex,ValueName ");
			strSql.Append(" FROM Dict ");
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
