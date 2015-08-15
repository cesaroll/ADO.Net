using System;
using System.Dynamic;
using System.Security.Permissions;
using P1.Config;
using P1.Interface.Entity;

namespace P1.Enity
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