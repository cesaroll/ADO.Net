using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using P1.Config;
using P1.Enity;
using P1.Factory;

namespace P1
{
    class Program
    {

        static void Main(string[] args)
        {
            var unityContainer = RegisterUnityContainer();

            //var empFact = new Factory<Employee>(EmployeeConfig.Instance);

            //Using Unity
            //var empFact = unityContainer.Resolve<Factory<Employee>>();
            var empFact = unityContainer.Resolve<EmployeeFactory>();

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

            //Retrieve By parameter
            var parms = new List<KeyValuePair<string, object>>();

            parms.Add(new KeyValuePair<string, object>("Name", "Cesar"));
            parms.Add(new KeyValuePair<string, object>("Gender", "Male"));

            var employeesbyParm =  empFact.RetieveByParameter(parms);

            Console.WriteLine("\nEmployees By Parm:\n");
            foreach (var item in empFact.PrintAll(employeesbyParm))
            {
                Console.WriteLine(item);
            }

            //Retrieve by Primary Key

            Console.WriteLine("\nEmployee By Primary Key:\n");
            var empl = empFact.RetrieveByPrimaryKey(5);
            Console.WriteLine("{0:###} {1,15} {2,15} {3,15:C}", empl.ID, empl.Name, empl.Gender, empl.AnnualSalary);



            var countryFact = new Factory<Country>(CountryConfig.Instance);
            var countries = countryFact.RetrieveAll();

            Console.WriteLine("\nCountries:\n");
            foreach (var item in countryFact.PrintAll(countries))
            {
                Console.WriteLine(item);
            }


        }

        private static UnityContainer RegisterUnityContainer()
        {
            var uc = new UnityContainer();
            
            uc.RegisterInstance(EmployeeConfig.Instance);

            uc.RegisterType<Factory<Employee>>();

            uc.RegisterType<EmployeeFactory>();

            return uc;
        }


    }
}
