using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
    /// <summary>
    /// 数据访问类FileRecording_Templet。
    /// </summary>
    public class FileRecording_Templet
    {
        public FileRecording_Templet()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id, string ProjectNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FileRecording_Templet");
            strSql.Append(" where id='" + id + "' and ProjectNO='" + ProjectNO + "' ");
            return DbHelperOleDb.Exists(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ERM.MDL.T_FileList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cjdag != null)
            {
                strSql1.Append("cjdag,");
                strSql2.Append("'" + model.cjdag + "',");
            }
            if (model.datawindow_id != null)
            {
                strSql1.Append("datawindow_id,");
                strSql2.Append("'" + model.datawindow_id + "',");
            }
            if (model.extension1 != null)
            {
                strSql1.Append("extension1,");
                strSql2.Append("'" + model.extension1 + "',");
            }
            if (model.extension2 != null)
            {
                strSql1.Append("extension2,");
                strSql2.Append("'" + model.extension2 + "',");
            }
            if (model.extension3 != null)
            {
                strSql1.Append("extension3,");
                strSql2.Append("'" + model.extension3 + "',");
            }
            if (model.gclx != null)
            {
                strSql1.Append("gclx,");
                strSql2.Append("'" + model.gclx + "',");
            }
            if (model.gdwj != null)
            {
                strSql1.Append("gdwj,");
                strSql2.Append("'" + model.gdwj + "',");
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
            if (model.jldw != null)
            {
                strSql1.Append("jldw,");
                strSql2.Append("'" + model.jldw + "',");
            }
            if (model.jsdw != null)
            {
                strSql1.Append("jsdw,");
                strSql2.Append("'" + model.jsdw + "',");
            }
            if (model.OrderIndex != null)
            {
                strSql1.Append("OrderIndex,");
                strSql2.Append("" + model.OrderIndex+ ",");
            }
            if (model.ProjectNO != null)
            {
                strSql1.Append("ProjectNO,");
                strSql2.Append("'" + model.ProjectNO + "',");
            }
            if (model.pTreePath != null)
            {
                strSql1.Append("pTreePath,");
                strSql2.Append("'" + model.pTreePath + "',");
            }
            if (model.selected != null)
            {
                strSql1.Append("selected,");
                strSql2.Append("" + model.selected + ",");
            }
            if (model.sgdw != null)
            {
                strSql1.Append("sgdw,");
                strSql2.Append("'" + model.sgdw + "',");
            }
            if (model.sjdw != null)
            {
                strSql1.Append("sjdw,");
                strSql2.Append("'" + model.sjdw + "',");
            }
            if (model.table_name != null)
            {
                strSql1.Append("table_name,");
                strSql2.Append("'" + model.table_name + "',");
            }
            if (model.table_standerd != null)
            {
                strSql1.Append("table_standerd,");
                strSql2.Append("'" + model.table_standerd + "',");
            }
            if (model.TreePath != null)
            {
                strSql1.Append("TreePath,");
                strSql2.Append("'" + model.TreePath + "',");
            }
            if (model.wjmj != null)
            {
                strSql1.Append("wjmj,");
                strSql2.Append("'" + model.wjmj + "',");
            }
            if (model.zrr != null)
            {
                strSql1.Append("zrr,");
                strSql2.Append("'" + model.zrr + "',");
            }
            strSql.Append("insert into FileRecording_Templet(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string GetAddSql(ERM.MDL.T_FileList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cjdag != null)
            {
                strSql1.Append("cjdag,");
                strSql2.Append("'" + model.cjdag + "',");
            }
            if (model.datawindow_id != null)
            {
                strSql1.Append("datawindow_id,");
                strSql2.Append("'" + model.datawindow_id + "',");
            }
            if (model.extension1 != null)
            {
                strSql1.Append("extension1,");
                strSql2.Append("'" + model.extension1 + "',");
            }
            if (model.extension2 != null)
            {
                strSql1.Append("extension2,");
                strSql2.Append("'" + model.extension2 + "',");
            }
            if (model.extension3 != null)
            {
                strSql1.Append("extension3,");
                strSql2.Append("'" + model.extension3 + "',");
            }
            if (model.gclx != null)
            {
                strSql1.Append("gclx,");
                strSql2.Append("'" + model.gclx + "',");
            }
            if (model.gdwj != null)
            {
                strSql1.Append("gdwj,");
                strSql2.Append("'" + model.gdwj + "',");
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
            if (model.jldw != null)
            {
                strSql1.Append("jldw,");
                strSql2.Append("'" + model.jldw + "',");
            }
            if (model.jsdw != null)
            {
                strSql1.Append("jsdw,");
                strSql2.Append("'" + model.jsdw + "',");
            }
            if (model.OrderIndex != null)
            {
                strSql1.Append("OrderIndex,");
                strSql2.Append("" + model.OrderIndex + ",");
            }
            if (model.ProjectNO != null)
            {
                strSql1.Append("ProjectNO,");
                strSql2.Append("'" + model.ProjectNO + "',");
            }
            if (model.pTreePath != null)
            {
                strSql1.Append("pTreePath,");
                strSql2.Append("'" + model.pTreePath + "',");
            }
            if (model.selected != null)
            {
                strSql1.Append("selected,");
                strSql2.Append("" + model.selected + ",");
            }
            if (model.sgdw != null)
            {
                strSql1.Append("sgdw,");
                strSql2.Append("'" + model.sgdw + "',");
            }
            if (model.sjdw != null)
            {
                strSql1.Append("sjdw,");
                strSql2.Append("'" + model.sjdw + "',");
            }
            if (model.table_name != null)
            {
                strSql1.Append("table_name,");
                strSql2.Append("'" + model.table_name + "',");
            }
            if (model.table_standerd != null)
            {
                strSql1.Append("table_standerd,");
                strSql2.Append("'" + model.table_standerd + "',");
            }
            if (model.TreePath != null)
            {
                strSql1.Append("TreePath,");
                strSql2.Append("'" + model.TreePath + "',");
            }
            if (model.wjmj != null)
            {
                strSql1.Append("wjmj,");
                strSql2.Append("'" + model.wjmj + "',");
            }
            if (model.zrr != null)
            {
                strSql1.Append("zrr,");
                strSql2.Append("'" + model.zrr + "',");
            }
            strSql.Append("insert into FileRecording_Templet(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(ERM.MDL.T_FileList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FileRecording_Templet set ");
            strSql.Append("cjdag='" + model.cjdag + "',");
            strSql.Append("datawindow_id='" + model.datawindow_id + "',");
            strSql.Append("extension1='" + model.extension1 + "',");
            strSql.Append("extension2='" + model.extension2 + "',");
            strSql.Append("extension3='" + model.extension3 + "',");
            strSql.Append("gclx='" + model.gclx + "',");
            strSql.Append("gdwj='" + model.gdwj + "',");
            strSql.Append("id='" + model.id + "',");
            strSql.Append("isvisible=" + model.isvisible + ",");
            strSql.Append("jldw='" + model.jldw + "',");
            strSql.Append("jsdw='" + model.jsdw + "',");
            strSql.Append("OrderIndex=" + model.OrderIndex + ",");
            strSql.Append("ProjectNO='" + model.ProjectNO + "',");
            strSql.Append("pTreePath='" + model.pTreePath + "',");
            strSql.Append("selected=" + model.selected + ",");
            strSql.Append("sgdw='" + model.sgdw + "',");
            strSql.Append("sjdw='" + model.sjdw + "',");
            strSql.Append("table_name='" + model.table_name + "',");
            strSql.Append("table_standerd='" + model.table_standerd + "',");
            strSql.Append("TreePath='" + model.TreePath + "',");
            strSql.Append("wjmj='" + model.wjmj + "',");
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
            strSql.Append("delete from FileRecording_Templet ");
            strSql.Append(" where id='" + id + "' and ProjectNO='" + ProjectNO + "' ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.T_FileList Find(string id, string ProjectNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" cjdag,datawindow_id,extension1,extension2,extension3,gclx,gdwj,id,isvisible,jldw,jsdw,OrderIndex,ProjectNO,pTreePath,selected,sgdw,sjdw,table_name,table_standerd,TreePath,wjmj,zrr ");
            strSql.Append(" from FileRecording_Templet ");
            strSql.Append(" where id='" + id + "' and ProjectNO='" + ProjectNO + "' ");
            ERM.MDL.T_FileList model = new ERM.MDL.T_FileList();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.cjdag = ds.Tables[0].Rows[0]["cjdag"].ToString();
                model.datawindow_id = ds.Tables[0].Rows[0]["datawindow_id"].ToString();
                model.extension1 = ds.Tables[0].Rows[0]["extension1"].ToString();
                model.extension2 = ds.Tables[0].Rows[0]["extension2"].ToString();
                model.extension3 = ds.Tables[0].Rows[0]["extension3"].ToString();
                model.gclx = ds.Tables[0].Rows[0]["gclx"].ToString();
                model.gdwj = ds.Tables[0].Rows[0]["gdwj"].ToString();
                model.id = ds.Tables[0].Rows[0]["id"].ToString();
                if (ds.Tables[0].Rows[0]["isvisible"].ToString() != "")
                {
                    model.isvisible = int.Parse(ds.Tables[0].Rows[0]["isvisible"].ToString());
                }
                model.jldw = ds.Tables[0].Rows[0]["jldw"].ToString();
                model.jsdw = ds.Tables[0].Rows[0]["jsdw"].ToString();
                if (ds.Tables[0].Rows[0]["OrderIndex"].ToString() != "")
                {
                    model.OrderIndex = int.Parse(ds.Tables[0].Rows[0]["OrderIndex"].ToString());
                }
                model.ProjectNO = ds.Tables[0].Rows[0]["ProjectNO"].ToString();
                model.pTreePath = ds.Tables[0].Rows[0]["pTreePath"].ToString();
                if (ds.Tables[0].Rows[0]["selected"].ToString() != "")
                {
                    model.selected = int.Parse(ds.Tables[0].Rows[0]["selected"].ToString());
                }
                model.sgdw = ds.Tables[0].Rows[0]["sgdw"].ToString();
                model.sjdw = ds.Tables[0].Rows[0]["sjdw"].ToString();
                model.table_name = ds.Tables[0].Rows[0]["table_name"].ToString();
                model.table_standerd = ds.Tables[0].Rows[0]["table_standerd"].ToString();
                model.TreePath = ds.Tables[0].Rows[0]["TreePath"].ToString();
                model.wjmj = ds.Tables[0].Rows[0]["wjmj"].ToString();
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
            strSql.Append("select cjdag,datawindow_id,extension1,extension2,extension3,gclx,gdwj,id,isvisible,jldw,jsdw,OrderIndex,ProjectNO,pTreePath,selected,sgdw,sjdw,table_name,table_standerd,TreePath,wjmj,zrr ");
            strSql.Append(" FROM FileRecording_Templet ");
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
