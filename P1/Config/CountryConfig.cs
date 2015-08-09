using System;
using System.Data;
using P1.Enity;

namespace P1.Config
{
    public class CountryConfig : Config<Country>
    {
        private static readonly IConfig<Country> _instance = new CountryConfig();

        private CountryConfig()
        {
        }

        public static IConfig<Country> Instance
        {
            get { return _instance; }
        }

        public override string GetSelectAllQuery()
        {
            return "SELECT * FROM Country ORDER BY CountryId";
        }


        public override Country GetEntityFromReader(IDataReader dr)
        {
            return new Country()
            {
                ID = Convert.ToInt32(dr["CountryId"]),
                Name = dr["CountryName"].ToString()
            };
        }

    }
}