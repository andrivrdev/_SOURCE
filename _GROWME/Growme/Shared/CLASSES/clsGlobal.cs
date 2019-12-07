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
        public static string gEndpointAddress = "http://andrivrddns.dlinkddns.com:8081//GrowmeAPI/GrowmeWS.asmx";

        //dev
        //public static string gEndpointAddress = "http://localhost:49752/GrowmeWS.asmx";

        public const string gWebServiceNamespace = "http://localhost/GrowmeAPI/api";
        public static int gSoapCallTimeout = 5000;

        public const string gMessageCommandSeperator = "||||/|";

        public const int gCompressIfStringLonger = 100000;

        
    }
}
