using System;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMSInterface;

namespace WriteAttendance
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

                SIMSAssessment();
                return;


                AnyOtherFunction();
            }
            catch (Exception ex)
            {
                // Handle error 
                Console.WriteLine(ex.ToString());
            }
        }

        static void SIMSAssessment()
        {
            if (SIMSInterface.LoginHelper.SIMSlogin(DatabaseConfig.Server, DatabaseConfig.Database, DatabaseConfig.User, DatabaseConfig.Password))                
            {

                SIMSInterface.SIMSAssessment.Test_AssessmentResultComponent();
                SIMSInterface.SIMSAssessment.Test_AspectSummary();
                SIMSInterface.SIMSAssessment.Test_GradeSet();

            }
            else
            {
                Console.WriteLine(SIMSInterface.LoginHelper.ErrorMessage);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// SIMS Calls can be made in any funciton except main
        /// </summary>
        static void AnyOtherFunction()
        {
            // Login
            if (SIMSInterface.LoginHelper.SIMSlogin(@".\SIMS_2012", "EngGA", "blacka", "abcd"))
            //if (SIMSInterface.LoginHelper.SIMSlogin(Server, Database, User, Password))
            {

                // Get Students
                XmlDocument Students = SIMSInterface.Students.GetCurrentStudents();
                // Save Students to Partner System
                PartnerWorld.AttendanceInterface.SaveStudentData(Students);
                // Get Attendance codes
                XmlDocument AttendanceCodes = SIMSInterface.Attendance.GetAttendanceCodes();
                // Save Attendance Codes to partner system
                PartnerWorld.AttendanceInterface.SaveAttendanceMarks(AttendanceCodes);

                // Add some Marks
                SIMSInterface.Attendance.ClearMarks();
                SIMSInterface.Attendance.AddAMMark(PartnerWorld.AttendanceInterface.StudentID, PartnerWorld.AttendanceInterface.AttendanceDate, PartnerWorld.AttendanceInterface.AttendanceCode, 1, "Good Morning");
                SIMSInterface.Attendance.AddPMMark(PartnerWorld.AttendanceInterface.StudentID, PartnerWorld.AttendanceInterface.AttendanceDate, PartnerWorld.AttendanceInterface.AttendanceCode, 1, "Good Afternoon");
                string Errors = SIMSInterface.Attendance.SaveSessionMarks();
                Console.WriteLine(Errors);

            }
            else
            {
                Console.WriteLine(SIMSInterface.LoginHelper.ErrorMessage);
            }
            Console.ReadLine();
        }
    }
}
