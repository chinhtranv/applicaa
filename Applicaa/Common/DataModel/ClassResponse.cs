using System.Collections.Generic;

namespace Common.DataModel
{
    public class ClassResponse
    {
        public Data data { get; set; }

    }

    public class Data
    {
        public List<ClassesItem> clazzs { get; set; }
    }

    public class ClassesItem
    {
        public int id { get; set; }

        public string name { get; set; }
        public string code { get; set; }

        public string displayName
        {
            get
            {
                return name + " - "+code;
            }
        }

        public int? course_id { get; set; }
        public int? school_year_id { get; set; }
        public int application_form_id { get; set; }

        public int? sims_class_id { get; set; }
        public string sims_class_name { get; set; }
        public string sims_class_schema_type { get; set; }
    }

    public class Block
    {
        public int id { get; set; }

        public string name { get; set; }
    }

}