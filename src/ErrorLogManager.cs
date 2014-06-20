#region Using

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

#endregion

namespace CursorLock
{
    public class ErrorLogManager
    {
        public const string LogName = "Log.txt";
        public string LogLocation;

        public ErrorLogManager()
        {
            LogLocation = Path.Combine(Directory.GetCurrentDirectory(), LogName);

            // Create error log if it doesn't exist
            if (!File.Exists(LogLocation))
                CreateErrorLog();

            // Write header
            WriteHeader();

            // Write time of program start
            WriteMsg("Log Initialized");
        }

        #region Public Methods

        public void WriteCloser()
        {
            using (FileStream fs = new FileStream(LogLocation, FileMode.Append, FileAccess.Write))
            {
                fs.Flush();

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("====================");
                };

                fs.Close();
            };
        }

        public void WriteMsg(string msg)
        {
            string curTime =
                "[" + DateTime.Now.ToString("HH:MM:ss") + "]";

            using (FileStream fs = new FileStream(LogLocation, FileMode.Append, FileAccess.Write))
            {
                fs.Flush();

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(curTime + " " + msg);
                };

                fs.Close();
            };
        }

        public void WriteError(string msg)
        {
            string curTime =
                "[" + DateTime.Now.ToString("HH:MM:ss") + "]";

            using (FileStream fs = new FileStream(LogLocation, FileMode.Append, FileAccess.Write))
            {
                fs.Flush();

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(curTime + " ERROR: " + msg);
                };

                fs.Close();
            };
        }

        #endregion

        #region Private Methods

        private void WriteHeader()
        {
            string curDate = "";

            using (FileStream fs = new FileStream(LogLocation, FileMode.Append, FileAccess.Write))
            {
                fs.Flush();

                if (fs.Length > 0)
                    curDate = "\n===== " + DateTime.Now.ToShortDateString() + " =====";
                else
                    curDate = "===== " + DateTime.Now.ToShortDateString() + " =====";

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(curDate);
                };

                fs.Close();
            };
        }

        private void CreateErrorLog()
        {
            using (FileStream fs = new FileStream(LogLocation, FileMode.Create))
            {
                fs.Close();
            };
        }

#endregion
    }
}
