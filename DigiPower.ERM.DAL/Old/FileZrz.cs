using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类FileZrz。
	/// </summary>
	public class FileZrz
	{
		public FileZrz()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FileZrz");
			strSql.Append(" where id="+id+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.FileZrz model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.fileid != null)
			{
				strSql1.Append("fileid,");
				strSql2.Append("'"+model.fileid+"',");
			}
			if (model.id != null)
			{
				strSql1.Append("id,");
				strSql2.Append(""+model.id+",");
			}
			if (model.treepath != null)
			{
				strSql1.Append("treepath,");
				strSql2.Append("'"+model.treepath+"',");
			}
			if (model.zezzzfw != null)
			{
				strSql1.Append("zezzzfw,");
				strSql2.Append("'"+model.zezzzfw+"',");
			}
			if (model.zrzbsm != null)
			{
				strSql1.Append("zrzbsm,");
				strSql2.Append("'"+model.zrzbsm+"',");
			}
			if (model.zrzlb != null)
			{
				strSql1.Append("zrzlb,");
				strSql2.Append("'"+model.zrzlb+"',");
			}
			if (model.zrzmc != null)
			{
				strSql1.Append("zrzmc,");
				strSql2.Append("'"+model.zrzmc+"',");
			}
			strSql.Append("insert into FileZrz(");
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
		public void Update(ERM.MDL.FileZrz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FileZrz set ");
			strSql.Append("fileid='"+model.fileid+"',");
			strSql.Append("id="+model.id+",");
			strSql.Append("treepath='"+model.treepath+"',");
			strSql.Append("zezzzfw='"+model.zezzzfw+"',");
			strSql.Append("zrzbsm='"+model.zrzbsm+"',");
			strSql.Append("zrzlb='"+model.zrzlb+"',");
			strSql.Append("zrzmc='"+model.zrzmc+"'");
			strSql.Append(" where id="+ model.id+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FileZrz ");
			strSql.Append(" where id="+id+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.FileZrz Find(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" fileid,id,treepath,zezzzfw,zrzbsm,zrzlb,zrzmc ");
			strSql.Append(" from FileZrz ");
			strSql.Append(" where id="+id+" " );
			ERM.MDL.FileZrz model=new ERM.MDL.FileZrz();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.fileid=ds.Tables[0].Rows[0]["fileid"].ToString();
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.treepath=ds.Tables[0].Rows[0]["treepath"].ToString();
				model.zezzzfw=ds.Tables[0].Rows[0]["zezzzfw"].ToString();
				model.zrzbsm=ds.Tables[0].Rows[0]["zrzbsm"].ToString();
				model.zrzlb=ds.Tables[0].Rows[0]["zrzlb"].ToString();
				model.zrzmc=ds.Tables[0].Rows[0]["zrzmc"].ToString();
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
			strSql.Append("select fileid,id,treepath,zezzzfw,zrzbsm,zrzlb,zrzmc ");
			strSql.Append(" FROM FileZrz ");
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
