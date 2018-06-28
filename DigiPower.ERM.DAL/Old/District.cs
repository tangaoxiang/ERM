using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类District。
	/// </summary>
	public class District
	{
		public District()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DistrictID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from District");
			strSql.Append(" where DistrictID="+DistrictID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.District model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.DistrictName != null)
			{
                strSql1.Append("DistrictName,");
				strSql2.Append("'"+model.DistrictName+"',");
			}
			if (model.DistrictID != null)
			{
				strSql1.Append("DistrictID,");
				strSql2.Append(""+model.DistrictID+",");
			}
			if (model.OrderIndex != null)
			{
				strSql1.Append("OrderIndex,");
				strSql2.Append(""+model.OrderIndex+",");
			}
			if (model.TempID != null)
			{
				strSql1.Append("TempID,");
				strSql2.Append(""+model.TempID+",");
			}
			strSql.Append("insert into District(");
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
		public void Update(ERM.MDL.District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update District set ");
            strSql.Append("DistrictName='" + model.DistrictName + "',");
			strSql.Append("DistrictID="+model.DistrictID+",");
			strSql.Append("OrderIndex="+model.OrderIndex+",");
			strSql.Append("TempID="+model.TempID+"");
			strSql.Append(" where DistrictID="+ model.DistrictID+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int DistrictID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from District ");
			strSql.Append(" where DistrictID="+DistrictID+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.District Find(int DistrictID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
            strSql.Append(" DistrictID,DistrictName,OrderIndex,TempID ");
			strSql.Append(" from District ");
			strSql.Append(" where DistrictID="+DistrictID+" " );
			ERM.MDL.District model=new ERM.MDL.District();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
                model.DistrictName = ds.Tables[0].Rows[0]["DistrictName"].ToString();
				if(ds.Tables[0].Rows[0]["DistrictID"].ToString()!="")
				{
					model.DistrictID=int.Parse(ds.Tables[0].Rows[0]["DistrictID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderIndex"].ToString()!="")
				{
					model.OrderIndex=int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TempID"].ToString()!="")
				{
					model.TempID=int.Parse(ds.Tables[0].Rows[0]["TempID"].ToString());
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
            strSql.Append("select DistrictName,DistrictID,OrderIndex,TempID ");
			strSql.Append(" FROM District ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere);
			}

            strSql.Append("  order by OrderIndex asc");
			return DbHelperOleDb.Query(strSql.ToString());
		}
		/*
		*/
	}
}
