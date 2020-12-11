using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.CLASSES
{
    public static class clsGlobal
    {
        public static string gPasswordHash = "AnDr1devITV";
        public static string gSaltKey = "s@lT1Zk3ydevMGZ";
        public static string gVIKey = "@AzzeM81YydevLQJ";

        //live
        public static string gEndpointAddress = "http://andrivrddns.dlinkddns.com:8081//GrowmeAPI/GrowmeWS.asmx";

        //dev
        //public static string gEndpointAddress = "http://localhost:49752/GrowmeWS.asmx";

        public const string gWebServiceNamespace = "http://andrivrddns.dlinkddns.com:8081//GrowmeAPI";
        public static int gSoapCallTimeout = 30000;

        public const string gMessageCommandSeperator = "||||/|";

        public const int gCompressIfStringLonger = 100000;

        public static string gConnectionString = "Server=.;Database=Growme;User ID = sa; Password=passNEWm.3;Trusted_Connection=False;Connection Timeout = 30";

        public static string gEmailFromAddress = "andrivrgrowme@gmail.com";
        public static string gSmtpPassword = "passNEWm.3";
        public static string gSmtpAddress = "smtp.gmail.com";
        public static int gSmtpPort = 587;
        public static int gSmtpTimeout = 20000;
        public static bool gSmtpUseSSL = true;

        public static string gEmailVerificationAddress = "http://andrivrddns.dlinkddns.com:8081/Growmeapi/Growmews.asmx/DoWork?xData=";

    }
}
