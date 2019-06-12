using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Common
{
    public class Log
    {
        private static Logger Logger;
        public static void InitialiseLogger()
        {
            Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.RollingFile(@"logs\\Log-{Date}.txt", LogEventLevel.Information)
                        .CreateLogger();
        }

        public static void Info(string message)
        {
            Logger.Information(message);          
        }

        public static void Info<T>(T obj)
        {
            Logger.Information(obj.ToString(), obj);
        }
        public static void Error(Exception ex,string message)
        {
            Logger.Error(ex, message);
        }
        public static void Error(string message)
        {
            Logger.Error(message);
        }

        public static void Debug(string message)
        {
            Logger.Debug(message);
        }

    }
}
