using System;
using System.Data;
using P1.Enity;
using P1.Interface.Config;

namespace P1.Config
{
    public class CountryConfig : Config<Country>
    {
        #region Singleton Class
        private static readonly IConfig<Country> _instance = new CountryConfig();

        private CountryConfig()
        {
        }

        public static IConfig<Country> Instance
        {
            get { return _instance; }
        }
        #endregion

        public override string SelectAllQuery
        {
            get { return "SELECT * FROM Country ORDER BY CountryId"; }
        }

        public override string PrimaryKey
        {
            get { return "CountryId"; }
        }

        public override Country EntityFromReader(IDataReader dr)
        {
            return new Country()
            {
                ID = Convert.ToInt32(dr["CountryId"]),
                Name = dr["CountryName"].ToString()
            };
        }

        public override string PrintableString(Country country)
        {
            return string.Format("{0:###} {1,15}", country.ID, country.Name);
        }
    }
}