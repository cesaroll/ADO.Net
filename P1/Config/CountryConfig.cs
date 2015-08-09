using System;
using System.Data;
using P1.Enity;

namespace P1.Config
{
    public class CountryConfig : Config
    {
        public override string GetSelectAll()
        {
            return "SELECT * FROM Country ORDER BY CountryId";
        }


        public override IEntity GetEntityFromReader(IDataReader dr)
        {
            return new Country()
            {
                ID = Convert.ToInt32(dr["CountryId"]),
                Name = dr["CountryName"].ToString()
            };
        }

    }
}