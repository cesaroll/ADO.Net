using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace P1.Util
{
    public class SQLProxy : IDbProxy
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection(DBUtil.SQL_CONNECTION_STRING);
        }

        public IDbCommand GetCommand()
        {
            return new SqlCommand();
        }
    }
}