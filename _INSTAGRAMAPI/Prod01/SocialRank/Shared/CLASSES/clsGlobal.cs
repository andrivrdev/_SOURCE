using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CLASSES
{
    public static class clsGlobal
    {
        public static string gPasswordHash = "AnDr1devITV";
        public static string gSaltKey = "s@lT1Zk3ydevMGZ";
        public static string gVIKey = "@AzzeM81YydevLQJ";

        //live
        public const string gEndpointAddress = "http://andrivr.hopto.org:8000/SocialRankAPI/wsSocialRankAPI.asmx";
        
        public const string gWebServiceNamespace = "http://andrivr.hopto.org:8000/SocialRankAPI";
        public static int gSoapCallTimeout = 30000;

        public const string gMessageCommandSeperator = "||||/|";

        public const int gCompressIfStringLonger = 100000;

        public static string gConnectionString = "Server=.;Database=SocialRank;User ID = sa; Password=passNEWm.3;Trusted_Connection=False;Connection Timeout = 30";

        public static string gEmailFromAddress = "andrivrgrowme@gmail.com";
        public static string gSmtpPassword = "passNEWm.3";
        public static string gSmtpAddress = "smtp.gmail.com";
        public static int gSmtpPort = 587;
        public static int gSmtpTimeout = 20000;
        public static bool gSmtpUseSSL = true;

        public static string gEmailVerificationAddress = gEndpointAddress + "/DoWork?xData=";
    }
}
