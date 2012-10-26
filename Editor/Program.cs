using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace ZGE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Put the following code before InitializeComponent()
            // Set the culture to InvariantCulture (essential for XML parsing)
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Also set the UI culture
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Editor());
        }
    }
}