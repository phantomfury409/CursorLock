#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace CursorLock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Error Log
            ErrorLogManager eLog = new ErrorLogManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(eLog));
        }
    }
}
