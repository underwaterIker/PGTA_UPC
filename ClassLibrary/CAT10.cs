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
        
        // Where the decodificated data will be stored
        public Data data = new Data();

        // DICTIONARIES
        // Data Item I010/000, Message Type
        private IDictionary<int, string> MessageType_dict = new Dictionary<int, string>() { { 1, "Target Report" }, { 2, "Start of Update Cycle" }, { 3, "Periodic Status Message" }, { 4, "Event-triggered Status Message" } };

        // Data Item I010/020, Target Report Descriptor
        private IDictionary<string, string> TargetReportDescriptor_TYP_dict = new Dictionary<string, string>() { { "000", "SSR multilateration" }, { "001", "Mode S multilateration" }, { "010", "ADS-B" }, { "011", "PSR" }, { "100", "Magnetic Loop System" }, { "101", "Not defined" }, { "111", "Other types" } };
        private IDictionary<char, string> TargetReportDescriptor_DCR_dict = new Dictionary<char, string>() { { '0', "No differential correction (ADS-B)" }, { '1', "Differential correction (ADS-B)" } };
        private IDictionary<char, string> TargetReportDescriptor_CHN_dict = new Dictionary<char, string>() { { '0', "Chain 1" }, { '1', "Chain 2" } };
        private IDictionary<char, string> TargetReportDescriptor_GBS_dict = new Dictionary<char, string>() { { '0', "Transponder Ground bit not set" }, { '1', "Transponder Ground bit set" } };
        private IDictionary<char, string> TargetReportDescriptor_CRT_dict = new Dictionary<char, string>() { { '0', "No Corrupted reply in multilateration" }, { '1', "Corrupted replies in multilateration" } };
        private IDictionary<char, string> TargetReportDescriptor_SIM_dict = new Dictionary<char, string>() { { '0', "Actual target report" }, { '1', "Simulated target report " } };
        private IDictionary<char, string> TargetReportDescriptor_TST_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "Test Target" } };
        private IDictionary<char, string> TargetReportDescriptor_RAB_dict = new Dictionary<char, string>() { { '0', "Report from target transponder" }, { '1', "Report from field monitor (fixed transponder)" } };
        private IDictionary<string, string> TargetReportDescriptor_LOP_dict = new Dictionary<string, string>() { { "00", "Undetermined" }, { "01", "Loop start" }, { "10", "Loop finish" } };
        private IDictionary<string, string> TargetReportDescriptor_TOT_dict = new Dictionary<string, string>() { { "00", "Undetermined" }, { "01", "Aircraft" }, { "10", "Ground vehicle" }, { "11", "Helicopter" } };
        private IDictionary<char, string> TargetReportDescriptor_SPI_dict = new Dictionary<char, string>() { { '0', "Absence of SPI " }, { '1', "Special Position Identification" } };

        // Data Item I010/060, Mode-3/A Code in Octal Representation and...
        // Data Item I010/090, Flight Level in Binary Representation
        private IDictionary<char, string> Mode3ACodeV_and_FlightLevelV_dict = new Dictionary<char, string>() { { '0', "Code validated" }, { '1', "Code not validated" } };
        private IDictionary<char, string> Mode3ACodeG_and_FlightLevelG_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "Garbled code" } };
        private IDictionary<char, string> Mode3ACodeL_dict = new Dictionary<char, string>() { { '0', "Mode-3/A code derived from the reply of the transponder" }, { '1', "Mode-3/A code not extracted during the last scan" } };

        // Data Item I010/170, Track Status
        private IDictionary<char, string> TrackStatus_CNF_dict = new Dictionary<char, string>() { { '0', "Confirmed track" }, { '1', "Track in initialisation phase" } };
        private IDictionary<char, string> TrackStatus_TRE_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "Last report for a track" } };
        private IDictionary<string, string> TrackStatus_CST_dict = new Dictionary<string, string>() { { "00", "No extrapolation" }, { "01", "Predictable extrapolation due to sensor refresh period" }, { "10", "Predictable extrapolation in masked area" }, { "11", "Extrapolation due to unpredictable absence of detection" } };
        private IDictionary<char, string> TrackStatus_MAH_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "Horizontal manoeuvre" } };
        private IDictionary<char, string> TrackStatus_TCC_dict = new Dictionary<char, string>() { { '0', "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied." }, { '1', "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates." } };
        private IDictionary<char, string> TrackStatus_STH_dict = new Dictionary<char, string>() { { '0', "Measured position" }, { '1', "Smoothed position" } };
        private IDictionary<string, string> TrackStatus_TOM_dict = new Dictionary<string, string>() { { "00", "Unknown type of movement" }, { "01", "Taking-off" }, { "10", "Landing" }, { "11", "Other types of movement" } };
        private IDictionary<string, string> TrackStatus_DOU_dict = new Dictionary<string, string>() { { "000", "No doubt" }, { "001", "Doubtful correlation (undetermined reason)" }, { "010", "Doubtful correlation in clutter" }, { "011", "Loss of accuracy" }, { "100", "Loss of accuracy in clutter" }, { "101", "Unstable track" }, { "110", "Previously coasted" } };
        private IDictionary<string, string> TrackStatus_MRS_dict = new Dictionary<string, string>() { { "00", "Merge or split indication undetermined" }, { "01", "Track merged by association to plot" }, { "10", "Track merged by non-association to plot" }, { "11", "Split track" } };
        private IDictionary<char, string> TrackStatus_GHO_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "Ghost track" } };

        // Data Item I010/245, Target Identification
        private IDictionary<string, string> TartgetIdentificationSTI_dict = new Dictionary<string, string>() { { "00", "Callsign or registration downlinked from transponder" }, { "01", "Callsign not downlinked from transponder" }, { "10", "Registration not downlinked from transponder" } };
        private IDictionary<string, string> TargetIdentificationCharacters_dict = new Dictionary<string, string>() { { "000001", "A" }, { "000010", "B" }, { "000011", "C" }, { "000100", "D" }, { "000101", "E" }, { "000110", "F" }, { "000111", "G" }, { "001000", "H" }, { "001001", "I" }, { "001010", "J" }, { "001011", "K" }, { "001100", "L" }, { "001101", "M" }, { "001110", "N" }, { "001111", "O" }, { "010000", "P" }, { "010001", "Q" }, { "010010", "R" }, { "010011", "S" }, { "010100", "T" }, { "010101", "U" }, { "010110", "V" }, { "010111", "W" }, { "011000", "X" }, { "011001", "Y" }, { "011010", "Z" }, { "100000", " " }, { "110000", "0" }, { "110001", "1" }, { "110010", "2" }, { "110011", "3" }, { "110100", "4" }, { "110101", "5" }, { "110110", "6" }, { "110111", "7" }, { "111000", "8" }, { "111001", "9" } };

        // Data Item I010/300, Vehicle Fleet Identification
        private IDictionary<int, string> VehicleFleetIdentification_VFI_dict = new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "ATC equipment maintenance" }, { 2, "Airport maintenance" }, { 3, "Fire" }, { 4, "Bird scarer" }, { 5, "Snow plough" }, { 6, "Runway sweeper" }, { 7, "Emergency" }, { 8, "Police" }, { 9, "Bus" }, { 10, "Tug (push/tow)" }, { 11, "Grass cutter" }, { 12, "Fuel" }, { 13, "Baggage" }, { 14, "Catering" }, { 15, "Aircraft maintenance" }, { 16, "Flyco (follow me)" } };

        // Data Item I010/310, Pre-programmed Message
        private IDictionary<char, string> PreprogrammedMessage_TRB_dict = new Dictionary<char, string>() { { '0', "Default" }, { '1', "In Trouble" } };
        private IDictionary<int, string> PreprogrammedMessage_MSG_dict = new Dictionary<int, string>() { { 1, "Towing aircraf" }, { 2, "'Follow me' operation" }, { 3, "Runway check" }, { 4, "Emergency operation (fire, medical…)" }, { 5, "Work in progress (maintenance, birds scarer, sweepers…)" } };

        // Data Item I010/550, System Status
        private IDictionary<string, string> SystemStatus_NOGO_dict = new Dictionary<string, string>() { { "00", "Operational" }, { "01", "Degraded" }, { "10", "NOGO" } };
        private IDictionary<char, string> SystemStatus_OVL_dict = new Dictionary<char, string>() { { '0', "No overload" }, { '1', "Overload" } };
        private IDictionary<char, string> SystemStatus_TSV_dict = new Dictionary<char, string>() { { '0', "valid" }, { '1', "invalid" } };
        private IDictionary<char, string> SystemStatus_DIV_dict = new Dictionary<char, string>() { { '0', "Normal Operation" }, { '1', "Diversity degraded" } };
        private IDictionary<char, string> SystemStatus_TTF_dict = new Dictionary<char, string>() { { '0', "Test Target Operative" }, { '1', "Test Target Failure" } };

        // CONSTRUCTOR
        public CAT10(string[] message)
        {
            this.message = message; // Maybe its useless


            // Aqui dentro vamos a ir decodificando el mensaje usando las funciones que vamos
            // a crear en esta misma clase. De esta manera, cuando llamemos a esta funcion ya
            // va a quedar todo decodificado
        }

        // METHODS
        // CAT10 Decodification function
        private void Decodification(string Type, string[] dataitems, int numoctet)
        {

            switch (Type)
            {
                case "MessageType":
                    //MessageType(dataitems[numoctet]);

                    break;

                case "DataSourceIdentifier":
                    DataSourceIdentifier(dataitems);

                    break;

                case "Position in Cartesian Co-ordinates":
                    //PositionCartesianCoordinates()
                    numoctet = numoctet + 3;
                    break;

                case " TargetReportDescriptor":
                    //TargetReportDescriptor();
                    numoctet = numoctet + 4;
                    break;

                case "MeasuredPositioninPolarCoordinates":
                    //MeasuredPositioninPolarCoordinates();
                    numoctet = numoctet + 5;
                    break;

                case "Position in WGS - 84 Co - ordinates":
                    //PositionWGS84Coordinates()
                    numoctet = numoctet + 6;
                    break;

                case "SystemStatusMessageType":
                    numoctet = numoctet + 7;
                    break;

                case "StandardDeviationPosition":
                    numoctet = numoctet + 8;
                    break;

                case "Mode - 3 / A Code in Octal Representation":
                    //Mode3ACodeOctalRepresentation
                    numoctet = numoctet + 9;
                    break;

                case "Flight Level in Binary Representation ":
                    //FlightLevelBinaryRepresentation
                    numoctet = numoctet + 10;
                    break;

                case "Measured Height":
                    numoctet = numoctet + 11;
                    break;

                case "AmplitudPrimayPlot":
                    numoctet = numoctet + 12;
                    break;

                case "TimeofDay":
                    numoctet = numoctet + 13;
                    break;

                case "TrackNumber":

                    break;

                case "Track Status":

                    break;

                case "Calculated Track Velocity in Polar Co-ordinates":

                    break;

                case "Calculated Track Velocity in Cartesian Co-ordinates":

                    break;

                case "Calculated Acceleration":

                    break;

                case "TargetAdress":

                    break;

                case "Target Identification":

                    break;

                case " Mode S MB Data":

                    break;

                case "Target Size & Orientation":

                    break;


                case "Presence":

                    break;

                case "VehicleFleetIdentification":

                    break;

                case "PreprogrammeMessage":

                    break;

                case "Standard Deviation of Position":


                    break;

                case " System Status":

                    break;

            }
        }

        // Data Item I010/000, Message Type
        private void MessageType(string octet1)
        {
            data.MessageType = MessageType_dict[Convert.ToInt16(octet1, 2)];
        }

        // Data Item I010/010, Data Source Identifier
        private void DataSourceIdentifier(string[] octets)
        {
            int SAC = Functions.Bin2Num(octets[0]);
            int SIC = Functions.Bin2Num(octets[1]);
            data.DataSourceIdentifier_SAC = SAC;
            data.DataSourceIdentifier_SIC = SIC;

        }

        // Data Item I010/020, Target Report Descriptor
        private void TargetReportDescriptor(string[] octets)
        {
            data.TargetReportDescriptor_TYP = TargetReportDescriptor_TYP_dict[octets[0].Substring(0, 3)];
            data.TargetReportDescriptor_DCR = TargetReportDescriptor_DCR_dict[octets[0][3]];
            data.TargetReportDescriptor_CHN = TargetReportDescriptor_CHN_dict[octets[0][4]];
            data.TargetReportDescriptor_GBS = TargetReportDescriptor_GBS_dict[octets[0][5]];
            data.TargetReportDescriptor_CRT = TargetReportDescriptor_CRT_dict[octets[0][6]];

            if (octets[0][7] == '1')
            {
                data.TargetReportDescriptor_SIM = TargetReportDescriptor_SIM_dict[octets[1][0]];
                data.TargetReportDescriptor_TST = TargetReportDescriptor_TST_dict[octets[1][1]];
                data.TargetReportDescriptor_RAB = TargetReportDescriptor_RAB_dict[octets[1][2]];
                data.TargetReportDescriptor_LOP = TargetReportDescriptor_LOP_dict[octets[1].Substring(3, 2)];
                data.TargetReportDescriptor_TOT = TargetReportDescriptor_TOT_dict[octets[1].Substring(5, 2)];

                if(octets[1][7] == '1')
                {
                    data.TargetReportDescriptor_SPI = TargetReportDescriptor_SPI_dict[octets[2][0]];
                }
            }
        }

        //Data Item I010/040, Measured Position in Polar Co-ordinates
        private void MeasuredPositioninPolarCoordinates(string[] octets)
        {
            double LSB_RHO = 1; // m
            double LSB_theta = 360 / Math.Pow(2, 16); // degrees

            double RHO = LSB_RHO * Functions.Bin2Num(octets[0] + octets[1]);
            double THETA = LSB_theta * Functions.Bin2Num(octets[2] + octets[3]);
            
            data.MeasuredPositioninPolarCoordinates_RHO = RHO;
            data.MeasuredPositioninPolarCoordinates_THETA = THETA;
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

        // Data Item I010/091, Measured Height
        private void MeasuredHeight(string[] octets)
        {
            double LSB = 6.25; // ft
            double measuredHeight = LSB * Functions.TwosComplement2Int(octets[0] + octets[1]);
            data.MeasuredHeight = measuredHeight;
        }

        //Data Item I010/131, Amplitude of Primary Plot
        private void AmplitudPrimayPlot(string octet1)
        {
            data.AmplitudPrimayPlot = Functions.Bin2Num(octet1);
        }

        // Data Item I010/140: Time of Day
        private void TimeofDay(string[] octets)
        {
            double LSB = 1 / 128; // s
            double timeOfDay = LSB * Functions.Bin2Num(octets[0] + octets[1] + octets[2]);
            data.TimeofDay = timeOfDay;
        }

        // Data Item I010/161: Track Number
        private void TrackNumber(string[] octets)
        {
            data.TrackNumber = Functions.Bin2Num(octets[0].Substring(4, 4) + octets[1]);
        }

        // Data Item I010/170, Track Status
        private void TrackStatus(string[] octets)
        {
            data.TrackStatus_CNF = TrackStatus_CNF_dict[octets[0][0]];
            data.TrackStatus_TRE = TrackStatus_TRE_dict[octets[0][1]];
            data.TrackStatus_CST = TrackStatus_CST_dict[octets[0].Substring(2, 2)];
            data.TrackStatus_MAH = TrackStatus_MAH_dict[octets[0][4]];
            data.TrackStatus_TCC = TrackStatus_TCC_dict[octets[0][5]];
            data.TrackStatus_STH = TrackStatus_STH_dict[octets[0][6]];

            if (octets[0][7] == '1')
            {
                data.TrackStatus_TOM = TrackStatus_TOM_dict[octets[1].Substring(0, 2)];
                data.TrackStatus_DOU = TrackStatus_DOU_dict[octets[1].Substring(2, 3)];
                data.TrackStatus_MRS = TrackStatus_MRS_dict[octets[1].Substring(5, 2)];

                if (octets[1][7] == '1')
                {
                    data.TrackStatus_GHO = TrackStatus_GHO_dict[octets[2][0]];
                }
            }
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

        // Data Item I010/280, Presence
        private void Presence(string[] octets)
        {
            data.Presence_REP = Functions.Bin2Num(octets[0]);

            double LSB_DRHO = 1; // m
            double LSB_DTHETA = 0.15; //degrees

            double DRHO = LSB_DRHO * Functions.Bin2Num(octets[1]);
            double DTHETA = LSB_DTHETA * Functions.Bin2Num(octets[2]);

            data.Presence_DRHO = DRHO;
            data.Presence_DTHETA = DTHETA;
        }

        // Data Item I010/300, Vehicle Fleet Identification
        private void VehicleFleetIdentification(string octet1)
        {
            data.VehicleFleetIdentification = VehicleFleetIdentification_VFI_dict[Functions.Bin2Num(octet1)];
        }

        // Data Item I010/310, Pre-programmed Message
        private void PreprogrammedMessage(string octet1)
        {
            data.PreprogrammedMessage_TRB = PreprogrammedMessage_TRB_dict[octet1[0]];
            data.PreprogrammedMessage_MSG = PreprogrammedMessage_MSG_dict[Functions.Bin2Num(octet1.Substring(1, 7))];
        }

        // Data Item I010/500, Standard Deviation of Position
        private void StandardDeviationPosition(string[] octets)
        {
            double LSB = 0.25; // m and (m^2)

            double SDx = LSB * Functions.Bin2Num(octets[0]);
            double SDy = LSB * Functions.Bin2Num(octets[1]);
            double Covariance = LSB * Functions.TwosComplement2Int(octets[2] + octets[3]);

            data.StandardDeviationPosition_SDx = SDx;
            data.StandardDeviationPosition_SDy = SDy;
            data.StandardDeviationPosition_Coveriance = Covariance;
        }

        // Data Item I010/550, System Status
        private void SystemStatusMessageType(string octet1)
        {
            string NOGO = octet1.Substring(0, 2);

            data.SystemStatusMessageType_NOGO = SystemStatus_NOGO_dict[NOGO];
            data.SystemStatusMessageType_OVL = SystemStatus_OVL_dict[octet1[2]];
            data.SystemStatusMessageType_TSV = SystemStatus_TSV_dict[octet1[3]];
            data.SystemStatusMessageType_DIV = SystemStatus_DIV_dict[octet1[4]];
            data.SystemStatusMessageType_TTF = SystemStatus_TTF_dict[octet1[5]];
        }

    }
}
