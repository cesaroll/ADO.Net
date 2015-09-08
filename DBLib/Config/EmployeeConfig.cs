using System;
using System.Data;
using Base.Config;
using Base.Interface.Config;
using DB.Entity;

namespace DB.Config
{
    public class EmployeeConfig : Config<Employee>
    {
        #region Singleton Class
        private static readonly IConfig<Employee> _instance = new EmployeeConfig();

        private EmployeeConfig()
        {
        }

        public static IConfig<Employee> Instance
        {
            get { return _instance; }
        }
        #endregion

        public override string SelectAllQuery
        {
            get { return "SELECT * FROM Employee"; }
        }

        public override Employee EntityFromReader(IDataReader dr)
        {
            return new Employee()
            {
                ID = Convert.ToInt32(dr["Id"]),
                Name = dr["Name"].ToString(),
                Gender = dr["Gender"].ToString(),
                DoB = Convert.ToDateTime(dr["DateOfBirth"]),
                EmployeeType = Convert.ToInt32(dr["EmployeeType"]),
                AnnualSalary = Convert.ToDecimal(dr["AnnualSalary"]),
                HourlyPay = Convert.ToDecimal(dr["HourlyPay"]),
                HoursWorked = Convert.ToInt32(dr["HoursWorked"]),
                City = dr["City"].ToString()
            };
        }

        public override string PrintableString(Employee emp)
        {
            return string.Format("{0:###} {1,15} {2,15} {3,15} {4, 5} {5,15:C} {6,20}", 
                emp.ID, emp.Name, emp.Gender, emp.DoB.ToString("yyyy-MM-dd"), emp.EmployeeType, emp.AnnualSalary, emp.City);
        }
    }
}