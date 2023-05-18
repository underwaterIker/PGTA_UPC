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
            this.ExportKML_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeScaleIndicator_label = new System.Windows.Forms.Label();
            this.TimeScaleBackward_button = new System.Windows.Forms.PictureBox();
            this.TimeScaleForward_button = new System.Windows.Forms.PictureBox();
            this.SMR_checkBox = new System.Windows.Forms.CheckBox();
            this.ADSB_checkBox = new System.Windows.Forms.CheckBox();
            this.MLAT_checkBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Set_button = new System.Windows.Forms.Button();
            this.ZoomInLEBL_button = new System.Windows.Forms.Button();
            this.Hour_comboBox = new System.Windows.Forms.ComboBox();
            this.Minuts_comboBox = new System.Windows.Forms.ComboBox();
            this.Seconds_comboBox = new System.Windows.Forms.ComboBox();
            this.SeeTraces_checkBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TargetData_DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleBackward_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleForward_button)).BeginInit();
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
            this.Play_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_button.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.Play_button.Location = new System.Drawing.Point(186, 496);
            this.Play_button.Name = "Play_button";
            this.Play_button.Size = new System.Drawing.Size(119, 45);
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
            this.Stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_button.ForeColor = System.Drawing.Color.DarkRed;
            this.Stop_button.Location = new System.Drawing.Point(186, 547);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(119, 47);
            this.Stop_button.TabIndex = 9;
            this.Stop_button.Text = "STOP";
            this.Stop_button.UseVisualStyleBackColor = false;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // Time_label
            // 
            this.Time_label.AutoSize = true;
            this.Time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_label.Location = new System.Drawing.Point(476, 4);
            this.Time_label.Name = "Time_label";
            this.Time_label.Size = new System.Drawing.Size(88, 24);
            this.Time_label.TabIndex = 10;
            this.Time_label.Text = "00:00:00";
            // 
            // TargetData_DGV
            // 
            this.TargetData_DGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.TargetData_DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TargetData_DGV.Location = new System.Drawing.Point(353, 498);
            this.TargetData_DGV.Name = "TargetData_DGV";
            this.TargetData_DGV.RowHeadersVisible = false;
            this.TargetData_DGV.RowHeadersWidth = 62;
            this.TargetData_DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.TargetData_DGV.RowTemplate.Height = 28;
            this.TargetData_DGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TargetData_DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TargetData_DGV.Size = new System.Drawing.Size(320, 226);
            this.TargetData_DGV.TabIndex = 11;
            // 
            // ExportKML_button
            // 
            this.ExportKML_button.BackColor = System.Drawing.Color.Snow;
            this.ExportKML_button.FlatAppearance.BorderSize = 3;
            this.ExportKML_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportKML_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportKML_button.ForeColor = System.Drawing.Color.Black;
            this.ExportKML_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ExportKML_button.Location = new System.Drawing.Point(171, 632);
            this.ExportKML_button.Name = "ExportKML_button";
            this.ExportKML_button.Size = new System.Drawing.Size(152, 76);
            this.ExportKML_button.TabIndex = 16;
            this.ExportKML_button.Text = "EXPORT TO .KML";
            this.ExportKML_button.UseVisualStyleBackColor = false;
            this.ExportKML_button.Click += new System.EventHandler(this.ExportKML_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "TIME SCALE";
            // 
            // TimeScaleIndicator_label
            // 
            this.TimeScaleIndicator_label.AutoSize = true;
            this.TimeScaleIndicator_label.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TimeScaleIndicator_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeScaleIndicator_label.Location = new System.Drawing.Point(63, 583);
            this.TimeScaleIndicator_label.Name = "TimeScaleIndicator_label";
            this.TimeScaleIndicator_label.Size = new System.Drawing.Size(27, 20);
            this.TimeScaleIndicator_label.TabIndex = 22;
            this.TimeScaleIndicator_label.Text = "x1";
            // 
            // TimeScaleBackward_button
            // 
            this.TimeScaleBackward_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TimeScaleBackward_button.Image = ((System.Drawing.Image)(resources.GetObject("TimeScaleBackward_button.Image")));
            this.TimeScaleBackward_button.Location = new System.Drawing.Point(12, 524);
            this.TimeScaleBackward_button.Name = "TimeScaleBackward_button";
            this.TimeScaleBackward_button.Size = new System.Drawing.Size(50, 50);
            this.TimeScaleBackward_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TimeScaleBackward_button.TabIndex = 27;
            this.TimeScaleBackward_button.TabStop = false;
            this.TimeScaleBackward_button.Click += new System.EventHandler(this.TimeScaleBackward_button_Click);
            // 
            // TimeScaleForward_button
            // 
            this.TimeScaleForward_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TimeScaleForward_button.Image = ((System.Drawing.Image)(resources.GetObject("TimeScaleForward_button.Image")));
            this.TimeScaleForward_button.Location = new System.Drawing.Point(96, 524);
            this.TimeScaleForward_button.Name = "TimeScaleForward_button";
            this.TimeScaleForward_button.Size = new System.Drawing.Size(55, 55);
            this.TimeScaleForward_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TimeScaleForward_button.TabIndex = 29;
            this.TimeScaleForward_button.TabStop = false;
            this.TimeScaleForward_button.Click += new System.EventHandler(this.TimeScaleForward_button_Click);
            // 
            // SMR_checkBox
            // 
            this.SMR_checkBox.AutoSize = true;
            this.SMR_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMR_checkBox.ForeColor = System.Drawing.Color.Yellow;
            this.SMR_checkBox.Location = new System.Drawing.Point(738, 627);
            this.SMR_checkBox.Name = "SMR_checkBox";
            this.SMR_checkBox.Size = new System.Drawing.Size(73, 28);
            this.SMR_checkBox.TabIndex = 31;
            this.SMR_checkBox.Text = "SMR";
            this.SMR_checkBox.UseVisualStyleBackColor = true;
            this.SMR_checkBox.CheckedChanged += new System.EventHandler(this.SMR_checkBox_CheckedChanged);
            // 
            // ADSB_checkBox
            // 
            this.ADSB_checkBox.AutoSize = true;
            this.ADSB_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADSB_checkBox.ForeColor = System.Drawing.Color.Red;
            this.ADSB_checkBox.Location = new System.Drawing.Point(738, 689);
            this.ADSB_checkBox.Name = "ADSB_checkBox";
            this.ADSB_checkBox.Size = new System.Drawing.Size(83, 28);
            this.ADSB_checkBox.TabIndex = 32;
            this.ADSB_checkBox.Text = "ADSB";
            this.ADSB_checkBox.UseVisualStyleBackColor = true;
            this.ADSB_checkBox.CheckedChanged += new System.EventHandler(this.ADSB_checkBox_CheckedChanged);
            // 
            // MLAT_checkBox
            // 
            this.MLAT_checkBox.AutoSize = true;
            this.MLAT_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MLAT_checkBox.ForeColor = System.Drawing.Color.Green;
            this.MLAT_checkBox.Location = new System.Drawing.Point(738, 657);
            this.MLAT_checkBox.Name = "MLAT_checkBox";
            this.MLAT_checkBox.Size = new System.Drawing.Size(84, 28);
            this.MLAT_checkBox.TabIndex = 33;
            this.MLAT_checkBox.Text = "MLAT";
            this.MLAT_checkBox.UseVisualStyleBackColor = true;
            this.MLAT_checkBox.CheckedChanged += new System.EventHandler(this.MLAT_checkBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(711, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "SIMULATION STARTING HOUR:";
            // 
            // Set_button
            // 
            this.Set_button.BackColor = System.Drawing.Color.Snow;
            this.Set_button.FlatAppearance.BorderSize = 3;
            this.Set_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Set_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Set_button.ForeColor = System.Drawing.Color.Black;
            this.Set_button.Location = new System.Drawing.Point(963, 547);
            this.Set_button.Name = "Set_button";
            this.Set_button.Size = new System.Drawing.Size(73, 43);
            this.Set_button.TabIndex = 36;
            this.Set_button.Text = "Set";
            this.Set_button.UseVisualStyleBackColor = false;
            this.Set_button.Click += new System.EventHandler(this.Set_button_Click);
            // 
            // ZoomInLEBL_button
            // 
            this.ZoomInLEBL_button.BackColor = System.Drawing.Color.Snow;
            this.ZoomInLEBL_button.FlatAppearance.BorderSize = 3;
            this.ZoomInLEBL_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZoomInLEBL_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomInLEBL_button.ForeColor = System.Drawing.Color.Black;
            this.ZoomInLEBL_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ZoomInLEBL_button.Location = new System.Drawing.Point(12, 632);
            this.ZoomInLEBL_button.Name = "ZoomInLEBL_button";
            this.ZoomInLEBL_button.Size = new System.Drawing.Size(139, 76);
            this.ZoomInLEBL_button.TabIndex = 37;
            this.ZoomInLEBL_button.Text = "ZOOM IN LEBL";
            this.ZoomInLEBL_button.UseVisualStyleBackColor = false;
            this.ZoomInLEBL_button.Click += new System.EventHandler(this.ZoomInLEBL_button_Click);
            // 
            // Hour_comboBox
            // 
            this.Hour_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hour_comboBox.FormattingEnabled = true;
            this.Hour_comboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.Hour_comboBox.Location = new System.Drawing.Point(715, 551);
            this.Hour_comboBox.Name = "Hour_comboBox";
            this.Hour_comboBox.Size = new System.Drawing.Size(70, 28);
            this.Hour_comboBox.TabIndex = 38;
            this.Hour_comboBox.Text = "Hour";
            // 
            // Minuts_comboBox
            // 
            this.Minuts_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minuts_comboBox.FormattingEnabled = true;
            this.Minuts_comboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.Minuts_comboBox.Location = new System.Drawing.Point(793, 551);
            this.Minuts_comboBox.Name = "Minuts_comboBox";
            this.Minuts_comboBox.Size = new System.Drawing.Size(70, 28);
            this.Minuts_comboBox.TabIndex = 41;
            this.Minuts_comboBox.Text = "Min";
            // 
            // Seconds_comboBox
            // 
            this.Seconds_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seconds_comboBox.FormattingEnabled = true;
            this.Seconds_comboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.Seconds_comboBox.Location = new System.Drawing.Point(870, 551);
            this.Seconds_comboBox.Name = "Seconds_comboBox";
            this.Seconds_comboBox.Size = new System.Drawing.Size(70, 28);
            this.Seconds_comboBox.TabIndex = 42;
            this.Seconds_comboBox.Text = "Sec";
            // 
            // SeeTraces_checkBox
            // 
            this.SeeTraces_checkBox.AutoSize = true;
            this.SeeTraces_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeeTraces_checkBox.Location = new System.Drawing.Point(865, 657);
            this.SeeTraces_checkBox.Name = "SeeTraces_checkBox";
            this.SeeTraces_checkBox.Size = new System.Drawing.Size(158, 28);
            this.SeeTraces_checkBox.TabIndex = 43;
            this.SeeTraces_checkBox.Text = "SEE TRACES";
            this.SeeTraces_checkBox.UseVisualStyleBackColor = true;
            this.SeeTraces_checkBox.CheckedChanged += new System.EventHandler(this.SeeTraces_checkBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(434, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 68);
            this.label2.TabIndex = 44;
            this.label2.Text = "CLICK ON\r\nA TARGET";
            // 
            // Map
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SeeTraces_checkBox);
            this.Controls.Add(this.Seconds_comboBox);
            this.Controls.Add(this.Minuts_comboBox);
            this.Controls.Add(this.Hour_comboBox);
            this.Controls.Add(this.ZoomInLEBL_button);
            this.Controls.Add(this.Set_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MLAT_checkBox);
            this.Controls.Add(this.ADSB_checkBox);
            this.Controls.Add(this.SMR_checkBox);
            this.Controls.Add(this.TimeScaleForward_button);
            this.Controls.Add(this.TimeScaleBackward_button);
            this.Controls.Add(this.TimeScaleIndicator_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExportKML_button);
            this.Controls.Add(this.TargetData_DGV);
            this.Controls.Add(this.Time_label);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.Play_button);
            this.Controls.Add(this.GMap_control);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "00:00:00.000";
            this.Load += new System.EventHandler(this.Map_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TargetData_DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleBackward_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeScaleForward_button)).EndInit();
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
        private Button ExportKML_button;
        private Label label3;
        private Label TimeScaleIndicator_label;
        private PictureBox TimeScaleBackward_button;
        private PictureBox TimeScaleForward_button;
        private CheckBox SMR_checkBox;
        private CheckBox ADSB_checkBox;
        private CheckBox MLAT_checkBox;
        private Label label1;
        private Button Set_button;
        private Button ZoomInLEBL_button;
        private ComboBox Hour_comboBox;
        private ComboBox Minuts_comboBox;
        private ComboBox Seconds_comboBox;
        private CheckBox SeeTraces_checkBox;
        private Label label2;
    }
}

