using System;
using System.Collections.Generic;
using System.Text;
using ERM.BLL;
using ERM.MDL;
namespace ERM.BLL
{
    public class BLLMore : IBLL
    {
        public void CopyFileList(string _projectNO,string _projectCategory)
        {
            BLL.T_FileList_BLL B1 = new T_FileList_BLL();
            IList<MDL.T_FileList> fileList = (new BLL.T_FileList_BLL()).FindByProjectNO(_projectNO);
            if (fileList.Count <= 0)
            {
                T_FileList file = new T_FileList();
                T_GdList gd = new T_GdList();

                gd.ProjectNo = _projectNO;
                gd.ProjectCategory = _projectCategory;
                file.ProjectNO = _projectNO;
                file.ProjectCategory = _projectCategory;

                String stmtId = "T_FileList.CopyFileList";
                MyISqlMap.QueryForObject<int>(stmtId, file);

                stmtId = "T_CellAndEFile.CopyCellFileList";
                MyISqlMap.QueryForObject<int>(stmtId, _projectNO);

                stmtId = "T_GdList.CopyGdList";
                MyISqlMap.QueryForObject<int>(stmtId, gd);
            }
        }
        public void DeleteUnitByProjectNO(string _projectNO)
        {
            String stmtId = "T_Units.DeleteUnitByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }
        public void DeleteFileListByProjectNO(string _projectNO)
        {
            String stmtId = "T_FileList.DeleteFileListByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }
        public void DeleteCellFileByProjectNO(string _projectNO)
        {
            String stmtId = "T_CellAndEFile.DeleteCellFileByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }
        public void DeleteArchiveByProjectNO(string _projectNO)
        {
            String stmtId = "T_Archive.DeleteArchiveByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }
        public void DeleteGdFileByProjectNO(string _projectNO)
        {
            String stmtId = "T_GdList.DeleteGdFileByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }

        public void DeleteTrafficByProjectNO(string _projectNO)
        {
            String stmtId1 = "T_Traffic.QueryTraffic_ByProjID";
            T_Traffic result = MyISqlMap.QueryForObject<T_Traffic>(stmtId1, _projectNO);
            if (result != null)
            {
                //删除交通详细
                String stmtId2 = "T_Traffic_Detail.DeleteTrafficDetailByTrafficID";
                int res = MyISqlMap.QueryForObject<int>(stmtId2, result.ID);
            }
            //删除交通主信息
            String stmtId = "T_Traffic.DeleteTrafficByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }

        public void DeleteBrigeByProjectNO(string _projectNO)
        {
            String stmtId = "T_Project_Brige.DeleteBrigeByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }

        public void DeleteRoadLampByProjectNO(string _projectNO)
        {
            String stmtId = "T_Project_RoadLamp.DeleteRoadLampByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }

        public System.Data.DataSet GetListArchive(string _projectNO, string ArchiveID)
        {
            String stmtId = "T_Archive.GetListArchive";
            MDL.T_Archive obj = new ERM.MDL.T_Archive();
            obj.ProjectNO = _projectNO;
            obj.ArchiveID = ArchiveID;
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetListFile(string _projectNO, string ArchiveID)
        {
            String stmtId = "T_FileList.GetListFile";
            MDL.T_FileList obj = new ERM.MDL.T_FileList();
            obj.ProjectNO = _projectNO;
            obj.ArchiveID = ArchiveID;
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }

        public void CopyFileAndEFileList(string s_projectNO, string t_projectNO)
        {
            MDL.T_FileList obj = new MDL.T_FileList();
            obj.ProjectNO = s_projectNO;
            obj.ParentID = t_projectNO;
            String stmtId = "T_FileList.CopyFileListByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, obj);

            MDL.T_CellAndEFile obj2 = new MDL.T_CellAndEFile();
            obj2.ProjectNO = s_projectNO;
            obj2.FileID = t_projectNO;
            stmtId = "T_CellAndEFile.CopyCellFileListByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, obj2);


            MDL.T_GdList obj3 = new MDL.T_GdList();
            obj3.ProjectNo = s_projectNO;
            obj3.ID = t_projectNO;
            stmtId = "T_GdList.CopyGdFileByProjectNO";
            MyISqlMap.QueryForObject<int>(stmtId, obj3);
        }
        /// <summary>
        /// 删除归档记录
        /// </summary>
        /// <param name="_projectNO"></param>
        public void DeleteGdListByProjectNO(string _projectNO)
        {
            String stmtId = "T_GdList.DeleteProjectNo";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }

        /// <summary>
        /// 删除坐标信息
        /// </summary>
        /// <param name="_projectNO"></param>
        public void DeletePointByPorjectNo(string _projectNO)
        {
            String stmtId = "T_Point.DeleteByProjectNo";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }

        /// <summary>
        /// 删除原文信息
        /// </summary>
        /// <param name="_projectNO"></param>
        public void DeleteYW_CellAndEFileByPorjectNo(string _projectNO)
        {
            String stmtId = "T_YW_CellAndEFile.DeleteByProjectNo";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);
        }
    }
}
