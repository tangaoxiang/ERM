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
    /// 市政路灯XML
    /// </summary>
    public class RoadLamp : IProjectXML
    {
        public void setXmlInfo(XmlDocument To_JavaXml, XmlElement engBaseInfo, T_Projects project, XmlElement root = null)
        {
            XmlElement roadLampInfo = To_JavaXml.CreateElement("RoadLampInfo");
            engBaseInfo.AppendChild(roadLampInfo);
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectID", roadLampInfo, "RoadLamp", " where ProjectID='" + project.ProjectNO + "'");

            if (outList != null)
            {
                foreach (var item in outList)
                {
                    XmlElement X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    X_temp.SetAttribute("value", "");
                    X_temp.SetAttribute("description", item.Description);
                    roadLampInfo.AppendChild(X_temp);
                }
            }
        }
    }
}
