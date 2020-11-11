using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Try1.CLASSES
{
    public static class clsGlobal
    {
        public static string g_URI_access_token = "https://api.instagram.com/oauth/access_token";
        public static string g_client_id = "1101018996984145";
        public static string g_client_secret = "a3eac22d8a35bb4400e1de27b46a415b";
        //public static string grant_type { get; set; }
        public static string g_redirect_uri = "https://avrdev001.azurewebsites.net/";
        public static string g_code { get; set; }


        public static string g_URL = "https://api.instagram.com/oauth/authorize?client_id=1101018996984145&redirect_uri=https://avrdev001.azurewebsites.net/&scope=user_profile,user_media&response_type=code";

        public static readonly HttpClient g_HttpClient = new HttpClient();
    }
}
