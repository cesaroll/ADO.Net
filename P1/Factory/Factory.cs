using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using P1.Config;
using P1.Enity;
using P1.Util;

namespace P1.Factory
{
    public class Factory<T> : IFactory<T>  where T : IEntity, new() 
    {
        private IConfig<T> _config;

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
            _config = ConfigUtil.GetConfig<T>();
        }

        #endregion


        #region Db Operations

        public virtual IEnumerable<T> RetrieveAll()
        {
            //Employee Collection
            var collection = new List<T>();

            using (var conn = DbProxy.GetConnection())
            {
                var cmd = DbProxy.GetCommand();

                cmd.CommandText = _config.GetSelectAllQuery();
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    collection.Add(_config.GetEntityFromReader(rdr));

                }

                //conn.Close(); Using takes care of closing the connection
            }

            return collection;

        }

        #endregion


    }
}