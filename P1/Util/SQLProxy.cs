using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace P1.Util
{
    public class SQLProxy : IDbProxy
    {
        #region Singleton Class

        private static readonly IDbProxy _instance = new SQLProxy();

        private SQLProxy()
        {
        }

        public static IDbProxy Instance
        {
            get { return _instance; }
        }

        #endregion
        
        public IDbConnection GetConnection()
        {
            return new SqlConnection(DBUtil.WcfConnectionString);
        }

        public IDbCommand GetCommand()
        {
            return new SqlCommand();
        }
    }
}