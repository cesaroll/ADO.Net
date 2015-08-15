using System.Configuration;
using System.Data.SqlClient;
using P1.Interface.Util;

namespace P1.Util
{
    public class DBUtil : IDBUtil
    {
        #region SingletonClass

        private static readonly DBUtil _instance = new DBUtil();
        private DBUtil()
        {
        }

        public static DBUtil Instance
        {
            get { return _instance; }
        }

        #endregion

        #region Connections

        public string WcfConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["WCF"].ConnectionString; }
        }


        /// <summary>
        /// When using New DB Connection you are responsible for closing it.
        /// </summary>
        public SqlConnection DbConnection
        {
            get { return new SqlConnection(WcfConnectionString); }
        }
        

        public SqlCommand DbCommand
        {
            get { return new SqlCommand(); }
        }

        #endregion

    }
}