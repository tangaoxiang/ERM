using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用

namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类PageSize。
	/// </summary>
	public class PageSize
	{
		public PageSize()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PageSize");
			strSql.Append(" where PID="+PID+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.PageSize model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.IsDefault != null)
			{
				strSql1.Append("IsDefault,");
				strSql2.Append(""+model.IsDefault+",");
			}
			if (model.Pages != null)
			{
				strSql1.Append("Pages,");
				strSql2.Append(""+model.Pages+",");
			}
			if (model.Pfloat != null)
			{
				strSql1.Append("Pfloat,");
				strSql2.Append(""+model.Pfloat+",");
			}
			if (model.PID != null)
			{
				strSql1.Append("PID,");
				strSql2.Append(""+model.PID+",");
			}
			if (model.PTYPE != null)
			{
				strSql1.Append("PTYPE,");
				strSql2.Append("'"+model.PTYPE+"',");
			}
			strSql.Append("insert into PageSize(");
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
		public void Update(ERM.MDL.PageSize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PageSize set ");
			strSql.Append("IsDefault="+model.IsDefault+",");
			strSql.Append("Pages="+model.Pages+",");
			strSql.Append("Pfloat="+model.Pfloat+",");
			strSql.Append("PID="+model.PID+",");
			strSql.Append("PTYPE='"+model.PTYPE+"'");
			strSql.Append(" where PID="+ model.PID+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PageSize ");
			strSql.Append(" where PID="+PID+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}

        /// <summary>
        /// 得到插入的最大值
        /// </summary>
        /// <returns></returns>
        public int GetPageSizeMaxId()
        {
            string sql = "select max(PID) from PageSize";
            return DbHelperOleDb.GetSingle(sql) == null ? 0 : (int)DbHelperOleDb.GetSingle(sql);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.PageSize Find(int PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" IsDefault,Pages,Pfloat,PID,PTYPE ");
			strSql.Append(" from PageSize ");
			strSql.Append(" where PID="+PID+" " );
			ERM.MDL.PageSize model=new ERM.MDL.PageSize();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(ds.Tables[0].Rows[0]["IsDefault"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pages"].ToString()!="")
				{
					model.Pages=int.Parse(ds.Tables[0].Rows[0]["Pages"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pfloat"].ToString()!="")
				{
					model.Pfloat=int.Parse(ds.Tables[0].Rows[0]["Pfloat"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PID"].ToString()!="")
				{
					model.PID=int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
				}
				model.PTYPE=ds.Tables[0].Rows[0]["PTYPE"].ToString();
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
			strSql.Append("select IsDefault,Pages,Pfloat,PID,PTYPE ");
			strSql.Append(" FROM PageSize ");
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
