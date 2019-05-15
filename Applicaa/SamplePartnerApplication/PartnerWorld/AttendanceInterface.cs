using System;
using System.Xml;

namespace PartnerWorld
{
    public class AttendanceInterface
    {
        /// <summary>
        /// The partner system needs to control what's done
        /// </summary>
        public static DateTime AttendanceDate { get { return DateTime.Today.AddDays(14); } } // Warning avoid holidays
        public static string AttendanceCode = "/";  // Set a default 
        public static void SaveAttendanceData(XmlDocument d)
        {
            // TODO!
            return;
        }
        public static int StudentID = -1;
        /// <summary>
        /// The application needs to take out the student data that it is authorised to extract and store it appropriately.
        /// our example simply needs any valid student ID.
        /// </summary>
        /// <param name="d"></param>
        public static void SaveStudentData(XmlDocument d)
        {
            foreach (XmlNode n in d.SelectNodes("Students/Student") )
            {
                string sId = n["PersonID"].InnerXml;
                int i = 0;
                int.TryParse(sId, out i);
                StudentID = i;
                break;
            }
            // Simply pick the first student ID for our purposes
            return;
        }
        /// <summary>
        /// Save attendance codes shoudl do more but the example simply tries to pick a standard present code 
        /// if it fails, it picks the last code in the list for demo purposes
        /// </summary>
        /// <param name="d"></param>
        public static void SaveAttendanceMarks(XmlDocument d)
        {
            foreach (XmlNode n in d.SelectNodes("AttendanceCodes/AttendanceCode"))
            {
                string sCode = n["Code"].InnerXml;
                AttendanceCode = sCode;
                if (sCode == "\\")
                {
                    break;
                }
            }
            return;
            // Simply pick the first student ID for our purposes
            return;
        }
    }
}
