using System;
using System.Collections.Generic;
using System.Text;
using Digi.DBUtility;
using System.Data;
namespace ERM.CBLL
{
    public class UserSetting
    {
        public UserSetting()
        { 
        }
        /// <summary>
        /// 判断数据库是否可以连接
        /// </summary>
        /// <returns></returns>
        public bool UpdateSettings()
        {
            IDataReader reader =null;
            try
            {                
                string sql = "select top 1 * from Settings";                 
                 reader = DbHelperOleDb.ExecuteReader(sql);
                if (reader.Read())
                {
                    reader.Close();
                }
                return true;                    
            }
            catch
            {
                if(reader !=null)
                    reader.Close();
                return false;
            }
        }
        /// <summary>
        /// 获得设置
        /// </summary>
        /// <returns></returns>
        public ERM.MDL.T_Settings GetSetting()
        {
            string sql = "select top 1 * from Settings";
            DataSet ds = DbHelperOleDb.Query(sql);
            ERM.MDL.Settings model = new ERM.MDL.Settings();
            model.AppTitle = ds.Tables[0].Rows[0]["AppTitle"].ToString();
            model.PromptTitle = ds.Tables[0].Rows[0]["PromptTitle"].ToString();
            model.UserTitle = ds.Tables[0].Rows[0]["UserTitle"].ToString();
            model.UserTitle2 = ds.Tables[0].Rows[0]["UserTitle2"].ToString();
            return model;
        }
    }
}
