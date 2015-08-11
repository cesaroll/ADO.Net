﻿using System;
using System.Data;
using P1.Enity;

namespace P1.Config
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
                AnnualSalary = Convert.ToDecimal(dr["AnnualSalary"])
            };
        }

        public override string PrintableString(Employee emp)
        {
            return string.Format("{0:###} {1,15} {2,15} {3,15:C}", emp.ID, emp.Name, emp.Gender, emp.AnnualSalary);
        }
    }
}