/*
   作者：  张建宏
 * 日期：2009-01-05
 * 功能：文件组卷打印
 * 备注：
 *       
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ERM.MDL;
using Digi.DBUtility;//请先添加引用
using System.Linq;

namespace ERM.CBLL
{
    public class PrintFinalArchive
    {
        /// <summary>
        /// 案卷封面打印信息
        /// </summary>
        /// <param name="archiveID"></param>
        /// <returns></returns>
        public DataView Print_Ajfm(List<string> archiveID, string ProjectNO)
        {
            string id = string.Empty;
            int js = (int)DbHelperOleDb.GetSingle("select count(*) from T_Archive where ProjectNO='" + ProjectNO + "'");
            DataTable dt = null;
             List<DataTable>list = new List<DataTable>();
             list.Clear();
            for (int i = 0; i < archiveID.Count; i++)
            {
                string sql = "SELECT '"+js+"' as js, T_Archive.zlrq, T_Archive.ajlx, T_Archive.ajs, T_Archive.ajtm, T_Archive.ArchiveID, T_Archive.bgqx, T_Archive.bz, T_Archive.bzdw, (select IIF(isnull(min(f.CreateDate)),'',format(min(f.CreateDate),'yyyy.mm.dd')) from T_FileList f where f.ArchiveID ='" +
                    archiveID[i].ToString() + "' )+'-'+(select IIF(isnull(max(f.CreateDate2)),'',format(max(f.CreateDate2),'yyyy.mm.dd'))from T_FileList f where f.ArchiveID ='" +
                    archiveID[i].ToString() + "' ) AS bzrq,(select sum(stys) from t_filelist where archiveid='"+
                    archiveID[i].ToString()+"')as stys, T_Archive.cdh, T_Archive.cpz, T_Archive.dh, T_Archive.dpz, T_Archive.dtz, T_Archive.dw, T_Archive.gpz, T_Archive.ljr, T_Archive.lxdh, T_Archive.lydh, T_Archive.mj, T_Archive.orderindex, T_Archive.p, T_Archive.ProjectNO, T_Archive.qt, T_Archive.sl, T_Archive.swp, T_Archive.tzz, T_Archive.wzz, T_Archive.ysfw, T_Archive.z, T_Archive.zpz, bzksrq+'  -  '+bzjsrq AS bzrq1, (CInt(dtz)+CInt(tzz)+CInt(wzz)) AS totalPageNumber FROM T_Archive WHERE (((T_Archive.[archiveID])='" + 
                    archiveID[i].ToString() + "')) ORDER BY T_Archive.orderindex";
                dt = DbHelperOleDb.Query(sql).Tables[0];
                int r = dt.Rows.Count;
                list.Add(dt);
            }
            DataTable dt1 = new DataTable();
            dt1.TableName = "newTable";

            if (list.Count>0)
            {
                if (dt1.Rows.Count>0)
                {
                    dt1.Rows.Clear();
                }
                else
                {
                    dt1 = list[0].Clone(); 
                }
            }

            foreach (var item in list)
            {
                for (int i = 0; i < item.Rows.Count; i++)
                {
                    DataRow dr = dt1.NewRow();
                    for (int j = 0; j < item.Columns.Count; j++)
                    {
                        if (item.Columns[j].DataType ==Type.GetType("System.Int32"))
                        {
                            int flag = 0;
                            if (int.TryParse(item.Rows[i][item.Columns[j].ColumnName].ToString(),out flag))
                            {
                                dr[item.Columns[j].ColumnName] = flag;
                            }
                        }
                        else if (item.Columns[j].DataType ==Type.GetType("System.Double"))
                        {
                            double flag1 = 0;
                            if (double.TryParse(item.Rows[i][item.Columns[j].ColumnName].ToString(), out flag1))
                            {
                                dr[item.Columns[j].ColumnName] = flag1;
                            }
                        }
                        else
                        {
                            dr[item.Columns[j].ColumnName] = item.Rows[i][item.Columns[j].ColumnName].ToString();
                        }

                        //if (item.Columns[j].ColumnName == "stys" && item.Rows[i][item.Columns[j].ColumnName].ToString()=="")
                        //{
                        //    item.Rows[i][item.Columns[j].ColumnName] = 0;
                        //}
                    }


                    dt1.Rows.Add(dr);
                }
            }
            return dt1.DefaultView;
        }
        /// <summary>
        /// 备考表打印信息
        /// </summary>
        /// <param name="archiveID"></param>
        /// <returns></returns>
        public DataView Print_Bkb(List<string> archiveID)
        {
            string id = string.Empty;
            for (int i = 0; i < archiveID.Count; i++)
            {
                id += "'" + archiveID[i].ToString() + "',";
            }

            if (id != "")
            {
                id = id.Substring(0, id.Length - 1);
            }

            string sql = "Select a.*,b.ProjectNO as ProjectNO,(select sum(iif(IsNull(wzys),0,wzys)) from t_filelist where projectno=b.projectno and archiveid=a.archiveid)as wzys ,b.projectname as projectname from T_Archive as a inner join T_Projects as b on b.ProjectNO=a.ProjectNO where archiveID in(" + id + ")";
            DataSet ds = DbHelperOleDb.Query(sql);
            DataTable dt = new DataTable();
            dt.Columns.Add("zpz", typeof(string));
            dt.Columns.Add("sl", typeof(string));
            dt.Columns.Add("wzz", typeof(string));
            dt.Columns.Add("ty", typeof(string));
            dt.Columns.Add("bz", typeof(string));
            dt.Columns.Add("ljr", typeof(string));
            dt.Columns.Add("ProjectNO", typeof(string));
            dt.Columns.Add("projectname", typeof(string));
            dt.Columns.Add("bkshr", typeof(string));
            dt.Columns.Add("zlrq", typeof(string));
            dt.Columns.Add("ljrq", typeof(string));
            dt.Columns.Add("tzz", typeof(string));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string zpz = ds.Tables[0].Rows[i]["zpz"].ToString();
                string dpz = ds.Tables[0].Rows[i]["dpz"].ToString();
                string tzz = ds.Tables[0].Rows[i]["tzz"].ToString();
                string dtz = ds.Tables[0].Rows[i]["dtz"].ToString();
                string wzz = ds.Tables[0].Rows[i]["wzys"].ToString();
                int i_dpz = string.IsNullOrEmpty(dpz) ? 0 : Convert.ToInt32(dpz);
                int i_zpz = string.IsNullOrEmpty(zpz) ? 0 : Convert.ToInt32(zpz);
                int i_tzz = string.IsNullOrEmpty(tzz) ? 0 : Convert.ToInt32(tzz);
                int i_dtz = string.IsNullOrEmpty(dtz) ? 0 : Convert.ToInt32(dtz);
                int i_wzz = string.IsNullOrEmpty(wzz) ? 0 : Convert.ToInt32(wzz);
               
                DataRow dr = dt.NewRow();
                dr["ProjectNO"] = ds.Tables[0].Rows[i]["ProjectNO"].ToString();
                dr["projectname"] = ds.Tables[0].Rows[i]["projectname"].ToString();
                dr["bkshr"] = ds.Tables[0].Rows[i]["ajs"].ToString();
                dr["zpz"] = i_zpz + i_dpz;
                dr["wzz"] = i_wzz;
                dr["tzz"] = i_dtz;
                dr["ty"] = i_dtz + i_tzz;
                dr["sl"] = i_tzz + i_dtz + i_wzz + i_zpz + i_dpz;
                dr["bz"] = ds.Tables[0].Rows[i]["bz"].ToString();
                dr["ljr"] = ds.Tables[0].Rows[i]["ljr"].ToString();
                dr["zlrq"] = ds.Tables[0].Rows[i]["zlrq"].ToString();
                dr["ljrq"] = ds.Tables[0].Rows[i]["ljrq"].ToString();
                dt.Rows.Add(dr);
            }
            
            return dt.DefaultView;
        }
        /// <summary>
        /// 卷内目录打印信息
        /// </summary>
        /// <param name="archiveID"></param>
        /// <returns></returns>
        List<string> list = null;
        public DataView Print_Jnml(List<string> archiveID)
        {
            string id = string.Empty;
            for (int i = 0; i < archiveID.Count; i++)
            {
                id += "'" + archiveID[i].ToString() + "',";
            }

            if (id != "")
            {
                id = id.Substring(0, id.Length - 1);
            }

            //int OrderIndex = (int)DbHelperOleDb.GetSingle("select orderindex from T_Archive where archiveID in(" + id + ")");
            //string sql2 = "select orderindex  from T_Archive where archiveid= '" + archiveID + "'";
            //object obj = DbHelperOleDb.GetSingle(sql2);
            //string sql = "SELECT  T_FileList.*, " + obj.ToString() + " as orderindex,  t1.ArchiveID FROM T_FileList INNER JOIN (select  fileid,archiveid,max(orderindex2) as or2 from attachment where archiveid='" + archiveID + "' group by fileid,archiveid) as t1 ON T_FileList.FileID = t1.fileID where  fileStatus='5' and Attachment.ArchiveID='" + archiveID + "' order by t1.or2";

            string sql = "SELECT T_FileList.*,T_Archive.ajtm,T_Archive.dh FROM T_FileList INNER JOIN T_Archive ON T_Archive.ArchiveID = T_FileList.ArchiveID where fileStatus='6' and T_FileList.ArchiveID in(" + id + ") Order by t_filelist.archiveid, ArchiveIndex";
            DataSet ds = DbHelperOleDb.Query(sql);

            DataTable dt = null;

            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns.Add("yc", Type.GetType("System.String"));
                int PageIndexCount = 1;
                dt = ds.Tables[0];

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow rv = ds.Tables[0].Rows[i];

                    if (i == 0)
                    {
                        dt.Rows[i]["yc"] = PageIndexCount;
                        dt.Rows[i]["orderIndex"] = 1;
                    }
                    else
                    {
                        if (dt.Rows[i]["archiveid"].ToString() != dt.Rows[i - 1]["archiveid"].ToString())
                        {
                            PageIndexCount = 1;
                            dt.Rows[i]["orderIndex"] = 1;
                        }
                        else
                        {
                            PageIndexCount += Convert.ToInt32(dt.Rows[i - 1]["stys"]);

                            if (i+1<dt.Rows.Count)
                            {
                                if (dt.Rows[i]["archiveid"].ToString() != dt.Rows[i + 1]["archiveid"].ToString())
                                {
                                    yc_Index(dt, PageIndexCount, i);
                                    continue;
                                }
                            }

                            if (i+1==dt.Rows.Count)
                            {
                                yc_Index(dt, PageIndexCount, i);
                                continue; 
                            }
                        }
                        dt.Rows[i]["yc"] = PageIndexCount;
                        dt.Rows[i]["orderIndex"] = PageIndexCount;
                    }
                }
            }

            DataSet ds1;
           
            foreach (var item in archiveID)
            {
                string sqlCount = @"select count(1) as counts,sum(iif(isnull(stys),0,stys)) as stys1 from t_filelist where archiveid='" + item.ToString() + "'";
                ds1 = DbHelperOleDb.Query(sqlCount);
                if (ds1.Tables.Count > 0)
                {
                    if (Convert.ToInt32(ds1.Tables[0].Rows[0]["counts"]) > 0)
                    {
                        int flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["counts"]);
                        int countFlag = 0;
                        if (flag<15)
                        {
                            countFlag = 15 - flag;
                        }
                        else
                        {
                            countFlag = getListCount(15, ref flag);
                            if (countFlag>15)
                            {
                                countFlag = countFlag - 15;
                            }
                            countFlag = 15 - countFlag;
                        }
                        
                        for (int n = 0; n < countFlag; n++)
                        {
                            DataRow dr = dt.NewRow();
                            dr["ArchiveID"] = item.ToString();
                            //dr["ArchiveIndex"] = Convert.ToInt32(ds1.Tables[0].Rows[0]["counts"])+n;
                            int orderIndex = 0;
                            if (int.TryParse(ds1.Tables[0].Rows[0]["stys1"].ToString(), out orderIndex))
                            {
                                dr["orderIndex"] = orderIndex + 100 + n;
                            }
                            else
                            {
                                dr["orderIndex"] = orderIndex + 1000 + n;
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            return dt.DefaultView;
        }

        /// <summary>
        /// 递归返回需要增加多少条空记录
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private int getListCount(int pageSize, ref int count)
        {
            int flag = 0;
            if (count > pageSize)
            {
                flag = count - pageSize;
                getListCount(pageSize, ref flag);
            }
            else
            {
                flag = pageSize - count;
            }
            return flag;
        }

        private static void yc_Index(DataTable dt, int PageIndexCount, int i)
        {
            int lastManualCount = Convert.ToInt32(dt.Rows[i]["stys"]);//每个案卷中的最后一份文件页次都是 *-*格式
            if (lastManualCount > 1)
            {
                dt.Rows[i]["yc"] = string.Concat(PageIndexCount, "-",
                PageIndexCount - 1 + lastManualCount);
            }
            else
            {
                dt.Rows[i]["yc"] = string.Concat(PageIndexCount, "-", PageIndexCount);
            }
            dt.Rows[i]["orderIndex"] = PageIndexCount + i;
        }

        /// <summary>
        /// 卷内目录导出信息
        /// </summary>
        /// <param name="archiveID"></param>
        /// <returns></returns>
        public DataView Export_Jnml(string archiveID)
        {
            int OrderIndex = (int)DbHelperOleDb.GetSingle("select orderindex from T_FileList where archiveID='" + archiveID + "' ");

            //string sql = "SELECT 0 as 序号,wh as 文件编号,zrr as 责任者,wjtm as 文件题名, (CreateDate + '+' +CreateDate) as 日期 , "
            //           + "CStr(iif(IsNull(dw),0,dw) + iif(IsNull(wzz),0,wzz) + iif(IsNull(sl),0,sl)) as 页次, "
            //           +"bz as 备注 FROM T_FileList where fileStatus='6' and ArchiveID='" + archiveID + "' Order by OrderIndex ";

            string sql = "SELECT 0 as numxh,wh,zrr,wjtm,(CreateDate + '+' +CreateDate) as fdate, "
                        + "CStr(iif(IsNull(T_FileList.dw),0,T_FileList.dw) + iif(IsNull(T_FileList.wzz),0,T_FileList.wzz) + "
                        + "iif(IsNull(T_FileList.sl),0,T_FileList.sl))as yc,T_FileList.bz FROM T_FileList "
                        + "INNER JOIN T_Archive ON T_Archive.ArchiveID = T_FileList.ArchiveID where fileStatus='6' and T_FileList.ArchiveID='" 
                        + archiveID + "' Order by ArchiveIndex ";
            DataSet ds = DbHelperOleDb.Query(sql);
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 打印工程下已组卷的文件信息  文件登记
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <returns></returns>
        public DataView Print_ProjectFile(string ProjectNO)
        {
            // string sql = "SELECT T_FileList.*, T_Projects.projectname FROM T_FileList INNER JOIN T_Projects ON T_FileList.ProjectNO = T_Projects.ProjectNO where  T_FileList.fileID in (select fileID from Attachment where ArchiveID<>'1' and  Attachment.ProjectNO='" + ProjectNO + "');";
            string sql = "SELECT T_FileList.*, T_Projects.projectname FROM T_FileList INNER JOIN T_Projects ON T_FileList.ProjectNO = T_Projects.ProjectNO where T_FileList.fileStatus='6' and T_FileList.ProjectNO='" + ProjectNO + "'";// Order by ArchiveIndex
            DataSet ds = DbHelperOleDb.Query(sql);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                foreach (DataRow rv in ds.Tables[0].Rows)
                {
                    if (rv["CreateDate2"].ToString()!="")
                    {
                        rv["CreateDate"] = rv["CreateDate"] + "-\r\n"+ rv["CreateDate2"];
                    }
                }
            }
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 项目工程信息
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <returns></returns>
        public DataView Print_Project_Item(string ProjectNO)
        {
            string sql = @"SELECT T_Projects.ProjectNO, T_Item.ConstructionProjectAdd, T_Item.ConStructionProjectName, T_Projects.projectname, T_Projects.address,(select top 1 dwmc from T_Units where unittype='unit1' and ProjectNo='" + ProjectNO + "') as dwmc,(select top 1 tel from T_Units where unittype='unit1' and ProjectNo='" + ProjectNO + "') as tel FROM T_Projects INNER JOIN T_Item ON T_Projects.ItemID = T_Item.ItemID where T_Projects.ProjectNo='" + ProjectNO + "'";
            DataView dv = DbHelperOleDb.Query(sql).Tables[0].DefaultView;
            return dv;
        }

        public DataTable ExportArchive(string ArchiveID,string ProjectNO)
        {
            string sql = "Select 0 as 序号,a.ajtm as 案卷题名,(Cint(a.dtz) + Cint(a.tzz) + Cint(a.wzz)) as 页数,Cint(a.wzz) as 文字页,"
                       + "(Cint(a.dtz) + Cint(a.tzz)) as 图纸页,a.bz as 备注 from T_Archive as a where a.archiveID='" + ArchiveID + "' "
                       + "or a.ProjectNO='" + ProjectNO + "' ";
            DataSet ds = DbHelperOleDb.Query(sql);

            return ds.Tables[0];
        }
        public DataTable JNMLData(DataTable dt, string type)
        {
            int curnum = 1;
            if (type == "export")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sl = (Convert.ToInt32(dt.Rows[i]["yc"]));
                    if (sl == 0)
                    {
                        sl = 1;
                        if (i < dt.Rows.Count - 1)
                        {
                            dt.Rows[i]["yc"] = curnum.ToString();
                        }
                        else
                        {
                            dt.Rows[i]["yc"] = curnum.ToString() + "-" + (curnum - 1 + sl);
                        }
                        curnum = curnum + sl;
                    }
                    else
                    {
                        if (i < dt.Rows.Count - 1)
                        {
                            dt.Rows[i]["yc"] = curnum.ToString();
                        }
                        else
                        {
                            dt.Rows[i]["yc"] = curnum.ToString() + "-" + (curnum - 1 + sl);
                        }
                        curnum = curnum + sl;
                    }
                }
            }
            else if (type == "import")
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (j == dt.Rows.Count - 1)
                    {
                        string []t = dt.Rows[j]["页次"].ToString().Split('-');
                        if (t.Length == 1)
                        {
                           // dt.Rows[j]["页次"] = (Convert.ToInt32(t[0]) - curnum).ToString();
                            dt.Rows[j]["页次"] = "0";
                        }
                        else if (Convert.ToInt32(t[0])>Convert.ToInt32(t[1]))
                        {
                             dt.Rows[j]["页次"] = "0";
                        }
                        else
                        {
                            dt.Rows[j]["页次"] = (Convert.ToInt32(t[1]) - Convert.ToInt32(t[0]) + 1).ToString();
                        }
                    }
                    else if (j == dt.Rows.Count - 2)
                    {
                        string[] t = dt.Rows[j + 1]["页次"].ToString().Split('-');
                        dt.Rows[j]["页次"] = (Convert.ToInt32(t[0]) -
                                             Convert.ToInt32(dt.Rows[j]["页次"])).ToString();
                    }
                    else
                    {
                        dt.Rows[j]["页次"] = (Convert.ToInt32(dt.Rows[j + 1]["页次"]) - 
                                              Convert.ToInt32(dt.Rows[j]["页次"])).ToString();
                    }
                }
            }
            return dt;
        }
    }
}
