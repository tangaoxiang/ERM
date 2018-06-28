using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类T_Archive。
	/// </summary>
	public class T_Archive
	{
		public T_Archive()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ArchiveID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Archive");
			strSql.Append(" where ArchiveID='"+ArchiveID+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.T_Archive model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ajlx != null)
			{
				strSql1.Append("ajlx,");
				strSql2.Append("'"+model.ajlx+"',");
			}
			if (model.ajs != null)
			{
				strSql1.Append("ajs,");
				strSql2.Append("'"+model.ajs+"',");
			}
			if (model.ajtm != null)
			{
				strSql1.Append("ajtm,");
				strSql2.Append("'"+model.ajtm+"',");
			}
			if (model.ArchiveID != null)
			{
				strSql1.Append("ArchiveID,");
				strSql2.Append("'"+model.ArchiveID+"',");
			}
			if (model.bgqx != null)
			{
				strSql1.Append("bgqx,");
				strSql2.Append("'"+model.bgqx+"',");
			}
			if (model.bz != null)
			{
				strSql1.Append("bz,");
				strSql2.Append("'"+model.bz+"',");
			}
			if (model.bzdw != null)
			{
				strSql1.Append("bzdw,");
				strSql2.Append("'"+model.bzdw+"',");
			}
			if (model.bzrq != null)
			{
				strSql1.Append("bzrq,");
				strSql2.Append("'"+model.bzrq+"',");
			}
			if (model.cdh != null)
			{
				strSql1.Append("cdh,");
				strSql2.Append("'"+model.cdh+"',");
			}
			if (model.cpz != null)
			{
				strSql1.Append("cpz,");
				strSql2.Append("'"+model.cpz+"',");
			}
			if (model.dh != null)
			{
				strSql1.Append("dh,");
				strSql2.Append("'"+model.dh+"',");
			}
			if (model.dpz != null)
			{
				strSql1.Append("dpz,");
				strSql2.Append("'"+model.dpz+"',");
			}
			if (model.dtz != null)
			{
				strSql1.Append("dtz,");
				strSql2.Append("'"+model.dtz+"',");
			}
			if (model.dw != null)
			{
				strSql1.Append("dw,");
				strSql2.Append("'"+model.dw+"',");
			}
			if (model.gpz != null)
			{
				strSql1.Append("gpz,");
				strSql2.Append("'"+model.gpz+"',");
			}
			if (model.ljr != null)
			{
				strSql1.Append("ljr,");
				strSql2.Append("'"+model.ljr+"',");
			}
			if (model.lxdh != null)
			{
				strSql1.Append("lxdh,");
				strSql2.Append("'"+model.lxdh+"',");
			}
			if (model.lydh != null)
			{
				strSql1.Append("lydh,");
				strSql2.Append("'"+model.lydh+"',");
			}
			if (model.mj != null)
			{
				strSql1.Append("mj,");
				strSql2.Append("'"+model.mj+"',");
			}
            if (model.OrderIndex != null)
			{
				strSql1.Append("orderindex,");
                strSql2.Append("" + model.OrderIndex + ",");
			}
			if (model.p != null)
			{
				strSql1.Append("p,");
				strSql2.Append("'"+model.p+"',");
			}
			if (model.ProjectNO != null)
			{
				strSql1.Append("ProjectNO,");
				strSql2.Append("'"+model.ProjectNO+"',");
			}
			if (model.qt != null)
			{
				strSql1.Append("qt,");
				strSql2.Append("'"+model.qt+"',");
			}
			if (model.sl != null)
			{
				strSql1.Append("sl,");
				strSql2.Append("'"+model.sl+"',");
			}
			if (model.swp != null)
			{
				strSql1.Append("swp,");
				strSql2.Append("'"+model.swp+"',");
			}
			if (model.tzz != null)
			{
				strSql1.Append("tzz,");
				strSql2.Append("'"+model.tzz+"',");
			}
			if (model.wzz != null)
			{
				strSql1.Append("wzz,");
				strSql2.Append("'"+model.wzz+"',");
			}
			if (model.ysfw != null)
			{
				strSql1.Append("ysfw,");
				strSql2.Append("'"+model.ysfw+"',");
			}
			if (model.z != null)
			{
				strSql1.Append("z,");
				strSql2.Append("'"+model.z+"',");
			}
			if (model.zpz != null)
			{
				strSql1.Append("zpz,");
				strSql2.Append("'"+model.zpz+"',");
			}
            if (model.jhlx != null)
			{
                strSql1.Append("jhlx,");
                strSql2.Append("'" + model.jhlx + "',");
			}
			strSql.Append("insert into T_Archive(");
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
		public void Update(ERM.MDL.T_Archive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Archive set ");
			strSql.Append("ajlx='"+model.ajlx+"',");
			strSql.Append("ajs='"+model.ajs+"',");
			strSql.Append("ajtm='"+model.ajtm+"',");
			strSql.Append("ArchiveID='"+model.ArchiveID+"',");
			strSql.Append("bgqx='"+model.bgqx+"',");
			strSql.Append("bz='"+model.bz+"',");
			strSql.Append("bzdw='"+model.bzdw+"',");
			strSql.Append("bzrq='"+model.bzrq+"',");
			strSql.Append("cdh='"+model.cdh+"',");
			strSql.Append("cpz='"+model.cpz+"',");
			strSql.Append("dh='"+model.dh+"',");
			strSql.Append("dpz='"+model.dpz+"',");
			strSql.Append("dtz='"+model.dtz+"',");
			strSql.Append("dw='"+model.dw+"',");
			strSql.Append("gpz='"+model.gpz+"',");
			strSql.Append("ljr='"+model.ljr+"',");
			strSql.Append("lxdh='"+model.lxdh+"',");
			strSql.Append("lydh='"+model.lydh+"',");
			strSql.Append("mj='"+model.mj+"',");
            strSql.Append("orderindex=" + model.OrderIndex + ",");
			strSql.Append("p='"+model.p+"',");
			strSql.Append("ProjectNO='"+model.ProjectNO+"',");
			strSql.Append("qt='"+model.qt+"',");
			strSql.Append("sl='"+model.sl+"',");
			strSql.Append("swp='"+model.swp+"',");
			strSql.Append("tzz='"+model.tzz+"',");
			strSql.Append("wzz='"+model.wzz+"',");
			strSql.Append("ysfw='"+model.ysfw+"',");
			strSql.Append("z='"+model.z+"',");
            strSql.Append("zpz='" + model.zpz + "',");
            strSql.Append("jhlx='"+model.jhlx+"'");
			strSql.Append(" where ArchiveID='"+ model.ArchiveID+"' ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ArchiveID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Archive ");
			strSql.Append(" where ArchiveID='"+ArchiveID+"' " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.T_Archive Find(string ArchiveID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
            strSql.Append(" ajlx,ajs,ajtm,ArchiveID,bgqx,bz,bzdw,bzrq,cdh,cpz,dh,dpz,dtz,dw,gpz,ljr,lxdh,lydh,mj,orderindex,p,ProjectNO,qt,sl,swp,tzz,wzz,ysfw,z,zpz,jhlx ");
			strSql.Append(" from T_Archive ");
			strSql.Append(" where ArchiveID='"+ArchiveID+"' " );
			ERM.MDL.T_Archive model=new ERM.MDL.T_Archive();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ajlx=ds.Tables[0].Rows[0]["ajlx"].ToString();
				model.ajs=ds.Tables[0].Rows[0]["ajs"].ToString();
				model.ajtm=ds.Tables[0].Rows[0]["ajtm"].ToString();
				model.ArchiveID=ds.Tables[0].Rows[0]["ArchiveID"].ToString();
				model.bgqx=ds.Tables[0].Rows[0]["bgqx"].ToString();
				model.bz=ds.Tables[0].Rows[0]["bz"].ToString();
				model.bzdw=ds.Tables[0].Rows[0]["bzdw"].ToString();
				model.bzrq=ds.Tables[0].Rows[0]["bzrq"].ToString();
				model.cdh=ds.Tables[0].Rows[0]["cdh"].ToString();
				model.cpz=ds.Tables[0].Rows[0]["cpz"].ToString();
				model.dh=ds.Tables[0].Rows[0]["dh"].ToString();
				model.dpz=ds.Tables[0].Rows[0]["dpz"].ToString();
				model.dtz=ds.Tables[0].Rows[0]["dtz"].ToString();
				model.dw=ds.Tables[0].Rows[0]["dw"].ToString();
				model.gpz=ds.Tables[0].Rows[0]["gpz"].ToString();
				model.ljr=ds.Tables[0].Rows[0]["ljr"].ToString();
				model.lxdh=ds.Tables[0].Rows[0]["lxdh"].ToString();
				model.lydh=ds.Tables[0].Rows[0]["lydh"].ToString();
				model.mj=ds.Tables[0].Rows[0]["mj"].ToString();
				if(ds.Tables[0].Rows[0]["orderindex"].ToString()!="")
				{
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
				}
				model.p=ds.Tables[0].Rows[0]["p"].ToString();
				model.ProjectNO=ds.Tables[0].Rows[0]["ProjectNO"].ToString();
				model.qt=ds.Tables[0].Rows[0]["qt"].ToString();
				model.sl=ds.Tables[0].Rows[0]["sl"].ToString();
				model.swp=ds.Tables[0].Rows[0]["swp"].ToString();
				model.tzz=ds.Tables[0].Rows[0]["tzz"].ToString();
				model.wzz=ds.Tables[0].Rows[0]["wzz"].ToString();
				model.ysfw=ds.Tables[0].Rows[0]["ysfw"].ToString();
				model.z=ds.Tables[0].Rows[0]["z"].ToString();
				model.zpz=ds.Tables[0].Rows[0]["zpz"].ToString();
                model.jhlx = ds.Tables[0].Rows[0]["jhlx"].ToString();
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
            strSql.Append("select ajlx,ajs,ajtm,ArchiveID,bgqx,bz,bzdw,bzrq,cdh,cpz,dh,dpz,dtz,dw,gpz,ljr,lxdh,lydh,mj,orderindex,p,ProjectNO,qt,sl,swp,tzz,wzz,ysfw,z,zpz,jhlx ");
			strSql.Append(" FROM T_Archive ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append("  order by  orderindex");
			return DbHelperOleDb.Query(strSql.ToString());
		}
		/*
		*/
	}
}
