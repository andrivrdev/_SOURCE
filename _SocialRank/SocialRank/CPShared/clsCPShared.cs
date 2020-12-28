using System;
using System.Collections.Generic;
using System.Text;

namespace CPShared
{
    public class clsCPShared
    {

        public string DoError(Exception xEx)
        {
            try
            {
                clsLogger xclsLogger = new clsLogger();
                xclsLogger.Error(xEx.Message);
            }
            catch (Exception Ex)
            {
                clsLogger xclsLogger = new clsLogger();
                xclsLogger.Error(Ex.Message);
            }

            return xEx.Message;
        }

    }
}
