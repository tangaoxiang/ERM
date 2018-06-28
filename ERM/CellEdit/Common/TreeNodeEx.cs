using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace ERM.UI
{
    /// <summary>
    /// TreeNode ��չ�࣬��չ��TreeNode��һЩ����
    /// </summary>
    public class TreeNodeEx : System.Windows.Forms.TreeNode, IDictionaryEnumerator
    {
        private DictionaryEntry nodeEntry;
        private IEnumerator enumerator;
        private bool isFirstExpand = true;
        public TreeNodeEx()
        {
            enumerator = base.Nodes.GetEnumerator();
        }
        /// <summary>
        /// �ýڵ��Ƿ��״α�չ��
        /// </summary>
        public bool IsFirstExpand
        {
            get { return isFirstExpand; }
            set { isFirstExpand = value; }
        }
        /// <summary>
        /// NodeKey��������ű�����
        /// </summary>
        public string NodeKey
        {
            get
            {
                return nodeEntry.Key.ToString();
            }
            set
            {
                nodeEntry.Key = value;
            }
        }
        /// <summary>
        /// NodeValue��������ű��·��
        /// </summary>
        public string NodeValue
        {
            get
            {
                return nodeEntry.Value.ToString();
            }
            set
            {
                nodeEntry.Value = value;
            }
        }
        DictionaryEntry IDictionaryEnumerator.Entry
        {
            get
            {
                return nodeEntry;
            }
        }
        object IDictionaryEnumerator.Key
        {
            get
            {
                return nodeEntry.Key;
            }
        }
        object IDictionaryEnumerator.Value
        {
            get
            {
                return nodeEntry.Value;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return enumerator.Current;
            }
        }
        bool IEnumerator.MoveNext()
        {
            bool Success;
            Success = enumerator.MoveNext();
            return Success;
        }
        void IEnumerator.Reset()
        {
            enumerator.Reset();
        }
    }
}
