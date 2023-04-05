using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class CAT21
    {
        // Content of the CAT21 message
        byte[] message { get; set; } // Maybe its useless

        // Bytes of the FSPEC
        public byte[] FSPEC { get; set; }

        // Where the decodificated data will be stored
        public CAT21_Data data = new CAT21_Data();


        // CONSTRUCTOR
        public CAT21(byte[] message)
        {
            this.message = message;
        }


        // METHODS
        // Data Item I021/020, Emitter Category
        private void EmitterCategory(byte octet1)
        {
            int ECAT = octet1;
            data.EmitterCategory = CAT21_Dict.EmitterCategory_dict[ECAT];
        }

        // Data Item I021/040, Target Report Descriptor
        private int TargetReportDescriptor(byte[] octets)
        {
            BitArray bits = new BitArray(octets);

            BitArray ATP_bits = new BitArray(3);
            ATP_bits[0] = bits[5];
            ATP_bits[1] = bits[6];
            ATP_bits[2] = bits[7];
            int ATP_int = Functions.BitArray2Int(ATP_bits);

            BitArray ARC_bits = new BitArray(2);
            ARC_bits[0] = bits[3];
            ARC_bits[1] = bits[4];
            int ARC_int = Functions.BitArray2Int(ARC_bits);

            data.TargetReportDescriptor_ATP = CAT21_Dict.TargetReportDescriptor_ATP_dict[ATP_int];
            data.TargetReportDescriptor_ARC = CAT21_Dict.TargetReportDescriptor_ARC_dict[ARC_int];
            data.TargetReportDescriptor_RC = CAT21_Dict.TargetReportDescriptor_RC_dict[bits[2]];
            data.TargetReportDescriptor_RAB = CAT21_Dict.TargetReportDescriptor_RAB_dict[bits[1]];

            if (bits[0] == true)
            {
                data.TargetReportDescriptor_FirstExtent_flag = true;

                BitArray CL_bits = new BitArray(2);
                CL_bits[0] = bits[9];
                CL_bits[1] = bits[10];
                int CL_int = Functions.BitArray2Int(CL_bits);

                data.TargetReportDescriptor_DCR = CAT21_Dict.TargetReportDescriptor_DCR_dict[bits[15]];
                data.TargetReportDescriptor_GBS = CAT21_Dict.TargetReportDescriptor_GBS_dict[bits[14]];
                data.TargetReportDescriptor_SIM = CAT21_Dict.TargetReportDescriptor_SIM_dict[bits[13]];
                data.TargetReportDescriptor_TST = CAT21_Dict.TargetReportDescriptor_TST_dict[bits[12]];
                data.TargetReportDescriptor_SAA = CAT21_Dict.TargetReportDescriptor_SAA_dict[bits[11]];
                data.TargetReportDescriptor_CL = CAT21_Dict.TargetReportDescriptor_CL_dict[CL_int];

                if (bits[8] == true)
                {
                    data.TargetReportDescriptor_SecondExtent_flag = true;

                    data.TargetReportDescriptor_IPC = CAT21_Dict.TargetReportDescriptor_IPC_dict[bits[21]];
                    data.TargetReportDescriptor_NOGO = CAT21_Dict.TargetReportDescriptor_NOGO_dict[bits[20]];
                    data.TargetReportDescriptor_CPR = CAT21_Dict.TargetReportDescriptor_CPR_dict[bits[19]];
                    data.TargetReportDescriptor_LDPJ = CAT21_Dict.TargetReportDescriptor_LDPJ_dict[bits[18]];
                    data.TargetReportDescriptor_RCF = CAT21_Dict.TargetReportDescriptor_RCF_dict[bits[17]];

                    return 3;
                }
                return 2;
            }
            return 1;
        }

        // Data Item I021/070, Mode 3/A Code in Octal Representation
        private void Mode3ACodeOctalRepresentation(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

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

        // Data Item I021/071, Time of Applicability for Position
        private void TimeOfApplicabilityForPosition(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfApplicabilityForPosition = LSB * Functions.CombineBytes2Int(octets);

            data.TimeOfApplicabilityForPosition = timeOfApplicabilityForPosition;
        }

        // Data Item I021/072, Time of Applicability for Velocity
        private void TimeOfApplicabilityForVelocity(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfApplicabilityForVelocity = LSB * Functions.CombineBytes2Int(octets);

            data.TimeOfApplicabilityForVelocity = timeOfApplicabilityForVelocity;
        }

        // Data Item I021/073, Time of Message Reception for Position
        private void TimeOfMessageReceptionForPosition(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfMessageReceptionForPosition = LSB * Functions.CombineBytes2Int(octets);

            data.TimeOfMessageReceptionForPosition = timeOfMessageReceptionForPosition;
        }

        // Data Item I021/074, Time of Message Reception of Position–High Precision
        private void TimeOfMessageReceptionOfPosition_HighPrecision(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // Full Second Indication (FSI)
            BitArray FSI_bits = new BitArray(2);
            FSI_bits[0] = bits[30];
            FSI_bits[1] = bits[31];
            int FSI_int = Functions.BitArray2Int(FSI_bits);

            data.TimeOfMessageReceptionOfPosition_HighPrecision_FSI = CAT21_Dict.TimeOfMessageReceptionOfPosition_HighPrecision_FSI_dict[FSI_int];

            // Fractional part of the time of message reception for position in the ground station.
            bits.Length = bits.Length - 2;

            decimal LSB = (decimal)Math.Pow(2, -30); // s (0.9313 ns)
            decimal timeOfMessageReceptionOfPosition_HighPrecision = LSB * Functions.BitArray2Int(bits);

            data.TimeOfMessageReceptionOfPosition_HighPrecision = timeOfMessageReceptionOfPosition_HighPrecision;
        }

        // Data Item I021/075, Time of Message Reception for Velocity
        private void TimeOfMessageReceptionForVelocity(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfMessageReceptionForVelocity = LSB * Functions.CombineBytes2Int(octets);

            data.TimeOfMessageReceptionForVelocity = timeOfMessageReceptionForVelocity;
        }

        // Data Item I021/110, Trajectory Intent
        private int TrajectoryIntent(byte[] octets, int REP)
        {
            BitArray primary_bits = new BitArray(new byte[1] { octets[0] });

            // maybe this is not necessary
            bool TIS_bool = primary_bits[7];
            bool TID_bool = primary_bits[6];
            data.TrajectoryIntent_TIS = CAT21_Dict.TrajectoryIntent_TIS_dict[TID_bool];
            data.TrajectoryIntent_TID = CAT21_Dict.TrajectoryIntent_TID_dict[TIS_bool];

            // We will need to save the index value in a variable
            int index = 1;

            if (primary_bits[0] == true)
            {
                if (primary_bits[7] == true)
                {
                    data.TrajectoryIntent_FirstExtent_flag = true; // maybe unnecessary

                    BitArray subfield1_bits = new BitArray(new byte[1] { octets[index] });

                    data.TrajectoryIntent_NAV = CAT21_Dict.TrajectoryIntent_NAV_dict[subfield1_bits[7]];
                    data.TrajectoryIntent_NVB = CAT21_Dict.TrajectoryIntent_NVB_dict[subfield1_bits[6]];

                    index += 1;
                }
                if (primary_bits[6] == true)
                {
                    data.TrajectoryIntent_SecondExtent_flag = true; // maybe unnecessary

                    index += 1; // for the REP byte

                    for (int i = 0; i < REP; i++)
                    {
                        // We save the bytes from subfield 2 in a byte array
                        byte[] subfield2_bytes = new byte[15] { octets[(index)], octets[(index + 1)], octets[(index + 2)], octets[(index + 3)], octets[(index + 4)], octets[(index + 5)], octets[(index + 6)], octets[(index + 7)], octets[(index + 8)], octets[(index + 9)], octets[(index + 10)], octets[(index + 11)], octets[(index + 12)], octets[(index + 13)], octets[(index + 14)] };

                        // Octet no. 2
                        BitArray subfield2_byte0_bits = new BitArray(new byte[1] { subfield2_bytes[0] });
                        data.TrajectoryIntent_TCA[i] = CAT21_Dict.TrajectoryIntent_TCA_dict[subfield2_byte0_bits[7]];
                        data.TrajectoryIntent_NC[i] = CAT21_Dict.TrajectoryIntent_NC_dict[subfield2_byte0_bits[6]];
                        subfield2_byte0_bits.Length = subfield2_byte0_bits.Length - 2;
                        data.TrajectoryIntent_TCP[i] = Functions.BitArray2Int(subfield2_byte0_bits);

                        // Octet no. 3 & 4
                        double Altitude_LSB = 10; // ft
                        byte[] Altitude_bytes = new byte[2] { subfield2_bytes[2], subfield2_bytes[1] }; // Reversed
                        double Altitude = Altitude_LSB * Functions.TwosComplement2Int_fromBytes(Altitude_bytes);
                        data.TrajectoryIntent_Altitude[i] = Altitude;

                        // Octet no. 5 & 6 & 7
                        double LatAndLongWGS84_LSB = 180 / Math.Pow(2, 23); // ft
                        byte[] LatitudeWGS84_bytes = new byte[3] { subfield2_bytes[5], subfield2_bytes[4], subfield2_bytes[3] }; // Reversed
                        double LatitudeWGS84 = LatAndLongWGS84_LSB * Functions.TwosComplement2Int_fromBytes(LatitudeWGS84_bytes);
                        data.TrajectoryIntent_Latitude[i] = LatitudeWGS84;

                        // Octet no. 8 & 9 & 10
                        byte[] LongitudeWGS84_bytes = new byte[3] { subfield2_bytes[8], subfield2_bytes[7], subfield2_bytes[6] }; // Reversed
                        double LongitudeWGS84 = LatAndLongWGS84_LSB * Functions.TwosComplement2Int_fromBytes(LongitudeWGS84_bytes);
                        data.TrajectoryIntent_Longitude[i] = LongitudeWGS84;

                        // Octet no. 11
                        BitArray subfield2_byte9_bits = new BitArray(new byte[1] { subfield2_bytes[9] });
                        BitArray PointType_bits = new BitArray(4);
                        PointType_bits[0] = subfield2_byte9_bits[4];
                        PointType_bits[1] = subfield2_byte9_bits[5];
                        PointType_bits[2] = subfield2_byte9_bits[6];
                        PointType_bits[3] = subfield2_byte9_bits[7];
                        int PointType_int = Functions.BitArray2Int(PointType_bits);
                        data.TrajectoryIntent_PointType[i] = CAT21_Dict.TrajectoryIntent_PointType_dict[PointType_int];
                        BitArray TD_bits = new BitArray(2);
                        TD_bits[0] = subfield2_byte9_bits[2];
                        TD_bits[1] = subfield2_byte9_bits[3];
                        int TD_int = Functions.BitArray2Int(TD_bits);
                        data.TrajectoryIntent_TD[i] = CAT21_Dict.TrajectoryIntent_TD_dict[TD_int];
                        data.TrajectoryIntent_TRA[i] = CAT21_Dict.TrajectoryIntent_TRA_dict[subfield2_byte9_bits[1]];
                        data.TrajectoryIntent_TOA[i] = CAT21_Dict.TrajectoryIntent_TOA_dict[subfield2_byte9_bits[0]];

                        // Octet no. 12 & 13 & 14
                        //double TOV_LSB = 1; // s
                        byte[] TOV_bytes = new byte[3] { subfield2_bytes[12], subfield2_bytes[11], subfield2_bytes[10] }; // Reversed
                        double TOV = Functions.CombineBytes2Int(TOV_bytes);
                        data.TrajectoryIntent_TOV[i] = TOV;

                        // Octet no. 15 & 16
                        double TTR_LSB = 0.01; // Nm
                        byte[] TTR_bytes = new byte[2] { subfield2_bytes[14], subfield2_bytes[13] }; // Reversed
                        double TTR = TTR_LSB * Functions.CombineBytes2Int(TTR_bytes);
                        data.TrajectoryIntent_TTR[i] = TTR;

                        index += 15;
                    }
                }
            }
            return index;
        }

        // Data Item I021/130, Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates(byte[] octets)
        {
            double LSB = 180 / Math.Pow(2, 23); // degrees

            byte[] latitude_bytes = new byte[3] { octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitude_bytes = new byte[3] { octets[5], octets[4], octets[3] }; // Reversed

            double latitude = LSB * Functions.TwosComplement2Int_fromBytes(latitude_bytes);
            double longitude = LSB * Functions.TwosComplement2Int_fromBytes(longitude_bytes);

            data.PositionWGS84Coordinates_Latitude = latitude;
            data.PositionWGS84Coordinates_Longitude = longitude;
        }

        // Data Item I021/131, High-Resolution Position in WGS-84 Co-ordinates
        private void HighResolutionPositionWGS84Coordinates(byte[] octets)
        {
            double LSB = 180 / Math.Pow(2, 30); // degrees

            byte[] latitudeWGS84_bytes = new byte[4] { octets[3], octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitudeWGS84_bytes = new byte[4] { octets[7], octets[6], octets[5], octets[4] }; // Reversed

            double latitudeWGS84 = LSB * Functions.TwosComplement2Int_fromBytes(latitudeWGS84_bytes);
            double longitudeWGS84 = LSB * Functions.TwosComplement2Int_fromBytes(longitudeWGS84_bytes);

            data.HighResolutionPositionWGS84Coordinates_Latitude = latitudeWGS84;
            data.HighResolutionPositionWGS84Coordinates_Longitude = longitudeWGS84;
        }

        // Data Item I021/132, Message Amplitude
        private void MessageAmplitude(byte octet1)
        {
            byte[] MAM_bytes = new byte[1] { octet1 }; // Reversed (no need to reverse, array of length 1)
            //double LSB = 1 // dBm
            data.MessageAmplitude = Functions.TwosComplement2Int_fromBytes(MAM_bytes);
        }

        // Data Item I021/155, Barometric Vertical Rate
        private void BarometricVerticalRate(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            data.BarometricVerticalRate_RE = CAT21_Dict.RE_dict[bits[15]];

            bits.Length = bits.Length - 1;

            double LSB = 6.25; // ft/min
            double BarometricVerticalRate = LSB * Functions.TwosComplement2Int_fromBitArray(bits);
            data.BarometricVerticalRate = BarometricVerticalRate;
        }

        // Data Item I021/157, Geometric Vertical Rate
        private void GeometricVerticalRate(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            data.GeometricVerticalRate_RE = CAT21_Dict.RE_dict[bits[15]];

            bits.Length = bits.Length - 1;

            double LSB = 6.25; // ft/min
            double GeometricVerticalRate = LSB * Functions.TwosComplement2Int_fromBitArray(bits);
            data.GeometricVerticalRate = GeometricVerticalRate;
        }

        // Data Item I021/160, Airborne Ground Vector
        private void AirborneGroundVector(byte[] octets)
        {
            Array.Reverse(octets);

            // RE and Ground Speed
            byte[] GroundSpeed_and_RE_bytes = new byte[2] { octets[2], octets[3] }; // Previously reversed
            BitArray GroundSpeed_and_RE_bits = new BitArray(GroundSpeed_and_RE_bytes);

            data.AirborneGroundVector_RE = CAT21_Dict.RE_dict[GroundSpeed_and_RE_bits[15]];
            GroundSpeed_and_RE_bits.Length = GroundSpeed_and_RE_bits.Length - 1;

            double LSB_GroundSpeed = 0.22; // kt
            double GroundSpeed = LSB_GroundSpeed * Functions.BitArray2Int(GroundSpeed_and_RE_bits);
            data.AirborneGroundVector_GroundSpeed = GroundSpeed;

            // Track Angle
            double LSB_TrackAngle = 360 / Math.Pow(2, 16); // degrees
            byte[] TrackAngle_bytes = new byte[2] { octets[0], octets[1] }; // Previously reversed
            double TrackAngle = LSB_TrackAngle * Functions.CombineBytes2Int(TrackAngle_bytes);
            data.AirborneGroundVector_TrackAngle = TrackAngle;
        }

        // Data Item I021/161: Track Number
        private void TrackNumber(byte[] octets)
        {
            Array.Reverse(octets);

            data.TrackNumber = Functions.CombineBytes2Int(octets);
        }

        // Data Item I021/200, Target Status
        private void TargetStatus(byte octet1)
        {
            BitArray bits = new BitArray(new byte[1] { octet1 });

            BitArray PS_bits = new BitArray(3);
            PS_bits[0] = bits[2];
            PS_bits[1] = bits[3];
            PS_bits[2] = bits[4];
            int PS_int = Functions.BitArray2Int(PS_bits);

            BitArray SS_bits = new BitArray(2);
            SS_bits[0] = bits[0];
            SS_bits[1] = bits[1];
            int SS_int = Functions.BitArray2Int(SS_bits);

            data.TargetStatus_ICF = CAT21_Dict.TargetStatus_ICF_dict[bits[7]];
            data.TargetStatus_LNAV = CAT21_Dict.TargetStatus_LNAV_dict[bits[6]];
            data.TargetStatus_PS = CAT21_Dict.TargetStatus_PS_dict[PS_int];
            data.TargetStatus_SS = CAT21_Dict.TargetStatus_SS_dict[SS_int];
        }

        // Data Item I021/210, MOPS Version
        private void MOPSVersion(byte octet1)
        {
            BitArray bits = new BitArray(new byte[1] { octet1 });

            BitArray VN_bits = new BitArray(3);
            VN_bits[0] = bits[3];
            VN_bits[1] = bits[4];
            VN_bits[2] = bits[5];
            int VN_int = Functions.BitArray2Int(VN_bits);

            BitArray LTT_bits = new BitArray(3);
            LTT_bits[0] = bits[0];
            LTT_bits[1] = bits[1];
            LTT_bits[2] = bits[2];
            int LTT_int = Functions.BitArray2Int(LTT_bits);

            data.MOPSVersion_VNS = CAT21_Dict.MOPSVersion_VNS_dict[bits[6]];
            data.MOPSVersion_VN = CAT21_Dict.MOPSVersion_VN_dict[VN_int];
            data.MOPSVersion_LTT = CAT21_Dict.MOPSVersion_LTT_dict[LTT_int];
        }

        // Data Item I021/220, Met Information
        private int MetInformation(byte[] octets)
        {
            BitArray primary_bits = new BitArray(new byte[1] { octets[0] });
            
            // maybe this is not necessary
            data.MetInformation_WS = CAT21_Dict.MetInformation_WS_dict[primary_bits[7]];
            data.MetInformation_WD = CAT21_Dict.MetInformation_WD_dict[primary_bits[6]];
            data.MetInformation_TMP = CAT21_Dict.MetInformation_TMP_dict[primary_bits[5]];
            data.MetInformation_TRB = CAT21_Dict.MetInformation_TRB_dict[primary_bits[4]];

            // We will need to save the index value in a variable
            int index = 1;

            if (primary_bits[0] == true)
            {
                if (primary_bits[7] == true)
                {
                    //double WindSpeed_LSB = 1; // kt
                    byte[] WindSpeed_bytes = new byte[2] { octets[index+1], octets[index] }; // Reversed
                    double WindSpeed = Functions.CombineBytes2Int(WindSpeed_bytes);
                    data.MetInformation_WindSpeed = WindSpeed;
                    index += 2;
                }
                if (primary_bits[6] == true)
                {
                    //double WindDirection_LSB = 1; // degree
                    byte[] WindDirection_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double WindDirection = Functions.CombineBytes2Int(WindDirection_bytes);
                    data.MetInformation_WindDirection = WindDirection;
                    index += 2;
                }
                if (primary_bits[5] == true)
                {
                    double Temperature_LSB = 0.25; // 'C
                    byte[] Temperature_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double Temperature = Temperature_LSB * Functions.CombineBytes2Int(Temperature_bytes);
                    data.MetInformation_Temperature = Temperature;
                    index += 2;
                }
                if (primary_bits[4] == true)
                {
                    int Turbulence = octets[index];
                    data.MetInformation_Turbulence = Turbulence;
                    index += 1;
                }
            }
            return index;
        }

        // Data Item I021/170, Target Identification
        private void TargetIdentification(byte[] octets)
        {
            Array.Reverse(octets);
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

            for (int i = 0; i < bits.Length; i++)
            {
                // Maybe it's better to use Switch Case ????
                if (i < 6)
                {
                    char8_bits[i] = bits[i];
                }
                if (i >= 6 && i < 12)
                {
                    char7_bits[i-6] = bits[i];
                }
                if (i >= 12 && i < 18)
                {
                    char6_bits[i-12] = bits[i];
                }
                if (i >= 18 && i < 24)
                {
                    char5_bits[i-18] = bits[i];
                }
                if (i >= 24 && i < 30)
                {
                    char4_bits[i-24] = bits[i];
                }
                if (i >= 30 && i < 36)
                {
                    char3_bits[i-30] = bits[i];
                }
                if (i >= 36 && i < 42)
                {
                    char2_bits[i-36] = bits[i];
                }
                if (i >= 42 && i < 48)
                {
                    char1_bits[i-42] = bits[i];
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

            string char8 = CAT21_Dict.TargetIdentification_dict[char8_int];
            string char7 = CAT21_Dict.TargetIdentification_dict[char7_int];
            string char6 = CAT21_Dict.TargetIdentification_dict[char6_int];
            string char5 = CAT21_Dict.TargetIdentification_dict[char5_int];
            string char4 = CAT21_Dict.TargetIdentification_dict[char4_int];
            string char3 = CAT21_Dict.TargetIdentification_dict[char3_int];
            string char2 = CAT21_Dict.TargetIdentification_dict[char2_int];
            string char1 = CAT21_Dict.TargetIdentification_dict[char1_int];

            data.TargetIdentification = char1 + char2 + char3 + char4 + char5 + char6 + char7 + char8;
        }


    }
}
