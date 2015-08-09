using System;
using System.Data;
using P1.Enity;

namespace P1.Config
{
    public class EmployeeConfig : Config
    {
        public override string GetSelectAll()
        {
            return "SELECT * FROM Employee ORDER BY Id";
        }

        public override IEntity GetEntityFromReader(IDataReader dr)
        {
            return new Employee()
            {
                ID = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Gender = dr["Gender"].ToString(),
                AnnualSalary = Convert.ToDecimal(dr["AnnualSalary"])
            };
        }

    }
}