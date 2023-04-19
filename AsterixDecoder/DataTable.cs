using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class DataTable : Form
    {
  
        //int i = 0;
        //int f = 1000;

        List<string> columnOrder = new List<string>() { "SIC", "SAC", "Time of Day", "MessageType", "Track Number", "Target Address", "Target Identification", "X Cartesian", "Y Cartesian", "Latitude WGS84", "Latitude WGS84 HP", "Latitude Intention", "Longitude WGS84", "Longitude WGS84 HP", "Longitude Intention", "rho", "theta", "Velocity X Cart", "Velocity Y Cart", "Ground Speed", "Air Speed", "True AirSpeed", "Acceleration X", "Acceleration Y", "Track Angle", "Track Angle Rate", "FL", "Height", "Geometric Height", "Barometric Vertical Rate", "Geometric Vertical Rate", "Selected Altitude", "Altitude Intention", "Altitude Final", "Mode-3/A Code", "Emitter Category", "Vehicle Fleet Identification", "Target Length", "Target Orientation", "Target Width", "Magnetic Heading", "Receiver ID", "Service Identification", "Turbulence", "Temperature", "Wind Direction", "Wind Speed", "Roll Angle", "Amplitude", "Time of Applicability Position", "Time of Applicability Velocity", "Time of Message Reception Position", "Time of Message Reception Position HP", "Time of Message Reception Velocity", "Time of Message Reception Velocity HP", "Point Type", "Presence rho", "Presence theta", "Standard Deviation X", "Standard Deviation Y", "BDS1", "BDS2", "BDS1_BDS", "BDS2_BDS", "BDSDATA", "ATP", "Covariance", "ICF", "MB", "ME", "MSG", "PS", "RA", "RAS", "SIM", "SS", "TCAS", "TD", "TOM", "TOT", "TOV", "TTR" };

        public DataTable(List<CAT21_Data> data21 = null, List<CAT10_Data> data10 = null)
        {
            InitializeComponent();
            TableCleared();

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            Type type = data10 == null ? data21[0].GetType() : data10[0].GetType();
            PropertyInfo[] Properties = type.GetProperties();

            foreach (PropertyInfo prop in Properties)
            {
                string name = prop.Name;
                dataGridView1.Columns.Add(name, name);
            }

            if (data10 == null)
                DrawTableCAT21(data21, Properties);
            else DrawTableCAT10(data10, Properties);
        }

        public void DrawTableCAT21(List<CAT21_Data> data, PropertyInfo[] Properties)
        {
            foreach (CAT21_Data element in data)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                for (int i = 0; i < Properties.Length; i++)
                {
                    PropertyInfo prop = Properties[i];
                    object value = prop.GetValue(element);
                    row.Cells[i].Value = value;
                }
                dataGridView1.Rows.Add(row);
            }
        }

        public void DrawTableCAT10(List<CAT10_Data> data, PropertyInfo[] Properties)
        {
            foreach (CAT10_Data element in data)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                for (int i = 0; i < Properties.Length; i++)
                {
                    PropertyInfo prop = Properties[i];
                    object value = prop.GetValue(element);
                    row.Cells[i].Value = value;
                }
                dataGridView1.Rows.Add(row);
            }
        }

        private void DataTable_Load(object sender, EventArgs e)
        {
         
        }

        public void TableCleared()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}
