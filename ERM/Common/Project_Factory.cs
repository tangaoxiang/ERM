using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERM.MDL;
using System.Reflection;

namespace ERM.UI.Controls
{
    public class Project_Factory
    {
        static IProject project;
        /// <summary>
        /// 动态加载用户控件对象工厂
        /// </summary>
        /// <param name="list"></param>
        /// <param name="selectValue"></param>
        /// <returns></returns>
        public static IProject getInstance(IList<MDL.T_Dict> list, string selectValue)
        {
            project = null;
            foreach (var item in list)
            {
                string val = string.Empty;
                if (project!=null)
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

                        if (selectValue==val)
                        {
                            Assembly asm = Assembly.GetExecutingAssembly();
                            project = asm.CreateInstance("ERM.UI.Controls.UC_" + val, true) as IProject;
                            break;
                        }
                    }
                }
            }
            return project;
        }
    }
}
