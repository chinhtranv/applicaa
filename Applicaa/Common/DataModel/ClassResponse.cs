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

        public int? course_id { get; set; }
        public int? school_year_id { get; set; }

        //public List<Block> blocks { get; set; }
    }

    public class Block
    {
        public int id { get; set; }

        public string name { get; set; }
    }


    //"id": "418",
    //"name": "Test 12 Level Art and Design A",
    //"code": "12LDA Test",
    //"students_max": 20,
    //"block_id": null,
    //"course_id": 5485,
    //"created_at": "27 Mar 2019",
    //"school_year_id": 1,
    //"application_form_id": null,
    //"sims_block": null,
    //"sims_brand": null,
    //"sims_cluster": null,
    //"blocks": [
    //{
    //    "id": "3",
    //    "name": "C",
    //    "schedule": null,
    //    "created_at": "17 Oct 2017",
    //    "application_form_id": 1
    //}
    //]
}