using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Units。
	/// </summary>
	public class Units
	{
		public Units()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string unitid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Units");
			strSql.Append(" where unitid='"+unitid+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.T_Units model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.addr != null)
			{
				strSql1.Append("addr,");
				strSql2.Append("'"+model.addr+"',");
			}
			if (model.dwmc != null)
			{
				strSql1.Append("dwmc,");
				strSql2.Append("'"+model.dwmc+"',");
			}
			if (model.fax != null)
			{
				strSql1.Append("fax,");
				strSql2.Append("'"+model.fax+"',");
			}
			if (model.fzr != null)
			{
				strSql1.Append("fzr,");
				strSql2.Append("'"+model.fzr+"',");
			}
			if (model.fzrzs != null)
			{
				strSql1.Append("fzrzs,");
				strSql2.Append("'"+model.fzrzs+"',");
			}
			if (model.projectno != null)
			{
				strSql1.Append("projectno,");
				strSql2.Append("'"+model.projectno+"',");
			}
			if (model.remark != null)
			{
				strSql1.Append("remark,");
				strSql2.Append("'"+model.remark+"',");
			}
			if (model.tel != null)
			{
				strSql1.Append("tel,");
				strSql2.Append("'"+model.tel+"',");
			}
			if (model.unitid != null)
			{
				strSql1.Append("unitid,");
				strSql2.Append("'"+model.unitid+"',");
			}
			if (model.unittype != null)
			{
				strSql1.Append("unittype,");
				strSql2.Append("'"+model.unittype+"',");
			}
			if (model.xmjl != null)
			{
				strSql1.Append("xmjl,");
				strSql2.Append("'"+model.xmjl+"',");
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
			if (model.zrzzzfw != null)
			{
				strSql1.Append("zrzzzfw,");
				strSql2.Append("'"+model.zrzzzfw+"',");
			}
			if (model.zzdj != null)
			{
				strSql1.Append("zzdj,");
				strSql2.Append("'"+model.zzdj+"',");
			}
			if (model.zzzh != null)
			{
				strSql1.Append("zzzh,");
				strSql2.Append("'"+model.zzzh+"',");
			}
			strSql.Append("insert into Units(");
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
		public void Update(ERM.MDL.T_Units model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Units set ");
			strSql.Append("addr='"+model.addr+"',");
			strSql.Append("dwmc='"+model.dwmc+"',");
			strSql.Append("fax='"+model.fax+"',");
			strSql.Append("fzr='"+model.fzr+"',");
			strSql.Append("fzrzs='"+model.fzrzs+"',");
			strSql.Append("projectno='"+model.projectno+"',");
			strSql.Append("remark='"+model.remark+"',");
			strSql.Append("tel='"+model.tel+"',");
			strSql.Append("unitid='"+model.unitid+"',");
			strSql.Append("unittype='"+model.unittype+"',");
			strSql.Append("xmjl='"+model.xmjl+"',");
			strSql.Append("zrzbsm='"+model.zrzbsm+"',");
			strSql.Append("zrzlb='"+model.zrzlb+"',");
			strSql.Append("zrzmc='"+model.zrzmc+"',");
			strSql.Append("zrzzzfw='"+model.zrzzzfw+"',");
			strSql.Append("zzdj='"+model.zzdj+"',");
			strSql.Append("zzzh='"+model.zzzh+"'");
			strSql.Append(" where unitid='"+ model.unitid+"' ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string unitid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Units ");
			strSql.Append(" where unitid='"+unitid+"' " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.T_Units GetModel(string unitid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" addr,dwmc,fax,fzr,fzrzs,projectno,remark,tel,unitid,unittype,xmjl,zrzbsm,zrzlb,zrzmc,zrzzzfw,zzdj,zzzh ");
			strSql.Append(" from Units ");
			strSql.Append(" where unitid='"+unitid+"' " );
			ERM.MDL.T_Units model=new ERM.MDL.T_Units();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.addr=ds.Tables[0].Rows[0]["addr"].ToString();
				model.dwmc=ds.Tables[0].Rows[0]["dwmc"].ToString();
				model.fax=ds.Tables[0].Rows[0]["fax"].ToString();
				model.fzr=ds.Tables[0].Rows[0]["fzr"].ToString();
				model.fzrzs=ds.Tables[0].Rows[0]["fzrzs"].ToString();
				model.projectno=ds.Tables[0].Rows[0]["projectno"].ToString();
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				model.tel=ds.Tables[0].Rows[0]["tel"].ToString();
				model.unitid=ds.Tables[0].Rows[0]["unitid"].ToString();
				model.unittype=ds.Tables[0].Rows[0]["unittype"].ToString();
				model.xmjl=ds.Tables[0].Rows[0]["xmjl"].ToString();
				model.zrzbsm=ds.Tables[0].Rows[0]["zrzbsm"].ToString();
				model.zrzlb=ds.Tables[0].Rows[0]["zrzlb"].ToString();
				model.zrzmc=ds.Tables[0].Rows[0]["zrzmc"].ToString();
				model.zrzzzfw=ds.Tables[0].Rows[0]["zrzzzfw"].ToString();
				model.zzdj=ds.Tables[0].Rows[0]["zzdj"].ToString();
				model.zzzh=ds.Tables[0].Rows[0]["zzzh"].ToString();
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
			strSql.Append("select addr,dwmc,fax,fzr,fzrzs,projectno,remark,tel,unitid,unittype,xmjl,zrzbsm,zrzlb,zrzmc,zrzzzfw,zzdj,zzzh ");
			strSql.Append(" FROM Units ");
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
