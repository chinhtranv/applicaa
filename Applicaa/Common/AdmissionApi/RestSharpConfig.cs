using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AdmissionApi
{
    class RestSharpConfig
    {

        public static string AdmissionApiUrl => ConfigurationManager.AppSettings["AdmissionApiUrl"];
        public static string Protocol => ConfigurationManager.AppSettings["Protocol"];
        public static string Login => "api/client/";

        public static string BaseUrl => Protocol + AdmissionApiUrl;
    }
}
