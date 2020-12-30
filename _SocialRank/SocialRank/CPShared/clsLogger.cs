using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static CPShared.clsGlobal;

namespace CPShared
{
    public class clsLogger
    {
        private const string FILE_EXT = ".log";
        private readonly string datetimeFormat;
        private readonly string logFilename;

        /// <summary>
        /// Initiate an instance of SimpleLogger class constructor.
        /// If log file does not exist, it will be created automatically.
        /// </summary>
        public clsLogger()
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            logFilename = Path.Combine(clsGlobal.gLogRootFolder, clsGlobal.gLogSubfolder, clsGlobal.gLogFileName);

            FileInfo MyFile = new FileInfo(logFilename);

            if (!(Directory.Exists(MyFile.DirectoryName)))
            {
                Directory.CreateDirectory(MyFile.DirectoryName);
            }

            if (!File.Exists(logFilename))
            {
               // SQLiteConnection.CreateFile(zDBPathAndFileName);
            }
            // Log file header line
            string logHeader = logFilename + " is created.";
            if (!System.IO.File.Exists(logFilename))
            {
                WriteLine(System.DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
            }

            WriteLine(System.DateTime.Now.ToString(datetimeFormat) + " App started.", true);

        }

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteFormattedLog(gLogLevel.DEBUG, text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteFormattedLog(gLogLevel.ERROR, text);
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(gLogLevel.FATAL, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(gLogLevel.INFO, text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteFormattedLog(gLogLevel.TRACE, text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteFormattedLog(gLogLevel.WARNING, text);
        }

        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilename, append, System.Text.Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch (Exception Ex)
            {
                var x = 1;
                //throw;
            }
        }

        public void WriteFormattedLog(gLogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case gLogLevel.TRACE:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [TRACE]   ";
                    break;
                case gLogLevel.INFO:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
                    break;
                case gLogLevel.DEBUG:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [DEBUG]   ";
                    break;
                case gLogLevel.WARNING:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [WARNING] ";
                    break;
                case gLogLevel.ERROR:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
                    break;
                case gLogLevel.FATAL:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [FATAL]   ";
                    break;
                default:
                    pretext = "";
                    break;
            }

            WriteLine(pretext + text);
        }

    }

}