using System.Data;
using System.Data.OracleClient;

namespace P1.Util
{
    public class OraProxy : IDbProxy
    {
        #region Singleton Class

        private static readonly IDbProxy _instance = new OraProxy();

        private OraProxy()
        {
        }

        public static IDbProxy Instance
        {
            get { return _instance; }
        }

        #endregion

        public IDbConnection GetConnection()
        {
            return new OracleConnection(DBUtil.WcfConnectionString);
        }

        public IDbCommand GetCommand()
        {
            return new OracleCommand();
        }
    }
}