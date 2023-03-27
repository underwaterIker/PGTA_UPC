using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Data
    {
        public string MessageType { get; set; }

        public double[] PositionWGS84Coordinates { get; set; }

        public double[] PositionCartesianCoordinates { get; set; }

        public string Mode3ACode_V { get; set; }
        public string Mode3ACode_G { get; set; }
        public string Mode3ACode_L { get; set; }
        public string Mode3ACode_Reply { get; set; }

        public string FlightLevel_V { get; set; }
        public string FlightLevel_G { get; set; }
        public double FlightLevel_FL { get; set; }

        public double[] CalculatedTrackVelocityPolarCoordinates { get; set; }

        public double[] CalculatedTrackVelocityCartesianCoordinates { get; set; }

        public double[] CalculatedAcceleration { get; set; }

        public string TargetAddress { get; set; }
    }
}
