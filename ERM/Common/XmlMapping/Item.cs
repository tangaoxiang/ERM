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
    /// 项目XML
    /// </summary>
    public class Item:IProjectXML
    {
        ProjectItemUnits projectFactory = null;
        public Item() { }
        public Item(ProjectItemUnits projectFactory) { this.projectFactory = projectFactory; }
        public void setXmlInfo(System.Xml.XmlDocument To_JavaXml, System.Xml.XmlElement engBaseInfo, MDL.T_Projects project = null, System.Xml.XmlElement root = null)
        {
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByItemID", engBaseInfo, "Item",  " and a.ItemID='" + project.ItemID + "'");
            List<string> list2 = new List<string>();
            list2.AddRange(new string[] { "xmdesignOrgSidtmp", "xmreconnaissanceOrgSidtmp", "xmsupervisionOrgSidtmp" });

            XmlElement X_temp = null;

            if (outList != null)
            {
                foreach (var item in outList)
                {
                    if (list2.Contains(item.MappColumn))
                    {
                        ProjectXML_Factory.FieldMethod(To_JavaXml, item, item.Column, ref X_temp, projectFactory);
                    }
                    else
                    {
                        X_temp = To_JavaXml.CreateElement(item.MappColumn);
                        X_temp.SetAttribute("value", item.Default);
                    }

                    //X_temp.SetAttribute("description", item.Description==null?"":item.Description.ToString());
                    engBaseInfo.AppendChild(X_temp);
                }
            }
        }

        public DataSet pb_setXmlInfo(string ItemID)
        {
            return ProjectXML_Factory.setXmlInfo("pb_queryByItemID", "Item", "ItemID='" + ItemID + "'");
        }
    }
}
