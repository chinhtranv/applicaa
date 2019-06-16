using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModel
{
    public class StudentResponse
    {
        public StudentData data { get; set; }
    }

    public class StudentData
    {
        public List<StudentItem> enrolledStudents { get; set; }
    }

    public class StudentItem
    {
        public int id { get; set; }
        public bool selected { get; set; } = true;

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string age { get; set; }
        public string application_reference_number { get; set; }
        public List<StudentExamination> exam_results { get; set; }
        public string class_list
        {
            get
            {

                if (this.clazzs != null || clazzs.Any())
                    return string.Join(", ", clazzs.Select(x => x.name).ToList());
                return string.Empty;
            }
        }

        public List<StudentClass> clazzs { get; set; }
        
    }

    public class StudentClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class StudentExamination
    {
        public string board_code { get; set; }
        public string level { get; set; }
        public string subject_code { get; set; }
        public string school { get; set; }
        public string year { get; set; }
        public string result { get; set; }
        public string result_type { get; set; }
        public string qan { get; set; }
    }
}
/*
 "exam_results": [
                    {
                        "board_code": "AQA",
                        "level": "2",
                        "subject_code": "FK2B",
                        "school": "Green Abbey School",
                        "year": "2019",
                        "result": "7",
                        "result_type": "Result",
                        "qan": "60142923"
                    },
 */
