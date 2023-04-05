using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT21_Data
    {
        // Data Item I021/020, Emitter Category
        public string EmitterCategory { get; set; }

        // Data Item I021/040, Target Report Descriptor
        public bool TargetReportDescriptor_FirstExtent_flag { get; set; }
        public bool TargetReportDescriptor_SecondExtent_flag { get; set; }
        public string TargetReportDescriptor_ATP { get; set; }
        public string TargetReportDescriptor_ARC { get; set; }
        public string TargetReportDescriptor_RC { get; set; }
        public string TargetReportDescriptor_RAB { get; set; }
        public string TargetReportDescriptor_DCR { get; set; }
        public string TargetReportDescriptor_GBS { get; set; }
        public string TargetReportDescriptor_SIM { get; set; }
        public string TargetReportDescriptor_TST { get; set; }
        public string TargetReportDescriptor_SAA { get; set; }
        public string TargetReportDescriptor_CL { get; set; }
        public string TargetReportDescriptor_IPC { get; set; }
        public string TargetReportDescriptor_NOGO { get; set; }
        public string TargetReportDescriptor_CPR { get; set; }
        public string TargetReportDescriptor_LDPJ { get; set; }
        public string TargetReportDescriptor_RCF { get; set; }

        // Data Item I021/070, Mode 3/A Code in Octal Representation
        public string Mode3ACode_Reply { get; set; }

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

        // Data Item I021/110, Trajectory Intent
        public bool TrajectoryIntent_FirstExtent_flag { get; set; }
        public bool TrajectoryIntent_SecondExtent_flag { get; set; }
        public string TrajectoryIntent_TIS { get; set; }
        public string TrajectoryIntent_TID { get; set; }
        public string TrajectoryIntent_NAV { get; set; }
        public string TrajectoryIntent_NVB { get; set; }
        public string[] TrajectoryIntent_TCA { get; set; }
        public string[] TrajectoryIntent_NC { get; set; }
        public int[] TrajectoryIntent_TCP { get; set; }
        public double[] TrajectoryIntent_Altitude { get; set; }
        public double[] TrajectoryIntent_Latitude { get; set; }
        public double[] TrajectoryIntent_Longitude { get; set; }
        public string[] TrajectoryIntent_PointType { get; set; }
        public string[] TrajectoryIntent_TD { get; set; }
        public string[] TrajectoryIntent_TRA { get; set; }
        public string[] TrajectoryIntent_TOA { get; set; }
        public double[] TrajectoryIntent_TOV { get; set; }
        public double[] TrajectoryIntent_TTR { get; set; }

        // Data Item I021/130, Position in WGS-84 Co-ordinates
        public double PositionWGS84Coordinates_Latitude { get; set; }
        public double PositionWGS84Coordinates_Longitude { get; set; }

        // Data Item I021/131, High-Resolution Position in WGS-84 Co-ordinates
        public double HighResolutionPositionWGS84Coordinates_Latitude { get; set; }
        public double HighResolutionPositionWGS84Coordinates_Longitude { get; set; }

        // Data Item I021/132, Message Amplitude
        public double MessageAmplitude { get; set; }

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
        public int TrackNumber { get; set; }

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
        public string MetInformation_WS { get; set; }
        public string MetInformation_WD { get; set; }
        public string MetInformation_TMP { get; set; }
        public string MetInformation_TRB { get; set; }
        public double MetInformation_WindSpeed { get; set; }
        public double MetInformation_WindDirection { get; set; }
        public double MetInformation_Temperature { get; set; }
        public int MetInformation_Turbulence { get; set; }

        // Data Item I021/170, Target Identification
        public string TargetIdentification { get; set; }


    }
}
