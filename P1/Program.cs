using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Input;
using P1.Config;
using P1.Enity;
using P1.Factory;


namespace P1
{
    class Program
    {

        static void Main(string[] args)
        {

            //var empFact = new EmployeeFactory();
            var empFact = new Factory<Employee, EmployeeConfig>();

            var employees = empFact.RetrieveAll();


            PrintiEntityEnum(employees, "Employees:");
            

            var filter = from emp in employees
                         where emp.Name == "Cesar"
                         select emp;

            PrintiEntityEnum(filter, "Employees Filtered:");


            //var countryFact = new CountryFactory();
            var countryFact = new Factory<Country, CountryConfig>();
            var countries = countryFact.RetrieveAll();
            PrintiEntityEnum(countries, "Countries:");


        }

        public static void PrintiEntityEnum(IEnumerable<IEntity> entities, string msg)
        {
            Console.WriteLine(msg+"\n");

            foreach (var entity in entities)
            {
                Console.WriteLine(entity);
            }
            Console.WriteLine("\n\n");
        }


    }
}
