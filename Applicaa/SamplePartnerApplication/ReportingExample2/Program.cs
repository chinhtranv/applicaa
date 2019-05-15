using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingExample2
{
    class Program
    {
        private static string[] Args;
        /// <summary>
        /// Get the server
        /// </summary>
        private static string Server { get { return Args[0]; } }
        /// <summary>
        /// Get the database
        /// </summary>
        private static string Database { get { return Args[1]; } }
        /// <summary>
        /// Get the User
        /// </summary>
        private static string User { get { return Args[2]; } }
        /// <summary>
        /// Get the password
        /// </summary>
        private static string Password { get { return Args[3]; } }
        static void Main(string[] args)
        {
            Args = args;
            try
            {
                string reportname = "ULAS Student 01";
                string reportdefinitionFileName = @"C:\Users\Lenovo\Desktop\SIMS 2018\SamplePartnerApplication\ulas.rptdef";
                if (SIMSReportingEngine.ReportingEngine.Load(reportdefinitionFileName,Server,Database,User,Password))
                {
                    System.Xml.XmlDocument d = SIMSReportingEngine.ReportingEngine.Run(reportname, Server, Database, User, Password);

                }
                string x = SIMSReportingEngine.ReportingEngine.ErrorMessage;
            }
            catch (Exception ex)
            {
                // Handle error 
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
