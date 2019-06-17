using System.Collections.Generic;
using Common.AdmissionApi;
using Common.DataModel;
using RestSharp;
using RestSharp.Deserializers;

namespace Common.RestApi
{
    public class AdmissionApplicationFormClient : BaseClient
    {
        private const string LoginResource = "/graphql";
        private const string query =
            "{ applicationForms { id,name,description,activate,created_at,school_year_id,image,terms_and_conditions,contactable_occasions,logo_left,logo_right,head_teacher_image,main_photo} }";


        public AdmissionApplicationFormClient(IDeserializer serializer, IErrorLogger errorLogger)
            : base(serializer, errorLogger, RestSharpConfig.BaseUrl)
        {

        }

        public List<ApplicationFormsItem> GetApplicationForms(string email, string token)
        {
            var result = new List<ApplicationFormsItem>();

            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("user_token", token);
            request.AddQueryParameter("query", query);

            var data= Get<ApplicationFormResponse>(request);
            if (data != null)
            {
                result = data.data.applicationForms;
                return result;
            }

            return result;
        }
    }
}
