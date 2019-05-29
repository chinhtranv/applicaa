using System;
using System.Windows.Forms;
using Common;


namespace Applicaa
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.InitialiseLogger();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Admissions());
        }
    }
}
