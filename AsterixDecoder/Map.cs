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
using MultiCAT6.Utils;
using System.Reflection;
using System.Xml.Serialization;

namespace AsterixDecoder
{
    public partial class Map : Form
    {
        // ATTRIBUTES
        // List containing TargetData of all targets
        private List<TargetData> targetData_list;
        private int list_index = 0;

        // Refresh period (in seconds)
        private int refreshPeriod = 1;

        // Initial Position for the Map
        private readonly PointLatLng LEBL_position = new PointLatLng(41.29839, 2.08331);

        // Current time
        private string currentTime = "08:00:00";

        // GeoUtils class
        private GeoUtils myGeoUtils = new GeoUtils();

        // Timer started indicator
        private bool timerstarted = false;

        // One Overlay for each type
        private GMapOverlay SMR_overlay = new GMapOverlay("SMR");
        private GMapOverlay MLAT_overlay = new GMapOverlay("MLAT");
        private GMapOverlay ADSB_overlay = new GMapOverlay("ADSB");

        // One Overlay for each type, for the traces
        private GMapOverlay SMR_traces_overlay = new GMapOverlay("SMR_traces");
        private GMapOverlay MLAT_traces_overlay = new GMapOverlay("MLAT_traces");
        private GMapOverlay ADSB_traces_overlay = new GMapOverlay("ADSB_traces");

        // Lists containing the route of each target for the last 50 detections
        private List<GMapRoute> SMR_traces_routes = new List<GMapRoute>();
        private List<GMapRoute> MLAT_traces_routes = new List<GMapRoute>();
        private List<GMapRoute> ADSB_traces_routes = new List<GMapRoute>();

        // Lists containing the COMPLETE route of each target (useful for exporting to .kml)
        private List<GMapRoute> SMR_complete_routes = new List<GMapRoute>();
        private List<GMapRoute> MLAT_complete_routes = new List<GMapRoute>();
        private List<GMapRoute> ADSB_complete_routes = new List<GMapRoute>();

        // Radar WGS84 Coordinates of SMR and MLAT
        private readonly CoordinatesWGS84 SMR_radar_WGS84Coordinates = new CoordinatesWGS84(Functions.Deg2Rad(41.29561833), Functions.Deg2Rad(2.09511417));
        private readonly CoordinatesWGS84 MLAT_radar_WGS84Coordinates = new CoordinatesWGS84(Functions.Deg2Rad(41.29706278), Functions.Deg2Rad(2.07844722));

        
        // CONSTRUCTOR
        public Map(List<TargetData> targetData_list)
        {
            InitializeComponent();
            this.targetData_list = targetData_list;
        }


        // METHODS

        // ------------------------------------------------------------
        // Load Map form
        private void Map_Load(object sender, EventArgs e)
        {
            GMap_control.Show();
            GMap_control.MarkersEnabled = true;
            GMap_control.PolygonsEnabled = true;
            GMap_control.DragButton = MouseButtons.Left;
            GMap_control.CanDragMap = true;
            GMap_control.MapProvider = GMapProviders.GoogleMap;
            
            GMap_control.Position = LEBL_position;
            GMap_control.MinZoom = 8;
            GMap_control.MaxZoom = 22;
            GMap_control.Zoom = 13;
            GMap_control.AutoScroll = true;

            // We add the overlays to the GMap
            GMap_control.Overlays.Add(this.SMR_overlay);
            GMap_control.Overlays.Add(this.MLAT_overlay);
            GMap_control.Overlays.Add(this.ADSB_overlay);

            // We add the overlays of the traces to the GMap
            GMap_control.Overlays.Add(this.SMR_traces_overlay);
            GMap_control.Overlays.Add(this.MLAT_traces_overlay);
            GMap_control.Overlays.Add(this.ADSB_traces_overlay);
            this.SMR_traces_overlay.IsVisibile = false;
            this.MLAT_traces_overlay.IsVisibile = false;
            this.ADSB_traces_overlay.IsVisibile = false;

            // We check all the SMR, MLAT and ADSB checkboxes
            SMR_checkBox.Checked = true;
            ADSB_checkBox.Checked = true;
            MLAT_checkBox.Checked = true;

            // We set the Hour label
            Time_label.Text = this.currentTime;

            // We set the timer interval
            timer1.Interval = 1000;
        }
        // Load Map form
        // ------------------------------------------------------------

        // ------------------------------------------------------------
        // Play & Stop buttons + timer1 methods
        private void Play_button_Click(object sender, EventArgs e) //START 
        {
            Stop_button.Show();
            Play_button.Hide();

            timerstarted = true;
            timer1.Start();
        }

