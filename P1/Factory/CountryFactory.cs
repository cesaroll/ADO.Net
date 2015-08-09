using System;
using System.Collections.Generic;
using P1.Enity;
using P1.Util;

namespace P1.Factory
{
    public class CountryFactory : IFactory
    {
        #region Constants
        private const string SELECT_ALL = "SELECT * FROM Country ORDER BY CountryId";
        #endregion

         #region Public Properties
        public IDbProxy DbProxy { get; set; }
        #endregion
        
        #region Constructors
        public CountryFactory() : this(new SQLProxy())
        {
        }

        public CountryFactory(IDbProxy dbProxy)
        {
            DbProxy = dbProxy;
        }

        #endregion
        
        #region Db Operations

        public IEnumerable<Country> RetrieveAll()
        {
            //Employee Collection
            var countries = new List<Country>();

            using (var conn = DbProxy.GetConnection())
            {
                var cmd = DbProxy.GetCommand();

                cmd.CommandText = SELECT_ALL;
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    countries.Add(new Country()
                    {
                        ID = Convert.ToInt32(rdr["CountryId"]),
                        Name = rdr["CountryName"].ToString()
                    });

                }

                conn.Close();
            }

            return countries;

        }

        #endregion

        public string GetSelectAll()
        {
            return SELECT_ALL;
        }
    }
}