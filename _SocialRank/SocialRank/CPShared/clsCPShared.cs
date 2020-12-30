using System;
using System.Collections.Generic;
using System.Text;
using static CPShared.clsGlobal;

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

        public void DoLog(gLogLevel level, string text)
        {
            try
            {
                clsLogger xclsLogger = new clsLogger();
                xclsLogger.WriteFormattedLog(level, text);
            }
            catch (Exception Ex)
            {
                clsLogger xclsLogger = new clsLogger();
                xclsLogger.Error(Ex.Message);
            }
        }
    }
}
