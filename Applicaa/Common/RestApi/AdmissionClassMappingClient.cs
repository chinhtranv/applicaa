//using System.Collections.Generic;
//using Common.AdmissionApi;
//using Common.DataModel;
//using RestSharp;
//using RestSharp.Deserializers;

//namespace Common.RestApi
//{
//    public class AdmissionClassMappingClient : BaseClient
//    {
//        private const string LoginResource = "/graphql";
//        private const string query = "{ clazzs( applicationFormId: 1 ) { id,name,code,students_max,block_id,course_id,created_at,school_year_id,application_form_id,sims_block,sims_brand,sims_cluster,sims_class_id,sims_class_name,sims_class_schema_type,blocks{id,name,schedule,created_at,application_form_id } } }";
//        public AdmissionClassMappingClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
//            : base(cache, serializer, errorLogger, RestSharpConfig.BaseUrl)
//        {

//        }

//        public List<ClassMappingItem> GetClassMappingConfig(string email, string token)
//        {
//            var result = new List<ClassMappingItem>();

//            var request = new RestRequest(LoginResource, Method.POST);
//            request.AddQueryParameter("user_email", email);
//            request.AddQueryParameter("user_token", token);
//            request.AddQueryParameter("query", query);
            
//            var data= Get<ClassMappingResponse>(request);
//            if (data != null)
//            {
//                result = data.data.clazzs;
//                return result;
//            }

//            return result;
//        }
//    }
//}
