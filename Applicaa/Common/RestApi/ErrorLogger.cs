using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.RestApi
{
    public interface IErrorLogger
    {
        void LogError(Exception ex, string infoMessages);
    }

    public class ErrorLogger : IErrorLogger
    {
        public void LogError(Exception ex, string infoMessages)
        {
            Log.Error(ex, infoMessages);
        }
    }
}

