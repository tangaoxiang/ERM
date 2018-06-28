using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Settings。
	/// </summary>
	public class Settings
	{
		public Settings()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Settings");
			strSql.Append(" where ID="+ID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Settings model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.AppTitle != null)
			{
				strSql1.Append("AppTitle,");
				strSql2.Append("'"+model.AppTitle+"',");
			}
			if (model.defaultTempID != null)
			{
				strSql1.Append("defaultTempID,");
				strSql2.Append(""+model.defaultTempID+",");
			}
			if (model.ID != null)
			{
				strSql1.Append("ID,");
				strSql2.Append(""+model.ID+",");
			}
			if (model.port != null)
			{
				strSql1.Append("port,");
				strSql2.Append("'"+model.port+"',");
			}
			if (model.PromptTitle != null)
			{
				strSql1.Append("PromptTitle,");
				strSql2.Append("'"+model.PromptTitle+"',");
			}
			if (model.ServerAddr != null)
			{
				strSql1.Append("ServerAddr,");
				strSql2.Append("'"+model.ServerAddr+"',");
			}
			if (model.timeout != null)
			{
				strSql1.Append("timeout,");
				strSql2.Append(""+model.timeout+",");
			}
			if (model.UserTitle != null)
			{
				strSql1.Append("UserTitle,");
				strSql2.Append("'"+model.UserTitle+"',");
			}
			if (model.Ver != null)
			{
				strSql1.Append("Ver,");
				strSql2.Append("'"+model.Ver+"',");
			}
			strSql.Append("insert into Settings(");
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
		public void Update(ERM.MDL.Settings model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Settings set ");
			strSql.Append("AppTitle='"+model.AppTitle+"',");
			strSql.Append("defaultTempID="+model.defaultTempID+",");
			strSql.Append("ID="+model.ID+",");
			strSql.Append("port='"+model.port+"',");
			strSql.Append("PromptTitle='"+model.PromptTitle+"',");
			strSql.Append("ServerAddr='"+model.ServerAddr+"',");
			strSql.Append("timeout="+model.timeout+",");
			strSql.Append("UserTitle='"+model.UserTitle+"',");
			strSql.Append("Ver='"+model.Ver+"'");
			strSql.Append(" where ID="+ model.ID+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Settings ");
			strSql.Append(" where ID="+ID+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Settings Find(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" AppTitle,defaultTempID,ID,port,PromptTitle,ServerAddr,timeout,UserTitle,Ver ");
			strSql.Append(" from Settings ");
			strSql.Append(" where ID="+ID+" " );
			ERM.MDL.Settings model=new ERM.MDL.Settings();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.AppTitle=ds.Tables[0].Rows[0]["AppTitle"].ToString();
				if(ds.Tables[0].Rows[0]["defaultTempID"].ToString()!="")
				{
					model.defaultTempID=int.Parse(ds.Tables[0].Rows[0]["defaultTempID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.port=ds.Tables[0].Rows[0]["port"].ToString();
				model.PromptTitle=ds.Tables[0].Rows[0]["PromptTitle"].ToString();
				model.ServerAddr=ds.Tables[0].Rows[0]["ServerAddr"].ToString();
				if(ds.Tables[0].Rows[0]["timeout"].ToString()!="")
				{
					model.timeout=int.Parse(ds.Tables[0].Rows[0]["timeout"].ToString());
				}
				model.UserTitle=ds.Tables[0].Rows[0]["UserTitle"].ToString();
				model.Ver=ds.Tables[0].Rows[0]["Ver"].ToString();
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
			strSql.Append("select AppTitle,defaultTempID,ID,port,PromptTitle,ServerAddr,timeout,UserTitle,Ver ");
			strSql.Append(" FROM Settings ");
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
