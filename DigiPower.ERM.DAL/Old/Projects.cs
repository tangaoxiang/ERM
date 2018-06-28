using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
    /*
     * 数据字段begindate enddate bjdate createdate四个字段datetime操作有改动
     */
	/// <summary>
	/// 数据访问类Projects。
	/// </summary>
	public class Projects
	{
		public Projects()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string projectno)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Projects");
			strSql.Append(" where projectno='"+projectno+"' ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.T_Projects model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.address != null)
			{
				strSql1.Append("address,");
				strSql2.Append("'"+model.address+"',");
			}
			if (model.area1 != null)
			{
				strSql1.Append("area1,");
				strSql2.Append(""+model.area1+",");
			}
			if (model.area2 != null)
			{
				strSql1.Append("area2,");
				strSql2.Append(""+model.area2+",");
			}
			if (model.begindate != null)
			{
				strSql1.Append("begindate,");
				strSql2.Append("'"+model.begindate+"',");
			}
			if (model.bgyfmj != null)
			{
				strSql1.Append("bgyfmj,");
				strSql2.Append("'"+model.bgyfmj+"',");
			}
			if (model.bjdate != null)
			{
				strSql1.Append("bjdate,");
				strSql2.Append("'"+model.bjdate+"',");
			}
			if (model.category != null)
			{
				strSql1.Append("category,");
				strSql2.Append("'"+model.category+"',");
			}
			if (model.cfmj != null)
			{
				strSql1.Append("cfmj,");
				strSql2.Append("'"+model.cfmj+"',");
			}
			if (model.createdate != null)
			{
				strSql1.Append("createdate,");
				strSql2.Append("'"+model.createdate+"',");
			}
			if (model.district != null)
			{
				strSql1.Append("district,");
				strSql2.Append("'"+model.district+"',");
			}
			if (model.dxsmj != null)
			{
				strSql1.Append("dxsmj,");
				strSql2.Append("'"+model.dxsmj+"',");
			}
			if (model.enddate != null)
			{
				strSql1.Append("enddate,");
				strSql2.Append("'"+model.enddate+"',");
			}
			if (model.floors1 != null)
			{
				strSql1.Append("floors1,");
				strSql2.Append(""+model.floors1+",");
			}
			if (model.floors2 != null)
			{
				strSql1.Append("floors2,");
				strSql2.Append(""+model.floors2+",");
			}
			if (model.ghcode != null)
			{
				strSql1.Append("ghcode,");
				strSql2.Append("'"+model.ghcode+"',");
			}
			if (model.high != null)
			{
				strSql1.Append("high,");
				strSql2.Append(""+model.high+",");
			}
			if (model.hjqk != null)
			{
				strSql1.Append("hjqk,");
				strSql2.Append("'"+model.hjqk+"',");
			}
			if (model.jldwshr != null)
			{
				strSql1.Append("jldwshr,");
				strSql2.Append("'"+model.jldwshr+"',");
			}
			if (model.jsdwshr != null)
			{
				strSql1.Append("jsdwshr,");
				strSql2.Append("'"+model.jsdwshr+"',");
			}
			if (model.passwd != null)
			{
				strSql1.Append("passwd,");
				strSql2.Append("'"+model.passwd+"',");
			}
			if (model.price1 != null)
			{
				strSql1.Append("price1,");
				strSql2.Append(""+model.price1+",");
			}
			if (model.price2 != null)
			{
				strSql1.Append("price2,");
				strSql2.Append(""+model.price2+",");
			}
			if (model.projectname != null)
			{
				strSql1.Append("projectname,");
				strSql2.Append("'"+model.projectname+"',");
			}
			if (model.projectno != null)
			{
				strSql1.Append("projectno,");
				strSql2.Append("'"+model.projectno+"',");
			}
			if (model.projecttype != null)
			{
				strSql1.Append("projecttype,");
				strSql2.Append("'"+model.projecttype+"',");
			}
			if (model.qtyfmj != null)
			{
				strSql1.Append("qtyfmj,");
				strSql2.Append("'"+model.qtyfmj+"',");
			}
			if (model.sgbzz != null)
			{
				strSql1.Append("sgbzz,");
				strSql2.Append("'"+model.sgbzz+"',");
			}
			if (model.sgcode != null)
			{
				strSql1.Append("sgcode,");
				strSql2.Append("'"+model.sgcode+"',");
			}
			if (model.stru != null)
			{
				strSql1.Append("stru,");
				strSql2.Append("'"+model.stru+"',");
			}
			if (model.syyfmj != null)
			{
				strSql1.Append("syyfmj,");
				strSql2.Append("'"+model.syyfmj+"',");
			}
			if (model.tbr != null)
			{
				strSql1.Append("tbr,");
				strSql2.Append("'"+model.tbr+"',");
			}
			if (model.tempid != null)
			{
				strSql1.Append("tempid,");
				strSql2.Append(""+model.tempid+",");
			}
			if (model.ts1 != null)
			{
				strSql1.Append("ts1,");
				strSql2.Append("'"+model.ts1+"',");
			}
			if (model.ts2 != null)
			{
				strSql1.Append("ts2,");
				strSql2.Append("'"+model.ts2+"',");
			}
			if (model.ts3 != null)
			{
				strSql1.Append("ts3,");
				strSql2.Append("'"+model.ts3+"',");
			}
			if (model.ts4 != null)
			{
				strSql1.Append("ts4,");
				strSql2.Append("'"+model.ts4+"',");
			}
			if (model.tstotal != null)
			{
				strSql1.Append("tstotal,");
				strSql2.Append("'"+model.tstotal+"',");
			}
			if (model.ydpzcode != null)
			{
				strSql1.Append("ydpzcode,");
				strSql2.Append("'"+model.ydpzcode+"',");
			}
			if (model.ydxkcode != null)
			{
				strSql1.Append("ydxkcode,");
				strSql2.Append("'"+model.ydxkcode+"',");
			}
			if (model.zjy != null)
			{
				strSql1.Append("zjy,");
				strSql2.Append("'"+model.zjy+"',");
			}
			if (model.zygz != null)
			{
				strSql1.Append("zygz,");
				strSql2.Append("'"+model.zygz+"',");
			}
			if (model.zzmj != null)
			{
				strSql1.Append("zzmj,");
				strSql2.Append("'"+model.zzmj+"',");
			}
			strSql.Append("insert into Projects(");
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
		public void Update(ERM.MDL.T_Projects model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Projects set ");
			strSql.Append("address='"+model.address+"',");
			strSql.Append("area1="+model.area1+",");
			strSql.Append("area2="+model.area2+",");
            strSql.Append("begindate='" + model.begindate.ToString("yyyy-MM-dd") + "',");
			strSql.Append("bgyfmj='"+model.bgyfmj+"',");
            strSql.Append("bjdate='" + model.bjdate.ToString("yyyy-MM-dd") + "',");
			strSql.Append("category='"+model.category+"',");
			strSql.Append("cfmj='"+model.cfmj+"',");
            strSql.Append("createdate='" + model.createdate.ToString("yyyy-MM-dd") + "',");
			strSql.Append("district='"+model.district+"',");
			strSql.Append("dxsmj='"+model.dxsmj+"',");
            strSql.Append("enddate='" + model.enddate.ToString("yyyy-MM-dd") + "',");
			strSql.Append("floors1="+model.floors1+",");
			strSql.Append("floors2="+model.floors2+",");
			strSql.Append("ghcode='"+model.ghcode+"',");
			strSql.Append("high="+model.high+",");
			strSql.Append("hjqk='"+model.hjqk+"',");
			strSql.Append("jldwshr='"+model.jldwshr+"',");
			strSql.Append("jsdwshr='"+model.jsdwshr+"',");
			strSql.Append("passwd='"+model.passwd+"',");
			strSql.Append("price1="+model.price1+",");
			strSql.Append("price2="+model.price2+",");
			strSql.Append("projectname='"+model.projectname+"',");
			strSql.Append("projectno='"+model.projectno+"',");
			strSql.Append("projecttype='"+model.projecttype+"',");
			strSql.Append("qtyfmj='"+model.qtyfmj+"',");
			strSql.Append("sgbzz='"+model.sgbzz+"',");
			strSql.Append("sgcode='"+model.sgcode+"',");
			strSql.Append("stru='"+model.stru+"',");
			strSql.Append("syyfmj='"+model.syyfmj+"',");
			strSql.Append("tbr='"+model.tbr+"',");
			strSql.Append("tempid="+model.tempid+",");
			strSql.Append("ts1='"+model.ts1+"',");
			strSql.Append("ts2='"+model.ts2+"',");
			strSql.Append("ts3='"+model.ts3+"',");
			strSql.Append("ts4='"+model.ts4+"',");
			strSql.Append("tstotal='"+model.tstotal+"',");
			strSql.Append("ydpzcode='"+model.ydpzcode+"',");
			strSql.Append("ydxkcode='"+model.ydxkcode+"',");
			strSql.Append("zjy='"+model.zjy+"',");
			strSql.Append("zygz='"+model.zygz+"',");
			strSql.Append("zzmj='"+model.zzmj+"'");            
			strSql.Append(" where projectno='"+ model.projectno+"' ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string projectno)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Projects ");
			strSql.Append(" where projectno='"+projectno+"' " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.T_Projects GetModel(string projectno)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" address,area1,area2,begindate,bgyfmj,bjdate,category,cfmj,createdate,district,dxsmj,enddate,floors1,floors2,ghcode,high,hjqk,jldwshr,jsdwshr,passwd,price1,price2,projectname,projectno,projecttype,qtyfmj,sgbzz,sgcode,stru,syyfmj,tbr,tempid,ts1,ts2,ts3,ts4,tstotal,ydpzcode,ydxkcode,zjy,zygz,zzmj ");
			strSql.Append(" from Projects ");
			strSql.Append(" where projectno='"+projectno+"' " );
			ERM.MDL.T_Projects model=new ERM.MDL.T_Projects();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.address=ds.Tables[0].Rows[0]["address"].ToString();
				if(ds.Tables[0].Rows[0]["area1"].ToString()!="")
				{
					model.area1=decimal.Parse(ds.Tables[0].Rows[0]["area1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["area2"].ToString()!="")
				{
					model.area2=decimal.Parse(ds.Tables[0].Rows[0]["area2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["begindate"].ToString()!="")
				{
					model.begindate= Convert.ToDateTime(ds.Tables[0].Rows[0]["begindate"]);
				}
				model.bgyfmj=ds.Tables[0].Rows[0]["bgyfmj"].ToString();
				if(ds.Tables[0].Rows[0]["bjdate"].ToString()!="")
				{
					model.bjdate=Convert.ToDateTime(ds.Tables[0].Rows[0]["bjdate"]);
				}
				model.category=ds.Tables[0].Rows[0]["category"].ToString();
				model.cfmj=ds.Tables[0].Rows[0]["cfmj"].ToString();
				if(ds.Tables[0].Rows[0]["createdate"].ToString()!="")
				{
					model.createdate=Convert.ToDateTime(ds.Tables[0].Rows[0]["createdate"]);
				}
				model.district=ds.Tables[0].Rows[0]["district"].ToString();
				model.dxsmj=ds.Tables[0].Rows[0]["dxsmj"].ToString();
				if(ds.Tables[0].Rows[0]["enddate"].ToString()!="")
				{
                    model.enddate = Convert.ToDateTime(ds.Tables[0].Rows[0]["enddate"]);
				}
				if(ds.Tables[0].Rows[0]["floors1"].ToString()!="")
				{
					model.floors1=int.Parse(ds.Tables[0].Rows[0]["floors1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["floors2"].ToString()!="")
				{
					model.floors2=int.Parse(ds.Tables[0].Rows[0]["floors2"].ToString());
				}
				model.ghcode=ds.Tables[0].Rows[0]["ghcode"].ToString();
				if(ds.Tables[0].Rows[0]["high"].ToString()!="")
				{
					model.high=decimal.Parse(ds.Tables[0].Rows[0]["high"].ToString());
				}
				model.hjqk=ds.Tables[0].Rows[0]["hjqk"].ToString();
				model.jldwshr=ds.Tables[0].Rows[0]["jldwshr"].ToString();
				model.jsdwshr=ds.Tables[0].Rows[0]["jsdwshr"].ToString();
				model.passwd=ds.Tables[0].Rows[0]["passwd"].ToString();
				if(ds.Tables[0].Rows[0]["price1"].ToString()!="")
				{
					model.price1=decimal.Parse(ds.Tables[0].Rows[0]["price1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["price2"].ToString()!="")
				{
					model.price2=decimal.Parse(ds.Tables[0].Rows[0]["price2"].ToString());
				}
				model.projectname=ds.Tables[0].Rows[0]["projectname"].ToString();
				model.projectno=ds.Tables[0].Rows[0]["projectno"].ToString();
				model.projecttype=ds.Tables[0].Rows[0]["projecttype"].ToString();
				model.qtyfmj=ds.Tables[0].Rows[0]["qtyfmj"].ToString();
				model.sgbzz=ds.Tables[0].Rows[0]["sgbzz"].ToString();
				model.sgcode=ds.Tables[0].Rows[0]["sgcode"].ToString();
				model.stru=ds.Tables[0].Rows[0]["stru"].ToString();
				model.syyfmj=ds.Tables[0].Rows[0]["syyfmj"].ToString();
				model.tbr=ds.Tables[0].Rows[0]["tbr"].ToString();
				if(ds.Tables[0].Rows[0]["tempid"].ToString()!="")
				{
					model.tempid=int.Parse(ds.Tables[0].Rows[0]["tempid"].ToString());
				}
				model.ts1=ds.Tables[0].Rows[0]["ts1"].ToString();
				model.ts2=ds.Tables[0].Rows[0]["ts2"].ToString();
				model.ts3=ds.Tables[0].Rows[0]["ts3"].ToString();
				model.ts4=ds.Tables[0].Rows[0]["ts4"].ToString();
				model.tstotal=ds.Tables[0].Rows[0]["tstotal"].ToString();
				model.ydpzcode=ds.Tables[0].Rows[0]["ydpzcode"].ToString();
				model.ydxkcode=ds.Tables[0].Rows[0]["ydxkcode"].ToString();
				model.zjy=ds.Tables[0].Rows[0]["zjy"].ToString();
				model.zygz=ds.Tables[0].Rows[0]["zygz"].ToString();
				model.zzmj=ds.Tables[0].Rows[0]["zzmj"].ToString();
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
            strSql.Append("select address,area1,area2,begindate,bgyfmj,bjdate,category,cfmj,createdate,district,dxsmj,enddate,floors1,floors2,ghcode,high,hjqk,jldwshr,jsdwshr,passwd,price1,price2,projectname,projectno,projecttype,qtyfmj,sgbzz,sgcode,stru,syyfmj,tbr,tempid,ts1,ts2,ts3,ts4,tstotal,ydpzcode,ydxkcode,zjy,zygz,zzmj ");
            strSql.Append(" FROM Projects ");
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
