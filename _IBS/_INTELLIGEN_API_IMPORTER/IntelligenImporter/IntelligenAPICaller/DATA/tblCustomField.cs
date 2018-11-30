using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.DATA
{
    public class tblCustomField
    {
        public int? DispatchID { get; set; }

        public int? CustomFieldID { get; set; }

        public string CustomField { get; set; }

        public string Label { get; set; }

        public int? TypeID { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string Identifier { get; set; }

        public bool? Required { get; set; }

        public string DropDownListValues { get; set; }
    }
}
