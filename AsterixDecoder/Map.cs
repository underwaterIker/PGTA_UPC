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

namespace AsterixDecoder
{
    public partial class Map : Form
    {
        // ATTRIBUTES
        // List containing all CAT messages in order
        private List<Data> messagesData_list;

        // Initial Coordinates for the Map
        double LAT = 41.29839;
        double LON = 2.08331;


        // CONSTRUCTOR
        public Map(List<Data> messagesData_list)
        {
            InitializeComponent();
            this.messagesData_list = messagesData_list;
        }


        // METHODS
        // MapView
        List<TargetData> TargetsList = new List<TargetData>();
        List<GMarkerGoogle> markersList = new List<GMarkerGoogle>();
        private void MapView_button_Click(object sender, EventArgs e)
        {
            gMapControl1_Load(sender, e);
        }

        bool CancelThread = false;
        bool FirstTime = true;
        Thread checkTargetThread;


        // -----------------------------------------------------------------------------------------------------------------------------

        private void setTimer(string initialtime)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            labelhora.Text = initialtime;
            if (FirstTime)
            {
                timer1.Tick += new System.EventHandler(this.Hora_Tick);
            }

        }
        private void Hora_Tick(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(TimeSpan.Parse(labelhora.Text).TotalSeconds + 1);
            string t = time.ToString(@"hh\:mm\:ss");
            labelhora.Text = t;
        }
        
        private void CheckTargets()
        {

            // Check when the target has to be plotted 

            for (int i = 0; i < this.messagesData_list.Count; i++)
            {
                bool searching = true;
                while (searching)
                {
                    if ((int)TimeSpan.Parse(labelhora.Text).TotalSeconds >= (int)TimeSpan.Parse(this.messagesData_list[i].targetData.Time).TotalSeconds)
                    {

                        //Thread plotTargetThread = new Thread(() => Targets(this.messagesData_list[i]));
                        //plotTargetThread.Start();
                        //searching = false;
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
                gMapControl1.Overlays.Clear();
                TargetsList.Clear();
                markersList.Clear();

            }
        }

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

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.Show();
            gMapControl1.MarkersEnabled = true;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.CanDragMap = false;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            PointLatLng ubicacion = new PointLatLng(LAT, LON);
            gMapControl1.Position = ubicacion;
            gMapControl1.MinZoom = 8;
            gMapControl1.MaxZoom = 22;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;

        }

        private void button2_Click(object sender, EventArgs e) //START 
        {
            MessageBox.Show("");
            button3.Show();
            button2.Hide();
            Thread.Sleep(1000);

            gMapControl1.Overlays.Clear();
            TargetsList.Clear();
            markersList.Clear();

            setTimer(messagesData_list[0].targetData.Time);
            FirstTime = false;
            CancelThread = false;

            checkTargetThread = new Thread(CheckTargets);
            checkTargetThread.SetApartmentState(System.Threading.ApartmentState.STA);
            checkTargetThread.Start();

        }
        bool StopMap;
        private void button3_Click(object sender, EventArgs e) //STOP
        {
            button3.Hide();
            button2.Show();
            timer1.Stop(); //parem el timer i es parara el thread
            StopMap = true;

        }
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
        private void gMapControl1_OnMarkerClick_1(GMapMarker item, MouseEventArgs e)
        {
            //TargetsTable(item);
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
