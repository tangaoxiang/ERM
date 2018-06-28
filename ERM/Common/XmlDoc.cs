using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace ERM.UI
{
    public class XmlDoc : XmlDocument
    {
        private string _xmlFileName;
        public string XmlFileName
        {
            set { _xmlFileName = value; }
            get { return _xmlFileName; }
        }
        public XmlDoc(string xmlFile)
        {
            XmlFileName = xmlFile;
            this.Load(xmlFile);
        }
        /// <summary>
        /// ����һ���ڵ��xPath���ʽ������һ���ڵ�
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public XmlNode FindNode(string xPath)
        {
            XmlNode xmlNode = this.SelectSingleNode(xPath);
            return xmlNode;
        }
        /// <summary>
        /// ����һ���ڵ��xPath���ʽ������ֵ
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public string GetNodeValue(string xPath)
        {
            XmlNode xmlNode = this.SelectSingleNode(xPath);
            return xmlNode.InnerText;
        }
        /// <summary>
        /// ����һ���ڵ�ı��ʽ���ش˽ڵ��µĺ��ӽڵ��б�
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public XmlNodeList GetNodeList(string xPath)
        {
            XmlNodeList nodeList = this.SelectSingleNode(xPath).ChildNodes;
            return nodeList;
        }
    }
}
