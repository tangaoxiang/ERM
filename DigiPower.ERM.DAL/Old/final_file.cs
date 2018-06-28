using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Digi.DBUtility;//请先添加引用
namespace ERM.DAL
{
    /// <summary>
    /// 数据访问类T_FileList。
    /// </summary>
    public class T_FileList
    {
        public T_FileList()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string FileID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_FileList");
            strSql.Append(" where FileID='" + FileID + "' ");
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
            if (model.bgqx != null)
            {
                strSql1.Append("bgqx,");
                strSql2.Append("'" + model.bgqx + "',");
            }
            if (model.bz != null)
            {
                strSql1.Append("bz,");
                strSql2.Append("'" + model.bz + "',");
            }
            if (model.bzdw != null)
            {
                strSql1.Append("bzdw,");
                strSql2.Append("'" + model.bzdw + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.CreateDate2 != null)
            {
                strSql1.Append("CreateDate2,");
                strSql2.Append("'" + model.CreateDate2 + "',");
            }
            if (model.dw != null)
            {
                strSql1.Append("dw,");
                strSql2.Append("'" + model.dw + "',");
            }
            if (model.fbl != null)
            {
                strSql1.Append("fbl,");
                strSql2.Append("'" + model.fbl + "',");
            }
            if (model.FileID != null)
            {
                strSql1.Append("FileID,");
                strSql2.Append("'" + model.FileID + "',");
            }
            if (model.filepath != null)
            {
                strSql1.Append("filepath,");
                strSql2.Append("'" + model.filepath + "',");
            }
            if (model.fileStatus != null)
            {
                strSql1.Append("fileStatus,");
                strSql2.Append("'" + model.fileStatus + "',");
            }
            if (model.gg != null)
            {
                strSql1.Append("gg,");
                strSql2.Append("'" + model.gg + "',");
            }
            if (model.mj != null)
            {
                strSql1.Append("mj,");
                strSql2.Append("'" + model.mj + "',");
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
            if (model.psdd != null)
            {
                strSql1.Append("psdd,");
                strSql2.Append("'" + model.psdd + "',");
            }
            if (model.pssj != null)
            {
                strSql1.Append("pssj,");
                strSql2.Append("'" + model.pssj + "',");
            }
            if (model.psz != null)
            {
                strSql1.Append("psz,");
                strSql2.Append("'" + model.psz + "',");
            }
            if (model.PtreePath != null)
            {
                strSql1.Append("PtreePath,");
                strSql2.Append("'" + model.PtreePath + "',");
            }
            if (model.sb != null)
            {
                strSql1.Append("sb,");
                strSql2.Append("'" + model.sb + "',");
            }
            if (model.sl != null)
            {
                strSql1.Append("sl,");
                strSql2.Append("" + model.sl + ",");
            }
            if (model.TreePath != null)
            {
                strSql1.Append("TreePath,");
                strSql2.Append("'" + model.TreePath + "',");
            }
            if (model.wh != null)
            {
                strSql1.Append("wh,");
                strSql2.Append("'" + model.wh + "',");
            }
            if (model.wjbsm != null)
            {
                strSql1.Append("wjbsm,");
                strSql2.Append("'" + model.wjbsm + "',");
            }
            if (model.wjcj != null)
            {
                strSql1.Append("wjcj,");
                strSql2.Append("'" + model.wjcj + "',");
            }
            if (model.wjdx != null)
            {
                strSql1.Append("wjdx,");
                strSql2.Append("'" + model.wjdx + "',");
            }
            if (model.wjgbdm != null)
            {
                strSql1.Append("wjgbdm,");
                strSql2.Append("'" + model.wjgbdm + "',");
            }
            if (model.wjgs != null)
            {
                strSql1.Append("wjgs,");
                strSql2.Append("'" + model.wjgs + "',");
            }
            if (model.wjlxdm != null)
            {
                strSql1.Append("wjlxdm,");
                strSql2.Append("'" + model.wjlxdm + "',");
            }
            if (model.wjmc != null)
            {
                strSql1.Append("wjmc,");
                strSql2.Append("'" + model.wjmc + "',");
            }
            if (model.wjtm != null)
            {
                strSql1.Append("wjtm,");
                strSql2.Append("'" + model.wjtm + "',");
            }
            if (model.xjpp != null)
            {
                strSql1.Append("xjpp,");
                strSql2.Append("'" + model.xjpp + "',");
            }
            if (model.xjxh != null)
            {
                strSql1.Append("xjxh,");
                strSql2.Append("'" + model.xjxh + "',");
            }
            if (model.zrr != null)
            {
                strSql1.Append("zrr,");
                strSql2.Append("'" + model.zrr + "',");
            }
            if (model.ztlx != null)
            {
                strSql1.Append("ztlx,");
                strSql2.Append("'" + model.ztlx + "',");
            }
            if (model.dpz != null)
            {
                strSql1.Append("dpz,");
                strSql2.Append("'" + model.dpz + "',");
            }
            if (model.dtz != null)
            {
                strSql1.Append("dtz,");
                strSql2.Append("'" + model.dtz + "',");
            }
            if (model.tzz != null)
            {
                strSql1.Append("tzz,");
                strSql2.Append("'" + model.tzz + "',");
            }
            if (model.wzz != null)
            {
                strSql1.Append("wzz,");
                strSql2.Append("'" + model.wzz + "',");
            }
            if (model.zpz != null)
            {
                strSql1.Append("zpz,");
                strSql2.Append("'" + model.zpz + "',");
            }
            strSql.Append("insert into T_FileList(");
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
        public void Update(ERM.MDL.T_FileList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_FileList set ");
            strSql.Append("bgqx='" + model.bgqx + "',");
            strSql.Append("bz='" + model.bz + "',");
            strSql.Append("bzdw='" + model.bzdw + "',");
            strSql.Append("CreateDate='" + model.CreateDate + "',");
            strSql.Append("CreateDate2='" + model.CreateDate2 + "',");
            strSql.Append("dw='" + model.dw + "',");
            strSql.Append("fbl='" + model.fbl + "',");
            strSql.Append("FileID='" + model.FileID + "',");
            strSql.Append("filepath='" + model.filepath + "',");
            strSql.Append("fileStatus='" + model.fileStatus + "',");
            strSql.Append("gg='" + model.gg + "',");
            strSql.Append("mj='" + model.mj + "',");
            strSql.Append("parentid='" + model.parentid + "',");
            strSql.Append("ProjectNO='" + model.ProjectNO + "',");
            strSql.Append("psdd='" + model.psdd + "',");
            strSql.Append("pssj='" + model.pssj + "',");
            strSql.Append("psz='" + model.psz + "',");
            strSql.Append("PtreePath='" + model.PtreePath + "',");
            strSql.Append("sb='" + model.sb + "',");
            strSql.Append("sl=" + model.sl + ",");
            strSql.Append("TreePath='" + model.TreePath + "',");
            strSql.Append("wh='" + model.wh + "',");
            strSql.Append("wjbsm='" + model.wjbsm + "',");
            strSql.Append("wjcj='" + model.wjcj + "',");
            strSql.Append("wjdx='" + model.wjdx + "',");
            strSql.Append("wjgbdm='" + model.wjgbdm + "',");
            strSql.Append("wjgs='" + model.wjgs + "',");
            strSql.Append("wjlxdm='" + model.wjlxdm + "',");
            strSql.Append("wjmc='" + model.wjmc + "',");
            strSql.Append("wjtm='" + model.wjtm + "',");
            strSql.Append("xjpp='" + model.xjpp + "',");
            strSql.Append("xjxh='" + model.xjxh + "',");
            strSql.Append("zrr='" + model.zrr + "',");
            strSql.Append("ztlx='" + model.ztlx + "',");
            strSql.Append("dpz='" + model.dpz + "',");
            strSql.Append("dtz='" + model.dtz + "',");
            strSql.Append("tzz='" + model.tzz + "',");
            strSql.Append("wzz='" + model.wzz + "',");
            strSql.Append("zpz='" + model.zpz + "'");
            strSql.Append(" where TreePath='" + model.TreePath + "' ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string FileID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_FileList ");
            strSql.Append(" where FileID='" + FileID + "' ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ERM.MDL.T_FileList Find(string FileID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ");
            strSql.Append(" bgqx,bz,bzdw,CreateDate,CreateDate2,dw,fbl,FileID,filepath,fileStatus,gg,mj,parentid,ProjectNO,psdd,pssj,psz,PtreePath,sb,sl,TreePath,wh,wjbsm,wjcj,wjdx,wjgbdm,wjgs,wjlxdm,wjmc,wjtm,xjpp,xjxh,zrr,ztlx,dpz,dtz,tzz,wzz,zpz ");
            strSql.Append(" from T_FileList ");
            strSql.Append(" where FileID='" + FileID + "' ");
            ERM.MDL.T_FileList model = new ERM.MDL.T_FileList();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.bgqx = ds.Tables[0].Rows[0]["bgqx"].ToString();
                model.bz = ds.Tables[0].Rows[0]["bz"].ToString();
                model.bzdw = ds.Tables[0].Rows[0]["bzdw"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate2"].ToString() != "")
                {
                    model.CreateDate2 = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate2"].ToString());
                }
                model.dw = ds.Tables[0].Rows[0]["dw"].ToString();
                model.fbl = ds.Tables[0].Rows[0]["fbl"].ToString();
                model.FileID = ds.Tables[0].Rows[0]["FileID"].ToString();
                model.filepath = ds.Tables[0].Rows[0]["filepath"].ToString();
                model.fileStatus = ds.Tables[0].Rows[0]["fileStatus"].ToString();
                model.gg = ds.Tables[0].Rows[0]["gg"].ToString();
                model.mj = ds.Tables[0].Rows[0]["mj"].ToString();
                model.parentid = ds.Tables[0].Rows[0]["parentid"].ToString();
                model.ProjectNO = ds.Tables[0].Rows[0]["ProjectNO"].ToString();
                model.psdd = ds.Tables[0].Rows[0]["psdd"].ToString();
                if (ds.Tables[0].Rows[0]["pssj"].ToString() != "")
                {
                    model.pssj = DateTime.Parse(ds.Tables[0].Rows[0]["pssj"].ToString());
                }
                model.psz = ds.Tables[0].Rows[0]["psz"].ToString();
                model.PtreePath = ds.Tables[0].Rows[0]["PtreePath"].ToString();
                model.sb = ds.Tables[0].Rows[0]["sb"].ToString();
                if (ds.Tables[0].Rows[0]["sl"].ToString() != "")
                {
                    model.sl = int.Parse(ds.Tables[0].Rows[0]["sl"].ToString());
                }
                model.TreePath = ds.Tables[0].Rows[0]["TreePath"].ToString();
                model.wh = ds.Tables[0].Rows[0]["wh"].ToString();
                model.wjbsm = ds.Tables[0].Rows[0]["wjbsm"].ToString();
                model.wjcj = ds.Tables[0].Rows[0]["wjcj"].ToString();
                model.wjdx = ds.Tables[0].Rows[0]["wjdx"].ToString();
                model.wjgbdm = ds.Tables[0].Rows[0]["wjgbdm"].ToString();
                model.wjgs = ds.Tables[0].Rows[0]["wjgs"].ToString();
                model.wjlxdm = ds.Tables[0].Rows[0]["wjlxdm"].ToString();
                model.wjmc = ds.Tables[0].Rows[0]["wjmc"].ToString();
                model.wjtm = ds.Tables[0].Rows[0]["wjtm"].ToString();
                model.xjpp = ds.Tables[0].Rows[0]["xjpp"].ToString();
                model.xjxh = ds.Tables[0].Rows[0]["xjxh"].ToString();
                model.zrr = ds.Tables[0].Rows[0]["zrr"].ToString();
                model.ztlx = ds.Tables[0].Rows[0]["ztlx"].ToString();
                model.dpz = ds.Tables[0].Rows[0]["dpz"].ToString();
                model.dtz = ds.Tables[0].Rows[0]["dtz"].ToString();
                model.tzz = ds.Tables[0].Rows[0]["tzz"].ToString();
                model.wzz = ds.Tables[0].Rows[0]["wzz"].ToString();
                model.zpz = ds.Tables[0].Rows[0]["zpz"].ToString();
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
            strSql.Append("select bgqx,bz,bzdw,CreateDate,CreateDate2,dw,fbl,FileID,filepath,fileStatus,gg,mj,parentid,ProjectNO,psdd,pssj,psz,PtreePath,sb,sl,TreePath,wh,wjbsm,wjcj,wjdx,wjgbdm,wjgs,wjlxdm,wjmc,wjtm,xjpp,xjxh,zrr,ztlx,dpz,dtz,tzz,wzz,zpz ");
            strSql.Append(" FROM T_FileList ");
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
