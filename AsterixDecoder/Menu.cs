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
        // List containing all CAT messages in order
        private List<Data> messagesData_list;

        // CAT indicators
        private bool CAT10_flag;
        private bool CAT21_flag;

        // file loaded indicator
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
                    this.messagesData_list = decoder.messagesData_list;
                    this.CAT10_flag = decoder.CAT10_present;
                    this.CAT21_flag = decoder.CAT21_present;

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
                Tables myTables = new Tables(this.messagesData_list, this.CAT10_flag, this.CAT21_flag);
                myTables.Show();
                myTables.dataList_DGV.Rows[0].Cells[0].Selected = false;
            }
            else
            {
                MessageBox.Show("Load the File first.", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // MapView
        private void MapView_button_Click(object sender, EventArgs e)
        {

        }

        // AboutUs
        private void AboutUs_button_Click(object sender, EventArgs e)
        {
            AboutUs AboutUs = new AboutUs();
            AboutUs.Show();
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
