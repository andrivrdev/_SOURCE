using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace devGeneric.devClasses.devStatic
{
    public static class devGlobals
    {
        public static string gVersion;
        public static string gStandaloneVersion;

        public static Dictionary<string, string> gTamperTableList;

        public static string gDBName = "";
        public static string gProgramName = "";

        public static string gLocalSettingFile = Application.StartupPath + "\\LocalSettings.ini";

        public static bool gDebugLog = true;
        public static int gRegOverride = 1;

        public static string gUsername;
        public static string gEncUsername;

        public static List<string> gMainMenuButtonList;

        public static string gPasswordHash = "AnDr1devMAS";
        public static string gSaltKey = "s@lT1Zk3ydevMAS";
        public static string gVIKey = "@AzzeM81YydevMAS";

        public static string gDB;

        public static bool gBusySettingUp;

        public static bool gCreateDefDBRecs;

        public static bool gShowBulletinBoard = false;

        public static bool gSkipKickUser = false;

        public static bool gDoLogout = true;

        public static bool gFastIsAdmin = false;
        public static List<string> gFastAccessList = new List<string>();

        public static Color gRowCol1 = Color.FromArgb(80, 80, 80);
        public static Color gRowCol2 = Color.FromArgb(100, 100, 100);
        public static Color gSelRowCol1 = Color.FromArgb(0x32, 0x00, 0x8A, 0xFF);//  Color.FromArgb(215, 179, 26);
        public static Color gSelRowCol2 = Color.FromArgb(0x33, 0xFF, 0x00, 0x00); // Color.FromArgb(128, 120, 81);
        public static Color gCurRowCol1 = gSelRowCol1;// Color.FromArgb(215, 179, 26);
        public static Color gCurRowCol2 = gSelRowCol2; //Color.FromArgb(128, 120, 81);

        public static Font gHeaderFont = new Font("Arial Narrow", 8, FontStyle.Bold, GraphicsUnit.Point);
        public static Font gCellFont = new Font("Arial Narrow", 8, FontStyle.Regular, GraphicsUnit.Point);

        public static bool gEndApp;

    }
}
