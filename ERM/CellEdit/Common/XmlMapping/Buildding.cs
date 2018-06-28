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
            XmlElement X_temp = null;
            if (outList != null)
            {
                foreach (var item in outList)
                {
                    XmlNodeList xmlList = engBaseInfo.GetElementsByTagName(item.MappColumn);

                    if (xmlList.Count == 0)
                    {
                        X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    }
                    else
                    {
                        continue;
                    }

                    X_temp.SetAttribute("value", "");
                    X_temp.SetAttribute("description", item.Description);
                    engBaseInfo.AppendChild(X_temp);
                }
            }
        }
    }
}
