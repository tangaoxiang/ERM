/*
 * 网上抄来的
 * 获得数值时最好用GetText属性，类中用LostFocus取消最后一位小数点，否则没法去掉小数点是最后一个位的情况
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using TX.Framework.WindowUI;
using System.Drawing;
using TX.Framework.WindowUI.Properties;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class NumberTextBox : System.Windows.Forms.MaskedTextBox //.TextBox
    {
        private bool showMsg = false;
        private int decimalLength = 0;//小数点后位数
        [Category("定制特性"), Description("小数点后位数，为0时是整数")]
        public int DecimalLength
        {
            get { return decimalLength; }
            set { decimalLength = value; }
        }
        ////在失去焦点时，把最后一位小数点去掉       不好用
        //protected override void OnLostFocus(EventArgs e)
        //{
        //    base.OnLostFocus(e);
        //    this.Text = this.Text.Trim('.');
        //}

        protected override void OnLeave(EventArgs e)
        {
            string tag = (this.Tag == null ? "" : this.Tag.ToString().Trim());
            if (tag != "" && this.Text != "")
            {
                string[] strArr = tag.ToLower().Split(',');
                if (strArr.Length >= 2)
                {
                    string TagText = strArr[1];
                    if (TagText.ToLower() == "int".ToLower())
                    {
                        if (!IsValidInt(this.Text))
                        {
                            TXMessageBoxExtensions.Info("提示：\"" + strArr[0] + "\" 输入错误！\n【温馨提示：只能输入1-" + _MaxValuelLength + "位正整数】");
                            this.Focus();
                            this.Text = "";
                            return;
                        }
                        else
                        {
                            this.BackColor = System.Drawing.Color.White;
                        }
                    }
                    else if (TagText.ToLower() == "number".ToLower())
                    {
                        if (!IsValidDecimal(this.Text) && strArr.Length == 2)
                        {
                            TXMessageBoxExtensions.Info("提示：\"" + strArr[0] + "\" 输入错误！\n【温馨提示：只能输入1-" + _MaxValuelLength + "位正整数或2位浮点数】");
                            this.Focus();
                            this.Text = "";
                            return;
                        }
                        //else if (!IsValidDecimal(this.Text, strArr[2]))
                        //{
                        //    TXMessageBoxExtensions.Info("提示：\"" + strArr[0] + "\" 输入错误！ \n    【温馨提示：只能输入正整数或" + strArr[2] + "位浮点数】");
                        //    this.Focus();
                        //   
                        //    return;
                        //}
                        else
                        {
                            this.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            else
            {
                if (this.BackColor == System.Drawing.Color.Red)
                    this.BackColor = System.Drawing.Color.White;
            }
            base.OnLeave(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            string tag = (this.Tag == null ? "" : this.Tag.ToString().Trim());
            if (tag != "")
            {
                string[] strArr = tag.ToLower().Split(',');
                if (strArr.Length >= 2)
                {
                    string TagText = strArr[1];
                    if (TagText == "int".ToLower())
                    {
                        if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else if (TagText == "number".ToLower())
                    {
                        if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)//46 .
                        {
                            if (e.KeyChar == 46 && this.Text.IndexOf('.') == -1)
                            {

                            }
                            else
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                    }
                }
            }
            base.OnKeyPress(e);
        }
        /// <summary>
        /// 验证是否为浮点数 2位小数
        /// </summary>
        /// <param name="strIn">Value值</param>
        /// <param name="numLength">小数位长度</param>
        /// <returns>bool:true正确 false错误</returns>
        private bool IsValidDecimal(string strIn, string numLength)
        {
            string mathText = @"^(([1-9]\d)|(0))(\.\d{0," + numLength + "})?$";//=@"^(([1-9]\d{0,6})|(0))(\.\d{1,2})?$"
            return Regex.IsMatch(strIn, mathText);
        }

        /// <summary>
        /// 验证是否为浮点数 2位小数
        /// </summary>
        /// <param name="strIn">Value值</param>
        /// <param name="numLength">小数位长度</param>
        /// <returns>bool:true正确 false错误</returns>
        private bool IsValidDecimal(string strIn)
        {
            string mathText = @"^(([1-9]\d{0," + _MaxValuelLength + "})|(0))(\\.\\d{1,2})?$";//=@"^(([1-9]\d{0,6})|(0))(\.\d{1,2})?$"  //"^(\\d+(\\.\\d+))|(\\d{1,2}+(\\.\\d{1,2}+))?$"

            return Regex.IsMatch(strIn, mathText);
        }

        private int _MaxValuelLength = 1;
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("最大输入字符数")]
        [DefaultValue(32767)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxValuelLength
        {
            get { return _MaxValuelLength; }
            set { this._MaxValuelLength = value; }
        }

        /// <summary>
        /// 验证是否整数
        /// </summary>
        /// <param name="strIn">Value值</param>
        /// <returns>bool:true正确 false错误</returns>
        private bool IsValidInt(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\d{0," + _MaxValuelLength + "}$");
        }

        [Category("定制特性"), Description("获得文本数值时用此方法，不要直接用Text")]
        public string GetText
        {
            get
            {
                string strIn = this.Text.Trim();
                decimal strOut = 0;
                try
                {
                    strOut = decimal.Parse(strIn);
                }
                catch { }
                if (strIn == "0")
                    return "0";
                else if (strOut == 0)
                {
                    return "";
                }
                else
                {
                    return strOut.ToString();
                }
            }
        }
        [Category("定制特性"), Description("获得整数时用此方法，不要直接用Text")]
        public int GetInt
        {
            get
            {
                if (string.IsNullOrEmpty(this.Text.Trim()))
                    return 0;
                else
                    return (int)decimal.Parse(this.Text.Replace(" ", ""));
            }
        }
        [Category("定制特性"), Description("获得数值时用此方法，不要直接用Text")]
        public decimal GetDecimal
        {
            get
            {
                string strIn = this.Text.Trim();
                decimal strOut = 0;
                try
                {
                    strOut = Decimal.Parse(strIn);
                }
                catch { }
                return strOut;
            }
        }
        public double GetDouble
        {
            get
            {
                string strIn = this.Text.Trim();
                double strOut = 0;
                try
                {
                    strOut = double.Parse(strIn);
                }
                catch { }
                return strOut;
            }
        }
        [Category("定制特性"), Description("是否弹出提示框")]
        public bool ShowMsg
        {
            get
            {
                return showMsg;
            }
            set
            {
                showMsg = value;
            }
        }
        ///// <summary>
        ///// 捕获Mouse的Paste消息
        ///// </summary>
        ///// <summary>
        ///// 捕获Ctrl+V快捷键操作
        ///// </summary>
        ///// <summary>
        ///// 屏蔽非数字键
        ///// </summary>
        ///// <summary>
        ///// 通过消息模拟键盘录入
        ///// </summary>
        ///// <summary>
        ///// 清除当前TextBox的选择
        ///// </summary>
        ///// <summary>
        ///// 删除当前字符, 并计算SelectionStart值
        ///// </summary>

        #region fileds

        /// <summary>
        /// 圆角值
        /// </summary>
        private int _CornerRadius = 1;

        /// <summary>
        /// 内部的文本控件
        /// </summary>
        public MaskedTextBox _TextBox;

        /// <summary>
        /// 边框颜色
        /// </summary>
        private Color _BorderColor = SkinManager.CurrentSkin.BorderColor;

        /// <summary>
        /// 控件激活时的高亮边框色
        /// </summary>
        private Color _HeightLightBolorColor = SkinManager.CurrentSkin.HeightLightControlColor.First;

        /// <summary>
        /// 控件内文本和图片的排列位置
        /// </summary>
        private ToolStripItemAlignment _ImageAlignment = ToolStripItemAlignment.Left;

        /// <summary>
        /// 控件内部的偏移量
        /// </summary>
        private Size _Offset = new Size(2, 1);

        /// <summary>
        /// 静态图标按钮对象
        /// </summary>
        private static readonly object _ImageButton = new object();

        /// <summary>
        /// 内嵌的图标显示控件（用这个控件可以显示任意的图标了，包括动画图标）
        /// </summary>
        private PictureBox _pictureBox;

        /// <summary>
        /// 文本值
        /// </summary>
        private string _Text = string.Empty;

        /// <summary>
        /// 当前控件状态
        /// </summary>
        private EnumControlState _ControlState = EnumControlState.Default;

        /// <summary>
        /// 必填
        /// </summary>
        private bool _Required = false;

        #endregion

        #region Events

        public delegate void ImageButtonClickEventHandler(object sender, EventArgs e);

        /// <summary>
        /// 当图标按钮被点击时发生
        /// </summary>
        [Category("TXEvents")]
        [Description("当图标按钮被点击时发生")]
        public event ImageButtonClickEventHandler OnImageButtonClick
        {
            add { base.Events.AddHandler(_ImageButton, value); }
            remove { base.Events.RemoveHandler(_ImageButton, value); }
        }

        /// <summary>
        /// 当文本框Text值发生变化时发生
        /// </summary>
        public EventHandler OnTextChanged;

        #endregion

        #region Initializes

        /// <summary>
        /// 初始化控件数据。
        /// (构造函数).Initializes a new instance of the <see cref="ERM.UI.Controls.TXTextBoxEX"/> class.
        /// </summary>
        /// User:Ryan  CreateTime:2011-08-19 15:31.
        public NumberTextBox()
            : base()
        {
            this.Text = "";
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            this.InitializeComponent();
            base.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new Size(180, 25);
            this._TextBox.GotFocus += new EventHandler(_TextBox_GotFocus);
            this._TextBox.LostFocus += new EventHandler(_TextBox_LostFocus);
            this._TextBox.MouseDown+=_TextBox_MouseDown;
            this._TextBox.KeyUp+=_TextBox_KeyUp;
            this._TextBox.KeyDown += _TextBox_KeyDown;
            this._TextBox.KeyPress+=_TextBox_KeyPress;
            this._pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Text = string.Empty;
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
        int index = 0;
        private void _TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            index =Convert.ToInt32(this._TextBox.SelectionStart.ToString());  
        }

        private void _TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tag = (this.Tag == null ? "" : this.Tag.ToString().Trim());
            if (tag != "")
            {
                string[] strArr = tag.ToLower().Split(',');
                if (strArr.Length >= 2)
                {
                    string TagText = strArr[1];
                    if (TagText == "int".ToLower())
                    {
                        if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 || (this.Text.Length >= _MaxValuelLength && this._TextBox.SelectedText == "") || (this._TextBox.SelectionLength != this.Text.Length && e.KeyChar == 48))
                        {
                            e.Handled = true;
                        }
                    }
                    else if (TagText == "number".ToLower())
                    {
                        if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 || (this.Text.Length >= _MaxValuelLength && this._TextBox.SelectedText == "") || (this._TextBox.SelectionLength != this.Text.Length && e.KeyChar == 48))
                        {
                            if (e.KeyChar == 46 && this.Text.IndexOf('.') == -1)
                            {
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }

                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }

                if ((e.KeyChar > 47 && e.KeyChar < 58 && this.Text.Length < _MaxValuelLength))
                {
                    if (((this.Text.Length == 1 && this.Text == "0" && this._TextBox.SelectedText == "") || (this.Text.Length > 1 && this.Text.Substring(0, 1) == "0")) && e.KeyChar != 8 && e.KeyChar != 46 && this.Text.IndexOf('.') == -1)
                    {
                        e.Handled = true;
                    }
                    else if (index == 0 && this.Text.Length > 1 && e.KeyChar == 48 && e.KeyChar != 46 && this.Text.IndexOf('.') == -1)
                    {
                        e.Handled = true;
                    }
                    else if (this._TextBox.SelectionStart == 0 && this._TextBox.SelectionLength != this.Text.Length && e.KeyChar == 48 && this._TextBox.SelectedText != "" && e.KeyChar != 46 && this.Text.IndexOf('.') == -1)
                    {
                        e.Handled = true;
                    }
                    else if (this.Text.IndexOf(".") > -1 && this.Text.Substring(this.Text.IndexOf("."), this.Text.Length - this.Text.IndexOf(".")).Length > 2 && index > this.Text.IndexOf(".") && this._TextBox.SelectedText.Length != this.Text.Length)
                    {
                        e.Handled = true;
                    }
                    else if (this.Text.IndexOf(".") > -1 && index == 0 && e.KeyChar == 48)
                    {
                        e.Handled = true;
                    }
                    else if (this.Text.IndexOf(".") > -1 && this._TextBox.SelectionStart==0 && e.KeyChar == 48&&this._TextBox.SelectedText.Length != this.Text.Length)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }

            base.OnKeyPress(e);
        }

        private void _TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void _TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            index = Convert.ToInt32(this._TextBox.SelectionStart.ToString());  
        }

        #endregion

        #region Properties

        /// <summary>
        /// 获取或者设置控件的圆角值
        /// </summary>
        /// <value>The corner radius.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:22.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("圆角的半径值")]
        [DefaultValue(1)]
        public int CornerRadius
        {
            get { return this._CornerRadius; }
            set
            {
                this._CornerRadius = value;
                if (value > this._Offset.Width * 3)
                {
                    this.Offset = new Size(value / 3, this.Offset.Height);
                }
                else
                {
                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        public new BorderStyle BorderStyle
        {
            get { return BorderStyle.None; }
            set { }
        }

        //[Browsable(false)]
        //public new Color BackColor
        //{
        //    get { return base.BackColor; }
        //    set
        //    {
        //        this.BackColor = value;
        //    }
        //}

        /// <summary>
        ///  获取或者设置边框颜色
        /// </summary>
        /// <value>The color of the border.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:23.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return this._BorderColor; }
            set
            {
                this._BorderColor = value;
                base.Invalidate();
            }
        }

        /// <summary>
        ///  获取或者设置控件是否必填，使用该功能，不可再使用图标按钮功能了！
        /// </summary>
        /// <value>The color of the border.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:23.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("必填")]
        public bool Required
        {
            get { return this._Required; }
            set
            {
                this._Required = value;
                if (value)
                {
                    this.Image = string.IsNullOrEmpty(this.Text) ? Resources.requried : Resources.check;
                    this.ImageAlignment = ToolStripItemAlignment.Right;
                    this.ImageSize = new Size(14, 14);
                    this.OnImageButtonClick += new ImageButtonClickEventHandler(TXTextBox_OnImageButtonClick);
                }
                else
                {
                    //this.Image = null;
                    //this.ImageSize = new Size(18, 18);
                    this.OnImageButtonClick -= new ImageButtonClickEventHandler(TXTextBox_OnImageButtonClick);
                }

                base.Invalidate();
            }
        }

        /// <summary>
        ///  获取或者设置高亮时的边框色
        /// </summary>
        /// <value>The color of the height lightColor bolor.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:23.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("边框的高亮色")]
        public Color HeightLightBolorColor
        {
            get { return this._HeightLightBolorColor; }
            set
            {
                this._HeightLightBolorColor = value;
            }
        }

        /// <summary>
        ///  获取或者设置图标对象
        /// </summary>
        /// <value>The image.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:24.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("图标")]
        public Image Image
        {
            get { return this._pictureBox.Image; }
            set
            {
                this._pictureBox.Image = value;
                if (value != null)
                {
                    this._pictureBox.Size = new Size(16, 16);
                }

                this.ResetControlSize();
                this.Invalidate();
            }
        }

        /// <summary>
        ///  获取或者设置图标显示的大小
        /// </summary>
        /// <value>The size of the image.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:24.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("图标的大小")]
        [DefaultValue(typeof(Size), "18,18")]
        public Size ImageSize
        {
            get { return this._pictureBox.Size; }
            set
            {
                this._pictureBox.Size = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///  获取或者设置图标放置的位置
        /// </summary>
        /// <value>The image alignment.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:24.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("图标的安放位置")]
        [DefaultValue(typeof(ToolStripItemAlignment), "Left")]
        public ToolStripItemAlignment ImageAlignment
        {
            get { return this._ImageAlignment; }
            set
            {
                this._ImageAlignment = value;
                this.ResetControlSize();
                this.Invalidate();
            }
        }

        /// <summary>
        ///  获取或者设置控件内部的偏移量
        /// </summary>
        /// <value>The offset.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:24.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("控件内部的偏移量")]
        [DefaultValue(typeof(Size), "2,1")]
        public Size Offset
        {
            get { return this._Offset; }
            set
            {
                this._Offset = value;
                this.ResetControlSize();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 获取或设置控件显示的文字的字体。
        /// </summary>
        /// <returns>
        /// 要应用于由控件显示的文本的 <see cref="T:System.Drawing.Font"/>。默认为 <see cref="P:System.Windows.Forms.Control.DefaultFont"/> 属性的值。
        /// </returns>
        /// User:Ryan  CreateTime:2011-08-19 15:25.
        [Category("TXProperties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this._TextBox.Font = value;
            }
        }

        /// <summary>
        /// 获取或设置控件的前景色。
        /// </summary>
        /// <returns>
        /// 控件的前景 <see cref="T:System.Drawing.Color"/>。默认为 <see cref="P:System.Windows.Forms.Control.DefaultForeColor"/> 属性的值。
        /// </returns>
        /// User:Ryan  CreateTime:2011-08-19 15:25.
        [Category("TXProperties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                this._TextBox.ForeColor = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否将控件的元素对齐以支持使用从右向左的字体的区域设置。
        /// </summary>
        /// User:Ryan  CreateTime:2011-08-19 15:25.
        [Category("TXProperties")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set
            {
                base.RightToLeft = value;
                this._TextBox.RightToLeft = value;
            }
        }

        /// <summary>
        /// 获取或设置哪些控件边框停靠到其父控件并确定控件如何随其父级一起调整大小。
        /// </summary>
        /// <returns>
        /// 	<see cref="T:System.Windows.Forms.DockStyle"/> 值之一。默认为 <see cref="F:System.Windows.Forms.DockStyle.None"/>。
        /// </returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
        /// 分配的值不是 <see cref="T:System.Windows.Forms.DockStyle"/> 值之一。
        /// </exception>
        /// User:Ryan  CreateTime:2011-08-19 15:26.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("这个，你懂的！")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override System.Windows.Forms.DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = value;
            }
        }

        /// <summary>
        /// 文本值
        /// </summary>
        /// <returns>
        /// 与该控件关联的文本。
        /// </returns>
        /// User:Ryan  CreateTime:2011-08-19 15:26.
        [Category("TXProperties")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        public new string Text
        {
            get
            {
                if (this._TextBox == null)
                {
                    this._TextBox = new MaskedTextBox();
                }
                return this._TextBox.Text;
            }
            set
            {
                if (this._TextBox == null)
                {
                    this._TextBox = new MaskedTextBox();
                }
                this._TextBox.Text = string.IsNullOrEmpty(value) || value.Contains("txTextBox") ? string.Empty : value;
                ////Requried attribute
                if (this.Required)
                {
                    this.Image = string.IsNullOrEmpty(value) ? Resources.requried : Resources.check;
                }
            }
        }

        /// <summary>
        /// 获取设置设置文本的最大长度
        /// </summary>
        /// <value>The length of the max.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:28.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("最大输入字符数")]
        [DefaultValue(32767)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxLength
        {
            get
            {
                return this._TextBox.MaxLength;
            }
            set
            {
                this._TextBox.MaxLength = value > 0 ? value : 0;
            }
        }

        /// <summary>
        /// 获取设置设置文本输入是否支持多行
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:29.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("是否支持多行输入")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public bool Multiline
        {
            get
            {
                return this._TextBox.Multiline;
            }
            set
            {
                this._TextBox.Multiline = value;
                if (value)
                {
                    this.Size = new Size(250, 45);
                }
                else
                {
                    this.Size = new Size(180, 25);
                }
            }
        }

        /// <summary>
        /// 获取设置设置密码格式的显示字符
        /// </summary>
        /// <value>The password char.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:29.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("密码字符")]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public char PasswordChar
        {
            get
            {
                return this._TextBox.PasswordChar;
            }
            set
            {
                this._TextBox.PasswordChar = value;
            }
        }

        /// <summary>
        /// 获取设置设置文本值是否只读
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:29.
        [Category("TXProperties")]
        [Browsable(true)]
        [Description("是否只读")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ReadOnly
        {
            get
            {
                return this._TextBox.ReadOnly;
            }
            set
            {
                this._TextBox.ReadOnly = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 获取设置设置多行显示时的滑动条显示方式
        /// </summary>
        /// <value>The scroll bars.</value>
        /// User:Ryan  CreateTime:2011-08-19 15:30.
        //[Category("TXProperties")]
        //[Browsable(true)]
        //[Description("多行输入时的滚动条显示")]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[DefaultValue(typeof(ScrollBars), "None")]
        //public ScrollBars ScrollBars
        //{
        //    get
        //    {
        //        return this._TextBox.ScrollBars;
        //    }
        //    set
        //    {
        //        this._TextBox.ScrollBars = value;
        //    }
        //}

        /// <summary>
        /// 获取或设置一个值，该值指示控件是否可以对用户交互作出响应。
        /// </summary>
        /// <value></value>
        /// <returns>
        /// 如果控件可以对用户交互作出响应，则为 true；否则为 false。默认为 true。
        /// </returns>
        /// User:Ryan  CreateTime:2011-08-19 15:30.
        [Category("TXProperties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public new bool Enabled
        {
            get { return this._TextBox.Enabled; }
            set
            {
                this._TextBox.Enabled = value;
            }
        }

        #endregion

        #region  private Events

        private void _TextBox_LostFocus(object sender, EventArgs e)
        {
            this._ControlState = EnumControlState.Default;
            this.Invalidate();
        }

        private void _TextBox_GotFocus(object sender, EventArgs e)
        {
            this._ControlState = EnumControlState.HeightLight;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.DrawBorder(e.Graphics);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.ResetControlSize();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ResetControlSize();
            this.Text = this.Text == this.Name ? string.Empty : this.Text;
        }

        private void _pictureBox_Click(object sender, EventArgs e)
        {
            ImageButtonClickEventHandler handler = base.Events[_ImageButton] as ImageButtonClickEventHandler;
            if (handler != null)
            {
                handler(this.Text, e);
            }
        }

        private void _TextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Required)
            {
                this.Image = string.IsNullOrEmpty(this.Text.Trim()) ? Resources.requried : Resources.check;
            }

            if (this.OnTextChanged != null)
            {
                this.OnTextChanged(sender, e);
            }
        }

        private void TXTextBox_OnImageButtonClick(object sender, EventArgs e)
        {
            TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info("亲，该项为必填哦！");
        }

        #endregion

        #region public methods

        public void SelectAll()
        {
            this._TextBox.SelectAll();
        }

        public void Focus()
        {
            this._TextBox.Focus();
        }

        public void Select()
        {
            this._TextBox.Select();
        }

        public void Select(int start, int length)
        {
            this._TextBox.Select(start, length);
        }

        #endregion

        #region private methods

        private void ResetControlSize()
        {
            if (this._pictureBox.Image == null)
            {
                this._pictureBox.Size = Size.Empty;
            }

            int mid = this.Height / 2;
            switch (this._ImageAlignment)
            {
                case ToolStripItemAlignment.Left:
                    this._pictureBox.Location = new Point(this._Offset.Width + 1, mid - this.ImageSize.Height / 2);
                    this._TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    this._TextBox.Size = new Size(this.Width - 4, this.Height - this._Offset.Height * 2);
                    this._TextBox.Location = new Point(this._pictureBox.Width + this._Offset.Width, mid - this._TextBox.Height / 2 - 1);
                    break;
                case ToolStripItemAlignment.Right:
                    this._pictureBox.Location = new Point(this.Width - this._Offset.Width - this._pictureBox.Width - 2, mid - this._pictureBox.Height / 2);
                    this._TextBox.Size = new Size(this.Width - this._pictureBox.Width - this._Offset.Width * 3 - 3, this.Height - this._Offset.Height * 2 - 6);
                    this._TextBox.Location = new Point(this._Offset.Width + 2, mid - this._TextBox.Height / 2);
                    break;
            }
        }

        private void DrawBorder(Graphics g)
        {
            GDIHelper.InitializeGraphics(g);
            Rectangle rect = new Rectangle(1, 1, this.Width - 3, this.Height - 3);
            RoundRectangle roundRect = new RoundRectangle(rect, this._CornerRadius);
            Color c = (!this._TextBox.Enabled || this._TextBox.ReadOnly) ? Color.FromArgb(215, 250, 243) : Color.White;
            this._TextBox.BackColor = c;
            //this._TextBox.Font = this._Font;
            //this._TextBox.ForeColor = this._ForeColor;
            GDIHelper.FillPath(g, roundRect, c, c);
            GDIHelper.DrawPathBorder(g, roundRect, this._BorderColor);
            if (this._ControlState == EnumControlState.HeightLight)
            {
                GDIHelper.DrawPathBorder(g, roundRect, SkinManager.CurrentSkin.HeightLightControlColor.Second);
                GDIHelper.DrawPathOuterBorder(g, roundRect, SkinManager.CurrentSkin.HeightLightControlColor.First);
            }
        }

        #endregion

        #region InitializeComponent

        private void InitializeComponent()
        {
            this._TextBox = new System.Windows.Forms.MaskedTextBox();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _TextBox
            // 
            this._TextBox.BackColor = System.Drawing.SystemColors.Window;
            this._TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._TextBox.Location = new System.Drawing.Point(32, 4);
            this._TextBox.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this._TextBox.Name = "_TextBox";
            this._TextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TextBox.Size = new System.Drawing.Size(223, 16);
            this._TextBox.TabIndex = 0;
            this._TextBox.TextChanged += new System.EventHandler(this._TextBox_TextChanged);
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(6, 0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(20, 20);
            this._pictureBox.TabIndex = 1;
            this._pictureBox.TabStop = false;
            this._pictureBox.Click += new System.EventHandler(this._pictureBox_Click);
            // 
            // NumberTextBox
            // 
            this.Controls.Add(this._pictureBox);
            this.Controls.Add(this._TextBox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "ERM.UI.Controls.TXTextBoxEX";
            this.Size = new System.Drawing.Size(333, 23);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberTextBox_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberTextBox_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumberTextBox_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void NumberTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void NumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
