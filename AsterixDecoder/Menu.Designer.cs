using System.Drawing;
using System.Windows.Forms;

namespace AsterixDecoder
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMap_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUs_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataList_DGV = new System.Windows.Forms.DataGridView();
            this.dataItems_DGV = new System.Windows.Forms.DataGridView();
            this.Item_DGV = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItems_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFile_ToolStripMenuItem,
            this.showMap_ToolStripMenuItem,
            this.aboutUs_ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1121, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadFile_ToolStripMenuItem
            // 
            this.loadFile_ToolStripMenuItem.Name = "loadFile_ToolStripMenuItem";
            this.loadFile_ToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.loadFile_ToolStripMenuItem.Text = "Load file";
            this.loadFile_ToolStripMenuItem.Click += new System.EventHandler(this.loadFile_ToolStripMenuItem_Click);
            // 
            // showMap_ToolStripMenuItem
            // 
            this.showMap_ToolStripMenuItem.Name = "showMap_ToolStripMenuItem";
            this.showMap_ToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.showMap_ToolStripMenuItem.Text = "Show map";
            this.showMap_ToolStripMenuItem.Click += new System.EventHandler(this.showMap_ToolStripMenuItem_Click);
            // 
            // aboutUs_ToolStripMenuItem1
            // 
            this.aboutUs_ToolStripMenuItem1.Name = "aboutUs_ToolStripMenuItem1";
            this.aboutUs_ToolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.aboutUs_ToolStripMenuItem1.Text = "About us";
            this.aboutUs_ToolStripMenuItem1.Click += new System.EventHandler(this.aboutUsToolStripMenuItem1_Click);
            // 
            // dataList_DGV
            // 
            this.dataList_DGV.AllowUserToAddRows = false;
            this.dataList_DGV.AllowUserToDeleteRows = false;
            this.dataList_DGV.AllowUserToResizeColumns = false;
            this.dataList_DGV.AllowUserToResizeRows = false;
            this.dataList_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataList_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataList_DGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataList_DGV.Location = new System.Drawing.Point(12, 27);
            this.dataList_DGV.Name = "dataList_DGV";
            this.dataList_DGV.ReadOnly = true;
            this.dataList_DGV.RowHeadersVisible = false;
            this.dataList_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataList_DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataList_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataList_DGV.Size = new System.Drawing.Size(310, 504);
            this.dataList_DGV.TabIndex = 8;
            this.dataList_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataList_DGV_CellClick);
            // 
            // dataItems_DGV
            // 
            this.dataItems_DGV.AllowUserToAddRows = false;
            this.dataItems_DGV.AllowUserToDeleteRows = false;
            this.dataItems_DGV.AllowUserToResizeColumns = false;
            this.dataItems_DGV.AllowUserToResizeRows = false;
            this.dataItems_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataItems_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItems_DGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataItems_DGV.Location = new System.Drawing.Point(328, 27);
            this.dataItems_DGV.Name = "dataItems_DGV";
            this.dataItems_DGV.ReadOnly = true;
            this.dataItems_DGV.RowHeadersVisible = false;
            this.dataItems_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataItems_DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataItems_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataItems_DGV.Size = new System.Drawing.Size(380, 504);
            this.dataItems_DGV.TabIndex = 9;
            this.dataItems_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataItems_DGV_CellClick);
            // 
            // Item_DGV
            // 
            this.Item_DGV.AllowUserToAddRows = false;
            this.Item_DGV.AllowUserToDeleteRows = false;
            this.Item_DGV.AllowUserToResizeColumns = false;
            this.Item_DGV.AllowUserToResizeRows = false;
            this.Item_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Item_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Item_DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.Item_DGV.Location = new System.Drawing.Point(714, 27);
            this.Item_DGV.Name = "Item_DGV";
            this.Item_DGV.ReadOnly = true;
            this.Item_DGV.RowHeadersVisible = false;
            this.Item_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Item_DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Item_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Item_DGV.Size = new System.Drawing.Size(380, 504);
            this.Item_DGV.TabIndex = 10;
            // 
            // Menu
            // 
            this.ClientSize = new System.Drawing.Size(1121, 543);
            this.Controls.Add(this.Item_DGV);
            this.Controls.Add(this.dataItems_DGV);
            this.Controls.Add(this.dataList_DGV);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItems_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadFile_ToolStripMenuItem;
        private ToolStripMenuItem showMap_ToolStripMenuItem;
        private ToolStripMenuItem aboutUs_ToolStripMenuItem1;
        private DataGridView dataList_DGV;
        private DataGridView dataItems_DGV;
        private DataGridView Item_DGV;
    }
}

