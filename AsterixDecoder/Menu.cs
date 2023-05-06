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

namespace AsterixDecoder
{
    public partial class Menu : Form
    {
        // ATTRIBUTES
        // My Forms
        Tables myTables;
        Map myMap;
        AboutUs myAboutUs = new AboutUs();

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

                    Decodification decoder = new Decodification(fileName);
                    this.myTables = new Tables(decoder.messagesData_list, decoder.CAT10_flag, decoder.CAT21_flag);
                    this.myMap = new Map(decoder.targetData_list);

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

            FinishedLoading_ButtonState(LoadFile_button, "Load File");
        }

        // ViewData
        private void ViewData_button_Click(object sender, EventArgs e)
        {
            if (this.fileLoaded_flag == true)
            {
                this.myTables.Show();
                this.myTables.dataList_DGV.Rows[0].Cells[0].Selected = false;
            }
            else
            {
                MessageBox.Show("Load the File first.", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // MapView
        private void MapView_button_Click(object sender, EventArgs e)
        {
            this.myMap.Show();
        }

        // AboutUs
        private void AboutUs_button_Click(object sender, EventArgs e)
        {
            this.myAboutUs.Show();
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
            button.ForeColor = Color.Red;
            button.BackColor = Color.Gray;
            Application.DoEvents();
        }

        private void FinishedLoading_ButtonState(Button button, string str)
        {
            button.Text = str;
            button.ForeColor = Color.Black;
            button.BackColor = Color.White;
        }

        
    }
}
