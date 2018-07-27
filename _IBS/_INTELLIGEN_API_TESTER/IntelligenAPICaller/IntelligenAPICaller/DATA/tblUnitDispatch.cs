using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblUnitDispatch
    {
        public int? UnitID { get; set; }

        public int? DispatchID { get; set; }

        public int? DispatchStatus { get; set; }

        public IList<tblDestination2> Destinations { get; set; }

        public string OrderNr { get; set; }

        public DateTime? StartDateTimeUTC { get; set; }

    }
}
