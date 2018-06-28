using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类ArchiveTemps。
	/// </summary>
	public class ArchiveTemps
	{
		public ArchiveTemps()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int tempid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ArchiveTemps");
			strSql.Append(" where tempid="+tempid+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.ArchiveTemps model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.Cell_Templet_Name != null)
			{
				strSql1.Append("Cell_Templet_Name,");
				strSql2.Append("'"+model.Cell_Templet_Name+"',");
			}
			if (model.Cell_Templet_Table != null)
			{
				strSql1.Append("Cell_Templet_Table,");
				strSql2.Append("'"+model.Cell_Templet_Table+"',");
			}
			if (model.fileRecording_Templet_Table != null)
			{
				strSql1.Append("fileRecording_Templet_Table,");
				strSql2.Append("'"+model.fileRecording_Templet_Table+"',");
			}
			if (model.isDefault != null)
			{
				strSql1.Append("isDefault,");
				strSql2.Append(""+model.isDefault+",");
			}
			if (model.orderindex != null)
			{
				strSql1.Append("orderindex,");
				strSql2.Append(""+model.orderindex+",");
			}
			if (model.Recording_Templet_Name != null)
			{
				strSql1.Append("Recording_Templet_Name,");
				strSql2.Append("'"+model.Recording_Templet_Name+"',");
			}
			if (model.tempid != null)
			{
				strSql1.Append("tempid,");
				strSql2.Append(""+model.tempid+",");
			}
			if (model.UserTitle != null)
			{
				strSql1.Append("UserTitle,");
				strSql2.Append("'"+model.UserTitle+"',");
			}
			if (model.visible != null)
			{
				strSql1.Append("visible,");
				strSql2.Append(""+model.visible+",");
			}
			strSql.Append("insert into ArchiveTemps(");
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
		public void Update(ERM.MDL.ArchiveTemps model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ArchiveTemps set ");
			strSql.Append("Cell_Templet_Name='"+model.Cell_Templet_Name+"',");
			strSql.Append("Cell_Templet_Table='"+model.Cell_Templet_Table+"',");
			strSql.Append("fileRecording_Templet_Table='"+model.fileRecording_Templet_Table+"',");
			strSql.Append("isDefault="+model.isDefault+",");
			strSql.Append("orderindex="+model.orderindex+",");
			strSql.Append("Recording_Templet_Name='"+model.Recording_Templet_Name+"',");
			strSql.Append("tempid="+model.tempid+",");
			strSql.Append("UserTitle='"+model.UserTitle+"',");
			strSql.Append("visible="+model.visible+"");
			strSql.Append(" where tempid="+ model.tempid+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int tempid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ArchiveTemps ");
			strSql.Append(" where tempid="+tempid+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.ArchiveTemps Find(int tempid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" Cell_Templet_Name,Cell_Templet_Table,fileRecording_Templet_Table,isDefault,orderindex,Recording_Templet_Name,tempid,UserTitle,visible ");
			strSql.Append(" from ArchiveTemps ");
			strSql.Append(" where tempid="+tempid+" " );
			ERM.MDL.ArchiveTemps model=new ERM.MDL.ArchiveTemps();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.Cell_Templet_Name=ds.Tables[0].Rows[0]["Cell_Templet_Name"].ToString();
				model.Cell_Templet_Table=ds.Tables[0].Rows[0]["Cell_Templet_Table"].ToString();
				model.fileRecording_Templet_Table=ds.Tables[0].Rows[0]["fileRecording_Templet_Table"].ToString();
				if(ds.Tables[0].Rows[0]["isDefault"].ToString()!="")
				{
					model.isDefault=int.Parse(ds.Tables[0].Rows[0]["isDefault"].ToString());
				}
				if(ds.Tables[0].Rows[0]["orderindex"].ToString()!="")
				{
					model.orderindex=int.Parse(ds.Tables[0].Rows[0]["orderindex"].ToString());
				}
				model.Recording_Templet_Name=ds.Tables[0].Rows[0]["Recording_Templet_Name"].ToString();
				if(ds.Tables[0].Rows[0]["tempid"].ToString()!="")
				{
					model.tempid=int.Parse(ds.Tables[0].Rows[0]["tempid"].ToString());
				}
				model.UserTitle=ds.Tables[0].Rows[0]["UserTitle"].ToString();
				if(ds.Tables[0].Rows[0]["visible"].ToString()!="")
				{
					model.visible=int.Parse(ds.Tables[0].Rows[0]["visible"].ToString());
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
			strSql.Append("select Cell_Templet_Name,Cell_Templet_Table,fileRecording_Templet_Table,isDefault,orderindex,Recording_Templet_Name,tempid,UserTitle,visible ");
			strSql.Append(" FROM ArchiveTemps ");
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
