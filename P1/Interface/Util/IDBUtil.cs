using System.Data.SqlClient;

namespace P1.Interface.Util
{
    public interface IDBUtil
    {
        string WcfConnectionString { get; }

        SqlConnection DbConnection { get; }

        SqlCommand DbCommand { get; }

    }
}