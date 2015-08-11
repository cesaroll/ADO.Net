using System;
using P1.Config;
using P1.Interface.Entity;

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