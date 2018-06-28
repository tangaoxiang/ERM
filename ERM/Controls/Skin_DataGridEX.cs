using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
   public class Skin_DataGridEX:CCWin.SkinControl.SkinDataGridView
    {
       public Skin_DataGridEX():base() {
           base.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
          // this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           base.BackgroundColor = System.Drawing.Color.White;
           base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           base.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
           base.ColumnHeadersHeight = 26;
           base.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
           base.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
           base.ColumnSelectForeColor = System.Drawing.Color.Black;
           base.EnableHeadersVisualStyles = false;
           base.GridColor = System.Drawing.Color.Gainsboro;
           base.HeadFont = base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
           base.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
           base.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
           base.LineNumberForeColor = System.Drawing.Color.Black;
           base.MultiSelect = false;
           base.ReadOnly = false;
           base.EditMode = DataGridViewEditMode.EditOnEnter;
           base.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
           base.RowHeadersWidth = 22;
           base.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
           base.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
           base.RowTemplate.MinimumHeight = 25;
           base.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
           base.SkinGridColor = System.Drawing.Color.Gainsboro;
           base.TitleBackColorBegin = System.Drawing.Color.White;
           base.RowHeadersVisible = false;
          // base.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
           //base.RowHeadersDefaultCellStyle.Padding = new Padding(base.RowHeadersWidth);
           base.ColumnForeColor = System.Drawing.Color.Black;
           base.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
           base.AllowUserToAddRows = false;
       }
    }
}
