using ClassLibrary;
using GMap.NET;
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
using System.Reflection.Emit;
using System.Windows.Forms.DataVisualization.Charting;

namespace AsterixDecoder
{
    public partial class FLsInsideDER : Form
    {
        // ATTRIBUTES
        // List containing TargetData of all targets
        private List<TargetData> targetData_list;

        // Selected Runway
        private int selectedRunway_index;

        // List with all the DER points of each runway (the index of this list corresponds to the selected index in the comboBox)
        private readonly List<List<PointLatLng>> DERs_list = new List<List<PointLatLng>>
        {
            // 24L DER (DER: Departure End of Runway)
            new List<PointLatLng>
            {
                new PointLatLng(41.282975, 2.075364), // RightUp [0]
                new PointLatLng(41.282447, 2.075648), // RightDown [1]
                new PointLatLng(41.282290, 2.073250), // LeftUp [2]
                new PointLatLng(41.281548, 2.073695) // LeftDown [3]
            },
            // 06R DER (DER: Departure End of Runway)
            new List<PointLatLng>
            {
                new PointLatLng(41.292881, 2.104156), // RightUp
                new PointLatLng(41.292192, 2.104574), // RightDown
                new PointLatLng(41.292131, 2.102069), // LeftUp
                new PointLatLng(41.291615, 2.102380) // LeftDown
            },
            // 24R DER (DER: Departure End of Runway)
            new List<PointLatLng>
            {
                new PointLatLng(41.294466, 2.069489), // RightUp
                new PointLatLng(41.293701, 2.069972), // RightDown
                new PointLatLng(41.293189, 2.065305), // LeftUp
                new PointLatLng(41.292278, 2.065793) // LeftDown
            },
            // 06L DER (DER: Departure End of Runway)
            new List<PointLatLng>
            {
                new PointLatLng(41.306722, 2.105287), // RightUp
                new PointLatLng(41.305930, 2.105743), // RightDown
                new PointLatLng(41.305673, 2.102435), // LeftUp
                new PointLatLng(41.305055, 2.102788) // LeftDown
            },
            // 20 DER (DER: Departure End of Runway)
            new List<PointLatLng>
            {
                new PointLatLng(41.288632, 2.084884), // RightUp
                new PointLatLng(41.288496, 2.085522), // RightDown
                new PointLatLng(41.286981, 2.084154), // LeftUp
                new PointLatLng(41.286883, 2.084772) // LeftDown
            },
            // 02 DER (DER: Departure End of Runway)
            new List<PointLatLng>
            {
                new PointLatLng(41.310089, 2.094568), // RightUp
                new PointLatLng(41.309881, 2.095368), // RightDown
                new PointLatLng(41.308136, 2.093760), // LeftUp
                new PointLatLng(41.307994, 2.094410) // LeftDown
            }
        };

        // Lists to save the FLs for each target
        private List<List<double>> FLs = new List<List<double>>();
        private List<string> targetIDs = new List<string>();


        // CONSTRUCTOR
        public FLsInsideDER(List<TargetData> targetData_list)
        {
            InitializeComponent();
            this.targetData_list = targetData_list;
        }


        // METHODS
        private void SelectRwy_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedRunway_index = SelectRwy_comboBox.SelectedIndex;

            this.FLs.Clear();
            this.targetIDs.Clear();

            SaveFLsInsideDER(this.DERs_list[this.selectedRunway_index]);

