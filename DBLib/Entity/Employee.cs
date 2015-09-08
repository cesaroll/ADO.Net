using System;
using System.Dynamic;
using System.Security.Permissions;
using Base.Interface.Entity;

namespace DB.Entity
{
    public class Employee : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime DoB { get; set; }

        public int EmployeeType { get; set; }
        
        public decimal AnnualSalary { get; set; }

        public decimal HourlyPay { get; set; }

        public int HoursWorked { get; set; }

        public string City { get; set; }
    }
}