        // Stop button
        private void Stop_button_Click(object sender, EventArgs e) //STOP
        {
            Stop_button.Hide();
            Play_button.Show();

            timerstarted = false;
            timer1.Stop();
        }

        // timer1.Tick: Method that is executed in every timer1.Interval
        private void timer1_Tick(object sender, EventArgs e)
        {
            System.TimeSpan time = System.TimeSpan.FromSeconds(System.TimeSpan.Parse(this.currentTime).TotalSeconds + this.refreshPeriod);
            this.currentTime = time.ToString(@"hh\:mm\:ss");
            Time_label.Text = this.currentTime;
            CheckTargets();
        }

        private void CheckTargets()
        {
            ClearCurrentLists();
            ClearTracesLists();

            for (; this.list_index < this.targetData_list.Count; this.list_index++)
            {
                if ((double)System.TimeSpan.Parse(targetData_list[this.list_index].Time).TotalSeconds <= (double)System.TimeSpan.Parse(this.currentTime).TotalSeconds)
                {
                    AddMarkerToItsOverlay(this.list_index);
                }
                else
                {
                    break;
                }
            }

            // Add routes of the current targets to the corresponding traces_overlay
            for (int i = 0; i < this.SMR_overlay.Markers.Count; i++)
            {
                int routesList_index = this.SMR_traces_routes.FindIndex(x => x.Name == this.SMR_overlay.Markers[i].ToolTipText);
                this.SMR_traces_overlay.Routes.Add(this.SMR_traces_routes[routesList_index]);
                //this.GMap_control.UpdateRouteLocalPosition(this.SMR_traces_routes[routesList_index]);
            }

            for (int i = 0; i < this.MLAT_overlay.Markers.Count; i++)
            {
                int routesList_index = this.MLAT_traces_routes.FindIndex(x => x.Name == this.MLAT_overlay.Markers[i].ToolTipText);
                this.MLAT_traces_overlay.Routes.Add(this.MLAT_traces_routes[routesList_index]);
                //this.GMap_control.UpdateRouteLocalPosition(this.MLAT_traces_routes[routesList_index]);
            }
            for (int i = 0; i < this.ADSB_overlay.Markers.Count; i++)
            {
                int routesList_index = this.ADSB_traces_routes.FindIndex(x => x.Name == this.ADSB_overlay.Markers[i].ToolTipText);
                this.ADSB_traces_overlay.Routes.Add(this.ADSB_traces_routes[routesList_index]);
                //this.GMap_control.UpdateRouteLocalPosition(this.ADSB_traces_routes[routesList_index]);
            }

            // Check if we have reached the end of the simulation
            if (this.list_index == this.targetData_list.Count)
            {
                Stop_button.Hide();
                Play_button.Show();

                timerstarted = false;
                timer1.Stop();

                MessageBox.Show("End of the file has been reached!", "End", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                    Pen trace_pen = new Pen(Color.Goldenrod, 3);
                    markerType = GMarkerGoogleType.yellow_small;
                    marker = CreateMarker(latitude, longitude, markerType, index);

                    RemovePreviousMarker_and_AddNewMarker(marker, this.SMR_overlay, this.SMR_traces_routes, this.SMR_complete_routes, trace_pen);
                }
                else if (this.targetData_list[index].isMLAT is true)
                {
                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.MLAT_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    Pen trace_pen = new Pen(Color.OliveDrab, 3);
                    markerType = GMarkerGoogleType.green_small;
                    marker = CreateMarker(latitude, longitude, markerType, index);

                    RemovePreviousMarker_and_AddNewMarker(marker, this.MLAT_overlay, this.MLAT_traces_routes, this.MLAT_complete_routes, trace_pen);
                }
            }
            else //if (this.targetData_list[index].isADSB is true)
            {
                latitude = this.targetData_list[index].Position[0];
                longitude = this.targetData_list[index].Position[1];

                Pen trace_pen = new Pen(Color.IndianRed, 3);
                //trace_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                markerType = GMarkerGoogleType.red_small;
                marker = CreateMarker(latitude, longitude, markerType, index);

                RemovePreviousMarker_and_AddNewMarker(marker, this.ADSB_overlay, this.ADSB_traces_routes, this.ADSB_complete_routes, trace_pen);
            }

        }

