﻿using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace SIMSInterface
{
    public class Attendance
    {
        private static List<string> AttendanceMarkList = new List<string>();
        public static void ClearMarks() { AttendanceMarkList.Clear(); }
        public static void AddAMMark (int StudentID, DateTime Date, string Mark, int MinutesLate, string Comment)
        {
            AddMark(StudentID, "AM", Date, Mark, MinutesLate, Comment);
        }
        public static void AddPMMark(int StudentID, DateTime Date, string Mark, int MinutesLate, string Comment)
        {
            AddMark(StudentID, "PM", Date, Mark, MinutesLate, Comment);
        }
        private static void AddMark(int StudentID, string Session, DateTime Date, string Mark, int MinutesLate, string Comment)
        {
            AttendanceMarkList.Add(formatAttendanceMark(Date, Session, StudentID, Mark, MinutesLate.ToString(), Comment));
        }
        /// <summary>
        /// This call uses partner APIs to return a set of Attendance Codes
        /// </summary>
        /// <returns></returns>
        public static XmlDocument GetAttendanceCodes()
        {
            SIMS.Processes.TPAttendanceRead ATR = new SIMS.Processes.TPAttendanceRead();
            // XML Document needed to get the codes
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            // This is the actual call to get the codes
            doc.InnerXml = ATR.GetXmlAttendanceCodes();
            return doc;
        }
        /// <summary>
        /// This call returns the marks for the specified student on the specified date
        /// 00:00 to 23:59
        /// </summary>
        /// <param name="forDate"></param>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public static XmlDocument GetAttendanceRead(DateTime forDate, int StudentId)
        {
            SIMS.Processes.TPAttendanceRead ATR = new SIMS.Processes.TPAttendanceRead();
            // XML Document needed to get the codes
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            // This is the actual call to get the codes
            doc.InnerXml = ATR.GetXmlSessionAttendancesExtended(StudentId,0,forDate.Date,forDate.Date.AddDays(1).AddMinutes(-1));
            return doc;
        }
        /// <summary>
        /// Warning we really do require that mark xml is exactly in the format given.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="session"></param>
        /// <param name="person_id"></param>
        /// <param name="mark"></param>
        /// <param name="minsLate"></param>
        /// <returns></returns>
        private static string formatAttendanceMark(DateTime date, string session, int person_id, string mark, string minsLate, string comment)
        {
            StringBuilder element = new StringBuilder();
            element.Append("<SessionAttendance>");
            element.AppendFormat("<PersonID>{0}</PersonID>", person_id);
            element.AppendFormat("<AttendanceDate>{0}-{1}-{2}</AttendanceDate>", date.Year, (date.Month < 10 ? "0" : "") + date.Month.ToString(), (date.Day < 10 ? "0" : "") + date.Day.ToString());
            element.AppendFormat("<SessionName>{0}</SessionName>", session);
            element.AppendFormat("<AttendanceMark>{0}</AttendanceMark>", mark);
            // NB This call needs to be reviewed - it simply tries to enure that the string is allowable in XML
            string cComment = comment.Replace("<", "_").Replace(">", "_").Replace("//", "_").Replace("&", "_");
            element.AppendFormat("<Comments>{0}</Comments>",cComment);
            if (!string.IsNullOrEmpty(minsLate))
            {
                element.AppendFormat("<MinsLate>{0}</MinsLate>", minsLate);
            }
            element.Append("</SessionAttendance>");
            return element.ToString();
        }
        /// <summary>
        /// Save attendance mark call
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string SaveSessionMarks()
        {
            XmlDocument d = new XmlDocument();
            StringBuilder b = new StringBuilder();

            b.Append("<SessionAttendances>");
            foreach (string s in AttendanceMarkList)
            {
                b.Append(s);
            }
            b.Append("</SessionAttendances>");
            string x = b.ToString();
            d.InnerXml = b.ToString();
            string rc = "No Errors";
            SIMS.Processes.TPAttendanceWrite ATW = new SIMS.Processes.TPAttendanceWrite();
            try
            {
                ATW.WriteSessionAttendances(d.InnerXml);
                if (ATW.ValidationMessages.Count == 0)
                {
                    // It worked
                    return rc;
                }
                else
                {
                    rc = "Errors: ";
                    foreach (SIMS.Entities.ValidationError v in ATW.ValidationMessages)
                    {
                        rc += v.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                rc = "Errors: " + ex.ToString();
            }
            return rc;

        }

    }
}
