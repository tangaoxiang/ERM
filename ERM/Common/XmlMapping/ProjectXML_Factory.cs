using ERM.BLL;
using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
            List<T_Model> resultList = new List<T_Model>();
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
                modelList.Clear();
                resultList.Clear();

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

                    if (model.Type=="1")
                    {
                        resultList.Add(model);
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
                        try
                        {
                             DataSet ds = ERM.DAL.MyBatis.QueueyForSql(sql + "  " + where);
                             if (ds.Tables.Count > 0)
                             {
                                 for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
                                 {
                                     for (int k = 0; k < modelList.Count; k++)
                                     {
                                         for (int n = 0; n < ds.Tables[0].Columns.Count; n++)
                                         {
                                             if (modelList[k].Column.ToString().ToLower() == ds.Tables[0].Columns[n].ColumnName.ToString().ToLower())
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
                                                 xmlInfo.AppendChild(X_temp);
                                             }
                                         }
                                     }
                                 }
                             }
                        }
                        catch (Exception ex)
                        {
                            TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info(ex.Message.ToString());
                        }
                        break;
                        #endregion
                    }
                }
            }
            return resultList;
                #endregion  
        }

        /// <summary>
        /// 针对PB导出XML
        /// </summary>
        /// <param name="project"></param>
        /// <param name="sqlID"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static DataSet setXmlInfo(string sqlID,string template,string where) {
            XmlDoc doc = new XmlDoc(Application.StartupPath + @"\Common\XMLTemplate\" + template + ".xml");
            XmlNodeList nodeList = doc.GetNodeList("root");
            XmlNodeList columList = null;
            XmlNodeList sqlList = null;
            string sql = string.Empty;
            #region XML节点
            for (int i = 0; i < nodeList.Count; i++)
            {
                switch (nodeList[i].Name.ToLower())
                {
                    case "selects":
                        sqlList = nodeList[i].ChildNodes;
                        break;
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
                        string param = attrColl["params"].Value.ToString();
                        string[] paramList = param.Split(',');
                        sql = sqlList[j].InnerText.Trim();
                        string[] whereList = where.Split(',');

                        for (int w = 0; w < whereList.Length; w++)
                        {
                            sql = Regex.Replace(sql, @"#" + whereList[w].Split('=')[0].ToString() + "#", whereList[w].Split('=')[1].ToString());
                        }

                        try
                        {
                             DataSet ds = ERM.DAL.MyBatis.QueueyForSql(sql);
                             return ds;
                        }
                        catch (Exception ex)
                        {
                            TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info(ex.Message.ToString());
                        }
                    }
                }
            }
            #endregion  
            return null;
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