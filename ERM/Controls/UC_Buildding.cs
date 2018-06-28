using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERM.MDL;
using ERM.UI.Common;

namespace ERM.UI.Controls
{
    public partial class UC_Buildding : UserControl, IProject
    {
        T_Projects projectMDL;
        public UC_Buildding()
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

        public object GetInfo(string where = "", object objModel = null,int flag=0)
        {
            if (cboStru.Items.Count==0)
            {
                IList<MDL.T_Dict> ds2 = new ERM.BLL.T_Dict_BLL().FindByKeyWord("stru");
                cboStru.DisplayMember = "displayname";
                cboStru.ValueMember = "valuename";
                cboStru.DataSource = ds2;
            }

            projectMDL = (new BLL.T_Projects_BLL()).Find(where);
            if (projectMDL==null)
            {
                projectMDL = new T_Projects();
            }

            return Reflections.Control_Reflection(typeof(T_Projects), projectMDL, this.Controls, "txt|cbo|dtp",flag);
        }

        public bool Add(T_Projects ProjectModel, T_Item ItemModel, object Model = null)
        {
            ProjectModel.shrq = DateTime.Now.ToString("yyyy.MM.dd");
            return (new ERM.BLL.T_Projects_BLL().Add(ProjectModel, ItemModel));
        }

        public bool Updates(T_Projects ProjectModel, T_Item ItemModel = null, object Model = null)
        {
            return (new ERM.BLL.T_Projects_BLL().Update(ProjectModel, ItemModel));
        }

        private void UC_Buildding_Load(object sender, EventArgs e)
        {

        }
    }
}
