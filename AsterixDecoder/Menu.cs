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
using System.Collections;
using System.Globalization;
using Microsoft.Ajax.Utilities;

namespace AsterixDecoder
{
    public partial class Menu : Form
    {
        // List containing all CAT messages in order
        private List<Decodification> data_list = new List<Decodification>();
        private int index_dataList;
        private int index_dataItems;

        double LAT = 41.29839;
        double LON = 2.08331;


        public Menu()
        {
            InitializeComponent();
        }

        private void loadFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadFile = new OpenFileDialog();
            if (LoadFile.ShowDialog() == DialogResult.OK && Path.GetExtension(LoadFile.FileName) == ".ast")
            {
                string fileName = LoadFile.FileName;

                ReadFile readFile = new ReadFile(fileName);
                this.data_list = readFile.data_list;

                //MessageBox.Show("done");

                Set_dataList_DGV(this.data_list);
            }
            else
            {
                MessageBox.Show("Select a valid file format.", "Incorrect file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataList_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                int index = e.RowIndex - 1;
                this.index_dataList = index;
                Set_dataItems_DGV(this.data_list[index]);
            }
        }

        private void dataItems_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                int index = e.RowIndex - 1;
                this.index_dataItems = index;
                Set_Item_DGV(this.data_list[this.index_dataList].data_list[index], this.data_list[this.index_dataList].fieldTypes[index]);
            }
        }

        private void showMap_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutUs AboutUs = new AboutUs();
            AboutUs.Show();
        }

        // -----------------------------------------------------------------------------

        private void Set_dataList_DGV(List<Decodification> data_list)
        {
            dataList_DGV.Columns.Clear();
            dataList_DGV.Rows.Clear();
            dataItems_DGV.Columns.Clear();
            dataItems_DGV.Rows.Clear();
            Item_DGV.Columns.Clear();
            Item_DGV.Rows.Clear();

            dataList_DGV.RowHeadersVisible = false;
            dataList_DGV.ColumnHeadersVisible = false;

            // Set the number of rows and columns
            dataList_DGV.RowCount = data_list.Count + 1;
            dataList_DGV.ColumnCount = 4;

            dataList_DGV.Rows[0].Cells[0].Selected = false;
            dataList_DGV.Columns[0].Width = 50;
            dataList_DGV.Columns[1].Width = 80;
            dataList_DGV.Columns[2].Width = 80;
            dataList_DGV.Columns[3].Width = 80;

            // Row[0] bold
            dataList_DGV.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            dataList_DGV.Rows[0].Cells[1].Value = "Length";
            dataList_DGV.Rows[0].Cells[2].Value = "#Items";
            dataList_DGV.Rows[0].Cells[3].Value = "CAT";

            for (int i = 0; i < data_list.Count; i++)
            {
                dataList_DGV.Rows[i + 1].Cells[0].Value = i + 1;
                dataList_DGV.Rows[i + 1].Cells[1].Value = data_list[i].LENGTH;
                dataList_DGV.Rows[i + 1].Cells[2].Value = data_list[i].numberOfDataItems;
                dataList_DGV.Rows[i + 1].Cells[3].Value = data_list[i].CAT;
            }
        }

        private void Set_dataItems_DGV(Decodification data)
        {
            dataItems_DGV.Columns.Clear();
            dataItems_DGV.Rows.Clear();

            dataItems_DGV.RowHeadersVisible = false;
            dataItems_DGV.ColumnHeadersVisible = false;

            // Set the number of rows and columns
            dataItems_DGV.RowCount = data.numberOfDataItems + 1;
            dataItems_DGV.ColumnCount = 2;

            dataItems_DGV.Rows[0].Cells[0].Selected = false;
            dataItems_DGV.Columns[0].Width = 120;
            dataItems_DGV.Columns[1].Width = 240;

            // Row[0] bold
            dataItems_DGV.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            dataItems_DGV.Rows[0].Cells[0].Value = "Field Type";
            dataItems_DGV.Rows[0].Cells[1].Value = "Description";

            // Set Dictionaries depending on the CAT number
            IDictionary<int, string> code_dict;
            IDictionary<int, string> name_dict;
            if (data.CAT == 10)
            {
                code_dict = Dictionaries.FieldType_Code_CAT10_dict;
                name_dict = Dictionaries.FieldType_Name_CAT10_dict;
            }
            else
            {
                code_dict = Dictionaries.FieldType_Code_CAT21_dict;
                name_dict = Dictionaries.FieldType_Name_CAT21_dict;
            }

            // Loop
            for (int i = 0; i < data.numberOfDataItems; i++)
            {
                dataItems_DGV.Rows[i + 1].Cells[0].Value = code_dict[data.fieldTypes[i]];
                dataItems_DGV.Rows[i + 1].Cells[1].Value = name_dict[data.fieldTypes[i]];
            }
        }

        private void Set_Item_DGV(object item, int itemCode)
        {
            var item_array = item as IList;

            Item_DGV.Columns.Clear();
            Item_DGV.Rows.Clear();

            Item_DGV.RowHeadersVisible = false;
            Item_DGV.ColumnHeadersVisible = false;

            // Set the number of rows and columns
            Item_DGV.RowCount = item_array.Count + 1;
            Item_DGV.ColumnCount = 2;

            Item_DGV.Rows[0].Cells[0].Selected = false;
            Item_DGV.Columns[0].Width = 120;
            Item_DGV.Columns[1].Width = 240;

            // Row[0] bold
            Item_DGV.Rows[0].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);

            // Headers
            Item_DGV.Rows[0].Cells[0].Value = "Item name";
            Item_DGV.Rows[0].Cells[1].Value = "Value";

            // Set Item Dictionary depending on CAT number
            string[] item_dict;
            if (this.data_list[this.index_dataList].CAT == 10)
            {
                item_dict = Dictionaries.FieldType_ItemsName_CAT10_dict[itemCode];
            }
            else //else if (this.data_list[this.index_dataList].CAT == 21)
            {
                item_dict = Dictionaries.FieldType_ItemsName_CAT21_dict[itemCode];
            }

            // Loop
            for (int i = 0; i < item_array.Count; i++)
            {
                Item_DGV.Rows[i + 1].Cells[0].Value = item_dict[i];
                Item_DGV.Rows[i + 1].Cells[1].Value = item_array[i];
            }
        }

    }
}
