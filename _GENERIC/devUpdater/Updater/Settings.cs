using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace devUpdater
{
    public static class Settings
    {
        public static string WebPath { get; set; }
        public static string LocalPath { get; set; }
        public static string UseLocalPath { get; set; }
        public static string AppPath { get; set; }

        public static void Init()
        {
            WebPath = "";
            LocalPath = "";
            UseLocalPath = "";
            AppPath = "";
        }

        public static void LoadSettings()
        {
            string settingsFile = Directory.GetCurrentDirectory() + "\\UpdaterSettings.txt";

            if (File.Exists(settingsFile))
            {
                char[] splitter = { '=' };
                List<string> Lines = new List<string>();
                using (FileStream stream = new FileStream(settingsFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            Lines.Add(line.Trim());
                        }
                    }
                }

                foreach (string line in Lines)
                {
                    if (line.Contains("="))
                    {
                        string[] frags = line.Split(splitter);
                        string setting = frags[0];
                        string settingValue = frags[1];

                        // in the case where there is a = sigh in the value
                        if (frags.Length > 2)
                        {
                            for (int i = 2; i < frags.Length; i++)
                            {
                                settingValue += "=" + frags[i];
                            }
                        }

                        setting = setting.Trim();
                        settingValue = settingValue.Trim();

                        SetSetting(setting, settingValue);
                    }
                }
            }
            else
            {
                SaveSettings();
            }

            if (UseLocalPath == null || UseLocalPath == "")
                UseLocalPath = "false";
        }

        public static void SaveSettings()
        {
            try
            {
                string settingsFile = Directory.GetCurrentDirectory() + "\\UpdaterSettings.txt";
                using (FileStream stream = new FileStream(settingsFile, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        string wAppPath = AppPath.ToLower();
                        if (wAppPath.Length > 3)
                        {
                            string wLast1 = wAppPath.Substring(wAppPath.Length - 1, 1);
                            if (wLast1 != "\\")
                            {
                                wAppPath += "\\";
                            }
                        }
                        sw.WriteLine("WEBPATH	  = " + WebPath);
                        sw.WriteLine("LOCALPATH	  = " + LocalPath);
                        sw.WriteLine("USELOCALPATH	  = " + UseLocalPath.ToLower());
                        sw.WriteLine("APPPATH   	  = " + wAppPath);
                    }
                }
            }
            catch (Exception ex)
            {
                string sdsdsd = "";
            }
        }

        private static void SetSetting(string setting, string settingValue)
        {
            switch (setting.ToUpper())
            {
                case "WEBPATH":
                    WebPath = settingValue;
                    break;
                case "LOCALPATH":
                    LocalPath = settingValue;
                    break;
                case "USELOCALPATH":
                    UseLocalPath = settingValue;
                    break;
                case "APPPATH":
                    AppPath = settingValue;
                    break;
                default :
                    break;
            }
        }
    }
}
