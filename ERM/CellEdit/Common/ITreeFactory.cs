using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace ERM.UI
{
    public interface ITreeFactory
    {
        /// <summary>
        /// ��ȡ��
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="fileRecording_templet"></param>
        /// <param name="cell_tempet"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        /// <param name="treeEnum"></param>
        //void GetFileTree(TreeView treeView, string fileRecording_templet, string cell_tempet, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum);
        /// <summary>
        /// ��ȡ�����ļ���
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        string GetFinal_fileCount(TreeNodeEx node);
        DataSet GetDS(string projectNo, string KeyString);
        /// <summary>
        /// ˢ�½ڵ�
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        /// <param name="treeEnum"></param>
        void RefreshFileNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum, bool IsRush);
        /// <summary>
        /// ���ӽڵ�
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="projectNo"></param>
        void AddFileNode(TreeNodeEx Node, string projectNo);
        /// <summary>
        /// ����ģ��ͼ��
        /// </summary>
        /// <param name="NewNode"></param>
        void SetNodeIcon(TreeNodeEx NewNode);
        /// <summary>
        /// ��TreeView�ؼ���ѡ����һ���ڵ�
        /// </summary>
        /// <param name="treeView"></param>
        void SelectPrevNode(TreeView treeView);
        /// <summary>
        /// ��TreeView�ؼ���ѡ����һ���ڵ�
        /// </summary>
        /// <param name="treeView"></param>
        void SelectNextNode(TreeView treeView);
        /// <summary>
        /// �������� TreeView �� ImageList
        /// </summary>
        /// <returns></returns>
        ImageList CreateTreeImageList();
        /// <summary>
        /// ���,�����Ҳ�鵵Ŀ¼��
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <param name="trvFile"></param>
        void LoadRightTree(string ProjectNO, TreeView trvFile);
        /// <summary>
        /// ˢ�½ڵ�
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        void RefreshNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, CellCreate enumTree);
        /// <summary>
        /// ����ģ��ͼ��
        /// </summary>
        /// <param name="Nodes"></param>
        void SetIcon(TreeNodeCollection Nodes);
        /// <summary>
        /// ��ȡ�ڵ�·��
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        string OpeartPath(TreeNodeEx node);
    }
}
