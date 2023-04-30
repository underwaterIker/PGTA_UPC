using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        public Loading(string displayMessage)
        {
            InitializeComponent();
            label1.Text = displayMessage;
        }
    }
}
