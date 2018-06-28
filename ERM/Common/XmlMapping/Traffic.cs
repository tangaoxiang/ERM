using ERM.BLL;
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
    /// 管线XML
    /// </summary>
    public class Traffic : IProjectXML
    {
        public void setXmlInfo(XmlDocument To_JavaXml, XmlElement engBaseInfo, T_Projects project, XmlElement root)
        {
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectID", engBaseInfo, "Traffic", " where ProjectID='" + project.ProjectNO + "'");

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

            //交通明细
            //T_Traffic traffic = new T_Traffic_BLL().QueryTraffic_ByProjID(project.ProjectNO);
            //if (traffic != null)
            //{
            //    IList<T_Traffic_Detail> detailList = new T_Traffic_Detail_BLL().QueryTraffic_ByProjID(traffic.ID);
            //    foreach (var detail in detailList)
            //    {
            //        XmlElement traffic_DetailInfo = To_JavaXml.CreateElement("DetailInfo");
            //        trafficInfo.AppendChild(traffic_DetailInfo);
            //        List<T_Model> outList_Detail = new List<T_Model>();
            //        outList_Detail = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByTrafficID", traffic_DetailInfo, "Traffic_Detail", " where Trafficid='" + traffic.ID + "' and types='" + detail.Types + "'");

            //        if (outList_Detail != null)
            //        {
            //            foreach (var item in outList_Detail)
            //            {
            //                XmlElement X_temp = To_JavaXml.CreateElement(item.MappColumn);
            //                X_temp.SetAttribute("value", "");
            //                X_temp.SetAttribute("description", item.Description);
            //                traffic_DetailInfo.AppendChild(X_temp);
            //            }
            //        }  
            //    } 
            //}
        }

        public DataSet PB_setXmlInfo(string trafficID) {
            return ProjectXML_Factory.setXmlInfo("pb_queryByTrafficID", "Traffic_Detail", "ID='" + trafficID + "'");
        }
    }
}
