using System;
using System.Xml;
using SIMS.Entities;
using SIMS.Processes;

namespace SIMSInterface
{
    public class Students
    {
        public static StudentExtension StudentEx => new StudentExtension();

        /// <summary>
        /// Use a third party API call to return current student data
        /// NB: Just because the API returns data, there is no implied right to pass all of the data returned to 
        /// and external system
        /// </summary>
        /// <returns></returns>
        public static XmlDocument GetCurrentStudents()
        {
            XmlDocument d = new XmlDocument();
            // Create an instance of the pa
            SIMS.Processes.TPPersonStudent tpps = new SIMS.Processes.TPPersonStudent();
            d.InnerXml = tpps.GetXmlStudents(DateTime.Today);
            return d;

        }


        /// <summary>
        /// Seeking student by ULN, UPN, UCI 
        /// </summary>
        /// <param name="uln"></param>
        /// <param name="upn"></param>
        /// <param name="uci"></param>
        /// <returns></returns>
        public static StudentItem SeekingStudent(string uln, string upn, string uci)
        {           
            return StudentEx.GetStudentByCriteria(uln, upn, uci);
        }
    
    }
}
