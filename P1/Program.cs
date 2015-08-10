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
            var empFact = new Factory<Employee>(EmployeeConfig.Instance);

            var employees = empFact.RetrieveAll();

            Console.WriteLine("Employees:\n");
            foreach (var item in empFact.PrintAll(employees))
            {
                Console.WriteLine(item);
            }
            

            var filter = from emp in employees
                         where emp.Name == "Cesar"
                         select emp;
            Console.WriteLine("\nEmployees Filtered:\n");
            foreach (var item in empFact.PrintAll(filter))
            {
                Console.WriteLine(item);
            }
            
            var countryFact = new Factory<Country>(CountryConfig.Instance);
            var countries = countryFact.RetrieveAll();

            Console.WriteLine("\nCountries:\n");
            foreach (var item in countryFact.PrintAll(countries))
            {
                Console.WriteLine(item);
            }


        }


    }
}
