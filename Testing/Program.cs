using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            /// Here goes the function to be tested

            /// TEST OF READFILE() FUNCTION FROM FUNCTIONS CLASS
            test_readFile();

            /// TEST OF MESSAGETYPE() FUNCTION DECODER FROM CAT10 CLASS
            /*
            CAT10 cat10 = new CAT10();
            byte octet1 = 4;
            cat10.MessageType(octet1);
            Console.WriteLine(cat10.data.MessageType);
            */

            /// TEST OF TWOSCOMPLEMENT() FUNCTION FROM FUNCTIONS CLASS
            //Console.WriteLine(Functions.TwosComplement2Int("1111101100110001")); //-1231
            //byte[] bytes = new byte[1] {179};
            //Console.WriteLine(Functions.TwosComplement2Int2(bytes)); //-1231

            /// TEST OF BITARRAY
            /*
            byte[] bytes = new byte[1] {8};
            Console.WriteLine(bytes[0]);
            bytes.Reverse();
            Console.WriteLine(bytes[0]);
            */

            //byte[] bytes = new byte[1] { 7 };
            //BitArray bits = new BitArray(bytes);
            //Console.WriteLine(bits.Length);
            //bits.Length = bits.Length - 2;
            //Console.WriteLine(bits.Length);
            //Console.WriteLine(bits[bits.Length - 1]);
            //Console.WriteLine(Convert.ToInt32(bits[bits.Length-1]));
            

            /// TEST OF TargetReportDescriptor() FUNCTION DECODER FROM CAT10 CLASS
            /*
            //byte[] bytes = new byte[2] { 2, 0 };
            //Console.WriteLine((bytes[0] << 8) | bytes[1]);
            CAT10 cat10 = new CAT10();
            BitArray bits = new BitArray(bytes);
            cat10.TargetReportDescriptor(bytes);
            Console.WriteLine(cat10.data.TargetReportDescriptor_TYP);
            */

            /// TEST OF CombineBytes() FUNCTION
            /*
            byte[] bytes = new byte[4] { 1, 0, 0, 0 };
            Console.WriteLine(Functions.CombineBytes2Int(bytes)); // 16777216
            */

            time.Stop();
            Console.WriteLine(time.Elapsed);
            Console.ReadLine();
        }

        // Testing readFile function
        private static void test_readFile()
        {
            string path = @"D:\Proyectos\PGTA_UPC\Archivos AST\201002-lebl-080001_smr.ast";
            ReadFile readFile = new ReadFile(path);

            ShowCAT10Data(readFile.CAT10_list);
        }

        // For testing CAT10
        private static void ShowCAT10Data(List<CAT10> CAT10_list)
        {
            for (int i = 0;  i < CAT10_list.Count; i++)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("CAT10: message {0}", i);

                CAT10 cat10 = CAT10_list[i];
                byte[] FSPEC_bytes = cat10.FSPEC;
                CAT10_Data data = cat10.data;

                for (int j = 0; j < FSPEC_bytes.Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            BitArray FSPEC_byte1_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                            if (FSPEC_byte1_bits[7] == true)
                            {
                                int DataSourceIdentifier_SAC = data.DataSourceIdentifier_SAC;
                                Console.WriteLine(DataSourceIdentifier_SAC);

                                int DataSourceIdentifier_SIC = data.DataSourceIdentifier_SIC;
                                Console.WriteLine(DataSourceIdentifier_SIC);
                            }
                            if (FSPEC_byte1_bits[6] == true)
                            {
                                string MessageType = data.MessageType;
                                Console.WriteLine(MessageType);
                            }
                            if (FSPEC_byte1_bits[5] == true)
                            {
                                string TYP = data.TargetReportDescriptor_TYP;
                                Console.WriteLine(TYP);
                                string DCR = data.TargetReportDescriptor_DCR;
                                Console.WriteLine(DCR);
                                string CHN = data.TargetReportDescriptor_CHN;
                                Console.WriteLine(CHN);
                                string GBS = data.TargetReportDescriptor_GBS;
                                Console.WriteLine(GBS);
                                string CRT = data.TargetReportDescriptor_CRT;
                                Console.WriteLine(CRT);

                                if (data.TargetReportDescriptor_FirstExtent_flag == true)
                                {
                                    string SIM = data.TargetReportDescriptor_SIM;
                                    Console.WriteLine(SIM);
                                    string TST = data.TargetReportDescriptor_TST;
                                    Console.WriteLine(TST);
                                    string RAB = data.TargetReportDescriptor_RAB;
                                    Console.WriteLine(RAB);
                                    string LOP = data.TargetReportDescriptor_LOP;
                                    Console.WriteLine(LOP);
                                    string TOT = data.TargetReportDescriptor_TOT;
                                    Console.WriteLine(TOT);

                                    if (data.TargetReportDescriptor_SecondExtent_flag == true)
                                    {
                                        string SPI = data.TargetReportDescriptor_SPI;
                                        Console.WriteLine(SPI);
                                    }
                                }
                            }
                            if (FSPEC_byte1_bits[4] == true)
                            {
                                double timeOfDay = data.TimeOfDay;
                                Console.WriteLine(timeOfDay.ToString());
                            }
                            if (FSPEC_byte1_bits[3] == true)
                            {
                                double WGS84_latitude = data.PositionWGS84Coordinates_latitude;
                                Console.WriteLine(WGS84_latitude);

                                double WGS84_longitude = data.PositionWGS84Coordinates_longitude;
                                Console.WriteLine(WGS84_longitude);
                            }
                            if (FSPEC_byte1_bits[2] == true)
                            {
                                double PolarCoordinates_RHO = data.MeasuredPositioninPolarCoordinates_RHO;
                                Console.WriteLine(PolarCoordinates_RHO);

                                double PolarCoordinates_THETA = data.MeasuredPositioninPolarCoordinates_THETA;
                                Console.WriteLine(PolarCoordinates_THETA);
                            }
                            if (FSPEC_byte1_bits[1] == true)
                            {
                                double CartesianCoordinates_x = data.PositionCartesianCoordinates_x;
                                Console.WriteLine(CartesianCoordinates_x);

                                double CartesianCoordinates_y = data.PositionCartesianCoordinates_y;
                                Console.WriteLine(CartesianCoordinates_y);
                            }

                            break;

                        case 1:
                            BitArray FSPEC_byte2_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                            if (FSPEC_byte2_bits[7] == true)
                            {
                                double PolarCoordinates_GroundSpeed = data.CalculatedTrackVelocityPolarCoordinates_GroundSpeed;
                                Console.WriteLine(PolarCoordinates_GroundSpeed);

                                double PolarCoordinates_TrackAngle = data.CalculatedTrackVelocityPolarCoordinates_TrackAngle;
                                Console.WriteLine(PolarCoordinates_TrackAngle);
                            }
                            if (FSPEC_byte2_bits[6] == true)
                            {
                                double a = data.CalculatedTrackVelocityCartesianCoordinates_Vx;
                                Console.WriteLine(a);

                                double b = data.CalculatedTrackVelocityCartesianCoordinates_Vy;
                                Console.WriteLine(b);
                            }
                            if (FSPEC_byte2_bits[5] == true)
                            {
                                int a = data.TrackNumber;
                                Console.WriteLine(a);
                            }
                            if (FSPEC_byte2_bits[4] == true)
                            {
                                string a = data.TrackStatus_CNF;
                                Console.WriteLine(a);
                                string b = data.TrackStatus_TRE;
                                Console.WriteLine(b);
                                string c = data.TrackStatus_CST;
                                Console.WriteLine(c);
                                string d = data.TrackStatus_MAH;
                                Console.WriteLine(d);
                                string e = data.TrackStatus_TCC;
                                Console.WriteLine(e);
                                string f = data.TrackStatus_STH;
                                Console.WriteLine(f);

                                if (data.TrackStatus_FirstExtent_flag == true)
                                {
                                    string g = data.TrackStatus_TOM;
                                    Console.WriteLine(g);
                                    string h = data.TrackStatus_DOU;
                                    Console.WriteLine(h);
                                    string k = data.TrackStatus_MRS;
                                    Console.WriteLine(k);

                                    if (data.TrackStatus_SecondExtent_flag == true)
                                    {
                                        string l = data.TrackStatus_GHO;
                                        Console.WriteLine(l);
                                    }
                                }
                            }
                            if (FSPEC_byte2_bits[3] == true)
                            {
                                string a = data.Mode3ACode_V;
                                Console.WriteLine(a);
                                string b = data.Mode3ACode_G;
                                Console.WriteLine(b);
                                string c = data.Mode3ACode_L;
                                Console.WriteLine(c);
                                string d = data.Mode3ACode_Reply;
                                Console.WriteLine(d);
                            }
                            if (FSPEC_byte2_bits[2] == true)
                            {
                                string a = data.TargetAddress;
                                Console.WriteLine(a);
                            }
                            if (FSPEC_byte2_bits[1] == true)
                            {
                                string a = data.TargetIdentification_STI;
                                Console.WriteLine(a);
                                string b = data.TargetIdentification_Characters;
                                Console.WriteLine(b);
                            }

                            break;

                        case 2:
                            BitArray FSPEC_byte3_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                            if (FSPEC_byte3_bits[7] == true)
                            {
                                int[] a = data.ModeSMBData_MBData;
                                int[] b = data.ModeSMBData_BDS1;
                                int[] c = data.ModeSMBData_BDS2;
                                for (int k = 0; k < a.Length; k++)
                                {
                                    Console.WriteLine(a[k]);
                                    Console.WriteLine(b[k]);
                                    Console.WriteLine(c[k]);
                                }
                            }
                            if (FSPEC_byte3_bits[6] == true)
                            {
                                string a = data.VehicleFleetIdentification;
                                Console.WriteLine(a);
                            }
                            if (FSPEC_byte3_bits[5] == true)
                            {
                                string a = data.FlightLevel_V;
                                Console.WriteLine(a);
                                string b = data.FlightLevel_G;
                                Console.WriteLine(b);
                                double c = data.FlightLevel_FL;
                                Console.WriteLine(c);
                            }
                            if (FSPEC_byte3_bits[4] == true)
                            {
                                double a = data.MeasuredHeight;
                                Console.WriteLine(a);
                            }
                            if (FSPEC_byte3_bits[3] == true)
                            {
                                int a = data.TargetSizeAndOrientation_Length;
                                Console.WriteLine(a);

                                if (data.TargetSizeAndOrientation_FirstExtent_flag == true)
                                {
                                    double b = data.TargetSizeAndOrientation_Orientation;
                                    Console.WriteLine(b);

                                    if (data.TargetSizeAndOrientation_SecondExtent_flag == true)
                                    {
                                        int c = data.TargetSizeAndOrientation_Width;
                                        Console.WriteLine(c);
                                    }
                                }
                            }
                            if (FSPEC_byte3_bits[2] == true)
                            {
                                string a = data.SystemStatus_OVL;
                                Console.WriteLine(a);
                                string b = data.SystemStatus_TSV;
                                Console.WriteLine(b);
                                string c = data.SystemStatus_DIV;
                                Console.WriteLine(c);
                                string d = data.SystemStatus_TTF;
                                Console.WriteLine(d);
                                string e = data.SystemStatus_NOGO;
                                Console.WriteLine(e);
                            }
                            if (FSPEC_byte3_bits[1] == true)
                            {
                                string a = data.PreprogrammedMessage_TRB;
                                Console.WriteLine(a);
                                string b = data.PreprogrammedMessage_MSG;
                                Console.WriteLine(b);
                            }

                            break;

                        case 3:
                            BitArray FSPEC_byte4_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                            if (FSPEC_byte4_bits[7] == true)
                            {
                                double a = data.StandardDeviationPosition_SDx;
                                Console.WriteLine(a);
                                double b = data.StandardDeviationPosition_SDy;
                                Console.WriteLine(b);
                                double c = data.StandardDeviationPosition_Coveriance;
                                Console.WriteLine(c);
                            }
                            if (FSPEC_byte4_bits[6] == true)
                            {
                                int[] a = data.Presence_DRHO;
                                double[] b = data.Presence_DTHETA;
   
                                for (int k = 0; k < a.Length; k++)
                                {
                                    Console.WriteLine(a[k]);
                                    Console.WriteLine(b[k]);
                                }
                            }
                            if (FSPEC_byte4_bits[5] == true)
                            {
                                int a = data.AmplitudePrimayPlot;
                                Console.WriteLine(a);
                            }
                            if (FSPEC_byte4_bits[4] == true)
                            {
                                double a = data.CalculatedAcceleration_Ax;
                                Console.WriteLine(a);
                                double b = data.CalculatedAcceleration_Ay;
                                Console.WriteLine(b);
                            }

                            break;
                    }
                }
            } 
        }

    }
}
