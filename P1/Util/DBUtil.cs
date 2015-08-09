using System.Configuration;

namespace P1.Util
{
    public class DBUtil
    {
        public static string GetWcfConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["WCF"].ConnectionString;
        }

    }
}