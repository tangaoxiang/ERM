using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace DigiPower.ERM.Common
{
    public class PDFManager : IDisposable
    {
        private Control m_parent = null;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        public PDFManager(Control parent)
        {
            m_parent = parent;
            Initialize();
        }
        private bool Initialize()
        {
            try
            {
                if (axAcroPDF1 != null)
                {
                    Dispose();
                }
                this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
                ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
                m_parent.SuspendLayout();
                this.axAcroPDF1.Parent = m_parent;
                this.axAcroPDF1.Visible = false;
                this.axAcroPDF1.Enabled = false;
                this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
                this.axAcroPDF1.Name = "axAcroPDF1";
                this.axAcroPDF1.Size = new System.Drawing.Size(m_parent.Bounds.Width, m_parent.Bounds.Height);
                this.axAcroPDF1.TabIndex = 0;
                m_parent.Controls.Add(this.axAcroPDF1);
                ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
                m_parent.ResumeLayout();
                axAcroPDF1.setShowScrollbars(true);
                axAcroPDF1.setShowToolbar(false);
                axAcroPDF1.setLayoutMode("SinglePage");
                axAcroPDF1.setPageMode("thumbs");
                axAcroPDF1.setView("FitH");
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private void Dispose()
        {
            if (axAcroPDF1 != null)
            {
                axAcroPDF1.Dispose();
                axAcroPDF1 = null;
            }
        }
        public bool Open(string filename)
        {
            if (axAcroPDF1 == null)
            {
                return false;
            }
            try
            {
                if (axAcroPDF1.src == filename)
                {
                    return true;
                }
                axAcroPDF1.LoadFile(filename);
                axAcroPDF1.gotoFirstPage();
                axAcroPDF1.Refresh();
                axAcroPDF1.Enabled = true;
                axAcroPDF1.Visible = true;
            }
            catch
            {
                return false;
            }
            return true;
        }
        public void Refresh()
        {
            if (axAcroPDF1 == null)
                return;
            axAcroPDF1.SetBounds(0, 0, m_parent.Bounds.Width, m_parent.Bounds.Height);
        }
        public void NextPage()
        {
            if (axAcroPDF1 == null)
                return;
            axAcroPDF1.gotoNextPage();
        }
        public void PreviousPage()
        {
            if (axAcroPDF1 == null)
                return;
            axAcroPDF1.gotoPreviousPage();
        }
        public bool Visible
        {
            get { if (axAcroPDF1 != null) { return axAcroPDF1.Visible; } else return false; }
            set { if (axAcroPDF1 != null) { axAcroPDF1.Visible = value; } }
        }
        public bool Toolbar
        {
            set { if (axAcroPDF1 != null) { axAcroPDF1.setShowToolbar(value); } }
        }
        public float Scroll
        {
            set { if (axAcroPDF1 != null) { axAcroPDF1.setViewScroll("FitH", value); } }
        }
        void IDisposable.Dispose()
        {
            if (axAcroPDF1 != null)
            {
                axAcroPDF1.Dispose();
                axAcroPDF1 = null;
            }
        }
        private void KillProcess(string processName)
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            try
            {
                foreach (Process thisproc in Process.GetProcessesByName(processName))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch (Exception Exc)
            {
            }
        }
        /// <summary>
        /// ¹Ø±Õ AcroRd32
        /// </summary>
        public void KillProcess()
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            try
            {
                foreach (Process thisproc in Process.GetProcessesByName("AcroRd32"))
                {
                    int wdwa = thisproc.StartInfo.EnvironmentVariables.Count;
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch (Exception Exc)
            {
            }
        }
    }
}
