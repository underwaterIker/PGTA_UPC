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
using System.IO;
using System.Threading;
using System.Timers;
using MultiCAT6.Utils;

namespace AsterixDecoder
{
    public partial class Map : Form
    {
        // ATTRIBUTES
        // List containing TargetData of all targets
        private List<TargetData> targetData_list;
        
        // One Overlay for each type
        GMapOverlay SMR_overlay = new GMapOverlay("SMR");
        GMapOverlay MLAT_overlay = new GMapOverlay("MLAT");
        GMapOverlay ADSB_overlay = new GMapOverlay("ADSB");

        // Radar WGS84 Coordinates of SMR and MLAT
        CoordinatesWGS84 SMR_radar_WGS84Coordinates = new CoordinatesWGS84(Functions.Deg2Rad(41.29561833), Functions.Deg2Rad(2.09511417));
        CoordinatesWGS84 MLAT_radar_WGS84Coordinates = new CoordinatesWGS84(Functions.Deg2Rad(41.29706278), Functions.Deg2Rad(2.07844722));

        // Initial Position for the Map
        PointLatLng LEBL_position = new PointLatLng(41.29839, 2.08331);

        // Current time
        string currentTime = "08:00:00";

        // GeoUtils class
        GeoUtils myGeoUtils = new GeoUtils();


        // CONSTRUCTOR
        public Map(List<TargetData> targetData_list)
        {
            InitializeComponent();
            this.targetData_list = targetData_list;
        }


        // METHODS
        // Load GMap
        private void Map_Load(object sender, EventArgs e)
        {
            GMap_control.Show();
            GMap_control.MarkersEnabled = true;
            GMap_control.PolygonsEnabled = true;
            GMap_control.CanDragMap = false;
            GMap_control.MapProvider = GMapProviders.GoogleMap;
            
            GMap_control.Position = LEBL_position;
            GMap_control.MinZoom = 8;
            GMap_control.MaxZoom = 22;
            GMap_control.Zoom = 13;
            GMap_control.AutoScroll = true;
        }

        // Play button
        private void Play_button_Click(object sender, EventArgs e) //START 
        {
            //MessageBox.Show("");
            Stop_button.Show();
            Play_button.Hide();
            GMap_control.Overlays.Clear();

            //timer1.Enabled = true;
            //timer1.Interval = 1000;
            timer1.Start();
        }

        // Stop button
        private void Stop_button_Click(object sender, EventArgs e) //STOP
        {
            Stop_button.Hide();
            Play_button.Show();
            timer1.Stop();
            //timer1.Enabled = false;
        }

        // Export to .KML button
        private void ExportKML_button_Click(object sender, EventArgs e)
        {

        }

        // timer1.Tick: Method that is executed in every timer1.Interval
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(TimeSpan.Parse(this.currentTime).TotalSeconds + 1);
            this.currentTime = time.ToString(@"hh\:mm\:ss");
            Time_label.Text = this.currentTime;
            CheckTargets();
        }

        // Method that is executed when a marker from the GMap_control is clicked
        private void GMap_control_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //TargetsTable(item);
        }

        // -----------------------------------------------------------------------------------------------------------------------------

        private void CheckTargets()
        {
            for (int i = 0; i<this.targetData_list.Count; i++)
            {
                if ((double)TimeSpan.Parse(targetData_list[i].Time).TotalSeconds <= (double)TimeSpan.Parse(this.currentTime).TotalSeconds)
                {
                    AddMarkerToItsOverlay(i);
                }
                else
                {
                    break;
                }
                    
            }
            AddOverlays();
        }

        private void AddMarkerToItsOverlay(int index)
        {
            CoordinatesXYZ cartesian;
            CoordinatesXYZ geocentric = new CoordinatesXYZ();
            double latitude = 0;
            double longitude = 0;

            GMarkerGoogleType markerType = new GMarkerGoogleType();
            GMarkerGoogle marker;

            if (this.targetData_list[index].isSMR is true || this.targetData_list[index].isMLAT is true)
            {
                if (this.targetData_list[index].isSMR is true)
                {
                    markerType = GMarkerGoogleType.yellow_small;

                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.SMR_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerType);
                    this.SMR_overlay.Markers.Add(marker);
                }
                else if (this.targetData_list[index].isMLAT is true)
                {
                    markerType = GMarkerGoogleType.green_small;

                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.MLAT_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerType);
                    this.MLAT_overlay.Markers.Add(marker);
                }
            }
            else //if (this.targetData_list[index].isADSB is true)
            {
                markerType = GMarkerGoogleType.red_small;

                latitude = this.targetData_list[index].Position[0];
                longitude = this.targetData_list[index].Position[1];

                marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerType);
                this.ADSB_overlay.Markers.Add(marker);
            }

        }

        private void AddOverlays()
        {
            if (this.SMR_overlay.Markers.Any())
            {
                this.GMap_control.Overlays.Add(this.SMR_overlay);
                //MessageBox.Show("smr");
            }
            if (this.MLAT_overlay.Markers.Any())
            {
                this.GMap_control.Overlays.Add(this.MLAT_overlay);
                //MessageBox.Show("mlat");
            }
            if (this.ADSB_overlay.Markers.Any())
            {
                this.GMap_control.Overlays.Add(this.ADSB_overlay);
                //MessageBox.Show("adsb");
            }

            //this.GMap_control.Overlays.Add(this.SMR_overlay);
            //this.GMap_control.Overlays.Add(this.MLAT_overlay);
            //this.GMap_control.Overlays.Add(this.ADSB_overlay);
        }



        // TABLE CLICK TARGET
        /*
        private void TargetsTable(GMapMarker target)
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 5;


            //dataGridView1.Cell.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            int k = 0;
            int indice = 0;
            while (k < TargetsList.Count)
            {
                indice = TargetsList[k].ID.IndexOf(target.Overlay.Id);

                k = k + 1;
            }

            {

                if (TargetsList[indice].cat == 10)
                {
                    dataGridView1.Rows[0].Cells[0].Value = "ID";
                    dataGridView1.Rows[1].Cells[0].Value = "Flight Level";

                    dataGridView1.Rows[0].Cells[1].Value = TargetsList[indice].ID;
                    dataGridView1.Rows[1].Cells[1].Value = TargetsList[indice].FL;
                    //dataGridView1.Rows[2].Cells[1].Value = targetList[indice].ID;
                    //dataGridView1.Rows[3].Cells[1].Value = targetList[indice].FL


                }
                else if (TargetsList[indice].cat == 21)
                {
                    dataGridView1.Rows[0].Cells[0].Value = "ID";
                    dataGridView1.Rows[1].Cells[0].Value = "Flight Level";


                }
                else
                {
                    //MessageBox("Error");
                }

            }

        }
        */

        
        

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
