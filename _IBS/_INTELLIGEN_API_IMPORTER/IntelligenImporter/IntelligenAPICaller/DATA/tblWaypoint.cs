using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblWaypoint
    {
        public int? DispatchID { get; set; }

        public int? WaypointID { get; set; }

        public int? AreaID { get; set; }

        public string Waypoint { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Sequence { get; set; }
    }
}
