using System;
using System.Windows.Forms;
using ERM.MDL;
using ERM.BLL;
using ERM.UI.Common;
using System.Drawing;

namespace ERM.UI.Controls
{
    public partial class UC_RoadLamp : UserControl, IProject
    {
        T_Project_RoadLamp RoadLampMDL;
        public UC_RoadLamp()
        {
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
        /// 获取市政路灯扩展信息
        /// </summary>
        public object GetInfo(string where = "", object objModel = null, int flag = 0)
        {
            //路灯信息
            RoadLampMDL = (new BLL.T_Project_RoadLamp_BLL().QueryRoadLamp_ByProjID(where));
            //工程信息
            objModel = Reflections.Control_Reflection(typeof(T_Projects), objModel, this.Controls, "txt_ld_", flag) as T_Projects;

            if (RoadLampMDL == null)
            {
                RoadLampMDL = new T_Project_RoadLamp();
            }

            Reflections.Control_Reflection(typeof(T_Project_RoadLamp), RoadLampMDL, this.Controls, "txt_ld_", flag);
            return objModel;
        }

        /// <summary>
        /// 保存市政路灯扩展信息
        /// </summary>
        /// <param name="ProjectModel">工程模型</param>
        /// <param name="ItemModel">项目模型</param>
        /// <param name="Model">备用，可空</param>
        /// <returns></returns>
        public bool Add(T_Projects ProjectModel, T_Item ItemModel, object Model = null)
        {
            ProjectModel.shrq = DateTime.Now.ToString("yyyy.MM.dd");
            RoadLampMDL.ProjectID = ProjectModel.ProjectNO;
            RoadLampMDL.ID = Guid.NewGuid().ToString();
            return (new T_Project_RoadLamp_BLL().Add(ProjectModel, ItemModel, RoadLampMDL));
        }

        /// <summary>
        /// 更新路灯扩展信息和明细
        /// </summary>
        /// <param name="ProjectModel">工程模型</param>
        /// <param name="ItemModel">项目模型</param>
        /// <param name="Model">备用，可空</param>
        /// <returns></returns>
        public bool Updates(T_Projects ProjectModel, T_Item ItemModel = null, object Model = null)
        {
            return (new T_Project_RoadLamp_BLL().Update(ProjectModel, ItemModel, RoadLampMDL));
        }

        private void txt_ld_End_X_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_ld_End_Y_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_ld_dlcd_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txt_ld_ldxs_st_Load(object sender, EventArgs e)
        {

        }

        private void txt_ld_ldxs_mt_Load(object sender, EventArgs e)
        {

        }

        private void txt_ld_xbxh_Load(object sender, EventArgs e)
        {

        }

        private void UC_RoadLamp_Load(object sender, EventArgs e)
        {

        }
    }
}
