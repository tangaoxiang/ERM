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
        /// 获取树
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
        /// 获取电子文件数
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        string GetFinal_fileCount(TreeNodeEx node);
        DataSet GetDS(string projectNo, string KeyString);
        /// <summary>
        /// 刷新节点
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        /// <param name="treeEnum"></param>
        void RefreshFileNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, FileStatus treeEnum, bool IsRush);
        /// <summary>
        /// 增加节点
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="projectNo"></param>
        void AddFileNode(TreeNodeEx Node, string projectNo);
        /// <summary>
        /// 设置模板图标
        /// </summary>
        /// <param name="NewNode"></param>
        void SetNodeIcon(TreeNodeEx NewNode);
        /// <summary>
        /// 在TreeView控件上选中上一个节点
        /// </summary>
        /// <param name="treeView"></param>
        void SelectPrevNode(TreeView treeView);
        /// <summary>
        /// 在TreeView控件上选中下一个节点
        /// </summary>
        /// <param name="treeView"></param>
        void SelectNextNode(TreeView treeView);
        /// <summary>
        /// 创建用于 TreeView 的 ImageList
        /// </summary>
        /// <returns></returns>
        ImageList CreateTreeImageList();
        /// <summary>
        /// 组卷,加载右侧归档目录树
        /// </summary>
        /// <param name="ProjectNO"></param>
        /// <param name="trvFile"></param>
        void LoadRightTree(string ProjectNO, TreeView trvFile);
        /// <summary>
        /// 刷新节点
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="withImage"></param>
        /// <param name="projectNo"></param>
        /// <param name="IsCount"></param>
        /// <param name="isAll"></param>
        void RefreshNode(TreeNodeEx Node, bool withImage, string projectNo, bool IsCount, bool isAll, CellCreate enumTree);
        /// <summary>
        /// 设置模板图标
        /// </summary>
        /// <param name="Nodes"></param>
        void SetIcon(TreeNodeCollection Nodes);
        /// <summary>
        /// 获取节点路径
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        string OpeartPath(TreeNodeEx node);
    }
}
