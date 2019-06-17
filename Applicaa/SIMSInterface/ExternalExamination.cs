﻿using System.Collections.Generic;
using System.Linq;
using SIMS.Entities.Exams;
using SIMS.Processes.Exams;

namespace SIMSInterface
{
    public class ExternalExamination
    {
        public static List<CreateEntityResult> AddResults(ATfilePupil pupil, int studentId)
        {
            ExamCachePopulate();
            var entityResults = new List<CreateEntityResult>();
            foreach (var examination in pupil.ExternalExaminationResults)
            {
                var result = AddResult(examination, studentId);
                entityResults.Add(new CreateEntityResult
                {
                    Type = EntityType.ExternalExamination,
                    EntityName = examination.BoardCode + " - " + examination.Level + " - " + examination.QAN,
                    SimsResult = result
                });
            }

            return entityResults;
        }

        public static void ExamCachePopulate()
        {
            SIMS.Processes.ExamCache.Populate();
        }

        public static SimsResult AddResult(ATfilePupilExternalExaminationResult examination, int studentId)
        {

            //int year = examination.Year;
            //string subjectCode = examination.SubjectCode; //learning skill
            //string board  = examination.BoardCode;
            //string level  = examination.Level; //ABQ Unassigned
            //string QAN = examination.QAN.ToString(); //8 numbers            
            //string resultType = examination.ResultType;
            //string result = examination.Result; //pass
            //string schoolName = examination.School;

            return AddResult(examination.Year, examination.SubjectCode, examination.BoardCode, examination.Level,
                examination.QAN.ToString(), examination.ResultType, examination.Result, examination.School, studentId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="subjectCode"></param>
        /// <param name="board"></param>
        /// <param name="level"></param>
        /// <param name="QAN"></param>
        /// <param name="resultType"></param>
        /// <param name="result"></param>
        /// <param name="schoolName"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public static SimsResult AddResult(int year,
            string subjectCode,
            string board,
            string level, 
            string QAN,
            string resultType, 
            string result,
            string schoolName, 
            int studentId)
        {
            bool success = false;
            var errors = new SIMS.Entities.ValidationErrors();
            string message = string.Empty;

            var manageExternalExamResult = new ManageExternalExamResult(studentId);
            manageExternalExamResult.ExamResult.QAN = QAN;
            manageExternalExamResult.ExamResult.School = ExternalResultLookups.Schools.FirstOrDefault(s => s.Description == schoolName);            
            manageExternalExamResult.ExamResult.Subject = ExternalResultLookups.Subjects.FirstOrDefault(x => x.Code == subjectCode);
            manageExternalExamResult.ExamResult.Board = ExternalResultLookups.Boards.FirstOrDefault(x => x.Code == board);
            manageExternalExamResult.ExamResult.Level = ExternalResultLookups.Levels.FirstOrDefault(x => x.Code == level); //invalid level                        
            manageExternalExamResult.ExamResult.ResultType = ExternalResultLookups.ResultTypes.FirstOrDefault(r => r.Description == resultType);            
            manageExternalExamResult.ExamResult.Result = result;
            manageExternalExamResult.ExamResult.ExamResultDate = ExternalResultLookups.ResultDates.FirstOrDefault(x => x.AcadYear == year);            
            manageExternalExamResult.ExamResult.ExamYear = SIMS.Entities.ExamCache.ExamYears.FirstOrDefault(y => y.Code == year.ToString());

            //saving external result
            bool isValid = manageExternalExamResult.Valid();
            if (isValid)
            {                
                success = manageExternalExamResult.AddResult();
            }
            else
            {
                //current Error : School is required ....
                message = "External Examination validation error ....";
                errors = manageExternalExamResult.ExamResult.ValidationErrors;
            }

            //handle the result
            if (success)
            {
                return new SimsResult
                {
                    Status = Status.Success
                };
            }

            return new SimsResult
            {
                Status = Status.Failed,
                Errors = errors,
                Message = message
            };
        }
    }
}
