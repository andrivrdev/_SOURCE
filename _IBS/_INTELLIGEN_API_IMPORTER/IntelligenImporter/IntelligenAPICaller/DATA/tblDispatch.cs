using IntelligenAPICaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblDispatch
    {
        public int? DispatchID { get; set; }

        public DateTimeOffset? CreatedDateTimeUTC { get; set; }

        public DateTimeOffset? StartDateTimeUTC { get; set; }

        public int? DurationInMinutes { get; set; }

        public DateTimeOffset? EndDateTimeUTC { get; private set; }

        public int? LoginID { get; set; }

        public int? AccountID { get; set; }

        public string OrderNr { get; set; }

        public string Description { get; set; }

        public string Client { get; set; }

        public string ClientCellNr { get; set; }

        public string ClientEmail { get; set; }

        public int? DispatchStatus { get; set; }

        public string DispatchStatusText { get; set; }

        public int? UnitID { get; set; }

        public string Alias { get; set; }

        public DateTimeOffset? DispatchETAUTC { get; set; }

        public tblDispatchUnit Unit { get; set; }

        public int? LastUnitID { get; set; }

        public string SignalRConnection { get; set; }

        public List<tblDestination> Destinations { get; set; }

        public List<tblCustomField> CustomFields { get; set; }

        public string GUID { get; set; }

        public int? DispatchTypeID { get; set; }

        public string DispatchType { get; set; }

        public int? RoutingOrder { get; set; }

        public bool? SendStatusUpdatesToPlaza { get; set; }
    }
}
