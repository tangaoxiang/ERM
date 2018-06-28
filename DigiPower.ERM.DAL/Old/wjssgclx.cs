using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类wjssgclx。
	/// </summary>
	public class wjssgclx
	{
		public wjssgclx()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id2)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wjssgclx");
			strSql.Append(" where id2="+id2+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.wjssgclx model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.id != null)
			{
				strSql1.Append("id,");
				strSql2.Append("'"+model.id+"',");
			}
			if (model.id2 != null)
			{
				strSql1.Append("id2,");
				strSql2.Append(""+model.id2+",");
			}
			if (model.ProjectCode != null)
			{
				strSql1.Append("ProjectCode,");
				strSql2.Append("'"+model.ProjectCode+"',");
			}
			if (model.ProjectName != null)
			{
				strSql1.Append("ProjectName,");
				strSql2.Append("'"+model.ProjectName+"',");
			}
			if (model.PTreePath != null)
			{
				strSql1.Append("PTreePath,");
				strSql2.Append("'"+model.PTreePath+"',");
			}
			strSql.Append("insert into wjssgclx(");
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
		public void Update(ERM.MDL.wjssgclx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wjssgclx set ");
			strSql.Append("id='"+model.id+"',");
			strSql.Append("id2="+model.id2+",");
			strSql.Append("ProjectCode='"+model.ProjectCode+"',");
			strSql.Append("ProjectName='"+model.ProjectName+"',");
			strSql.Append("PTreePath='"+model.PTreePath+"'");
			strSql.Append(" where id2="+ model.id2+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id2)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wjssgclx ");
			strSql.Append(" where id2="+id2+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.wjssgclx Find(int id2)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" id,id2,ProjectCode,ProjectName,PTreePath ");
			strSql.Append(" from wjssgclx ");
			strSql.Append(" where id2="+id2+" " );
			ERM.MDL.wjssgclx model=new ERM.MDL.wjssgclx();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.id=ds.Tables[0].Rows[0]["id"].ToString();
				if(ds.Tables[0].Rows[0]["id2"].ToString()!="")
				{
					model.id2=int.Parse(ds.Tables[0].Rows[0]["id2"].ToString());
				}
				model.ProjectCode=ds.Tables[0].Rows[0]["ProjectCode"].ToString();
				model.ProjectName=ds.Tables[0].Rows[0]["ProjectName"].ToString();
				model.PTreePath=ds.Tables[0].Rows[0]["PTreePath"].ToString();
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
			strSql.Append("select id,id2,ProjectCode,ProjectName,PTreePath ");
			strSql.Append(" FROM wjssgclx ");
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
