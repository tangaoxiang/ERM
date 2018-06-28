using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Digi.B.DAL
{
    public class Vars
    {
        /// <summary>
        /// 获取自定义变量数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetVars()
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sql = "Select * from Vars order by varID";

            DbCommand cmd = db.GetSqlStringCommand(sql);

            DataSet ds = db.ExecuteDataSet(cmd);

            return ds;
        }
        public DataSet GetTrees()
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sql = "select id,len(id) as length,parentid,title,filepath,examplepath,codeno,2 as imageindex,codetype,zrr,fbmc,fxmc,zfbmc,orderindex,isvisible,ys,customdefine,'' as gclx,'' as jsdw,'' as sgdw,'' as sjdw,'' as jldw,'' as cjdag,'' as wjmj from Cell_Templet "
            + " UNION select id,len(id) as length,iif(len(id)>2,left(id,len(id)-2),iif(id='00','','00')) ,gdwj,'','','',1 as imageindex,0 as codetype,zrr,'','','',orderindex,isvisible,0,0,gclx,jsdw,sgdw,sjdw,jldw,cjdag,wjmj from filerecording_templet order by length,orderindex";

            DbCommand cmd = db.GetSqlStringCommand(sql);

            DataSet ds = db.ExecuteDataSet(cmd);

            return ds;
        }

        public DataSet GetArchives()
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sql = "select * from archivedata ";

            DbCommand cmd = db.GetSqlStringCommand(sql);

            DataSet ds = db.ExecuteDataSet(cmd);

            return ds;
        }

        public int GetNextNodeID(string parentid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "select max(cint(right(nodeid,2))) as nextid  from  Cell_templet where left(nodeid,len(nodeid)-2)='" + parentid + "' and   len(nodeid)-2=len('" + parentid + "')" +
                " union " +
                " select max(cint(right(nodeid,2)))  from  filerecording_templet where left(nodeid,len(nodeid)-2)='" + parentid + "' and   len(nodeid)-2=len('" + parentid + "')" +
                " order by nextid desc";
            
            DbCommand cmd = db .GetSqlStringCommand(sql);

            object obj = db.ExecuteScalar(cmd);

            return Convert.ToInt32(obj)+1;
        }

        public DataView GetFileRecording(string nodeid)
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sql = "select * from filerecording_templet where nodeid= '" + nodeid + "'";

            DbCommand cmd = db.GetSqlStringCommand(sql);

            DataView dv = db.ExecuteDataSet(cmd).Tables[0].DefaultView;

            return dv;
        }
        
    }
}
