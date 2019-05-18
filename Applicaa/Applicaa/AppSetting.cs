using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicaa
{
    public class AppSetting
    {
        public static string Server => ConfigurationManager.AppSettings["Server"];
        public static string Database => ConfigurationManager.AppSettings["Database"];
        public static string User => ConfigurationManager.AppSettings["User"];
        public static string Password => ConfigurationManager.AppSettings["Password"];
    }
}
