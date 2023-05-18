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
        public string[] ID { get; set; } = new string[3]; // ID[0]=TrackNumber, ID[1]=TargetAddress, ID[2]=TargetIdentification
        //public int TrackNumber { get; set; }
        //public string TargetAddres { get; set; }
        //public string TargetIdentification { get; set; }
        public string Mode3ACode { get; set; }
        public double? FlightLevel { get; set; }

        // SMR, MLAT or ADSB message indicator
        public bool isSMR { get; set; } = false;
        public bool isMLAT { get; set; } = false;
        public bool isADSB { get; set; } = false;


        // CONSTRUCTOR
        public TargetData()
        {

        }

    }
}
