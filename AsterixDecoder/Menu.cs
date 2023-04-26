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
        private List<Data> messagesData_list = new List<Data>();
        private int index_messagesDataList;
        private int index_dataItems;

        double LAT = 41.29839;
        double LON = 2.08331;


        public Menu()
        {
            InitializeComponent();
        }

        private void LoadFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadFile = new OpenFileDialog();
            if (LoadFile.ShowDialog() == DialogResult.OK && Path.GetExtension(LoadFile.FileName) == ".ast")
            {
                string fileName = LoadFile.FileName;

                Decodification decoder = new Decodification(fileName);
                this.messagesData_list = decoder.messagesData_list;

                //MessageBox.Show("done");

                Set_dataList_DGV(this.messagesData_list);
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
                this.index_messagesDataList = index;
                Set_dataItems_DGV(this.messagesData_list[index]);
            }
        }

        private void dataItems_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                int index = e.RowIndex - 1;
                this.index_dataItems = index;
                Set_Item_DGV(this.messagesData_list[this.index_messagesDataList].data_list[index], this.messagesData_list[this.index_messagesDataList].fieldTypes[index]);
            }
        }

        private void ShowMap_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutUs_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs AboutUs = new AboutUs();
            AboutUs.Show();
        }

        // -----------------------------------------------------------------------------

        private void Set_dataList_DGV(List<Data> messagesData_list)
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
            dataList_DGV.RowCount = messagesData_list.Count + 1;
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

            for (int i = 0; i < messagesData_list.Count; i++)
            {
                dataList_DGV.Rows[i + 1].Cells[0].Value = i + 1;
                dataList_DGV.Rows[i + 1].Cells[1].Value = messagesData_list[i].LENGTH;
                dataList_DGV.Rows[i + 1].Cells[2].Value = messagesData_list[i].numberOfDataItems;
                dataList_DGV.Rows[i + 1].Cells[3].Value = messagesData_list[i].CAT;
            }
        }

        private void Set_dataItems_DGV(Data messageData)
        {
            dataItems_DGV.Columns.Clear();
            dataItems_DGV.Rows.Clear();
            Item_DGV.Columns.Clear();
            Item_DGV.Rows.Clear();

            dataItems_DGV.RowHeadersVisible = false;
            dataItems_DGV.ColumnHeadersVisible = false;

            // Set the number of rows and columns
            dataItems_DGV.RowCount = messageData.numberOfDataItems + 1;
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
            if (messageData.CAT == 10)
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
            for (int i = 0; i < messageData.numberOfDataItems; i++)
            {
                dataItems_DGV.Rows[i + 1].Cells[0].Value = code_dict[messageData.fieldTypes[i]];
                dataItems_DGV.Rows[i + 1].Cells[1].Value = name_dict[messageData.fieldTypes[i]];
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
            if (this.messagesData_list[this.index_messagesDataList].CAT == 10)
            {
                item_dict = Dictionaries.FieldType_ItemsName_CAT10_dict[itemCode];
            }
            else //else if (this.data_list[this.index_dataList].CAT == 21)
            {
                item_dict = Dictionaries.FieldType_ItemsName_CAT21_dict[itemCode];
            }

            // Loop depending if its a Compund Data Item or not
            if (itemCode == 250) // Mode S MB Data (Cat10 & Cat21)
            {
                //int REP = (int)item_array[0];
                int oneReport_length = 8;
                for (int i = 0; i < item_array.Count-1;)
                {
                    for (int j = 0; j < oneReport_length; j++)
                    {
                        Item_DGV.Rows[i + 1].Cells[0].Value = item_dict[j];
                        Item_DGV.Rows[i + 1].Cells[1].Value = item_array[i+1];
                        i++;
                    }
                }
            }
            else if (itemCode == 280 && this.messagesData_list[this.index_messagesDataList].CAT == 10) // Presence (Cat10)
            {
                //int REP = (int)item_array[0];
                int oneReport_length = 2;
                for (int i = 0; i < item_array.Count - 1;)
                {
                    for (int j = 0; j < oneReport_length; j++)
                    {
                        Item_DGV.Rows[i + 1].Cells[0].Value = item_dict[j];
                        Item_DGV.Rows[i + 1].Cells[1].Value = item_array[i + 1];
                        i++;
                    }
                }
            }
            else if (itemCode == 220 && this.messagesData_list[this.index_messagesDataList].CAT == 21) // Met Information (Cat21)
            {
                int numberOfRows = 0;
                for (int i = 0; i < item_array.Count; i++)
                {
                    if (item_array[i] != null)
                    {
                        Item_DGV.Rows[numberOfRows + 1].Cells[0].Value = item_dict[i];
                        Item_DGV.Rows[numberOfRows + 1].Cells[1].Value = item_array[i];
                        numberOfRows++;
                    }
                }
                Item_DGV.RowCount = numberOfRows + 1;
            }
            else if (itemCode == 110 && this.messagesData_list[this.index_messagesDataList].CAT == 21) // Trajectory Intent (Cat21)
            {
                int index = 0;
                //  Subfield 1
                if (item_array[0] != null && item_array[1] != null)
                {
                    Item_DGV.Rows[index + 1].Cells[0].Value = item_dict[index];
                    Item_DGV.Rows[index + 1].Cells[1].Value = item_array[index];
                    Item_DGV.Rows[index + 2].Cells[0].Value = item_dict[index + 1];
                    Item_DGV.Rows[index + 2].Cells[1].Value = item_array[index + 1];
                    index = 2;
                }

                // Subfield 2
                //int REP = (int)item_array[index];
                int oneReport_length = 15;
                for ( ; index < item_array.Count - 1;)
                {
                    for (int j = 0; j < oneReport_length; j++)
                    {
                        Item_DGV.Rows[index + 1].Cells[0].Value = item_dict[j];
                        Item_DGV.Rows[index + 1].Cells[1].Value = item_array[index + 1];
                        index++;
                    }
                }
                Item_DGV.RowCount = index + 1;
            }
            else if (itemCode == 295 && this.messagesData_list[this.index_messagesDataList].CAT == 21) // Data Ages (Cat21)
            {
                int numberOfRows = 0;
                for (int i = 0; i < item_array.Count; i++)
                {
                    if (item_array[i] != null)
                    {
                        Item_DGV.Rows[numberOfRows + 1].Cells[0].Value = item_dict[i];
                        Item_DGV.Rows[numberOfRows + 1].Cells[1].Value = item_array[i];
                        numberOfRows++;
                    }
                }
                Item_DGV.RowCount = numberOfRows + 1;
            }
            else // All Data Items that are not the ones above
            {
                // Loop
                for (int i = 0; i < item_array.Count; i++)
                {
                    Item_DGV.Rows[i + 1].Cells[0].Value = item_dict[i];
                    Item_DGV.Rows[i + 1].Cells[1].Value = item_array[i];
                }
            }
            
        }

        
    }
}
