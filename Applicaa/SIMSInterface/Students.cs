﻿using System;
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

        public static CreateEntityResult UpdateStudentInfomation(int personId, ATfilePupil pupil)
        {
            var yearGroups = SIMS.Entities.GroupCache.YearGroups;
            var nationalCurriculumYear = SIMS.Entities.GroupCache.NationalCurriculumYears;


            bool success = false;
            var identityINV = new Person(personId);
            var studentBrowse = new StudentBrowseProcess();
            var editStudentInformation = new EditStudentInformation();


            editStudentInformation.Load(identityINV, System.DateTime.Now);
            editStudentInformation.Student.IssueUPN = UPNEnum.Permanent; //hackfor dumpData 
            editStudentInformation.Student.UPN = "A123456789012";
            
            editStudentInformation.Student.FSMReviewDateAttribute.IsNull = true;


            editStudentInformation.Student.Surname = pupil.Surname;
            editStudentInformation.Student.DateOfBirth = pupil.DOB;
            editStudentInformation.Student.Forename = pupil.Forename;
            editStudentInformation.Student.YearGroup = yearGroups.Item(0);
            editStudentInformation.Student.NationalCurriculumYear = nationalCurriculumYear.Item(0);

            if (editStudentInformation.Student.Valid())
            {                
                var rs = editStudentInformation.Save();
                success = rs == StudentEditResult.Success;
            }
            else
            {
                success = false;                
            }

            if (success)
            {
                return new CreateEntityResult
                {
                    Type = EntityType.UpdateStudent,
                    SimsResult = new SimsResult
                    {
                        Status = Status.Success
                    }
                };
            }
            else
            {
                return new CreateEntityResult
                {
                    Type = EntityType.UpdateStudent,
                    SimsResult = new SimsResult
                    {
                        Status = Status.Failed,
                        Errors = editStudentInformation.Student.ValidationErrors
                    }
                };
            }
        }
    }
}
