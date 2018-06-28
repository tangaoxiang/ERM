using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace ERM.Common
{
    public abstract class TreeOperation
    {
        /// <summary>
        /// 比较2个节点的路径是否相等
        /// </summary>
        /// <param name="OldPath">拖动节点的路径</param>
        /// <param name="NewPath">拖动结束所停留的节点路径</param>
        /// <returns>是否相等</returns>
        public static bool HavaSamePartent(string moveNode, string targeNode)
        {
            moveNode = OperationNodePath(moveNode);
            targeNode = OperationNodePath(targeNode);
            if ((!String.IsNullOrEmpty(moveNode)) && !String.IsNullOrEmpty(targeNode))
            {
                if (moveNode.Equals(targeNode))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 取节点的父路径
        /// </summary>
        /// <param name="NodePth">所操作的节点</param>
        /// <returns>父路径</returns>
        private static string OperationNodePath(string NodePth)
        {
            try
            {
                NodePth = NodePth.Substring(0, NodePth.LastIndexOf(@"\"));
                return NodePth;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 根据节点的fullpath取的各节点的路径集合
        /// </summary>
        /// <param name="FullPath">节点的fullpath</param>
        /// <returns>节点的路径集合</returns>
        public static string[] GetTreeFullPathItem(string FullPath)
        {
            if (!String.IsNullOrEmpty(FullPath))
            {
                char[] separator = new char[1];
                separator[0] = '\\';
                string[] PathItem = FullPath.Split(separator);
                return PathItem;
            }
            return null;
        }
        /// <summary>
        /// 比较2个节点的路径是否相等
        /// </summary>
        /// <param name="moveNode">拖动节点的路径</param>
        /// <param name="targeNode">拖动结束所停留的节点路径</param>
        /// <returns>是否相等</returns>
        public static bool CheckPath(TreeNode moveNode, TreeNode targeNode)
        {
            try
            {
                string moveNodeFullPaht = moveNode.Parent.FullPath + '\\' + moveNode.Text.Replace('\\', '/');
                string targeNodeFullPath = targeNode.Parent.FullPath + '\\' + targeNode.Text.Replace('\\', '/');
                return HavaSamePartent(moveNodeFullPaht, targeNodeFullPath);
            }
            catch
            {
                return false;
            }
        }
    }
}
