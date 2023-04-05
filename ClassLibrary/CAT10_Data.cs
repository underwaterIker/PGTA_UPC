using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10_Data
    {
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
        public int[] ModeSMBData_MBData { get; set; }
        public int[] ModeSMBData_BDS1 { get; set; }
        public int[] ModeSMBData_BDS2 { get; set; }

        // Data Item I010/270, Target Size & Orientation
        public bool TargetSizeAndOrientation_FirstExtent_flag { get; set; }
        public bool TargetSizeAndOrientation_SecondExtent_flag { get; set; }
        public int TargetSizeAndOrientation_Length { get; set; }
        public double TargetSizeAndOrientation_Orientation { get; set; }
        public int TargetSizeAndOrientation_Width { get; set; }

        // Data Item I010/280, Presence
        public int Presence_REP { get; set; }
        public int[] Presence_DRHO { get; set; }
        public double[] Presence_DTHETA { get; set; }

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
    }
}
