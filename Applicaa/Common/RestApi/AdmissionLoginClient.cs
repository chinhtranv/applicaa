using Common.AdmissionApi;
using Common.DataModel;
using RestSharp;
using RestSharp.Deserializers;

namespace Common.RestApi
{
    public class AdmissionLoginClient : BaseClient
    {
        private const string LoginResource = "/api/users/sign_in.json";
        public AdmissionLoginClient(IDeserializer serializer, IErrorLogger errorLogger)
            : base(serializer, errorLogger, RestSharpConfig.BaseUrl)
        {

        }
        public UserResponse LogIn(string email, string password)
        {
            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("password", password);
            return Get<UserResponse>(request);
        }
    }
}
