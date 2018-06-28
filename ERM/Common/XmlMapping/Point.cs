using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using ERM.BLL;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 工程坐标XML设置
    /// </summary>
    public class Point : IProjectXML
    {
        public Point() { 
        
        }

        public void setXmlInfo(System.Xml.XmlDocument XmlDoc, System.Xml.XmlElement xmlNode, MDL.T_Projects project, System.Xml.XmlElement element = null)
        {
            T_Point_BLL bll = new T_Point_BLL();
            IList<T_Point>list =  bll.GetList(project.ProjectNO);
            foreach (var pointItem in list)
            {
                XmlElement fileInfo = XmlDoc.CreateElement("pointInfo");
                xmlNode.AppendChild(fileInfo);
                List<T_Model> outList = new List<T_Model>();
                outList = ProjectXML_Factory.setXmlInfo(XmlDoc, project, "queryByProjectID", fileInfo, "Point", " where ProjectNo='" + project.ProjectNO + "' and id='" + pointItem.ID + "'");

                if (outList != null)
                {
                    foreach (var item in outList)
                    {
                        XmlElement X_temp = XmlDoc.CreateElement(item.MappColumn);
                        X_temp.SetAttribute("value", item.Default);
                        X_temp.SetAttribute("description", item.Description);
                        fileInfo.AppendChild(X_temp);
                    }
                }  
            }
        }
    }
}
