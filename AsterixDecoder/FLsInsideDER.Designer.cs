namespace AsterixDecoder
{
    partial class FLsInsideDER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.SelectRwy_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveCSV_button = new System.Windows.Forms.Button();
            this.FLs_DGV = new System.Windows.Forms.DataGridView();
            this.FLs_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.FLs_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FLs_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectRwy_comboBox
            // 
            this.SelectRwy_comboBox.BackColor = System.Drawing.Color.White;
            this.SelectRwy_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectRwy_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectRwy_comboBox.FormattingEnabled = true;
            this.SelectRwy_comboBox.Items.AddRange(new object[] {
            "24L",
            "06R",
            "24R",
            "06L",
            "20",
            "02"});
            this.SelectRwy_comboBox.Location = new System.Drawing.Point(55, 80);
            this.SelectRwy_comboBox.Name = "SelectRwy_comboBox";
            this.SelectRwy_comboBox.Size = new System.Drawing.Size(279, 32);
            this.SelectRwy_comboBox.TabIndex = 13;
            this.SelectRwy_comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectRwy_comboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "SELECT TAKE OFF RUNWAY";
            // 
            // SaveCSV_button
            // 
            this.SaveCSV_button.BackColor = System.Drawing.Color.Snow;
            this.SaveCSV_button.Enabled = false;
            this.SaveCSV_button.FlatAppearance.BorderSize = 3;
            this.SaveCSV_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveCSV_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCSV_button.ForeColor = System.Drawing.Color.Black;
            this.SaveCSV_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SaveCSV_button.Location = new System.Drawing.Point(170, 579);
            this.SaveCSV_button.Name = "SaveCSV_button";
            this.SaveCSV_button.Size = new System.Drawing.Size(152, 76);
            this.SaveCSV_button.TabIndex = 17;
            this.SaveCSV_button.Text = "SAVE DATA IN .CSV";
            this.SaveCSV_button.UseVisualStyleBackColor = false;
            this.SaveCSV_button.Click += new System.EventHandler(this.SaveCSV_button_Click);
            // 
            // FLs_DGV
            // 
            this.FLs_DGV.AllowUserToAddRows = false;
            this.FLs_DGV.AllowUserToDeleteRows = false;
            this.FLs_DGV.AllowUserToResizeColumns = false;
            this.FLs_DGV.AllowUserToResizeRows = false;
            this.FLs_DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.FLs_DGV.ColumnHeadersHeight = 46;
            this.FLs_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.FLs_DGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FLs_DGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.FLs_DGV.Location = new System.Drawing.Point(12, 156);
            this.FLs_DGV.MultiSelect = false;
            this.FLs_DGV.Name = "FLs_DGV";
            this.FLs_DGV.ReadOnly = true;
            this.FLs_DGV.RowHeadersVisible = false;
            this.FLs_DGV.RowHeadersWidth = 82;
            this.FLs_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.FLs_DGV.RowTemplate.Height = 26;
            this.FLs_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FLs_DGV.Size = new System.Drawing.Size(535, 387);
            this.FLs_DGV.TabIndex = 18;
            // 
            // FLs_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.FLs_chart.ChartAreas.Add(chartArea2);
            this.FLs_chart.Location = new System.Drawing.Point(563, 129);
            this.FLs_chart.Name = "FLs_chart";
            this.FLs_chart.Size = new System.Drawing.Size(509, 414);
            this.FLs_chart.TabIndex = 19;
            this.FLs_chart.Text = "chart1";
            // 
            // FLsInsideDER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 721);
            this.Controls.Add(this.FLs_chart);
            this.Controls.Add(this.FLs_DGV);
            this.Controls.Add(this.SaveCSV_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectRwy_comboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FLsInsideDER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLsInsideDER";
            ((System.ComponentModel.ISupportInitialize)(this.FLs_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FLs_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectRwy_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveCSV_button;
        public System.Windows.Forms.DataGridView FLs_DGV;
        private System.Windows.Forms.DataVisualization.Charting.Chart FLs_chart;
    }
}