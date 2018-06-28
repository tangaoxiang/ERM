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
        /// �Ƚ�2���ڵ��·���Ƿ����
        /// </summary>
        /// <param name="OldPath">�϶��ڵ��·��</param>
        /// <param name="NewPath">�϶�������ͣ���Ľڵ�·��</param>
        /// <returns>�Ƿ����</returns>
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
        /// ȡ�ڵ�ĸ�·��
        /// </summary>
        /// <param name="NodePth">�������Ľڵ�</param>
        /// <returns>��·��</returns>
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
        /// ���ݽڵ��fullpathȡ�ĸ��ڵ��·������
        /// </summary>
        /// <param name="FullPath">�ڵ��fullpath</param>
        /// <returns>�ڵ��·������</returns>
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
        /// �Ƚ�2���ڵ��·���Ƿ����
        /// </summary>
        /// <param name="moveNode">�϶��ڵ��·��</param>
        /// <param name="targeNode">�϶�������ͣ���Ľڵ�·��</param>
        /// <returns>�Ƿ����</returns>
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
