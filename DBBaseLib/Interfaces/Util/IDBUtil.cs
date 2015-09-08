using System.Data.SqlClient;

namespace Base.Interface.Util
{
    public interface IDBUtil
    {
        string WcfConnectionString { get; }

        SqlConnection DbConnection { get; }

        SqlCommand DbCommand { get; }

    }
}