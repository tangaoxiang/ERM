using System;
using System.Collections.Generic;
using System.Text;
using Digi.DBUtility;
using System.Data;
namespace ERM.CBLL
{
    public class ArchiveData_fbfx
    {
        private string  NodeID;
        private DataTable dt;
        private  DataSet ds = new DataSet();
        private DataSet ds_Archviedata = new DataSet();
        private CellTreesData treesData = new CellTreesData();
        public  string fbmc;
        public DataSet ds_fx;
        private string codetype;
        /// <summary>
        ///
        /// </summary>
        /// <param name="_nodeid">模板的ID</param>
        /// <param name="_codetype">分部分项子分部</param>
        /// <param name="_projectno">工程名称</param>
        public ArchiveData_fbfx(string _nodeid,string _codetype,string _projectno)
        {
            ds = treesData.GetTrees(false,_projectno);
            IList<MDL.T_Archive> archiveList = new ERM.BLL.T_Archive_BLL().FindByProjectNO(_projectno);
            ds_Archviedata = (DataSet)archiveList;
            NodeID = _nodeid;
            codetype = _codetype;
        }
        public Boolean HasChild()
        {
            DataView dv = new DataView(ds_Archviedata.Tables[0]);
            dv.RowFilter = "cellparentid='" + NodeID + "'";
            if (dv.Count > 0)
                return true;
            else
                return false;
        }
        public DataView Load()
        {
            dt = new DataTable();
            dt.Columns.Add("fbmc", typeof(string));
            dt.Columns.Add("fxmc", typeof(string));
            dt.Columns.Add("xh", typeof(string));
            dt.Columns.Add("ps", typeof(string));
            Setfbmc();
            return dt.DefaultView;
        }
        private void Getfbmc(string mc)
        {
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "id='" + NodeID + "'";
            fbmc= dv[0][mc].ToString();
        }
        public void Setfbmc()
        { 
            switch (codetype)
            {
                case "2":
                    Getfbmc("fbmc");
                    FindRows_fb(fbmc, "fbmc");
                    break;
                case "3":
                    Getfbmc("fbmc");
                    FindRows_fx(fbmc, "fbmc");
                    break;
                case "6":
                    Getfbmc("zfbmc");
                    FindRows_fb(fbmc, "zfbmc");
                    break;
            }
        }
        private void FindRows_fx(string key, string regular)
        {
            ds_fx = new DataSet();
            DataView dv = new DataView( ds.Tables[0]);
            dv.RowFilter = regular + "='" + key + "' and codetype=4";
            if (dv.Count < 1)
                return;
            foreach (DataRowView drv in dv)
            {
                int ps = GetCount(drv["id"].ToString());
                if (ps > 0)
                {
                    DataTable dt_fx = new DataTable();
                    dt_fx.Columns.Add("ps", typeof(string));
                    dt_fx.Columns.Add("fxmc", typeof(string));
                    dt_fx.Columns.Add("bw", typeof(string));
                    dt_fx.Columns.Add("xh", typeof(string));
                    DataView dv2 = new DataView(ds_Archviedata.Tables[0]);
                    dv2.RowFilter = "cellparentid='" + drv["id"].ToString() + "' and docstatus>0";
                    foreach (DataRowView drv2 in dv2)
                    {
                        DataRow dr = dt_fx.NewRow();
                        dr["ps"] = ps.ToString();
                        dr["fxmc"] = drv["fxmc"].ToString();
                        dr["bw"] = drv2["title"].ToString();
                        dr["xh"] = i;
                        dt_fx.Rows.Add(dr);
                        i++;
                    }
                    ds_fx.Tables.Add(dt_fx);
                    i = 1;
                }
            }
        }
        int i = 1;
        private void FindRows_fb(string key,string regular)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = regular+"='" + key  + "' and codetype=4";
            if (dv.Count < 1)
                return;
            foreach (DataRowView drv in dv)
            {
                int ps = GetCount(drv["id"].ToString());
                if (ps > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["fbmc"] = drv[regular].ToString();
                    dr["fxmc"] = drv["fxmc"].ToString();
                    dr["ps"] = ps.ToString();
                    dr["xh"] = i;
                    i += 1;
                    dt.Rows.Add(dr);
                }
            }
        }
        private int GetCount(string id)
        {
            DataView dv = new DataView(ds_Archviedata.Tables[0]);
            dv.RowFilter = "cellparentid='" + id + "'and docstatus>0";
            return dv.Count;
        }
    }
}
