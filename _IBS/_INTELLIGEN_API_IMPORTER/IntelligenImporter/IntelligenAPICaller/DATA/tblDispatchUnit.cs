using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblDispatchUnit
    {
        public int? UnitID { get; set; }

        public DateTimeOffset? DispatchETAUTC { get; set; }

        public string Alias { get; set; }
    }
}
