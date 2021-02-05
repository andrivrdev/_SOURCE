using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class clsSE
    {
        public string SerializeData(clsAPIData xData)
        {
            try
            {
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(xData);
                return JSONresult;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }

    }
}
