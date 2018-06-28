using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
    /// <summary>
    /// 数据访问类ArchiveData。
    /// </summary>
    public class ArchiveData
    {
        public ArchiveData()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ArchiveData");
            strSql.Append(" where id=" + id + " ");
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.ArchiveData model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cellCreatedate != null)
            {
                strSql1.Append("cellCreatedate,");
                strSql2.Append("'" + model.cellCreatedate + "',");
            }
            if (model.cellParentid != null)
            {
                strSql1.Append("cellParentid,");
                strSql2.Append("'" + model.cellParentid + "',");
            }
            if (model.codetype != null)
            {
                strSql1.Append("codetype,");
                strSql2.Append("" + model.codetype + ",");
            }
            if (model.customdefine != null)
            {
                strSql1.Append("customdefine,");
                strSql2.Append("" + model.customdefine + ",");
            }
            if (model.docstatus != null)
            {
                strSql1.Append("docstatus,");
                strSql2.Append("" + model.docstatus + ",");
            }
            if (model.examplepath != null)
            {
                strSql1.Append("examplepath,");
                strSql2.Append("'" + model.examplepath + "',");
            }
            if (model.fbmc != null)
            {
                strSql1.Append("fbmc,");
                strSql2.Append("'" + model.fbmc + "',");
            }
            if (model.filepath != null)
            {
                strSql1.Append("filepath,");
                strSql2.Append("'" + model.filepath + "',");
            }
            if (model.fxmc != null)
            {
                strSql1.Append("fxmc,");
                strSql2.Append("'" + model.fxmc + "',");
            }
            if (model.id != null)
            {
                strSql1.Append("id,");
                strSql2.Append("" + model.id + ",");
            }
            if (model.orderindex != null)
            {
                strSql1.Append("orderindex,");
                strSql2.Append("" + model.orderindex + ",");
            }
            if (model.ProjectNO != null)
            {
                strSql1.Append("ProjectNO,");
                strSql2.Append("'" + model.ProjectNO + "',");
            }
            if (model.ptreepath != null)
            {
                strSql1.Append("ptreepath,");
                strSql2.Append("'" + model.ptreepath + "',");
            }
            if (model.title != null)
            {
                strSql1.Append("title,");
                strSql2.Append("'" + model.title + "',");
            }
            if (model.treepath != null)
            {
                strSql1.Append("treepath,");
                strSql2.Append("'" + model.treepath + "',");
            }
            if (model.ys != null)
            {
                strSql1.Append("ys,");
                strSql2.Append("" + model.ys + ",");
            }
            if (model.zfbmc != null)
            {
                strSql1.Append("zfbmc,");
                strSql2.Append("'" + model.zfbmc + "',");
            }
            if (model.zrr != null)
            {
                strSql1.Append("zrr,");
                strSql2.Append("'" + model.zrr + "',");
            }
            strSql.Append("insert into ArchiveData(");
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
        public void Update(ERM.MDL.ArchiveData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ArchiveData set ");
            strSql.Append("cellCreatedate='" + model.cellCreatedate + "',");
            strSql.Append("cellParentid='" + model.cellParentid + "',");
            strSql.Append("codetype=" + model.codetype + ",");
            strSql.Append("customdefine=" + model.customdefine + ",");
            strSql.Append("docstatus=" + model.docstatus + ",");
            strSql.Append("examplepath='" + model.examplepath + "',");
            strSql.Append("fbmc='" + model.fbmc + "',");
            strSql.Append("filepath='" + model.filepath + "',");
            strSql.Append("fxmc='" + model.fxmc + "',");
            strSql.Append("id=" + model.id + ",");
            strSql.Append("orderindex=" + model.orderindex + ",");
            strSql.Append("ProjectNO='" + model.ProjectNO + "',");
            strSql.Append("ptreepath='" + model.ptreepath + "',");
            strSql.Append("title='" + model.title + "',");
            strSql.Append("treepath='" + model.treepath + "',");
            strSql.Append("ys=" + model.ys + ",");
            strSql.Append("zfbmc='" + model.zfbmc + "',");
            strSql.Append("zrr='" + model.zrr + "'");
            strSql.Append(" where id=" + model.id + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ArchiveData ");
            strSql.Append(" where id=" + id + " ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.ArchiveData Find(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" cellCreatedate,cellParentid,codetype,customdefine,docstatus,examplepath,fbmc,filepath,fxmc,id,orderindex,ProjectNO,ptreepath,title,treepath,ys,zfbmc,zrr ");
            strSql.Append(" from ArchiveData ");
            strSql.Append(" where id=" + id + " ");
            ERM.MDL.ArchiveData model = new ERM.MDL.ArchiveData();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.cellCreatedate = ds.Tables[0].Rows[0]["cellCreatedate"].ToString();
                model.cellParentid = ds.Tables[0].Rows[0]["cellParentid"].ToString();
                if (ds.Tables[0].Rows[0]["codetype"].ToString() != "")
                {
                    model.codetype = int.Parse(ds.Tables[0].Rows[0]["codetype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["customdefine"].ToString() != "")
                {
                    model.customdefine = int.Parse(ds.Tables[0].Rows[0]["customdefine"].ToString());
                }
                if (ds.Tables[0].Rows[0]["docstatus"].ToString() != "")
                {
                    model.docstatus = int.Parse(ds.Tables[0].Rows[0]["docstatus"].ToString());
                }
                model.examplepath = ds.Tables[0].Rows[0]["examplepath"].ToString();
                model.fbmc = ds.Tables[0].Rows[0]["fbmc"].ToString();
                model.filepath = ds.Tables[0].Rows[0]["filepath"].ToString();
                model.fxmc = ds.Tables[0].Rows[0]["fxmc"].ToString();
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderindex"].ToString() != "")
                {
                    model.orderindex = int.Parse(ds.Tables[0].Rows[0]["orderindex"].ToString());
                }
                model.ProjectNO = ds.Tables[0].Rows[0]["ProjectNO"].ToString();
                model.ptreepath = ds.Tables[0].Rows[0]["ptreepath"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.treepath = ds.Tables[0].Rows[0]["treepath"].ToString();
                if (ds.Tables[0].Rows[0]["ys"].ToString() != "")
                {
                    model.ys = int.Parse(ds.Tables[0].Rows[0]["ys"].ToString());
                }
                model.zfbmc = ds.Tables[0].Rows[0]["zfbmc"].ToString();
                model.zrr = ds.Tables[0].Rows[0]["zrr"].ToString();
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
        public DataSet GetList22(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select cellCreatedate,cellParentid,codetype,customdefine,docstatus,examplepath,fbmc,filepath,fxmc,id,orderindex,ProjectNO,ptreepath,title,treepath,ys,zfbmc,zrr ");
            strSql.Append(" FROM ArchiveData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }
        /*
        */
    }
}
