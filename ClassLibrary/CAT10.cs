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

        private IDictionary<string, string> TartgetIdentificationSTI_dict = new Dictionary<string, string>() { { "00", "Callsign or registration downlinked from transponder" }, { "01", "Callsign not downlinked from transponder" }, { "10", "Registration not downlinked from transponder" } };
        public static IDictionary<string, string> TargetIdentificationCharacters_dict = new Dictionary<string, string>() { { "000001", "A" }, { "000010", "B" }, { "000011", "C" }, { "000100", "D" }, { "000101", "E" }, { "000110", "F" }, { "000111", "G" }, { "001000", "H" }, { "001001", "I" }, { "001010", "J" }, { "001011", "K" }, { "001100", "L" }, { "001101", "M" }, { "001110", "N" }, { "001111", "O" }, { "010000", "P" }, { "010001", "Q" }, { "010010", "R" }, { "010011", "S" }, { "010100", "T" }, { "010101", "U" }, { "010110", "V" }, { "010111", "W" }, { "011000", "X" }, { "011001", "Y" }, { "011010", "Z" }, { "100000", " " }, { "110000", "0" }, { "110001", "1" }, { "110010", "2" }, { "110011", "3" }, { "110100", "4" }, { "110101", "5" }, { "110110", "6" }, { "110111", "7" }, { "111000", "8" }, { "111001", "9" } };

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
            data.TargetIdentification_STI = TartgetIdentificationSTI_dict[octets[0].Substring(0, 2)];

            string char1 = TargetIdentificationCharacters_dict[octets[1].Substring(0, 6)];
            string char2 = TargetIdentificationCharacters_dict[octets[1].Substring(6, 2)+octets[2].Substring(0, 4)];
            string char3 = TargetIdentificationCharacters_dict[octets[2].Substring(4, 4) + octets[3].Substring(0, 2)];
            string char4 = TargetIdentificationCharacters_dict[octets[3].Substring(2, 6)];
            string char5 = TargetIdentificationCharacters_dict[octets[4].Substring(0, 6)];
            string char6 = TargetIdentificationCharacters_dict[octets[4].Substring(6, 2) + octets[5].Substring(0, 4)];
            string char7 = TargetIdentificationCharacters_dict[octets[5].Substring(4, 4) + octets[6].Substring(0, 2)];
            string char8 = TargetIdentificationCharacters_dict[octets[6].Substring(2, 6)];
            data.TargetIdentification_Characters = char1 + char2 + char3 + char4 + char5 + char6 + char7 + char8;
        }

        // Data Item I010/250, Mode S MB Data
        private void ModeSMBData(string[] octets)
        {
            double REP = Functions.Bin2Num(octets[0]);
            double MBData = Functions.Bin2Num(octets[1] + octets[2] + octets[3] + octets[4] + octets[5] + octets[6] + octets[7]);
            double BDS1 = Functions.Bin2Num(octets[8].Substring(0, 4));
            double BDS2 = Functions.Bin2Num(octets[8].Substring(4, 4));

            data.ModeSMBData_REP = REP;
            data.ModeSMBData_MBData = MBData;
            data.ModeSMBData_BDS1 = BDS1;
            data.ModeSMBData_BDS2 = BDS2;
        }

        // Data Item I010/270, Target Size & Orientation
        private void TargetSizeAndOrientation(string[] octets)
        {
            double LSB_Length = 1; // m
            double length = LSB_Length * Functions.Bin2Num(octets[0].Substring(0, 7));
            data.TargetSizeAndOrientation_Length = length;

            if (octets[0][7] == '1')
            {
                double LSB_Orientation = 360 / 128; // degrees
                double orientation = LSB_Orientation * Functions.Bin2Num(octets[1].Substring(0, 7));
                data.TargetSizeAndOrientation_Orientation = orientation;

                if (octets[1][7] == '1')
                {
                    double LSB_Width = 1; // m
                    double width = LSB_Width * Functions.Bin2Num(octets[2].Substring(0, 7));
                    data.TargetSizeAndOrientation_Width = width;
                }
            }
        }
    }
}
