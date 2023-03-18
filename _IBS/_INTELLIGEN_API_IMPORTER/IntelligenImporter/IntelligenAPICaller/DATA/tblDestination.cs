using IntelligenAPICaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblDestination
    {
        public int? DispatchID { get; set; }

        public int? DestinationType { get; set; }

        public string Destination { get; set; }

        public int? AreaID { get; set; }

        public string AreaDataWKT { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public int? Tolerance { get; set; }

        public string Mapcode { get; set; }

        public List<tblWaypoint> Waypoints { get; set; }

        public string WaypointsDescription { get; private set; }
    }
}
