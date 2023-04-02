using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10_dict
    {
        // NEEDED STRINGS
        // 2 bits
        static readonly string b00 = "FalseFalse";
        static readonly string b01 = "FalseTrue";
        static readonly string b10 = "TrueFalse";
        static readonly string b11 = "TrueTrue";

        // 3 bits
        static readonly string b000 = "FalseFalseFalse";
        static readonly string b001 = "FalseFalseTrue";
        static readonly string b010 = "FalseTrueFalse";
        static readonly string b011 = "FalseTrueTrue";
        static readonly string b100 = "TrueFalseFalse";
        static readonly string b101 = "TrueFalseTrue";
        static readonly string b110 = "TrueTrueFalse";
        static readonly string b111 = "TrueTrueTrue";

        // DICTIONARIES
        // Data Item I010/000, Message Type
        public static readonly IDictionary<int, string> MessageType_dict = new Dictionary<int, string>() { { 1, "Target Report" }, { 2, "Start of Update Cycle" }, { 3, "Periodic Status Message" }, { 4, "Event-triggered Status Message" } };

        // Data Item I010/020, Target Report Descriptor
        public static readonly IDictionary<string, string> TargetReportDescriptor_TYP_dict = new Dictionary<string, string>() { { b000, "SSR multilateration" }, { b001, "Mode S multilateration" }, { b010, "ADS-B" }, { b011, "PSR" }, { b100, "Magnetic Loop System" }, { b101, "HF multilateration" }, { b110, "Not defined" }, { b111, "Other types" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_DCR_dict = new Dictionary<bool, string>() { { false, "No differential correction (ADS-B)" }, { true, "Differential correction (ADS-B)" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_CHN_dict = new Dictionary<bool, string>() { { false, "Chain 1" }, { true, "Chain 2" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_GBS_dict = new Dictionary<bool, string>() { { false, "Transponder Ground bit not set" }, { true, "Transponder Ground bit set" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_CRT_dict = new Dictionary<bool, string>() { { false, "No Corrupted reply in multilateration" }, { true, "Corrupted replies in multilateration" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SIM_dict = new Dictionary<bool, string>() { { false, "Actual target report" }, { true, "Simulated target report " } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_TST_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Test Target" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_RAB_dict = new Dictionary<bool, string>() { { false, "Report from target transponder" }, { true, "Report from field monitor (fixed transponder)" } };
        public static readonly IDictionary<string, string> TargetReportDescriptor_LOP_dict = new Dictionary<string, string>() { { b00, "Undetermined" }, { b01, "Loop start" }, { b10, "Loop finish" } };
        public static readonly IDictionary<string, string> TargetReportDescriptor_TOT_dict = new Dictionary<string, string>() { { b00, "Undetermined" }, { b01, "Aircraft" }, { b10, "Ground vehicle" }, { b11, "Helicopter" } };
        public static readonly IDictionary<bool, string> TargetReportDescriptor_SPI_dict = new Dictionary<bool, string>() { { false, "Absence of SPI " }, { true, "Special Position Identification" } };

        // Data Item I010/060, Mode-3/A Code in Octal Representation and...
        // Data Item I010/090, Flight Level in Binary Representation
        public static readonly IDictionary<bool, string> Mode3ACodeV_and_FlightLevelV_dict = new Dictionary<bool, string>() { { false, "Code validated" }, { true, "Code not validated" } };
        public static readonly IDictionary<bool, string> Mode3ACodeG_and_FlightLevelG_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Garbled code" } };
        public static readonly IDictionary<bool, string> Mode3ACodeL_dict = new Dictionary<bool, string>() { { false, "Mode-3/A code derived from the reply of the transponder" }, { true, "Mode-3/A code not extracted during the last scan" } };

        // Data Item I010/170, Track Status
        public static readonly IDictionary<bool, string> TrackStatus_CNF_dict = new Dictionary<bool, string>() { { false, "Confirmed track" }, { true, "Track in initialisation phase" } };
        public static readonly IDictionary<bool, string> TrackStatus_TRE_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Last report for a track" } };
        public static readonly IDictionary<string, string> TrackStatus_CST_dict = new Dictionary<string, string>() { { b00, "No extrapolation" }, { b01, "Predictable extrapolation due to sensor refresh period" }, { b10, "Predictable extrapolation in masked area" }, { b11, "Extrapolation due to unpredictable absence of detection" } };
        public static readonly IDictionary<bool, string> TrackStatus_MAH_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Horizontal manoeuvre" } };
        public static readonly IDictionary<bool, string> TrackStatus_TCC_dict = new Dictionary<bool, string>() { { false, "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied." }, { true, "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates." } };
        public static readonly IDictionary<bool, string> TrackStatus_STH_dict = new Dictionary<bool, string>() { { false, "Measured position" }, { true, "Smoothed position" } };
        public static readonly IDictionary<string, string> TrackStatus_TOM_dict = new Dictionary<string, string>() { { b00, "Unknown type of movement" }, { b01, "Taking-off" }, { b10, "Landing" }, { b11, "Other types of movement" } };
        public static readonly IDictionary<string, string> TrackStatus_DOU_dict = new Dictionary<string, string>() { { b000, "No doubt" }, { b001, "Doubtful correlation (undetermined reason)" }, { b010, "Doubtful correlation in clutter" }, { b011, "Loss of accuracy" }, { b100, "Loss of accuracy in clutter" }, { b101, "Unstable track" }, { b110, "Previously coasted" } };
        public static readonly IDictionary<string, string> TrackStatus_MRS_dict = new Dictionary<string, string>() { { b00, "Merge or split indication undetermined" }, { b01, "Track merged by association to plot" }, { b10, "Track merged by non-association to plot" }, { b11, "Split track" } };
        public static readonly IDictionary<bool, string> TrackStatus_GHO_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "Ghost track" } };

        // Data Item I010/245, Target Identification
        public static readonly IDictionary<string, string> TartgetIdentificationSTI_dict = new Dictionary<string, string>() { { b00, "Callsign or registration downlinked from transponder" }, { b01, "Callsign not downlinked from transponder" }, { b10, "Registration not downlinked from transponder" } };
        public static readonly IDictionary<int, string> TargetIdentificationCharacters_dict = new Dictionary<int, string>() { { 1, "A" }, { 2, "B" }, { 3, "C" }, { 4, "D" }, { 5, "E" }, { 6, "F" }, { 7, "G" }, { 8, "H" }, { 9, "I" }, { 10, "J" }, { 11, "K" }, { 12, "L" }, { 13, "M" }, { 14, "N" }, { 15, "O" }, { 16, "P" }, { 17, "Q" }, { 18, "R" }, { 19, "S" }, { 20, "T" }, { 21, "U" }, { 22, "V" }, { 23, "W" }, { 24, "X" }, { 25, "Y" }, { 26, "Z" }, { 32, " " }, { 48, "0" }, { 49, "1" }, { 50, "2" }, { 51, "3" }, { 52, "4" }, { 53, "5" }, { 54, "6" }, { 55, "7" }, { 56, "8" }, { 57, "9" } };

        // Data Item I010/300, Vehicle Fleet Identification
        public static readonly IDictionary<int, string> VehicleFleetIdentification_VFI_dict = new Dictionary<int, string>() { { 0, "Unknown" }, { 1, "ATC equipment maintenance" }, { 2, "Airport maintenance" }, { 3, "Fire" }, { 4, "Bird scarer" }, { 5, "Snow plough" }, { 6, "Runway sweeper" }, { 7, "Emergency" }, { 8, "Police" }, { 9, "Bus" }, { 10, "Tug (push/tow)" }, { 11, "Grass cutter" }, { 12, "Fuel" }, { 13, "Baggage" }, { 14, "Catering" }, { 15, "Aircraft maintenance" }, { 16, "Flyco (follow me)" } };

        // Data Item I010/310, Pre-programmed Message
        public static readonly IDictionary<bool, string> PreprogrammedMessage_TRB_dict = new Dictionary<bool, string>() { { false, "Default" }, { true, "In Trouble" } };
        public static readonly IDictionary<int, string> PreprogrammedMessage_MSG_dict = new Dictionary<int, string>() { { 1, "Towing aircraf" }, { 2, "'Follow me' operation" }, { 3, "Runway check" }, { 4, "Emergency operation (fire, medical…)" }, { 5, "Work in progress (maintenance, birds scarer, sweepers…)" } };

        // Data Item I010/550, System Status
        public static readonly IDictionary<string, string> SystemStatus_NOGO_dict = new Dictionary<string, string>() { { b00, "Operational" }, { b01, "Degraded" }, { b10, "NOGO" } };
        public static readonly IDictionary<bool, string> SystemStatus_OVL_dict = new Dictionary<bool, string>() { { false, "No overload" }, { true, "Overload" } };
        public static readonly IDictionary<bool, string> SystemStatus_TSV_dict = new Dictionary<bool, string>() { { false, "valid" }, { true, "invalid" } };
        public static readonly IDictionary<bool, string> SystemStatus_DIV_dict = new Dictionary<bool, string>() { { false, "Normal Operation" }, { true, "Diversity degraded" } };
        public static readonly IDictionary<bool, string> SystemStatus_TTF_dict = new Dictionary<bool, string>() { { false, "Test Target Operative" }, { true, "Test Target Failure" } };
    }
}
