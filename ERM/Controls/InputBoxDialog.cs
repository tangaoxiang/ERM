using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
using ERM.UI.Controls;
namespace ERM.UI
{
    /// <summary>
    /// Summary description for InputBox.
    /// 
    public class InputBoxDialog : ERM.UI.Controls.Skin_DevEX
    {
        private SkinButtonEX btnOK;
        private SkinButtonEX button1;
        private ERM.UI.Controls.TXTextBoxEX txtInput;
        private Label lblPrompt;
        private IContainer components;
    
        public InputBoxDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOK = new ERM.UI.Controls.SkinButtonEX();
            this.button1 = new ERM.UI.Controls.SkinButtonEX();
            this.txtInput = new ERM.UI.Controls.TXTextBoxEX();
            this.lblPrompt = new ERM.UI.Controls.SkinLabelEX();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            //this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOK.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btnOK.BaseColor = System.Drawing.Color.Empty;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.DownBack = null;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(336, 57);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.MouseBack = null;
            this.btnOK.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Palace = true;
            this.btnOK.Radius = 10;
            this.btnOK.Size = new System.Drawing.Size(64, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "È·¶¨";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button1
            // 
            //this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.button1.BaseColor = System.Drawing.Color.Empty;
            this.button1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.DownBack = null;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(336, 98);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.MouseBack = null;
            this.button1.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.button1.Name = "button1";
            this.button1.NormlBack = null;
            this.button1.Palace = true;
            this.button1.Radius = 10;
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "È¡Ïû";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 164);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(396, 23);
            this.txtInput.TabIndex = 0;
            // 
            // lblPrompt
            // 
            this.lblPrompt.Location = new System.Drawing.Point(14, 61);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(315, 95);
            this.lblPrompt.TabIndex = 3;
            // 
            // InputBoxDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(420, 204);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBoxDialog";
            this.ShowInTaskbar = false;
            this.Text = "InputBox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        string formCaption = string.Empty;
        string formPrompt = string.Empty;
        string inputResponse = string.Empty;
        string defaultValue = string.Empty;
        public string FormCaption
        {
            get { return formCaption; }
            set { formCaption = value; }
        } // property FormCaption
        public string FormPrompt
        {
            get { return formPrompt; }
            set { formPrompt = value; }
        } // property FormPrompt
        public string InputResponse
        {
            get { return inputResponse; }
            set { inputResponse = value; }
        } // property InputResponse
        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        } // property DefaultValue
        private void InputBox_Load(object sender, System.EventArgs e)
        {
            this.txtInput.Text = defaultValue;
            this.lblPrompt.Text = formPrompt;
            this.Text = formCaption;
            //this.txtInput.SelectionStart = 0;
           // this.txtInput.SelectionLength = this.txtInput.Text.Length;
            this.txtInput.Focus();
        }
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            InputResponse = this.txtInput.Text;
            this.Close();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            InputResponse = "";
            this.Close();
        }
    }
}
