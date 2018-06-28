using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using Digi.DBUtility;
namespace ERM.CBLL
{
    public class FileRegist
    {
        private readonly ERM.DAL.FileRegist dal = new ERM.DAL.FileRegist();
        public FileRegist()
        { }
        /// <summary>
        /// 更新文件登记表签章状态
        /// </summary>
        /// <param name="Filepath"></param>
        /// <param name="ProjectNo"></param>
        /// <param name="Issign"></param>
        public void UpdateRegistIssign(string Filepath, string ProjectNo,int Issign)
        {
            string Sql = "update T_FileList set issign = " + Issign + " where filepath = '" + Filepath + "' and ProjectNO = '" + ProjectNo + "' ";
            DbHelperOleDb.ExecuteSql(Sql);
        }
        public int GetMpdfPageSize(string TreePath, string ProjectNo)
        {
            string Sql = "select sl from T_FileList where treepath = '" + TreePath + "' and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        public string GetIsSign(string TreePath, string ProjectNo)
        {
            string Sql = "select IsSign from T_FileList where treepath = '" + TreePath + "' and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        public string GetFileID(string TreePath, string ProjectNo)
        {
            string Sql = "select FileID from T_FileList where treepath = '" + TreePath + "' and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        public string GetFilePID(string TreePath,string ProjectNo)
        {
            string Sql = "select id from FileRecording_Templet where treepath = '"+ TreePath +"' and ProjectNO = '"+ ProjectNo +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        /// <summary>
        /// 取节点下的登记文件集合
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet GetWillCheckTemplate(string ID, string Projectno)
        {
            string Sql = "select * from T_FileList where parentid like '" + ID + "%' and ProjectNO = '"+ Projectno +"' and filestatus = '1'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 取节点下的登记文件集合
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet GetWillSigntureTemplate(string ID, string Projectno)
        {
            string Sql = "select * from T_FileList where parentid like '" + ID + "%' and ProjectNO = '" + Projectno + "' and filestatus = '4'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 取节点下的要打印的登记文件集合
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet GetWillPrintTemplate(string ID, string Projectno, string Path)
        {
            string Sql = "select wjtm as title,'" + Path + "' + filepath as filed from T_FileList where parentid like '" + ID + "%' and ProjectNO = '" + Projectno + "' and (filestatus = '4' or filestatus = '1')";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 取节点下的登记文件集合
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet GetWillUnSigntureTemplate(string ID, string Projectno)
        {
            string Sql = "select * from T_FileList where parentid like '" + ID + "%' and ProjectNO = '" + Projectno + "' and filestatus = '4' and issign = 1";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 取模板最大ID
        /// </summary>
        /// <param name="Treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public string GetTemplateMaxID(string Treepath, string Projectno)
        {
            string Sql = "select id from Cell_Templet where ptreepath = '" + Treepath + "' and ProjectNO = '" + Projectno + "'  order by id desc";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        /// <summary>
        /// 取模板title
        /// </summary>
        /// <param name="Treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet GetTemplateTitle(string Treepath, string Projectno)
        {
            string Sql = "select title from Cell_Templet where ptreepath = '"+ Treepath +"' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 档案馆添加自定义模板时取路径
        /// </summary>
        /// <param name="Treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public string GetUserTemplatePath(string Treepath, string Projectno)
        {
            string Sql = "select treepath from FileRecording_Templet where table_name in (select table_name from NewFileRecording_Templet where treepath = '"+ Treepath +"') and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        public bool GetNewFileRecording_TempletHasTable_Name(string TreePath)
        {
            string Sql = "select table_name from NewFileRecording_Templet where treepath = '"+ TreePath +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        public void DeleteNewFileRecording_TempletCountByTreepath(string TreePath)
        {
            string Sql = "delete from NewFileRecording_Templet where treepath in ("+ TreePath +")";
            try
            {
                DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public bool GetNewFileRecording_TempletCountlist(string Treepath)
        {
            string Sql = "select count(*) from NewFileRecording_Templet where Ptreepath = '" + Treepath + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if ((!String.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString())) && Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString())>0)
                {
                    return true;
                }
            }
            return false; ;
        }
        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="Treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public int GetNewFileRecording_TempletCount(string Treepath)
        {
            string Sql = "select count(*) from NewFileRecording_Templet where treepath = '" + Treepath + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            return 0; ;
        }
        /// <summary>
        /// 根据子路径找父路径
        /// </summary>
        /// <param name="Treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet Getfinal_filePtreePth(string Treepath, string Projectno)
        {
            string Sql = "select Ptreepath,parentid from Cell_Templet where treepath = '" + Treepath + "' and ProjectNO = '" + Projectno + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 根据档案馆树路径取各单位树路径
        /// </summary>
        /// <param name="treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public string GetNewPTreepath(string treepath, string Projectno)
        {
            string Sql = "select TreePath from Cell_Templet where ptreepath = (select treepath from FileRecording_Templet where table_name = (select table_name from NewFileRecording_Templet where treepath = '" + treepath + "' and  table_name<>'') and ProjectNO = '" + Projectno + "') and ProjectNO = '" + Projectno + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        /// <summary>
        /// 取档案馆树文件夹路径
        /// </summary>
        /// <param name="treepath"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        /// <summary>
        /// 后台档案馆树
        /// </summary>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet GetNewFileRecording_Templet(string Projectno)
        {
            string Sql = "select B.id,len(B.id) as length,left(B.id,len(B.id)-2) as parentid,B.title,B.table_name,1 as imageindex,isvisible,orderindex,B.PTreePath as ParentPath,B.treepath from FileRecording_Templet A right join NewFileRecording_Templet B on A.table_name = B.table_name where A.isvisible=1 and A.ProjectNO='"+ Projectno +"' union select id,len(id) as length,left(id,len(id)-2) ,title,table_name,1 as imageindex,1,'',ptreepath  as ParentPath,treepath from NewFileRecording_Templet where table_name='kongbai' order by length";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 文件登记档案馆树
        /// </summary>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet RegistGetNewFileRecording_Templet(string Projectno)
        {
            string Sql = "SELECT E.filepath,(F.id + right(E.id,2)) as id,len(F.id + right(E.id,2)) as length,F.id as parentid, E.title, F.table_name,2 as imageindex,E.isvisible,E.orderindex as orderindex,E.PTreePath as ParentPath, E.TreePath FROM Cell_Templet AS E RIGHT JOIN (SELECT D.id, D.title, D.table_name, C.ProjectNO, C.TreePath as path, C.pTreePath FROM FileRecording_Templet AS C RIGHT JOIN NewFileRecording_Templet AS D ON C.table_name = D.table_name WHERE (((C.ProjectNO)='" + Projectno + "' and c.table_name<>''))) AS F ON E.PTreePath = F.path WHERE (((E.ProjectNO)='" + Projectno + "')) union (select '',B.id,len(B.id) as length,left(B.id,len(B.id)-2) as parentid,B.title,B.table_name,1 as imageindex,isvisible,orderindex,A.PTreePath as ParentPath,A.treepath from FileRecording_Templet A right join NewFileRecording_Templet B on A.table_name = B.table_name where A.isvisible=1 and A.ProjectNO='digipower' union select '',id,len(id) as length,left(id,len(id)-2) ,title,table_name,1 as imageindex,1,'',ptreepath  as ParentPath,treepath from NewFileRecording_Templet where table_name='kongbai') order by length,orderindex";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        public DataSet GetSearchDS(string Projectno, string KeyString)
        {
            string Sql = "(SELECT distinct id FROM Cell_Templet where ProjectNO='" + Projectno + "' and (title like '%" + KeyString + "%'or codeno like '%" + KeyString + "%') union select distinct id from NewFileRecording_Templet where table_name='kongbai' and title like '%" + KeyString + "%')";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 工程资料用表中获取模版级的文件列表
        /// </summary>
        /// <returns>查询数据集</returns>
        public DataSet GetTreeForTemplate(string Projectno)
        {
            string Sql = "select id,len(id) as length,parentid,title,filepath,examplepath,codeno,2 as imageindex,codetype,fbmc,fxmc,zfbmc,sl,isvisible,orderindex,customdefine,zrr,PTreePath as ParentPath,treepath from Cell_Templet where ProjectNO = '"+ Projectno +"' UNION select id,len(id) as length,left(id,len(id)-2)  ,gdwj,'','','',1 as imageindex,0 as codetype,'','','',0,isvisible,orderindex,0,zrr,PTreePath  as ParentPath,treepath from filerecording_templet where cjdag='1' and ProjectNO = '"+ Projectno +"' order by length,orderindex";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 文件登记中获取已提交的模版级的文件列表
        /// </summary>
        /// <returns>查询数据集</returns>
        public DataSet GetIsCheckedTemplate(string ProjectNO)
        {
            string Sql = "select * from T_FileList where ProjectNO ='" + ProjectNO + "' and fileStatus='1'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 文件登记中获取已提交的模版级的文件列表
        /// </summary>
        /// <returns>查询数据集</returns>
        public DataSet GetNoCheckedTemplate(string ProjectNO)
        {
            string Sql = "select * from T_FileList where ProjectNO ='" + ProjectNO + "' and fileStatus<>'1'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 文件登记中获取已登记的模版级的文件列表
        /// </summary>
        /// <returns>查询数据集</returns>
        public DataSet GetIsRegistTemplate(string ProjectNO)
        {
            string Sql = "select * from T_FileList where ProjectNO ='" + ProjectNO + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 取对应模版提交后的电子文件列表
        /// </summary>
        /// <param name="FullPath"></param>
        /// <returns></returns>
        public DataSet GetDocuments(string FullPath,string Projectno)
        {
            string Sql = "select * from ArchiveData where cellParentid = (select id from Cell_Templet where TreePath = '"+FullPath+"' ) and docstatus = 1 and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            return ds;
        }
        /// <summary>
        /// 添加文件登记
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddFileRegist(ERM.MDL.T_FileList model)
        {
            try
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                fileBLL.Add(model);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 修改文件登记
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int EditFileRegist(ERM.MDL.T_FileList model)
        {
            try
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                fileBLL.Update(model);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 取文件登记数量统计项目
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Projectno"></param>
        /// <returns></returns>
        public DataSet FindFileRegistNum(string Path, string Projectno)
        {
            string Sql = "select Fileid,tzz,dtz,zpz,dpz from T_FileList where TreePath = '" + Path + "' and ProjectNO = '" + Projectno + "'";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 根据节点路径查找文件登记ID
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string FindFileRegistID(string Path,string Projectno)
        {
            string Sql = "select Fileid from T_FileList where TreePath = '" + Path + "' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
        /// <summary>
        /// 添加文件登记电子文件列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <summary>
        /// 添加工程资料用表电子文件列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <summary>
        /// 取工程资料用表电子文件原始文件路径
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public string GetArchiveDataID(string TreePath,string Projectno)
        {
            string Sql = "select ID from ArchiveData where treepath = '" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["ID"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取工程资料用表电子文件原始文件路径
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public string GetArchiveDataFilepath(string TreePath,string Projectno)
        {
            string Sql = "select filepath from ArchiveData where treepath = '" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["filepath"].ToString();
            }
            else
            {
                return null;
            }
        }
        public int UpdateArchiveDataYs(int PageCount,string TreePath,string Projectno)
        {
            string Sql = "update ArchiveData set ys = " + PageCount + " where treepath = '" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// 根据title和父路径取文件登记电子文件pdf路径
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fileTreePath"></param>
        /// <returns></returns>
        public string GetAttachmentPdfPath(string title, string fileTreePath,string ProjectNo)
        {
            string Sql = "select filepath from Attachment where fileTreePath = '" + fileTreePath + "' and title = '" + title + "' and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["filepath"].ToString();
            }
            return null;
        }
        /// <summary>
        /// 根据ID和工程号取文件夹数量
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ProjectNo"></param>
        /// <returns></returns>
        public int GetFileRecording_Templet(string ID, string ProjectNo)
        {
            string Sql = "select count(*) from FileRecording_Templet where id = '" + ID + "' and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        /// <summary>
        /// 根据ID和工程号取文件夹数量
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="ProjectNo"></param>
        /// <returns></returns>
        public int IsHaveGetNewFileRecording_Templet(string TreePath)
        {
            string Sql = "select count(*) from NewFileRecording_Templet where treepath = '"+ TreePath +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        /// <summary>
        /// 根据title和父路径取文件登记数量
        /// </summary>
        /// <param name="title"></param>
        /// <param name="fileTreePath"></param>
        /// <returns></returns>
        public int GetAttachmentFilePath(string title, string fileTreePath,string Projectno)
        {
            string Sql = "select count(*) from Attachment where fileTreePath = '" + fileTreePath + "' and title = '" + title + "' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        /// <summary>
        /// 根据父路径和工程编号取电子文件格式集合
        /// </summary>
        /// <param name="ProjectNo"></param>
        /// <param name="PTreePath"></param>
        /// <returns></returns>
        public string GetWJGS(string ProjectNo,string PTreePath)
        {
            string Sql = "select distinct mid(yswjpath,(len(filepath)-2),3) as wjgslist from Attachment where fileTreePath ='" + PTreePath + "' and ProjectNO = '"+ ProjectNo +"' ";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append(dr["wjgslist"].ToString());
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            return "";
        }
        /// <summary>
        /// 判断工程资料用表表中是否有此非外部添加模版记录
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public int GetCell_TempletHasRegist(string TreePath,string ProjectNo)
        {
            string Sql = "select count(*) from Cell_Templet where TreePath = '" + TreePath + "' and customdefine =0 and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            try
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 根据父路径判断是否有电子文件
        /// </summary>
        /// <param name="fileTreePath"></param>
        /// <returns></returns>
        public int GetAttachmentList(string fileTreePath, string ProjectNO)
        {
            string Sql = "select count(*) from Attachment where fileTreePath = '" + fileTreePath + "' and ProjectNO = '" + ProjectNO + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            try
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 取电子文件在文件登记中的序号
        /// </summary>
        /// <param name="fileTreePath"></param>
        /// <returns></returns>
        public string GetAttachmentFileOrderIndex(string fileTreePath, string ProjectNO, string Title)
        {
            string Sql = "select FileOrderIndex from Attachment where fileTreePath = '" + fileTreePath + "' and ProjectNO = '" + ProjectNO + "' and title = '"+ Title +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            try
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["FileOrderIndex"].ToString();
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        /// <summary>
        /// 更新电子文件在文件登记中的序号
        /// </summary>
        /// <param name="PTreePath"></param>
        /// <param name="ProjectNo"></param>
        /// <returns></returns>
        public int UpdateAttachmentFileOrderIndex(string fileTreePath, string ProjectNo, string FileOrderIndex,string Title)
        {
            string Sql = "update Attachment set FileOrderIndex = " + FileOrderIndex + " where fileTreePath = '" + fileTreePath + "' and ProjectNO = '" + ProjectNo + "' and title = '" + Title + "'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 根据title取登记电子文件
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        public DataSet IsHaveRegistList(string Title, string fileTreePath,string Projectno)
        {
            string Sql = "select * from Attachment where title = '" + Title + "' and fileTreePath='"+fileTreePath+"' and ProjectNO='"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.Query(Sql);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 更新文件登记表
        /// </summary>
        /// <param name="FileID"></param>
        /// <param name="PDFCount"></param>
        /// <returns></returns>
        public int UpdateFileRegist(string FileID, int PDFCount,string PDFFilePath,string TreePath,string PTreePath,int Level,string Count,int TzResult,int ZpResult,string tzz,string dtz,string zpz,string dpz,string Projectno)
        {
            string Sql = "update T_FileList set sl='" + PDFCount + "',fileStatus=4,filepath='" + PDFFilePath + "',wjdx = '"+ Count +"',dw = '"+ TzResult +"',wzz = '"+ ZpResult +"',tzz = '"+ tzz +"',dtz = '"+ dtz +"',zpz = '"+ zpz +"',dpz = '"+ dpz +"' where FileID='"+FileID+"' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 更新文件登记表电子文件title
        /// </summary>
        /// <param name="FileID"></param>
        /// <param name="PDFCount"></param>
        /// <returns></returns>
        public int UpdateAttachmentTitle(string PTreePath,string ProjectNo,string OldTitle,string NewTitle)
        {
            string Sql = "update Attachment set title='" + NewTitle + "' where fileTreePath = '" + PTreePath + "' and ProjectNO = '" + ProjectNo + "' and title = '" + OldTitle + "' ";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// 更新文件登记模板title
        /// </summary>
        /// <param name="FileID"></param>
        /// <param name="PDFCount"></param>
        /// <returns></returns>
        public int UpdateFinal_fileTitle(string NewTreePath, string ProjectNo, string OldTreePath)
        {
            string Sql = "update T_FileList set TreePath='" + NewTreePath + "' where TreePath = '" + OldTreePath + "' and ProjectNO = '" + ProjectNo + "'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 更新工程资料用表模板title
        /// </summary>
        /// <param name="FileID"></param>
        /// <param name="PDFCount"></param>
        /// <returns></returns>
        public int UpdateCell_TempletTitle(string NewTreePath, string ProjectNo, string OldTreePath,string Title)
        {
            string Sql = "update Cell_Templet set TreePath='" + NewTreePath + "',title = '"+ Title +"' where TreePath = '" + OldTreePath + "' and ProjectNO = '" + ProjectNo + "'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        public int UpdateAttachmentFilePath(string NewPTreePath, string OldPTreePath,string ProjectNo)
        {
            string Sql = "update Attachment set fileTreePath = '" + NewPTreePath + "' where fileTreePath = '" + OldPTreePath + "' and ProjectNO = '"+ ProjectNo +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// 反提交文件登记
        /// </summary>
        /// <param name="PDFFilePath"></param>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public int UnCheckUpdateFileRegist(string TreePath,string Projectno)
        {
            string Sql = "update T_FileList set fileStatus=1,filepath='',sl=0,wjdx='' where TreePath='" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// 取电子文件节点集合
        /// </summary>
        /// <param name="FullPath"></param>
        /// <returns></returns>
        public DataSet FindDocuments(string FullPath,string Projectno)
        {
            string Sql = "select treepath,ptreepath from ArchiveData where docstatus=1 and ptreepath like '%" + FullPath + "%' and ProjectNO = '"+ Projectno +"'";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 取形成文件树
        /// </summary>
        /// <returns></returns>
        public DataSet GetFileTree(string ProjectNO)
        {
            string Sql = "select id,len(id) as length,parentid,title,filepath,examplepath,codeno,2 as imageindex,codetype,fbmc,fxmc,zfbmc,ys,isvisible,orderindex,customdefine,zrr,0 as cjdag,PTreePath as ParentPath,treepath from Cell_Templet where isvisible=1 and ProjectNO='" + ProjectNO + "' UNION select id,len(id) as length,left(id,len(id)-2)  ,gdwj,'','','',1 as imageindex,0 as codetype,'','','',0,isvisible,orderindex,0,zrr,cjdag,PTreePath  as ParentPath,treepath from filerecording_templet where cjdag='1' and isvisible=1 and ProjectNO='" + ProjectNO + "' order by length,orderindex";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 取形成文件树
        /// </summary>
        /// <returns></returns>
        public DataSet GetFileChildTree(string ProjectNO)
        {
            string Sql = "select id,len(id) as length,parentid,title,filepath,examplepath,codeno,2 as imageindex,codetype,fbmc,fxmc,zfbmc,ys,isvisible,orderindex,customdefine,zrr,0 as cjdag,PTreePath as ParentPath,treepath from Cell_Templet where isvisible=1 and ProjectNO='" + ProjectNO + "' UNION select id,len(id) as length,left(id,len(id)-2)  ,gdwj,'','','',1 as imageindex,0 as codetype,'','','',0,isvisible,orderindex,0,zrr,cjdag,PTreePath  as ParentPath,treepath from filerecording_templet where cjdag='1' and isvisible=1 and ProjectNO='" + ProjectNO + "' order by length,orderindex";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 取各单位未登记的文件
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <returns></returns>
        public DataSet GetListNoInRegist(string ProjectNO)
        {
            string Sql = "select title,id from (select distinct * from (select id,len(id) as length,parentid,title,filepath,examplepath,codeno,2 as imageindex,codetype,fbmc,fxmc,zfbmc,ys,isvisible,orderindex,customdefine,zrr,0 as cjdag,PTreePath as ParentPath,treepath from Cell_Templet where isvisible=1 and ProjectNO='" + ProjectNO + "' UNION select id,len(id) as length,left(id,len(id)-2)  ,gdwj,'','','',1 as imageindex,0 as codetype,'','','',0,isvisible,orderindex,0,zrr,cjdag,PTreePath  as ParentPath,treepath from filerecording_templet where cjdag='1' and isvisible=1 and ProjectNO='" + ProjectNO + "' order by length,orderindex)  where treepath not in (select TreePath from T_FileList where ProjectNO='" + ProjectNO + "'and fileStatus='5')) order by mid(id,4)";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 取档案馆未登记的文件
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <returns></returns>
        public DataSet GetNewListNoInRegist(string ProjectNO)
        {
            string Sql = "select title,id from (select distinct * from (SELECT E.filepath,(F.id + right(E.id,2)) as id,len(F.id + right(E.id,2)) as length,F.id as parentid, F.title, F.table_name,2 as imageindex,E.isvisible,E.orderindex,E.PTreePath as ParentPath, E.TreePath FROM Cell_Templet AS E RIGHT JOIN [SELECT D.id, D.title, D.table_name, C.ProjectNO, C.TreePath as path, C.pTreePath FROM FileRecording_Templet AS C RIGHT JOIN NewFileRecording_Templet AS D ON C.table_name = D.table_name WHERE (((C.ProjectNO)='digipower' and c.table_name<>''))]. AS F ON E.PTreePath = F.path WHERE (((E.ProjectNO)='digipower')) union (select '',B.id,len(B.id) as length,left(B.id,len(B.id)-2) as parentid,B.title,B.table_name,1 as imageindex,isvisible,orderindex,A.PTreePath as ParentPath,A.treepath from FileRecording_Templet A right join NewFileRecording_Templet B on A.table_name = B.table_name where A.isvisible=1 and A.ProjectNO='digipower' union select '',id,len(id) as length,left(id,len(id)-2) ,title,table_name,1 as imageindex,1,'',ptreepath  as ParentPath,treepath from NewFileRecording_Templet where table_name='kongbai') order by length) where treepath not in (select TreePath from T_FileList where ProjectNO='"+ ProjectNO +"'and fileStatus='5')) order by mid(id,4)";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 根据路径取得文件登记信息
        /// </summary>
        /// <param name="PartentPath"></param>
        /// <returns></returns>
        public DataSet GetRegistValue222(string TreePath,string ProjectNO)
        {
            string Sql = "select * from T_FileList where TreePath = '" + TreePath + "' and ProjectNO ='" + ProjectNO + "' ";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 获取合并后的PDF路径
        /// </summary>
        /// <param name="PartentPath"></param>
        /// <returns></returns>
        public DataSet GetPdfPath(string PartentPath,string Projectno)
        {
            string Sql = "select * from T_FileList where TreePath = '" + PartentPath + "' and fileStatus=4 and ProjectNO = '"+ Projectno +"'";
            return DbHelperOleDb.Query(Sql);
        }
        public int GetArchiveData(string Ptreepath, string ProjectNo)
        {
            string Sql = "select count(*) from ArchiveData where ptreepath = '"+ Ptreepath +"' and ProjectNO = '"+ ProjectNo +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        /// <summary>
        /// 获取合并后的PDF路径
        /// </summary>
        /// <param name="PartentPath"></param>
        /// <returns></returns>
        public string GetMPdfPath(string TreePath,string Projectno)
        {
            string Sql = "select * from T_FileList where TreePath = '" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["filepath"].ToString();
            }
            return null;
        }
        /// <summary>
        /// 根据父路径取电子文件列表
        /// </summary>
        /// <param name="PartentPath"></param>
        /// <returns></returns>
        public DataSet GetAttachment(string PartentPath, string ProjectNO)
        {
            string Sql = "select * from Attachment where fileTreePath = '" + PartentPath + "' and ProjectNO = '" + ProjectNO + "' order by FileOrderIndex,attachid";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 根据父路径和文件编号取工程资料用表电子文件信息
        /// </summary>
        /// <param name="ptreepath"></param>
        /// <param name="projectNo"></param>
        /// <returns></returns>
        public DataSet GetArchiveDataAtPath(string ptreepath, string projectNo)
        {
            string Sql = "select * from ArchiveData where docstatus=1 and ptreepath='" + ptreepath + "' and ProjectNO='" + projectNo + "' order by orderindex";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 取文件登记下外部导入的电子文件数量
        /// </summary>
        /// <param name="ptreepath"></param>
        /// <param name="projectNo"></param>
        /// <returns></returns>
        public int GetAttachmentListWai(string ptreepath, string projectNo)
        {
            string Sql = "select count(*) from Attachment where fileTreePath = '" + ptreepath + "' and ProjectNO = '" + projectNo + "' and wjly = '外部导入'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            return 0;
        }
        public DataSet GetAttachmentListNei(string ptreepath, string projectNo)
        {
            string Sql = "select * from Attachment where fileTreePath = '" + ptreepath + "' and ProjectNO = '" + projectNo + "' and wjly = '系统内部'";
            return DbHelperOleDb.Query(Sql);
        }
        /// <summary>
        /// 工程资料用表和文件登记电子文件总数量
        /// </summary>
        /// <param name="ptreepath"></param>
        /// <param name="projectNo"></param>
        /// <returns></returns>
        public string GetAttachmentListCount(string ptreepath, string projectNo)
        {
            string Sql = "select top 1 ((select count(*) from Attachment where fileTreePath = '" + ptreepath + "' and ProjectNO = '" + projectNo + "' and wjly = '外部导入')+(select count(*) from ArchiveData where docstatus=1 and ptreepath='" + ptreepath + "' and ProjectNO='" + projectNo + "')) as listcount from FileRecording_Templet";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
         /// <summary>
        /// 工程资料用表和文件登记电子文件总数量
        /// </summary>
        /// <param name="ptreepath"></param>
        /// <param name="projectNo"></param>
        /// <returns></returns>
        public string GetAttachmentCheckListCount(string ptreepath, string projectNo)
        {
            string Sql = "select count(*) from Attachment where fileTreePath = '" + ptreepath + "' and ProjectNO = '" + projectNo + "' ";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return null;
        }
       /// <summary>
       /// 修改文件登记电子文件在登记文件中的顺序
       /// </summary>
       /// <param name="NewIndex">新顺序</param>
       /// <param name="title">名称</param>
       /// <param name="FileTreePath">父路径</param>
        public int EditFileOrderIndex(int NewIndex, string title, string FileTreePath,string Projectno)
        {
            string Sql = "update Attachment set FileOrderIndex = '" + NewIndex + "' where title = '" + title + "' and FileTreePath = '" + FileTreePath + "' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        /// <summary>
        /// 在文件登记电子文件表移除数据
        /// </summary>
        /// <param name="title"></param>
        /// <param name="FileTreePath"></param>
        /// <returns></returns>
        public int DeleteFileRecord(string title, string FileTreePath,string ProjectNo)
        {
            string Sql = "delete from Attachment where title = '" + title + "' and fileTreePath = '" + FileTreePath + "' and ProjectNO = '"+ ProjectNo +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
        public int DeleteFileRecording_Templet(string ID, string ProjectNo)
        {
            string Sql = "delete from FileRecording_Templet where id = '" + ID + "' and ProjectNO = '" + ProjectNo + "'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public int DeleteFileRecording_Templet(string TreePath)
        {
            string Sql = "delete from NewFileRecording_Templet where treepath = '"+ TreePath +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 修改工程资料用表电子文件在登记文件中的顺序
        /// </summary>
        /// <param name="NewIndex">新顺序</param>
        /// <param name="title">名称</param>
        /// <param name="FileTreePath">父路径</param>
        public int EditArchiveDataOrderIndex(int NewIndex, string title, string FileTreePath,string Projectno)
        {
            string Sql = "update ArchiveData set orderindex = '" + NewIndex + "' where title = '" + title + "' and ptreepath = '" + FileTreePath + "' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 在工程资料用表电子文件表移除数据
        /// </summary>
        /// <param name="title"></param>
        /// <param name="FileTreePath"></param>
        /// <returns></returns>
        public int DeleteArchiveDataRecord(string TreePath,string Projectno)
        {
            string Sql = "delete from ArchiveData where treepath = '" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public int DeleteCell_TempletRecord(string TreePath,string Projectno)
        {
            string Sql = "delete from Cell_Templet where treepath = '" + TreePath + "' and customdefine =1 and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 删除文件登记信息
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public int DeleteFinal_file(string TreePath,string Projectno)
        {
            string Sql = "delete from T_FileList where TreePath = '"+TreePath+"' and ProjectNO = '"+ Projectno +"'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 根据路径判断是否有文件登记
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public int GetFinal_fileCount(string TreePath,string Projectno)
        {
            string Sql = "select count(*) from T_FileList where TreePath = '" + TreePath + "' and ProjectNO = '"+ Projectno +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            try
            {
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 添加自定义模版到工程资料用表模版表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTemplate(ERM.MDL.T_CellAndEFile model)
        {
            string Sql = "insert into Cell_Templet (id,ProjectNO,TreePath,parentid,PTreePath,title,filepath,examplepath,codeno,customdefine,codetype,ys,orderindex,isvisible ) values('"+model.id+"','" + model.ProjectNO + "','" + model.TreePath + "','" + model.parentid + "','" + model.PTreePath + "','" + model.title + "','" + model.filepath + "','" + model.examplepath + "','" + model.codeno + "','" + model.customdefine + "','" + model.codetype + "',0,'" + model.orderindex + "','" + model.isvisible + "' )";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 获取文件登记状态
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public string GetRegistFileStatus(string TreePath,string ProjectNO)
        {
            string Sql = "select fileStatus from T_FileList where TreePath = '" + TreePath + "' and ProjectNO = '" + ProjectNO + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["fileStatus"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取工程资料用表是否外部添加
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public string GetCell_TempletCustomdefine(string TreePath)
        {
            string Sql = "select customdefine from Cell_Templet where treepath = '"+TreePath+"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["customdefine"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取文件登记电子文件是否外部添加
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public string GetAttachmentCustomdefine(string PTreePath,string Title,string ProjectNo)
        {
            string Sql = "select wjly from Attachment where fileTreePath = '" + PTreePath + "' and title ='" + Title + "' and ProjectNO = '"+ ProjectNo +"'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["wjly"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取工程资料用表电子文件是否外部添加
        /// </summary>
        /// <param name="TreePath"></param>
        /// <returns></returns>
        public string GetArchiveDataCustomdefine(string TreePath, string ProjectNo)
        {
            string Sql = "select customdefine from ArchiveData where treepath = '" + TreePath + "' and ProjectNO = '" + ProjectNo + "'";
            DataSet ds = DbHelperOleDb.Query(Sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["customdefine"].ToString();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 取电子文件原始文件路径集合
        /// </summary>
        /// <param name="FileID"></param>
        /// <returns></returns>
        public DataSet GetAttachmentyswjpath(string FileID)
        {
            string Sql = "select yswjpath,filepath from Attachment where fileID = '" + FileID + "'";
            return DbHelperOleDb.Query(Sql);
        }
        public int EditFinal_fileCreatetime(string TreePath, string ProjectNo)
        {
            string Sql = "update T_FileList set CreateDate2 = '" + DateTime.Now.ToString() + "' where TreePath = '" + TreePath + "' and ProjectNO = '" + ProjectNo + "'";
            try
            {
                return DbHelperOleDb.ExecuteSql(Sql);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
