using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblUnitState
    {
        public string GPSDateTime { get; set; }

        public string ReceivedDateTime { get; set; }

        public int? UnitID { get; set; }

        public string IMEI { get; set; }

        public string CellNr { get; set; }

        public string UserName { get; set; }

        public string Alias { get; set; }

        public string UnitType { get; set; }

        public long? EventID { get; set; }

        public DateTime? GPSDateTimeUTC { get; set; }

        public DateTime? ReceivedDateTimeUTC { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public string Location { get; set; }

        public int? Altitude { get; set; }

        public int? Speed { get; set; }

        public int? Odometer { get; set; }

        public int? UsageTimeAccumulator { get; set; }

        public int? NextServiceDueOn { get; set; }

        public int? EquipmentServiceDueOn { get; set; }

        public int? Heading { get; set; }

        public bool? IgnitionStatus { get; set; }

        public bool? MotionStatus { get; set; }

        public int? BatteryLevelPercentage { get; set; }

        public double? BatteryVoltageUnit { get; set; }

        public double? BatteryVoltageVehicle { get; set; }

        public string VehicleRegistrationNo { get; set; }

        public string Temperature { get; set; }

        public string Status { get; set; }

        public int? NumberOfSatellitesInView { get; set; }

        public int? MarkerID { get; set; }

        public string MarkerColor { get; set; }

        public string LabelBackColor { get; set; }

        public IList<int?> GroupIDs { get; set; }

        public bool? Panic { get; set; }

        public DateTime? DispatchETAUTC { get; set; }

        public int? EtaDispatchID { get; set; }

        public IList<tblUnitDispatch> Dispatches { get; set; }

    }
}
