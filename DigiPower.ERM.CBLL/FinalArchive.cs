/*
   ���ߣ�  �Ž���
 * ���ڣ�2008-12-18
 * ���ܣ��ļ����
 * ��ע��������� Ҫ������Լ�� ������������ Attachment�����ļ��ǼǱ��е���Ϣ
 *       1 һ�������ļ����������������� 
 *       2 һ�������ļ���ҳ�����ܳ�����������ҳ�� ��������ȶ�ֵ+����ֵ
 *       3 �����ļ��ϲ���PDF ��ҳ����Ϊ1��1  Ҳ����˵1ҳPDF��Ӧ1ҳ��ԭʼ�ļ�
 *       
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Digi.DBUtility;//�����������
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
        /// �õ�ģ����������ѡ����ļ�
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
        /// �õ�ģ����������ѡ����ļ���ʼҳ
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
        /// ��������˳��
        /// </summary>
        /// <param name="Node"></param>
        public void MoveAFinalArchiveOrderindex(TreeNode Node)��//��������˳��
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
        /// ��������˳��
        /// </summary>
        /// <param name="Node"></param>
        public void MoveArchiveOrderindex(TreeNode Node)��//��������˳��
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
        /// �����������ļ����м�¼���ڰ����е�˳���
        /// </summary>
        /// <param name="Node"></param>
        public void MoveFinalAttachment_ArchIndex(TreeNode Node, string ArchiveID, string ProjectNO)
        {
            ERM.BLL.T_FileList_BLL fileList_bll = new ERM.BLL.T_FileList_BLL();//�ļ������� 2011-3-17 from YQ
            if (Node != null && Node.Parent != null)
            {
                int orderindex2 = 1;
                for (int i = 0; i < Node.Parent.Nodes.Count; i++)
                {
                    string FileID = Node.Parent.Nodes[i].Name.ToString();//�ļ��ǼǱ��е�ID                
                    T_FileList moveFileList = fileList_bll.Find(FileID, ProjectNO);
                    moveFileList.ArchiveIndex = orderindex2++;
                    fileList_bll.Update(moveFileList);
                }
            }
        }
    }//endclass
}//emdmonth
