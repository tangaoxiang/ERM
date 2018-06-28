using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Users。
	/// </summary>
	public class Users
	{
		public Users()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Users");
			strSql.Append(" where userid="+userid+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.fullname != null)
			{
				strSql1.Append("fullname,");
				strSql2.Append("'"+model.fullname+"',");
			}
			if (model.login != null)
			{
				strSql1.Append("login,");
				strSql2.Append("'"+model.login+"',");
			}
			if (model.password != null)
			{
				strSql1.Append("password,");
				strSql2.Append("'"+model.password+"',");
			}
			if (model.phone != null)
			{
				strSql1.Append("phone,");
				strSql2.Append("'"+model.phone+"',");
			}
			if (model.sh != null)
			{
				strSql1.Append("sh,");
				strSql2.Append(""+model.sh+",");
			}
			if (model.theme != null)
			{
				strSql1.Append("theme,");
				strSql2.Append(""+model.theme+",");
			}
			if (model.title != null)
			{
				strSql1.Append("title,");
				strSql2.Append("'"+model.title+"',");
			}
			if (model.units != null)
			{
				strSql1.Append("units,");
				strSql2.Append("'"+model.units+"',");
			}
			if (model.unitstype != null)
			{
				strSql1.Append("unitstype,");
				strSql2.Append("'"+model.unitstype+"',");
			}
			if (model.userid != null)
			{
				strSql1.Append("userid,");
				strSql2.Append(""+model.userid+",");
			}
			strSql.Append("insert into Users(");
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
		public void Update(ERM.MDL.Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Users set ");
			strSql.Append("fullname='"+model.fullname+"',");
			strSql.Append("login='"+model.login+"',");
			strSql.Append("password='"+model.password+"',");
			strSql.Append("phone='"+model.phone+"',");
			strSql.Append("sh="+model.sh+",");
			strSql.Append("theme="+model.theme+",");
			strSql.Append("title='"+model.title+"',");
			strSql.Append("units='"+model.units+"',");
			strSql.Append("unitstype='"+model.unitstype+"',");
			strSql.Append("userid="+model.userid+"");
			strSql.Append(" where userid="+ model.userid+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Users ");
			strSql.Append(" where userid="+userid+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Users GetModel(int userid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" fullname,login,password,phone,sh,theme,title,units,unitstype,userid ");
			strSql.Append(" from Users ");
			strSql.Append(" where userid="+userid+" " );
			ERM.MDL.Users model=new ERM.MDL.Users();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.fullname=ds.Tables[0].Rows[0]["fullname"].ToString();
				model.login=ds.Tables[0].Rows[0]["login"].ToString();
				model.password=ds.Tables[0].Rows[0]["password"].ToString();
				model.phone=ds.Tables[0].Rows[0]["phone"].ToString();
				if(ds.Tables[0].Rows[0]["sh"].ToString()!="")
				{
					model.sh=int.Parse(ds.Tables[0].Rows[0]["sh"].ToString());
				}
				if(ds.Tables[0].Rows[0]["theme"].ToString()!="")
				{
					model.theme=int.Parse(ds.Tables[0].Rows[0]["theme"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.units=ds.Tables[0].Rows[0]["units"].ToString();
				model.unitstype=ds.Tables[0].Rows[0]["unitstype"].ToString();
				if(ds.Tables[0].Rows[0]["userid"].ToString()!="")
				{
					model.userid=int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
				}
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
			strSql.Append("select fullname,login,password,phone,sh,theme,title,units,unitstype,userid ");
			strSql.Append(" FROM Users ");
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
