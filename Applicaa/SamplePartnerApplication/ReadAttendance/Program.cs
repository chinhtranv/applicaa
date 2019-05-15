using System;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMSInterface;

namespace ReadAttendance
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
        }
        /// <summary>
        /// SIMS Calls can be made in any funciton except main
        /// </summary>
        static void AnyOtherFunction()
        {
            // Login
            //if (SIMSInterface.LoginHelper.SIMSlogin(Server, Database, User, Password))
            if (SIMSInterface.LoginHelper.SIMSlogin(@"EPVNWRKDADD\SIMS_2012", "SIMS", "dangdinh", "sA123456!"))
            {

                // Get Students
                XmlDocument Students = SIMSInterface.Students.GetCurrentStudents();
                // Save Students to Partner System
                PartnerWorld.AttendanceInterface.SaveStudentData(Students);
                // Get Attendance codes
                XmlDocument AttendanceCodes = SIMSInterface.Attendance.GetAttendanceCodes();
                // Save Attendance Codes to partner system
                PartnerWorld.AttendanceInterface.SaveAttendanceMarks(AttendanceCodes);

                // Get some Marks
                Console.WriteLine(SIMSInterface.Attendance.GetAttendanceRead(PartnerWorld.AttendanceInterface.AttendanceDate, PartnerWorld.AttendanceInterface.StudentID).InnerXml);

            }
            else
            {
                Console.WriteLine(SIMSInterface.LoginHelper.ErrorMessage);
            }
            Console.ReadLine();
        }



        //private void Test()
        //{
        //    ExternalPopulation scatter = new ExternalPopulation();

        //    if (scatter.LoadScheme("Block", "10xy Option A"))
        //    {
        //        scatter.CreateMember("004604", "10A/Mu1");
        //        scatter.CreateMember("004605", "10A/Fr1");

        //    }


        //}


        ////

        }
}
