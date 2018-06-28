using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
	/// <summary>
	/// 数据访问类Attachment。
	/// </summary>
	public class Attachment
	{
		public Attachment()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int attachid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Attachment");
			strSql.Append(" where attachid="+attachid+" ");
			return DbHelperOleDb.Exists(strSql.ToString());
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(ERM.MDL.Attachment model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ArchiveID != null)
			{
				strSql1.Append("ArchiveID,");
				strSql2.Append("'"+model.ArchiveID+"',");
			}
			if (model.attachid != null)
			{
				strSql1.Append("attachid,");
				strSql2.Append(""+model.attachid+",");
			}
			if (model.docFormat != null)
			{
				strSql1.Append("docFormat,");
				strSql2.Append("'"+model.docFormat+"',");
			}
			if (model.docType != null)
			{
				strSql1.Append("docType,");
				strSql2.Append("'"+model.docType+"',");
			}
			if (model.DocYs != null)
			{
				strSql1.Append("DocYs,");
				strSql2.Append(""+model.DocYs+",");
			}
			if (model.Draft != null)
			{
				strSql1.Append("Draft,");
				strSql2.Append("'"+model.Draft+"',");
			}
			if (model.ext != null)
			{
				strSql1.Append("ext,");
				strSql2.Append("'"+model.ext+"',");
			}
			if (model.fileID != null)
			{
				strSql1.Append("fileID,");
				strSql2.Append("'"+model.fileID+"',");
			}
			if (model.FileOrderIndex != null)
			{
				strSql1.Append("FileOrderIndex,");
				strSql2.Append(""+model.FileOrderIndex+",");
			}
			if (model.filepath != null)
			{
				strSql1.Append("filepath,");
				strSql2.Append("'"+model.filepath+"',");
			}
			if (model.fileTreePath != null)
			{
				strSql1.Append("fileTreePath,");
				strSql2.Append("'"+model.fileTreePath+"',");
			}
			if (model.OrderIndex2 != null)
			{
				strSql1.Append("OrderIndex2,");
				strSql2.Append(""+model.OrderIndex2+",");
			}
			if (model.OriOpenPro != null)
			{
				strSql1.Append("OriOpenPro,");
				strSql2.Append("'"+model.OriOpenPro+"',");
			}
			if (model.ProjectNO != null)
			{
				strSql1.Append("ProjectNO,");
				strSql2.Append("'"+model.ProjectNO+"',");
			}
			if (model.title != null)
			{
				strSql1.Append("title,");
				strSql2.Append("'"+model.title+"',");
			}
			if (model.wjly != null)
			{
				strSql1.Append("wjly,");
				strSql2.Append("'"+model.wjly+"',");
			}
			if (model.yswjpath != null)
			{
				strSql1.Append("yswjpath,");
				strSql2.Append("'"+model.yswjpath+"',");
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
			strSql.Append("insert into Attachment(");
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
		public void Update(ERM.MDL.Attachment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Attachment set ");
			strSql.Append("ArchiveID='"+model.ArchiveID+"',");
			strSql.Append("attachid="+model.attachid+",");
			strSql.Append("docFormat='"+model.docFormat+"',");
			strSql.Append("docType='"+model.docType+"',");
			strSql.Append("DocYs="+model.DocYs+",");
			strSql.Append("Draft='"+model.Draft+"',");
			strSql.Append("ext='"+model.ext+"',");
			strSql.Append("fileID='"+model.fileID+"',");
			strSql.Append("FileOrderIndex="+model.FileOrderIndex+",");
			strSql.Append("filepath='"+model.filepath+"',");
			strSql.Append("fileTreePath='"+model.fileTreePath+"',");
			strSql.Append("OrderIndex2="+model.OrderIndex2+",");
			strSql.Append("OriOpenPro='"+model.OriOpenPro+"',");
			strSql.Append("ProjectNO='"+model.ProjectNO+"',");
			strSql.Append("title='"+model.title+"',");
			strSql.Append("wjly='"+model.wjly+"',");
			strSql.Append("yswjpath='"+model.yswjpath+"',");
			strSql.Append("zezzzfw='"+model.zezzzfw+"',");
			strSql.Append("zrzbsm='"+model.zrzbsm+"',");
			strSql.Append("zrzlb='"+model.zrzlb+"',");
			strSql.Append("zrzmc='"+model.zrzmc+"'");
			strSql.Append(" where attachid="+ model.attachid+" ");
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int attachid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Attachment ");
			strSql.Append(" where attachid="+attachid+" " );
			DbHelperOleDb.ExecuteSql(strSql.ToString());
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ERM.MDL.Attachment Find(int attachid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  ");
			strSql.Append(" ArchiveID,attachid,docFormat,docType,DocYs,Draft,ext,fileID,FileOrderIndex,filepath,fileTreePath,OrderIndex2,OriOpenPro,ProjectNO,title,wjly,yswjpath,zezzzfw,zrzbsm,zrzlb,zrzmc ");
			strSql.Append(" from Attachment ");
			strSql.Append(" where attachid="+attachid+" " );
			ERM.MDL.Attachment model=new ERM.MDL.Attachment();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ArchiveID=ds.Tables[0].Rows[0]["ArchiveID"].ToString();
				if(ds.Tables[0].Rows[0]["attachid"].ToString()!="")
				{
					model.attachid=int.Parse(ds.Tables[0].Rows[0]["attachid"].ToString());
				}
				model.docFormat=ds.Tables[0].Rows[0]["docFormat"].ToString();
				model.docType=ds.Tables[0].Rows[0]["docType"].ToString();
				if(ds.Tables[0].Rows[0]["DocYs"].ToString()!="")
				{
					model.DocYs=int.Parse(ds.Tables[0].Rows[0]["DocYs"].ToString());
				}
				model.Draft=ds.Tables[0].Rows[0]["Draft"].ToString();
				model.ext=ds.Tables[0].Rows[0]["ext"].ToString();
				model.fileID=ds.Tables[0].Rows[0]["fileID"].ToString();
				if(ds.Tables[0].Rows[0]["FileOrderIndex"].ToString()!="")
				{
					model.FileOrderIndex=int.Parse(ds.Tables[0].Rows[0]["FileOrderIndex"].ToString());
				}
				model.filepath=ds.Tables[0].Rows[0]["filepath"].ToString();
				model.fileTreePath=ds.Tables[0].Rows[0]["fileTreePath"].ToString();
				if(ds.Tables[0].Rows[0]["OrderIndex2"].ToString()!="")
				{
					model.OrderIndex2=int.Parse(ds.Tables[0].Rows[0]["OrderIndex2"].ToString());
				}
				model.OriOpenPro=ds.Tables[0].Rows[0]["OriOpenPro"].ToString();
				model.ProjectNO=ds.Tables[0].Rows[0]["ProjectNO"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.wjly=ds.Tables[0].Rows[0]["wjly"].ToString();
				model.yswjpath=ds.Tables[0].Rows[0]["yswjpath"].ToString();
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
			strSql.Append("select ArchiveID,attachid,docFormat,docType,DocYs,Draft,ext,fileID,FileOrderIndex,filepath,fileTreePath,OrderIndex2,OriOpenPro,ProjectNO,title,wjly,yswjpath,zezzzfw,zrzbsm,zrzlb,zrzmc ");
			strSql.Append(" FROM Attachment ");
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
