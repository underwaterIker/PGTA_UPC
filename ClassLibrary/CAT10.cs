using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        // Content of the CAT10 message
        byte[] message { get; set; } // Maybe its useless

        // Bytes of the FSPEC
        public byte[] FSPEC_bytes { get; set; }

        // Where the decodificated data will be stored
        public CAT10_Data data = new CAT10_Data();


        // CONSTRUCTOR
        public CAT10(byte[] message)
        {
            this.message = message; // Maybe its useless

            Decodification(message);
        }

        
        // METHODS
        // CAT10 Decodification function
        private void Decodification(byte[] message)
        {
            byte[] uncertain_FSPEC_bytes = new byte[4] { message[0], message[1], message[2], message[3] };
            byte[] FSPEC_bytes = FSPEC(uncertain_FSPEC_bytes);

            // We can start decoding
            int byteSum_index = FSPEC_bytes.Length; // Index inside the byte[] message

            for (int i = 0; i < FSPEC_bytes.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        BitArray FSPEC_byte1_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte1_bits[7] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            DataSourceIdentifier(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte1_bits[6] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            MessageType(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte1_bits[5] == true)
                        {
                            byte[] bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 3)
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            }

                            int numBytes = TargetReportDescriptor(bytes);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte1_bits[4] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TimeofDay(bytes);
                            byteSum_index += 3;
                        }
                        if (FSPEC_byte1_bits[3] == true)
                        {
                            byte[] bytes = new byte[8] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5], message[byteSum_index + 6], message[byteSum_index + 7] };
                            PositionWGS84Coordinates(bytes);
                            byteSum_index += 8;
                        }
                        if (FSPEC_byte1_bits[2] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            MeasuredPositionPolarCoordinates(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte1_bits[1] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            PositionCartesianCoordinates(bytes);
                            byteSum_index += 4;
                        }

                        break;

                    case 1:
                        BitArray FSPEC_byte2_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte2_bits[7] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            CalculatedTrackVelocityPolarCoordinates(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte2_bits[6] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            CalculatedTrackVelocityCartesianCoordinates(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte2_bits[5] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            TrackNumber(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte2_bits[4] == true)
                        {
                            byte[] bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 3)
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index+j];
                                }
                            }
                            else
                            {
                                bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            }
                            
                            int numBytes = TrackStatus(bytes);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte2_bits[3] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            Mode3ACodeOctalRepresentation(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte2_bits[2] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TargetAddress(bytes);
                            byteSum_index += 3;
                        }
                        if (FSPEC_byte2_bits[1] == true)
                        {
                            byte[] bytes = new byte[7] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5], message[byteSum_index + 6] };
                            TargetIdentification(bytes);
                            byteSum_index += 7;
                        }

                        break;

                    case 2:
                        BitArray FSPEC_byte3_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte3_bits[7] == true)
                        {
                            int REP = message[byteSum_index];
                            byteSum_index += 1;
                            int numberOfBytes = REP * 8;
                            byte[] bytes = new byte[numberOfBytes];
                            for (int j = 0; j < numberOfBytes; j++)
                            {
                                bytes[j] = message[byteSum_index + j];
                            }
                            ModeSMBData(bytes, REP);
                            byteSum_index += numberOfBytes;
                        }
                        if (FSPEC_byte3_bits[6] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            VehicleFleetIdentification(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte3_bits[5] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            FlightLevelBinaryRepresentation(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte3_bits[4] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            MeasuredHeight(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte3_bits[3] == true)
                        {
                            byte[] bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 3)
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            }

                            int numBytes = TargetSizeAndOrientation(bytes);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte3_bits[2] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            SystemStatus(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte3_bits[1] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            PreprogrammedMessage(byte1);
                            byteSum_index += 1;
                        }

                        break;

                    case 3:
                        BitArray FSPEC_byte4_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte4_bits[7] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            StandardDeviationPosition(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte4_bits[6] == true)
                        {
                            int REP = message[byteSum_index];
                            byteSum_index += 1;
                            int numberOfBytes = REP * 2;
                            byte[] bytes = new byte[numberOfBytes];
                            for (i = 0; i < numberOfBytes; i++)
                            {
                                bytes[i] = message[byteSum_index + i];
                            }
                            Presence(bytes, REP);
                            byteSum_index += numberOfBytes;
                        }
                        if (FSPEC_byte4_bits[5] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            AmplitudePrimayPlot(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte4_bits[4] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            CalculatedAcceleration(bytes);
                            byteSum_index += 2;
                        }

                        break;
                }
            }
        }

        // FSPEC, returns a byte array with the bytes of the FSPEC
        private byte[] FSPEC(byte[] octets)
        {
            // Calculate the number of bytes that the FSPEC has
            int FSPEC_numberOfBytes = 1;
            for (int i = 0; i < 4; i++)
            {
                BitArray FSPEC_1byte_bits = new BitArray(new byte[1] { octets[i] });
                if (FSPEC_1byte_bits[0] == true)
                {
                    FSPEC_numberOfBytes += 1;
                }
                else
                {
                    break;
                }
            }

            // Makes the byte array of FSPEC
            byte[] FSPEC_bytes = new byte[FSPEC_numberOfBytes];
            for (int i = 0; i < FSPEC_numberOfBytes; i++)
            {
                FSPEC_bytes[i] = octets[i];
            }
            this.FSPEC_bytes = FSPEC_bytes;

            return FSPEC_bytes;
        }

        // Data Item I010/000, Message Type
        private void MessageType(byte octet1)
        {
            data.MessageType = CAT10_Dict.MessageType_dict[octet1];
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
        private int TargetReportDescriptor(byte[] octets)
        {
            BitArray bits = new BitArray(octets);

            BitArray TYP_bits = new BitArray(3);
            TYP_bits[0] = bits[5];
            TYP_bits[1] = bits[6];
            TYP_bits[2] = bits[7];
            int TYP_int = Functions.BitArray2Int(TYP_bits);

            data.TargetReportDescriptor_TYP = CAT10_Dict.TargetReportDescriptor_TYP_dict[TYP_int];
            data.TargetReportDescriptor_DCR = CAT10_Dict.TargetReportDescriptor_DCR_dict[bits[4]];
            data.TargetReportDescriptor_CHN = CAT10_Dict.TargetReportDescriptor_CHN_dict[bits[3]];
            data.TargetReportDescriptor_GBS = CAT10_Dict.TargetReportDescriptor_GBS_dict[bits[2]];
            data.TargetReportDescriptor_CRT = CAT10_Dict.TargetReportDescriptor_CRT_dict[bits[1]];

            if (bits[0] == true)
            {
                data.TargetReportDescriptor_FirstExtent_flag = true;

                BitArray LOP_bits = new BitArray(2);
                LOP_bits[0] = bits[11];
                LOP_bits[1] = bits[12];
                int LOP_int = Functions.BitArray2Int(LOP_bits);

                BitArray TOT_bits = new BitArray(2);
                TOT_bits[0] = bits[9];
                TOT_bits[1] = bits[10];
                int TOT_int = Functions.BitArray2Int(TOT_bits);

                data.TargetReportDescriptor_SIM = CAT10_Dict.TargetReportDescriptor_SIM_dict[bits[15]];
                data.TargetReportDescriptor_TST = CAT10_Dict.TargetReportDescriptor_TST_dict[bits[14]];
                data.TargetReportDescriptor_RAB = CAT10_Dict.TargetReportDescriptor_RAB_dict[bits[13]];
                data.TargetReportDescriptor_LOP = CAT10_Dict.TargetReportDescriptor_LOP_dict[LOP_int];
                data.TargetReportDescriptor_TOT = CAT10_Dict.TargetReportDescriptor_TOT_dict[TOT_int];

                if(bits[8] == true)
                {
                    data.TargetReportDescriptor_SecondExtent_flag = true;

                    data.TargetReportDescriptor_SPI = CAT10_Dict.TargetReportDescriptor_SPI_dict[bits[23]];
                    return 3;
                }
                return 2;
            }
            return 1;
        }

        //Data Item I010/040, Measured Position in Polar Co-ordinates
        private void MeasuredPositionPolarCoordinates(byte[] octets)
        {
            double LSB_RHO = 1; // m
            double LSB_theta = (double)(360 / Math.Pow(2, 16)); // degrees

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
            double LSB = (double)(180 / Math.Pow(2, 31)); // degrees

            byte[] latitude_bytes = new byte[4] { octets[3], octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitude_bytes = new byte[4] { octets[7], octets[6], octets[5], octets[4] }; // Reversed

            double latitude  = LSB * Functions.TwosComplement2Int_fromBytes(latitude_bytes);
            double longitude = LSB * Functions.TwosComplement2Int_fromBytes(longitude_bytes);

            data.PositionWGS84Coordinates_Latitude = latitude;
            data.PositionWGS84Coordinates_Longitude = longitude;
        }

        // Data Item I010/042, Position in Cartesian Co-ordinates
        private void PositionCartesianCoordinates(byte[] octets)
        {
            double LSB = 1; // m

            byte[] x_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] y_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double x = LSB * Functions.TwosComplement2Int_fromBytes(x_bytes);
            double y = LSB * Functions.TwosComplement2Int_fromBytes(y_bytes);

            data.PositionCartesianCoordinates_x = x;
            data.PositionCartesianCoordinates_y = y;
        }

        // Data Item I010/060, Mode-3/A Code in Octal Representation
        private void Mode3ACodeOctalRepresentation(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // BE CAREFUL WITH BITS AND BYTES ORDER !!!!!!!!!
            data.Mode3ACode_V = CAT10_Dict.Mode3ACodeV_and_FlightLevelV_dict[bits[15]];
            data.Mode3ACode_G = CAT10_Dict.Mode3ACodeG_and_FlightLevelG_dict[bits[14]];
            data.Mode3ACode_L = CAT10_Dict.Mode3ACodeL_dict[bits[13]];

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
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            data.FlightLevel_V = CAT10_Dict.Mode3ACodeV_and_FlightLevelV_dict[bits[15]];
            data.FlightLevel_G = CAT10_Dict.Mode3ACodeG_and_FlightLevelG_dict[bits[14]];

            bits.Length = bits.Length - 2;

            double LSB = (double)1 / 4; // FL
            double FL = LSB * Functions.TwosComplement2Int_fromBitArray(bits);
            data.FlightLevel_FL = FL;
        }

        // Data Item I010/091, Measured Height
        private void MeasuredHeight(byte[] octets)
        {
            double LSB = (double)6.25; // ft

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
            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfDay = LSB * Functions.CombineBytes2Int(octets);

            data.TimeOfDay = timeOfDay;
        }

        // Data Item I010/161: Track Number
        private void TrackNumber(byte[] octets)
        {
            Array.Reverse(octets);

            data.TrackNumber = Functions.CombineBytes2Int(octets);
        }

        // Data Item I010/170, Track Status
        private int TrackStatus(byte[] octets)
        {
            BitArray bits = new BitArray(octets);

            BitArray CST_bits = new BitArray(2);
            CST_bits[0] = bits[4];
            CST_bits[1] = bits[5];
            int CST_int = Functions.BitArray2Int(CST_bits);

            data.TrackStatus_CNF = CAT10_Dict.TrackStatus_CNF_dict[bits[7]];
            data.TrackStatus_TRE = CAT10_Dict.TrackStatus_TRE_dict[bits[6]];
            data.TrackStatus_CST = CAT10_Dict.TrackStatus_CST_dict[CST_int];
            data.TrackStatus_MAH = CAT10_Dict.TrackStatus_MAH_dict[bits[3]];
            data.TrackStatus_TCC = CAT10_Dict.TrackStatus_TCC_dict[bits[2]];
            data.TrackStatus_STH = CAT10_Dict.TrackStatus_STH_dict[bits[1]];

            if (bits[0] == true)
            {
                data.TrackStatus_FirstExtent_flag = true;

                BitArray TOM_bits = new BitArray(2);
                TOM_bits[0] = bits[14];
                TOM_bits[1] = bits[15];
                int TOM_int = Functions.BitArray2Int(TOM_bits);

                BitArray DOU_bits = new BitArray(3);
                DOU_bits[0] = bits[11];
                DOU_bits[1] = bits[12];
                DOU_bits[2] = bits[13];
                int DOU_int = Functions.BitArray2Int(DOU_bits);

                BitArray MRS_bits = new BitArray(2);
                MRS_bits[0] = bits[9];
                MRS_bits[1] = bits[10];
                int MRS_int = Functions.BitArray2Int(MRS_bits);

                data.TrackStatus_TOM = CAT10_Dict.TrackStatus_TOM_dict[TOM_int];
                data.TrackStatus_DOU = CAT10_Dict.TrackStatus_DOU_dict[DOU_int];
                data.TrackStatus_MRS = CAT10_Dict.TrackStatus_MRS_dict[MRS_int];

                if (bits[8] == true)
                {
                    data.TrackStatus_SecondExtent_flag = true;

                    data.TrackStatus_GHO = CAT10_Dict.TrackStatus_GHO_dict[bits[23]];
                    return 3;
                }
                return 2;
            }
            return 1;
        }

        // Data Item I010/200, Calculated Track Velocity in Polar Co-ordinates
        private void CalculatedTrackVelocityPolarCoordinates(byte[] octets)
        {
            double LSB_GroundSpeed = (double)0.22; // kt
            double LSB_TrackAngle = (double)(360 / Math.Pow(2, 16)); // degrees

            byte[] GroundSpeed_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] TrackAngle_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double GroundSpeed = LSB_GroundSpeed * Functions.TwosComplement2Int_fromBytes(GroundSpeed_bytes);
            double TrackAngle = LSB_TrackAngle * Functions.TwosComplement2Int_fromBytes(TrackAngle_bytes);

            data.CalculatedTrackVelocityPolarCoordinates_GroundSpeed = GroundSpeed;
            data.CalculatedTrackVelocityPolarCoordinates_TrackAngle = TrackAngle;
        }

        // Data Item I010/202, Calculated Track Velocity in Cartesian Co-ordinates
        private void CalculatedTrackVelocityCartesianCoordinates(byte[] octets)
        {
            double LSB = (double)0.25; // m/s

            byte[] Vx_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] Vy_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double Vx = LSB * Functions.TwosComplement2Int_fromBytes(Vx_bytes);
            double Vy = LSB * Functions.TwosComplement2Int_fromBytes(Vy_bytes);

            data.CalculatedTrackVelocityCartesianCoordinates_Vx = Vx;
            data.CalculatedTrackVelocityCartesianCoordinates_Vy = Vy;
        }

        // Data Item I010/210, Calculated Acceleration
        private void CalculatedAcceleration(byte[] octets)
        {
            double LSB = (double)0.25; // m/(s^2)

            byte[] Ax_bytes = new byte[1] { octets[0] }; // Reversed (no need to reverse, array of length 1)
            byte[] Ay_bytes = new byte[1] { octets[1] }; // Reversed (no need to reverse, array of length 1)

            double Ax = LSB * Functions.TwosComplement2Int_fromBytes(Ax_bytes);
            double Ay = LSB * Functions.TwosComplement2Int_fromBytes(Ay_bytes);

            data.CalculatedAcceleration_Ax = Ax;
            data.CalculatedAcceleration_Ay = Ay;
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
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // STI
            BitArray STI_bits = new BitArray(2);
            STI_bits[0] = bits[54];
            STI_bits[1] = bits[55];
            int STI_int = Functions.BitArray2Int(STI_bits);

            data.TargetIdentification_STI = CAT10_Dict.TartgetIdentificationSTI_dict[STI_int];

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
                // Maybe it's better to use Switch Case ????
                if (i < 6)
                {
                    char8_bits[i] = bits[i];
                }
                if (i >= 6 && i < 12)
                {
                    char7_bits[i - 6] = bits[i];
                }
                if (i >= 12 && i < 18)
                {
                    char6_bits[i - 12] = bits[i];
                }
                if (i >= 18 && i < 24)
                {
                    char5_bits[i - 18] = bits[i];
                }
                if (i >= 24 && i < 30)
                {
                    char4_bits[i - 24] = bits[i];
                }
                if (i >= 30 && i < 36)
                {
                    char3_bits[i - 30] = bits[i];
                }
                if (i >= 36 && i < 42)
                {
                    char2_bits[i - 36] = bits[i];
                }
                if (i >= 42 && i < 48)
                {
                    char1_bits[i - 42] = bits[i];
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

            string char8 = CAT10_Dict.TargetIdentificationCharacters_dict[char8_int];
            string char7 = CAT10_Dict.TargetIdentificationCharacters_dict[char7_int];
            string char6 = CAT10_Dict.TargetIdentificationCharacters_dict[char6_int];
            string char5 = CAT10_Dict.TargetIdentificationCharacters_dict[char5_int];
            string char4 = CAT10_Dict.TargetIdentificationCharacters_dict[char4_int];
            string char3 = CAT10_Dict.TargetIdentificationCharacters_dict[char3_int];
            string char2 = CAT10_Dict.TargetIdentificationCharacters_dict[char2_int];
            string char1 = CAT10_Dict.TargetIdentificationCharacters_dict[char1_int];

            data.TargetIdentification_Characters = char1 + char2 + char3 + char4 + char5 + char6 + char7 + char8;
        }

        // Data Item I010/250, Mode S MB Data
        private void ModeSMBData(byte[] octets, int REP)
        {
            data.ModeSMBData_REP = REP; // maybe it is not necessary to save REP in Data

            data.ModeSMBData_MBData = new int[REP];
            data.ModeSMBData_BDS1 = new int[REP];
            data.ModeSMBData_BDS2 = new int[REP];

            for (int i = 0; i < REP; i++)
            {
                byte[] MBData_bytes = new byte[7] { octets[8*i + 6], octets[8*i + 5], octets[8*i + 4], octets[8*i + 3], octets[8*i + 2], octets[8*i + 1], octets[8*i + 0] }; // Reversed

                BitArray BDS_bits = new BitArray(new byte[1] { octets[8*i + 7] });

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
        private int TargetSizeAndOrientation(byte[] octets)
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
                data.TargetSizeAndOrientation_FirstExtent_flag = true;

                // Orientation
                double LSB_Orientation = (double)360 / 128; // degrees
                double orientation = LSB_Orientation * Functions.BitArray2Int(Orientation_bits);
                data.TargetSizeAndOrientation_Orientation = orientation;

                if (bits[8] == true)
                {
                    data.TargetSizeAndOrientation_SecondExtent_flag = true;

                    // Width
                    int LSB_Width = 1; // m
                    int width = LSB_Width * Functions.BitArray2Int(Width_bits);
                    data.TargetSizeAndOrientation_Width = width;
                    return 3;
                }
                return 2;
            }
            return 1;
        }

        // Data Item I010/280, Presence
        private void Presence(byte[] octets, int REP)
        {
            data.Presence_REP = REP; // maybe it is not necessary to save REP in Data

            data.Presence_DRHO = new int[REP];
            data.Presence_DTHETA = new double[REP];

            int LSB_DRHO = 1; // m
            double LSB_DTHETA = (double)0.15; //degrees

            for (int i = 0; i < REP; i++)
            {
                int DRHO = LSB_DRHO * octets[2*i];
                double DTHETA = LSB_DTHETA * octets[2*i + 1];

                data.Presence_DRHO[i] = DRHO;
                data.Presence_DTHETA[i] = DTHETA;
            }
        }

        // Data Item I010/300, Vehicle Fleet Identification
        private void VehicleFleetIdentification(byte octet1)
        {
            data.VehicleFleetIdentification = CAT10_Dict.VehicleFleetIdentification_VFI_dict[octet1];
        }

        // Data Item I010/310, Pre-programmed Message
        private void PreprogrammedMessage(byte octet1)
        {
            BitArray bits = new BitArray(new byte[1] { octet1 });

            data.PreprogrammedMessage_TRB = CAT10_Dict.PreprogrammedMessage_TRB_dict[bits[7]];

            //bits.Length = bits.Length - 1;
            bits[7] = false;

            data.PreprogrammedMessage_MSG = CAT10_Dict.PreprogrammedMessage_MSG_dict[Functions.BitArray2Int(bits)];
        }

        // Data Item I010/500, Standard Deviation of Position
        private void StandardDeviationPosition(byte[] octets)
        {
            double LSB = (double)0.25; // m and (m^2)

            byte[] Covariance_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double SDx = LSB * octets[0];
            double SDy = LSB * octets[1];
            double Covariance = LSB * Functions.TwosComplement2Int_fromBytes(Covariance_bytes);

            data.StandardDeviationPosition_SDx = SDx;
            data.StandardDeviationPosition_SDy = SDy;
            data.StandardDeviationPosition_Coveriance = Covariance;
        }

        // Data Item I010/550, System Status
        private void SystemStatus(byte octet1)
        {
            BitArray bits = new BitArray(new byte[1] { octet1 });

            BitArray NOGO_bits = new BitArray(2);
            NOGO_bits[0] = bits[6];
            NOGO_bits[1] = bits[7];
            int NOGO_int = Functions.BitArray2Int(NOGO_bits);

            data.SystemStatus_NOGO = CAT10_Dict.SystemStatus_NOGO_dict[NOGO_int];
            data.SystemStatus_OVL = CAT10_Dict.SystemStatus_OVL_dict[bits[5]];
            data.SystemStatus_TSV = CAT10_Dict.SystemStatus_TSV_dict[bits[4]];
            data.SystemStatus_DIV = CAT10_Dict.SystemStatus_DIV_dict[bits[3]];
            data.SystemStatus_TTF = CAT10_Dict.SystemStatus_TTF_dict[bits[2]];
        }
        
    }
}
