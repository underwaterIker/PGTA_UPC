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
        private GMapOverlay SMR_overlay = new GMapOverlay("SMR");
        private GMapOverlay MLAT_overlay = new GMapOverlay("MLAT");
        private GMapOverlay ADSB_overlay = new GMapOverlay("ADSB");

        // List containing the IDs of the targets ploted, necessary for the RemovePreviousMarker() method
        private List<string> SMR_markerTags = new List<string>();
        private List<string> MLAT_markerTags = new List<string>();
        private List<string> ADSB_markerTags = new List<string>();

        //
        private List<int> indexes = new List<int>();

        // Radar WGS84 Coordinates of SMR and MLAT
        private CoordinatesWGS84 SMR_radar_WGS84Coordinates = new CoordinatesWGS84(Functions.Deg2Rad(41.29561833), Functions.Deg2Rad(2.09511417));
        private CoordinatesWGS84 MLAT_radar_WGS84Coordinates = new CoordinatesWGS84(Functions.Deg2Rad(41.29706278), Functions.Deg2Rad(2.07844722));

        // Initial Position for the Map
        private PointLatLng LEBL_position = new PointLatLng(41.29839, 2.08331);

        // Current time
        private string currentTime = "08:00:00";

        // GeoUtils class
        private GeoUtils myGeoUtils = new GeoUtils();


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

        // Clear Selection button
        private void ClearSelection_button_Click(object sender, EventArgs e)
        {
            TargetData_DGV.Columns.Clear();
            TargetData_DGV.Rows.Clear();
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
            Set_TargetData_DGV(item);
        }

        // -----------------------------------------------------------------------------------------------------------------------------

        private void CheckTargets()
        {
            for (int index = 0; index<this.targetData_list.Count; index++)
            {
                if ((double)TimeSpan.Parse(targetData_list[index].Time).TotalSeconds <= (double)TimeSpan.Parse(this.currentTime).TotalSeconds)
                {
                    AddMarkerToItsOverlay(index);
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
                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.SMR_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    markerType = GMarkerGoogleType.yellow_small;
                    marker = CreateMarker(latitude, longitude, markerType, index);

                    RemovePreviousMarker_and_AddNewMarker(marker, this.SMR_markerTags, this.SMR_overlay);
                }
                else if (this.targetData_list[index].isMLAT is true)
                {
                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.MLAT_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    markerType = GMarkerGoogleType.green_small;
                    marker = CreateMarker(latitude, longitude, markerType, index);

                    RemovePreviousMarker_and_AddNewMarker(marker, this.MLAT_markerTags, this.MLAT_overlay);
                }
            }
            else //if (this.targetData_list[index].isADSB is true)
            {
                latitude = this.targetData_list[index].Position[0];
                longitude = this.targetData_list[index].Position[1];

                markerType = GMarkerGoogleType.red_small;
                marker = CreateMarker(latitude, longitude, markerType, index);

                RemovePreviousMarker_and_AddNewMarker(marker, this.ADSB_markerTags, this.ADSB_overlay);
            }

        }

        private GMarkerGoogle CreateMarker(double latitude, double longitude, GMarkerGoogleType markerType, int index)
        {
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerType);
            marker.ToolTipText = this.targetData_list[index].ID[0];
            marker.Tag = index;

            return marker;
        }

        private void RemovePreviousMarker_and_AddNewMarker(GMarkerGoogle marker, List<string> markerTags, GMapOverlay overlay)
        {
            int delete_index = markerTags.IndexOf(marker.ToolTipText);
            if (delete_index != -1)
            {
                markerTags.RemoveAt(delete_index);
                overlay.Markers.RemoveAt(delete_index);
            }

            markerTags.Add(marker.ToolTipText);
            overlay.Markers.Add(marker);
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

        private void Set_TargetData_DGV(GMapMarker target)
        {
            TargetData_DGV.Columns.Clear();
            TargetData_DGV.Rows.Clear();

            TargetData_DGV.RowHeadersVisible = false;
            TargetData_DGV.ColumnHeadersVisible = false;

            // Set the number of rows and columns
            TargetData_DGV.RowCount = 8;
            TargetData_DGV.ColumnCount = 2;

            TargetData_DGV.Rows[0].Cells[0].Selected = false;
            TargetData_DGV.Columns[0].Width = 160;
            TargetData_DGV.Columns[1].Width = 160;

            // Column[0] bold
            TargetData_DGV.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            TargetData_DGV.Rows[0].Cells[0].Value = "Time";
            TargetData_DGV.Rows[1].Cells[0].Value = "Pos. Latitude";
            TargetData_DGV.Rows[2].Cells[0].Value = "Pos. Longitude";
            TargetData_DGV.Rows[3].Cells[0].Value = "Track Number";
            TargetData_DGV.Rows[4].Cells[0].Value = "Target Address";
            TargetData_DGV.Rows[5].Cells[0].Value = "Target Identification";
            TargetData_DGV.Rows[6].Cells[0].Value = "Mode 3A Code";
            TargetData_DGV.Rows[7].Cells[0].Value = "Flight Level";

            int index = (int)target.Tag;

            TargetData_DGV.Rows[0].Cells[1].Value = this.targetData_list[index].Time;
            TargetData_DGV.Rows[1].Cells[1].Value = target.Position.Lat;
            TargetData_DGV.Rows[2].Cells[1].Value = target.Position.Lng;

            string[] IDs = this.targetData_list[index].ID;
            for (int i = 0; i < IDs.Length; i++)
            {
                if (IDs[i] != null)
                    TargetData_DGV.Rows[i + 3].Cells[1].Value = IDs[i];
                else
                    TargetData_DGV.Rows[i + 3].Cells[1].Value = "--";

            }

            string mode3a = this.targetData_list[index].Mode3ACode;
            if (mode3a != null )
                TargetData_DGV.Rows[6].Cells[1].Value = mode3a;
            else
                TargetData_DGV.Rows[6].Cells[1].Value = "--";


            double FL = this.targetData_list[index].FlightLevel;
            if (FL != 0)  
                TargetData_DGV.Rows[7].Cells[1].Value = FL;
            else
                TargetData_DGV.Rows[7].Cells[1].Value = "--";
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
