using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Data
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
        public List<IList> data_list { get; set; }


        // CAT10
        // Data Item I010/000, Message Type
        public string MessageType { get; set; }

        // Data Item I010/010, Data Source Identifier
        public int DataSourceIdentifier_SAC { get; set; }
        public int DataSourceIdentifier_SIC { get; set; }

        // Data Item I010/020, Target Report Descriptor
        public bool TargetReportDescriptor_FirstExtent_flag { get; set; }
        public bool TargetReportDescriptor_SecondExtent_flag { get; set; }
        public string TargetReportDescriptor_TYP { get; set; }
        public string TargetReportDescriptor_DCR { get; set; }
        public string TargetReportDescriptor_CHN { get; set; }
        public string TargetReportDescriptor_GBS { get; set; }
        public string TargetReportDescriptor_CRT { get; set; }
        public string TargetReportDescriptor_FX { get; set; }
        public string TargetReportDescriptor_SIM { get; set; }
        public string TargetReportDescriptor_TST { get; set; }
        public string TargetReportDescriptor_RAB { get; set; }
        public string TargetReportDescriptor_LOP { get; set; }
        public string TargetReportDescriptor_TOT { get; set; }
        public string TargetReportDescriptor_SPI { get; set; }

        //Data Item I010/040, Measured Position in Polar Co-ordinates
        public double MeasuredPositioninPolarCoordinates_RHO { get; set; }
        public double MeasuredPositioninPolarCoordinates_THETA { get; set; }

        // Data Item I010/041, Position in WGS-84 Co-ordinates
        public double PositionWGS84Coordinates_Latitude { get; set; }
        public double PositionWGS84Coordinates_Longitude { get; set; }

        // Data Item I010/042, Position in Cartesian Co-ordinates
        public double PositionCartesianCoordinates_x { get; set; }
        public double PositionCartesianCoordinates_y { get; set; }

        // Data Item I010/060, Mode-3/A Code in Octal Representation
        public string Mode3ACode_V { get; set; }
        public string Mode3ACode_G { get; set; }
        public string Mode3ACode_L { get; set; }
        public string Mode3ACode_Reply { get; set; }

        // Data Item I010/090, Flight Level in Binary Representation
        public string FlightLevel_V { get; set; }
        public string FlightLevel_G { get; set; }
        public double FlightLevel_FL { get; set; }

        // Data Item I010/091, Measured Height
        public double MeasuredHeight { get; set; }

        //Data Item I010/131, Amplitude of Primary Plot
        public int AmplitudePrimayPlot { get; set; }

        // Data Item I010/140: Time of Day
        public double TimeOfDay { get; set; }

        // Data Item I010/161: Track Number
        public int TrackNumber { get; set; }

        // Data Item I010/170, Track Status
        public bool TrackStatus_FirstExtent_flag { get; set; }
        public bool TrackStatus_SecondExtent_flag { get; set; }
        public string TrackStatus_CNF { get; set; }
        public string TrackStatus_TRE { get; set; }
        public string TrackStatus_CST { get; set; }
        public string TrackStatus_MAH { get; set; }
        public string TrackStatus_TCC { get; set; }
        public string TrackStatus_STH { get; set; }
        public string TrackStatus_TOM { get; set; }
        public string TrackStatus_DOU { get; set; }
        public string TrackStatus_MRS { get; set; }
        public string TrackStatus_GHO { get; set; }

        // Data Item I010/200, Calculated Track Velocity in Polar Co-ordinates
        public double CalculatedTrackVelocityPolarCoordinates_GroundSpeed { get; set; }
        public double CalculatedTrackVelocityPolarCoordinates_TrackAngle { get; set; }

        // Data Item I010/202, Calculated Track Velocity in Cartesian Co-ordinates
        public double CalculatedTrackVelocityCartesianCoordinates_Vx { get; set; }
        public double CalculatedTrackVelocityCartesianCoordinates_Vy { get; set; }

        // Data Item I010/210, Calculated Acceleration
        public double CalculatedAcceleration_Ax { get; set; }
        public double CalculatedAcceleration_Ay { get; set; }

        // Data Item I010/220, Target Address
        public string TargetAddress { get; set; }

        // Data Item I010/245, Target Identification
        public string TargetIdentification_STI { get; set; }
        public string TargetIdentification_Characters { get; set; }

        // Data Item I010/250, Mode S MB Data
        public int ModeSMBData_REP { get; set; }
        public int[] ModeSMBData_MBData { get; set; } // Array size defined in the method
        public int[] ModeSMBData_BDS1 { get; set; } // Array size defined in the method
        public int[] ModeSMBData_BDS2 { get; set; } // Array size defined in the method

        // Data Item I010/270, Target Size & Orientation
        public bool TargetSizeAndOrientation_FirstExtent_flag { get; set; }
        public bool TargetSizeAndOrientation_SecondExtent_flag { get; set; }
        public int TargetSizeAndOrientation_Length { get; set; }
        public double TargetSizeAndOrientation_Orientation { get; set; }
        public int TargetSizeAndOrientation_Width { get; set; }

        // Data Item I010/280, Presence
        public int Presence_REP { get; set; }
        public int[] Presence_DRHO { get; set; } // Array size defined in the method
        public double[] Presence_DTHETA { get; set; } // Array size defined in the method

        // Data Item I010/300, Vehicle Fleet Identification
        public string VehicleFleetIdentification { get; set; }

        // Data Item I010/310, Pre-programmed Message
        public string PreprogrammedMessage_TRB { get; set; }
        public string PreprogrammedMessage_MSG { get; set; }

        // Data Item I010/500, Standard Deviation of Position
        public double StandardDeviationPosition_SDx { get; set; }
        public double StandardDeviationPosition_SDy { get; set; }
        public double StandardDeviationPosition_Coveriance { get; set; }

        // Data Item I010/550, System Status
        public string SystemStatus_OVL { get; set; }
        public string SystemStatus_TSV { get; set; }
        public string SystemStatus_DIV { get; set; }
        public string SystemStatus_TTF { get; set; }
        public string SystemStatus_NOGO { get; set; }

        // -----------------------------------------------------------------------------------

        // CAT21
        // Data Item I021/008, Aircraft Operational Status
        public string AircraftOperationalStatus_RA { get; set; }
        public string AircraftOperationalStatus_TC { get; set; }
        public string AircraftOperationalStatus_TS { get; set; }
        public string AircraftOperationalStatus_ARV { get; set; }
        public string AircraftOperationalStatus_CDTI_A { get; set; }
        public string AircraftOperationalStatus_TCAS { get; set; }
        public string AircraftOperationalStatus_SA { get; set; }

        // Data Item I021/010, Data Source Identification
        public int DataSourceIdentification_SAC { get; set; }
        public int DataSourceIdentification_SIC { get; set; }

        // Data Item I021/015, Service Identification 
        public int ServiceIdentification { get; set; }

        // Data Item I021/016, Service Management
        public double ServiceManagement { get; set; }

        // Data Item I021/020, Emitter Category
        public string EmitterCategory { get; set; }

        // Data Item I021/040, Target Report Descriptor
        //public bool TargetReportDescriptor_FirstExtent_flag { get; set; }
        //public bool TargetReportDescriptor_SecondExtent_flag { get; set; }
        public string TargetReportDescriptor_ATP { get; set; }
        public string TargetReportDescriptor_ARC { get; set; }
        public string TargetReportDescriptor_RC { get; set; }
        //public string TargetReportDescriptor_RAB { get; set; }
        //public string TargetReportDescriptor_DCR { get; set; }
        //public string TargetReportDescriptor_GBS { get; set; }
        //public string TargetReportDescriptor_SIM { get; set; }
        //public string TargetReportDescriptor_TST { get; set; }
        public string TargetReportDescriptor_SAA { get; set; }
        public string TargetReportDescriptor_CL { get; set; }
        public string TargetReportDescriptor_IPC { get; set; }
        public string TargetReportDescriptor_NOGO { get; set; }
        public string TargetReportDescriptor_CPR { get; set; }
        public string TargetReportDescriptor_LDPJ { get; set; }
        public string TargetReportDescriptor_RCF { get; set; }

        // Data Item I021/070, Mode 3/A Code in Octal Representation
        //public string Mode3ACode_Reply { get; set; }

        // Data Item I021/071, Time of Applicability for Position
        public double TimeOfApplicabilityForPosition { get; set; }

        // Data Item I021/072, Time of Applicability for Velocity
        public double TimeOfApplicabilityForVelocity { get; set; }

        // Data Item I021/073, Time of Message Reception for Position
        public double TimeOfMessageReceptionForPosition { get; set; }

        // Data Item I021/074, Time of Message Reception of Position–High Precision
        public string TimeOfMessageReceptionOfPosition_HighPrecision_FSI { get; set; }
        public decimal TimeOfMessageReceptionOfPosition_HighPrecision { get; set; }

        // Data Item I021/075, Time of Message Reception for Velocity
        public double TimeOfMessageReceptionForVelocity { get; set; }

        // Data Item I021/076, Time of Message Reception of Velocity–High Precision
        public string TimeOfMessageReceptionOfVelocity_HighPrecision_FSI { get; set; }
        public decimal TimeOfMessageReceptionOfVelocity_HighPrecision { get; set; }

        // Data Item I021/077, Time of ASTERIX Report Transmission
        public double TimeOfASTERIXReportTransmission { get; set; }

        // Data Item I021/080, Target Address
        //public string TargetAddress { get; set; }

        // Data Item I021/090, Quality Indicators
        public bool QualityIndicators_FirstExtent_flag { get; set; }
        public bool QualityIndicators_SecondExtent_flag { get; set; }
        public bool QualityIndicators_ThirdExtent_flag { get; set; }
        public int QualityIndicators_NUCr_or_NACv { get; set; }
        public int QualityIndicators_NUCp_or_NIC { get; set; }
        public int QualityIndicators_NICbaro { get; set; }
        public int QualityIndicators_SIL { get; set; }
        public int QualityIndicators_NACp { get; set; }
        public string QualityIndicators_SILsupplement { get; set; }
        public int QualityIndicators_SDA { get; set; }
        public int QualityIndicators_GVA { get; set; }
        public int QualityIndicators_PIC { get; set; }

        // Data Item I021/110, Trajectory Intent
        public bool TrajectoryIntent_FirstExtent_flag { get; set; }
        public bool TrajectoryIntent_SecondExtent_flag { get; set; }
        public bool TrajectoryIntent_TIS_subfield1 { get; set; } // absence or presence of Subfield #1
        public bool TrajectoryIntent_TID_subfield2 { get; set; } // absence or presence of Subfield #2
        public string TrajectoryIntent_NAV { get; set; }
        public string TrajectoryIntent_NVB { get; set; }
        public string[] TrajectoryIntent_TCA { get; set; } // Array size defined in the method
        public string[] TrajectoryIntent_NC { get; set; } // Array size defined in the method
        public int[] TrajectoryIntent_TCP { get; set; } // Array size defined in the method
        public double[] TrajectoryIntent_Altitude { get; set; } // Array size defined in the method
        public double[] TrajectoryIntent_Latitude { get; set; } // Array size defined in the method
        public double[] TrajectoryIntent_Longitude { get; set; } // Array size defined in the method
        public string[] TrajectoryIntent_PointType { get; set; } // Array size defined in the method
        public string[] TrajectoryIntent_TD { get; set; } // Array size defined in the method
        public string[] TrajectoryIntent_TRA { get; set; } // Array size defined in the method
        public string[] TrajectoryIntent_TOA { get; set; } // Array size defined in the method
        public double[] TrajectoryIntent_TOV { get; set; } // Array size defined in the method
        public double[] TrajectoryIntent_TTR { get; set; } // Array size defined in the method

        // Data Item I021/130, Position in WGS-84 Co-ordinates
        //public double PositionWGS84Coordinates_Latitude { get; set; }
        //public double PositionWGS84Coordinates_Longitude { get; set; }

        // Data Item I021/131, High-Resolution Position in WGS-84 Co-ordinates
        public double PositionWGS84Coordinates_HighResolution_Latitude { get; set; }
        public double PositionWGS84Coordinates_HighResolution_Longitude { get; set; }

        // Data Item I021/132, Message Amplitude
        public double MessageAmplitude { get; set; }

        // Data Item I021/140, Geometric Height
        public double GeometricHeight { get; set; }

        // Data Item I021/145, Flight Level
        public double FlightLevel { get; set; }

        // Data Item I021/146, Selected Altitude
        public string SelectedAltitude_SAS { get; set; }
        public string SelectedAltitude_Source { get; set; }
        public double SelectedAltitude_Altitude { get; set; }

        // Data Item I021/148, Final State Selected Altitude
        public string FinalStateSelectedAltitude_MV { get; set; }
        public string FinalStateSelectedAltitude_AH { get; set; }
        public string FinalStateSelectedAltitude_AM { get; set; }
        public double FinalStateSelectedAltitude_Altitude { get; set; }

        // Data Item I021/150, Air Speed
        public string AirSpeed_IM { get; set; }
        public double AirSpeed { get; set; }

        // Data Item I021/151 True Air Speed
        public string TrueAirSpeed_RE { get; set; }
        public double TrueAirSpeed { get; set; }

        // Data Item I021/152, Magnetic Heading
        public double MagneticHeading { get; set; }

        // Data Item I021/155, Barometric Vertical Rate
        public string BarometricVerticalRate_RE { get; set; }
        public double BarometricVerticalRate { get; set; }

        // Data Item I021/157, Geometric Vertical Rate
        public string GeometricVerticalRate_RE { get; set; }
        public double GeometricVerticalRate { get; set; }

        // Data Item I021/160, Airborne Ground Vector
        public string AirborneGroundVector_RE { get; set; }
        public double AirborneGroundVector_GroundSpeed { get; set; }
        public double AirborneGroundVector_TrackAngle { get; set; }

        // Data Item I021/161: Track Number
        //public int TrackNumber { get; set; }

        // Data Item I021/165, Track Angle Rate
        public double TrackAngleRate { get; set; }

        // Data Item I021/170, Target Identification
        public string TargetIdentification { get; set; }

        // Data Item I021/200, Target Status
        public string TargetStatus_ICF { get; set; }
        public string TargetStatus_LNAV { get; set; }
        public string TargetStatus_PS { get; set; }
        public string TargetStatus_SS { get; set; }

        // Data Item I021/210, MOPS Version
        public string MOPSVersion_VNS { get; set; }
        public string MOPSVersion_VN { get; set; }
        public string MOPSVersion_LTT { get; set; }

        // Data Item I021/220, Met Information
        public bool MetInformation_WS_subfield1 { get; set; } // absence or presence of Subfield #1
        public bool MetInformation_WD_subfield2 { get; set; } // absence or presence of Subfield #2
        public bool MetInformation_TMP_subfield3 { get; set; } // absence or presence of Subfield #3
        public bool MetInformation_TRB_subfield4 { get; set; } // absence or presence of Subfield #4
        public double MetInformation_WindSpeed { get; set; }
        public double MetInformation_WindDirection { get; set; }
        public double MetInformation_Temperature { get; set; }
        public int MetInformation_Turbulence { get; set; }

        // Data Item I021/230, Roll Angle
        public double RollAngle { get; set; }

        // Data Item I021/250, Mode S MB Data 
        //public int ModeSMBData_REP { get; set; }
        //public int[] ModeSMBData_MBData { get; set; } // Array size defined in the method
        //public int[] ModeSMBData_BDS1 { get; set; } // Array size defined in the method
        //public int[] ModeSMBData_BDS2 { get; set; } // Array size defined in the method

        // Data Item I021/260, ACAS Resolution Advisory Report
        public int ACASResolutionAdvisoryReport_TYP { get; set; }
        public int ACASResolutionAdvisoryReport_STYP { get; set; }
        public int ACASResolutionAdvisoryReport_ARA { get; set; }
        public int ACASResolutionAdvisoryReport_RAC { get; set; }
        public int ACASResolutionAdvisoryReport_RAT { get; set; }
        public int ACASResolutionAdvisoryReport_MTE { get; set; }
        public int ACASResolutionAdvisoryReport_TTI { get; set; }
        public int ACASResolutionAdvisoryReport_TID { get; set; }

        // Data Item I021/271, Surface Capabilities and Characteristics
        public bool SurfaceCapabilitiesandCharacteristics_FirstExtent_flag { get; set; }
        public string SurfaceCapabilitiesandCharacteristics_POA { get; set; }
        public string SurfaceCapabilitiesandCharacteristics_CDTI_S { get; set; }
        public string SurfaceCapabilitiesandCharacteristics_B2low { get; set; }
        public string SurfaceCapabilitiesandCharacteristics_RAS { get; set; }
        public string SurfaceCapabilitiesandCharacteristics_IDENT { get; set; }
        public int SurfaceCapabilitiesandCharacteristics_LW { get; set; }

        // Data Item I021/295, Data Ages
        public bool DataAges_FirstExtent_flag { get; set; }
        public bool DataAges_SecondExtent_flag { get; set; }
        public bool DataAges_ThirdExtent_flag { get; set; }
        // --------------------------------------
        public bool[] DataAges_subfields { get; set; } = new bool[23];// absence or presence of Subfield #X

        public bool DataAges_AOS_subfield1 { get; set; } // absence or presence of Subfield #1
        public bool DataAges_TRD_subfield2 { get; set; } // absence or presence of Subfield #2
        public bool DataAges_M3A_subfield3 { get; set; } // absence or presence of Subfield #3
        public bool DataAges_QI_subfield4 { get; set; } // absence or presence of Subfield #4
        public bool DataAges_TI_subfield5 { get; set; } // absence or presence of Subfield #5
        public bool DataAges_MAM_subfield6 { get; set; } // absence or presence of Subfield #6
        public bool DataAges_GH_subfield7 { get; set; } // absence or presence of Subfield #7
        public bool DataAges_FL_subfield8 { get; set; } // absence or presence of Subfield #8
        public bool DataAges_ISA_subfield9 { get; set; } // absence or presence of Subfield #9
        public bool DataAges_FSA_subfield10 { get; set; } // absence or presence of Subfield #10
        public bool DataAges_AS_subfield11 { get; set; } // absence or presence of Subfield #11
        public bool DataAges_TAS_subfield12 { get; set; } // absence or presence of Subfield #12
        public bool DataAges_MH_subfield13 { get; set; } // absence or presence of Subfield #13
        public bool DataAges_BVR_subfield14 { get; set; } // absence or presence of Subfield #14
        public bool DataAges_GVR_subfield15 { get; set; } // absence or presence of Subfield #15
        public bool DataAges_GV_subfield16 { get; set; } // absence or presence of Subfield #16
        public bool DataAges_TAR_subfield17 { get; set; } // absence or presence of Subfield #17
        public bool DataAges_TI_subfield18 { get; set; } // absence or presence of Subfield #18
        public bool DataAges_TS_subfield19 { get; set; } // absence or presence of Subfield #19
        public bool DataAges_MET_subfield20 { get; set; } // absence or presence of Subfield #20
        public bool DataAges_ROA_subfield21 { get; set; } // absence or presence of Subfield #21
        public bool DataAges_ARA_subfield22 { get; set; } // absence or presence of Subfield #22
        public bool DataAges_SCC_subfield23 { get; set; } // absence or presence of Subfield #23
        // --------------------------------------
        public double[] DataAges { get; set; } = new double[23];

        public double DataAges_AOS { get; set; }
        public double DataAges_TRD { get; set; }
        public double DataAges_M3A { get; set; }
        public double DataAges_QI { get; set; }
        public double DataAges_TI { get; set; }
        public double DataAges_MAM { get; set; }
        public double DataAges_GH { get; set; }
        public double DataAges_FL { get; set; }
        public double DataAges_ISA { get; set; }
        public double DataAges_FSA { get; set; }
        public double DataAges_AS { get; set; }
        public double DataAges_TAS { get; set; }
        public double DataAges_MH { get; set; }
        public double DataAges_BVR { get; set; }
        public double DataAges_GVR { get; set; }
        public double DataAges_GV { get; set; }
        public double DataAges_TAR { get; set; }
        public double DataAges_TaI { get; set; }
        public double DataAges_TS { get; set; }
        public double DataAges_MET { get; set; }
        public double DataAges_ROA { get; set; }
        public double DataAges_ARA { get; set; }
        public double DataAges_SCC { get; set; }

        // Data Item I021 / 400, Receiver ID
        public int ReceiverID { get; set; }
    }
}
