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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.TargetData_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // GMap_control
            // 
            this.GMap_control.Bearing = 0F;
            this.GMap_control.CanDragMap = true;
            this.GMap_control.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMap_control.GrayScaleMode = false;
            this.GMap_control.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMap_control.LevelsKeepInMemory = 5;
            this.GMap_control.Location = new System.Drawing.Point(-1, 29);
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
            this.GMap_control.Size = new System.Drawing.Size(1101, 450);
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
            this.Play_button.BackColor = System.Drawing.Color.Snow;
            this.Play_button.FlatAppearance.BorderSize = 3;
            this.Play_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play_button.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_button.Location = new System.Drawing.Point(177, 567);
            this.Play_button.Name = "Play_button";
            this.Play_button.Size = new System.Drawing.Size(119, 32);
            this.Play_button.TabIndex = 8;
            this.Play_button.Text = "PLAY";
            this.Play_button.UseVisualStyleBackColor = false;
            this.Play_button.Click += new System.EventHandler(this.Play_button_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.BackColor = System.Drawing.Color.Snow;
            this.Stop_button.FlatAppearance.BorderSize = 3;
            this.Stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop_button.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_button.Location = new System.Drawing.Point(177, 615);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(119, 32);
            this.Stop_button.TabIndex = 9;
            this.Stop_button.Text = "STOP";
            this.Stop_button.UseVisualStyleBackColor = false;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // Time_label
            // 
            this.Time_label.AutoSize = true;
            this.Time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_label.Location = new System.Drawing.Point(506, 2);
            this.Time_label.Name = "Time_label";
            this.Time_label.Size = new System.Drawing.Size(88, 24);
            this.Time_label.TabIndex = 10;
            this.Time_label.Text = "00:00:00";
            // 
            // TargetData_DGV
            // 
            this.TargetData_DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.TargetData_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargetData_DGV.Location = new System.Drawing.Point(339, 543);
            this.TargetData_DGV.Name = "TargetData_DGV";
            this.TargetData_DGV.RowHeadersWidth = 62;
            this.TargetData_DGV.RowTemplate.Height = 28;
            this.TargetData_DGV.Size = new System.Drawing.Size(288, 262);
            this.TargetData_DGV.TabIndex = 11;
            // 
            // ExportKML_button
            // 
            this.ExportKML_button.BackColor = System.Drawing.Color.Snow;
            this.ExportKML_button.FlatAppearance.BorderSize = 3;
            this.ExportKML_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportKML_button.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportKML_button.ForeColor = System.Drawing.Color.Black;
            this.ExportKML_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ExportKML_button.Location = new System.Drawing.Point(174, 669);
            this.ExportKML_button.Name = "ExportKML_button";
            this.ExportKML_button.Size = new System.Drawing.Size(122, 70);
            this.ExportKML_button.TabIndex = 16;
            this.ExportKML_button.Text = "EXPORT TO .KML";
            this.ExportKML_button.UseVisualStyleBackColor = false;
            this.ExportKML_button.Click += new System.EventHandler(this.ExportKML_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 569);
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
            this.label4.Location = new System.Drawing.Point(59, 669);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "x1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 603);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(78, 603);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(56, 56);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(795, 654);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(53, 17);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "SMR";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(720, 636);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 32;
            this.checkBox2.Text = "ADSB";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(795, 624);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(59, 17);
            this.checkBox3.TabIndex = 33;
            this.checkBox3.Text = "MLAT";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(699, 543);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 20);
            this.textBox1.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(682, 566);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "SIMULATION HOUR";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 492);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(1014, 45);
            this.trackBar1.TabIndex = 36;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Map
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExportKML_button);
            this.Controls.Add(this.TargetData_DGV);
            this.Controls.Add(this.Time_label);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.Play_button);
            this.Controls.Add(this.GMap_control);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "00:00:00.000";
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TargetData_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private TextBox textBox1;
        private Label label1;
        private TrackBar trackBar1;
    }
}

