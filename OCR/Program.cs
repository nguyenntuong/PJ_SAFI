using System;
using System.Windows.Forms;

namespace OCR
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Form startup = new Views.Forms.MainForm())
            {
                Application.Run(startup);
            }
        }
    }
}
