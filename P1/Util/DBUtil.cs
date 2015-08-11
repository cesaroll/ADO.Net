using System.Configuration;
using System.Data.SqlClient;

namespace P1.Util
{
    public static class DBUtil
    {
        public static string WcfConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["WCF"].ConnectionString; }
        }


        #region Connection

        /// <summary>
        /// When using New DB Connection you are responsible for closing it.
        /// </summary>
        public static SqlConnection DbConnection
        {
            get { return new SqlConnection(DBUtil.WcfConnectionString); }
        }

        #endregion

        #region Command

        public static SqlCommand DbCommand
        {
            get { return new SqlCommand(); }
        }
        #endregion


    }
}