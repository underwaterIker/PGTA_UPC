using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ClassLibrary
{
    public class Decodification
    {
        // CAT number
        public int CAT { get; set; }

        // LENGTH of the message (number of bytes of the message)
        public int LENGTH { get; set; }

        // Number of Data Items
        public int numberOfDataItems { get; set; }

        // Array with the Field Type numbers that the message includes
        public List<int> fieldTypes { get; set; } = new List<int>();

        // FSPEC bytes
        public byte[] FSPEC_bytes { get; set; }

        // Data List
        public List<IList> data_list { get; set; } = new List<IList>();
        //public List<int[]> index_list = new List<int[]>();


        // CONSTRUCTOR
        public Decodification(int cat, int length, byte[] message)
        {
            this.CAT = cat;
            this.LENGTH = length;

            if (cat == 10)
            {
                CAT10_Decodification(message);
            }
            else if (cat == 21)
            {
                CAT21_Decodification(message);
            }
            
        }

        public Decodification(int cat, int length)
        {
            this.CAT = cat;
            this.LENGTH = length;
        }


        // METHODS
        // CAT10 Decodification function
        private void CAT10_Decodification(byte[] message)
        {
            // Now we need to get the FSPEC bytes
            byte[] uncertain_FSPEC_bytes = new byte[4] { message[0], message[1], message[2], message[3] };
            byte[] FSPEC_bytes = FSPEC(uncertain_FSPEC_bytes);

            // Once we have the FSPEC bytes, we can start decoding
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
            this.numberOfDataItems = this.fieldTypes.Count;
        }

        // CAT21 Decodification function
        private void CAT21_Decodification(byte[] message)
        {
            // Now we need to get the FSPEC bytes
            byte[] uncertain_FSPEC_bytes = new byte[7] { message[0], message[1], message[2], message[3], message[4], message[5], message[6] };
            byte[] FSPEC_bytes = FSPEC(uncertain_FSPEC_bytes);

            // Once we have the FSPEC bytes, we can start decoding
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

                            int numBytes = TargetReportDescriptor_cat21(bytes);
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
                            PositionWGS84Coordinates_cat21(bytes);
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
                            TargetAddress_cat21(bytes);
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
                            Mode3ACodeOctalRepresentation_cat21(bytes);
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
                            TargetIdentification_cat21(bytes);
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
                            if (bytesAvailable < (3 + 15 * REP))
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
                            ModeSMBData(bytes, REP);
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
                            List<byte> bytes = new List<byte>();

                            int bytesAvailable = message.Length - byteSum_index;

                            for (int j = 0; j < bytesAvailable && j<27; j++)
                            {
                                bytes.Add(message[byteSum_index + j]);
                            }

                            int numBytes = DataAges(bytes);
                            byteSum_index += numBytes;
                        }

                        break;

                }
            }
            this.numberOfDataItems = this.fieldTypes.Count;
        }

        // FSPEC, returns a byte array with the bytes of the FSPEC
        private byte[] FSPEC(byte[] octets)
        {
            // Calculate the number of bytes that the FSPEC has
            int FSPEC_numberOfBytes = 1;
            for (int i = 0; i < octets.Length; i++)
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

        // --------------------------------------------------------------------------------------------------------------------------
        
        // CAT10 METHODS

        // Data Item I010/000, Message Type
        private void MessageType(byte octet1)
        {
            this.fieldTypes.Add(0);

            string messageType = Dictionaries.MessageType_dict[octet1];

            data_list.Add(new string[1] { messageType });
        }

        // Data Item I010/010, Data Source Identifier
        private void DataSourceIdentifier(byte[] octets)
        {
            this.fieldTypes.Add(10);

            int SAC = octets[0];
            int SIC = octets[1];
            
            data_list.Add(new int[2] { SAC, SIC });
        }

        // Data Item I010/020, Target Report Descriptor
        private int TargetReportDescriptor(byte[] octets)
        {
            this.fieldTypes.Add(20);

            BitArray bits = new BitArray(octets);

            BitArray TYP_bits = new BitArray(3);
            TYP_bits[0] = bits[5];
            TYP_bits[1] = bits[6];
            TYP_bits[2] = bits[7];
            int TYP_int = Functions.BitArray2Int(TYP_bits);

            string TYP = Dictionaries.TargetReportDescriptor_TYP_dict[TYP_int];
            string DCR = Dictionaries.TargetReportDescriptor_DCR_dict[bits[4]];
            string CHN = Dictionaries.TargetReportDescriptor_CHN_dict[bits[3]];
            string GBS = Dictionaries.TargetReportDescriptor_GBS_dict[bits[2]];
            string CRT = Dictionaries.TargetReportDescriptor_CRT_dict[bits[1]];

            if (bits[0] == true)
            {
                BitArray LOP_bits = new BitArray(2);
                LOP_bits[0] = bits[11];
                LOP_bits[1] = bits[12];
                int LOP_int = Functions.BitArray2Int(LOP_bits);

                BitArray TOT_bits = new BitArray(2);
                TOT_bits[0] = bits[9];
                TOT_bits[1] = bits[10];
                int TOT_int = Functions.BitArray2Int(TOT_bits);

                string SIM = Dictionaries.TargetReportDescriptor_SIM_dict[bits[15]];
                string TST = Dictionaries.TargetReportDescriptor_TST_dict[bits[14]];
                string RAB = Dictionaries.TargetReportDescriptor_RAB_dict[bits[13]];
                string LOP = Dictionaries.TargetReportDescriptor_LOP_dict[LOP_int];
                string TOT = Dictionaries.TargetReportDescriptor_TOT_dict[TOT_int];

                if(bits[8] == true)
                {
                    string SPI = Dictionaries.TargetReportDescriptor_SPI_dict[bits[23]];

                    data_list.Add(new string[11] { TYP, DCR, CHN, GBS, CRT, SIM, TST, RAB, LOP, TOT, SPI });
                    return 3;
                }
                data_list.Add(new string[10] { TYP, DCR, CHN, GBS, CRT, SIM, TST, RAB, LOP, TOT });
                return 2;
            }
            data_list.Add(new string[5] { TYP, DCR, CHN, GBS, CRT });
            return 1;
        }

        //Data Item I010/040, Measured Position in Polar Co-ordinates
        private void MeasuredPositionPolarCoordinates(byte[] octets)
        {
            this.fieldTypes.Add(40);

            double LSB_RHO = 1; // m
            double LSB_theta = (double)(360 / Math.Pow(2, 16)); // degrees

            byte[] RHO_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] THETA_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double RHO = LSB_RHO * Functions.CombineBytes2Int(RHO_bytes);
            double THETA = LSB_theta * Functions.CombineBytes2Int(THETA_bytes);

            data_list.Add(new double[2] {RHO, THETA});
        }

        // Data Item I010/041, Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates(byte[] octets)
        {
            this.fieldTypes.Add(41);

            double LSB = (double)(180 / Math.Pow(2, 31)); // degrees

            byte[] latitude_bytes = new byte[4] { octets[3], octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitude_bytes = new byte[4] { octets[7], octets[6], octets[5], octets[4] }; // Reversed

            double latitude  = LSB * Functions.TwosComplement2Int_fromBytes(latitude_bytes);
            double longitude = LSB * Functions.TwosComplement2Int_fromBytes(longitude_bytes);

            data_list.Add(new double[2] { latitude, longitude });
        }

        // Data Item I010/042, Position in Cartesian Co-ordinates
        private void PositionCartesianCoordinates(byte[] octets)
        {
            this.fieldTypes.Add(42);

            double LSB = 1; // m

            byte[] x_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] y_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double x = LSB * Functions.TwosComplement2Int_fromBytes(x_bytes);
            double y = LSB * Functions.TwosComplement2Int_fromBytes(y_bytes);

            data_list.Add(new double[2] { x, y });
        }

        // Data Item I010/060, Mode-3/A Code in Octal Representation
        private void Mode3ACodeOctalRepresentation(byte[] octets)
        {
            this.fieldTypes.Add(60);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // BE CAREFUL WITH BITS AND BYTES ORDER !!!!!!!!!
            string V = Dictionaries.Mode3ACodeV_and_FlightLevelV_dict[bits[15]];
            string G = Dictionaries.Mode3ACodeG_and_FlightLevelG_dict[bits[14]];
            string L = Dictionaries.Mode3ACodeL_dict[bits[13]];

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
            string Reply = A + B + C + D;

            data_list.Add(new string[4] { V, G, L, Reply });
        }

        // Data Item I010/090, Flight Level in Binary Representation
        private void FlightLevelBinaryRepresentation(byte[] octets)
        {
            this.fieldTypes.Add(90);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            string V = Dictionaries.Mode3ACodeV_and_FlightLevelV_dict[bits[15]];
            string G = Dictionaries.Mode3ACodeG_and_FlightLevelG_dict[bits[14]];

            bits.Length = bits.Length - 2;

            double LSB = (double)1 / 4; // FL
            double FL = LSB * Functions.TwosComplement2Int_fromBitArray(bits);

            data_list.Add(new object[3] { V, G, FL });
        }

        // Data Item I010/091, Measured Height
        private void MeasuredHeight(byte[] octets)
        {
            this.fieldTypes.Add(91);

            double LSB = (double)6.25; // ft
            byte[] measuredHeight_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            double measuredHeight = LSB * Functions.TwosComplement2Int_fromBytes(measuredHeight_bytes);

            data_list.Add(new double[1] { measuredHeight });
        }

        //Data Item I010/131, Amplitude of Primary Plot
        private void AmplitudePrimayPlot(byte octet1)
        {
            this.fieldTypes.Add(131);

            data_list.Add(new int[1] { octet1 });
        }

        // Data Item I010/140: Time of Day
        private void TimeofDay(byte[] octets)
        {
            this.fieldTypes.Add(140);

            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfDay = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { timeOfDay });
        }

        // Data Item I010/161: Track Number
        private void TrackNumber(byte[] octets)
        {
            this.fieldTypes.Add(161);

            Array.Reverse(octets);

            int TrackNumber = Functions.CombineBytes2Int(octets);

            data_list.Add(new int[1] { TrackNumber });
        }

        // Data Item I010/170, Track Status
        private int TrackStatus(byte[] octets)
        {
            this.fieldTypes.Add(170);

            BitArray bits = new BitArray(octets);

            BitArray CST_bits = new BitArray(2);
            CST_bits[0] = bits[4];
            CST_bits[1] = bits[5];
            int CST_int = Functions.BitArray2Int(CST_bits);

            string CNF = Dictionaries.TrackStatus_CNF_dict[bits[7]];
            string TRE = Dictionaries.TrackStatus_TRE_dict[bits[6]];
            string CST = Dictionaries.TrackStatus_CST_dict[CST_int];
            string MAH = Dictionaries.TrackStatus_MAH_dict[bits[3]];
            string TCC = Dictionaries.TrackStatus_TCC_dict[bits[2]];
            string STH = Dictionaries.TrackStatus_STH_dict[bits[1]];

            if (bits[0] == true)
            {
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

                string TOM = Dictionaries.TrackStatus_TOM_dict[TOM_int];
                string DOU = Dictionaries.TrackStatus_DOU_dict[DOU_int];
                string MRS = Dictionaries.TrackStatus_MRS_dict[MRS_int];

                if (bits[8] == true)
                {
                    string GHO = Dictionaries.TrackStatus_GHO_dict[bits[23]];

                    data_list.Add(new string[10] { CNF, TRE, CST, MAH, TCC, STH, TOM, DOU, MRS, GHO });
                    return 3;
                }
                data_list.Add(new string[9] { CNF, TRE, CST, MAH, TCC, STH, TOM, DOU, MRS });
                return 2;
            }
            data_list.Add(new string[6] { CNF, TRE, CST, MAH, TCC, STH });
            return 1;
        }

        // Data Item I010/200, Calculated Track Velocity in Polar Co-ordinates
        private void CalculatedTrackVelocityPolarCoordinates(byte[] octets)
        {
            this.fieldTypes.Add(200);

            double LSB_GroundSpeed = (double)0.22; // kt
            double LSB_TrackAngle = (double)(360 / Math.Pow(2, 16)); // degrees

            byte[] GroundSpeed_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] TrackAngle_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double GroundSpeed = LSB_GroundSpeed * Functions.TwosComplement2Int_fromBytes(GroundSpeed_bytes);
            double TrackAngle = LSB_TrackAngle * Functions.TwosComplement2Int_fromBytes(TrackAngle_bytes);

            data_list.Add(new double[2] { GroundSpeed, TrackAngle });
        }

        // Data Item I010/202, Calculated Track Velocity in Cartesian Co-ordinates
        private void CalculatedTrackVelocityCartesianCoordinates(byte[] octets)
        {
            this.fieldTypes.Add(202);

            double LSB = (double)0.25; // m/s

            byte[] Vx_bytes = new byte[2] { octets[1], octets[0] }; // Reversed
            byte[] Vy_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double Vx = LSB * Functions.TwosComplement2Int_fromBytes(Vx_bytes);
            double Vy = LSB * Functions.TwosComplement2Int_fromBytes(Vy_bytes);

            data_list.Add(new double[2] { Vx, Vy });
        }

        // Data Item I010/210, Calculated Acceleration
        private void CalculatedAcceleration(byte[] octets)
        {
            this.fieldTypes.Add(210);

            double LSB = (double)0.25; // m/(s^2)

            byte[] Ax_bytes = new byte[1] { octets[0] }; // Reversed (no need to reverse, array of length 1)
            byte[] Ay_bytes = new byte[1] { octets[1] }; // Reversed (no need to reverse, array of length 1)

            double Ax = LSB * Functions.TwosComplement2Int_fromBytes(Ax_bytes);
            double Ay = LSB * Functions.TwosComplement2Int_fromBytes(Ay_bytes);

            data_list.Add(new double[2] { Ax, Ay });
        }

        // Data Item I010/220, Target Address
        private void TargetAddress(byte[] octets)
        {
            this.fieldTypes.Add(220);

            byte[] TargetAddress_bytes = new byte[3] { octets[2], octets[1], octets[0] }; // Reversed
            int TargetAddress_int = Functions.CombineBytes2Int(TargetAddress_bytes);
            string TargetAddress = TargetAddress_int.ToString("X");

            data_list.Add(new string[1] { TargetAddress });
        }

        // Data Item I010/245, Target Identification
        private void TargetIdentification(byte[] octets)
        {
            this.fieldTypes.Add(245);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // STI
            BitArray STI_bits = new BitArray(2);
            STI_bits[0] = bits[54];
            STI_bits[1] = bits[55];
            int STI_int = Functions.BitArray2Int(STI_bits);
            string STI = Dictionaries.TartgetIdentificationSTI_dict[STI_int];

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

            string char8 = Dictionaries.TargetIdentificationCharacters_dict[char8_int];
            string char7 = Dictionaries.TargetIdentificationCharacters_dict[char7_int];
            string char6 = Dictionaries.TargetIdentificationCharacters_dict[char6_int];
            string char5 = Dictionaries.TargetIdentificationCharacters_dict[char5_int];
            string char4 = Dictionaries.TargetIdentificationCharacters_dict[char4_int];
            string char3 = Dictionaries.TargetIdentificationCharacters_dict[char3_int];
            string char2 = Dictionaries.TargetIdentificationCharacters_dict[char2_int];
            string char1 = Dictionaries.TargetIdentificationCharacters_dict[char1_int];

            string Characters = char1 + char2 + char3 + char4 + char5 + char6 + char7 + char8;

            data_list.Add(new string[2] { STI, Characters });
        }

        // Data Item I010/250, Mode S MB Data
        private void ModeSMBData(byte[] octets, int REP)
        {
            this.fieldTypes.Add(250);

            List<int> list = new List<int>();

            list.Add(REP);

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

                list.Add(MBData);
                list.Add(BDS1);
                list.Add(BDS2);
            }

            data_list.Add(list);
        }

        // Data Item I010/270, Target Size & Orientation
        private int TargetSizeAndOrientation(byte[] octets)
        {
            this.fieldTypes.Add(270);

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

            if (bits[0] == true)
            {
                // Orientation
                double LSB_Orientation = (double)360 / 128; // degrees
                double Orientation = LSB_Orientation * Functions.BitArray2Int(Orientation_bits);

                if (bits[8] == true)
                {
                    // Width
                    int LSB_Width = 1; // m
                    int Width = LSB_Width * Functions.BitArray2Int(Width_bits);

                    data_list.Add(new double[3] { Length, Orientation, Width });
                    return 3;
                }
                data_list.Add(new double[2] { Length, Orientation });
                return 2;
            }
            data_list.Add(new double[1] { Length });
            return 1;
        }

        // Data Item I010/280, Presence
        private void Presence(byte[] octets, int REP)
        {
            this.fieldTypes.Add(280);

            List<double> list = new List<double>();

            list.Add(REP);

            int LSB_DRHO = 1; // m
            double LSB_DTHETA = (double)0.15; //degrees

            for (int i = 0; i < REP; i++)
            {
                int DRHO = LSB_DRHO * octets[2*i];
                double DTHETA = LSB_DTHETA * octets[2*i + 1];

                list.Add(DRHO);
                list.Add(DTHETA);
            }

            data_list.Add(list);
        }

        // Data Item I010/300, Vehicle Fleet Identification
        private void VehicleFleetIdentification(byte octet1)
        {
            this.fieldTypes.Add(300);

            string VFI = Dictionaries.VehicleFleetIdentification_VFI_dict[octet1];

            data_list.Add(new string[1] { VFI });
        }

        // Data Item I010/310, Pre-programmed Message
        private void PreprogrammedMessage(byte octet1)
        {
            this.fieldTypes.Add(310);

            BitArray bits = new BitArray(new byte[1] { octet1 });

            string TRB = Dictionaries.PreprogrammedMessage_TRB_dict[bits[7]];

            //bits.Length = bits.Length - 1;
            bits[7] = false;

            string MSG = Dictionaries.PreprogrammedMessage_MSG_dict[Functions.BitArray2Int(bits)];

            data_list.Add(new string[2] { TRB, MSG });
        }

        // Data Item I010/500, Standard Deviation of Position
        private void StandardDeviationPosition(byte[] octets)
        {
            this.fieldTypes.Add(500);

            double LSB = (double)0.25; // m and (m^2)

            byte[] Covariance_bytes = new byte[2] { octets[3], octets[2] }; // Reversed

            double SDx = LSB * octets[0];
            double SDy = LSB * octets[1];
            double Covariance = LSB * Functions.TwosComplement2Int_fromBytes(Covariance_bytes);

            data_list.Add(new double[3] { SDx, SDy, Covariance });
        }

        // Data Item I010/550, System Status
        private void SystemStatus(byte octet1)
        {
            this.fieldTypes.Add(550);

            BitArray bits = new BitArray(new byte[1] { octet1 });

            BitArray NOGO_bits = new BitArray(2);
            NOGO_bits[0] = bits[6];
            NOGO_bits[1] = bits[7];
            int NOGO_int = Functions.BitArray2Int(NOGO_bits);

            string NOGO = Dictionaries.SystemStatus_NOGO_dict[NOGO_int];
            string OVL = Dictionaries.SystemStatus_OVL_dict[bits[5]];
            string TSV = Dictionaries.SystemStatus_TSV_dict[bits[4]];
            string DIV = Dictionaries.SystemStatus_DIV_dict[bits[3]];
            string TTF = Dictionaries.SystemStatus_TTF_dict[bits[2]];

            data_list.Add(new string[5] { NOGO, OVL, TSV, DIV, TTF });
        }

        // --------------------------------------------------------------------------------------------------------------------------

        // CAT21 METHODS

        // Data Item I021/008, Aircraft Operational Status
        private void AircraftOperationalStatus(byte octet1)
        {
            this.fieldTypes.Add(8);

            BitArray bits = new BitArray(new byte[1] { octet1 });

            BitArray TC_bits = new BitArray(2);
            TC_bits[0] = bits[5];
            TC_bits[1] = bits[6];
            int TC_int = Functions.BitArray2Int(TC_bits);

            string RA = Dictionaries.AircrafOperationalStatus_RA_dict[bits[7]];
            string TC = Dictionaries.AircraftOperationalStatus_TC_dict[TC_int];
            string TS = Dictionaries.AircraftOperationalStatus_TS_dict[bits[4]];
            string ARV = Dictionaries.AircraftOperationalStatus_ARV_dict[bits[3]];
            string CDTI_A = Dictionaries.AircraftOperationalStatus_CDTI_dict[bits[2]];
            string TCAS = Dictionaries.AircraftOperationalStatus_TCAS_dict[bits[1]];
            string SA = Dictionaries.AircraftOperationalStatus_SA_dict[bits[0]];

            data_list.Add(new string[7] { RA, TC, TS, ARV, CDTI_A, TCAS, SA });
        }

        // Data Item I021/010, Data Source Identification 
        private void DataSourceIdentification(byte[] octetos)
        {
            this.fieldTypes.Add(10);

            data_list.Add(new int[2] { octetos[0], octetos[1] });
        }

        // Data Item I021/015, Service Identification
        private void ServiceIdentification(byte octet1)
        {
            this.fieldTypes.Add(15);

            data_list.Add(new int[1] { octet1 });
        }

        // Data Item I021/016, Service Management
        private void ServiceManagement(byte octet1)
        {
            this.fieldTypes.Add(16);

            double LSB = (double)0.5; // s
            double ServiceManagement = LSB * octet1;

            data_list.Add(new double[1] { ServiceManagement });
        }

        // Data Item I021/020, Emitter Category
        private void EmitterCategory(byte octet1)
        {
            this.fieldTypes.Add(20);

            data_list.Add(new string[1] { Dictionaries.EmitterCategory_dict[octet1] });
        }

        // Data Item I021/040, Target Report Descriptor
        private int TargetReportDescriptor_cat21(byte[] octets)
        {
            this.fieldTypes.Add(40);

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

            string ATP = Dictionaries.TargetReportDescriptor_ATP_dict[ATP_int];
            string ARC = Dictionaries.TargetReportDescriptor_ARC_dict[ARC_int];
            string RC = Dictionaries.TargetReportDescriptor_RC_dict[bits[2]];
            string RAB = Dictionaries.TargetReportDescriptor_RAB_dict[bits[1]];

            if (bits[0] == true)
            {
                BitArray CL_bits = new BitArray(2);
                CL_bits[0] = bits[9];
                CL_bits[1] = bits[10];
                int CL_int = Functions.BitArray2Int(CL_bits);

                string DCR = Dictionaries.TargetReportDescriptor_DCR_dict[bits[15]];
                string GBS = Dictionaries.TargetReportDescriptor_GBS_cat21_dict[bits[14]];
                string SIM = Dictionaries.TargetReportDescriptor_SIM_dict[bits[13]];
                string TST = Dictionaries.TargetReportDescriptor_TST_dict[bits[12]];
                string SAA = Dictionaries.TargetReportDescriptor_SAA_dict[bits[11]];
                string CL = Dictionaries.TargetReportDescriptor_CL_dict[CL_int];

                if (bits[8] == true)
                {
                    string IPC = Dictionaries.TargetReportDescriptor_IPC_dict[bits[21]];
                    string NOGO = Dictionaries.TargetReportDescriptor_NOGO_dict[bits[20]];
                    string CPR = Dictionaries.TargetReportDescriptor_CPR_dict[bits[19]];
                    string LDPJ = Dictionaries.TargetReportDescriptor_LDPJ_dict[bits[18]];
                    string RCF = Dictionaries.TargetReportDescriptor_RCF_dict[bits[17]];

                    data_list.Add(new string[15] { ATP, ARC, RC, RAB, DCR, GBS, SIM, TST, SAA, CL, IPC, NOGO, CPR, LDPJ, RCF });
                    return 3;
                }
                data_list.Add(new string[10] { ATP, ARC, RC, RAB, DCR, GBS, SIM, TST, SAA, CL });
                return 2;
            }
            data_list.Add(new string[4] { ATP, ARC, RC, RAB });
            return 1;
        }

        // Data Item I021/070, Mode 3/A Code in Octal Representation
        private void Mode3ACodeOctalRepresentation_cat21(byte[] octets)
        {
            this.fieldTypes.Add(70);

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
            string Mode3ACode_Reply = A + B + C + D;

            data_list.Add(new string[1] { Mode3ACode_Reply });
        }

        // Data Item I021/071, Time of Applicability for Position
        private void TimeOfApplicabilityForPosition(byte[] octets)
        {
            this.fieldTypes.Add(71);

            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfApplicabilityForPosition = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { timeOfApplicabilityForPosition });
        }

        // Data Item I021/072, Time of Applicability for Velocity
        private void TimeOfApplicabilityForVelocity(byte[] octets)
        {
            this.fieldTypes.Add(72);

            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfApplicabilityForVelocity = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { timeOfApplicabilityForVelocity });
        }

        // Data Item I021/073, Time of Message Reception for Position
        private void TimeOfMessageReceptionForPosition(byte[] octets)
        {
            this.fieldTypes.Add(73);

            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfMessageReceptionForPosition = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { timeOfMessageReceptionForPosition });
        }

        // Data Item I021/074, Time of Message Reception of Position–High Precision
        private void TimeOfMessageReceptionOfPosition_HighPrecision(byte[] octets)
        {
            this.fieldTypes.Add(74);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // Full Second Indication (FSI)
            BitArray FSI_bits = new BitArray(2);
            FSI_bits[0] = bits[30];
            FSI_bits[1] = bits[31];
            int FSI_int = Functions.BitArray2Int(FSI_bits);

            string TimeOfMessageReceptionOfPosition_HighPrecision_FSI = Dictionaries.TimeOfMessageReceptionOfPosition_HighPrecision_FSI_dict[FSI_int];

            // Fractional part of the time of message reception for position in the ground station.
            bits.Length = bits.Length - 2;

            decimal LSB = (decimal)Math.Pow(2, -30); // s (0.9313 ns)
            decimal timeOfMessageReceptionOfPosition_HighPrecision = LSB * Functions.BitArray2Int(bits);

            data_list.Add(new object[2] { TimeOfMessageReceptionOfPosition_HighPrecision_FSI, timeOfMessageReceptionOfPosition_HighPrecision });
        }

        // Data Item I021/075, Time of Message Reception for Velocity
        private void TimeOfMessageReceptionForVelocity(byte[] octets)
        {
            this.fieldTypes.Add(75);

            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfMessageReceptionForVelocity = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { timeOfMessageReceptionForVelocity });
        }

        // Data Item I021/076, Time of Message Reception of Velocity–High Precision
        private void TimeOfMessageReceptionOfVelocity_HighPrecision(byte[] octets)
        {
            this.fieldTypes.Add(76);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            // Full Second Indication (FSI)
            BitArray FSI_bits = new BitArray(2);
            FSI_bits[0] = bits[30];
            FSI_bits[1] = bits[31];
            int FSI_int = Functions.BitArray2Int(FSI_bits);

            string TimeOfMessageReceptionOfVelocity_HighPrecision_FSI = Dictionaries.TimeOfMessageReceptionOfVelocity_HighPrecision_FSI_dict[FSI_int];

            // Fractional part of the time of message reception for position in the ground station.
            bits.Length = bits.Length - 2;

            decimal LSB = (decimal)Math.Pow(2, -30); // s (0.9313 ns)
            decimal timeOfMessageReceptionOfVelocity_HighPrecision = LSB * Functions.BitArray2Int(bits);

            data_list.Add(new object[2] { TimeOfMessageReceptionOfVelocity_HighPrecision_FSI, timeOfMessageReceptionOfVelocity_HighPrecision });
        }

        // Data Item I021/077, Time of ASTERIX Report Transmission
        private void TimeOfASTERIXReportTransmission(byte[] octets)
        {
            this.fieldTypes.Add(77);

            Array.Reverse(octets);

            double LSB = (double)1 / 128; // s
            double timeOfAsterixReportTransmission = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { timeOfAsterixReportTransmission });
        }

        // Data Item I021/080, Target Address
        private void TargetAddress_cat21(byte[] octets)
        {
            this.fieldTypes.Add(80);

            byte[] TargetAddress_bytes = new byte[3] { octets[2], octets[1], octets[0] }; // Reversed
            int TargetAddress_int = Functions.CombineBytes2Int(TargetAddress_bytes);
            string TargetAddress = TargetAddress_int.ToString("X");

            data_list.Add(new string[1] { TargetAddress });
        }

        // Data Item I021/090, Quality Indicators
        private int QualityIndicators(byte[] octets)
        {
            this.fieldTypes.Add(90);

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

            if (bits[0] == true)
            {
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

                if (bits[8] == true)
                {
                    BitArray SDA_bits = new BitArray(2);
                    SDA_bits[0] = bits[19];
                    SDA_bits[1] = bits[20];
                    int SDA_int = Functions.BitArray2Int(SDA_bits);

                    BitArray GVA_bits = new BitArray(2);
                    GVA_bits[0] = bits[17];
                    GVA_bits[1] = bits[18];
                    int GVA_int = Functions.BitArray2Int(GVA_bits);

                    string SILsupplement = Dictionaries.QualityIndicators_SILsupplement_dict[bits[21]];

                    if (bits[16] == true)
                    {
                        BitArray PIC_bits = new BitArray(4);
                        PIC_bits[0] = bits[28];
                        PIC_bits[1] = bits[29];
                        PIC_bits[2] = bits[30];
                        PIC_bits[3] = bits[31];
                        int PIC_int = Functions.BitArray2Int(PIC_bits);

                        data_list.Add(new object[9] { NUCr_or_NACv_int, NUCp_or_NIC_int, NICbaro_int, SIL_int, NACp_int, SILsupplement, SDA_int, GVA_int, PIC_int });
                        return 4;
                    }
                    data_list.Add(new object[8] { NUCr_or_NACv_int, NUCp_or_NIC_int, NICbaro_int, SIL_int, NACp_int, SILsupplement, SDA_int, GVA_int });
                    return 3;
                }
                data_list.Add(new object[5] { NUCr_or_NACv_int, NUCp_or_NIC_int, NICbaro_int, SIL_int, NACp_int });
                return 2;
            }
            data_list.Add(new object[2] { NUCr_or_NACv_int, NUCp_or_NIC_int });
            return 1;
        }

        // Data Item I021/110, Trajectory Intent (Get REP)
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
            this.fieldTypes.Add(110);

            List<object> list = new List<object>();

            list.Add(REP);

            BitArray primary_bits = new BitArray(new byte[1] { octets[0] });

            // We will need to save the index value in a variable
            int index = 1;

            if (primary_bits[0] == true)
            {
                if (primary_bits[7] == true)
                {
                    BitArray subfield1_bits = new BitArray(new byte[1] { octets[index] });

                    string NAV = Dictionaries.TrajectoryIntent_NAV_dict[subfield1_bits[7]];
                    string NVB = Dictionaries.TrajectoryIntent_NVB_dict[subfield1_bits[6]];

                    list.Add(NAV);
                    list.Add(NVB);

                    index += 1;
                }
                if (primary_bits[6] == true)
                {
                    index += 1; // for the REP byte

                    for (int i = 0; i < REP; i++)
                    {
                        // We save the bytes from subfield 2 in a byte array
                        byte[] subfield2_bytes = new byte[15] { octets[(index)], octets[(index + 1)], octets[(index + 2)], octets[(index + 3)], octets[(index + 4)], octets[(index + 5)], octets[(index + 6)], octets[(index + 7)], octets[(index + 8)], octets[(index + 9)], octets[(index + 10)], octets[(index + 11)], octets[(index + 12)], octets[(index + 13)], octets[(index + 14)] };

                        // Octet no. 2
                        BitArray subfield2_byte0_bits = new BitArray(new byte[1] { subfield2_bytes[0] });
                        string TCA = Dictionaries.TrajectoryIntent_TCA_dict[subfield2_byte0_bits[7]];
                        string NC = Dictionaries.TrajectoryIntent_NC_dict[subfield2_byte0_bits[6]];
                        subfield2_byte0_bits.Length = subfield2_byte0_bits.Length - 2;
                        int TCP = Functions.BitArray2Int(subfield2_byte0_bits);

                        list.Add(TCA);
                        list.Add(NC);
                        list.Add(TCP);

                        // Octet no. 3 & 4
                        double Altitude_LSB = 10; // ft
                        byte[] Altitude_bytes = new byte[2] { subfield2_bytes[2], subfield2_bytes[1] }; // Reversed
                        double Altitude = Altitude_LSB * Functions.TwosComplement2Int_fromBytes(Altitude_bytes);
                        
                        list.Add(Altitude);

                        // Octet no. 5 & 6 & 7
                        double LatAndLongWGS84_LSB = (double)(180 / Math.Pow(2, 23)); // ft
                        byte[] LatitudeWGS84_bytes = new byte[3] { subfield2_bytes[5], subfield2_bytes[4], subfield2_bytes[3] }; // Reversed
                        double LatitudeWGS84 = LatAndLongWGS84_LSB * Functions.TwosComplement2Int_fromBytes(LatitudeWGS84_bytes);
                        
                        list.Add(LatitudeWGS84);

                        // Octet no. 8 & 9 & 10
                        byte[] LongitudeWGS84_bytes = new byte[3] { subfield2_bytes[8], subfield2_bytes[7], subfield2_bytes[6] }; // Reversed
                        double LongitudeWGS84 = LatAndLongWGS84_LSB * Functions.TwosComplement2Int_fromBytes(LongitudeWGS84_bytes);
                        list.Add(LongitudeWGS84);

                        // Octet no. 11
                        BitArray subfield2_byte9_bits = new BitArray(new byte[1] { subfield2_bytes[9] });
                        BitArray PointType_bits = new BitArray(4);
                        PointType_bits[0] = subfield2_byte9_bits[4];
                        PointType_bits[1] = subfield2_byte9_bits[5];
                        PointType_bits[2] = subfield2_byte9_bits[6];
                        PointType_bits[3] = subfield2_byte9_bits[7];
                        int PointType_int = Functions.BitArray2Int(PointType_bits);
                        string PointType = Dictionaries.TrajectoryIntent_PointType_dict[PointType_int];
                        BitArray TD_bits = new BitArray(2);
                        TD_bits[0] = subfield2_byte9_bits[2];
                        TD_bits[1] = subfield2_byte9_bits[3];
                        int TD_int = Functions.BitArray2Int(TD_bits);
                        string TD = Dictionaries.TrajectoryIntent_TD_dict[TD_int];
                        string TRA = Dictionaries.TrajectoryIntent_TRA_dict[subfield2_byte9_bits[1]];
                        string TOA = Dictionaries.TrajectoryIntent_TOA_dict[subfield2_byte9_bits[0]];

                        list.Add(PointType);
                        list.Add(TD);
                        list.Add(TRA);
                        list.Add(TOA);

                        // Octet no. 12 & 13 & 14
                        //double TOV_LSB = 1; // s
                        byte[] TOV_bytes = new byte[3] { subfield2_bytes[12], subfield2_bytes[11], subfield2_bytes[10] }; // Reversed
                        double TOV = Functions.CombineBytes2Int(TOV_bytes);
                        list.Add(TOV);

                        // Octet no. 15 & 16
                        double TTR_LSB = (double)0.01; // Nm
                        byte[] TTR_bytes = new byte[2] { subfield2_bytes[14], subfield2_bytes[13] }; // Reversed
                        double TTR = TTR_LSB * Functions.CombineBytes2Int(TTR_bytes);
                        list.Add(TTR);

                        index += 15;
                    }
                }
            }

            data_list.Add(list);
            return index;
        }

        // Data Item I021/130, Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates_cat21(byte[] octets)
        {
            this.fieldTypes.Add(130);

            double LSB = (double)(180 / Math.Pow(2, 23)); // degrees

            byte[] latitude_bytes = new byte[3] { octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitude_bytes = new byte[3] { octets[5], octets[4], octets[3] }; // Reversed

            double latitude = LSB * Functions.TwosComplement2Int_fromBytes(latitude_bytes);
            double longitude = LSB * Functions.TwosComplement2Int_fromBytes(longitude_bytes);

            data_list.Add(new double[2] { latitude, longitude });
        }

        // Data Item I021/131, High-Resolution Position in WGS-84 Co-ordinates
        private void PositionWGS84Coordinates_HighResolution(byte[] octets)
        {
            this.fieldTypes.Add(131);

            double LSB = (double)(180 / Math.Pow(2, 30)); // degrees

            byte[] latitudeWGS84_bytes = new byte[4] { octets[3], octets[2], octets[1], octets[0] }; // Reversed
            byte[] longitudeWGS84_bytes = new byte[4] { octets[7], octets[6], octets[5], octets[4] }; // Reversed

            double latitudeWGS84 = LSB * Functions.TwosComplement2Int_fromBytes(latitudeWGS84_bytes);
            double longitudeWGS84 = LSB * Functions.TwosComplement2Int_fromBytes(longitudeWGS84_bytes);

            data_list.Add(new double[2] { latitudeWGS84, longitudeWGS84 });
        }

        // Data Item I021/132, Message Amplitude
        private void MessageAmplitude(byte octet1)
        {
            this.fieldTypes.Add(132);

            byte[] MAM_bytes = new byte[1] { octet1 }; // Reversed (no need to reverse, array of length 1)
            //double LSB = 1 // dBm
            double MessageAmplitude = Functions.TwosComplement2Int_fromBytes(MAM_bytes);

            data_list.Add(new double[1] { MessageAmplitude });
        }

        // Data Item I021/140, Geometric Height
        private void GeometricHeight(byte[] octets)
        {
            this.fieldTypes.Add(140);

            Array.Reverse(octets);

            double LSB = (double)6.25; // ft
            double GeometricHeight = LSB * Functions.TwosComplement2Int_fromBytes(octets);

            data_list.Add(new double[1] { GeometricHeight });
        }

        // Data Item I021/145, Flight Level
        private void FlightLevel(byte[] octets)
        {
            this.fieldTypes.Add(145);

            Array.Reverse(octets);

            double LSB = (double)1 / 4; // FL
            double FlightLevel = LSB * Functions.TwosComplement2Int_fromBytes(octets);

            data_list.Add(new double[1] { FlightLevel });
        }

        // Data Item I021/146, Selected Altitude
        private void SelectedAltitude(byte[] octets)
        {
            this.fieldTypes.Add(146);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            BitArray Source_bits = new BitArray(2);
            Source_bits[0] = bits[13];
            Source_bits[1] = bits[14];
            int Source_int = Functions.BitArray2Int(Source_bits);

            string SAS = Dictionaries.SelectedAltitude_SAS_dict[bits[15]];
            string Source = Dictionaries.SelectedAltitude_Source_dict[Source_int];

            bits.Length = bits.Length - 3;

            double LSB = 25; // ft
            double Altitude = LSB * Functions.BitArray2Int(bits);

            data_list.Add(new object[3] { SAS, Source, Altitude });
        }

        // Data Item I021/148, Final State Selected Altitude
        private void FinalStateSelectedAltitude(byte[] octets)
        {
            this.fieldTypes.Add(148);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            string MV = Dictionaries.FinalStateSelectedAltitude_dict[bits[15]];
            string AH = Dictionaries.FinalStateSelectedAltitude_dict[bits[14]];
            string AM = Dictionaries.FinalStateSelectedAltitude_dict[bits[13]];

            bits.Length = bits.Length - 3;

            double LSB = 25; // ft
            double Altitude = LSB * Functions.TwosComplement2Int_fromBitArray(bits);

            data_list.Add(new object[4] { MV, AH, AM, Altitude });
        }

        // Data Item I021/150, Air Speed
        private void AirSpeed(byte[] octets)
        {
            this.fieldTypes.Add(150);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            string IM = Dictionaries.AirSpeed_IM[bits[15]];

            bits.Length = bits.Length - 1;

            double Mach_or_IAS_LSB;

            if (bits[15] == true)
            {
                Mach_or_IAS_LSB = (double)0.001;
            }
            else
            {
                Mach_or_IAS_LSB = (double)Math.Pow(2, -14); // NM/s
            }

            double Mach_or_IAS = Mach_or_IAS_LSB * Functions.BitArray2Int(bits);

            data_list.Add(new object[2] { IM, Mach_or_IAS });
        }

        // Data Item I021/151 True Airspeed
        private void TrueAirSpeed(byte[] octets)
        {
            this.fieldTypes.Add(151);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            string RE = Dictionaries.RE_dict[bits[15]];

            bits.Length = bits.Length - 1;

            //double LSB = 1; // kt
            double TrueAirSpeed = Functions.BitArray2Int(bits);

            data_list.Add(new object[2] { RE, TrueAirSpeed });
        }

        // Data Item I021/152, Magnetic Heading
        private void MagneticHeading(byte[] octets)
        {
            this.fieldTypes.Add(152);

            Array.Reverse(octets);

            double LSB = (double)(360 / Math.Pow(2, 16)); // degrees
            double MagneticHeading = LSB * Functions.CombineBytes2Int(octets);

            data_list.Add(new double[1] { MagneticHeading });
        }

        // Data Item I021/155, Barometric Vertical Rate
        private void BarometricVerticalRate(byte[] octets)
        {
            this.fieldTypes.Add(155);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            string RE = Dictionaries.RE_dict[bits[15]];

            bits.Length = bits.Length - 1;

            double LSB = (double)6.25; // ft/min
            double BarometricVerticalRate = LSB * Functions.TwosComplement2Int_fromBitArray(bits);

            data_list.Add(new object[2] { RE, BarometricVerticalRate });
        }

        // Data Item I021/157, Geometric Vertical Rate
        private void GeometricVerticalRate(byte[] octets)
        {
            this.fieldTypes.Add(157);

            Array.Reverse(octets);
            BitArray bits = new BitArray(octets);

            string RE = Dictionaries.RE_dict[bits[15]];

            bits.Length = bits.Length - 1;

            double LSB = (double)6.25; // ft/min
            double GeometricVerticalRate = LSB * Functions.TwosComplement2Int_fromBitArray(bits);

            data_list.Add(new object[2] { RE, GeometricVerticalRate });
        }

        // Data Item I021/160, Airborne Ground Vector
        private void AirborneGroundVector(byte[] octets)
        {
            this.fieldTypes.Add(160);

            Array.Reverse(octets);

            // RE and Ground Speed
            byte[] GroundSpeed_and_RE_bytes = new byte[2] { octets[2], octets[3] }; // Previously reversed
            BitArray GroundSpeed_and_RE_bits = new BitArray(GroundSpeed_and_RE_bytes);

            string RE = Dictionaries.RE_dict[GroundSpeed_and_RE_bits[15]];

            GroundSpeed_and_RE_bits.Length = GroundSpeed_and_RE_bits.Length - 1;

            double LSB_GroundSpeed = (double)Math.Pow(2, -14); // NM/s
            double GroundSpeed = LSB_GroundSpeed * Functions.BitArray2Int(GroundSpeed_and_RE_bits);

            // Track Angle
            double LSB_TrackAngle = (double)(360 / Math.Pow(2, 16)); // degrees
            byte[] TrackAngle_bytes = new byte[2] { octets[0], octets[1] }; // Previously reversed
            double TrackAngle = LSB_TrackAngle * Functions.CombineBytes2Int(TrackAngle_bytes);

            data_list.Add(new object[3] { RE, GroundSpeed, TrackAngle });
        }

        // Data Item I021/161: Track Number
        /*
        private void TrackNumber(byte[] octets)
        {
            this.fieldTypes.Add(161);

            Array.Reverse(octets);

            int TrackNumber = Functions.CombineBytes2Int(octets);

            data_list.Add(new int[1] { TrackNumber });
        }
        */

        // Data Item I021/165, Track Angle Rate
        private void TrackAngleRate(byte[] octets)
        {
            this.fieldTypes.Add(165);

            Array.Reverse(octets);

            double LSB = (double)1 / 32; // degrees/s
            double TrackAngleRate = LSB * Functions.TwosComplement2Int_fromBytes(octets);

            data_list.Add(new double[1] { TrackAngleRate });
        }

        // Data Item I021/170, Target Identification
        private void TargetIdentification_cat21(byte[] octets)
        {
            this.fieldTypes.Add(170);

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

            string char8 = Dictionaries.TargetIdentification_dict[char8_int];
            string char7 = Dictionaries.TargetIdentification_dict[char7_int];
            string char6 = Dictionaries.TargetIdentification_dict[char6_int];
            string char5 = Dictionaries.TargetIdentification_dict[char5_int];
            string char4 = Dictionaries.TargetIdentification_dict[char4_int];
            string char3 = Dictionaries.TargetIdentification_dict[char3_int];
            string char2 = Dictionaries.TargetIdentification_dict[char2_int];
            string char1 = Dictionaries.TargetIdentification_dict[char1_int];
            string TargetIdentification = char1 + char2 + char3 + char4 + char5 + char6 + char7 + char8;

            data_list.Add(new string[1] { TargetIdentification });
        }

        // Data Item I021/200, Target Status
        private void TargetStatus(byte octet1)
        {
            this.fieldTypes.Add(200);

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

            string ICF = Dictionaries.TargetStatus_ICF_dict[bits[7]];
            string LNAV = Dictionaries.TargetStatus_LNAV_dict[bits[6]];
            string PS = Dictionaries.TargetStatus_PS_dict[PS_int];
            string SS = Dictionaries.TargetStatus_SS_dict[SS_int];

            data_list.Add(new string[4] { ICF, LNAV, PS, SS });
        }

        // Data Item I021/210, MOPS Version
        private void MOPSVersion(byte octet1)
        {
            this.fieldTypes.Add(210);

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

            string VNS = Dictionaries.MOPSVersion_VNS_dict[bits[6]];
            string VN = Dictionaries.MOPSVersion_VN_dict[VN_int];
            string LTT = Dictionaries.MOPSVersion_LTT_dict[LTT_int];

            data_list.Add(new string[3] { VNS, VN, LTT });
        }

        // Data Item I021/220, Met Information
        private int MetInformation(byte[] octets)
        {
            this.fieldTypes.Add(220);

            List<double> list = new List<double>();

            BitArray primary_bits = new BitArray(new byte[1] { octets[0] });

            // Abscense or presence of subfields
            bool WS_bool = primary_bits[7];
            bool WD_bool = primary_bits[6];
            bool TMP_bool = primary_bits[5];
            bool TRB_bool = primary_bits[4];

            // We will need to save the index value in a variable
            int index = 1;

            if (primary_bits[0] == true)
            {
                if (WS_bool == true)
                {
                    //double WindSpeed_LSB = 1; // kt
                    byte[] WindSpeed_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double WindSpeed = Functions.CombineBytes2Int(WindSpeed_bytes);

                    list.Add(WindSpeed);

                    index += 2;
                }
                if (WD_bool == true)
                {
                    //double WindDirection_LSB = 1; // degree
                    byte[] WindDirection_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double WindDirection = Functions.CombineBytes2Int(WindDirection_bytes);

                    list.Add(WindDirection);

                    index += 2;
                }
                if (TMP_bool == true)
                {
                    double Temperature_LSB = (double)0.25; // 'C
                    byte[] Temperature_bytes = new byte[2] { octets[index + 1], octets[index] }; // Reversed
                    double Temperature = Temperature_LSB * Functions.CombineBytes2Int(Temperature_bytes);

                    list.Add(Temperature);

                    index += 2;
                }
                if (TRB_bool == true)
                {
                    int Turbulence = octets[index];

                    list.Add(Turbulence);

                    index += 1;
                }
            }

            data_list.Add(list);
            return index;
        }

        // Data Item I021/230, Roll Angle
        private void RollAngle(byte[] octets)
        {
            this.fieldTypes.Add(230);

            Array.Reverse(octets);

            double LSB = (double)0.01; // degrees
            double RollAngle = LSB * Functions.TwosComplement2Int_fromBytes(octets);

            data_list.Add(new double[1] { RollAngle });
        }

        // Data Item I021/250, Mode S MB Data 
        /*
        private void ModeSMBData(byte[] octets, int REP)
        {
            this.fieldTypes.Add(250);

            List<int> list = new List<int>();

            list.Add(REP);

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

                list.Add(MBData);
                list.Add(BDS1);
                list.Add(BDS2);
            }

            data_list.Add(list);
        }
        */

        // Data Item I021/260, ACAS Resolution Advisory Report
        private void ACASResolutionAdvisoryReport(byte[] octets)
        {
            this.fieldTypes.Add(260);

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
                    ARA_bits[i] = bits[i + 34];
                    if (i < 5)
                    {
                        TYP_bits[i] = bits[i + 51];
                        if (i < 4)
                        {
                            RAC_bits[i] = bits[i + 30];
                            if (i < 3)
                            {
                                STYP_bits[i] = bits[i + 48];
                                if (i < 2)
                                {
                                    TTI_bits[i] = bits[i + 26];
                                    if (i < 1)
                                    {
                                        RAT_bits[i] = bits[i + 29];
                                        MTE_bits[i] = bits[i + 28];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            int TYP = Functions.BitArray2Int(TYP_bits);
            int STYP = Functions.BitArray2Int(STYP_bits);
            int ARA = Functions.BitArray2Int(ARA_bits);
            int RAC = Functions.BitArray2Int(RAC_bits);
            int RAT = Functions.BitArray2Int(RAT_bits);
            int MTE = Functions.BitArray2Int(MTE_bits);
            int TTI = Functions.BitArray2Int(TTI_bits);
            int TID = Functions.BitArray2Int(TID_bits);

            data_list.Add(new int[8] { TYP, STYP, ARA, RAC, RAT, MTE, TTI, TID });
        }

        // Data Item I021/271, Surface Capabilities and Characteristics
        private int SurfaceCapabilitiesAndCharacteristics(byte[] octets)
        {
            this.fieldTypes.Add(271);

            BitArray bits = new BitArray(octets);
            string POA = Dictionaries.SurfaceCapabilitiesandCharacteristics_POA_dict[bits[5]];
            string CDTI_S = Dictionaries.SurfaceCapabilitiesandCharacteristics_CDTI_S_dict[bits[4]];
            string B2low = Dictionaries.SurfaceCapabilitiesandCharacteristics_B2LOW_dict[bits[3]];
            string RAS = Dictionaries.SurfaceCapabilitiesandCharacteristics_RAS_dict[bits[2]];
            string IDENT = Dictionaries.SurfaceCapabilitiesandCharacteristics_IDENT_dict[bits[1]];

            if (bits[0] == true)
            {
                BitArray LengthAndWidth_bits = new BitArray(4);
                LengthAndWidth_bits[0] = bits[8];
                LengthAndWidth_bits[1] = bits[9];
                LengthAndWidth_bits[2] = bits[10];
                LengthAndWidth_bits[3] = bits[11];

                int LengthAndWidth_int = Functions.BitArray2Int(LengthAndWidth_bits);

                data_list.Add(new object[6] { POA, CDTI_S, B2low, RAS, IDENT, LengthAndWidth_int });
                return 2;
            }
            data_list.Add(new string[5] { POA, CDTI_S, B2low, RAS, IDENT });
            return 1;
        }

        // Data Item I021/295, Data Ages
        private int DataAges(List<byte> octets)
        {
            this.fieldTypes.Add(295);

            // First of all, we have to find which subfields will be present and which will be absent
            // Here we also count how many octets does the primary subfield have,
            // and also count how many octets we will have as Subfields #x
            bool[] subfields = new bool[23];
            int primarySubfield_numberOfOctets = 1;

            BitArray primarySubfield_octet1_bits = new BitArray(new byte[1] { octets[0] });

            subfields[0] = primarySubfield_octet1_bits[7];
            subfields[1] = primarySubfield_octet1_bits[6];
            subfields[2] = primarySubfield_octet1_bits[5];
            subfields[3] = primarySubfield_octet1_bits[4];
            subfields[4] = primarySubfield_octet1_bits[3];
            subfields[5] = primarySubfield_octet1_bits[2];
            subfields[6] = primarySubfield_octet1_bits[1];

            if (primarySubfield_octet1_bits[0] == true)
            {
                BitArray primarySubfield_octet2_bits = new BitArray(new byte[1] { octets[1] });

                subfields[7] = primarySubfield_octet2_bits[7];
                subfields[8] = primarySubfield_octet2_bits[6];
                subfields[9] = primarySubfield_octet2_bits[5];
                subfields[10] = primarySubfield_octet2_bits[4];
                subfields[11] = primarySubfield_octet2_bits[3];
                subfields[12] = primarySubfield_octet2_bits[2];
                subfields[13] = primarySubfield_octet2_bits[1];

                primarySubfield_numberOfOctets++;

                if (primarySubfield_octet2_bits[0] == true)
                {
                    BitArray primarySubfield_octet3_bits = new BitArray(new byte[1] { octets[2] });

                    subfields[14] = primarySubfield_octet3_bits[7];
                    subfields[15] = primarySubfield_octet3_bits[6];
                    subfields[16] = primarySubfield_octet3_bits[5];
                    subfields[17] = primarySubfield_octet3_bits[4];
                    subfields[18] = primarySubfield_octet3_bits[3];
                    subfields[19] = primarySubfield_octet3_bits[2];
                    subfields[20] = primarySubfield_octet3_bits[1];

                    primarySubfield_numberOfOctets++;

                    if (primarySubfield_octet3_bits[0] == true)
                    {
                        BitArray primarySubfield_octet4_bits = new BitArray(new byte[1] { octets[3] });

                        subfields[21] = primarySubfield_octet4_bits[7];
                        subfields[22] = primarySubfield_octet4_bits[6];

                        primarySubfield_numberOfOctets++;
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

            int numberOfOctets = primarySubfield_numberOfOctets + subfields_numberOfOctets;

            // ---------------------------------

            double[] DataAges = new double[23];

            double LSB = (double)0.1; // s

            for (int i = 0, j = 0; i < 23; i++)
            {
                if (subfields[i] == true)
                {
                    DataAges[i] = LSB * octets[j];
                    j++;
                }
                else
                {
                    DataAges[i] = 0;
                }
            }

            data_list.Add(DataAges);
            return numberOfOctets;
        }

        // Data Item I021 / 400, Receiver ID
        private void ReceiverID(byte octet1)
        {
            this.fieldTypes.Add(400);

            data_list.Add(new int[1] {octet1});
        }

    }
}
