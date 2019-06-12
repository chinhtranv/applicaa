using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AdmissionApi
{
    public enum AdmissionPlusStatus
    {
        Success,
        Failed
    }

    public class AdmissionPusResponse
    {
        public AdmissionPlusStatus Status { get; set; }
        public string Messages { get; set; }

    }

    public class Authentication
    {
        public AdmissionPusResponse Login(string username, string password)
        {
            


            return new AdmissionPusResponse
            {
                Status = AdmissionPlusStatus.Success
            };
        }
    }
}
