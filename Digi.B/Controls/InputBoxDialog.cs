using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Digi.B
{
    /// <summary>
    /// Summary description for InputBox.
    /// 
    public class InputBoxDialog : System.Windows.Forms.Form
    {

        #region Windows Contols and Constructor

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtInput;
        private Label lblPrompt;
        /// <summary>
        /// Required designer variable.
        /// 
        private System.ComponentModel.Container components = null;

        public InputBoxDialog()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        #endregion

        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// 
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(288, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(288, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "取消";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(10, 82);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(340, 21);
            this.txtInput.TabIndex = 0;
            // 
            // lblPrompt
            // 
            this.lblPrompt.Location = new System.Drawing.Point(12, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(270, 67);
            this.lblPrompt.TabIndex = 3;
            // 
            // InputBoxDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(360, 113);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBoxDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputBox";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Private Variables
        string formCaption = string.Empty;
        string formPrompt = string.Empty;
        string inputResponse = string.Empty;
        string defaultValue = string.Empty;
        #endregion

        #region Public Properties
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

        #endregion

        #region Form and Control Events
        private void InputBox_Load(object sender, System.EventArgs e)
        {
            this.txtInput.Text = defaultValue;
            this.lblPrompt.Text = formPrompt;
            this.Text = formCaption;
            this.txtInput.SelectionStart = 0;
            this.txtInput.SelectionLength = this.txtInput.Text.Length;
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
        #endregion


    }

}
