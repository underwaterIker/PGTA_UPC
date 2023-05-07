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

    }
}
