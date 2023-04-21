using System;
using System.Collections.Generic;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClassLibrary;

namespace AsterixDecoder
{
    public partial class Menu : Form
    {
        // List containing all CAT10 & CAT21 messages in order
        public List<Data> data_list = new List<Data>();

        bool fileload = false;
        bool filecompleted = false;

        double LAT = 41.29839;
        double LON = 2.08331;



        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        
        public void ResetFile(string FileName)
        {

        }

        

        private void LoadFile_Click(object sender, EventArgs e)
        {
            if (fileload == false)
            {
                OpenFileDialog LoadFile = new OpenFileDialog();
                if (LoadFile.ShowDialog() == DialogResult.OK)
                {
                    string FileName = LoadFile.FileName;
                    ReadFile readFile = new ReadFile(FileName);

                    this.data_list = readFile.data_list;

                    fileload = true;
                }

            }
            else if (fileload == true)
            {
                MessageBox.Show("The file has already been uploaded");
            }
        }

        private void AboutUs_Click(object sender, EventArgs e)
        {
            AboutUs AboutUs = new AboutUs();
            AboutUs.Show();
        }

        private void ViewData_Click(object sender, EventArgs e)
        {
            if (fileload==false)
            {
                MessageBox.Show("The file with the data has not been uploaded");
            }
            
            else
            {
                DataTable dataTable = new DataTable(this.data_list);
                dataTable.Show();
            
            }
           

        }

        // MAP
        private void MapView_Click(object sender, EventArgs e)
        {
            gMapControl1_Load(sender, e);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.Show();
            gMapControl1.MarkersEnabled = true;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            PointLatLng ubicacion = new PointLatLng(LAT, LON);
            gMapControl1.Position = ubicacion;
            gMapControl1.MinZoom = 8;
            gMapControl1.MaxZoom = 22;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;
        }
    }
}
