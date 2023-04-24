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
            //test_readFile();

            /// TEST OF LIST WITH OBJECTS
            /*
            string str = "abc";
            int num = 2;
            string[] strarray = new string[3] { "a", "b", "c" };
            int[] numarray = new int[3] {1,2,3};
            
            List<Object> list = new List<Object>();
            list.Add(str);
            list.Add(num);
            list.Add(strarray);
            list.Add(numarray);

            //int[] numarray2 = (int[])list[3];
            if (list[3] is int[])
            {
                Console.WriteLine(list[3]);
            }
            */

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
            string path = @"D:\Proyectos\PGTA_UPC\Archivos AST\201002-lebl-080001_adsb.ast";
            ReadFile readFile = new ReadFile(path);

            //ShowData(readFile.data_list);
        }

        // For testing
        private static void ShowData(List<Data> data_list)
        {
            for (int i = 0;  i < data_list.Count; i++)
            {
                Data data = data_list[i];
                int cat = data.CAT;
                byte[] FSPEC_bytes = data.FSPEC_bytes;

                if (cat == 10)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("CAT10: message {0}", i);

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
                                    double WGS84_latitude = data.PositionWGS84Coordinates_Latitude;
                                    Console.WriteLine(WGS84_latitude);

                                    double WGS84_longitude = data.PositionWGS84Coordinates_Longitude;
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

                else if (cat == 21)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("CAT21: message {0}", i);

                    for (int j = 0; j < FSPEC_bytes.Length; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                BitArray FSPEC_byte1_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                                if (FSPEC_byte1_bits[7] == true)
                                {
                                    int DataSourceIdentifier_SAC = data.DataSourceIdentification_SAC;
                                    Console.WriteLine(DataSourceIdentifier_SAC);

                                    int DataSourceIdentifier_SIC = data.DataSourceIdentification_SIC;
                                    Console.WriteLine(DataSourceIdentifier_SIC);
                                }
                                if (FSPEC_byte1_bits[6] == true)
                                {
                                    string ATP = data.TargetReportDescriptor_ATP;
                                    Console.WriteLine(ATP);
                                    string ARC = data.TargetReportDescriptor_ARC;
                                    Console.WriteLine(ARC);
                                    string RC = data.TargetReportDescriptor_RC;
                                    Console.WriteLine(RC);
                                    string RAB = data.TargetReportDescriptor_RAB;
                                    Console.WriteLine(RAB);

                                    if (data.TargetReportDescriptor_FirstExtent_flag == true)
                                    {
                                        string DCR = data.TargetReportDescriptor_DCR;
                                        Console.WriteLine(DCR);
                                        string GBS = data.TargetReportDescriptor_GBS;
                                        Console.WriteLine(GBS);
                                        string SIM = data.TargetReportDescriptor_SIM;
                                        Console.WriteLine(SIM);
                                        string TST = data.TargetReportDescriptor_TST;
                                        Console.WriteLine(TST);
                                        string SAA = data.TargetReportDescriptor_SAA;
                                        Console.WriteLine(SAA);
                                        string CL = data.TargetReportDescriptor_CL;
                                        Console.WriteLine(CL);

                                        if (data.TargetReportDescriptor_SecondExtent_flag == true)
                                        {
                                            string IPC = data.TargetReportDescriptor_IPC;
                                            Console.WriteLine(IPC);
                                            string NOGO = data.TargetReportDescriptor_NOGO;
                                            Console.WriteLine(NOGO);
                                            string CPR = data.TargetReportDescriptor_CPR;
                                            Console.WriteLine(CPR);
                                            string LDPJ = data.TargetReportDescriptor_LDPJ;
                                            Console.WriteLine(LDPJ);
                                            string RCF = data.TargetReportDescriptor_RCF;
                                            Console.WriteLine(RCF);
                                        }
                                    }
                                }
                                if (FSPEC_byte1_bits[5] == true)
                                {
                                    int a = data.TrackNumber;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte1_bits[4] == true)
                                {
                                    int a = data.ServiceIdentification;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte1_bits[3] == true)
                                {
                                    double a = data.TimeOfApplicabilityForPosition;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte1_bits[2] == true)
                                {
                                    double WGS84_latitude = data.PositionWGS84Coordinates_Latitude;
                                    Console.WriteLine(WGS84_latitude);

                                    double WGS84_longitude = data.PositionWGS84Coordinates_Longitude;
                                    Console.WriteLine(WGS84_longitude);
                                }
                                if (FSPEC_byte1_bits[1] == true)
                                {
                                    double WGS84_HP_latitude = data.PositionWGS84Coordinates_HighResolution_Latitude;
                                    Console.WriteLine(WGS84_HP_latitude);

                                    double WGS84_HP_longitude = data.PositionWGS84Coordinates_HighResolution_Longitude;
                                    Console.WriteLine(WGS84_HP_longitude);
                                }

                                break;

                            case 1:
                                BitArray FSPEC_byte2_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                                if (FSPEC_byte2_bits[7] == true)
                                {
                                    double a = data.TimeOfApplicabilityForVelocity;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte2_bits[6] == true)
                                {
                                    string a = data.AirSpeed_IM;
                                    Console.WriteLine(a);

                                    double b = data.AirSpeed;
                                    Console.WriteLine(b);
                                }
                                if (FSPEC_byte2_bits[5] == true)
                                {
                                    string a = data.TrueAirSpeed_RE;
                                    Console.WriteLine(a);

                                    double b = data.TrueAirSpeed;
                                    Console.WriteLine(b);
                                }
                                if (FSPEC_byte2_bits[4] == true)
                                {
                                    string a = data.TargetAddress;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte2_bits[3] == true)
                                {
                                    double a = data.TimeOfMessageReceptionForPosition;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte2_bits[2] == true)
                                {
                                    string a = data.TimeOfMessageReceptionOfPosition_HighPrecision_FSI;
                                    Console.WriteLine(a);

                                    decimal b = data.TimeOfMessageReceptionOfPosition_HighPrecision;
                                    Console.WriteLine(b);
                                }
                                if (FSPEC_byte2_bits[1] == true)
                                {
                                    double a = data.TimeOfMessageReceptionForVelocity;
                                    Console.WriteLine(a);
                                }

                                break;

                            case 2:
                                BitArray FSPEC_byte3_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                                if (FSPEC_byte3_bits[7] == true)
                                {
                                    string a = data.TimeOfMessageReceptionOfVelocity_HighPrecision_FSI;
                                    Console.WriteLine(a);

                                    decimal b = data.TimeOfMessageReceptionOfVelocity_HighPrecision;
                                    Console.WriteLine(b);
                                }
                                if (FSPEC_byte3_bits[6] == true)
                                {
                                    double a = data.GeometricHeight;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte3_bits[5] == true)
                                {
                                    int a = data.QualityIndicators_NUCr_or_NACv;
                                    Console.WriteLine(a);
                                    int b = data.QualityIndicators_NUCp_or_NIC;
                                    Console.WriteLine(b);

                                    if (data.QualityIndicators_FirstExtent_flag == true)
                                    {
                                        int c = data.QualityIndicators_NICbaro;
                                        Console.WriteLine(c);
                                        int d = data.QualityIndicators_SIL;
                                        Console.WriteLine(d);
                                        int e = data.QualityIndicators_NACp;
                                        Console.WriteLine(e);

                                        if (data.QualityIndicators_SecondExtent_flag == true)
                                        {
                                            string f = data.QualityIndicators_SILsupplement;
                                            Console.WriteLine(f);
                                            int g = data.QualityIndicators_SDA;
                                            Console.WriteLine(g);
                                            int h = data.QualityIndicators_GVA;
                                            Console.WriteLine(h);

                                            if (data.QualityIndicators_ThirdExtent_flag == true)
                                            {
                                                int k = data.QualityIndicators_PIC;
                                                Console.WriteLine(k);
                                            }
                                        }
                                    }
                                }
                                if (FSPEC_byte3_bits[4] == true)
                                {
                                    string a = data.MOPSVersion_VNS;
                                    Console.WriteLine(a);
                                    string b = data.MOPSVersion_VN;
                                    Console.WriteLine(b);
                                    string c = data.MOPSVersion_LTT;
                                    Console.WriteLine(c);
                                }
                                if (FSPEC_byte3_bits[3] == true)
                                {
                                    string a = data.Mode3ACode_Reply;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte3_bits[2] == true)
                                {
                                    double a = data.RollAngle;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte3_bits[1] == true)
                                {
                                    double a = data.FlightLevel;
                                    Console.WriteLine(a);
                                }

                                break;

                            case 3:
                                BitArray FSPEC_byte4_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                                if (FSPEC_byte4_bits[7] == true)
                                {
                                    double a = data.MagneticHeading;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte4_bits[6] == true)
                                {
                                    string a = data.TargetStatus_ICF;
                                    Console.WriteLine(a);
                                    string b = data.TargetStatus_LNAV;
                                    Console.WriteLine(b);
                                    string c = data.TargetStatus_PS;
                                    Console.WriteLine(c);
                                    string d = data.TargetStatus_SS;
                                    Console.WriteLine(d);
                                }
                                if (FSPEC_byte4_bits[5] == true)
                                {
                                    string a = data.BarometricVerticalRate_RE;
                                    Console.WriteLine(a);
                                    double b = data.BarometricVerticalRate;
                                    Console.WriteLine(b);
                                }
                                if (FSPEC_byte4_bits[4] == true)
                                {
                                    string a = data.GeometricVerticalRate_RE;
                                    Console.WriteLine(a);
                                    double b = data.GeometricVerticalRate;
                                    Console.WriteLine(b);
                                }
                                if (FSPEC_byte4_bits[3] == true)
                                {
                                    string a = data.AirborneGroundVector_RE;
                                    Console.WriteLine(a);
                                    double b = data.AirborneGroundVector_GroundSpeed;
                                    Console.WriteLine(b);
                                    double c = data.AirborneGroundVector_TrackAngle;
                                    Console.WriteLine(c);
                                }
                                if (FSPEC_byte4_bits[2] == true)
                                {
                                    double a = data.TrackAngleRate;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte4_bits[1] == true)
                                {
                                    double a = data.TimeOfASTERIXReportTransmission;
                                    Console.WriteLine(a);
                                }

                                break;

                            case 4:
                                BitArray FSPEC_byte5_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                                if (FSPEC_byte5_bits[7] == true)
                                {
                                    string a = data.TargetIdentification;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte5_bits[6] == true)
                                {
                                    string a = data.EmitterCategory;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte5_bits[5] == true)
                                {
                                    bool subfield1 = data.MetInformation_WS_subfield1;
                                    Console.WriteLine(subfield1);
                                    bool subfield2 = data.MetInformation_WD_subfield2;
                                    Console.WriteLine(subfield2);
                                    bool subfield3 = data.MetInformation_TMP_subfield3;
                                    Console.WriteLine(subfield3);
                                    bool subfield4 = data.MetInformation_TRB_subfield4;
                                    Console.WriteLine(subfield4);

                                    if (subfield1 == true)
                                    {
                                        double a = data.MetInformation_WindSpeed;
                                        Console.WriteLine(a);
                                    }
                                    if (subfield2 == true)
                                    {
                                        double b = data.MetInformation_WindDirection;
                                        Console.WriteLine(b);
                                    }
                                    if (subfield3 == true)
                                    {
                                        double c = data.MetInformation_Temperature;
                                        Console.WriteLine(c);
                                    }
                                    if (subfield4 == true)
                                    {
                                        double d = data.MetInformation_Turbulence;
                                        Console.WriteLine(d);
                                    }
                                }
                                if (FSPEC_byte5_bits[4] == true)
                                {
                                    string a = data.SelectedAltitude_SAS;
                                    Console.WriteLine(a);
                                    string b = data.SelectedAltitude_Source;
                                    Console.WriteLine(b);
                                    double c = data.SelectedAltitude_Altitude;
                                    Console.WriteLine(c);
                                }
                                if (FSPEC_byte5_bits[3] == true)
                                {
                                    string a = data.FinalStateSelectedAltitude_MV;
                                    Console.WriteLine(a);
                                    string b = data.FinalStateSelectedAltitude_AH;
                                    Console.WriteLine(b);
                                    string c = data.FinalStateSelectedAltitude_AM;
                                    Console.WriteLine(c);
                                    double d = data.FinalStateSelectedAltitude_Altitude;
                                    Console.WriteLine(d);
                                }
                                if (FSPEC_byte5_bits[2] == true)
                                {
                                    bool subfield1 = data.TrajectoryIntent_TIS_subfield1;
                                    Console.WriteLine(subfield1);
                                    bool subfield2 = data.TrajectoryIntent_TID_subfield2;
                                    Console.WriteLine(subfield2);

                                    if (subfield1 == true)
                                    {
                                        string a = data.TrajectoryIntent_NAV;
                                        Console.WriteLine(a);
                                        string b = data.TrajectoryIntent_NVB;
                                        Console.WriteLine(b);
                                    }
                                    if (subfield2 == true)
                                    {
                                        int REP = data.TrajectoryIntent_TCA.Length;
                                        for (int k = 0; k < REP; k++)
                                        {
                                            string c = data.TrajectoryIntent_TCA[k];
                                            Console.WriteLine(c);
                                            string d = data.TrajectoryIntent_NC[k];
                                            Console.WriteLine(d);
                                            int e = data.TrajectoryIntent_TCP[k];
                                            Console.WriteLine(e);
                                            double f = data.TrajectoryIntent_Altitude[k];
                                            Console.WriteLine(f);
                                            double g = data.TrajectoryIntent_Latitude[k];
                                            Console.WriteLine(g);
                                            double h = data.TrajectoryIntent_Longitude[k];
                                            Console.WriteLine(h);
                                            string l = data.TrajectoryIntent_PointType[k];
                                            Console.WriteLine(l);
                                            string m = data.TrajectoryIntent_TD[k];
                                            Console.WriteLine(m);
                                            string n = data.TrajectoryIntent_TRA[k];
                                            Console.WriteLine(n);
                                            string o = data.TrajectoryIntent_TOA[k];
                                            Console.WriteLine(o);
                                            double p = data.TrajectoryIntent_TOV[k];
                                            Console.WriteLine(p);
                                            double q = data.TrajectoryIntent_TTR[k];
                                            Console.WriteLine(q);
                                        }
                                    }
                                }
                                if (FSPEC_byte5_bits[1] == true)
                                {
                                    double a = data.ServiceManagement;
                                    Console.WriteLine(a);
                                }

                                break;

                            case 5:
                                BitArray FSPEC_byte6_bits = new BitArray(new byte[1] { FSPEC_bytes[j] });

                                if (FSPEC_byte6_bits[7] == true)
                                {
                                    string a = data.AircraftOperationalStatus_RA;
                                    Console.WriteLine(a);
                                    string b = data.AircraftOperationalStatus_TC;
                                    Console.WriteLine(b);
                                    string c = data.AircraftOperationalStatus_TS;
                                    Console.WriteLine(c);
                                    string d = data.AircraftOperationalStatus_ARV;
                                    Console.WriteLine(d);
                                    string e = data.AircraftOperationalStatus_CDTI_A;
                                    Console.WriteLine(e);
                                    string f = data.AircraftOperationalStatus_TCAS;
                                    Console.WriteLine(f);
                                    string g = data.AircraftOperationalStatus_SA;
                                    Console.WriteLine(g);
                                }
                                if (FSPEC_byte6_bits[6] == true)
                                {
                                    string a = data.SurfaceCapabilitiesandCharacteristics_POA;
                                    Console.WriteLine(a);
                                    string b = data.SurfaceCapabilitiesandCharacteristics_CDTI_S;
                                    Console.WriteLine(b);
                                    string c = data.SurfaceCapabilitiesandCharacteristics_B2low;
                                    Console.WriteLine(c);
                                    string d = data.SurfaceCapabilitiesandCharacteristics_RAS;
                                    Console.WriteLine(d);
                                    string e = data.SurfaceCapabilitiesandCharacteristics_IDENT;
                                    Console.WriteLine(e);

                                    if (data.SurfaceCapabilitiesandCharacteristics_FirstExtent_flag == true)
                                    {
                                        int f = data.SurfaceCapabilitiesandCharacteristics_LW;
                                        Console.WriteLine(f);
                                    }
                                }
                                if (FSPEC_byte6_bits[5] == true)
                                {
                                    double a = data.MessageAmplitude;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte6_bits[4] == true)
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
                                if (FSPEC_byte6_bits[3] == true)
                                {
                                    int a = data.ACASResolutionAdvisoryReport_TYP;
                                    Console.WriteLine(a);
                                    int b = data.ACASResolutionAdvisoryReport_STYP;
                                    Console.WriteLine(b);
                                    int c = data.ACASResolutionAdvisoryReport_ARA;
                                    Console.WriteLine(c);
                                    int d = data.ACASResolutionAdvisoryReport_RAC;
                                    Console.WriteLine(d);
                                    int e = data.ACASResolutionAdvisoryReport_RAT;
                                    Console.WriteLine(e);
                                    int f = data.ACASResolutionAdvisoryReport_MTE;
                                    Console.WriteLine(f);
                                    int g = data.ACASResolutionAdvisoryReport_TTI;
                                    Console.WriteLine(g);
                                    int h = data.ACASResolutionAdvisoryReport_TID;
                                    Console.WriteLine(h);
                                }
                                if (FSPEC_byte6_bits[2] == true)
                                {
                                    int a = data.ReceiverID;
                                    Console.WriteLine(a);
                                }
                                if (FSPEC_byte6_bits[1] == true)
                                {
                                    bool[] subfields = data.DataAges_subfields;
                                    for (int k = 0; k < subfields.Length; k++)
                                    {
                                        Console.WriteLine(subfields[k]);
                                    }

                                    double[] DataAges = data.DataAges;
                                    for (int l = 0; l < DataAges.Length; l++)
                                    {
                                        if (subfields[l] == true)
                                        {
                                            Console.WriteLine(DataAges[l]);
                                        }
                                    }
                                }

                                break;

                        }
                    }
                }
                else
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("ERROR. Not expected category. --> CAT {0}", cat);
                    Console.WriteLine("--------------------------------------------");
                }
            } 
        }

    }
}
