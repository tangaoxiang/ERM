using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 案卷XML
    /// </summary>
    public class Archive : IProjectXML
    {
        T_Archive obj = null;
        XmlElement X_temp = null;
        public Archive() { }
        public Archive(T_Archive obj) { this.obj = obj; }
        public void setXmlInfo(System.Xml.XmlDocument To_JavaXml, System.Xml.XmlElement engBaseInfo, MDL.T_Projects project = null, System.Xml.XmlElement root = null)
        {
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectNO", engBaseInfo, "Archive", " where ProjectNO='" + project.ProjectNO + "'");
            List<string> list = new List<string>();

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

                    if (item.MappColumn == "archWidth")
                    {
                        string jhlx = obj.jhlx.Replace("公分案卷盒", "");
                        jhlx = jhlx.Replace("公分", "");
                        jhlx = jhlx.Replace("案卷盒", "");
                        X_temp.SetAttribute("value", jhlx);
                    }
                    else
                    {
                        X_temp.SetAttribute("value", item.Default);
                    }

                    //X_temp.SetAttribute("description", item.Description);
                    engBaseInfo.AppendChild(X_temp);
                }
            }
        }
        public DataSet pb_setXmlInfo()
        {
            return ProjectXML_Factory.setXmlInfo("pb_queryByProjectNO1", "Archive", "ProjectNO='" + Globals.ProjectNO + "'");
        }
        public DataSet pb_setXmlInfo(string projectNo, string archiveID)
        {
            return ProjectXML_Factory.setXmlInfo("pb_queryByProjectNO", "Archive", "ArchiveID='" + archiveID + "',ProjectNO='" + projectNo + "'");      
        }
    }
}
