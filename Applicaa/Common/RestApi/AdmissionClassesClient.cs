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

        public List<ClassesItem> GetClasses(string email, string token)
        {
            var result = new List<ClassesItem>();

            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("user_token", token);
            request.AddQueryParameter("query", query);
            const string cacheKey = "AdmissionClassesCacheKey";

            var data= GetFromCache<ClassResponse>(request , cacheKey);
            if (data != null)
            {
                result = data.data.clazzs;
                return result;
            }

            return result;
        }

        //clazzId: 5, name: "5555", simsBlock: "aaa", simsBrand: "xxxx", simsCluster: "yyyyy", simsClassId:101,simsClassName:"History10A",simsClassSchemaType:"type1"
        public List<ClassesItem> UpdateClassConfig(string email, string token, int clazzId, string name,int simsClassId,string simsClassName,string simsClassSchemaType)
        {
            string model = "{clazzId: "+clazzId+", name: \""+name+"\", simsClassId:" + simsClassId + ",simsClassName:\"" + simsClassName + "\",simsClassSchemaType:\"" + simsClassSchemaType + "\"}";

            string mutuation = "mutation{updateClazz (clazzAttributes:[" + model + "]) "
                               +   "{ clazzs{ id,name,code,course,sims_block,sims_brand,sims_cluster,sims_class_id,sims_class_name,sims_class_schema_type}, errors}"
                                         +    "}";
            var result = new List<ClassesItem>();

            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("user_token", token);
            request.AddQueryParameter("query", mutuation);
            const string cacheKey = "AdmissionClassesCacheKey";

            var data = GetFromCache<ClassResponse>(request, cacheKey);
            if (data != null)
            {
                result = data.data.clazzs;
                return result;
            }

            return result;

        }
    }
}
