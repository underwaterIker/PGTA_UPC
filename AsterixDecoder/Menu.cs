﻿using System;
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
using System.Drawing.Text;
using System.CodeDom;

namespace AsterixDecoder
{
    public partial class Menu : Form
    {
        // List containing all CAT messages in order
        private List<Data> messagesData_list; 
        private int index_messagesDataList;
        private int index_dataItems;
        // List with Filtered messages
        private List<Data> Filtered_messagesData_list;
        private bool Filter_flag;

        // CAT indicators
        private bool CAT10_flag;
        private bool CAT21_flag;

        // file loaded indicator
        private bool fileLoaded_flag = false;

        double LAT = 41.29839;
        double LON = 2.08331;


        public Menu()
        {
            InitializeComponent();
        }

        private void LoadFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loading waitingForm = new Loading();
            waitingForm.Show();
            try
            {
                OpenFileDialog LoadFile = new OpenFileDialog();
                if (LoadFile.ShowDialog() == DialogResult.OK && Path.GetExtension(LoadFile.FileName) == ".ast")
                {
                    string fileName = LoadFile.FileName;

                    Decodification decoder = new Decodification(fileName);
                    this.messagesData_list = decoder.messagesData_list;
                    this.CAT10_flag = decoder.CAT10_present;
                    this.CAT21_flag = decoder.CAT21_present;

                    //MessageBox.Show("done");

                    this.fileLoaded_flag = true;

                    Set_dataList_DGV(this.messagesData_list);
                }
                else
                {
                    MessageBox.Show("Select a valid file format.", "Incorrect file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            waitingForm.Close();

        }

        private void dataList_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != 0)
                {
                    int index = e.RowIndex - 1;
                    this.index_messagesDataList = index;
                    if (this.Filter_flag is false)
                    {
                        Set_dataItems_DGV(this.messagesData_list[index]);
                    }
                    else
                    {
                        Set_dataItems_DGV(this.Filtered_messagesData_list[index]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataItems_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != 0)
                {
                    int index = e.RowIndex - 1;
                    this.index_dataItems = index;
                    if (this.Filter_flag is false)
                    {
                        Set_Item_DGV(this.messagesData_list[this.index_messagesDataList].data_list[index], this.messagesData_list[this.index_messagesDataList].fieldTypes[index], this.messagesData_list[this.index_messagesDataList].CAT);
                    }
                    else
                    {
                        Set_Item_DGV(this.Filtered_messagesData_list[this.index_messagesDataList].data_list[index], this.Filtered_messagesData_list[this.index_messagesDataList].fieldTypes[index], this.Filtered_messagesData_list[this.index_messagesDataList].CAT);
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Filter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter_textBox.Enabled = true;
            Filter_button.Enabled = true;

            Filter_textBox.Clear();
        }

        private void Filter_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.fileLoaded_flag is true)
                {
                    if (Filter_comboBox.SelectedIndex > -1) //somthing was selected
                    {
                        dataList_DGV.Rows.Clear();
                        dataList_DGV.Columns.Clear();

                        int[] cat;
                        int[] fieldType;
                        int[] index_item;
                        string textBox = Filter_textBox.Text;

                        switch (Filter_comboBox.SelectedIndex)
                        {
                            case 0: // Track number
                                cat = new int[2] { 10, 21 };
                                fieldType = new int[2] { 161, 161 };
                                index_item = new int[2] { 0, 0 };
                                Set_Filtered_messagesData_list(cat, fieldType, index_item, textBox);
                                Set_dataList_DGV(this.Filtered_messagesData_list);
                                break;

                            case 1: // Target Address
                                cat = new int[2] { 10, 21 };
                                fieldType = new int[2] { 220, 80 };
                                index_item = new int[2] { 0, 0 };
                                Set_Filtered_messagesData_list(cat, fieldType, index_item, textBox);
                                Set_dataList_DGV(this.Filtered_messagesData_list);
                                break;

                            case 2: // Target Identification
                                cat = new int[2] { 10, 21 };
                                fieldType = new int[2] { 245, 170 };
                                index_item = new int[2] { 1, 0 };
                                Set_Filtered_messagesData_list(cat, fieldType, index_item, textBox);
                                Set_dataList_DGV(this.Filtered_messagesData_list);
                                break;

                            case 3: // Mode 3A Code
                                cat = new int[2] { 10, 21 };
                                fieldType = new int[2] { 60, 70 };
                                index_item = new int[2] { 3, 0 };
                                Set_Filtered_messagesData_list(cat, fieldType, index_item, textBox);
                                Set_dataList_DGV(this.Filtered_messagesData_list);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select a Data Item to filter.", "Data Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Load a file before filtering", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ExportCSV_button_Click(object sender, EventArgs e)
        {
            Loading waitingForm = new Loading();
            waitingForm.Show();

            if (this.fileLoaded_flag is true)
            {
                try
                {
                    if (this.Filter_flag is false)
                    {
                        ExportCSV(this.messagesData_list);
                    }
                    else
                    {
                        ExportCSV(this.Filtered_messagesData_list);
                    }

                }
                catch
                {
                    MessageBox.Show("An error has occurred.\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Load a file before exporting", "File not loaded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            waitingForm.Close();
        }

        // -----------------------------------------------------------------------------
        // Set DataGridView funcions
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

        private void Set_Item_DGV(object item, int itemCode, int cat)
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
            if (cat == 10)
            {
                item_dict = Dictionaries.FieldType_ItemsName_CAT10_dict[itemCode];
            }
            else //else if (cat == 21)
            {
                item_dict = Dictionaries.FieldType_ItemsName_CAT21_dict[itemCode];
            }

            // Loop depending if its a Compund Data Item or not            
            for (int i = 0; i < item_array.Count; i++)
            {
                if (item_array[i] is IList) // REP items
                {
                    var REPitem_list = item_array[i] as IList;
                    Item_DGV.ColumnCount = 2*REPitem_list.Count;

                    for (int j = 0; j < REPitem_list.Count; j++)
                    {
                        Item_DGV.Rows[i + 1].Cells[0 + 2*j].Value = item_dict[i];
                        Item_DGV.Rows[i + 1].Cells[1 + 2*j].Value = REPitem_list[j];
                    }
                }
                else // normal items
                {
                    Item_DGV.Rows[i + 1].Cells[0].Value = item_dict[i];
                    Item_DGV.Rows[i + 1].Cells[1].Value = item_array[i];
                }
                    
            }
            
        }

        // ------------------------------------------------------
        // Export function
        private void ExportCSV(List<Data> messagesData_list)
        {
            // Set the StringBuilders we are going to need (one for each CAT present in the message)
            StringBuilder[] CSVs = new StringBuilder[2];
            SaveFileDialog[] SaveFileDialogs = new SaveFileDialog[2];

            // Set the Dictionaries we are going to need
            IDictionary<int, string>[] fieldTypeName_dicts = new Dictionary<int, string>[2];
            IDictionary<int, string[]>[] ItemsName_dicts = new Dictionary<int, string[]>[2];

            fieldTypeName_dicts[0] = Dictionaries.FieldType_Name_CAT10_dict;
            ItemsName_dicts[0] = Dictionaries.FieldType_ItemsName_CAT10_dict;

            fieldTypeName_dicts[1] = Dictionaries.FieldType_Name_CAT21_dict;
            ItemsName_dicts[1] = Dictionaries.FieldType_ItemsName_CAT21_dict;

            bool[] flags = new bool[2];

            // Headers CAT10
            if (this.CAT10_flag is true)
            {
                string headers_cat10 = "";
                string subheaders_cat10 = "";
                foreach (var header_cat10 in fieldTypeName_dicts[0])
                {
                    headers_cat10 = headers_cat10 + header_cat10.Value;

                    foreach (string itemsName_cat10 in ItemsName_dicts[0][header_cat10.Key])
                    {
                        headers_cat10 = headers_cat10 + ";";
                        subheaders_cat10 = subheaders_cat10 + itemsName_cat10 + ";";
                    }

                }
                CSVs[0] = new StringBuilder();
                CSVs[0].AppendLine(headers_cat10);
                CSVs[0].AppendLine(subheaders_cat10);

                SaveFileDialogs[0] = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "CAT10" };

                flags[0] = false;
            }
            
            // Headers CAT21
            if (this.CAT21_flag is true)
            {
                string headers_cat21 = "";
                string subheaders_cat21 = "";
                foreach (var header_cat21 in fieldTypeName_dicts[1])
                {
                    headers_cat21 = headers_cat21 + header_cat21.Value;

                    foreach (string itemsName_cat21 in ItemsName_dicts[1][header_cat21.Key])
                    {
                        headers_cat21 = headers_cat21 + ";";
                        subheaders_cat21 = subheaders_cat21 + itemsName_cat21 + ";";
                    }

                }
                CSVs[1] = new StringBuilder();
                CSVs[1].AppendLine(headers_cat21);
                CSVs[1].AppendLine(subheaders_cat21);

                SaveFileDialogs[1] = new SaveFileDialog() { Filter = "CSV|*.csv", FileName = "CAT21" };

                flags[1] = false;
            }
            

            // Messages
            int dictionary_index = 0;
            foreach (Data oneMessageData in messagesData_list)
            {
                if (oneMessageData.CAT == 10)
                {
                    dictionary_index = 0;
                    if (flags[0] is false)
                    {
                        flags[0] = true;
                    }    
                }
                else if (oneMessageData.CAT == 21)
                {
                    dictionary_index = 1;
                    if (flags[1] is false)
                    {
                        flags[1] = true;
                    }
                }

                string oneMessage = "";
                int index_oneMessageDataItems = 0;
                int index_allDataItems = 0;

                // for REP items:
                string oneMessage_emptyForREP = "";
                List<string> REP_oneMessage = new List<string>();

                foreach (int number in fieldTypeName_dicts[dictionary_index].Keys)
                {
                    if (index_oneMessageDataItems < oneMessageData.fieldTypes.Count && oneMessageData.fieldTypes[index_oneMessageDataItems] == number)
                    {
                        for (int i = 0; i < ItemsName_dicts[dictionary_index][number].Length; i++)
                        {
                            if (i < oneMessageData.data_list[index_oneMessageDataItems].Count)
                            {
                                var item = oneMessageData.data_list[index_oneMessageDataItems][i];
                                if (item is IList) // REP items
                                {
                                    var REPitem_list = item as IList;

                                    for (int j = 0; j < REPitem_list.Count; j++)
                                    {
                                        if (j == 0)
                                        {
                                            oneMessage = oneMessage + REPitem_list[j].ToString() + ";";
                                        }
                                        else
                                        {
                                            if (j >= REPitem_list.Count)
                                            {
                                                REP_oneMessage.Add(oneMessage_emptyForREP);
                                            }
                                                    
                                            REP_oneMessage[j-1] = REP_oneMessage[j-1] + REPitem_list[j].ToString() + ";";
                                        }

                                    }
                                    oneMessage_emptyForREP = oneMessage_emptyForREP + ";";
                                }
                                else // normal items
                                {
                                    oneMessage = oneMessage + item.ToString() + ";";
                                    oneMessage_emptyForREP = oneMessage_emptyForREP + ";";
                                }
                                        
                            }
                            else
                            {
                                oneMessage = oneMessage + ";";
                                oneMessage_emptyForREP = oneMessage_emptyForREP + ";";
                            }
                        }
                        index_oneMessageDataItems++;

                    }
                    else
                    {
                        for (int i = 0; i < ItemsName_dicts[dictionary_index][number].Length; i++)
                        {
                            oneMessage = oneMessage + ";";
                            oneMessage_emptyForREP = oneMessage_emptyForREP + ";";
                        }
                    }
                    index_allDataItems++;
                }

                CSVs[dictionary_index].AppendLine(oneMessage);
                for(int i = 0; i < REP_oneMessage.Count; i++) // In case there is a REP Data Item
                {
                    CSVs[dictionary_index].AppendLine(REP_oneMessage[i]);
                }

            }

            for (int i = 0; i < CSVs.Length; i++)
            {
                if (flags[i] is true)
                {
                    if (SaveFileDialogs[i].ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(SaveFileDialogs[i].FileName, CSVs[i].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Error when saving .csv file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }

        // ------------------------------------------------------
        // Filter function
        private void Set_Filtered_messagesData_list(int[] cat, int[] fieldType, int[] index_item, string textBox)
        {
            this.Filter_flag = true;

            this.Filtered_messagesData_list = new List<Data>();
            for (int i = 0; i < this.messagesData_list.Count; i++)
            {
                int index_cat10 = this.messagesData_list[i].fieldTypes.IndexOf(fieldType[0]);
                int index_cat21 = this.messagesData_list[i].fieldTypes.IndexOf(fieldType[1]);
                int cat_number = this.messagesData_list[i].CAT;

                if (index_cat10 != -1 && cat_number == cat[0])
                {
                    if (textBox == "")
                    {
                        this.Filtered_messagesData_list.Add(this.messagesData_list[i]);
                    }
                    else
                    {
                        if (this.messagesData_list[i].data_list[index_cat10][index_item[0]].ToString() == textBox)
                        {
                            this.Filtered_messagesData_list.Add(this.messagesData_list[i]);
                        }
                    }
                    
                }
                else if (index_cat21 != -1 && cat_number == cat[1])
                {
                    if (textBox == "")
                    {
                        this.Filtered_messagesData_list.Add(this.messagesData_list[i]);
                    }
                    else
                    {
                        if (this.messagesData_list[i].data_list[index_cat21][index_item[1]].ToString() == textBox)
                        {
                            this.Filtered_messagesData_list.Add(this.messagesData_list[i]);
                        }
                    }

                }
            }
        }


    }
}
