using System;
using System.Collections.Generic;
using P1.Config;
using P1.Enity;
using P1.Util;

namespace P1.Factory
{
    public class Factory<E, C> : IFactory  where E : IEntity, new() where C : Config.Config, new() 
    {
        private C _config;

        #region Properties
        
        protected IDbProxy DbProxy { get; set; }

        #endregion

        #region Constructors
        public Factory() : this(new SQLProxy())
        {
        }

        public Factory(IDbProxy dbProxy)
        {
            DbProxy = dbProxy;
            _config = new C();
        }

        #endregion


        #region Db Operations

        public IEnumerable<E> RetrieveAll()
        {
            //Employee Collection
            var collection = new List<E>();

            using (var conn = DbProxy.GetConnection())
            {
                var cmd = DbProxy.GetCommand();

                cmd.CommandText = _config.GetSelectAll();
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    collection.Add((E)_config.GetEntityFromReader(rdr));

                }

                conn.Close();
            }

            return collection;

        }

        #endregion


    }
}