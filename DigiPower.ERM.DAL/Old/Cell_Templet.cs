using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
    /// <summary>
    /// 数据访问类Cell_Templet。
    /// </summary>
    public class Cell_Templet
    {
        public Cell_Templet()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id, string ProjectNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cell_Templet");
            strSql.Append(" where id='" + id + "' and ProjectNO='" + ProjectNO + "' ");
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.T_CellFile model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.codeno != null)
            {
                strSql1.Append("codeno,");
                strSql2.Append("'" + model.codeno + "',");
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
                strSql2.Append("'" + model.id + "',");
            }
            if (model.isvisible != null)
            {
                strSql1.Append("isvisible,");
                strSql2.Append("" + model.isvisible + ",");
            }
            if (model.orderindex != null)
            {
                strSql1.Append("orderindex,");
                strSql2.Append("" + model.orderindex + ",");
            }
            if (model.parentid != null)
            {
                strSql1.Append("parentid,");
                strSql2.Append("'" + model.parentid + "',");
            }
            if (model.ProjectNO != null)
            {
                strSql1.Append("ProjectNO,");
                strSql2.Append("'" + model.ProjectNO + "',");
            }
            if (model.PTreePath != null)
            {
                strSql1.Append("PTreePath,");
                strSql2.Append("'" + model.PTreePath + "',");
            }
            if (model.title != null)
            {
                strSql1.Append("title,");
                strSql2.Append("'" + model.title + "',");
            }
            if (model.TreePath != null)
            {
                strSql1.Append("TreePath,");
                strSql2.Append("'" + model.TreePath + "',");
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
            strSql.Append("insert into Cell_Templet(");
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
        public void Update(ERM.MDL.T_CellFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cell_Templet set ");
            strSql.Append("codeno='" + model.codeno + "',");
            strSql.Append("codetype=" + model.codetype + ",");
            strSql.Append("customdefine=" + model.customdefine + ",");
            strSql.Append("examplepath='" + model.examplepath + "',");
            strSql.Append("fbmc='" + model.fbmc + "',");
            strSql.Append("filepath='" + model.filepath + "',");
            strSql.Append("fxmc='" + model.fxmc + "',");
            strSql.Append("id='" + model.id + "',");
            strSql.Append("isvisible=" + model.isvisible + ",");
            strSql.Append("orderindex=" + model.orderindex + ",");
            strSql.Append("parentid='" + model.parentid + "',");
            strSql.Append("ProjectNO='" + model.ProjectNO + "',");
            strSql.Append("PTreePath='" + model.PTreePath + "',");
            strSql.Append("title='" + model.title + "',");
            strSql.Append("TreePath='" + model.TreePath + "',");
            strSql.Append("ys=" + model.ys + ",");
            strSql.Append("zfbmc='" + model.zfbmc + "',");
            strSql.Append("zrr='" + model.zrr + "'");
            strSql.Append(" where id='" + model.id + "' and ProjectNO='" + model.ProjectNO + "' ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string id, string ProjectNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cell_Templet ");
            strSql.Append(" where id='" + id + "' and ProjectNO='" + ProjectNO + "' ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.T_CellFile Find(string id, string ProjectNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" codeno,codetype,customdefine,examplepath,fbmc,filepath,fxmc,id,isvisible,orderindex,parentid,ProjectNO,PTreePath,title,TreePath,ys,zfbmc,zrr ");
            strSql.Append(" from Cell_Templet ");
            strSql.Append(" where id='" + id + "' and ProjectNO='" + ProjectNO + "' ");
            ERM.MDL.T_CellFile model = new ERM.MDL.T_CellFile();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.codeno = ds.Tables[0].Rows[0]["codeno"].ToString();
                if (ds.Tables[0].Rows[0]["codetype"].ToString() != "")
                {
                    model.codetype = int.Parse(ds.Tables[0].Rows[0]["codetype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["customdefine"].ToString() != "")
                {
                    model.customdefine = int.Parse(ds.Tables[0].Rows[0]["customdefine"].ToString());
                }
                model.examplepath = ds.Tables[0].Rows[0]["examplepath"].ToString();
                model.fbmc = ds.Tables[0].Rows[0]["fbmc"].ToString();
                model.filepath = ds.Tables[0].Rows[0]["filepath"].ToString();
                model.fxmc = ds.Tables[0].Rows[0]["fxmc"].ToString();
                model.id = ds.Tables[0].Rows[0]["id"].ToString();
                if (ds.Tables[0].Rows[0]["isvisible"].ToString() != "")
                {
                    model.isvisible = int.Parse(ds.Tables[0].Rows[0]["isvisible"].ToString());
                }
                if (ds.Tables[0].Rows[0]["orderindex"].ToString() != "")
                {
                    model.orderindex = int.Parse(ds.Tables[0].Rows[0]["orderindex"].ToString());
                }
                model.parentid = ds.Tables[0].Rows[0]["parentid"].ToString();
                model.ProjectNO = ds.Tables[0].Rows[0]["ProjectNO"].ToString();
                model.PTreePath = ds.Tables[0].Rows[0]["PTreePath"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.TreePath = ds.Tables[0].Rows[0]["TreePath"].ToString();
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select codeno,codetype,customdefine,examplepath,fbmc,filepath,fxmc,id,isvisible,orderindex,parentid,ProjectNO,PTreePath,title,TreePath,ys,zfbmc,zrr ");
            strSql.Append(" FROM Cell_Templet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }
        /*
        */
        public DataSet GetMaxByParentID(string parentid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * ");
            strSql.Append(" FROM Cell_Templet ");
            strSql.Append(" where parentid='" + parentid + "' order by OrderIndex desc");
            return DbHelperOleDb.Query(strSql.ToString());
        }
    }
}
