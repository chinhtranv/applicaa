using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SIMSInterface;

namespace SIMSInternalAPIs
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
                // SIMS DLLS ARE STRONG NAMED AND THE APPLICATION WILL FAIL WITHOUT THIS CALL
                SIMSInterface.SIMSDllResolution.AddSIMSDllResolution();
                // WARNING - DO NOT PUT ANY CODE IN THIS MAIN FUNCTION THAT RELIES UPON THE DLL RESOLUTION 
                // CALL OUT TO ANY OTHER FUNCTION
                AnyOtherFunction();
            }
            catch (Exception ex)
            {
                // Handle error 
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(" - DONE -");
            Console.ReadLine();
        }
        /// <summary>
        /// SIMS Calls can be made in any funciton except main
        /// </summary>
        static void AnyOtherFunction()
        {
            // Login
            if (SIMSInterface.LoginHelper.SIMSlogin(DatabaseConfig.Server, DatabaseConfig.Database, DatabaseConfig.User, DatabaseConfig.Password))
            {
                SIMSInterface.StudentEDIT.editStudent(8404); // Grenetta Abbey
                //SIMSInterface.applicant.CreateApplicant();
              
            }
            else
            {
                Console.WriteLine(SIMSInterface.LoginHelper.ErrorMessage);
            }
            
        }
    }
}
