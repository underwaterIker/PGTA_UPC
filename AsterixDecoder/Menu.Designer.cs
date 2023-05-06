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
            this.LoadFile_button = new System.Windows.Forms.Button();
            this.ViewData_button = new System.Windows.Forms.Button();
            this.MapView_button = new System.Windows.Forms.Button();
            this.AboutUs_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadFile_button
            // 
            this.LoadFile_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.LoadFile_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFile_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFile_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoadFile_button.Location = new System.Drawing.Point(83, 47);
            this.LoadFile_button.Name = "LoadFile_button";
            this.LoadFile_button.Size = new System.Drawing.Size(135, 58);
            this.LoadFile_button.TabIndex = 1;
            this.LoadFile_button.Text = "LOAD FILE";
            this.LoadFile_button.UseVisualStyleBackColor = false;
            this.LoadFile_button.Click += new System.EventHandler(this.LoadFile_button_Click);
            // 
            // ViewData_button
            // 
            this.ViewData_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ViewData_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewData_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewData_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ViewData_button.Location = new System.Drawing.Point(83, 131);
            this.ViewData_button.Name = "ViewData_button";
            this.ViewData_button.Size = new System.Drawing.Size(135, 58);
            this.ViewData_button.TabIndex = 18;
            this.ViewData_button.Text = "VIEW DATA";
            this.ViewData_button.UseVisualStyleBackColor = false;
            this.ViewData_button.Click += new System.EventHandler(this.ViewData_button_Click);
            // 
            // MapView_button
            // 
            this.MapView_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.MapView_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MapView_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapView_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MapView_button.Location = new System.Drawing.Point(83, 219);
            this.MapView_button.Name = "MapView_button";
            this.MapView_button.Size = new System.Drawing.Size(135, 58);
            this.MapView_button.TabIndex = 20;
            this.MapView_button.Text = "MAP VIEW";
            this.MapView_button.UseVisualStyleBackColor = false;
            this.MapView_button.Click += new System.EventHandler(this.MapView_button_Click);
            // 
            // AboutUs_button
            // 
            this.AboutUs_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AboutUs_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutUs_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutUs_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AboutUs_button.Location = new System.Drawing.Point(83, 308);
            this.AboutUs_button.Name = "AboutUs_button";
            this.AboutUs_button.Size = new System.Drawing.Size(135, 58);
            this.AboutUs_button.TabIndex = 21;
            this.AboutUs_button.Text = "ABOUT US";
            this.AboutUs_button.UseVisualStyleBackColor = false;
            this.AboutUs_button.Click += new System.EventHandler(this.AboutUs_button_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Exit_button.Location = new System.Drawing.Point(83, 393);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(135, 58);
            this.Exit_button.TabIndex = 22;
            this.Exit_button.Text = "EXIT";
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 521);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.AboutUs_button);
            this.Controls.Add(this.MapView_button);
            this.Controls.Add(this.ViewData_button);
            this.Controls.Add(this.LoadFile_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadFile_button;
        private System.Windows.Forms.Button ViewData_button;
        private System.Windows.Forms.Button MapView_button;
        private System.Windows.Forms.Button AboutUs_button;
        private System.Windows.Forms.Button Exit_button;
    }
}