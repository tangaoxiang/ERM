using System.Windows.Forms;
using ERM.MDL;
using ERM.BLL;
using System.Collections.Generic;
using System;
using ERM.UI.Common;
using System.Configuration;
using TX.Framework.WindowUI.Forms;
using TX.Framework.WindowUI.Controls;
using System.Drawing;
using CCWin.SkinControl;

namespace ERM.UI.Controls
{
    /// <summary>
    /// 交通工程用户控件
    /// </summary>
    public partial class UC_Traffic : UserControl, IProject
    {
        T_Traffic trafficMDL;
        IList<T_Traffic_Detail> detailList;
        IList<T_Dict> list;
        static string labelText = string.Empty;
        public UC_Traffic()
        {
            InitializeComponent();
            //SetControl(this.Controls);
        }

        //private void SetControl(ControlCollection controls)
        //{
        //    for (int i = 0; i < controls.Count; i++)
        //    {
        //        if (controls[i].Name.ToLower().Contains("label"))
        //        {
        //            controls[i].ForeColor = Color.Black;
        //        }
        //        else
        //        {
        //            SetControl(controls[i].Controls);
        //        }
        //    }
        //}

        /// <summary>
        /// 获取市政交通工程扩展信息
        /// 新增和更新操作获取数据的共用方法，
        /// Flag参数区分是控件赋值还是控件取值
        /// </summary>
        public object GetInfo(string where, object objModel, int flag = 0)
        {
            //if (this.cbo_jt_jcxs.Items.Count == 0)
            //{
            //    IList<MDL.T_Dict> ds2 = new ERM.BLL.T_Dict_BLL().FindByKeyWord("sz_jcxs");
            //    cbo_jt_jcxs.DisplayMember = "displayname";
            //    cbo_jt_jcxs.ValueMember = "valuename";
            //    cbo_jt_jcxs.DataSource = ds2;
            //}

            //if (this.cbo_jt_mcxs.Items.Count == 0)
            //{
            //    IList<MDL.T_Dict> ds2 = new ERM.BLL.T_Dict_BLL().FindByKeyWord("sz_mcxs");
            //    cbo_jt_mcxs.DisplayMember = "displayname";
            //    cbo_jt_mcxs.ValueMember = "valuename";
            //    cbo_jt_mcxs.DataSource = ds2;
            //}

            trafficMDL = new T_Traffic_BLL().QueryTraffic_ByProjID(where);
            //如果为空，表示新增，创建一个用来接收控件数据的对象
            if (trafficMDL == null)
            {
                trafficMDL = new T_Traffic();
                if (ConfigurationManager.AppSettings["lockItem"].ToString()=="1")
                {
                    //this.ContextMenuStrip = this.contextMenuStrip1;
                }
            }

            #region 获取或设置信息
            //获取交通扩展主工程信息
            trafficMDL = Reflections.Control_Reflection(typeof(T_Traffic), trafficMDL, this.Controls, "txt_jt_|cbo_jt_", flag) as T_Traffic;
            //主工程信息
            objModel = Reflections.Control_Reflection(typeof(T_Projects), objModel, this.Controls, "txt_jt_", flag) as T_Projects;
            //获取交通工程附属扩展明细
            detailList = new T_Traffic_Detail_BLL().QueryTraffic_ByProjID(trafficMDL.ID == null ? "" : trafficMDL.ID);
            //获取交通明细的类型字典
            ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
            list = dicData.FindByKeyWord("TrafficType");

            //动态初始化管道信息控件
            InitControl(((detailList.Count - 10) / 3) - 1);

            //如果为空则增加空对象集合，用来接收填写的控件数据，以备更新时使用
            if (detailList.Count == 0)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    detailList.Add(new T_Traffic_Detail());
                    detailList[j].ID = Guid.NewGuid().ToString();
                }
            }
            #endregion

            #region 动态添加管道项
            //动态添加键值,应对自动增加的管道项
            //if (list.Count - 4 < this.panel1.Controls.Count)
            //{
            //    for (int m = 0; m < (this.panel1.Controls.Count - 3) / 3; m++)
            //    {
            //        list.Add(new T_Dict() { ValueName = "gsg" + (m + 2), DisplayName = "给水管(" + (m + 2) + ")", KeyWord = "TrafficType", ID = list.Count + 1 });
            //        list.Add(new T_Dict() { ValueName = "ysg" + (m + 2), DisplayName = "雨水管(" + (m + 2) + ")", KeyWord = "TrafficType", ID = list.Count + 1 });
            //        list.Add(new T_Dict() { ValueName = "wsg" + (m + 2), DisplayName = "污水管(" + (m + 2) + ")", KeyWord = "TrafficType", ID = list.Count + 1 });
            //    }
            //}

            //为新增加的管道项添加空对象接收数据
            if (list.Count > detailList.Count)
            {
                int length = list.Count - detailList.Count;
                for (int i = 0; i < length; i++)
                {
                    detailList.Add(new T_Traffic_Detail());
                    detailList[detailList.Count - 1].ID = Guid.NewGuid().ToString();
                }
            }
            #endregion

