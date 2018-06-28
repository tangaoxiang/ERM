using ERM.BLL;
using ERM.MDL;
using ERM.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class frmGdmlEdit : Skin_DevEX
    {
        private string ID = string.Empty;
        T_GdListTemplate gdTemplate = new T_GdListTemplate();
        T_GdListTemplate_BLL t_FileListTemplate_BLL = new T_GdListTemplate_BLL();
        static IList<T_GdListTemplate> list = null;
        private ERM.UI.frmGdmlList.refresh _refresh;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">文件ID</param>
        /// <param name="title">窗体标题</param>
        public frmGdmlEdit(string id, string title,string category,ERM.UI.frmGdmlList.refresh refreshs)
        {
            InitializeComponent();
            getType();
            _refresh = refreshs;
            this.ID=id;
            this.Text = title;
            this.cboType.SelectedValue = category;
            if (ID != "")
            {
                T_GdListTemplate t_GdListTemplate = t_FileListTemplate_BLL.FindID(id);
                this.txtGdtm.Text = t_GdListTemplate.GdName;
                this.cboType.SelectedValue = t_GdListTemplate.ProjectCategory;
                this.txtOrderIndex.Text = t_GdListTemplate.OrderIndex.ToString();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == "")
                {
                    //新增
                    gdTemplate.ID = Guid.NewGuid().ToString();
                    if (SetValue())
                    {
                        t_FileListTemplate_BLL.Insert(gdTemplate);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //编辑
                    gdTemplate.ID = ID;
                    if (SetValue())
                    {
                        t_FileListTemplate_BLL.Update(gdTemplate);
                    }
                    else
                    {
                        return;
                    }
                }
                _refresh();
                TXMessageBoxExtensions.Info("保存成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        private bool SetValue()
        {
            if (this.txtGdtm.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("归档名称不能为空！");
                this.txtGdtm.Focus();
                return false;
            } 
            if (this.txtOrderIndex.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("排序号不能为空！");
                this.txtOrderIndex.Focus();
                return false;
            }

            gdTemplate.OrderIndex = Convert.ToInt32(this.txtOrderIndex.Text);
            gdTemplate.ProjectCategory = this.cboType.SelectedValue.ToString();
            gdTemplate.GdName = this.txtGdtm.Text;
            return true;
        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 获取归档类别
        /// </summary>
        private void getType()
        {
            T_Dict_BLL dict_bll = new T_Dict_BLL();
            IList<T_Dict> dictList = dict_bll.FindByKeyWord("ProjectCategory");
            this.cboType.DataSource = dictList;
            this.cboType.DisplayMember = "DisplayName";
            this.cboType.ValueMember = "ValueName";
        }

        private void txtOrderIndex_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtOrderIndex_Leave(object sender, EventArgs e)
        {
        }
    }
}
