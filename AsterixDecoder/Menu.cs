using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace AsterixDecoder
{
    public partial class Menu : Form
    {
        // ATTRIBUTES
        // Decodification class
        Decodification myDecoder;

        // File Loaded indicator
        private bool fileLoaded_flag = false;


        // CONSTRUCTOR
        public Menu()
        {
            InitializeComponent();
        }


        // METHODS
        // Load Data
        private void LoadFile_button_Click(object sender, EventArgs e)
        {
            Loading_ButtonState(LoadFile_button);

            try
            {
                OpenFileDialog LoadFile = new OpenFileDialog();
                if (LoadFile.ShowDialog() == DialogResult.OK && Path.GetExtension(LoadFile.FileName) == ".ast")
                {
                    string fileName = LoadFile.FileName;

                    this.myDecoder = new Decodification(fileName);
                    
                    //MessageBox.Show("done");

                    this.fileLoaded_flag = true;
                }
                else
                {
                    MessageBox.Show("Select a valid file format.", "Incorrect file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            FinishedLoading_ButtonState(LoadFile_button, "LOAD FILE");
        }

        // ViewData
        private void ViewData_button_Click(object sender, EventArgs e)
        {
            Loading_ButtonState(ViewData_button);

            if (this.fileLoaded_flag == true)
            {
                Tables myTables = new Tables(this.myDecoder.messagesData_list, this.myDecoder.CAT10_flag, this.myDecoder.CAT21_flag);
                myTables.TopLevel = false;
                if (child_panel.Controls.Count>0)
                    child_panel.Controls.Clear();
                child_panel.Controls.Add(myTables);
                myTables.BringToFront();
                myTables.Show();


                //myTables.Show();
                //myTables.dataList_DGV.Rows[0].Cells[0].Selected = false;
            }
            else
            {
                MessageBox.Show("Load the File first.", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            FinishedLoading_ButtonState(ViewData_button, "VIEW DATA");
        }

        // MapView
        private void ViewMap_button_Click(object sender, EventArgs e)
        {
            Loading_ButtonState(ViewMap_button);

            Map myMap = new Map(this.myDecoder.targetData_list);
            myMap.Show();

            FinishedLoading_ButtonState(ViewMap_button, "VIEW MAP");
        }

        // AboutUs
        private void AboutUs_button_Click(object sender, EventArgs e)
        {
            AboutUs myAboutUs = new AboutUs();
            myAboutUs.Show();
        }

        // Exit
        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // ------------------------------------------------------
        // Loading Button State functions
        private void Loading_ButtonState(Button button)
        {
            button.Text = "Loading...";
            button.ForeColor = Color.DarkGreen;
            button.BackColor = Color.Silver;
            Application.DoEvents();
        }

        private void FinishedLoading_ButtonState(Button button, string str)
        {
            button.Text = str;
            button.ForeColor = Color.White;
            button.BackColor = Color.LightSkyBlue;
            button.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);
        }

        
    }
}
