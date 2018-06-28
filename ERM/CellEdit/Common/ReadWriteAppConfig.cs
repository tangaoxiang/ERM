using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace ERM.UI
{
    /// <summary>
    /// app.config读写类
    /// </summary>
    public class ReadWriteAppConfig
    {
        public void Write(string ModuleName, string ModuleValue)
        {
            //string ConfigFileName = Process.GetCurrentProcess().MainModule.FileName;
            //XmlDocument xmlDoc = new XmlDocument();
            //string configPath = ConfigFileName + ".config";
            //xmlDoc.Load(configPath);
            //XmlNode xmlNode = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='" + ModuleName + "']");
            //xmlNode.Attributes["value"].Value = ModuleValue;
            //xmlDoc.Save(configPath);

            string ConfigFileName = Process.GetCurrentProcess().MainModule.FileName;
            XmlDocument xmlDoc = new XmlDocument();
            string configPath = ConfigFileName + ".config";
            xmlDoc.Load(configPath);
            XmlNode xmlNode = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='" + ModuleName + "']");
            if (xmlNode == null)
            {
                XmlNode xmlNode2 = xmlDoc.SelectSingleNode("configuration/appSettings");
                XmlElement element2 = xmlDoc.CreateElement("add");
                element2.SetAttribute("key", ModuleName);
                element2.SetAttribute("value", ModuleValue);
                xmlNode2.AppendChild(element2);
            }
            else
            {
                xmlNode.Attributes["value"].Value = ModuleValue;
            }
            xmlDoc.Save(configPath);
        }

        public string Read(string ModuleName)
        {
            string ConfigFileName = Process.GetCurrentProcess().MainModule.FileName;
            XmlDocument xmlDoc = new XmlDocument();
            string configPath = ConfigFileName + ".config";
            xmlDoc.Load(configPath);
            XmlNode xmlNode = xmlDoc.SelectSingleNode("configuration/appSettings/add[@key='" + ModuleName + "']");
            if (xmlNode == null)
                return "";
            string ModuleValue = xmlNode.Attributes["value"].Value;
            return ModuleValue;
        }
    }

}