        private GMarkerGoogle CreateMarker(double latitude, double longitude, GMarkerGoogleType markerType, int index)
        {
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerType);
            marker.ToolTipText = this.targetData_list[index].ID[0];
            marker.Tag = index;

            return marker;
        }

        private void RemovePreviousMarker_and_AddNewMarker(GMarkerGoogle marker, GMapOverlay overlay, List<GMapRoute> partialRoutes_list, List<GMapRoute> completeRoutes_list, Pen pen)
        {

            int routesList_index = partialRoutes_list.FindIndex(x => x.Name == marker.ToolTipText);


            if (routesList_index != -1)
            {
                GMapRoute myRoute = partialRoutes_list[routesList_index];
                if (myRoute.Points.Count == 50) // Defines number of detections for the traces
                {
                    myRoute.Points.RemoveAt(0);
                }

                myRoute.Points.Add(marker.Position);
                partialRoutes_list[routesList_index] = myRoute;
            }
            else
            {
                GMapRoute route = new GMapRoute(marker.ToolTipText);
                route.Stroke = pen;
                route.Points.Add(marker.Position);

                partialRoutes_list.Add(route);
            }

            // Add the marker to the overlay (or replace the old marker for the most recent one in case of duplicates)
            int overlay_index = overlay.Markers.ToList().FindIndex(x => x.ToolTipText == marker.ToolTipText);
            if (overlay_index != -1)
            {
                // Replace marker for the most recent one
                overlay.Markers[overlay_index] = marker;
            }
            else
            {
                // Add marker
                overlay.Markers.Add(marker);
            }            
        }
        // Play & Stop buttons + timer1 methods
        // ------------------------------------------------------------

