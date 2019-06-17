using System.Collections.Generic;

namespace Common.DataModel
{
    public class ApplicationFormResponse
    {
        public ApplicationFormResponseData data { get; set; }

    }

    public class ApplicationFormResponseData
    {
        public List<ApplicationFormsItem> applicationForms { get; set; }
    }

    public class ApplicationFormsItem
    {
        public int id { get; set; }

        public string name { get; set; }
        public string code { get; set; }

    }

}