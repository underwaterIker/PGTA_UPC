using System.Drawing;
using System.Windows.Forms;

namespace AsterixDecoder
{
    partial class Tables
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
            this.dataList_DGV = new System.Windows.Forms.DataGridView();
            this.dataItems_DGV = new System.Windows.Forms.DataGridView();
            this.Item_DGV = new System.Windows.Forms.DataGridView();
            this.ExportCSV_button = new System.Windows.Forms.Button();
            this.Filter_comboBox = new System.Windows.Forms.ComboBox();
            this.Filter_textBox = new System.Windows.Forms.TextBox();
            this.Filter_button = new System.Windows.Forms.Button();
            this.UndoFilter_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataList_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItems_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item_DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dataList_DGV
            // 
            this.dataList_DGV.AllowUserToAddRows = false;
            this.dataList_DGV.AllowUserToDeleteRows = false;
            this.dataList_DGV.AllowUserToResizeColumns = false;
            this.dataList_DGV.AllowUserToResizeRows = false;
            this.dataList_DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataList_DGV.ColumnHeadersHeight = 46;
            this.dataList_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataList_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataList_DGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataList_DGV.Location = new System.Drawing.Point(6, 6);
            this.dataList_DGV.MultiSelect = false;
            this.dataList_DGV.Name = "dataList_DGV";
            this.dataList_DGV.ReadOnly = true;
            this.dataList_DGV.RowHeadersVisible = false;
            this.dataList_DGV.RowHeadersWidth = 82;
            this.dataList_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataList_DGV.RowTemplate.Height = 26;
            this.dataList_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataList_DGV.Size = new System.Drawing.Size(310, 504);
            this.dataList_DGV.TabIndex = 8;
            this.dataList_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataList_DGV_CellClick);
            this.dataList_DGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataList_DGV_RowPrePaint);
            // 
            // dataItems_DGV
            // 
            this.dataItems_DGV.AllowUserToAddRows = false;
            this.dataItems_DGV.AllowUserToDeleteRows = false;
            this.dataItems_DGV.AllowUserToResizeColumns = false;
            this.dataItems_DGV.AllowUserToResizeRows = false;
            this.dataItems_DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataItems_DGV.ColumnHeadersHeight = 46;
            this.dataItems_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataItems_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataItems_DGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataItems_DGV.Location = new System.Drawing.Point(322, 6);
            this.dataItems_DGV.MultiSelect = false;
            this.dataItems_DGV.Name = "dataItems_DGV";
            this.dataItems_DGV.ReadOnly = true;
            this.dataItems_DGV.RowHeadersVisible = false;
            this.dataItems_DGV.RowHeadersWidth = 82;
            this.dataItems_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataItems_DGV.RowTemplate.Height = 26;
            this.dataItems_DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataItems_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataItems_DGV.Size = new System.Drawing.Size(380, 504);
            this.dataItems_DGV.TabIndex = 9;
            this.dataItems_DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataItems_DGV_CellClick);
            this.dataItems_DGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataItems_DGV_RowPrePaint);
            // 
            // Item_DGV
            // 
            this.Item_DGV.AllowUserToAddRows = false;
            this.Item_DGV.AllowUserToDeleteRows = false;
            this.Item_DGV.AllowUserToResizeColumns = false;
            this.Item_DGV.AllowUserToResizeRows = false;
            this.Item_DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.Item_DGV.ColumnHeadersHeight = 46;
            this.Item_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Item_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Item_DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.Item_DGV.Location = new System.Drawing.Point(708, 6);
            this.Item_DGV.MultiSelect = false;
            this.Item_DGV.Name = "Item_DGV";
            this.Item_DGV.ReadOnly = true;
            this.Item_DGV.RowHeadersVisible = false;
            this.Item_DGV.RowHeadersWidth = 82;
            this.Item_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Item_DGV.RowTemplate.Height = 26;
            this.Item_DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Item_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Item_DGV.Size = new System.Drawing.Size(380, 504);
            this.Item_DGV.TabIndex = 10;
            this.Item_DGV.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.Item_DGV_RowPrePaint);
            // 
            // ExportCSV_button
            // 
            this.ExportCSV_button.BackColor = System.Drawing.Color.Snow;
            this.ExportCSV_button.FlatAppearance.BorderSize = 3;
            this.ExportCSV_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportCSV_button.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportCSV_button.ForeColor = System.Drawing.Color.Black;
            this.ExportCSV_button.Location = new System.Drawing.Point(842, 585);
            this.ExportCSV_button.Name = "ExportCSV_button";
            this.ExportCSV_button.Size = new System.Drawing.Size(131, 88);
            this.ExportCSV_button.TabIndex = 11;
            this.ExportCSV_button.Text = "EXPORT TO .CSV";
            this.ExportCSV_button.UseVisualStyleBackColor = false;
            this.ExportCSV_button.Click += new System.EventHandler(this.ExportCSV_button_Click);
            // 
            // Filter_comboBox
            // 
            this.Filter_comboBox.BackColor = System.Drawing.Color.White;
            this.Filter_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Filter_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_comboBox.FormattingEnabled = true;
            this.Filter_comboBox.Items.AddRange(new object[] {
            "Track Number",
            "Target Address",
            "Target Identification",
            "Mode 3A Code"});
            this.Filter_comboBox.Location = new System.Drawing.Point(376, 546);
            this.Filter_comboBox.Name = "Filter_comboBox";
            this.Filter_comboBox.Size = new System.Drawing.Size(279, 32);
            this.Filter_comboBox.TabIndex = 12;
            this.Filter_comboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_comboBox_SelectedIndexChanged);
            // 
            // Filter_textBox
            // 
            this.Filter_textBox.BackColor = System.Drawing.Color.White;
            this.Filter_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Filter_textBox.Enabled = false;
            this.Filter_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_textBox.Location = new System.Drawing.Point(376, 597);
            this.Filter_textBox.Name = "Filter_textBox";
            this.Filter_textBox.Size = new System.Drawing.Size(279, 29);
            this.Filter_textBox.TabIndex = 13;
            this.Filter_textBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Filter_textBox_MouseClick);
            // 
            // Filter_button
            // 
            this.Filter_button.BackColor = System.Drawing.Color.Snow;
            this.Filter_button.Enabled = false;
            this.Filter_button.FlatAppearance.BorderSize = 3;
            this.Filter_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filter_button.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filter_button.ForeColor = System.Drawing.Color.Black;
            this.Filter_button.Location = new System.Drawing.Point(376, 644);
            this.Filter_button.Name = "Filter_button";
            this.Filter_button.Size = new System.Drawing.Size(135, 64);
            this.Filter_button.TabIndex = 14;
            this.Filter_button.Text = "APPLY FILTER";
            this.Filter_button.UseVisualStyleBackColor = false;
            this.Filter_button.Click += new System.EventHandler(this.Filter_button_Click);
            // 
            // UndoFilter_button
            // 
            this.UndoFilter_button.BackColor = System.Drawing.Color.Snow;
            this.UndoFilter_button.Enabled = false;
            this.UndoFilter_button.FlatAppearance.BorderSize = 3;
            this.UndoFilter_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UndoFilter_button.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UndoFilter_button.ForeColor = System.Drawing.Color.Black;
            this.UndoFilter_button.Location = new System.Drawing.Point(543, 644);
            this.UndoFilter_button.Name = "UndoFilter_button";
            this.UndoFilter_button.Size = new System.Drawing.Size(112, 64);
            this.UndoFilter_button.TabIndex = 15;
            this.UndoFilter_button.Text = "UNDO FILTER";
            this.UndoFilter_button.UseVisualStyleBackColor = false;
            this.UndoFilter_button.Click += new System.EventHandler(this.UndoFilter_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(409, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 86);
            this.label1.TabIndex = 16;
            this.label1.Text = "SELECT A\r\nMESSAGE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(797, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 86);
            this.label2.TabIndex = 17;
            this.label2.Text = "SELECT A\r\nDATA ITEM";
            // 
            // Tables
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UndoFilter_button);
            this.Controls.Add(this.Filter_button);
            this.Controls.Add(this.Filter_textBox);
            this.Controls.Add(this.Filter_comboBox);
            this.Controls.Add(this.ExportCSV_button);
            this.Controls.Add(this.Item_DGV);
            this.Controls.Add(this.dataItems_DGV);
            this.Controls.Add(this.dataList_DGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asterix Decoder";
            ((System.ComponentModel.ISupportInitialize)(this.dataList_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataItems_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item_DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataItems_DGV;
        private DataGridView Item_DGV;
        private Button ExportCSV_button;
        private ComboBox Filter_comboBox;
        private TextBox Filter_textBox;
        private Button Filter_button;
        private Button UndoFilter_button;
        public DataGridView dataList_DGV;
        private Label label1;
        private Label label2;
    }
}

