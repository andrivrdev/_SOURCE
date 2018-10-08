using System;
using System.Collections.Generic;
using System.Data;
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
                try
                {
                    xResult.Add(new KeyValuePair<string, string>(xProperty.Name, xProperty.GetValue(xObj).ToString()));
                }
                catch
                {
                    xResult.Add(new KeyValuePair<string, string>(xProperty.Name, ""));
                }
                    


                
            }

            return xResult;
        }
    }
}
