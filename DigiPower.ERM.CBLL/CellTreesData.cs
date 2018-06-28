using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Digi.DBUtility;
using ERM.MDL;
namespace ERM.CBLL
{
    public class CellTreesData
    {
        public IList<MDL.T_CellAndEFile> GetNodeChildren(string nodeid, string ProjectNO, string path)
        {
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = cellBLL.FindByFileID(nodeid, ProjectNO, 1);

            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            IList<MDL.T_FileList> fileList = fileBLL.FindByParentID(nodeid, ProjectNO);
            foreach (MDL.T_FileList fileMDL in fileList)
            {
                IList<MDL.T_CellAndEFile> cellList2 = GetNodeChildren(fileMDL.FileID, ProjectNO, path);
                foreach (MDL.T_CellAndEFile obj in cellList2)
                {
                    cellList.Add(obj);
                }
            }
            return cellList;
        }

        public IList<MDL.T_CellAndEFile> GetNodeChildren(string nodeid, string ProjectNO, string path, int type_flg)
        {
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            IList<MDL.T_CellAndEFile> cellList = (type_flg == 0 ? cellBLL.FindByFileID(nodeid, ProjectNO) : cellBLL.FindByFileID(nodeid, ProjectNO, 1));

            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            IList<MDL.T_FileList> fileList = fileBLL.FindByParentID(nodeid, ProjectNO);
            foreach (MDL.T_FileList fileMDL in fileList)
            {
                IList<MDL.T_CellAndEFile> cellList2 = GetNodeChildren(fileMDL.FileID, ProjectNO, path, type_flg);
                foreach (MDL.T_CellAndEFile obj in cellList2)
                {
                    cellList.Add(obj);
                }
            }
            return cellList;
        }
        public DataSet GetTrees(bool isBack, string ProjectNO)
        {
            return new DataSet();
        }
        /// <summary>
        /// 删除一个用户做的表格
        /// </summary>
        /// <param name="cellParentid"></param>
        public DataSet DelArchiveData(string cellParentid, string ProjectNO)
        {
            string sql = "select * from archivedata where cellparentid='" + cellParentid + "' and ProjectNO='" + ProjectNO + "'";
            DataSet ds = DbHelperOleDb.Query(sql);
            sql = "delete from archivedata where cellparentid= '" + cellParentid + "' and ProjectNO='" + ProjectNO + "'";
            try
            {
                DbHelperOleDb.ExecuteSql(sql);
            }
            catch (Exception e)
            {
                throw e;
            }
            return ds;
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="nodeid"></param>
        /// <param name="title"></param>
        /// <param name="codeno"></param>
        /// <param name="filerecord"></param>
        /// <param name="cellTemplet"></param>
        /// <returns></returns>
        public IList<MDL.T_FileList> DoFind(string nodeid, string title, string codeno, bool filerecord, bool cellTemplet, string ProjectNO)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = new T_FileList();
            fileMDL.wjtm = title;
            fileMDL.table_name = title;
            fileMDL.ProjectNO = ProjectNO;
            IList<MDL.T_FileList> fileList = fileBLL.FindByKeyString(fileMDL);
            return fileList;
        }
    }
}
