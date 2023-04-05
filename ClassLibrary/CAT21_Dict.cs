using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT21_Dict
    {
        // DICTIONARIES
        // Data Item I021/020, Emitter Category
        public static readonly IDictionary<int, string> EmitterCategory_dict = new Dictionary<int, string>() { { 0, "No ADS-B Emitter Category Information" }, { 1, "light aircraft <= 15500 lbs" }, { 2, "15500 lbs < small aircraft <75000 lbs" }, { 3, "75000 lbs < medium a/c < 300000 lbs" }, { 4, "High Vortex Large" }, { 5, "300000 lbs <= heavy aircraft" }, { 6, "highly manoeuvrable (5g acceleration capability) and high speed (>400 knots cruise)" }, { 7, "reserved" }, { 8, "reserved" }, { 9, "reserved" }, { 10, "rotocraft" }, { 11, "glider / sailplane" }, { 12, "lighter-than-air" }, { 13, "unmanned aerial vehicle" }, { 14, "space / transatmospheric vehicle" }, { 15, "ultralight / handglider / paraglider" }, { 16, "parachutist / skydiver" }, { 17, "reserved" }, { 18, "reserved" }, { 19, "reserved" }, { 20, "surface emergency vehicle" }, { 21, "surface service vehicle" }, { 22, "fixed ground or tethered obstruction" }, { 23, "cluster obstacle" }, { 24, "line obstacle" } };

        // Data Item I021/040, Target Report Descriptor
        public static readonly IDictionary<int, string> TargetReportDescriptor_ATP_dict = new Dictionary<int, string>() { { 0, "24-Bit ICAO address" }, { 1, "Duplicate address" }, { 2, "Surface vehicle address" }, { 3, "Anonymous address" }, { 4, "Reserved for future use" }, { 5, "Reserved for future use" }, { 6, "Reserved for future use" }, { 7, "Reserved for future use" } };
        public static readonly IDictionary<int, string> TargetReportDescriptor_ARC_dict = new Dictionary<int, string>() { { 0, "24 ft" }, { 1, "100 ft" }, { 2, "Unknown" }, { 3, "Invalid" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RC_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Range Check passed, CPR Validation pending" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RAB_dict = new Dictionary<bool, string>() { { false, "Report from target transponder" }, { true, "Report from field monitor (fixed transponder)" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_DCR_dict = new Dictionary<bool, string>() { { false, "No differential correction (ADS-B)" }, { true, "Differential correction (ADS-B)" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_GBS_dict = new Dictionary<bool, string>() { { false, "Ground Bit not set" }, { true, "Ground Bit set" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SIM_dict = new Dictionary<bool, string>() { { false, "Actual target report" }, { true, "Simulated target report" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_TST_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Test Target" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SAA_dict = new Dictionary<bool, string>() { { false, "Equipment capable to provide Selected Altitude" }, { true, "Equipment not capable to provide Selected Altitude" } };
        public static readonly IDictionary<int, string> TargetReportDescriptor_CL_dict = new Dictionary<int, string>() { { 0, "Report valid" }, { 1, "Report suspect" }, { 2, "No information" }, { 3, "Reserved for future use" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_IPC_dict = new Dictionary<bool, string>() { { false, "default (see note)" }, { true, "Independent Position Check failed" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_NOGO_dict = new Dictionary<bool, string>() { { false, "NOGO-bit not set" }, { true, "NOGO-bit set" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_CPR_dict = new Dictionary<bool, string>() { { false, "CPR Validation correct" }, { true, "CPR Validation failed" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_LDPJ_dict = new Dictionary<bool, string>() { { false, "LDPJ not detected" }, { true, "LDPJ detected" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RCF_dict = new Dictionary<bool, string>() { { false, "default" }, { true, "Range Check failed" } };

        // Data Item I021/074, Time of Message Reception of Position–High Precision
        public static readonly IDictionary<int, string> TimeOfMessageReceptionOfPosition_HighPrecision_FSI_dict = new Dictionary<int, string>() { { 0, "TOMRp whole seconds = (I021/073) Whole seconds" }, { 1, "TOMRp whole seconds = (I021/073) Whole seconds + 1" }, { 2, "TOMRp whole seconds = (I021/073) Whole seconds – 1" }, { 3, "Reserved" } };

        // Data Item I021/110, Trajectory Intent
        public static readonly IDictionary<bool, string> TrajectoryIntent_TIS_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #1" }, { true, "Presence of Subfield #1" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TID_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #2" }, { true, "Presence of Subfield #2" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_NAV_dict = new Dictionary<bool, string>() { { false, "Trajectory Intent Data is available for this aircraft" }, { true, "Trajectory Intent Data is not available for this aircraft" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_NVB_dict = new Dictionary<bool, string>() { { false, "Trajectory Intent Data is valid" }, { true, "Trajectory Intent Data is not valid" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TCA_dict = new Dictionary<bool, string>() { { false, "TCP number available" }, { true, "TCP number not available" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_NC_dict = new Dictionary<bool, string>() { { false, "TCP compliance" }, { true, "TCP non-compliance" } };
        public static readonly IDictionary<int, string> TrajectoryIntent_PointType_dict = new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "Fly by waypoint (LT)" }, { 2, "Fly over waypoint (LT)" }, { 3, "Hold pattern (LT)" }, { 4, "Procedure hold (LT)" }, { 5, "Procedure turn (LT)" }, { 6, "RF leg (LT)" }, { 7, "Top of climb (VT)" }, { 8, "Top of descent (VT)" }, { 9, "Start of level (VT)" }, { 10, "Cross-over altitude (VT)" }, { 11, "Transition altitude (VT)" } };
        public static readonly IDictionary<int, string> TrajectoryIntent_TD_dict = new Dictionary<int, string>() { { 0, "N/A" }, { 1, "Turn right" }, { 2, "Turn left" }, { 3, "No turn" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TRA_dict = new Dictionary<bool, string>() { { false, "TTR not available" }, { true, "TTR available" } };
        public static readonly IDictionary<bool, string> TrajectoryIntent_TOA_dict = new Dictionary<bool, string>() { { false, "TOV available" }, { true, "TOV not available" } };

        // Data Item I021/155, Barometric Vertical Rate &
        // Data Item I021/157, Geometric Vertical Rate &
        // Data Item I021/160, Airborne Ground Vector
        public static readonly IDictionary<bool, string> RE_dict = new Dictionary<bool, string>() { { false, "Value in defined range" }, { true, "Value exceeds defined range" } };

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
        public static readonly IDictionary<bool, string> MetInformation_WS_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #1" }, { true, "Presence of Subfield #1" } };
        public static readonly IDictionary<bool, string> MetInformation_WD_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #2" }, { true, "Presence of Subfield #2" } };
        public static readonly IDictionary<bool, string> MetInformation_TMP_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #3" }, { true, "Presence of Subfield #3" } };
        public static readonly IDictionary<bool, string> MetInformation_TRB_dict = new Dictionary<bool, string>() { { false, "Absence of Subfield #4" }, { true, "Presence of Subfield #4" } };

        // Data Item I021/170, Target Identification
        public static readonly IDictionary<int, string> TargetIdentification_dict = new Dictionary<int, string>() { { 1, "A" }, { 2, "B" }, { 3, "C" }, { 4, "D" }, { 5, "E" }, { 6, "F" }, { 7, "G" }, { 8, "H" }, { 9, "I" }, { 10, "J" }, { 11, "K" }, { 12, "L" }, { 13, "M" }, { 14, "N" }, { 15, "O" }, { 16, "P" }, { 17, "Q" }, { 18, "R" }, { 19, "S" }, { 20, "T" }, { 21, "U" }, { 22, "V" }, { 23, "W" }, { 24, "X" }, { 25, "Y" }, { 26, "Z" }, { 32, " " }, { 48, "0" }, { 49, "1" }, { 50, "2" }, { 51, "3" }, { 52, "4" }, { 53, "5" }, { 54, "6" }, { 55, "7" }, { 56, "8" }, { 57, "9" } };



    }
}
