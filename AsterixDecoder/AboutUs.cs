using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsterixDecoder
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();

            //label1
            label1.Text = "Welcome to our simulator!";
            //label 2
            label2.Text = "We are Iker and Paula";
         

            // Establecer la propiedad TextAlign a MiddleCenter
           this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {

        }
    }
}
