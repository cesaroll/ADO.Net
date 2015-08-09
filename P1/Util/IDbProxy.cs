using System.Data;

namespace P1.Util
{
    public interface IDbProxy
    {
        IDbConnection GetConnection();

        IDbCommand GetCommand();

    }
}