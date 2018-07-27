using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IntelligenAPICaller.HELPERS
{
    public class clsHelper
    {
        public List<KeyValuePair<string, string>> ToKeyValuePair(object xObj)
        {
            List<KeyValuePair<string, string>> xResult = new List<KeyValuePair<string, string>>();
            foreach (PropertyInfo xProperty in xObj.GetType().GetProperties())
            {
                xResult.Add(new KeyValuePair<string, string>(xProperty.Name, xProperty.GetValue(xObj).ToString()));
            }

            return xResult;
        }
    }
}