            for (var item = 0; item < list.Count; item++)
            {
                //循环获取或设置明细
                detailList[item] = Reflections.Control_Reflection(typeof(T_Traffic_Detail), detailList[item], this.Controls, "txt_jt_" + list[item].ValueName + "_", flag) as T_Traffic_Detail;
                detailList[item].Types = list[item].ValueName;
            }
            //返回工程对象
            return objModel;
        }

        /// <summary>
        /// 保存市政交通扩展信息
        /// </summary>
        /// <param name="ProjectModel">工程模型</param>
        /// <param name="ItemModel">项目模型</param>
        /// <param name="Model">备用，可空</param>
        /// <returns></returns>
        public bool Add(T_Projects ProjectModel, T_Item ItemModel, object Model = null)
        {
            ProjectModel.shrq = System.DateTime.Now.ToString("yyyy.MM.dd");
            trafficMDL.ProjectID = ProjectModel.ProjectNO;
            trafficMDL.ID = Guid.NewGuid().ToString();
            return (new T_Traffic_BLL().Add(ProjectModel, ItemModel, trafficMDL, detailList));
        }

        /// <summary>
        /// 更新交通扩展信息和明细
        /// </summary>
        /// <param name="ProjectModel">工程模型</param>
        /// <param name="ItemModel">项目模型</param>
        /// <param name="Model">备用，可空</param>
        /// <returns></returns>
        public bool Updates(T_Projects ProjectModel, T_Item ItemModel = null, object Model = null)
        {
            return (new T_Traffic_BLL().Update(ProjectModel, ItemModel, trafficMDL, detailList));
        }

        /// <summary>
        /// 初始管道控件
        /// </summary>
        /// <param name="count"></param>
        private void InitControl(int count)
        {
            //int index = 0;

            //for (int i = 0; i < count; i++)
            //{
            //    index = this.panel1.Controls.Count / 3 + 1;
            //    if (index > 10)
            //    {
            //        TXMessageBoxExtensions.Info("最多添加10项!");
            //        return;
            //    }

            //    CreateControl(index, this.groupBox8);
            //    CreateControl(index, this.groupBox1);
            //    CreateControl(index, this.groupBox3);
            //}
        }

        /// <summary>
        /// 创建控件
        /// </summary>
        /// <param name="index"></param>
        private void CreateControl(int index, TXGroupBox ParenGroupBox)
        {
            TXGroupBox groupBox = new TXGroupBox();

            groupBox.Name = groupBox.Name + index;
            groupBox.Text = ParenGroupBox.Text.Substring(0, ParenGroupBox.Text.IndexOf('(')) + "(" + index + ")";
            groupBox.Size = ParenGroupBox.Size;
            groupBox.CaptionColor = ParenGroupBox.CaptionColor;
            groupBox.CaptionFont = ParenGroupBox.CaptionFont;
            groupBox.Font = ParenGroupBox.Font;
            groupBox.Location = new System.Drawing.Point(ParenGroupBox.Location.X, ((ParenGroupBox.Height + 5) * (index - 2)) + ParenGroupBox.Location.Y);
            groupBox.CaptionFont = ParenGroupBox.CaptionFont;
            foreach (var item in ParenGroupBox.Controls)
            {
                if (item is SkinLabelEX)
                {
                    SkinLabelEX label = new SkinLabelEX();
                    SkinLabelEX parnLabe = item as SkinLabelEX;
                    label.Location = new System.Drawing.Point(parnLabe.Location.X, parnLabe.Location.Y);
                    label.Text = parnLabe.Text;
                    groupBox.Controls.Add(label);
                }
                if (item is NumberTextBoxEX)
                {
                    NumberTextBoxEX numBox = new NumberTextBoxEX();
                    NumberTextBoxEX parenNumberBox = item as NumberTextBoxEX;
                    numBox.Location = new System.Drawing.Point(parenNumberBox.Location.X, parenNumberBox.Location.Y);
                    numBox.Size = parenNumberBox.Size;
                    numBox.Name = parenNumberBox.Name.Replace(parenNumberBox.Name.Substring(parenNumberBox.Name.LastIndexOf('_') - 1, 1), index.ToString());
                    numBox.Tag = parenNumberBox.Tag.ToString().Substring(0, 3) + "(" + index + ")" + labelText + ",number";
                    numBox.BorderStyle = parenNumberBox.BorderStyle;
                    numBox.TabIndex = numBox.TabIndex + index;
                    groupBox.Controls.Add(numBox);
                }
                if (item is TXTextBoxEX)
                {
                    TXTextBoxEX txtBox = new TXTextBoxEX();
                    TXTextBoxEX parenTxtBox = item as TXTextBoxEX;
                    txtBox.Location = new System.Drawing.Point(parenTxtBox.Location.X, parenTxtBox.Location.Y);
                    txtBox.Size = parenTxtBox.Size;
                    txtBox.Name = parenTxtBox.Name.Replace(parenTxtBox.Name.Substring(parenTxtBox.Name.LastIndexOf('_') - 1, 1), index.ToString());
                    groupBox.Controls.Add(txtBox);
                }
            }
            //this.panel1.Controls.Add(groupBox);
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addStrip_Click(object sender, EventArgs e)
        {
            InitControl(1);
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void label144_Click(object sender, EventArgs e)
        {

        }

        private void txt_jt_end_y_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txt_jt_wsg2_zhxs_Load(object sender, EventArgs e)
        {

        }

        private void UC_Traffic_Load(object sender, EventArgs e)
        {

        }
    }
}
