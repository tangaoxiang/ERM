using ERM.BLL;
using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ERM.UI.Common.XmlMapping
{
    /// <summary>
    /// 工程设置XML信息实例工厂
    /// </summary>
    public class ProjectXML_Factory
    {
        static IProjectXML project;
        /// <summary>
        /// 动态加载对象工厂
        /// </summary>
        /// <param name="list"></param>
        /// <param name="selectValue"></param>
        /// <returns></returns>
        public static IProjectXML getInstance(IList<MDL.T_Dict> list, string selectValue)
        {
            project = null;

            foreach (var item in list)
            {
                string val = string.Empty;
                if (project != null)
                {
                    break;
                }

                PropertyInfo[] properties = typeof(T_Dict).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    string propertyID = properties[i].Name;
                    if (propertyID == "ValueName")
                    {
                        PropertyInfo pinfo = typeof(T_Dict).GetProperty(propertyID);
                        val = pinfo.GetValue(item, null) == null ? "" : pinfo.GetValue(item, null).ToString();

                        if (selectValue == val)
                        {
                            Assembly asm = Assembly.GetExecutingAssembly();
                            project = asm.CreateInstance("ERM.UI.Common.XmlMapping." + val, true) as IProjectXML;
                            break;
                        }
                    }
                }
            }
            return project;
        }

        /// <summary>
        /// 根据配置模板动态导出XML
        /// </summary>
        /// <param name="To_JavaXml">XML文档对象</param>
        /// <param name="project">工程对象</param>
        /// <param name="tableName">查询表名</param>
        /// <param name="xmlInfo">XML节点</param>
        /// <param name="template">XML模板名</param>
        /// <param name="outList">非数据库取值字段列表,在具体实现类处理</param>
        public static void setXmlInfo(XmlDocument To_JavaXml, T_Projects project, string tableName, XmlElement xmlInfo, string template, out List<T_Model> outList, string where)
        {
            XmlDoc doc = new XmlDoc(Application.StartupPath + @"\Common\XMLTemplate\" + template + ".xml");
            XmlNodeList nodeList = doc.GetNodeList("root");
            XmlNodeList childList = null;
            outList = new List<T_Model>();

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].Name.ToLower() == "columns")
                {
                    childList = nodeList[i].ChildNodes;
                    break;
                }
            }

            if (childList != null)
            {
                T_Model model = null;
                string sql = string.Empty;
                List<T_Model> columnList = new List<T_Model>();

                for (int i = 0; i < childList.Count; i++)
                {
                    XmlNode node = childList[i];
                    XmlAttributeCollection attrCollection = node.Attributes;

                    if (attrCollection == null)
                    {
                        continue;
                    }
                    model = new T_Model();

                    for (int j = 0; j < attrCollection.Count; j++)
                    {
                        switch (attrCollection[j].Name)
                        {
                            case "column":
                                model.Column = attrCollection[j].Value;
                                break;
                            case "mappColumn":
                                model.MappColumn = attrCollection[j].Value;
                                break;
                            case "display":
                                model.Display = attrCollection[j].Value;
                                break;
                            case "description":
                                model.Description = attrCollection[j].Value;
                                break;
                            case "type":
                                model.Type = attrCollection[j].Value;
                                break;
                        }
                    }

                    if (model.Display == "1")
                    {
                        if (model.Type == "0")
                        {
                            sql += "[" + model.Column + "],";
                            columnList.Add(model);
                        }
                        else
                        {
                            outList.Add(model);
                        }
                    }
                }

                if (sql.Length > 0)
                {
                    sql = "select " + sql.TrimEnd(',') + " from " + tableName + " where " + where;
                    DataSet ds = ERM.DAL.MyBatis.QueueyForSql(sql);
                    
                    if (ds.Tables.Count>0)
                    {
                        DataTable dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                XmlElement X_temp = To_JavaXml.CreateElement(columnList[j].MappColumn);
                                X_temp.SetAttribute("value", dt.Rows[i][j].ToString());
                                X_temp.SetAttribute("description", columnList[j].Description);
                                xmlInfo.AppendChild(X_temp);
                            }
                        } 
                    }
                }
            }
        }

        /// <summary>
        /// 设置XML输出信息
        /// </summary>
        /// <param name="To_JavaXml">XML文档</param>
        /// <param name="project">工程对象</param>
        /// <param name="sqlID">SQL查询标识</param>
        /// <param name="xmlInfo">节点XML</param>
        /// <param name="template">模板名称</param>
        /// <param name="where">查询条件</param>
        /// <returns>自定义字段集合</returns>
        public static List<T_Model> setXmlInfo(XmlDocument To_JavaXml, T_Projects project, string sqlID, XmlElement xmlInfo, string template, string where = "")
        {
            XmlDoc doc = new XmlDoc(Application.StartupPath + @"\Common\XMLTemplate\" + template + ".xml");
            XmlNodeList nodeList = doc.GetNodeList("root");
            XmlNodeList columList = null;
            XmlNodeList sqlList = null;
            List<T_Model> modelList = new List<T_Model>();
            string sql = string.Empty;
            #region XML节点
            for (int i = 0; i < nodeList.Count; i++)
            {
                switch (nodeList[i].Name.ToLower())
                {
                    case "columns":
                        columList = nodeList[i].ChildNodes;
                        break;
                    case "selects":
                        sqlList = nodeList[i].ChildNodes;
                        break;
                }
            }
	        #endregion

            #region 模板字段
            if (columList != null)
            {
                T_Model model = null;

                for (int i = 0; i < columList.Count; i++)
                {
                    XmlNode node = columList[i];
                    XmlAttributeCollection attrCollection = node.Attributes;

                    if (attrCollection == null)
                    {
                        continue;
                    }
                    model = new T_Model();

                    for (int j = 0; j < attrCollection.Count; j++)
                    {
                        switch (attrCollection[j].Name)
                        {
                            case "column":
                                model.Column = attrCollection[j].Value;
                                break;
                            case "mappColumn":
                                model.MappColumn = attrCollection[j].Value;
                                break;
                            case "display":
                                model.Display = attrCollection[j].Value;
                                break;
                            case "description":
                                model.Description = attrCollection[j].Value;
                                break;
                            case "type":
                                model.Type = attrCollection[j].Value;
                                break;
                            case "default":
                                model.Default = attrCollection[j].Value;
                                break;
                        }
                    }

                    if (model.Display == "1")
                    {
                        modelList.Add(model);
                    }
                }
            }
            #endregion

            #region 映射字段
            if (sqlList.Count > 0)
            {
                for (int j = 0; j < sqlList.Count; j++)
                {
                    XmlAttributeCollection attrColl = sqlList[j].Attributes;
                    if (attrColl["id"].Value.ToString() == sqlID)
                    {
                        sql = sqlList[j].InnerText.Trim();

                        #region 参数处理
                        //switch (attrColl["parameterClass"].Value.ToLower())
                        //{
                        //    case "string":
                        //        sql = sql.Replace("#value#", "'" + project.ProjectNO + "'");
                        //        break;
                        //    case "int":
                        //        sql = sql.Replace("#value#", project.ProjectNO);
                        //        break;
                        //    default:
                        //        dynamic d = attrColl["parameterClass"].Value;

                        //        sql = sql.Replace("#value#", project.ProjectNO);
                        //        break;
                        //}
                        #endregion

                        #region 输出XML
                        DataSet ds = ERM.DAL.MyBatis.QueueyForSql(sql + "  " + where);
                        if (ds.Tables.Count > 0)
                        {
                            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                            {
                                for (int n = 0; n < ds.Tables[0].Columns.Count; n++)
                                {
                                    for (int k = 0; k < modelList.Count; k++)
                                    {
                                        if (modelList[k].Column == ds.Tables[0].Columns[n].ColumnName)
                                        {
                                            XmlElement X_temp = To_JavaXml.CreateElement(modelList[k].MappColumn);
                                            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[m][n].ToString()))
                                            {
                                                X_temp.SetAttribute("value", ds.Tables[0].Rows[m][n].ToString());
                                            }
                                            else
                                            {
                                                X_temp.SetAttribute("value", modelList[k].Default);
                                            }
                                            X_temp.SetAttribute("description", modelList[k].Description);
                                            xmlInfo.AppendChild(X_temp);
                                            modelList.RemoveAt(k);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                        #endregion
                    }
                }
            }
            return modelList;
                #endregion  
        }

        /// <summary>
        /// 处理工程单位字段
        /// </summary>
        /// <param name="To_JavaXml">XML文档</param>
        /// <param name="item">XML属性对象</param>
        /// <param name="field">单位名称</param>
        public static void FieldMethod(System.Xml.XmlDocument To_JavaXml, T_Model item, string field, ref XmlElement X_temp, ProjectItemUnits projectFactory)
        {
            if (projectFactory != null)
            {
                if (projectFactory.ProjectDetail[field] is System.String[])
                {
                    string Svalue = "";
                    foreach (string values in (projectFactory.ProjectDetail[field] as System.String[]))
                    {
                        if (!string.IsNullOrWhiteSpace(values))
                            Svalue += values + "，";
                    }
                    if (Svalue.EndsWith("，"))
                    {
                        Svalue = Svalue.Remove(Svalue.Length - 1);
                    }
                    X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    X_temp.SetAttribute("value", Svalue);
                }
                else
                {
                    X_temp = To_JavaXml.CreateElement(item.MappColumn);
                    X_temp.SetAttribute("value", projectFactory.ProjectDetail[field] == null ? "" : projectFactory.ProjectDetail[field].ToString());
                }
            }
        }
    }
}