using ERM.MDL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    public class YW_CellAndEFile : IProjectXML
    {
        string fileName = string.Empty;
        string filePath = string.Empty;
        string orderIndex = string.Empty;
        T_CellAndEFile obj = null;
        XmlElement X_temp = null;

        public YW_CellAndEFile() { }
        public YW_CellAndEFile(string fileName, string filePath, T_CellAndEFile obj,string orderIndex)
        {
            this.fileName = fileName;
            this.filePath = filePath;
            this.obj = obj;
            this.orderIndex = orderIndex;
        }
        public void setXmlInfo(System.Xml.XmlDocument To_JavaXml, System.Xml.XmlElement engBaseInfo, MDL.T_Projects project = null, System.Xml.XmlElement root = null)
        {
            XmlElement eFileINfo = To_JavaXml.CreateElement("eFileInfo");
            engBaseInfo.AppendChild(eFileINfo);
            List<T_Model> outList = new List<T_Model>();
            outList = ProjectXML_Factory.setXmlInfo(To_JavaXml, project, "queryByProjectNo", eFileINfo, "YW_CellAndEFile",  "  and a.ProjectNo='" + project.ProjectNO + "'");

            if (outList != null)
            {
                foreach (var item in outList)
                {
                    XmlNodeList xmlList = eFileINfo.GetElementsByTagName(item.MappColumn);

                    if (xmlList.Count == 0)
                    {
                        X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    }
                    else
                    {
                        continue;
                    }
                    switch (item.MappColumn)
                    {
                        case "FILENAME"://文件名
                            X_temp.SetAttribute("value", fileName);
                            break;
                        case "FILEPATH"://文件路径
                            X_temp.SetAttribute("value", filePath);
                            break;
                        case "FileSize"://文件大小
                            FileStream st = new FileStream(Globals.ProjectPath + obj.filepath, FileMode.Open, FileAccess.Read);
                            X_temp.SetAttribute("value", st.Length.ToString());
                            st.Close();
                            st.Dispose();
                            break;
                        case "ORDER_RANK":
                            X_temp.SetAttribute("value", orderIndex);
                            break;
                        default:
                            X_temp.SetAttribute("value", item.Default);
                            break;
                    }
                    X_temp.SetAttribute("description", item.Description);
                    eFileINfo.AppendChild(X_temp);
                }
            }
        }
    }
}
