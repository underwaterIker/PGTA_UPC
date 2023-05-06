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

        // List containing the GoogleMarkers
        List<GMarkerGoogle> GMarker_list = new List<GMarkerGoogle>();

        // Initial Coordinates for the Map
        private readonly double LEBL_latitude = 41.29839;
        private readonly double LEBL_longitude = 2.08331;

        // Current time
        string currentTime = "08:00:00";

        // Cosas que tenía Paula, mirar si son necesarias o no
        bool CancelThread = false;
        Thread checkTargetThread;


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
            PointLatLng ubicacion = new PointLatLng(LEBL_latitude, LEBL_longitude);
            GMap_control.Position = ubicacion;
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
            //TargetsList.Clear();
            GMarker_list.Clear();

            //timer1.Enabled = true;
            //timer1.Interval = 1000;
            timer1.Start();
            CancelThread = false;

            //checkTargetThread = new Thread(CheckTargets);
            //checkTargetThread.SetApartmentState(System.Threading.ApartmentState.STA);
            //checkTargetThread.Start();
        }

        // Stop button
        private void Stop_button_Click(object sender, EventArgs e) //STOP
        {
            Stop_button.Hide();
            Play_button.Show();
            timer1.Stop();
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
        }

        // Method that is executed when a marker from the GMap_control is clicked
        private void GMap_control_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //TargetsTable(item);
        }

        // -----------------------------------------------------------------------------------------------------------------------------


        /*
        private void CheckTargets()
        {

            // Check when the target has to be plotted 

            for (int i = 0; i < this.targetData_list.Count; i++)
            {
                bool searching = true;
                while (searching)
                {
                    if ((double)TimeSpan.Parse(Time_label.Text).TotalSeconds >= (double)TimeSpan.Parse(this.targetData_list[i].Time).TotalSeconds)
                    {

                        //Thread plotTargetThread = new Thread(() => Targets(data_list[i]));
                        //plotTargetThread.Start();
                        //searching = false;

                        GeoUtils g = new GeoUtils();
                        CoordinatesWGS84 radarWGS84 = new CoordinatesWGS84(Functions.Deg2Rad(latitudRadar), Functions.Deg2Rad(longitudRadar));
                        CoordinatesXYZ cartesian = new CoordinatesXYZ(data.PositionCartesianCoordinates_x, data.PositionCartesianCoordinates_y, h);
                        //Cartesianas radar -> Geocéntricas Radar -> Geodésicas
                        CoordinatesXYZ geocentric = g.change_radar_cartesian2geocentric(radarWGS84, cartesian);
                        CoordinatesWGS84 geodesic = g.change_geocentric2geodesic(geocentric);
                        latitud = Functions.Rad2Deg(geodesic.Lat);
                        longitud = Functions.Rad2Deg(geodesic.Lon);
                        h = geodesic.Height;
                        //Cartesianas radar –> Geocéntricas Radar -> Cartesianas ->Estereográficas ???
                    }

                    if (CancelThread)
                    {
                        break;
                    }
                }
            }
            timer1.Stop();

            if (CancelThread == false)
            {
                MessageBox.Show("End of the simulation");
            }
            else
            {
                GMap_control.Overlays.Clear();
                //TargetsList.Clear();
                GMarker_list.Clear();

            }
        }
        */

        /*
        private void Targets(Data data)
        {
            double groundspeed = 0;
            double FL = 0;
            double TrackNumber = 0;
            double longitud = 0;
            double latitud = 0;
            int cat = 0;

            double h = 0;

            if (data.MeasuredHeight != 0)
            {
                h = data.MeasuredHeight;
            }

            if (data.CalculatedTrackVelocityPolarCoordinates_GroundSpeed != 0)
            {
                groundspeed = data.CalculatedTrackVelocityPolarCoordinates_GroundSpeed;
            }

            if (data.FlightLevel_FL != 0)
            {
                FL = data.FlightLevel_FL;
            }
            if (data.TrackNumber != 0)
            {
                TrackNumber = data.TrackNumber;
            }


            // CAT10: SMR ofrece la posición de los blancos en dos sistemes de coordenadas: polares y cartesianas respecto el radar SMR
            // CAT10: MLAT solo da las posiciones de los blancos en cartesianas respecto al ARP del Aeropuerto de LEBL

            if ((data.PositionCartesianCoordinates_x != 0 && data.PositionCartesianCoordinates_y != 0 && data.MessageType != null))
            {
                if (data.MessageType == "Target Report")
                {
                    double latitudRadar;
                    double longitudRadar;
                    cat = 10;
                    if (data.TargetAddress != null)
                    {
                        //Radar SMR
                        latitudRadar = 41.297;
                        longitudRadar = 2.07845;
                    }
                    else
                    {
                        //ARP
                        latitudRadar = 41.2956;
                        longitudRadar = 2.095;
                    }

                    GeoUtils g = new GeoUtils();
                    CoordinatesWGS84 radarWGS84 = new CoordinatesWGS84(Functions.DegToRad(latitudRadar), Functions.DegToRad(longitudRadar));
                    CoordinatesXYZ cartesian = new CoordinatesXYZ(data.PositionCartesianCoordinates_x, data.PositionCartesianCoordinates_y, h);
                    //Cartesianas radar -> Geocéntricas Radar -> Geodésicas
                    CoordinatesXYZ geocentric = g.change_radar_cartesian2geocentric(radarWGS84, cartesian);
                    CoordinatesWGS84 geodesic = g.change_geocentric2geodesic(geocentric);
                    latitud = Functions.RadToDeg(geodesic.Lat);
                    longitud = Functions.RadToDeg(geodesic.Lon);
                    h = geodesic.Height;
                    //Cartesianas radar –> Geocéntricas Radar -> Cartesianas ->Estereográficas ???
                }

            }
            //CAT21:ADSB da la posición de sus blancos en geodésicas WGS84
            else if (data.PositionWGS84Coordinates_Latitude != 0 && data.PositionWGS84Coordinates_Longitude != 0)
            {
                cat = 21;


                latitud = data.PositionWGS84Coordinates_Latitude;
                longitud = data.PositionWGS84Coordinates_Longitude;
            }

            string ID = null;
            if (cat == 10 || cat == 21)
            {
                if (data.TargetIdentification_Characters != null)
                {

                    ID = data.TargetIdentification_Characters.ToString();
                }

                else if (data.TrackNumber != 0)
                {
                    ID = data.TrackNumber.ToString();
                }

                if (longitud != 0 && latitud != 0 && ID != null && groundspeed != 0)
                {
                    int index = TargetsList.FindIndex(a => a.ID == ID);
                    TargetData exists = TargetsList.Find(a => a.ID == ID);
                    if (exists != null) //itexists? UPDATE
                    {
                        TargetsList[index].Lat = latitud;
                        TargetsList[index].Long = longitud;
                        TargetsList[index].FL = FL;
                        TargetsList[index].height = h;
                        TargetsList[index].groundSpeed = groundspeed;
                        //targetList[index].TimeOftheDay= data.TimeOfDay;
                        markersList[index].Position = new PointLatLng(latitud, longitud);
                        //GMapOverlay targets = new GMapOverlay(ID);
                        //GMarkerGoogle markerTarget = new GMarkerGoogle(new PointLatLng(latitud, longitud), targetList[index].Bitmap);
                        //targets.Markers.Add(markerTarget);
                        //gMapControl1.Overlays.Add(targets);
                    }
                    else
                    {
                        TargetData a = new TargetData(ID, longitud, latitud, h, "", groundspeed, FL, TrackNumber, cat);
                        GMapOverlay targets = new GMapOverlay(ID);
                        GMarkerGoogle markerTarget = new GMarkerGoogle(new PointLatLng(latitud, longitud), a.Bitmap);
                        TargetsList.Add(a);
                        markersList.Add(markerTarget);
                        targets.Markers.Add(markerTarget);
                        gMapControl1.Overlays.Add(targets);

                    }
                }

            }
        }
        */


        


        
        //TIME SCALE



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
