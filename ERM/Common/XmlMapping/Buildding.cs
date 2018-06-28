using ERM.BLL;
using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 建筑XML
    /// </summary>
    public class Buildding : IProjectXML
    {
        public void setXmlInfo(XmlDocument To_JavaXml, XmlElement engBaseInfo, T_Projects project, XmlElement root = null)
        {
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectNo", engBaseInfo, "Buildding", " and ProjectNo='" + project.ProjectNO + "'"); 
            if (outList != null)
            {
                foreach (var item in outList)
                {
                    XmlElement X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    X_temp.SetAttribute("value", item.Default);
                    engBaseInfo.AppendChild(X_temp);
                }
            }
        }
    }
}
