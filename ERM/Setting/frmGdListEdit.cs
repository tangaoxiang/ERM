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

namespace ERM.UI.Setting
{
    public partial class frmGdListEdit : Skin_DevEX
    {
        private string ID = string.Empty;
        T_FileListTemplate fileTemplate = new T_FileListTemplate();
        T_FileListTemplate_BLL t_FileListTemplate_BLL = new T_FileListTemplate_BLL();
        static IList<T_GdListTemplate> list = null;
        public ERM.UI.frmGdList.refresh refreshs;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="id">文件ID</param>
        /// <param name="title">窗体标题</param>
        public frmGdListEdit(string id, string title, string category, ERM.UI.frmGdList.refresh _refresh)
        {
            InitializeComponent();
            refreshs = _refresh;
            getType();
            BindCategory(this.cboType.SelectedValue.ToString());
            this.ID=id;
            this.Text = title;
            this.cboType.SelectedValue = category;
            this.cboCategory.SelectedIndex = 0;
            if (ID != "")
            {
                IList<T_FileListTemplate>list = t_FileListTemplate_BLL.FindByid(id);
                foreach (var item in list)
                {
                    if (string.IsNullOrEmpty(item.GDID))
                    {
                        this.cboCategory.SelectedIndex = 0;
                    }
                    else
                    {
                        this.cboCategory.SelectedValue = item.GDID.ToString();
                    }
                    this.txtGdtm.Text = item.gdwj;
                    this.cboType.SelectedValue = item.ProjectCategory;
                    this.cboType.Enabled = false;
                    this.txtOrderIndex.Text = item.OrderIndex.ToString();
                    this.chkIsVisible.Checked = (item.isvisible == 0 ? false : true);
                }
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
                    fileTemplate.FileID = Guid.NewGuid().ToString();

                    T_FileListTemplate  fileTemplate1 = t_FileListTemplate_BLL.FindByProjectCategory(this.cboType.SelectedValue.ToString());

                    fileTemplate.ParentID = fileTemplate1.FileID;
                    if (SetValue())
                    {
                        t_FileListTemplate_BLL.Insert(fileTemplate);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //编辑
                    fileTemplate.FileID = ID;
                    if (SetValue())
                    {
                        t_FileListTemplate_BLL.Update(fileTemplate);
                    }
                    else
                    {
                        return;
                    }
                }
                refreshs();
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
                TXMessageBoxExtensions.Info("文件名称不能为空！");
                this.txtGdtm.Focus();
                return false;
            }

            if (this.txtOrderIndex.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("排序号不能为空！");
                this.txtOrderIndex.Focus();
                return false;
            }

            fileTemplate.OrderIndex = Convert.ToInt32(this.txtOrderIndex.Text);
            fileTemplate.ProjectCategory = this.cboType.SelectedValue.ToString();
            fileTemplate.gdwj = this.txtGdtm.Text;
            fileTemplate.GDID = this.cboCategory.SelectedValue.ToString();
            fileTemplate.isvisible = this.chkIsVisible.Checked ? 1 : 0;
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

        /// <summary>
        /// 上级分类
        /// </summary>
        private void BindCategory(string Type)
        {
            List<T_GdListTemplate> temp_list = new List<T_GdListTemplate>();
            T_GdListTemplate fileTemp = new T_GdListTemplate();
            fileTemp.ProjectCategory = this.cboType.SelectedValue.ToString();
            list = new T_GdListTemplate_BLL().GetAllByCategory(fileTemp);
            //T_GdListTemplate fileList = new T_GdListTemplate();
            //fileList.GdName = "-无父级-";
            //fileList.ID = "";
            //temp_list.Add(fileList);
            foreach (var item in list)
            {
                temp_list.Add(item);
            }
            this.cboCategory.DataSource = temp_list;
            this.cboCategory.DisplayMember = "GdName";
            this.cboCategory.ValueMember = "ID";
        }
        private void txtOrderIndex_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtOrderIndex_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 加载归档目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCategory(this.cboType.SelectedValue.ToString());
        }
    }
}
