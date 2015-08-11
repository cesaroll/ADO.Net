using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using P1.Config;
using P1.Enity;
using P1.Util;

namespace P1.Factory
{
    public class Factory<T> : IFactory<T> where T : IEntity, new() 
    {
        #region Properties

        protected IConfig<T> Config { get; set; }

        #endregion

        #region Constructors
        public Factory(IConfig<T> config ) 
        {
            Config = config;
        }

        #endregion
        
        #region Db Operations

        public virtual IEnumerable<T> RetrieveAll()
        {
            //Employee Collection
            var collection = new List<T>();

            using (var conn = DBUtil.DbConnection)
            {
                var cmd = DBUtil.DbCommand;

                cmd.CommandText = Config.SelectAllQuery;
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    collection.Add(Config.EntityFromReader(rdr));

                }

                //conn.Close(); Using takes care of closing the connection
            }

            return collection;

        }

        public virtual T RetrieveByPrimaryKey(object value)
        {
            var query = Config.SelectAllQuery + " WHERE " + Config.PrimaryKey + " = @" + Config.PrimaryKey;
            var cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@" + Config.PrimaryKey, value);

            var entity = default(T);

            using (var conn = DBUtil.DbConnection)
            {
                cmd.Connection = conn;
                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    entity = Config.EntityFromReader(rdr);
                    break;
                }
            }

            return entity;
        }

        public virtual IEnumerable<T> RetieveByParameter(IEnumerable<KeyValuePair<string, object>> parms)
        {
            var queryBuilder = new StringBuilder(Config.SelectAllQuery).Append(" WHERE ");
            var and = " ";
            var cmd = new SqlCommand();

            foreach (var parm in parms)
            {
                cmd.Parameters.AddWithValue("@" + parm.Key, parm.Value);

                queryBuilder.Append(and).Append(parm.Key).Append(" = ").Append("@" + parm.Key);
                and = " AND ";
            }

            //Employee Collection
            var collection = new List<T>();

            using (var conn = DBUtil.DbConnection)
            {
                cmd.CommandText = queryBuilder.ToString();
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    collection.Add(Config.EntityFromReader(rdr));

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