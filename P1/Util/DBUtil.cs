using System.Configuration;

namespace P1.Util
{
    public class DBUtil
    {
        public static string WcfConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["WCF"].ConnectionString; }
        }

        //Default Db proxy
        public static IDbProxy DeafultDbProxy
        {
            get { return SQLProxy.Instance; }
        }

    }
}