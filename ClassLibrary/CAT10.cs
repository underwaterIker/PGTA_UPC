using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        // Content of the CAT10 message
        string[] message; // Maybe its useless
        
        Data data = new Data();

        // Dictionary
        private IDictionary<int, string> MessageType_dict = new Dictionary<int, string>() { { 1, "Target Report" }, { 2, "Start of Update Cycle" }, { 3, "Periodic Status Message" }, { 4, "Event-triggered Status Message" } };

        private IDictionary<char, string> Mode3ACodeV_and_FlightLevelV_dict = new Dictionary<char, string>() { { '0', "Code validated" }, { '1', "Code not validated" } };
        private IDictionary<char, string> Mode3ACodeG_and_FlightLevelG_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "Garbled code" } };
        private IDictionary<char, string> Mode3ACodeL_dict = new Dictionary<char, string>() { { '0', "Mode-3/A code derived from the reply of the transponder" }, { '1', "Mode-3/A code not extracted during the last scan" } };


        public CAT10(string[] message)
        {
            this.message = message; // Maybe its useless

            

            // Aqui dentro vamos a ir decodificando el mensaje usando las funciones que vamos
            // a crear en esta misma clase. De esta manera, cuando llamemos a esta funcion ya
            // va a quedar todo decodificado
        }

        // Data Item I010/000, Message Type
        private void MessageType(string octet1)
        {
            data.MessageType = MessageType_dict[Convert.ToInt16(octet1, 2)];
        }

        // Data Item I010/041, Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates(string[] octets)
        {
            double LSB = 180 / Math.Pow(2, 31); // degrees
            double latitude  = LSB * Functions.TwosComplement2Int(octets[0] + octets[1] + octets[2] + octets[3]);
            double longitude = LSB * Functions.TwosComplement2Int(octets[4] + octets[5] + octets[6] + octets[7]);
            data.PositionWGS84Coordinates[0] = latitude;
            data.PositionWGS84Coordinates[1] = longitude;
        }

        // Data Item I010/042, Position in Cartesian Co-ordinates
        private void PositionCartesianCoordinates(string[] octets)
        {
            double LSB = 1; // m
            double x = LSB * Functions.TwosComplement2Int(octets[0] + octets[1]);
            double y = LSB * Functions.TwosComplement2Int(octets[2] + octets[3]);
            data.PositionCartesianCoordinates[0] = x;
            data.PositionCartesianCoordinates[1] = y;
        }

        // Data Item I010/060, Mode-3/A Code in Octal Representation
        private void Mode3ACodeOctalRepresentation(string[] octets)
        {
            data.Mode3ACode_V = Mode3ACodeV_and_FlightLevelV_dict[octets[0][0]];
            data.Mode3ACode_G = Mode3ACodeG_and_FlightLevelG_dict[octets[0][1]];
            data.Mode3ACode_L = Mode3ACodeL_dict[octets[0][2]];

            string A = Functions.Bin2Num(octets[0].Substring(4, 3)).ToString();
            string B = Functions.Bin2Num(octets[0][7] + octets[1].Substring(0, 2)).ToString();
            string C = Functions.Bin2Num(octets[1].Substring(2, 3)).ToString();
            string D = Functions.Bin2Num(octets[1].Substring(5, 3)).ToString();
            data.Mode3ACode_Reply = A + B + C + D;
        }

        // Data Item I010/090, Flight Level in Binary Representation
        private void FlightLevelBinaryRepresentation(string[] octets)
        {
            data.FlightLevel_V = Mode3ACodeV_and_FlightLevelV_dict[octets[0][0]];
            data.FlightLevel_G = Mode3ACodeG_and_FlightLevelG_dict[octets[0][1]];

            double LSB = 1 / 4; // FL
            double FL = LSB * Functions.TwosComplement2Int(octets[0].Substring(2, 6) + octets[1]);
            data.FlightLevel_FL = FL;
        }

        // Data Item I010/200, Calculated Track Velocity in Polar Co-ordinates
        private void CalculatedTrackVelocityPolarCoordinates(string[] octets)
        {
            double LSB_GroundSpeed = 0.22; // kt
            double GroundSpeed = LSB_GroundSpeed * Functions.TwosComplement2Int(octets[0] + octets[1]);

            double LSB_TrackAngle = 360 / Math.Pow(2, 16); // degrees
            double TrackAngle = LSB_TrackAngle * Functions.TwosComplement2Int(octets[2] + octets[3]);

            data.CalculatedTrackVelocityPolarCoordinates[0] = GroundSpeed;
            data.CalculatedTrackVelocityPolarCoordinates[1] = TrackAngle;
        }

        // Data Item I010/202, Calculated Track Velocity in Cartesian Co-ordinates
        private void CalculatedTrackVelocityCartesianCoordinates(string[] octets)
        {
            double LSB = 0.25; // m/s
            double Vx = LSB * Functions.TwosComplement2Int(octets[0] + octets[1]);
            double Vy = LSB * Functions.TwosComplement2Int(octets[2] + octets[3]);
            data.CalculatedTrackVelocityCartesianCoordinates[0] = Vx;
            data.CalculatedTrackVelocityCartesianCoordinates[1] = Vy;
        }

        // Data Item I010/210, Calculated Acceleration
        private void CalculatedAcceleration(string[] octets)
        {
            double LSB = 0.25; // m/(s^2)
            double Ax = LSB * Functions.TwosComplement2Int(octets[0]);
            double Ay = LSB * Functions.TwosComplement2Int(octets[1]);
            data.CalculatedAcceleration[0] = Ax;
            data.CalculatedAcceleration[1] = Ay;
        }

        // Data Item I010/220, Target Address
        private void TargetAddress(string[] octets)
        {
            string TargetAddress = Functions.Bin2Hex(octets[0] + octets[1] + octets[2]);
            data.TargetAddress = TargetAddress;
        }

        // Data Item I010/245, Target Identification
        private void TargetIdentification(string[] octets)
        {

        }
    }
}