        // ------------------------------------------------------------
        // Export to .KML
        private void ExportKML_button_Click(object sender, EventArgs e)
        {
            Loading_ButtonState(ExportKML_button);

            try
            {
                ExportKML();
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            FinishedLoading_ButtonState(ExportKML_button, "EXPORT TO .KML");
        }

        private void ExportKML()
        {
            FulfillCompleteRoutesLists();

            StringBuilder KML_file = new StringBuilder();
            SaveFileDialog saveFile = new SaveFileDialog() { Filter = "KML|*.kml", FileName = "routes" };

            KML_file.AppendLine("<?xml version='1.0' encoding='UTF-8'?>");
            KML_file.AppendLine("<kml xmlns='http://www.opengis.net/kml/2.2'>");
            KML_file.AppendLine("<Document>");

            foreach (GMapRoute route in this.SMR_complete_routes)
            {
                KML_file.AppendLine("<Placemark>");
                KML_file.AppendLine("<Style>");
                KML_file.AppendLine("<LineStyle>");
                KML_file.AppendLine("<color>ff00ffff</color>"); // yellow
                KML_file.AppendLine("<width>3</width>");
                KML_file.AppendLine("</LineStyle>");
                //KML_file.AppendLine("<PolyStyle>");
                //KML_file.AppendLine("<color>DAA520</color>");
                //KML_file.AppendLine("</PolyStyle>");
                KML_file.AppendLine("</Style>");
                KML_file.AppendLine("<name>" + "SMR" + "</name>");
                KML_file.AppendLine("<description>" + "something" + "</description>");
                KML_file.AppendLine("<LineString>");
                //KML_file.AppendLine("<extrude>1</extrude>");
                //KML_file.AppendLine("<tessellate>1</tessellate>");
                KML_file.AppendLine("<coordinates>");

                foreach (PointLatLng point in route.Points)
                {
                    KML_file.AppendLine(Convert.ToString(point.Lng).Replace(",", ".") + "," + Convert.ToString(point.Lat).Replace(",", "."));
                }

                KML_file.AppendLine("</coordinates>");
                KML_file.AppendLine("</LineString>");
                KML_file.AppendLine("</Placemark>");
            }

            foreach (GMapRoute route in this.MLAT_complete_routes)
            {
                KML_file.AppendLine("<Placemark>");
                KML_file.AppendLine("<Style>");
                KML_file.AppendLine("<LineStyle>");
                KML_file.AppendLine("<color>ff00ff00</color>"); // green
                KML_file.AppendLine("<width>3</width>");
                KML_file.AppendLine("</LineStyle>");
                KML_file.AppendLine("</Style>");
                KML_file.AppendLine("<name>" + "MLAT" + "</name>");
                KML_file.AppendLine("<description>" + "something" + "</description>");
                KML_file.AppendLine("<LineString>");
                KML_file.AppendLine("<coordinates>");

                foreach (PointLatLng point in route.Points)
                {
                    KML_file.AppendLine(Convert.ToString(point.Lng).Replace(",", ".") + "," + Convert.ToString(point.Lat).Replace(",", "."));
                }

                KML_file.AppendLine("</coordinates>");
                KML_file.AppendLine("</LineString>");
                KML_file.AppendLine("</Placemark>");
            }

            foreach (GMapRoute route in this.ADSB_complete_routes)
            {
                KML_file.AppendLine("<Placemark>");
                KML_file.AppendLine("<Style>");
                KML_file.AppendLine("<LineStyle>");
                KML_file.AppendLine("<color>ff0000ff</color>"); // red
                KML_file.AppendLine("<width>3</width>");
                KML_file.AppendLine("</LineStyle>");
                KML_file.AppendLine("</Style>");
                KML_file.AppendLine("<name>" + "ADSB" + "</name>");
                KML_file.AppendLine("<description>" + "something" + "</description>");
                KML_file.AppendLine("<LineString>");
                KML_file.AppendLine("<coordinates>");

                foreach (PointLatLng point in route.Points)
                {
                    KML_file.AppendLine(Convert.ToString(point.Lng).Replace(",", ".") + "," + Convert.ToString(point.Lat).Replace(",", "."));
                }

                KML_file.AppendLine("</coordinates>");
                KML_file.AppendLine("</LineString>");
                KML_file.AppendLine("</Placemark>");
            }

            KML_file.AppendLine("</Document>");
            KML_file.AppendLine("</kml>");

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, KML_file.ToString());
            }
            else
            {
                MessageBox.Show("Error when saving .kml file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void FulfillCompleteRoutesLists()
        {
            for (int index = 0; index < this.targetData_list.Count; index++)
            {
                PointLatLng point;
                Pen pen;
                List<GMapRoute> completeRoutes_list;

                CoordinatesXYZ cartesian;
                CoordinatesXYZ geocentric = new CoordinatesXYZ();
                double latitude = 0;
                double longitude = 0;

                if (this.targetData_list[index].isSMR is true)
                {
                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.SMR_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    pen = new Pen(Color.Goldenrod, 3);
                    completeRoutes_list = this.SMR_complete_routes;
                }
                else if (this.targetData_list[index].isMLAT is true)
                {
                    cartesian = new CoordinatesXYZ(this.targetData_list[index].Position[0], this.targetData_list[index].Position[1], this.targetData_list[index].Position[2]);
                    geocentric = this.myGeoUtils.change_radar_cartesian2geocentric(this.MLAT_radar_WGS84Coordinates, cartesian);
                    CoordinatesWGS84 geodesic = this.myGeoUtils.change_geocentric2geodesic(geocentric);
                    latitude = Functions.Rad2Deg(geodesic.Lat);
                    longitude = Functions.Rad2Deg(geodesic.Lon);
                    //double h = geodesic.Height;

                    pen = new Pen(Color.OliveDrab, 3);
                    completeRoutes_list = this.MLAT_complete_routes;
                }
                else //if (this.targetData_list[index].isADSB is true)
                {
                    latitude = this.targetData_list[index].Position[0];
                    longitude = this.targetData_list[index].Position[1];

                    pen = new Pen(Color.IndianRed, 3);
                    completeRoutes_list = this.ADSB_complete_routes;
                }

                point = new PointLatLng(latitude, longitude);
                AddPointToCompleteRoute(index, point, pen, completeRoutes_list);
            }
        }

        private void AddPointToCompleteRoute(int index, PointLatLng point, Pen pen, List<GMapRoute> completeRoutes_list)
        {
            int routesList_index = completeRoutes_list.FindIndex(x => x.Name == this.targetData_list[index].ID[0]);

            if (routesList_index != -1)
            {
                GMapRoute myRoute = completeRoutes_list[routesList_index];
                myRoute.Points.Add(point);
                completeRoutes_list[routesList_index] = myRoute;
            }
            else
            {
                GMapRoute newRoute = new GMapRoute(this.targetData_list[index].ID[0]);
                newRoute.Stroke = pen;
                newRoute.Points.Add(point);

                completeRoutes_list.Add(newRoute);
            }
        }
        // Export to .KML
        // ------------------------------------------------------------

        // ------------------------------------------------------------
        // Show Target Data in a table when a marker is clicked
        private void GMap_control_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            try
            {
                Set_TargetData_DGV(item);
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Set_TargetData_DGV(GMapMarker target)
        {
            label2.Hide();

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
            // Column[1] not bold
            TargetData_DGV.Columns[1].DefaultCellStyle.Font = new Font("Tahoma", 11);

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
            if (mode3a != null)
                TargetData_DGV.Rows[6].Cells[1].Value = mode3a;
            else
                TargetData_DGV.Rows[6].Cells[1].Value = "--";


            double? FL = this.targetData_list[index].FlightLevel;
            if (FL != null)
                TargetData_DGV.Rows[7].Cells[1].Value = FL;
            else
                TargetData_DGV.Rows[7].Cells[1].Value = "--";
        }
        // Show Target Data in a table when a marker is clicked
        // ------------------------------------------------------------


        // ------------------------------------------------------------------------------------
        // Time Scale buttons
        private void TimeScaleForward_button_Click(object sender, EventArgs e)
        {
            if (TimeScaleIndicator_label.Text == "x1")
            {
                TimeScaleIndicator_label.Text = "x1.25";
                timer1.Interval = Convert.ToInt32(1000/1.25);
            }
            else if (TimeScaleIndicator_label.Text == "x0.25")
            {
                TimeScaleIndicator_label.Text = "x0.5";
                timer1.Interval = Convert.ToInt32(1000/0.5);
            }
            else if (TimeScaleIndicator_label.Text == "x0.5")
            {
                TimeScaleIndicator_label.Text = "x0.75";
                timer1.Interval = Convert.ToInt32(1000/0.75);
            }
            else if (TimeScaleIndicator_label.Text == "x0.75")
            {
                TimeScaleIndicator_label.Text = "x1";
                timer1.Interval = 1000;
            }
            else if (TimeScaleIndicator_label.Text == "x1.25")
            {
                TimeScaleIndicator_label.Text = "x1.5";
                timer1.Interval = Convert.ToInt32(1000 / 1.5);
            }
            else if (TimeScaleIndicator_label.Text == "x1.5")
            {
                TimeScaleIndicator_label.Text = "x1.75";
                timer1.Interval = Convert.ToInt32(1000 / 1.75);
            }
            else if (TimeScaleIndicator_label.Text == "x1.75")
            {
                TimeScaleIndicator_label.Text = "x2";
                timer1.Interval = Convert.ToInt32(1000 / 2);
            }
            else if (TimeScaleIndicator_label.Text == "x2")
            {
                TimeScaleIndicator_label.Text = "x5";
                timer1.Interval = Convert.ToInt32(1000 / 5);
            }
            else if (TimeScaleIndicator_label.Text == "x5")
            {
                TimeScaleIndicator_label.Text = "x10";
                timer1.Interval = Convert.ToInt32(1000 / 10);
            }
            else
            {
                MessageBox.Show("You can not move forward");
            }
        }

        private void TimeScaleBackward_button_Click(object sender, EventArgs e)
        {

            if (TimeScaleIndicator_label.Text == "x1")
            {
                TimeScaleIndicator_label.Text = "x0.75";
                timer1.Interval = Convert.ToInt32(1000 / 0.75);
            }
            else if (TimeScaleIndicator_label.Text == "x0.75")
            {
                TimeScaleIndicator_label.Text = "x0.5";
                timer1.Interval = Convert.ToInt32(1000 / 0.5);
            }
            else if (TimeScaleIndicator_label.Text == "x0.5")
            {
                TimeScaleIndicator_label.Text = "x0.25";
                timer1.Interval = Convert.ToInt32(1000 / 0.25);
            }
            else if (TimeScaleIndicator_label.Text == "x1.5")
            {
                TimeScaleIndicator_label.Text = "x1.25";
                timer1.Interval = Convert.ToInt32(1000 / 1.25);
            }
            else if (TimeScaleIndicator_label.Text == "x1.75")
            {
                TimeScaleIndicator_label.Text = "x1.5";
                timer1.Interval = Convert.ToInt32(1000 / 1.5);
            }
            else if (TimeScaleIndicator_label.Text == "x1.25")
            {
                TimeScaleIndicator_label.Text = "x1";
                timer1.Interval = 1000;
            }
            else if (TimeScaleIndicator_label.Text == "x2")
            {
                TimeScaleIndicator_label.Text = "x1.75";
                timer1.Interval = Convert.ToInt32(1000 / 1.75);
            }
            else if (TimeScaleIndicator_label.Text == "x5")
            {
                TimeScaleIndicator_label.Text = "x2";
                timer1.Interval = Convert.ToInt32(1000 / 2);
            }
            else if (TimeScaleIndicator_label.Text == "x10")
            {
                TimeScaleIndicator_label.Text = "x5";
                timer1.Interval = Convert.ToInt32(1000 / 5);
            }
            else
            {
                MessageBox.Show("You can not move backward");
            }
        }
        // Time Scale buttons
        // ------------------------------------------------------------------------------------

        // -----------------------------------------------------------------------------------
        // Check Boxes
        private void SMR_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SMR_overlay.IsVisibile = SMR_checkBox.Checked;
            SeeTraces_checkBox_CheckedChanged(sender, e);
        }

        private void MLAT_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.MLAT_overlay.IsVisibile = MLAT_checkBox.Checked;
            SeeTraces_checkBox_CheckedChanged(sender, e);
        }

        private void ADSB_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ADSB_overlay.IsVisibile = ADSB_checkBox.Checked;
            SeeTraces_checkBox_CheckedChanged(sender, e);
        }

