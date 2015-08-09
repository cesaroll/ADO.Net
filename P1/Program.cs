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
            var empFact = new Factory<Employee>();

            var employees = empFact.RetrieveAll();


            PrintEntityEnum(employees, "Employees:");
            

            var filter = from emp in employees
                         where emp.Name == "Cesar"
                         select emp;

            PrintEntityEnum(filter, "Employees Filtered:");

            
            var countryFact = new Factory<Country>();
            var countries = countryFact.RetrieveAll();
            PrintEntityEnum(countries, "Countries:");


        }

        public static void PrintEntityEnum(IEnumerable<IEntity> entities, string msg)
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