            if (this.FLs.Count > 0)
            {
                Set_FLs_DGV();
                FLs_DGV.Rows[0].Cells[0].Selected = false;

                Set_FLs_chart();

                SaveCSV_button.Enabled = true;
            }
            else
            {
                FLs_DGV.Rows.Clear();
                FLs_DGV.Columns.Clear();

                FLs_chart.Series.Clear();

                SaveCSV_button.Enabled = false;

                MessageBox.Show("Thera are no target records in this runway.", "Try another runway", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void SaveCSV_button_Click(object sender, EventArgs e)
        {
            Loading_ButtonState(SaveCSV_button);

            try
            {
                StringBuilder csv_file = new StringBuilder();
                SaveFileDialog saveFile = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "FlightLevels_insideDER" };

                // Headers
                string headers = "Track Number;Fligh Levels;";
                csv_file.AppendLine(headers);

                // Flight Levels
                for (int i = 0; i < this.FLs.Count; i++)
                {
                    string str = this.targetIDs[i] + ";";
                    foreach (double fl in this.FLs[i])
                    {
                        str = str + fl.ToString() + ";";
                    }
                    csv_file.AppendLine(str);
                }

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFile.FileName, csv_file.ToString());
                }
                else
                {
                    MessageBox.Show("Error when saving .csv file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            FinishedLoading_ButtonState(SaveCSV_button, "SAVE DATA IN .CSV");
        }

        private void SaveFLsInsideDER(List<PointLatLng> points_list)
        {
            foreach (TargetData targetData in this.targetData_list)
            {
                if (targetData.FlightLevel != null)
                {
                    // Note down the FLs inside the DER
                    if (targetData.Position[1] >= points_list[2].Lng && targetData.Position[1] <= points_list[1].Lng)
                    {
                        if (targetData.Position[0] >= points_list[3].Lat && targetData.Position[0] <= points_list[0].Lat)
                        {
                            int FLs_index = this.targetIDs.FindIndex(x => x == targetData.ID[0]);
                            if (FLs_index != -1)
                            {
                                this.FLs[FLs_index].Add((double)targetData.FlightLevel);
                            }
                            else
                            {
                                this.targetIDs.Add(targetData.ID[0]);
                                List<double> FL = new List<double>() { (double)targetData.FlightLevel };
                                this.FLs.Add(FL);
                            }
                        }
                    }
                }
                
            }
        }

        private void Set_FLs_DGV()
        {
            FLs_DGV.Columns.Clear();
            FLs_DGV.Rows.Clear();

            FLs_DGV.RowHeadersVisible = false;
            FLs_DGV.ColumnHeadersVisible = false;

            // Set the number of rows and columns
            FLs_DGV.RowCount = this.FLs.Count + 1;
            FLs_DGV.ColumnCount = 10;

            FLs_DGV.Rows[0].Cells[0].Selected = false;
            FLs_DGV.Columns[0].Width = 130;

            // Row[0] Bold and Frozen
            FLs_DGV.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            FLs_DGV.Rows[0].Frozen = true;
            FLs_DGV.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            // Headers
            FLs_DGV.Rows[0].Cells[0].Value = "Track Number";
            FLs_DGV.Rows[0].Cells[1].Value = "FL";

            for (int i = 0; i < this.FLs.Count; i++)
            {
                FLs_DGV.Rows[i+1].Cells[0].Value = this.targetIDs[i];
                for (int j = 0; j < this.FLs[i].Count; j++)
                {
                    FLs_DGV.Rows[i + 1].Cells[j+1].Value = this.FLs[i][j];
                }
            }
        }

        private void Set_FLs_chart()
        {
            FLs_chart.Series.Clear();
            
            var objChart = FLs_chart.ChartAreas[0];

            objChart.AxisX.IntervalType = DateTimeIntervalType.Number;
            objChart.AxisY.IntervalType = DateTimeIntervalType.Number;

            objChart.AxisX.Minimum = 0;

            if (FLs_chart.Titles.Count == 0)
            {
                FLs_chart.Titles.Add("Flight Levels inside DER");
                FLs_chart.Titles[0].Font = new Font("Tahoma", 18, FontStyle.Bold);
            }
                
            objChart.AxisX.Title = "Steps";
            objChart.AxisY.Title = "Flight Level [FL]";
            objChart.AxisX.TitleFont = new Font("Tahoma", 12);
            objChart.AxisY.TitleFont = new Font("Tahoma", 12);

            Random random = new Random();

            for (int i = 0;i < this.FLs.Count;i++)
            {
                FLs_chart.Series.Add(this.targetIDs[i]);
                FLs_chart.Series[this.targetIDs[i]].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                FLs_chart.Series[this.targetIDs[i]].BorderWidth = 3;
                FLs_chart.Series[this.targetIDs[i]].ChartType = SeriesChartType.Line;

                for (int j =0; j < this.FLs[i].Count;j++)
                {
                    FLs_chart.Series[this.targetIDs[i]].Points.AddXY(j, this.FLs[i][j]);
                }
            }
            
        }


        // ------------------------------------------------------
        // Loading Button State methods
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
        // Loading Button State methods
        // ------------------------------------------------------


    }
}
