using System;
using System.Collections;
using System.Reflection;
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
            this.message = message; // Maybe its useless

            FSPEC_Decodification(message);
        }


        // METHODS
        // CAT21 Decodification function (with FSPEC)
        private void FSPEC_Decodification(byte[] message)
        {
            // Calculate the number of bytes that the FSPEC has
            int FSPEC_numberOfBytes = 1;
            for (int i = 0; i < 7; i++)
            {
                BitArray FSPEC_1byte_bits = new BitArray(new byte[1] { message[i] });
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
                FSPEC_bytes[i] = message[i];
            }
            this.FSPEC = FSPEC_bytes;

            // We can start decoding
            int byteSum_index = FSPEC_numberOfBytes; // Index inside the byte[] message

            for (int i = 0; i < FSPEC_numberOfBytes; i++)
            {
                switch (i)
                {
                    case 0:
                        BitArray FSPEC_byte1_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte1_bits[7] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            DataSourceIdentification(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte1_bits[6] == true)
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
                        if (FSPEC_byte1_bits[5] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            TrackNumber(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte1_bits[4] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            ServiceIdentification(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte1_bits[3] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TimeOfApplicabilityForPosition(bytes);
                            byteSum_index += 3;
                        }
                        if (FSPEC_byte1_bits[2] == true)
                        {
                            byte[] bytes = new byte[6] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5] };
                            PositionWGS84Coordinates(bytes);
                            byteSum_index += 6;
                        }
                        if (FSPEC_byte1_bits[1] == true)
                        {
                            byte[] bytes = new byte[8] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5], message[byteSum_index + 6], message[byteSum_index + 7] };
                            PositionWGS84Coordinates_HighResolution(bytes);
                            byteSum_index += 8;
                        }

                        break;

                    case 1:
                        BitArray FSPEC_byte2_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte2_bits[7] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TimeOfApplicabilityForVelocity(bytes);
                            byteSum_index += 3;
                        }
                        if (FSPEC_byte2_bits[6] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            AirSpeed(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte2_bits[5] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            TrueAirSpeed(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte2_bits[4] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TargetAddress(bytes);
                            byteSum_index += 3;
                        }
                        if (FSPEC_byte2_bits[3] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TimeOfMessageReceptionForPosition(bytes);
                            byteSum_index += 3;
                        }
                        if (FSPEC_byte2_bits[2] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            TimeOfMessageReceptionOfPosition_HighPrecision(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte2_bits[1] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TimeOfMessageReceptionForVelocity(bytes);
                            byteSum_index += 3;
                        }

                        break;

                    case 2:
                        BitArray FSPEC_byte3_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte3_bits[7] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            TimeOfMessageReceptionOfVelocity_HighPrecision(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte3_bits[6] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            GeometricHeight(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte3_bits[5] == true)
                        {
                            byte[] bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 4)
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            }

                            int numBytes = QualityIndicators(bytes);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte3_bits[4] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            MOPSVersion(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte3_bits[3] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            Mode3ACodeOctalRepresentation(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte3_bits[2] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            RollAngle(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte3_bits[1] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            FlightLevel(bytes);
                            byteSum_index += 2;
                        }

                        break;

                    case 3:
                        BitArray FSPEC_byte4_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte4_bits[7] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            MagneticHeading(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte4_bits[6] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            TargetStatus(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte4_bits[5] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            BarometricVerticalRate(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte4_bits[4] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            GeometricVerticalRate(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte4_bits[3] == true)
                        {
                            byte[] bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            AirborneGroundVector(bytes);
                            byteSum_index += 4;
                        }
                        if (FSPEC_byte4_bits[2] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            TrackAngleRate(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte4_bits[1] == true)
                        {
                            byte[] bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            TimeOfASTERIXReportTransmission(bytes);
                            byteSum_index += 3;
                        }

                        break;

                    case 4:
                        BitArray FSPEC_byte5_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte5_bits[7] == true)
                        {
                            byte[] bytes = new byte[6] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5] };
                            TargetIdentification(bytes);
                            byteSum_index += 6;
                        }
                        if (FSPEC_byte5_bits[6] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            EmitterCategory(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte5_bits[5] == true)
                        {
                            byte[] bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 8)
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                bytes = new byte[8] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5], message[byteSum_index + 6], message[byteSum_index + 7] };
                            }

                            int numBytes = MetInformation(bytes);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte5_bits[4] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            SelectedAltitude(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte5_bits[3] == true)
                        {
                            byte[] bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            FinalStateSelectedAltitude(bytes);
                            byteSum_index += 2;
                        }
                        if (FSPEC_byte5_bits[2] == true)
                        {
                            // Get REP value
                            byte[] REP_bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 3)
                            {
                                REP_bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    REP_bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                REP_bytes = new byte[3] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2] };
                            }

                            int REP = TrajectoryIntent_REP(REP_bytes);

                            // Once we have REP value, decode Trajectory Intent
                            byte[] bytes;

                            //int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < (3 + 15*REP))
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                bytes = new byte[3 + 15 * REP];
                                for (int k = 0; k < bytes.Length; k++)
                                {
                                    bytes[k] = message[byteSum_index + k];
                                }
                            }

                            int numBytes = TrajectoryIntent(bytes, REP);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte5_bits[1] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            ServiceManagement(byte1);
                            byteSum_index += 1;
                        }

                        break;

                    case 5:
                        BitArray FSPEC_byte6_bits = new BitArray(new byte[1] { FSPEC_bytes[i] });

                        if (FSPEC_byte6_bits[7] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            AircraftOperationalStatus(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte6_bits[6] == true)
                        {
                            byte[] bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 2)
                            {
                                bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                bytes = new byte[2] { message[byteSum_index], message[byteSum_index + 1] };
                            }

                            int numBytes = SurfaceCapabilitiesAndCharacteristics(bytes);
                            byteSum_index += numBytes;
                        }
                        if (FSPEC_byte6_bits[5] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            MessageAmplitude(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte6_bits[4] == true)
                        {
                            int REP = message[byteSum_index];
                            byteSum_index += 1;
                            int numberOfBytes = REP * 8;
                            byte[] bytes = new byte[numberOfBytes];
                            for (int j = 0; j < numberOfBytes; j++)
                            {
                                bytes[j] = message[byteSum_index + j];
                            }
                            ModeSMBdata(bytes, REP);
                            byteSum_index += numberOfBytes;
                        }
                        if (FSPEC_byte6_bits[3] == true)
                        {
                            byte[] bytes = new byte[7] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3], message[byteSum_index + 4], message[byteSum_index + 5], message[byteSum_index + 6] };
                            ACASResolutionAdvisoryReport(bytes);
                            byteSum_index += 7;
                        }
                        if (FSPEC_byte6_bits[2] == true)
                        {
                            byte byte1 = message[byteSum_index];
                            ReceiverID(byte1);
                            byteSum_index += 1;
                        }
                        if (FSPEC_byte6_bits[1] == true)
                        {
                            // First we get the number of octets of the primary subfield and the subfields
                            byte[] primarySubfield_bytes;

                            int bytesAvailable = message.Length - byteSum_index;
                            if (bytesAvailable < 4)
                            {
                                primarySubfield_bytes = new byte[bytesAvailable];
                                for (int j = 0; j < bytesAvailable; j++)
                                {
                                    primarySubfield_bytes[j] = message[byteSum_index + j];
                                }
                            }
                            else
                            {
                                primarySubfield_bytes = new byte[4] { message[byteSum_index], message[byteSum_index + 1], message[byteSum_index + 2], message[byteSum_index + 3] };
                            }

                            int[] numberOfOctets = DataAges_primarySubfield(primarySubfield_bytes);
                            int primarySubfield_numberOfOctets = numberOfOctets[0];
                            int subfields_numberOfOctets = numberOfOctets[1];

                            byteSum_index += primarySubfield_numberOfOctets; // we sum the primary subfield octets to the index

                            // Once we have the number of octets, we can decode
                            byte[] subfields_bytes = new byte[subfields_numberOfOctets];

                            for (int k = 0; k < subfields_numberOfOctets; k++)
                            {
                                subfields_bytes[k] = message[byteSum_index + k];
                            }

                            DataAges_subfields(subfields_bytes);
                            byteSum_index += subfields_numberOfOctets;
                        }

                        break;

                }
            }
        }

        // Data Item I021/008, Aircraft Operational Status
        private void AircraftOperationalStatus(byte octet1)
        {
            BitArray bits = new BitArray(new byte[1] { octet1 });

            BitArray TC_bits = new BitArray(2);
            TC_bits[0] = bits[5];
            TC_bits[1] = bits[6];
            int TC_int = Functions.BitArray2Int(TC_bits);

            data.AircraftOperationalStatus_RA = CAT21_Dict.AircrafOperationalStatus_RA_dict[bits[7]];
            data.AicraftOperationalStatus_TC = CAT21_Dict.AircraftOperationalStatus_TC_dict[TC_int];
            data.AircraftOpertionalStatus_TS = CAT21_Dict.AircraftOperationalStatus_TS_dict[bits[4]];
            data.AircraftOperationalStatus_ARV = CAT21_Dict.AircraftOperationalStatus_ARV_dict[bits[3]];
            data.AircraftOperationalStatus_CDTI_A = CAT21_Dict.AircraftOperationalStatus_CDTI_dict[bits[2]];
            data.AircraftOperationalStatus_TCAS = CAT21_Dict.AircraftOperationalStatus_TCAS_dict[bits[1]];
            data.AircraftOperationalStatus_SA = CAT21_Dict.AircraftOperationalStatus_SA_dict[bits[0]];
        }

        // Data Item I021/010, Data Source Identification 
        private void DataSourceIdentification(byte[] octetos)
        {
            data.DataSourceIdentification_SAC = octetos[0];
            data.DataSourceIdentification_SIC = octetos[1];
        }

        // Data Item I021/015, Service Identification
        private void ServiceIdentification(byte octet1)
        {
            data.ServiceIdentification = octet1;
        }

        // Data Item I021/016, Service Management
        private void ServiceManagement(byte octet1)
        {
            double LSB = 0.5; // s
            double ServiceManagement = LSB * octet1;
            data.ServiceManagement = ServiceManagement;
        }

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

        // Data Item I021/076, Time of Message Reception of Velocity–High Precision
        private void TimeOfMessageReceptionOfVelocity_HighPrecision(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // Full Second Indication (FSI)
            BitArray FSI_bits = new BitArray(2);
            FSI_bits[0] = bits[30];
            FSI_bits[1] = bits[31];
            int FSI_int = Functions.BitArray2Int(FSI_bits);

            data.TimeOfMessageReceptionOfVelocity_HighPrecision_FSI = CAT21_Dict.TimeOfMessageReceptionOfVelocity_HighPrecision_FSI_dict[FSI_int];

            // Fractional part of the time of message reception for position in the ground station.
            bits.Length = bits.Length - 2;

            decimal LSB = (decimal)Math.Pow(2, -30); // s (0.9313 ns)
            decimal timeOfMessageReceptionOfVelocity_HighPrecision = LSB * Functions.BitArray2Int(bits);

            data.TimeOfMessageReceptionOfVelocity_HighPrecision = timeOfMessageReceptionOfVelocity_HighPrecision;
        }

        // Data Item I021/077, Time of ASTERIX Report Transmission
        private void TimeOfASTERIXReportTransmission(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = 1 / 128; // s
            double timeOfAsterixReportTransmission = LSB * Functions.CombineBytes2Int(octets);

            data.TimeOfASTERIXReportTransmission = timeOfAsterixReportTransmission;
        }

        // Data Item I021/080, Target Address
        private void TargetAddress(byte[] octets)
        {
            byte[] TargetAddress_bytes = new byte[3] { octets[2], octets[1], octets[0] }; // Reversed

            int TargetAddress_int = Functions.CombineBytes2Int(TargetAddress_bytes);
            string TargetAddress = TargetAddress_int.ToString("X");

            data.TargetAddress = TargetAddress;
        }

        // Data Item I021/090, Quality Indicators
        private int QualityIndicators(byte[] octets)
        {
            BitArray bits = new BitArray(octets);

            BitArray NUCr_or_NACv_bits = new BitArray(3);
            NUCr_or_NACv_bits[0] = bits[5];
            NUCr_or_NACv_bits[1] = bits[6];
            NUCr_or_NACv_bits[2] = bits[7];
            int NUCr_or_NACv_int = Functions.BitArray2Int(NUCr_or_NACv_bits);

            BitArray NUCp_or_NIC_bits = new BitArray(4);
            NUCp_or_NIC_bits[0] = bits[1];
            NUCp_or_NIC_bits[1] = bits[2];
            NUCp_or_NIC_bits[2] = bits[3];
            NUCp_or_NIC_bits[3] = bits[4];
            int NUCp_or_NIC_int = Functions.BitArray2Int(NUCp_or_NIC_bits);

            data.QualityIndicators_NUCr_or_NACv = NUCr_or_NACv_int;
            data.QualityIndicators_NUCp_or_NIC = NUCp_or_NIC_int;

            if (bits[0] == true)
            {
                data.QualityIndicators_FirstExtent_flag = true;

                int NICbaro_int = Convert.ToInt32(bits[15]);

                BitArray SIL_bits = new BitArray(2);
                SIL_bits[0] = bits[13];
                SIL_bits[1] = bits[14];
                int SIL_int = Functions.BitArray2Int(SIL_bits);

                BitArray NACp_bits = new BitArray(4);
                NACp_bits[0] = bits[9];
                NACp_bits[1] = bits[10];
                NACp_bits[2] = bits[11];
                NACp_bits[3] = bits[12];
                int NACp_int = Functions.BitArray2Int(NACp_bits);

                data.QualityIndicators_NICbaro = NICbaro_int;
                data.QualityIndicators_SIL = SIL_int;
                data.QualityIndicators_NACp = NACp_int;

                if (bits[8] == true)
                {
                    data.QualityIndicators_SecondExtent_flag = true;

                    BitArray SDA_bits = new BitArray(2);
                    SDA_bits[0] = bits[19];
                    SDA_bits[1] = bits[20];
                    int SDA_int = Functions.BitArray2Int(SDA_bits);

                    BitArray GVA_bits = new BitArray(2);
                    GVA_bits[0] = bits[17];
                    GVA_bits[1] = bits[18];
                    int GVA_int = Functions.BitArray2Int(GVA_bits);

                    data.QualityIndicators_SILsupplement = CAT21_Dict.QualityIndicators_SILsupplement_dict[bits[21]];
                    data.QualityIndicators_SDA = SDA_int;
                    data.QualityIndicators_GVA = GVA_int;

                    if (bits[16] == true)
                    {
                        data.QualityIndicators_ThirdExtent_flag = true;

                        BitArray PIC_bits = new BitArray(4);
                        PIC_bits[0] = bits[28];
                        PIC_bits[1] = bits[29];
                        PIC_bits[2] = bits[30];
                        PIC_bits[3] = bits[31];
                        int PIC_int = Functions.BitArray2Int(PIC_bits);

                        data.QualityIndicators_PIC = PIC_int;

                        return 4;
                    }
                    return 3;
                }
                return 2;
            }
            return 1;
        }

        // Data Item I021/110, Trajectory Intent
        private int TrajectoryIntent_REP(byte[] octets)
        {
            BitArray primary_bits = new BitArray(new byte[1] { octets[0] });

            int REP = 0;

            int index = 0;

            if (primary_bits[0] == true)
            {
                if (primary_bits[7] == true)
                {
                    index++;
                }
                if (primary_bits[6] == true)
                {
                    index++;
                }
                else if (primary_bits[6] == false)
                {
                    return 0;
                }
            }

            REP = octets[index];
            return REP;
        }

        // Data Item I021/110, Trajectory Intent
        private int TrajectoryIntent(byte[] octets, int REP)
        {
            BitArray primary_bits = new BitArray(new byte[1] { octets[0] });

            // maybe this is not necessary (changed)
            bool TIS_bool = primary_bits[7];
            bool TID_bool = primary_bits[6];
            //data.TrajectoryIntent_TIS = CAT21_Dict.TrajectoryIntent_TIS_dict[TID_bool];
            //data.TrajectoryIntent_TID = CAT21_Dict.TrajectoryIntent_TID_dict[TIS_bool];
            data.TrajectoryIntent_TIS_subfield1 = TIS_bool;
            data.TrajectoryIntent_TID_subfield2 = TID_bool;

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
        private void PositionWGS84Coordinates_HighResolution(byte[] octets)
        {
            double LSB = 180 / Math.Pow(2, 30); // degrees

            byte[] latitudeWGS84_bytes = new byte[4] { octets[3], octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitudeWGS84_bytes = new byte[4] { octets[7], octets[6], octets[5], octets[4] }; // Reversed

            double latitudeWGS84 = LSB * Functions.TwosComplement2Int_fromBytes(latitudeWGS84_bytes);
            double longitudeWGS84 = LSB * Functions.TwosComplement2Int_fromBytes(longitudeWGS84_bytes);

            data.PositionWGS84Coordinates_HighResolution_Latitude = latitudeWGS84;
            data.PositionWGS84Coordinates_HighResolution_Longitude = longitudeWGS84;
        }

        // Data Item I021/132, Message Amplitude
        private void MessageAmplitude(byte octet1)
        {
            byte[] MAM_bytes = new byte[1] { octet1 }; // Reversed (no need to reverse, array of length 1)
            //double LSB = 1 // dBm
            data.MessageAmplitude = Functions.TwosComplement2Int_fromBytes(MAM_bytes);
        }

        // Data Item I021/140, Geometric Height
        private void GeometricHeight(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = 6.25; // ft
            double GeometricHeight = LSB * Functions.TwosComplement2Int_fromBytes(octets);

            data.GeometricHeight = GeometricHeight;
        }

        // Data Item I021/145, Flight Level
        private void FlightLevel(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = 1 / 4; // FL
            double FlightLevel = LSB * Functions.TwosComplement2Int_fromBytes(octets);

            data.FlightLevel = FlightLevel;
        }

        // Data Item I021/146, Selected Altitude
        private void SelectedAltitude(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            BitArray Source_bits = new BitArray(2);
            Source_bits[0] = bits[13];
            Source_bits[1] = bits[14];
            int Source_int = Functions.BitArray2Int(Source_bits);

            data.SelectedAltitude_SAS = CAT21_Dict.SelectedAltitude_SAS_dict[bits[15]];
            data.SelectedAltitude_Source = CAT21_Dict.SelectedAltitude_Source_dict[Source_int];

            bits.Length = bits.Length - 3;

            double LSB = 25; // ft
            double Altitude = LSB * Functions.BitArray2Int(bits);
            data.SelectedAltitude_Altitude = Altitude;
        }

        // Data Item I021/148, Final State Selected Altitude
        private void FinalStateSelectedAltitude(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            data.FinalStateSelectedAltitude_MV = CAT21_Dict.FinalStateSelectedAltitude_dict[bits[15]];
            data.FinalStateSelectedAltitude_AH = CAT21_Dict.FinalStateSelectedAltitude_dict[bits[14]];
            data.FinalStateSelectedAltitude_AM = CAT21_Dict.FinalStateSelectedAltitude_dict[bits[13]];

            bits.Length = bits.Length - 3;

            double LSB = 25; // ft
            double Altitude = LSB * Functions.TwosComplement2Int_fromBitArray(bits);
            data.FinalStateSelectedAltitude_Altitude = Altitude;
        }

        // Data Item I021/150, Air Speed
        private void AirSpeed(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            data.AirSpeed_IM = CAT21_Dict.AirSpeed_IM[bits[15]];
            
            bits.Length = bits.Length - 1;

            if (bits[15] == true)
            {
                double Mach_LSB = 0.001;
                double Mach = Mach_LSB * Functions.BitArray2Int(bits);
                data.AirSpeed = Mach;

            }
            else
            {
                double IAS_LSB = Math.Pow(2, -14); // NM/s
                double IAS = IAS_LSB * Functions.BitArray2Int(bits);
                data.AirSpeed = IAS;
            }
        }

        // Data Item I021/151 True Airspeed
        private void TrueAirSpeed(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            data.TrueAirSpeed_RE = CAT21_Dict.RE_dict[bits[15]];

            bits.Length = bits.Length - 1;

            //double LSB = 1; // kt
            double TrueAirSpeed = Functions.BitArray2Int(bits);
            data.TrueAirSpeed = TrueAirSpeed;
        }

        // Data Item I021/152, Magnetic Heading
        private void MagneticHeading(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = 360 / Math.Pow(2, 16); // degrees
            double MagneticHeading = LSB * Functions.CombineBytes2Int(octets);
            data.MagneticHeading = MagneticHeading;
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

        // Data Item I021/165, Track Angle Rate
        private void TrackAngleRate(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = 1 / 32; // degrees/s
            double TrackAngleRate = LSB * Functions.TwosComplement2Int_fromBytes(octets);
            data.TrackAngleRate = TrackAngleRate;
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
            bool WS_bool = primary_bits[7];
            bool WD_bool = primary_bits[6];
            bool TMP_bool = primary_bits[5];
            bool TRB_bool = primary_bits[4];
            //data.MetInformation_WS = CAT21_Dict.MetInformation_WS_dict[WS_bool];
            //data.MetInformation_WD = CAT21_Dict.MetInformation_WD_dict[WD_bool];
            //data.MetInformation_TMP = CAT21_Dict.MetInformation_TMP_dict[TMP_bool];
            //data.MetInformation_TRB = CAT21_Dict.MetInformation_TRB_dict[TRB_bool];
            data.MetInformation_WS_subfield1 = WS_bool;
            data.MetInformation_WD_subfield2 = WD_bool;
            data.MetInformation_TMP_subfield3 = TMP_bool;
            data.MetInformation_TRB_subfield4 = TRB_bool;

            // We will need to save the index value in a variable
            int index = 1;

            if (primary_bits[0] == true)
            {
                if (WS_bool == true)
                {
                    //double WindSpeed_LSB = 1; // kt
                    byte[] WindSpeed_bytes = new byte[2] { octets[index+1], octets[index] }; // Reversed
                    double WindSpeed = Functions.CombineBytes2Int(WindSpeed_bytes);
                    data.MetInformation_WindSpeed = WindSpeed;
                    index += 2;
                }
                if (WD_bool == true)
                {
                    //double WindDirection_LSB = 1; // degree
                    byte[] WindDirection_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double WindDirection = Functions.CombineBytes2Int(WindDirection_bytes);
                    data.MetInformation_WindDirection = WindDirection;
                    index += 2;
                }
                if (TMP_bool == true)
                {
                    double Temperature_LSB = 0.25; // 'C
                    byte[] Temperature_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double Temperature = Temperature_LSB * Functions.CombineBytes2Int(Temperature_bytes);
                    data.MetInformation_Temperature = Temperature;
                    index += 2;
                }
                if (TRB_bool == true)
                {
                    int Turbulence = octets[index];
                    data.MetInformation_Turbulence = Turbulence;
                    index += 1;
                }
            }
            return index;
        }

        // Data Item I021/230, Roll Angle
        private void RollAngle(byte[] octets)
        {
            Array.Reverse(octets);

            double LSB = 0.01; // degrees
            double RollAngle = LSB * Functions.TwosComplement2Int_fromBytes(octets);
            data.RollAngle = RollAngle;
        }

        // Data Item I021/250, Mode S MB Data 
        private void ModeSMBdata(byte[] octets, int REP)
        {
            data.ModeSMBdata_REP = REP;
            for (int i = 0; i < REP; i++)
            {
                byte[] MBData_bytes = new byte[7] { octets[8 * i + 6], octets[8 * i + 5], octets[8 * i + 4], octets[8 * i + 3], octets[8 * i + 2], octets[8 * i + 1], octets[8 * i + 0] }; // Reversed

                BitArray BDS_bits = new BitArray(new byte[1] { octets[8 * i + 7] });

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

        // Data Item I021/260, ACAS Resolution Advisory Report
        private void ACASResolutionAdvisoryReport(byte[] octets)
        {
            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            BitArray TID_bits = new BitArray(26);
            BitArray ARA_bits = new BitArray(14);
            BitArray TYP_bits = new BitArray(5);
            BitArray RAC_bits = new BitArray(4);
            BitArray STYP_bits = new BitArray(3);
            BitArray TTI_bits = new BitArray(2);
            BitArray RAT_bits = new BitArray(1);
            BitArray MTE_bits = new BitArray(1);

            for (int i = 0; i < 26; i++)
            {
                TID_bits[i] = bits[i];
                if (i < 14)
                {
                    ARA_bits[i] = bits[i+34];
                    if (i < 5)
                    {
                        TYP_bits[i] = bits[i+51];
                        if (i < 4)
                        {
                            RAC_bits[i] = bits[i+30];
                            if (i < 3)
                            {
                                STYP_bits[i] = bits[i+48];
                                if (i < 2)
                                {
                                    TTI_bits[i] = bits[i+26];
                                    if (i < 1)
                                    {
                                        RAT_bits[i] = bits[i+29];
                                        MTE_bits[i] = bits[i+28];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            data.ACASResolutionAdvisoryReport_TYP = Functions.BitArray2Int(TYP_bits);
            data.ACASResolutionAdvisoryReport_STYP = Functions.BitArray2Int(STYP_bits);
            data.ACASResolutionAdvisoryReport_ARA = Functions.BitArray2Int(ARA_bits);
            data.ACASResolutionAdvisoryReport_RAC = Functions.BitArray2Int(RAC_bits);
            data.ACASResolutionAdvisoryReport_RAT = Functions.BitArray2Int(RAT_bits);
            data.ACASResolutionAdvisoryReport_MTE = Functions.BitArray2Int(MTE_bits);
            data.ACASResolutionAdvisoryReport_TTI = Functions.BitArray2Int(TTI_bits);
            data.ACASResolutionAdvisoryReport_TID = Functions.BitArray2Int(TID_bits);
        }

        // Data Item I021/271, Surface Capabilities and Characteristics
        private int SurfaceCapabilitiesAndCharacteristics(byte[] octets)
        {
            BitArray bits = new BitArray(octets);
            data.SurfaceCapabilitiesandCharacteristics_POA = CAT21_Dict.SurfaceCapabilitiesandCharacteristics_POA_dict[bits[5]];
            data.SurfaceCapabilitiesandCharacteristics_CDTI_S = CAT21_Dict.SurfaceCapabilitiesandCharacteristics_CDTI_S_dict[bits[4]];
            data.SurfaceCapabilitiesandCharacteristics_B2low = CAT21_Dict.SurfaceCapabilitiesandCharacteristics_B2LOW_dict[bits[3]];
            data.SurfaceCapabilitiesandCharacteristics_RAS = CAT21_Dict.SurfaceCapabilitiesandCharacteristics_RAS_dict[bits[2]];
            data.SurfaceCapabilitiesandCharacteristics_IDENT = CAT21_Dict.SurfaceCapabilitiesandCharacteristics_IDENT_dict[bits[1]];

            if (bits[0] == true)
            {
                data.SurfaceCapabilitiesandCharacteristics_FirstExtent_flag = true;

                BitArray LengthAndWidth_bits = new BitArray(4);
                LengthAndWidth_bits[0] = bits[8];
                LengthAndWidth_bits[1] = bits[9];
                LengthAndWidth_bits[2] = bits[10];
                LengthAndWidth_bits[3] = bits[11];

                int LengthAndWidth_int = Functions.BitArray2Int(LengthAndWidth_bits);
                data.SurfaceCapabilitiesandCharacteristics_LW = LengthAndWidth_int;
                
                return 2;
            }
            return 1;
        }

        // Data Item I021/295, Data Ages
        private int[] DataAges_primarySubfield(byte[] octets)
        {
            // First of all, we have to find which subfields will be present and which will be absent
            // Here we also count how many octets does the primary subfield have,
            // and also count how many octets we will have as Subfields #x
            int primarySubfield_numberOfOctets;

            BitArray primarySubfield_octet1_bits = new BitArray(new byte[1] { octets[0] });

            data.DataAges_subfields[0] = primarySubfield_octet1_bits[7];
            data.DataAges_subfields[1] = primarySubfield_octet1_bits[6];
            data.DataAges_subfields[2] = primarySubfield_octet1_bits[5];
            data.DataAges_subfields[3] = primarySubfield_octet1_bits[4];
            data.DataAges_subfields[4] = primarySubfield_octet1_bits[3];
            data.DataAges_subfields[5] = primarySubfield_octet1_bits[2];
            data.DataAges_subfields[6] = primarySubfield_octet1_bits[1];

            primarySubfield_numberOfOctets = 1;

            if (primarySubfield_octet1_bits[0] == true)
            {
                data.DataAges_FirstExtent_flag = true;

                BitArray primarySubfield_octet2_bits = new BitArray(new byte[1] { octets[1] });

                data.DataAges_subfields[7] = primarySubfield_octet2_bits[7];
                data.DataAges_subfields[8] = primarySubfield_octet2_bits[6];
                data.DataAges_subfields[9] = primarySubfield_octet2_bits[5];
                data.DataAges_subfields[10] = primarySubfield_octet2_bits[4];
                data.DataAges_subfields[11] = primarySubfield_octet2_bits[3];
                data.DataAges_subfields[12] = primarySubfield_octet2_bits[2];
                data.DataAges_subfields[13] = primarySubfield_octet2_bits[1];

                primarySubfield_numberOfOctets = 2;

                if (primarySubfield_octet2_bits[0] == true)
                {
                    data.DataAges_SecondExtent_flag = true;

                    BitArray primarySubfield_octet3_bits = new BitArray(new byte[1] { octets[2] });

                    data.DataAges_subfields[14] = primarySubfield_octet3_bits[7];
                    data.DataAges_subfields[15] = primarySubfield_octet3_bits[6];
                    data.DataAges_subfields[16] = primarySubfield_octet3_bits[5];
                    data.DataAges_subfields[17] = primarySubfield_octet3_bits[4];
                    data.DataAges_subfields[18] = primarySubfield_octet3_bits[3];
                    data.DataAges_subfields[19] = primarySubfield_octet3_bits[2];
                    data.DataAges_subfields[20] = primarySubfield_octet3_bits[1];

                    primarySubfield_numberOfOctets = 3;

                    if (primarySubfield_octet3_bits[0] == true)
                    {
                        data.DataAges_ThirdExtent_flag = true;

                        BitArray primarySubfield_octet4_bits = new BitArray(new byte[1] { octets[3] });

                        data.DataAges_subfields[21] = primarySubfield_octet4_bits[7];
                        data.DataAges_subfields[22] = primarySubfield_octet4_bits[6];

                        primarySubfield_numberOfOctets = 4;
                    }
                }
            }


            // Now that we know which subfields are present, and
            // we also know the number of octets the primary subfield has,
            // We can calculate the number of bytes DataAges() will have.
            int subfields_numberOfOctets = 0;

            for (int i = 0; i < primarySubfield_numberOfOctets; i++)
            {
                BitArray octetX_bits = new BitArray(new byte[1] { octets[i] });
                for (int j = 1; j < octetX_bits.Length; j++)
                {
                    if (octetX_bits[j] == true)
                    {
                        subfields_numberOfOctets++;
                    }
                }
            }

            // numberOfOctets[0] --> number of octets of the primary subfield
            // numberOfOctets[1] --> number of octets of the subfields
            int[] numberOfOctets = new int[2] { primarySubfield_numberOfOctets, subfields_numberOfOctets };

            return numberOfOctets;
        }

        // Data Item I021/295, Data Ages
        private void DataAges_subfields(byte[] octets)
        {
            double LSB = 0.1; // s

            for (int i = 0, j = 0; i < data.DataAges_subfields.Length; i++)
            {
                if (data.DataAges_subfields[i] == true)
                {
                    data.DataAges[i] = LSB * octets[j];
                    j++;
                }
                else
                {
                    data.DataAges[i] = 0;
                }
            }
        }

        // Data Item I021 / 400, Receiver ID
        private void ReceiverID(byte octet1)
        {
            data.ReceiverID = octet1;
        }


    }
}
