﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.CLASSES
{
    public static class clsGlobal
    {
        public static string gConnectionString = ConfigurationManager.ConnectionStrings["MJ"].ConnectionString;
        public static Int64 gCompanyID = 0;
        public static string gImageSize = "2000";
        public static decimal gThumbnailSize = 0.3m;
        public static string gOpacity = "0.5";
        
    }
}
