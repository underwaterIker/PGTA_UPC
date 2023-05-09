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
            this.ViewMap_button = new System.Windows.Forms.Button();
            this.AboutUs_button = new System.Windows.Forms.Button();
            this.Exit_button = new System.Windows.Forms.Button();
            this.child_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LoadFile_button
            // 
            this.LoadFile_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.LoadFile_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFile_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFile_button.ForeColor = System.Drawing.Color.White;
            this.LoadFile_button.Location = new System.Drawing.Point(18, 53);
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
            this.ViewData_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewData_button.ForeColor = System.Drawing.Color.White;
            this.ViewData_button.Location = new System.Drawing.Point(18, 137);
            this.ViewData_button.Name = "ViewData_button";
            this.ViewData_button.Size = new System.Drawing.Size(135, 58);
            this.ViewData_button.TabIndex = 18;
            this.ViewData_button.Text = "VIEW DATA";
            this.ViewData_button.UseVisualStyleBackColor = false;
            this.ViewData_button.Click += new System.EventHandler(this.ViewData_button_Click);
            // 
            // ViewMap_button
            // 
            this.ViewMap_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ViewMap_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewMap_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewMap_button.ForeColor = System.Drawing.Color.White;
            this.ViewMap_button.Location = new System.Drawing.Point(18, 225);
            this.ViewMap_button.Name = "ViewMap_button";
            this.ViewMap_button.Size = new System.Drawing.Size(135, 58);
            this.ViewMap_button.TabIndex = 20;
            this.ViewMap_button.Text = "VIEW MAP";
            this.ViewMap_button.UseVisualStyleBackColor = false;
            this.ViewMap_button.Click += new System.EventHandler(this.ViewMap_button_Click);
            // 
            // AboutUs_button
            // 
            this.AboutUs_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.AboutUs_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutUs_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutUs_button.ForeColor = System.Drawing.Color.White;
            this.AboutUs_button.Location = new System.Drawing.Point(18, 314);
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
            this.Exit_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_button.ForeColor = System.Drawing.Color.White;
            this.Exit_button.Location = new System.Drawing.Point(18, 399);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(135, 58);
            this.Exit_button.TabIndex = 22;
            this.Exit_button.Text = "EXIT";
            this.Exit_button.UseVisualStyleBackColor = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // child_panel
            // 
            this.child_panel.Location = new System.Drawing.Point(172, 11);
            this.child_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.child_panel.Name = "child_panel";
            this.child_panel.Size = new System.Drawing.Size(828, 521);
            this.child_panel.TabIndex = 23;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 552);
            this.Controls.Add(this.child_panel);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.AboutUs_button);
            this.Controls.Add(this.ViewMap_button);
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
        private System.Windows.Forms.Button ViewMap_button;
        private System.Windows.Forms.Button AboutUs_button;
        private System.Windows.Forms.Button Exit_button;
        private System.Windows.Forms.Panel child_panel;
    }
}