        private void SeeTraces_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SeeTraces_checkBox.Checked is true)
            {
                this.SMR_traces_overlay.IsVisibile = SMR_checkBox.Checked;
                this.MLAT_traces_overlay.IsVisibile = MLAT_checkBox.Checked;
                this.ADSB_traces_overlay.IsVisibile = ADSB_checkBox.Checked;
            }
            else
            {
                this.SMR_traces_overlay.IsVisibile = false;
                this.MLAT_traces_overlay.IsVisibile = false;
                this.ADSB_traces_overlay.IsVisibile = false;
            }
        }
        // Check Boxes
        // -----------------------------------------------------------------------------------

        // ----------------------------------------------------------------------------------
        // Set Hour
        private void Set_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Hour_comboBox.SelectedIndex != -1)
                {
                    ClearAllLists();

                    if (Minuts_comboBox.SelectedIndex == -1)
                        Minuts_comboBox.SelectedItem = "00";

                    if (Seconds_comboBox.SelectedIndex == -1)
                        Seconds_comboBox.SelectedItem = "00";

                    this.currentTime = Hour_comboBox.SelectedItem.ToString() + ":" + Minuts_comboBox.SelectedItem.ToString() + ":" + Seconds_comboBox.SelectedItem.ToString();
                    Time_label.Text = this.currentTime;
                    
                    this.list_index = this.targetData_list.Count; // Just in case the following loop does not find the index value (because the Time Set is when the file with messages has already finished)
                    for (int index = 0; index < this.targetData_list.Count; index++)
                    {
                        if ((double)System.TimeSpan.Parse(targetData_list[index].Time).TotalSeconds >= (double)System.TimeSpan.Parse(this.currentTime).TotalSeconds)
                        {
                            this.list_index = index;
                            break;
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Select at least the start Hour!");
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        // Set Hour
        // ----------------------------------------------------------------------------------

        // ---------------------------------------------------------------------------------
        // Zoom in LEBL
        private void ZoomInLEBL_button_Click(object sender, EventArgs e)
        {
            GMap_control.Position = new PointLatLng(41.403046, 2.162958);
            GMap_control.Position = LEBL_position;
            GMap_control.MinZoom = 8;
            GMap_control.MaxZoom = 22;
            GMap_control.Zoom = 13;
            GMap_control.AutoScroll = true;
        }
        // Zoom in LEBL
        // ---------------------------------------------------------------------------------

        // ------------------------------------------------------
        // Clear lists methods
        private void ClearCurrentLists()
        {
            this.SMR_overlay.Clear();
            this.MLAT_overlay.Clear();
            this.ADSB_overlay.Clear();
        }

        private void ClearTracesLists()
        {
            this.SMR_traces_overlay.Clear();
            this.MLAT_traces_overlay.Clear();
            this.ADSB_traces_overlay.Clear();
        }

        private void ClearAllLists()
        {
            ClearCurrentLists();

            ClearTracesLists();
            this.SMR_traces_routes.Clear();
            this.MLAT_traces_routes.Clear();
            this.ADSB_traces_routes.Clear();
        }
        // Clear lists methods
        // ------------------------------------------------------

        // ------------------------------------------------------
        // Loading Button State functions
        private void Loading_ButtonState(Button button)
        {
            button.Text = "Loading\n...";
            button.ForeColor = Color.White;
            button.BackColor = Color.Black;
            Application.DoEvents();
        }

        private void FinishedLoading_ButtonState(Button button, string str)
        {
            button.Text = str;
            button.ForeColor = Color.Black;
            button.BackColor = Color.White;
        }
        // Loading Button State functions
        // ------------------------------------------------------


    }
}
