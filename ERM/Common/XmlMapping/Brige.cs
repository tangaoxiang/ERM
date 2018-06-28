using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 市政桥梁XML
    /// </summary>
    public class Brige:IProjectXML
    {
        public void setXmlInfo(System.Xml.XmlDocument To_JavaXml, System.Xml.XmlElement engBaseInfo, MDL.T_Projects project = null, System.Xml.XmlElement root = null)
        {
            //XmlElement brigeInfo = To_JavaXml.CreateElement("BrigeInfo");
            //engBaseInfo.AppendChild(brigeInfo);
            List<T_Model>outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectID", engBaseInfo, "Brige", " where ProjectID='" + project.ProjectNO + "'");
            
            if (outList!=null)
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
