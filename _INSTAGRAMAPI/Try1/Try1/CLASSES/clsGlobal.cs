﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Try1.CLASSES
{
    public static class clsGlobal
    {
        //Authenticate the User
        public static string g_BasicDisplayAPI = "https://api.instagram.com/oauth/authorize";
        public static string g_client_id = "1101018996984145";
        public static string g_redirect_uri = "https://avrdev001.azurewebsites.net/";

        //Get Short Lived Token from Code
        public static string g_URI_access_token = "https://api.instagram.com/oauth/access_token";
        public static string g_client_secret = "a3eac22d8a35bb4400e1de27b46a415b";

        //Get Long Lived Token from Short Lived Token
        public static string g_URI_long_access_token = "https://graph.instagram.com/access_token?grant_type=ig_exchange_token&&";

        //User name and Media Count
        public static string g_URI_Me_UsernameAndMediaCount = "https://graph.instagram.com/me?fields=id,username,media_count&access_token=";

        //MediaID
        public static string g_URI_Me_MediaID = "https://graph.instagram.com/me?fields=media&access_token=";




        public static string gDBSubFolderName = "Database";
        public static string gDBName = "DB.dat";



        public static string g_code { get; set; }


        public static string g_URL = "https://api.instagram.com/oauth/authorize?client_id=1101018996984145&redirect_uri=https://avrdev001.azurewebsites.net/&scope=user_profile,user_media&response_type=code";

        public static readonly HttpClient g_HttpClient = new HttpClient();
    }
}
