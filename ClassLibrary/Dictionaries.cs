using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Dictionaries
    {
        // CAT10
        // Field Types
        public static readonly string[] DSI = new string[2] { "System Area Code fixed to zero", "System Identification Code" };
        public static readonly string[] MT = new string[1] { "Message Type" };
        public static readonly string[] TRD = new string[11] { "TYP", "DCR", "CHN", "GBS", "CRT", "SIM", "TST", "RAB", "LOP", "TOT", "SPI" };
        public static readonly string[] TOD = new string[1] { "Time of Day [s]" };
        public static readonly string[] PWGS84C = new string[2] { "Latitude in WGS - 84 [deg]", "Longitude in WGS - 84 [deg]" };
        public static readonly string[] MPPC = new string[2] { "RHO [m]", "THETA [deg]" };
        public static readonly string[] PCC = new string[2] { "X-Component [m]", "Y-Component [m]" };
        public static readonly string[] CTVPC = new string[2] { "Ground Speed [kt]", "Track Angle [deg]" };
        public static readonly string[] CTVCC = new string[2] { "Vx [m/s]", "Vy [m/s]" };
        public static readonly string[] TN = new string[1] { "Track Number" };
        public static readonly string[] TS = new string[10] { "CNF", "TRE", "CST", "MAH", "TCC", "STH", "TOM", "DOU", "MRS", "GHO" };
        public static readonly string[] M3ACOR = new string[4] { "V", "G", "L", "Mode-3/A reply in octal representation" };
        public static readonly string[] TA = new string[1] { "Track Address" };
        public static readonly string[] TI = new string[2] { "STI", "Target Identification" };
        public static readonly string[] MSMBD = new string[3] { "Mode S Comm B message data", "Comm B Data Buffer Store 1 Address", "Comm B Data Buffer Store 2 Address" };
        public static readonly string[] VFI = new string[1] { "Vehicle Fleet Identification" };
        public static readonly string[] FLBR = new string[3] { "V", "G", "Flight Level [FL]" };
        public static readonly string[] MH = new string[1] { "Measured Height [ft]" };
        public static readonly string[] TSO = new string[3] { "Length [m]", "Orientation [deg]", "Width [m]" };
        public static readonly string[] SS = new string[5] { "NOGO", "OVL", "TSV", "DIV", "TTF" };
        public static readonly string[] PPM = new string[2] { "TRB", "MSG" };
        public static readonly string[] SDP = new string[3] { "Standard Deviation of X component [m]", "Standard Deviation of Y component [m]", "Covariance in two’s complement form [m^2]" };
        public static readonly string[] P = new string[2] { "DRHO [m]", "DTHETA [deg]" };
        public static readonly string[] APP = new string[1] { "PAM" };
        public static readonly string[] CA = new string[2] { "Ax [m/s^2]", "Ay [m/s^2]" };

        public static readonly IDictionary<int, string> FieldType_Code_CAT10_dict = new Dictionary<int, string>() { { 10, "I010/010" }, { 0, "I010/000" }, { 20, "I010/020" }, { 140, "I010/140" }, { 41, "I010/041" }, { 40, "I010/040" }, { 42, "I010/042" }, { 200, "I010/200" }, { 202, "I010/202" }, { 161, "I010/161" }, { 170, "I010/170" }, { 60, "I010/060" }, { 220, "I010/220" }, { 245, "I010/245" }, { 250, "I010/250" }, { 300, "I010/300" }, { 90, "I010/090" }, { 91, "I010/091" }, { 270, "I010/270" }, { 550, "I010/550" }, { 310, "I010/310" }, { 500, "I010/500" }, { 280, "I010/280" }, { 131, "I010/131" }, { 210, "I010/210" } };
        public static readonly IDictionary<int, string> FieldType_Name_CAT10_dict = new Dictionary<int, string>() { { 10, "Data Source Identifier" }, { 0, "Message Type" }, { 20, "Target Report Descriptor" }, { 140, "Time of Day" }, { 41, "Position in WGS-84 Co-ordinates" }, { 40, "Measured Position in Polar Co-ordinates" }, { 42, "Position in Cartesian Co-ordinates" }, { 200, "Calculated Track Velocity in Polar Co-ordinates" }, { 202, "Calculated Track Velocity in Cartesian Coord." }, { 161, "Track Number" }, { 170, "Track Status" }, { 60, "Mode-3/A Code in Octal Representation" }, { 220, "Target Address" }, { 245, "Target Identification" }, { 250, "Mode S MB Data" }, { 300, "Vehicle Fleet Identification" }, { 90, "Flight Level in Binary Representation" }, { 91, "Measured Height" }, { 270, "Target Size & Orientation" }, { 550, "System Status" }, { 310, "Pre-programmed Message" }, { 500, "Standard Deviation of Position" }, { 280, "Presence" }, { 131, "Amplitude of Primary Plot" }, { 210, "Calculated Acceleration" } };
        public static readonly IDictionary<int, string[]> FieldType_ItemsName_CAT10_dict = new Dictionary<int, string[]>() { { 10, DSI }, { 0, MT }, { 20, TRD }, { 140, TOD }, { 41, PWGS84C }, { 40, MPPC }, { 42, PCC }, { 200, CTVPC }, { 202, CTVCC }, { 161, TN }, { 170, TS }, { 60, M3ACOR }, { 220, TA }, { 245, TI }, { 250, MSMBD }, { 300, VFI }, { 90, FLBR }, { 91, MH }, { 270, TSO }, { 550, SS }, { 310, PPM }, { 500, SDP }, { 280, P }, { 131, APP }, { 210, CA } };

        // Data Item I010/000, Message Type
        public static readonly IDictionary<int, string> MessageType_dict = new Dictionary<int, string>() { { 1, "Target Report" }, { 2, "Start of Update Cycle" }, { 3, "Periodic Status Message" }, { 4, "Event-triggered Status Message" } };

        // Data Item I010/020, Target Report Descriptor
        public static readonly IDictionary<int, string> TargetReportDescriptor_TYP_dict = new Dictionary<int, string>() { { 0, "SSR multilateration" }, { 1, "Mode S multilateration" }, { 2, "ADS-B" }, { 3, "PSR" }, { 4, "Magnetic Loop System" }, { 5, "HF multilateration" }, { 6, "Not defined" }, { 7, "Other types" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_DCR_dict = new Dictionary<bool, string>() { { false, "No differential correction (ADS-B)" }, { true, "Differential correction (ADS-B)" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_CHN_dict = new Dictionary<bool, string>() { { false, "Chain 1" }, { true, "Chain 2" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_GBS_dict = new Dictionary<bool, string>() { { false, "Transponder Ground bit not set" }, { true, "Transponder Ground bit set" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_CRT_dict = new Dictionary<bool, string>() { { false, "No Corrupted reply in multilateration" }, { true, "Corrupted replies in multilateration" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SIM_dict = new Dictionary<bool, string>() { { false, "Actual target report" }, { true, "Simulated target report " } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_TST_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Test Target" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RAB_dict = new Dictionary<bool, string>() { { false, "Report from target transponder" }, { true, "Report from field monitor (fixed transponder)" } };
        public static readonly IDictionary<int, string> TargetReportDescriptor_LOP_dict = new Dictionary<int, string>() { { 0, "Undetermined" }, { 1, "Loop start" }, { 2, "Loop finish" } };
        public static readonly IDictionary<int, string> TargetReportDescriptor_TOT_dict = new Dictionary<int, string>() { { 0, "Undetermined" }, { 1, "Aircraft" }, { 2, "Ground vehicle" }, { 3, "Helicopter" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SPI_dict = new Dictionary<bool, string>() { { false, "Absence of SPI " }, { true, "Special Position Identification" } };

        // Data Item I010/060, Mode-3/A Code in Octal Representation and...
        // Data Item I010/090, Flight Level in Binary Representation
        public static readonly IDictionary<bool, string> Mode3ACodeV_and_FlightLevelV_dict = new Dictionary<bool, string>() { { false, "Code validated" }, { true, "Code not validated" } };
        public static readonly IDictionary<bool, string> Mode3ACodeG_and_FlightLevelG_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Garbled code" } };
        public static readonly IDictionary<bool, string> Mode3ACodeL_dict = new Dictionary<bool, string>() { { false, "Mode-3/A code derived from the reply of the transponder" }, { true, "Mode-3/A code not extracted during the last scan" } };

        // Data Item I010/170, Track Status
        public static readonly IDictionary<bool, string> TrackStatus_CNF_dict = new Dictionary<bool, string>() { { false, "Confirmed track" }, { true, "Track in initialisation phase" } };
        public static readonly IDictionary<bool, string> TrackStatus_TRE_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Last report for a track" } };
        public static readonly IDictionary<int, string> TrackStatus_CST_dict = new Dictionary<int, string>() { { 0, "No extrapolation" }, { 1, "Predictable extrapolation due to sensor refresh period (see NOTE)" }, { 2, "Predictable extrapolation in masked area" }, { 3, "Extrapolation due to unpredictable absence of detection" } };
        public static readonly IDictionary<bool, string> TrackStatus_MAH_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Horizontal manoeuvre" } };
        public static readonly IDictionary<bool, string> TrackStatus_TCC_dict = new Dictionary<bool, string>() { { false, "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied." }, { true, "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates." } };
        public static readonly IDictionary<bool, string> TrackStatus_STH_dict = new Dictionary<bool, string>() { { false, "Measured position" }, { true, "Smoothed position" } };
        public static readonly IDictionary<int, string> TrackStatus_TOM_dict = new Dictionary<int, string>() { { 0, "Unknown type of movement" }, { 1, "Taking-off" }, { 2, "Landing" }, { 3, "Other types of movement" } };
        public static readonly IDictionary<int, string> TrackStatus_DOU_dict = new Dictionary<int, string>() { { 0, "No doubt" }, { 1, "Doubtful correlation (undetermined reason)" }, { 2, "Doubtful correlation in clutter" }, { 3, "Loss of accuracy" }, { 4, "Loss of accuracy in clutter" }, { 5, "Unstable track" }, { 6, "Previously coasted" } };
        public static readonly IDictionary<int, string> TrackStatus_MRS_dict = new Dictionary<int, string>() { { 0, "Merge or split indication undetermined" }, { 1, "Track merged by association to plot" }, { 2, "Track merged by non-association to plot" }, { 3, "Split track" } };
        public static readonly IDictionary<bool, string> TrackStatus_GHO_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Ghost track" } };

        // Data Item I010/245, Target Identification
        public static readonly IDictionary<int, string> TartgetIdentificationSTI_dict = new Dictionary<int, string>() { { 0, "Callsign or registration downlinked from transponder" }, { 1, "Callsign not downlinked from transponder" }, { 2, "Registration not downlinked from transponder" } };
        public static readonly IDictionary<int, string> TargetIdentificationCharacters_dict = new Dictionary<int, string>() { { 1, "A" }, { 2, "B" }, { 3, "C" }, { 4, "D" }, { 5, "E" }, { 6, "F" }, { 7, "G" }, { 8, "H" }, { 9, "I" }, { 10, "J" }, { 11, "K" }, { 12, "L" }, { 13, "M" }, { 14, "N" }, { 15, "O" }, { 16, "P" }, { 17, "Q" }, { 18, "R" }, { 19, "S" }, { 20, "T" }, { 21, "U" }, { 22, "V" }, { 23, "W" }, { 24, "X" }, { 25, "Y" }, { 26, "Z" }, { 32, " " }, { 48, "0" }, { 49, "1" }, { 50, "2" }, { 51, "3" }, { 52, "4" }, { 53, "5" }, { 54, "6" }, { 55, "7" }, { 56, "8" }, { 57, "9" } };

        // Data Item I010/300, Vehicle Fleet Identification
        public static readonly IDictionary<int, string> VehicleFleetIdentification_VFI_dict = new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "ATC equipment maintenance" }, { 2, "Airport maintenance" }, { 3, "Fire" }, { 4, "Bird scarer" }, { 5, "Snow plough" }, { 6, "Runway sweeper" }, { 7, "Emergency" }, { 8, "Police" }, { 9, "Bus" }, { 10, "Tug (push/tow)" }, { 11, "Grass cutter" }, { 12, "Fuel" }, { 13, "Baggage" }, { 14, "Catering" }, { 15, "Aircraft maintenance" }, { 16, "Flyco (follow me)" } };

        // Data Item I010/310, Pre-programmed Message
        public static readonly IDictionary<bool, string> PreprogrammedMessage_TRB_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "In Trouble" } };
        public static readonly IDictionary<int, string> PreprogrammedMessage_MSG_dict = new Dictionary<int, string>() { { 1, "Towing aircraf" }, { 2, "'Follow me' operation" }, { 3, "Runway check" }, { 4, "Emergency operation (fire, medical…)" }, { 5, "Work in progress (maintenance, birds scarer, sweepers…)" } };

        // Data Item I010/550, System Status
        public static readonly IDictionary<int, string> SystemStatus_NOGO_dict = new Dictionary<int, string>() { { 0, "Operational" }, { 1, "Degraded" }, { 2, "NOGO" } };
        public static readonly IDictionary<bool, string> SystemStatus_OVL_dict = new Dictionary<bool, string>() { { false, "No overload" }, { true, "Overload" } };
        public static readonly IDictionary<bool, string> SystemStatus_TSV_dict = new Dictionary<bool, string>() { { false, "valid" }, { true, "invalid" } };
        public static readonly IDictionary<bool, string> SystemStatus_DIV_dict = new Dictionary<bool, string>() { { false, "Normal Operation" }, { true, "Diversity degraded" } };
        public static readonly IDictionary<bool, string> SystemStatus_TTF_dict = new Dictionary<bool, string>() { { false, "Test Target Operative" }, { true, "Test Target Failure" } };

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // CAT21
        // Field Types
        public static readonly string[] DSI_cat21 = new string[2] { "System Area Code", "System Identification Code" };
        public static readonly string[] TRD_cat21 = new string[15] { "Address Type", "Altitude Reporting Capability", "Range Check", "Report Type", "Differential Correction", "Ground Bit Setting", "Simulated Target", "Test Target", "Selected Altitude Available", "Confidence Level", "Independent Position Check", "No-go Bit Status", "Compact Position Reporting", "Local Decoding Position Jump", "Range Check" };
        //public static readonly string[] TN = new string[1] { "Track Number" };
        public static readonly string[] SI = new string[1] { "Service Identification" };
        public static readonly string[] TAP = new string[1] { "Time of Applicability of Position [s]" };
        //public static readonly string[] PWGS84C = new string[2] { "Latitude in WGS - 84 [deg]", "Longitude in WGS - 84 [deg]" };
        //public static readonly string[] PWGS84CHR = new string[2] { "Latitude in WGS - 84 [deg]", "Longitude in WGS - 84 [deg]" };
        public static readonly string[] TAV = new string[1] { "Time of Applicability of Velocity [s]" };
        public static readonly string[] AS = new string[2] { "IM", "Air Speed [IAS: NM/s, Mach:-]" };
        public static readonly string[] TAS = new string[2] { "“Range Exceeded” Indicator", "True Air Speed [kt]" };
        public static readonly string[] TargAdd = new string[1] { "Target Address" };
        public static readonly string[] TMRP = new string[1] { "Time of Message Reception of Position [s]" };
        public static readonly string[] TMRPHP = new string[2] { "Full Second Indication", "Time of Message Reception of Position – high precision [s]" };
        public static readonly string[] TMRV = new string[1] { "Time of Message Reception of Velocity [s]" };
        public static readonly string[] TMRVHP = new string[2] { "Full Second Indication", "Time of Message Reception of Velocity – high precision [s]" };
        public static readonly string[] GH = new string[1] { "Geometric Height [ft]" };
        public static readonly string[] QI = new string[9] { "“Navigation Uncertainty Category for velocity” NUCr or the “Navigation Accuracy Category for Velocity” NACv", "“Navigation Uncertainty Category for Position” NUCp or “Navigation Integrity Category” NIC", "Navigation Integrity Category for Barometric Altitude", "Surveillance (version 1) or Source (version 2) Integrity Level", "Navigation Accuracy Category for Position", "SIL-Supplement", "Horizontal Position System Design Assurance Level (as defined in version 2)", "Geometric Altitude Accuracy", "Position Integrity Category" };
        public static readonly string[] MOPSV = new string[3] { "Version Not Supported", "Version Number", "Link Technology Type" };
        public static readonly string[] M3ACOR_cat21 = new string[1] { "Mode-3/A reply in octal representation" };
        public static readonly string[] RA = new string[1] { "Roll Angle [deg]" };
        public static readonly string[] FL = new string[1] { "Flight Level [FL]" };
        public static readonly string[] MagHea = new string[1] { "Magnetic Heading [deg]" };
        public static readonly string[] TargSta = new string[4] { "Intent Change Flag", "LNAV Mode", "Priority Status", "Surveillance Status" };
        public static readonly string[] BVR = new string[2] { "“Range Exceeded” Indicator", "Barometric Vertical Rate [ft/min]" };
        public static readonly string[] GVR = new string[2] { "“Range Exceeded” Indicator", "Geometric Vertical Rate [ft/min]" };
        public static readonly string[] AGV = new string[3] { "“Range Exceeded” Indicator", "Ground Speed referenced to WGS-84 [NM/s]", "Track Angle clockwise reference to “True North” [deg]" };
        public static readonly string[] TAR = new string[1] { "Track Angle Rate [deg/s]" };
        public static readonly string[] TART = new string[1] { "Time of ASTERIX Report Transmission [s]" };
        public static readonly string[] TI_cat21 = new string[1] { "Target Identification" };
        public static readonly string[] EC = new string[1] { "Emitter Category" };
        public static readonly string[] MI = new string[4] { "Wind Speed [kt]", "Wind Direction [deg]", "Temperature [°C]", "Turbulence" };
        public static readonly string[] SA = new string[3] { "Source Availability", "Source", "Altitude [ft]" };
        public static readonly string[] FSSA = new string[4] { "Manage Vertical Mode", "Altitude Hold Mode", "Approach Mode", "Altitude [ft]" };
        public static readonly string[] TrajInt = new string[14] { "NAV", "NVB", "TCA", "NC", "Trajectory Change Point number", "Altitude [ft]", "Latitude [deg]", "Longitude [deg]", "Point Type", "TD", "Turn Radius Availabilty", "TOA", "Time Over Point", "TCP Turn radius" };
        public static readonly string[] SM = new string[1] { "Report Period [s]" };
        public static readonly string[] AOS = new string[7] { "TCAS Resolution Advisory active", "Target Trajectory Change Report Capability", "Target State Report Capability", "Air-Referenced Velocity Report Capability", "Cockpit Display of Traffic Information airborne", "TCAS System Status", "Single Antenna" };
        public static readonly string[] SCC = new string[6] { "Position Offset Applied", "Cockpit Display of Traffic Information Surface", "Class B2 transmit power less than 70 Watts", "Receiving ATC Services", "Setting of “IDENT”-switch", "Length and width of the aircraft" };
        public static readonly string[] MA = new string[1] { "Message Amplitude [dBm]" };
        //public static readonly string[] MSMBD = new string[3] { "Mode S Comm B message data", "Comm B Data Buffer Store 1 Address", "Comm B Data Buffer Store 2 Address" };
        public static readonly string[] ACASRAR = new string[8] { "Message Type (= 28 for 1090 ES, version 2)", "Message Sub-type (= 2 for 1090 ES, version 2)", "Active Resolution Advisories", "RAC (RA Complement) Record", "RA Terminated", "Multiple Threat Encounter", "Threat Type Indicator", "Threat Identity Data" };
        public static readonly string[] RID = new string[1] { "Receiver ID" };
        public static readonly string[] DA = new string[23] { "Age of the latest received information transmitted in item I021/008 [s]", "Age of the last update of the Target Report Descriptor, item I021/040 [s]", "Age of the last update of the Mode 3/A Code, item I021/070 [s]", "Age of the latest information received to update the Quality Indicators, item I021/090 [s]", "Age of the last update of the Trajectory Intent information updating item I021/110 [s]", "Age of the latest measurement of the message amplitude, item I021/132 [s]", "Age of the information contained in item 021/140 [s]", "Age of the Flight Level information in item I021/145 [s]", "Age of the Intermediate State Selected Altitude in item I021/146 [s]", "Age of the Final State Selected Altitude in item I021/148 [s]", "Age of the Air Speed contained in item I021/150 [s]", "Age of the value for the True Air Speed in item I021/151 [s]", "Age of the value for the Magnetic Heading in item I021/152 [s]", "Age of the Barometric Vertical Rate contained in I021/155 [s]", "Age of the Geometric Vertical Rate in item I021/157 [s]", "Age of the Ground Vector in item I021/160 [s]", "Age of item I021/165 Track Angle Rate [s]", "Age of the Target Identification in item I021/170 [s]", "Age of the Target Status as contained in item I021/200 [s]", "Age of the Meteorological data contained in I021/220 [s]", "Age of the Roll Angle value as in item I021/230 [s]", "Age of the latest update of an active ACAS Resolution Advisory [s]", "Age of the latest information received on the surface capabilities and characteristics of the respective target [s]" };

        public static readonly IDictionary<int, string> FieldType_Code_CAT21_dict = new Dictionary<int, string>() { { 10, "I021/010" }, { 40, "I021/040" }, { 161, "I021/161" }, { 15, "I021/015" }, { 71, "I021/071" }, { 130, "I021/130" }, { 131, "I021/131" }, { 72, "I021/072" }, { 150, "I021/150" }, { 151, "I021/151" }, { 80, "I021/080" }, { 73, "I021/073" }, { 74, "I021/074" }, { 75, "I021/075" }, { 76, "I021/076" }, { 140, "I021/140" }, { 90, "I021/090" }, { 210, "I021/210" }, { 70, "I021/070" }, { 230, "I021/230" }, { 145, "I021/145" }, { 152, "I021/152" }, { 200, "I021/200" }, { 155, "I021/155" }, { 157, "I021/157" }, { 160, "I021/160" }, { 165, "I021/165" }, { 77, "I021/077" }, { 170, "I021/170" }, { 20, "I021/020" }, { 220, "I021/220" }, { 146, "I021/146" }, { 148, "I021/148" }, { 110, "I021/110" }, { 16, "I021/016" }, { 8, "I021/008" }, { 271, "I021/271" }, { 132, "I021/132" }, { 250, "I021/250" }, { 260, "I021/260" }, { 400, "I021/400" }, { 295, "I021/295" } };
        public static readonly IDictionary<int, string> FieldType_Name_CAT21_dict = new Dictionary<int, string>() { { 10, "Data Source Identification" }, { 40, "Target Report Descriptor" }, { 161, "Track Number" }, { 15, "Service Identification" }, { 71, "Time of Applicability for Position" }, { 130, "Position in WGS-84 co-ordinates" }, { 131, "Position in WGS-84 co-ordinates, high res." }, { 72, "Time of Applicability for Velocity" }, { 150, "Air Speed" }, { 151, "True Air Speed" }, { 80, "Target Address" }, { 73, "Time of Message Reception of Position" }, { 74, "Time of Message Reception of Position-High Precision" }, { 75, "Time of Message Reception of Velocity" }, { 76, "Time of Message Reception of Velocity-High Precision" }, { 140, "Geometric Height" }, { 90, "Quality Indicators" }, { 210, "MOPS Version" }, { 70, "Mode 3/A Code" }, { 230, "Roll Angle" }, { 145, "Flight Level" }, { 152, "Magnetic Heading" }, { 200, "Target Status" }, { 155, "Barometric Vertical Rate" }, { 157, "Geometric Vertical Rate" }, { 160, "Airborne Ground Vector" }, { 165, "Track Angle Rate" }, { 77, "Time of Report Transmission" }, { 170, "Target Identification" }, { 20, "Emitter Category" }, { 220, "Met Information" }, { 146, "Selected Altitude" }, { 148, "Final State Selected Altitude" }, { 110, "Trajectory Intent" }, { 16, "Service Management" }, { 8, "Aircraft Operational Status" }, { 271, "Surface Capabilities and Characteristics" }, { 132, "Message Amplitude" }, { 250, "Mode S MB Data" }, { 260, "ACAS Resolution Advisory Report" }, { 400, "Receiver ID" }, { 295, "Data Ages" } };
        public static readonly IDictionary<int, string[]> FieldType_ItemsName_CAT21_dict = new Dictionary<int, string[]>() { { 10, DSI_cat21 }, { 40, TRD_cat21 }, { 161, TN }, { 15, SI }, { 71, TAP }, { 130, PWGS84C }, { 131, PWGS84C }, { 72, TAV }, { 150, AS }, { 151, TAS }, { 80, TargAdd }, { 73, TMRP }, { 74, TMRPHP }, { 75, TMRV }, { 76, TMRVHP }, { 140, GH }, { 90, QI }, { 210, MOPSV }, { 70, M3ACOR_cat21 }, { 230, RA }, { 145, FL }, { 152, MagHea }, { 200, TargSta }, { 155, BVR }, { 157, GVR }, { 160, AGV }, { 165, TAR }, { 77, TART }, { 170, TI_cat21 }, { 20, EC }, { 220, MI }, { 146, SA }, { 148, FSSA }, { 110, TrajInt }, { 16, SM }, { 8, AOS }, { 271, SCC }, { 132, MA }, { 250, MSMBD }, { 260, ACASRAR }, { 400, RID }, { 295, DA } };

        //Data Item I021/008, Aircraft Operational Status
        public static readonly IDictionary<bool, string> AircrafOperationalStatus_RA_dict = new Dictionary<bool, string>() { { false, "TCAS II or ACAS RA not active" }, { true, "TCAS RA active " } };
        public static readonly IDictionary<int, string> AircraftOperationalStatus_TC_dict = new Dictionary<int, string>() { { 0, "no capability for Trajectory Change Reports " }, { 1, "support for TC+0 reports only " }, { 2, "support for multiple TC reports" }, { 3, "reserved" } };
        public static readonly IDictionary<bool, string> AircraftOperationalStatus_TS_dict = new Dictionary<bool, string>() { { false, "no capability to support Target State Reports" }, { true, "capable of supporting target State Reports" } };
        public static readonly IDictionary<bool, string> AircraftOperationalStatus_ARV_dict = new Dictionary<bool, string>() { { false, "no capability to generate ARV-reports " }, { true, "capable of generate ARV-reports" } };
        public static readonly IDictionary<bool, string> AircraftOperationalStatus_CDTI_dict = new Dictionary<bool, string>() { { false, "CDTI not operational" }, { true, "CDTI operational " } };
        public static readonly IDictionary<bool, string> AircraftOperationalStatus_TCAS_dict = new Dictionary<bool, string>() { { false, "TCAS  operational" }, { true, "TCAS no operational " } };
        public static readonly IDictionary<bool, string> AircraftOperationalStatus_SA_dict = new Dictionary<bool, string>() { { false, "Antenna Divesity" }, { true, "Single Antenna  " } };

        // Data Item I021/020, Emitter Category
        public static readonly IDictionary<int, string> EmitterCategory_dict = new Dictionary<int, string>() { { 0, "No ADS-B Emitter Category Information" }, { 1, "light aircraft <= 15500 lbs" }, { 2, "15500 lbs < small aircraft <75000 lbs" }, { 3, "75000 lbs < medium a/c < 300000 lbs" }, { 4, "High Vortex Large" }, { 5, "300000 lbs <= heavy aircraft" }, { 6, "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)" }, { 7, "reserved" }, { 8, "reserved" }, { 9, "reserved" }, { 10, "rotocraft" }, { 11, "glider / sailplane" }, { 12, "lighter-than-air" }, { 13, "unmanned aerial vehicle" }, { 14, "space / transatmospheric vehicle" }, { 15, "ultralight / handglider / paraglider" }, { 16, "parachutist / skydiver" }, { 17, "reserved" }, { 18, "reserved" }, { 19, "reserved" }, { 20, "surface emergency vehicle" }, { 21, "surface service vehicle" }, { 22, "fixed ground or tethered obstruction" }, { 23, "cluster obstacle" }, { 24, "line obstacle" } };

        // Data Item I021/040, Target Report Descriptor
        public static readonly IDictionary<int, string> TargetReportDescriptor_ATP_dict = new Dictionary<int, string>() { { 0, "24-Bit ICAO address" }, { 1, "Duplicate address" }, { 2, "Surface vehicle address" }, { 3, "Anonymous address" }, { 4, "Reserved for future use" }, { 5, "Reserved for future use" }, { 6, "Reserved for future use" }, { 7, "Reserved for future use" } };
        public static readonly IDictionary<int, string> TargetReportDescriptor_ARC_dict = new Dictionary<int, string>() { { 0, "25 ft" }, { 1, "100 ft" }, { 2, "Unknown" }, { 3, "Invalid" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RC_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Range Check passed, CPR Validation pending" } };
        //public static readonly IDictionary<bool, string> TargetReportDescriptor_RAB_dict = new Dictionary<bool, string>() { { false, "Report from target transponder" }, { true, "Report from field monitor (fixed transponder)" } };
        //public static readonly IDictionary<bool, string> TargetReportDescriptor_DCR_dict = new Dictionary<bool, string>() { { false, "No differential correction (ADS-B)" }, { true, "Differential correction (ADS-B)" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_GBS_cat21_dict = new Dictionary<bool, string>() { { false, "Ground Bit not set" }, { true, "Ground Bit set" } };
        //public static readonly IDictionary<bool, string> TargetReportDescriptor_SIM_dict = new Dictionary<bool, string>() { { false, "Actual target report" }, { true, "Simulated target report" } };
        //public static readonly IDictionary<bool, string> TargetReportDescriptor_TST_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Test Target" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SAA_dict = new Dictionary<bool, string>() { { false, "Equipment capable to provide Selected Altitude" }, { true, "Equipment not capable to provide Selected Altitude" } };
        public static readonly IDictionary<int, string> TargetReportDescriptor_CL_dict = new Dictionary<int, string>() { { 0, "Report valid" }, { 1, "Report suspect" }, { 2, "No information" }, { 3, "Reserved for future use" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_IPC_dict = new Dictionary<bool, string>() { { false, "default (see note)" }, { true, "Independent Position Check failed" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_NOGO_dict = new Dictionary<bool, string>() { { false, "NOGO-bit not set" }, { true, "NOGO-bit set" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_CPR_dict = new Dictionary<bool, string>() { { false, "CPR Validation correct" }, { true, "CPR Validation failed" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_LDPJ_dict = new Dictionary<bool, string>() { { false, "LDPJ not detected" }, { true, "LDPJ detected" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RCF_dict = new Dictionary<bool, string>() { { false, "default" }, { true, "Range Check failed" } };

        // Data Item I021/074, Time of Message Reception of Position–High Precision
        public static readonly IDictionary<int, string> TimeOfMessageReceptionOfPosition_HighPrecision_FSI_dict = new Dictionary<int, string>() { { 0, "TOMRp whole seconds = (I021/073) Whole seconds" }, { 1, "TOMRp whole seconds = (I021/073) Whole seconds + 1" }, { 2, "TOMRp whole seconds = (I021/073) Whole seconds – 1" }, { 3, "Reserved" } };

        // Data Item I021/076, Time of Message Reception of Velocity–High Precision
        public static readonly IDictionary<int, string> TimeOfMessageReceptionOfVelocity_HighPrecision_FSI_dict = new Dictionary<int, string>() { { 0, "TOMRv whole seconds = (I021/075) Whole seconds" }, { 1, "TOMRv whole seconds = (I021/075) Whole seconds + 1" }, { 2, "TOMRv whole seconds = (I021/075) Whole seconds – 1" }, { 3, "Reserved" } };

        // Data Item I021/090, Quality Indicators
        public static readonly IDictionary<bool, string> QualityIndicators_SILsupplement_dict = new Dictionary<bool, string>() { { false, "measured per flight-hour" }, { true, "measured per sample" } };

        // Data Item I021/110, Trajectory Intent
        //public static readonly IDictionary<bool, string> TrajectoryIntent_TIS_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #1" }, { true, "Presence of Subfield #1" } };
        //public static readonly IDictionary<bool, string> TrajectoryIntent_TID_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #2" }, { true, "Presence of Subfield #2" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_NAV_dict = new Dictionary<bool, string>() { { false, "Trajectory Intent Data is available for this aircraft" }, { true, "Trajectory Intent Data is not available for this aircraft" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_NVB_dict = new Dictionary<bool, string>() { { false, "Trajectory Intent Data is valid" }, { true, "Trajectory Intent Data is not valid" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TCA_dict = new Dictionary<bool, string>() { { false, "TCP number available" }, { true, "TCP number not available" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_NC_dict = new Dictionary<bool, string>() { { false, "TCP compliance" }, { true, "TCP non-compliance" } };
        public static readonly IDictionary<int, string> TrajectoryIntent_PointType_dict = new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "Fly by waypoint (LT)" }, { 2, "Fly over waypoint (LT)" }, { 3, "Hold pattern (LT)" }, { 4, "Procedure hold (LT)" }, { 5, "Procedure turn (LT)" }, { 6, "RF leg (LT)" }, { 7, "Top of climb (VT)" }, { 8, "Top of descent (VT)" }, { 9, "Start of level (VT)" }, { 10, "Cross-over altitude (VT)" }, { 11, "Transition altitude (VT)" } };
        public static readonly IDictionary<int, string> TrajectoryIntent_TD_dict = new Dictionary<int, string>() { { 0, "N/A" }, { 1, "Turn right" }, { 2, "Turn left" }, { 3, "No turn" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TRA_dict = new Dictionary<bool, string>() { { false, "TTR not available" }, { true, "TTR available" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TOA_dict = new Dictionary<bool, string>() { { false, "TOV available" }, { true, "TOV not available" } };

        // Data Item I021/146, Selected Altitude
        public static readonly IDictionary<bool, string> SelectedAltitude_SAS_dict = new Dictionary<bool, string>() { { false, "No source information provided" }, { true, "Source Information provided" } };
        public static readonly IDictionary<int, string> SelectedAltitude_Source_dict = new Dictionary<int, string>() { { 0, "Unknown " }, { 1, "Aircraft Altitude (Holding Altitude)" }, { 2, "MCP/FCU Selected Altitude " }, { 3, "FMS Selected Altitude " } };

        // Data Item I021/148, Final State Selected Altitude
        public static readonly IDictionary<bool, string> FinalStateSelectedAltitude_dict = new Dictionary<bool, string>() { { false, "Not active or unknown" }, { true, "Active" } };

        // Data Item I021/150, Air Speed
        public static readonly IDictionary<bool, string> AirSpeed_IM = new Dictionary<bool, string>() { { false, "Air Speed = IAS" }, { true, "Air Speed = MACH" } };

        // Data Item I021/151 True Airspeed &
        // Data Item I021/155, Barometric Vertical Rate &
        // Data Item I021/157, Geometric Vertical Rate &
        // Data Item I021/160, Airborne Ground Vector
        public static readonly IDictionary<bool, string> RE_dict = new Dictionary<bool, string>() { { false, "Value in defined range" }, { true, "Value exceeds defined range" } };

        // Data Item I021/170, Target Identification
        public static readonly IDictionary<int, string> TargetIdentification_dict = new Dictionary<int, string>() { { 0, "" }, { 1, "A" }, { 2, "B" }, { 3, "C" }, { 4, "D" }, { 5, "E" }, { 6, "F" }, { 7, "G" }, { 8, "H" }, { 9, "I" }, { 10, "J" }, { 11, "K" }, { 12, "L" }, { 13, "M" }, { 14, "N" }, { 15, "O" }, { 16, "P" }, { 17, "Q" }, { 18, "R" }, { 19, "S" }, { 20, "T" }, { 21, "U" }, { 22, "V" }, { 23, "W" }, { 24, "X" }, { 25, "Y" }, { 26, "Z" }, { 32, " " }, { 48, "0" }, { 49, "1" }, { 50, "2" }, { 51, "3" }, { 52, "4" }, { 53, "5" }, { 54, "6" }, { 55, "7" }, { 56, "8" }, { 57, "9" } };

        // Data Item I021/200, Target Status
        public static readonly IDictionary<bool, string> TargetStatus_ICF_dict = new Dictionary<bool, string>() { { false, "No intent change active" }, { true, "Intent change flag raised" } };
        public static readonly IDictionary<bool, string> TargetStatus_LNAV_dict = new Dictionary<bool, string>() { { false, "LNAV Mode engaged" }, { true, "LNAV Mode not engaged" } };
        public static readonly IDictionary<int, string> TargetStatus_PS_dict = new Dictionary<int, string>() { { 0, "No emergency / not reported" }, { 1, "General emergency" }, { 2, "Lifeguard / medical emergency" }, { 3, "Minimum fuel" }, { 4, "No communications" }, { 5, "Unlawful interference" }, { 6, "“Downed” Aircraft" } };
        public static readonly IDictionary<int, string> TargetStatus_SS_dict = new Dictionary<int, string>() { { 0, "No condition reported" }, { 1, "Permanent Alert (Emergency condition)" }, { 2, "Temporary Alert (change in Mode 3/A Code other than emergency)" }, { 3, "SPI set" } };

        // Data Item I021/210, MOPS Version
        public static readonly IDictionary<bool, string> MOPSVersion_VNS_dict = new Dictionary<bool, string>() { { false, "The MOPS Version is supported by the GS" }, { true, "The MOPS Version is not supported by the GS" } };
        public static readonly IDictionary<int, string> MOPSVersion_VN_dict = new Dictionary<int, string>() { { 0, "ED102/DO-260 [Ref. 8]" }, { 1, "DO-260A [Ref. 9]" }, { 2, "ED102A/DO-260B [Ref. 11]" } };
        public static readonly IDictionary<int, string> MOPSVersion_LTT_dict = new Dictionary<int, string>() { { 0, "Other" }, { 1, "UAT" }, { 2, "1090 ES" }, { 3, "VDL 4" }, { 4, "Not assigned" }, { 5, "Not assigned" }, { 6, "Not assigned" }, { 7, "Not assigned" } };

        // Data Item I021/220, Met Information
        //public static readonly IDictionary<bool, string> MetInformation_WS_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #1" }, { true, "Presence of Subfield #1" } };
        //public static readonly IDictionary<bool, string> MetInformation_WD_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #2" }, { true, "Presence of Subfield #2" } };
        //public static readonly IDictionary<bool, string> MetInformation_TMP_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #3" }, { true, "Presence of Subfield #3" } };
        //public static readonly IDictionary<bool, string> MetInformation_TRB_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #4" }, { true, "Presence of Subfield #4" } };

        // Data Item I021/271, Surface Capabilities and Characteristics
        public static readonly IDictionary<bool, string> SurfaceCapabilitiesandCharacteristics_POA_dict = new Dictionary<bool, string>() { { false, "Position transmitted is not ADS-B position reference point" }, { true, "Position transmitted is the ADS-B position reference point" } };
        public static readonly IDictionary<bool, string> SurfaceCapabilitiesandCharacteristics_CDTI_S_dict = new Dictionary<bool, string>() { { false, "CDTI not operational " }, { true, "CDTI operational" } };
        public static readonly IDictionary<bool, string> SurfaceCapabilitiesandCharacteristics_B2LOW_dict = new Dictionary<bool, string>() { { false, "≥ 70 Watts" }, { true, "< 70 Watts" } };
        public static readonly IDictionary<bool, string> SurfaceCapabilitiesandCharacteristics_RAS_dict = new Dictionary<bool, string>() { { false, "Aircraft not receiving ATC-services" }, { true, "Aircraft receiving ATC services" } };
        public static readonly IDictionary<bool, string> SurfaceCapabilitiesandCharacteristics_IDENT_dict = new Dictionary<bool, string>() { { false, "IDENT switch not active" }, { true, "IDENT switch active" } };
    }
}
