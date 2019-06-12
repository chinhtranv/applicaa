using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModel
{
    public class UserResponse
    {
        public string status { get; set; }
        public string user_token { get; set; }
        public string user_email { get; set; }
        public string message { get; set; }
    }
}
