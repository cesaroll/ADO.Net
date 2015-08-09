﻿using System.Data;
using System.Data.OracleClient;

namespace P1.Util
{
    public class OraProxy : IDbProxy
    {
        public IDbConnection GetConnection()
        {
            return new OracleConnection(DBUtil.GetWcfConnectionString());
        }

        public IDbCommand GetCommand()
        {
            return new OracleCommand();
        }
    }
}