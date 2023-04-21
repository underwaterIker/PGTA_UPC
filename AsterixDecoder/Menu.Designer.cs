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
            this.LoadFile = new System.Windows.Forms.Button();
            this.AboutUs = new System.Windows.Forms.Button();
            this.ViewData = new System.Windows.Forms.Button();
            this.MapView = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadFile
            // 
            this.LoadFile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFile.Location = new System.Drawing.Point(12, 139);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(135, 58);
            this.LoadFile.TabIndex = 0;
            this.LoadFile.Text = "Load";
            this.LoadFile.UseVisualStyleBackColor = false;
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // AboutUs
            // 
            this.AboutUs.Location = new System.Drawing.Point(12, 296);
            this.AboutUs.Name = "AboutUs";
            this.AboutUs.Size = new System.Drawing.Size(135, 52);
            this.AboutUs.TabIndex = 2;
            this.AboutUs.Text = "About Us";
            this.AboutUs.UseVisualStyleBackColor = true;
            this.AboutUs.Click += new System.EventHandler(this.AboutUs_Click);
            // 
            // ViewData
            // 
            this.ViewData.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ViewData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ViewData.Location = new System.Drawing.Point(12, 220);
            this.ViewData.Name = "ViewData";
            this.ViewData.Size = new System.Drawing.Size(135, 59);
            this.ViewData.TabIndex = 3;
            this.ViewData.Text = "View Data";
            this.ViewData.UseVisualStyleBackColor = false;
            this.ViewData.Click += new System.EventHandler(this.ViewData_Click);
            // 
            // MapView
            // 
            this.MapView.Location = new System.Drawing.Point(12, 364);
            this.MapView.Name = "MapView";
            this.MapView.Size = new System.Drawing.Size(135, 55);
            this.MapView.TabIndex = 4;
            this.MapView.Text = "Map View";
            this.MapView.UseVisualStyleBackColor = true;
            this.MapView.Click += new System.EventHandler(this.MapView_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(298, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 398);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(298, 107);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(624, 398);
            this.gMapControl1.TabIndex = 6;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // Menu
            // 
            this.ClientSize = new System.Drawing.Size(970, 543);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MapView);
            this.Controls.Add(this.ViewData);
            this.Controls.Add(this.AboutUs);
            this.Controls.Add(this.LoadFile);
            this.Name = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadFile;
        private System.Windows.Forms.Button AboutUs;
        private System.Windows.Forms.Button ViewData;
        private System.Windows.Forms.Button MapView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
    }
}

