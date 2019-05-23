using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Entities;
using SIMS.Entities.Exams;
using SIMS.Processes;
using SIMS.Processes.Exams;

namespace SIMSInterface
{
    public class ExternalExamination
    {

        public static bool AddResults(ATfilePupil pupil, int studentId)
        {

           
            foreach (var examination in pupil.ExternalExaminationResults)
            {
                AddResult(examination, studentId);
            }

            return true;
        }

        public static SimsResult AddResult(ATfilePupilExternalExaminationResult examination, int studentId)
        {

            SIMS.Processes.ExamCache.Populate();

            bool success = false;
            var errors = new SIMS.Entities.ValidationErrors();
            string message = string.Empty;

            var manageExternalExamResult = new ManageExternalExamResult(studentId);
            //manageExternalExamResult.PopulateLookups(qan, year, studentId); no need to poplulated
            //manageExternalExamResult.ExamResult.School = new ExamSchool{ ID = Cache.CurrentSchool.SchoolId };

            //manageExternalExamResult.ExamResult.PersonId = studentId;
            //7 errors
            int year = 2018;
            string subjectCode = "0020"; //learning skill
            string board  = "OCR";
            string level  = "ABQ/B"; //ABQ Unassigned
            string QAN = "10002431";
            string aspectName = "EDEXL/GCE 6673 Entry";
            string resultType = "Result";
            string result = "P"; //pass


            manageExternalExamResult.ExamResult.QAN = QAN;
            manageExternalExamResult.ExamResult.Subject = ExternalResultLookups.Subjects.FirstOrDefault(x => x.Code == subjectCode);
            manageExternalExamResult.ExamResult.Board = ExternalResultLookups.Boards.FirstOrDefault(x => x.Code == board);
            manageExternalExamResult.ExamResult.Level = ExternalResultLookups.Levels.FirstOrDefault(x => x.Code == level); //invalid level                        
            manageExternalExamResult.ExamResult.ResultType = ExternalResultLookups.ResultTypes.FirstOrDefault(r => r.Description == resultType);                       
            manageExternalExamResult.ExamResult.AspectName = aspectName;
            manageExternalExamResult.ExamResult.Result = result;
            manageExternalExamResult.ExamResult.ExamResultDate = ExternalResultLookups.ResultDates.FirstOrDefault(x => x.AcadYear == year);
            //manageExternalExamResult.ExamResult.SetResultDatesForAcadYear();
            manageExternalExamResult.ExamResult.ExamYear = SIMS.Entities.ExamCache.ExamYears.FirstOrDefault(y => y.Code == year.ToString());

            //saving external result
            bool isValid = manageExternalExamResult.Valid();
            if (isValid)
            {
                success = true;
                //success = manageExternalExamResult.AddResult();
            }
            else
            {
                message = "Validation error ....";
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


        //public void CopyTo(ExamExternalResult examResult)
        //{
        //    if (examResult == null)
        //        throw new ArgumentNullException(nameof(examResult));
        //    this.PersonId = examResult.PersonId;
        //    this.ResultID = examResult.ResultID;
        //    this.QAN = examResult.QAN;
        //    this.Board = ExternalResultLookups.Boards.FirstOrDefault<ExamAwardingBody>((Func<ExamAwardingBody, bool>)(b => b.Code == examResult.Board));
        //    this.Level = ExternalResultLookups.Levels.FirstOrDefault<ExamLevel>((Func<ExamLevel, bool>)(l => l.Code == examResult.Level));
        //    this.Subject = ExternalResultLookups.Subjects.FirstOrDefault<ExamSubject>((Func<ExamSubject, bool>)(s => s.Code == examResult.SubjectCode));
        //    if (this.Subject == null)
        //    {
        //        ExamSubject examSubject = new ExamSubject();
        //        examSubject.ID = 0;
        //        examSubject.Code = examResult.SubjectCode;
        //        examSubject.Description = examResult.SubjectName;
        //        this.Subject = examSubject;
        //        ExternalResultLookups.Subjects.Clear();
        //        ExternalResultLookups.Subjects.Add(this.Subject);
        //    }
        //    string str;
        //    if (!examResult.IsExternalResult)
        //        str = "Result";
        //    else
        //        str = ((IEnumerable<string>)examResult.AspectName.Split(' ')).Last<string>();
        //    string resultType = str;
        //    this.ResultType = ExternalResultLookups.ResultTypes.FirstOrDefault<ExamResultType>((Func<ExamResultType, bool>)(r => r.Description == resultType));
        //    this.School = ExternalResultLookups.Schools.FirstOrDefault<ExamSchool>((Func<ExamSchool, bool>)(s => s.Description == examResult.SchoolName));
        //    this.Result = examResult.Result;
        //    this.AspectName = examResult.AspectName;
        //    this.IsExternalResult = examResult.IsExternalResult;
        //    this.copyToYearAndMonth(examResult);
        //    this.makeAttributesReadOnly();
        //    this.ClearChangeFlags();
        //}
    }
}
