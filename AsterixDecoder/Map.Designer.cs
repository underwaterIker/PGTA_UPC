using System.Drawing;
using System.Windows.Forms;

namespace AsterixDecoder
{
    partial class Map
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
            this.components = new System.ComponentModel.Container();
            this.Map_pictureBox = new System.Windows.Forms.PictureBox();
            this.GMap_control = new GMap.NET.WindowsForms.GMapControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Play_button = new System.Windows.Forms.Button();
            this.Stop_button = new System.Windows.Forms.Button();
            this.Time_label = new System.Windows.Forms.Label();
            this.TargetData_DGV = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ExportKML_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ClearSelection_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Map_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetData_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // Map_pictureBox
            // 
            this.Map_pictureBox.Location = new System.Drawing.Point(464, 94);
            this.Map_pictureBox.Name = "Map_pictureBox";
            this.Map_pictureBox.Size = new System.Drawing.Size(1032, 547);
            this.Map_pictureBox.TabIndex = 5;
            this.Map_pictureBox.TabStop = false;
            // 
            // GMap_control
            // 
            this.GMap_control.Bearing = 0F;
            this.GMap_control.CanDragMap = true;
            this.GMap_control.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMap_control.GrayScaleMode = false;
            this.GMap_control.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMap_control.LevelsKeepInMemory = 5;
            this.GMap_control.Location = new System.Drawing.Point(464, 94);
            this.GMap_control.MarkersEnabled = true;
            this.GMap_control.MaxZoom = 2;
            this.GMap_control.MinZoom = 2;
            this.GMap_control.MouseWheelZoomEnabled = true;
            this.GMap_control.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GMap_control.Name = "GMap_control";
            this.GMap_control.NegativeMode = false;
            this.GMap_control.PolygonsEnabled = true;
            this.GMap_control.RetryLoadTile = 0;
            this.GMap_control.RoutesEnabled = true;
            this.GMap_control.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GMap_control.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMap_control.ShowTileGridLines = false;
            this.GMap_control.Size = new System.Drawing.Size(1032, 547);
            this.GMap_control.TabIndex = 6;
            this.GMap_control.Zoom = 0D;
            this.GMap_control.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.GMap_control_OnMarkerClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Play_button
            // 
            this.Play_button.Location = new System.Drawing.Point(600, 718);
            this.Play_button.Name = "Play_button";
            this.Play_button.Size = new System.Drawing.Size(119, 32);
            this.Play_button.TabIndex = 8;
            this.Play_button.Text = "Play";
            this.Play_button.UseVisualStyleBackColor = true;
            this.Play_button.Click += new System.EventHandler(this.Play_button_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.Location = new System.Drawing.Point(725, 718);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(119, 32);
            this.Stop_button.TabIndex = 9;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = true;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // Time_label
            // 
            this.Time_label.AutoSize = true;
            this.Time_label.Location = new System.Drawing.Point(958, 66);
            this.Time_label.Name = "Time_label";
            this.Time_label.Size = new System.Drawing.Size(57, 13);
            this.Time_label.TabIndex = 10;
            this.Time_label.Text = "00:00:00";
            // 
            // TargetData_DGV
            // 
            this.TargetData_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargetData_DGV.Location = new System.Drawing.Point(27, 146);
            this.TargetData_DGV.Name = "TargetData_DGV";
            this.TargetData_DGV.RowHeadersWidth = 62;
            this.TargetData_DGV.RowTemplate.Height = 28;
            this.TargetData_DGV.Size = new System.Drawing.Size(310, 311);
            this.TargetData_DGV.TabIndex = 11;
            // 
            // ExportKML_button
            // 
            this.ExportKML_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ExportKML_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportKML_button.ForeColor = System.Drawing.Color.Black;
            this.ExportKML_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ExportKML_button.Location = new System.Drawing.Point(1255, 686);
            this.ExportKML_button.Name = "ExportKML_button";
            this.ExportKML_button.Size = new System.Drawing.Size(165, 88);
            this.ExportKML_button.TabIndex = 16;
            this.ExportKML_button.Text = "Export to .KML";
            this.ExportKML_button.UseVisualStyleBackColor = false;
            this.ExportKML_button.Click += new System.EventHandler(this.ExportKML_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 681);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "TIME SCALE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 738);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "x1";
            // 
            // ClearSelection_button
            // 
            this.ClearSelection_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearSelection_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearSelection_button.Location = new System.Drawing.Point(27, 80);
            this.ClearSelection_button.Name = "ClearSelection_button";
            this.ClearSelection_button.Size = new System.Drawing.Size(310, 60);
            this.ClearSelection_button.TabIndex = 26;
            this.ClearSelection_button.Text = "CLEAR SELECTION";
            this.ClearSelection_button.UseVisualStyleBackColor = false;
            this.ClearSelection_button.Click += new System.EventHandler(this.ClearSelection_button_Click);
            // 
            // Map
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1522, 804);
            this.Controls.Add(this.ClearSelection_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExportKML_button);
            this.Controls.Add(this.TargetData_DGV);
            this.Controls.Add(this.Time_label);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.Play_button);
            this.Controls.Add(this.GMap_control);
            this.Controls.Add(this.Map_pictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Map_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetData_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Map_pictureBox;
        private GMap.NET.WindowsForms.GMapControl GMap_control;
        private Timer timer1;
        private Button Play_button;
        private Button Stop_button;
        private Label Time_label;
        private DataGridView TargetData_DGV;
        private BindingSource bindingSource1;
        private Button ExportKML_button;
        private Label label3;
        private Label label4;
        private Button ClearSelection_button;
    }
}

