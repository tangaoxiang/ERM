/*
   作者：  张建宏
 * 日期：2008-12-18
 * 功能：文件组卷
 * 备注：此组卷功能 要有以下约定 才能正常运行 Attachment电子文件登记表中的信息
 *       1 一个电子文件不能属于两个案卷 
 *       2 一个电子文件的页数不能超过案卷的最大页数 即案卷的稳定值+浮动值
 *       3 电子文件合并顾PDF 其页数比为1：1  也就是说1页PDF对应1页的原始文件
 *       
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Digi.DBUtility;//请先添加引用
using ERM.MDL;
using System.Windows.Forms;
namespace ERM.CBLL
{
    public class FinalArchive
    {
        ERM.BLL.T_Archive_BLL FinalArchiveDB = new ERM.BLL.T_Archive_BLL();
        ERM.BLL.T_FileList_BLL FinalFileDB = new ERM.BLL.T_FileList_BLL();
        ERM.BLL.PageSize PageSizeDB = new ERM.BLL.PageSize();
        
        /// <summary>
        /// 得到模板下所有已选择的文件
        /// </summary>
        /// <param name="ArchiveID"></param>
        /// <param name="ProjectNO"></param>
        /// <returns></returns>
        public DataSet GetgFinal_archivePDFByCheck(string Sqlwhere, string ProjectNO)
        {
            string sql = @"select * from (SELECT  b.FileID, b.wjtm, b.filepath,b.ProjectNO,b.ArchiveID ,min(a.OrderIndex) as OrderIndex2
                                              FROM T_CellAndEFile a, T_FileList b   
                                           where a.fileID = b.FileID  and b.ProjectNO='" + ProjectNO + @"' " + Sqlwhere + @"
                                            group by b.FileID, b.wjtm, b.filepath,b.ProjectNO,b.ArchiveID) order by OrderIndex2";
            DataSet ds = DbHelperOleDb.Query(sql);
            return ds;
        }
        /// <summary>
        /// 得到模板下所有已选择的文件起始页
        /// </summary>
        /// <param name="ArchiveID"></param>
        /// <param name="ProjectNO"></param>
        /// <returns></returns>
        public int GetgFinal_archivePDFByCheckStartPageNo(string Sqlwhere, string ProjectNO, string ArchiveID)
        {
            string sql = @"select sum(ys) as [count]  from T_CellAndEFile where OrderIndex<(select top 1 OrderIndex from (SELECT b.FileID, b.wjtm, b.filepath,b.ProjectNO,b.ArchiveID,min(a.OrderIndex) as OrderIndex,a.ys
                                              FROM T_CellAndEFile a, T_FileList b   
                                           where a.fileID = b.FileID and b.ProjectNO='" + ProjectNO + @"' " + Sqlwhere + @"
                                           group by   b.FileID, b.wjtm, b.filepath,b.ProjectNO,b.ArchiveID,a.ys))";
            DataSet ds = DbHelperOleDb.Query(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && (!String.IsNullOrEmpty(ds.Tables[0].Rows[0]["count"].ToString())))
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["count"]);
            }
            return 0;
        }
        /// <summary>
        /// 调整按卷顺序
        /// </summary>
        /// <param name="Node"></param>
        public void MoveAFinalArchiveOrderindex(TreeNode Node)　//调整按卷顺序
        {
            if (Node != null && Node.Parent != null)
            {
                BLL.T_Archive_BLL archiveBLL = new ERM.BLL.T_Archive_BLL();
                for (int i = 0; i < Node.Parent.Nodes.Count; i++)
                {
                    string ArchiveID = Node.Parent.Nodes[i].Tag.ToString();
                    int orderindex = i + 1;
                    MDL.T_Archive archiveMDL = archiveBLL.Find(ArchiveID);
                    archiveMDL.OrderIndex = orderindex;
                    archiveBLL.Update(archiveMDL);
                }
            }
        }
        /// <summary>
        /// 调整按卷顺序
        /// </summary>
        /// <param name="Node"></param>
        public void MoveArchiveOrderindex(TreeNode Node)　//调整按卷顺序
        {
            if (Node != null)
            {
                BLL.T_Archive_BLL archiveBLL = new ERM.BLL.T_Archive_BLL();
                for (int i = 0; i < Node.Nodes.Count; i++)
                {
                    string ArchiveID = Node.Nodes[i].Tag.ToString();
                    int orderindex = i + 1;
                    MDL.T_Archive archiveMDL = archiveBLL.Find(ArchiveID);
                    archiveMDL.OrderIndex = orderindex;
                    archiveBLL.Update(archiveMDL);
                }
            }
        }
        /// <summary>
        /// 调整　电子文件表中记录　在案卷中的顺序号
        /// </summary>
        /// <param name="Node"></param>
        public void MoveFinalAttachment_ArchIndex(TreeNode Node, string ArchiveID, string ProjectNO)
        {
            ERM.BLL.T_FileList_BLL fileList_bll = new ERM.BLL.T_FileList_BLL();//文件操作类 2011-3-17 from YQ
            if (Node != null && Node.Parent != null)
            {
                int orderindex2 = 1;
                for (int i = 0; i < Node.Parent.Nodes.Count; i++)
                {
                    string FileID = Node.Parent.Nodes[i].Name.ToString();//文件登记表中的ID                
                    T_FileList moveFileList = fileList_bll.Find(FileID, ProjectNO);
                    moveFileList.ArchiveIndex = orderindex2++;
                    fileList_bll.Update(moveFileList);
                }
            }
        }
    }//endclass
}//emdmonth
