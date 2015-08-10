using System;
using P1.Config;

namespace P1.Enity
{
    public class Employee : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public decimal AnnualSalary { get; set; }


    }
}