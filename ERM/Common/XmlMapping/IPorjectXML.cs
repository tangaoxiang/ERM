using ERM.BLL;
using ERM.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ERM.UI.Common
{
    /// <summary>
    /// XML导出数据接口
    /// </summary>
    public interface IProjectXML
    {
        /// <summary>
        ///  给XML设置对象信息
        /// </summary>
        /// <param name="XmlDoc">xml文档对象</param>
        /// <param name="xmlNode">节点XML</param>
        /// <param name="project">工程对象</param>
        /// <param name="element">备用节点,可选</param>
        void setXmlInfo(XmlDocument XmlDoc, XmlElement xmlNode, T_Projects project, XmlElement element = null);
    } 
}
