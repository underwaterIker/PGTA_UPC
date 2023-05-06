using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class TargetData
    {
        // ATTRIBUTES
        public string Time { get; set; }
        public double[] Position { get; set; }
        public List<string> ID { get; set; } = new List<string>();
        //public int TrackNumber { get; set; }
        //public string TargetAddres { get; set; }
        //public string TargetIdentification { get; set; }
        public string Mode3ACode { get; set; }
        public double FlightLevel { get; set; }

        // SMR, MLAT or ADSB message indicator
        public bool isSMR = false;
        public bool isMLAT = false;
        public bool isADSB = false;


        // CONSTRUCTOR
        public TargetData()
        {

        }


        // ATTRIBUTES
        //Bitmap Bmpaircrafts = (Bitmap)Image.FromFile(@"C:\Users\paula\Desktop\CODIGO3\Aircraft.png");

        //public double Lat { get; set; }
        //public double cat { get; set; }
        //public string ID { get; set; }
        //public double Long { get; set; }
        //public double height { get; set; }
        //public double groundSpeed { get; set; }
        //public double FL { get; set; }
        //public double TrackStatus { get; set; }
        //public double TimeOftheDay { get; set; }
        //public double Mode3A { get; set; }

        //public Bitmap Bitmap { get; set; }


        // CONSTRUCTOR
        /*
        public TargetData(string ID, double longitude, double latitude, double height, string t, double groundSpeed, double FL, double trackNumber, double cat)
        {
            this.ID = ID;
            this.Bitmap = new Bitmap(Bmpaircrafts, new Size(32, 32));
            this.Lat = latitude;
            this.Long = longitude;
            this.height = height;
            this.cat = cat;
        }
        */


    }
}
