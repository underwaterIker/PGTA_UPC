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
            dataGridView1.Rows[0].Cells[0].Value = "Message n°";
            dataGridView1.Rows[0].Cells[1].Value = "CAT";

            for (int i = 0; i < data_list.Count; i++)
            {
                dataGridView1.Rows[i + 1].Cells[0].Value = i + 1;
                dataGridView1.Rows[i + 1].Cells[1].Value = data_list[i].CAT;
            }
        }

        public void TableCleared()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }
            

    }
}
