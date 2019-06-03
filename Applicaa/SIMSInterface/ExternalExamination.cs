using System.Collections.Generic;
using System.Linq;
using SIMS.Entities.Exams;
using SIMS.Processes.Exams;

namespace SIMSInterface
{
    public class ExternalExamination
    {
        public static List<CreateEntityResult> AddResults(ATfilePupil pupil, int studentId)
        {
            SIMS.Processes.ExamCache.Populate();
            var entityResults = new List<CreateEntityResult>();
            foreach (var examination in pupil.ExternalExaminationResults)
            {
                var result = AddResult(examination, studentId);
                entityResults.Add(new CreateEntityResult
                {
                    Type = EntityType.ExternalExamination,
                    SimsResult = result
                });
            }

            return entityResults;
        }

        public static SimsResult AddResult(ATfilePupilExternalExaminationResult examination, int studentId)
        {
            
            bool success = false;
            var errors = new SIMS.Entities.ValidationErrors();
            string message = string.Empty;
                   
            //fake data ...
            //int year = 2018;
            //string subjectCode = "0020"; //learning skill
            //string board  = "OCR";
            //string level  = "ABQ/B"; //ABQ Unassigned
            //string QAN = "10002431"; //8 numbers            
            //string resultType = "Result";
            //string result = "P"; //pass
            //string schoolName = "Green Abbey School";

            int year = examination.Year;
            string subjectCode = examination.SubjectCode; //learning skill
            string board  = examination.BoardCode;
            string level  = examination.Level; //ABQ Unassigned
            string QAN = examination.QAN.ToString(); //8 numbers            
            string resultType = examination.ResultType;
            string result = examination.Result; //pass
            string schoolName = examination.School;

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
