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
  
        List<string> columnOrder = new List<string>() { "SIC", "SAC", "Time of Day", "MessageType", "Track Number", "Target Address", "Target Identification", "X Cartesian", "Y Cartesian", "Latitude WGS84", "Latitude WGS84 HP", "Latitude Intention", "Longitude WGS84", "Longitude WGS84 HP", "Longitude Intention", "rho", "theta", "Velocity X Cart", "Velocity Y Cart", "Ground Speed", "Air Speed", "True AirSpeed", "Acceleration X", "Acceleration Y", "Track Angle", "Track Angle Rate", "FL", "Height", "Geometric Height", "Barometric Vertical Rate", "Geometric Vertical Rate", "Selected Altitude", "Altitude Intention", "Altitude Final", "Mode-3/A Code", "Emitter Category", "Vehicle Fleet Identification", "Target Length", "Target Orientation", "Target Width", "Magnetic Heading", "Receiver ID", "Service Identification", "Turbulence", "Temperature", "Wind Direction", "Wind Speed", "Roll Angle", "Amplitude", "Time of Applicability Position", "Time of Applicability Velocity", "Time of Message Reception Position", "Time of Message Reception Position HP", "Time of Message Reception Velocity", "Time of Message Reception Velocity HP", "Point Type", "Presence rho", "Presence theta", "Standard Deviation X", "Standard Deviation Y", "BDS1", "BDS2", "BDS1_BDS", "BDS2_BDS", "BDSDATA", "ATP", "Covariance", "ICF", "MB", "ME", "MSG", "PS", "RA", "RAS", "SIM", "SS", "TCAS", "TD", "TOM", "TOT", "TOV", "TTR" };

        public DataTable(List<Data> data_list)
        {
            InitializeComponent();
            TableCleared();

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            dataGridView1.RowCount = data_list.Count + 1;
            dataGridView1.ColumnCount = 2;

            // Row[0] bold
            dataGridView1.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            dataGridView1.Rows[0].Cells[0].Value = "Message number";
            dataGridView1.Rows[0].Cells[1].Value = "CAT";

            for (int i = 0; i < data_list.Count; i++)
            {
                dataGridView1.Rows[i + 1].Cells[0].Value = i + 1;
                dataGridView1.Rows[i + 1].Cells[1].Value = data_list[i].CAT;
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
