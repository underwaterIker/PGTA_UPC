using System;
using System.Collections;
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
        byte[] CAT10_message; // Maybe its useless
        
        // Where the decodificated data will be stored
        public Data data = new Data();

        // CONSTRUCTOR
        public CAT10(byte[] message)
        {
            this.CAT10_message = message; // Maybe its useless


            // Aqui dentro vamos a ir decodificando el mensaje usando las funciones que vamos
            // a crear en esta misma clase. De esta manera, cuando llamemos a esta funcion ya
            // va a quedar todo decodificado
        }

        public CAT10() { }

        
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
                    //DataSourceIdentifier(dataitems);

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
        private void MessageType(byte octet1)
        {
            data.MessageType = CAT10_dict.MessageType_dict[octet1];
        }

        // Data Item I010/010, Data Source Identifier
        private void DataSourceIdentifier(byte[] octets)
        {
            //int SAC = octets[0];
            //int SIC = octets[1];
            data.DataSourceIdentifier_SAC = octets[0];
            data.DataSourceIdentifier_SIC = octets[1];
        }

        // Data Item I010/020, Target Report Descriptor
        private void TargetReportDescriptor(byte[] octets)
        {
            BitArray bits = new BitArray(octets);
            
            string TYP_boolString = bits[7].ToString() + bits[6] + bits[5];
            data.TargetReportDescriptor_TYP = CAT10_dict.TargetReportDescriptor_TYP_dict[TYP_boolString];
            data.TargetReportDescriptor_DCR = CAT10_dict.TargetReportDescriptor_DCR_dict[bits[4]];
            data.TargetReportDescriptor_CHN = CAT10_dict.TargetReportDescriptor_CHN_dict[bits[3]];
            data.TargetReportDescriptor_GBS = CAT10_dict.TargetReportDescriptor_GBS_dict[bits[2]];
            data.TargetReportDescriptor_CRT = CAT10_dict.TargetReportDescriptor_CRT_dict[bits[1]];

            if (bits[0] == true)
            {
                data.TargetReportDescriptor_SIM = CAT10_dict.TargetReportDescriptor_SIM_dict[bits[15]];
                data.TargetReportDescriptor_TST = CAT10_dict.TargetReportDescriptor_TST_dict[bits[14]];
                data.TargetReportDescriptor_RAB = CAT10_dict.TargetReportDescriptor_RAB_dict[bits[13]];
                string LOP_boolString = bits[12].ToString() + bits[11];
                data.TargetReportDescriptor_LOP = CAT10_dict.TargetReportDescriptor_LOP_dict[LOP_boolString];
                string TOT_boolString = bits[10].ToString() + bits[9];
                data.TargetReportDescriptor_TOT = CAT10_dict.TargetReportDescriptor_TOT_dict[TOT_boolString];

                if(bits[8] == true)
                {
                    data.TargetReportDescriptor_SPI = CAT10_dict.TargetReportDescriptor_SPI_dict[bits[23]];
                }
            }
        }

        //Data Item I010/040, Measured Position in Polar Co-ordinates
        private void MeasuredPositioninPolarCoordinates(byte[] octets)
        {
            double LSB_RHO = 1; // m
            double LSB_theta = 360 / Math.Pow(2, 16); // degrees

            byte[] RHO_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] THETA_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double RHO = LSB_RHO * Functions.CombineBytes2Int(RHO_bytes);
            double THETA = LSB_theta * Functions.CombineBytes2Int(THETA_bytes);
            
            data.MeasuredPositioninPolarCoordinates_RHO = RHO;
            data.MeasuredPositioninPolarCoordinates_THETA = THETA;
        }

        // Data Item I010/041, Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates(byte[] octets)
        {
            double LSB = 180 / Math.Pow(2, 31); // degrees

            byte[] latitude_bytes = new byte[4] { octets[3], octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitude_bytes = new byte[4] { octets[7], octets[6], octets[5], octets[4] }; // Reversed

            double latitude  = LSB * Functions.TwosComplement2Int_fromBytes(latitude_bytes);
            double longitude = LSB * Functions.TwosComplement2Int_fromBytes(longitude_bytes);

            data.PositionWGS84Coordinates[0] = latitude;
            data.PositionWGS84Coordinates[1] = longitude;
        }

        // Data Item I010/042, Position in Cartesian Co-ordinates
        private void PositionCartesianCoordinates(byte[] octets)
        {
            double LSB = 1; // m

            byte[] x_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] y_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double x = LSB * Functions.TwosComplement2Int_fromBytes(x_bytes);
            double y = LSB * Functions.TwosComplement2Int_fromBytes(y_bytes);

            data.PositionCartesianCoordinates[0] = x;
            data.PositionCartesianCoordinates[1] = y;
        }

        // Data Item I010/060, Mode-3/A Code in Octal Representation
        private void Mode3ACodeOctalRepresentation(byte[] octets)
        {
            octets.Reverse();
            BitArray bits = new BitArray(octets);

            // BE CAREFUL WITH BITS AND BYTES ORDER !!!!!!!!!
            data.Mode3ACode_V = CAT10_dict.Mode3ACodeV_and_FlightLevelV_dict[bits[15]];
            data.Mode3ACode_G = CAT10_dict.Mode3ACodeG_and_FlightLevelG_dict[bits[14]];
            data.Mode3ACode_L = CAT10_dict.Mode3ACodeL_dict[bits[13]];

            // We create BitArrays for A, B, C & D and fill them with the corresponding bits
            BitArray bits_A = new BitArray(3);
            BitArray bits_B = new BitArray(3);
            BitArray bits_C = new BitArray(3);
            BitArray bits_D = new BitArray(3);
            for (int i = 0; i < 3; i++)
            {
                bits_A[i] = bits[9 + i];
                bits_B[i] = bits[6 + i];
                bits_C[i] = bits[3 + i];
                bits_D[i] = bits[i];
            }

            // We convert the BitArrays to a number, and then to string
            string A = Functions.BitArray2Int(bits_A).ToString();
            string B = Functions.BitArray2Int(bits_B).ToString();
            string C = Functions.BitArray2Int(bits_C).ToString();
            string D = Functions.BitArray2Int(bits_D).ToString();

            data.Mode3ACode_Reply = A + B + C + D;
        }

        // Data Item I010/090, Flight Level in Binary Representation
        private void FlightLevelBinaryRepresentation(byte[] octets)
        {
            octets.Reverse();
            BitArray bits = new BitArray(octets);

            data.FlightLevel_V = CAT10_dict.Mode3ACodeV_and_FlightLevelV_dict[bits[15]];
            data.FlightLevel_G = CAT10_dict.Mode3ACodeG_and_FlightLevelG_dict[bits[14]];

            bits.Length = bits.Length - 2;

            double LSB = 1 / 4; // FL
            double FL = LSB * Functions.TwosComplement2Int_fromBitArray(bits);
            data.FlightLevel_FL = FL;
        }

        // Data Item I010/091, Measured Height
        private void MeasuredHeight(byte[] octets)
        {
            double LSB = 6.25; // ft

            byte[] measuredHeight_bytes = new byte[2] { octets[1], octets[0] }; // Reversed

            double measuredHeight = LSB * Functions.TwosComplement2Int_fromBytes(measuredHeight_bytes);
            data.MeasuredHeight = measuredHeight;
        }

        //Data Item I010/131, Amplitude of Primary Plot
        private void AmplitudePrimayPlot(byte octet1)
        {
            data.AmplitudePrimayPlot = octet1;
        }

        // Data Item I010/140: Time of Day
        private void TimeofDay(byte[] octets)
        {
            octets.Reverse();

            double LSB = 1 / 128; // s
            double timeOfDay = LSB * Functions.CombineBytes2Int(octets);
            data.TimeofDay = timeOfDay;
        }

        // Data Item I010/161: Track Number
        private void TrackNumber(byte[] octets)
        {
            octets.Reverse();

            data.TrackNumber = Functions.CombineBytes2Int(octets);
        }

        // Data Item I010/170, Track Status
        private void TrackStatus(byte[] octets)
        {
            BitArray bits = new BitArray(octets);

            data.TrackStatus_CNF = CAT10_dict.TrackStatus_CNF_dict[bits[7]];
            data.TrackStatus_TRE = CAT10_dict.TrackStatus_TRE_dict[bits[6]];
            string CST_boolString = bits[5].ToString() + bits[4];
            data.TrackStatus_CST = CAT10_dict.TrackStatus_CST_dict[CST_boolString];
            data.TrackStatus_MAH = CAT10_dict.TrackStatus_MAH_dict[bits[3]];
            data.TrackStatus_TCC = CAT10_dict.TrackStatus_TCC_dict[bits[2]];
            data.TrackStatus_STH = CAT10_dict.TrackStatus_STH_dict[bits[1]];

            if (bits[0] == true)
            {
                string TOM_boolString = bits[15].ToString() + bits[14];
                data.TrackStatus_TOM = CAT10_dict.TrackStatus_TOM_dict[TOM_boolString];
                string DOU_boolString = bits[13].ToString() + bits[12] + bits[11];
                data.TrackStatus_DOU = CAT10_dict.TrackStatus_DOU_dict[DOU_boolString];
                string MRS_boolString = bits[10].ToString() + bits[9];
                data.TrackStatus_MRS = CAT10_dict.TrackStatus_MRS_dict[MRS_boolString];

                if (bits[8] == true)
                {
                    data.TrackStatus_GHO = CAT10_dict.TrackStatus_GHO_dict[bits[23]];
                }
            }
        }

        // Data Item I010/200, Calculated Track Velocity in Polar Co-ordinates
        private void CalculatedTrackVelocityPolarCoordinates(byte[] octets)
        {
            double LSB_GroundSpeed = 0.22; // kt
            double LSB_TrackAngle = 360 / Math.Pow(2, 16); // degrees

            byte[] GroundSpeed_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] TrackAngle_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double GroundSpeed = LSB_GroundSpeed * Functions.TwosComplement2Int_fromBytes(GroundSpeed_bytes);
            double TrackAngle = LSB_TrackAngle * Functions.TwosComplement2Int_fromBytes(TrackAngle_bytes);

            data.CalculatedTrackVelocityPolarCoordinates[0] = GroundSpeed;
            data.CalculatedTrackVelocityPolarCoordinates[1] = TrackAngle;
        }

        // Data Item I010/202, Calculated Track Velocity in Cartesian Co-ordinates
        private void CalculatedTrackVelocityCartesianCoordinates(byte[] octets)
        {
            double LSB = 0.25; // m/s

            byte[] Vx_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] Vy_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double Vx = LSB * Functions.TwosComplement2Int_fromBytes(Vx_bytes);
            double Vy = LSB * Functions.TwosComplement2Int_fromBytes(Vy_bytes);

            data.CalculatedTrackVelocityCartesianCoordinates[0] = Vx;
            data.CalculatedTrackVelocityCartesianCoordinates[1] = Vy;
        }

        // Data Item I010/210, Calculated Acceleration
        private void CalculatedAcceleration(byte[] octets)
        {
            double LSB = 0.25; // m/(s^2)

            byte[] Ax_bytes = new byte[1] { octets[0] }; // Reversed (no need to reverse, array of length 1)
            byte[] Ay_bytes = new byte[1] { octets[1] }; // Reversed (no need to reverse, array of length 1)

            double Ax = LSB * Functions.TwosComplement2Int_fromBytes(Ax_bytes);
            double Ay = LSB * Functions.TwosComplement2Int_fromBytes(Ay_bytes);

            data.CalculatedAcceleration[0] = Ax;
            data.CalculatedAcceleration[1] = Ay;
        }

        // Data Item I010/220, Target Address
        private void TargetAddress(byte[] octets)
        {
            byte[] TargetAddress_bytes = new byte[3] { octets[2], octets[1], octets[0] }; // Reversed

            int TargetAddress_int = Functions.CombineBytes2Int(TargetAddress_bytes);
            string TargetAddress = TargetAddress_int.ToString("X");

            data.TargetAddress = TargetAddress;
        }

        // Data Item I010/245, Target Identification
        private void TargetIdentification(byte[] octets)
        {
            octets.Reverse();
            BitArray bits = new BitArray(octets);

            // Characters
            BitArray char8_bits = new BitArray(6);
            BitArray char7_bits = new BitArray(6);
            BitArray char6_bits = new BitArray(6);
            BitArray char5_bits = new BitArray(6);
            BitArray char4_bits = new BitArray(6);
            BitArray char3_bits = new BitArray(6);
            BitArray char2_bits = new BitArray(6);
            BitArray char1_bits = new BitArray(6);

            for (int i=0; i<bits.Length-8; i++)
            {
                if (i < 6)
                {
                    char8_bits[i] = bits[i];
                }
                if (i >= 6 && i < 12)
                {
                    char7_bits[i] = bits[i];
                }
                if (i >= 12 && i < 18)
                {
                    char6_bits[i] = bits[i];
                }
                if (i >= 18 && i < 24)
                {
                    char5_bits[i] = bits[i];
                }
                if (i >= 24 && i < 30)
                {
                    char4_bits[i] = bits[i];
                }
                if (i >= 30 && i < 36)
                {
                    char3_bits[i] = bits[i];
                }
                if (i >= 36 && i < 42)
                {
                    char2_bits[i] = bits[i];
                }
                if (i >= 42 && i < 48)
                {
                    char1_bits[i] = bits[i];
                }
            }

            int char8_int = Functions.BitArray2Int(char8_bits);
            int char7_int = Functions.BitArray2Int(char7_bits);
            int char6_int = Functions.BitArray2Int(char6_bits);
            int char5_int = Functions.BitArray2Int(char5_bits);
            int char4_int = Functions.BitArray2Int(char4_bits);
            int char3_int = Functions.BitArray2Int(char3_bits);
            int char2_int = Functions.BitArray2Int(char2_bits);
            int char1_int = Functions.BitArray2Int(char1_bits);

            string char8 = CAT10_dict.TargetIdentificationCharacters_dict[char8_int];
            string char7 = CAT10_dict.TargetIdentificationCharacters_dict[char7_int];
            string char6 = CAT10_dict.TargetIdentificationCharacters_dict[char6_int];
            string char5 = CAT10_dict.TargetIdentificationCharacters_dict[char5_int];
            string char4 = CAT10_dict.TargetIdentificationCharacters_dict[char4_int];
            string char3 = CAT10_dict.TargetIdentificationCharacters_dict[char3_int];
            string char2 = CAT10_dict.TargetIdentificationCharacters_dict[char2_int];
            string char1 = CAT10_dict.TargetIdentificationCharacters_dict[char1_int];

            data.TargetIdentification_Characters = char1 + char2 + char3 + char4 + char5 + char6 + char7 + char8;

            // STI
            BitArray STI_bits = new BitArray(octets[6]);

            string STI_boolString = STI_bits[7].ToString() + STI_bits[6];

            data.TargetIdentification_STI = CAT10_dict.TartgetIdentificationSTI_dict[STI_boolString];
        }

        // Data Item I010/250, Mode S MB Data
        private void ModeSMBData(byte[] octets)
        {
            int REP = octets[0];
            data.ModeSMBData_REP = REP; // maybe it is not necessary to save REP in Data

            for(int i = 0; i < 1+REP; i++)
            {
                byte[] MBData_bytes = new byte[7] { octets[8*i + 7], octets[8*i + 6], octets[8*i + 5], octets[8*i + 4], octets[8*i + 3], octets[8*i + 2], octets[8*i + 1] }; // Reversed

                BitArray BDS_bits = new BitArray(octets[8*i + 8]);

                BitArray BDS1_bits = new BitArray(4);
                BDS1_bits[0] = BDS_bits[4];
                BDS1_bits[1] = BDS_bits[5];
                BDS1_bits[2] = BDS_bits[6];
                BDS1_bits[3] = BDS_bits[7];

                BitArray BDS2_bits = new BitArray(4);
                BDS2_bits[0] = BDS_bits[0];
                BDS2_bits[1] = BDS_bits[1];
                BDS2_bits[2] = BDS_bits[2];
                BDS2_bits[3] = BDS_bits[3];

                int MBData = Functions.CombineBytes2Int(MBData_bytes);
                int BDS1 = Functions.BitArray2Int(BDS1_bits);
                int BDS2 = Functions.BitArray2Int(BDS2_bits);

                data.ModeSMBData_MBData[i] = MBData;
                data.ModeSMBData_BDS1[i] = BDS1;
                data.ModeSMBData_BDS2[i] = BDS2;
            }
        }

        // Data Item I010/270, Target Size & Orientation
        private void TargetSizeAndOrientation(byte[] octets)
        {
            BitArray bits = new BitArray(octets);

            BitArray Length_bits = new BitArray(7);
            BitArray Orientation_bits = new BitArray(7);
            BitArray Width_bits = new BitArray(7);

            for (int i = 0; i < 7; i++)
            {
                Length_bits[i] = bits[i+1];
                if (bits[0] == true)
                {
                    Orientation_bits[i] = bits[i + 9];
                    if (bits[8] == true)
                    {
                        Width_bits[i] = bits[i + 17];
                    }
                }
            }

            // Length
            int LSB_Length = 1; // m
            int Length = LSB_Length * Functions.BitArray2Int(Length_bits);
            data.TargetSizeAndOrientation_Length = Length;

            if (bits[0] == true)
            {
                // Orientation
                double LSB_Orientation = 360 / 128; // degrees
                double orientation = LSB_Orientation * Functions.BitArray2Int(Orientation_bits);
                data.TargetSizeAndOrientation_Orientation = orientation;

                if (bits[8] == true)
                {
                    // Width
                    int LSB_Width = 1; // m
                    int width = LSB_Width * Functions.BitArray2Int(Width_bits);
                    data.TargetSizeAndOrientation_Width = width;
                }
            }
        }

        // Data Item I010/280, Presence
        private void Presence(byte[] octets)
        {
            int REP = octets[0];
            data.Presence_REP = REP; // maybe it is not necessary to save REP in Data

            int LSB_DRHO = 1; // m
            double LSB_DTHETA = 0.15; //degrees

            for (int i = 0; i < 1 + REP; i++)
            {
                int DRHO = LSB_DRHO * octets[2*i + 1];
                double DTHETA = LSB_DTHETA * octets[2*i +2];

                data.Presence_DRHO[i] = DRHO;
                data.Presence_DTHETA[i] = DTHETA;
            }
        }

        // Data Item I010/300, Vehicle Fleet Identification
        private void VehicleFleetIdentification(byte octet1)
        {
            data.VehicleFleetIdentification = CAT10_dict.VehicleFleetIdentification_VFI_dict[octet1];
        }

        // Data Item I010/310, Pre-programmed Message
        private void PreprogrammedMessage(byte octet1)
        {
            BitArray bits = new BitArray(octet1);

            data.PreprogrammedMessage_TRB = CAT10_dict.PreprogrammedMessage_TRB_dict[bits[7]];

            //bits.Length = bits.Length - 1;
            bits[7] = false;

            data.PreprogrammedMessage_MSG = CAT10_dict.PreprogrammedMessage_MSG_dict[Functions.BitArray2Int(bits)];
        }

        // Data Item I010/500, Standard Deviation of Position
        private void StandardDeviationPosition(byte[] octets)
        {
            double LSB = 0.25; // m and (m^2)

            byte[] Covariance_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double SDx = LSB * octets[0];
            double SDy = LSB * octets[1];
            double Covariance = LSB * Functions.TwosComplement2Int_fromBytes(Covariance_bytes);

            data.StandardDeviationPosition_SDx = SDx;
            data.StandardDeviationPosition_SDy = SDy;
            data.StandardDeviationPosition_Coveriance = Covariance;
        }

        // Data Item I010/550, System Status
        private void SystemStatusMessageType(byte octet1)
        {
            BitArray bits = new BitArray(octet1);

            string NOGO_boolString = bits[7].ToString() + bits[6];
            data.SystemStatusMessageType_NOGO = CAT10_dict.SystemStatus_NOGO_dict[NOGO_boolString];
            data.SystemStatusMessageType_OVL = CAT10_dict.SystemStatus_OVL_dict[bits[5]];
            data.SystemStatusMessageType_TSV = CAT10_dict.SystemStatus_TSV_dict[bits[4]];
            data.SystemStatusMessageType_DIV = CAT10_dict.SystemStatus_DIV_dict[bits[3]];
            data.SystemStatusMessageType_TTF = CAT10_dict.SystemStatus_TTF_dict[bits[2]];
        }
        
    }
}
