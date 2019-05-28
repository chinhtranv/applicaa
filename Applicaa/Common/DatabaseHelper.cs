namespace Common
{
    public class DatabaseHelper
    {
        public static string PopulateConnectionString()
        {
            var server = System.Configuration.ConfigurationManager.AppSettings["Server"];
            var database = System.Configuration.ConfigurationManager.AppSettings["Database"];
            return $"Data Source={server};Initial Catalog={database};Integrated Security=True";
        }
    }
}
