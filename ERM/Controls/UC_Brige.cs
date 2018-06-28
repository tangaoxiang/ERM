using System;
using System.Windows.Forms;
using ERM.MDL;
using ERM.BLL;
using ERM.UI.Common;
using System.Collections.Generic;
using System.Drawing;

namespace ERM.UI.Controls
{
    public partial class UC_Brige : UserControl,IProject
    {
        T_Project_Brige brigeMDL;
        public UC_Brige() { 
            InitializeComponent();
            //for (int i = 0; i < this.Controls.Count; i++)
            //{
            //    if (this.Controls[i].Name.ToLower().Contains("label"))
            //    {
            //        this.Controls[i].ForeColor = Color.Black;
            //    }
            //}
        }

        /// <summary>
        /// 获取市政桥梁扩展信息
        /// </summary>
        public object GetInfo(string where = "", object objModel = null,int flag=0)
        {
            if (this.cbo_ql_stuructType.Items.Count == 0)
            {
                IList<MDL.T_Dict> ds2 = new ERM.BLL.T_Dict_BLL().FindByKeyWord("stru_brige");
                this.cbo_ql_stuructType.DisplayMember = "displayname";
                cbo_ql_stuructType.ValueMember = "valuename";
                cbo_ql_stuructType.DataSource = ds2;
            }

            //桥梁信息
            brigeMDL = (new BLL.T_Project_Brige_BLL().QueryBrige_ByProjID(where));
            //工程信息
            objModel = Reflections.Control_Reflection(typeof(T_Projects), objModel, this.Controls, "txt_ql_", flag) as T_Projects;

            if (brigeMDL == null)
            {
                brigeMDL = new T_Project_Brige();
            }

            Reflections.Control_Reflection(typeof(T_Project_Brige), brigeMDL, this.Controls, "txt_ql_|cbo_ql_", flag);
            return objModel;
        }

        /// <summary>
        /// 保存市政桥梁扩展信息
        /// </summary>
        /// <param name="ProjectModel">工程模型</param>
        /// <param name="ItemModel">项目模型</param>
        /// <param name="Model">备用，可空</param>
        /// <returns></returns>
        public bool Add(T_Projects ProjectModel, T_Item ItemModel, object Model = null)
        {
            ProjectModel.shrq = DateTime.Now.ToString("yyyy.MM.dd");
            brigeMDL.ProjectID = ProjectModel.ProjectNO;
            brigeMDL.ID = Guid.NewGuid().ToString();
            return (new T_Project_Brige_BLL().Add(ProjectModel, ItemModel, brigeMDL));
        }

        /// <summary>
        /// 更新桥梁扩展信息和明细
        /// </summary>
        /// <param name="ProjectModel">工程模型</param>
        /// <param name="ItemModel">项目模型</param>
        /// <param name="Model">备用，可空</param>
        /// <returns></returns>
        public bool Updates(T_Projects ProjectModel, T_Item ItemModel = null, object Model = null)
        {
            return (new T_Project_Brige_BLL().Update(ProjectModel, ItemModel, brigeMDL));
        }

        private void cbo_ql_stuructType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_Brige_Load(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }
    }
}
