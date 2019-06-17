using System.Collections.Generic;
using Common.AdmissionApi;
using Common.DataModel;
using RestSharp;
using RestSharp.Deserializers;

namespace Common.RestApi
{
    public class AdmissionClassesClient : BaseClient
    {
        private const string LoginResource = "/graphql";
        private const string query = "{ clazzs( applicationFormId: 1 ) { id,name,code,students_max,block_id,course_id,created_at,school_year_id,application_form_id,sims_block,sims_brand,sims_cluster,sims_class_id,sims_class_name,sims_class_schema_type,blocks{id,name,schedule,created_at,application_form_id } } }";
        public AdmissionClassesClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
            : base(cache, serializer, errorLogger, RestSharpConfig.BaseUrl)
        {

        }

        public List<ClassesItem> GetClasses(int appFormId,string email, string token)
        {
            var result = new List<ClassesItem>();

            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("user_token", token);
            request.AddQueryParameter("query", PopulateQuery(appFormId));
            
            var data= Get<ClassResponse>(request);
            if (data != null)
            {
                result = data.data.clazzs;
                return result;
            }

            return result;
        }

        private string PopulateQuery(int appFormId)
        {
            return "{ clazzs( applicationFormId: "+ appFormId + " ) { id,name,code,students_max,block_id,course_id,created_at,school_year_id,application_form_id,sims_block,sims_brand,sims_cluster,sims_class_id,sims_class_name,sims_class_schema_type,blocks{id,name,schedule,created_at,application_form_id } } }";
            
        }


        public List<ClassesItem> UpdateClassConfig(string email, string token, int? clazzId, string name,int simsClassId,string simsClassName,string simsClassSchemaType,int applicationFormId)
        {
            string model = "{clazzId: " + clazzId+", name: \""+name+"\", simsClassId:" + simsClassId + ",simsClassName:\"" + simsClassName + "\",simsClassSchemaType:\"" + simsClassSchemaType + "\" ,  applicationFormId: "+applicationFormId+"}";

            string mutuation = "mutation{updateClazz (clazzAttributes:[" + model + "]) "
                               + "{ clazzs{ id,name,code,course,sims_block,sims_brand,sims_cluster,sims_class_id,sims_class_name,sims_class_schema_type, application_form_id}, errors}"
                                         +    "}";
            var result = new List<ClassesItem>();

            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("user_token", token);
            request.AddQueryParameter("query", mutuation);
            
            var data = Get<ClassResponse>(request);
            if (data != null)
            {
                result = data.data.clazzs;
                return result;
            }

            return result;

        }
    }
}
