using ERM.MDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 工程级XML
    /// </summary>
    public class Project : IProjectXML
    {
        ProjectItemUnits projectFactory = null;
        XmlElement X_temp = null;
        public Project() { }
        public Project(ProjectItemUnits projectFactory) { this.projectFactory = projectFactory; }
        public void setXmlInfo(System.Xml.XmlDocument To_JavaXml, System.Xml.XmlElement engBaseInfo, MDL.T_Projects project = null, System.Xml.XmlElement root = null)
        {
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectNo", engBaseInfo, "Project",  " where ProjectNo='" + project.ProjectNO + "'");

            List<string> list = new List<string>();//单位
            list.AddRange(new string[] { "designOrgSid", "reconnaissanceOrgSid", "supervisionOrgSid", "reconnaissanceOrgBy", "subpackageOrgBy", "subpackageOrgName", "constructOrgBy", "constructOrgName", "jldw_xmzj", "developmentsOrgName", "constructOrgSid", "supervisionOrgName", "designOrgName", "jldw_xmfzr" });

            if (outList != null)
            {
                foreach (var item in outList)
                {
                    if (list.Contains(item.MappColumn))
                    {
                        ProjectXML_Factory.FieldMethod(To_JavaXml, item, item.Column,ref X_temp,projectFactory);
                    }
                    else
                    {
                        X_temp = To_JavaXml.CreateElement(item.MappColumn);
                        X_temp.SetAttribute("value", "");
                    }
                    X_temp.SetAttribute("description", item.Description);
                    engBaseInfo.AppendChild(X_temp);
                }
            }
        }
    }
}
