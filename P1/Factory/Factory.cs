using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using P1.Config;
using P1.Enity;
using P1.Util;

namespace P1.Factory
{
    public class Factory<T> : IFactory<T> where T : IEntity, new() 
    {
        #region Properties

        private IConfig<T> Config { get; set; }
        
        protected IDbProxy DbProxy { get; set; }

        #endregion

        #region Constructors
        public Factory(IConfig<T> config ) : this(DBUtil.DeafultDbProxy, config)
        {
        }

        public Factory(IDbProxy dbProxy, IConfig<T> config)
        {
            DbProxy = dbProxy;
            Config = config;
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

                cmd.CommandText = Config.GetSelectAllQuery();
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    collection.Add(Config.GetEntityFromReader(rdr));

                }

                //conn.Close(); Using takes care of closing the connection
            }

            return collection;

        }

        #endregion


        #region Other Operations

        public virtual IEnumerable<string> PrintAll(IEnumerable<T> items)
        {
            return items.Select(item => Config.PrintableString(item));
//            foreach (var item in items)
//            {
//                yield return Config.PrintableString(item);
//            }
        }

        #endregion

    }
}