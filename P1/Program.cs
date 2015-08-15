using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Microsoft.Practices.Unity;
using P1.Config;
using P1.Enity;
using P1.Factory;
using P1.Interface.Factory;
using P1.Interface.Util;
using P1.Util;

namespace P1
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var empFact = DependencyFactory.Resolve<IEmployeeFactory>(); //Get Basic Employee Factory

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

            //Get Logging Employee Factory
            empFact = DependencyFactory.Resolve<IEmployeeFactory>("Logging");

            //Retrieve By parameter
            var parms = new List<KeyValuePair<string, object>>();

            parms.Add(new KeyValuePair<string, object>("Name", "Cesar"));
            parms.Add(new KeyValuePair<string, object>("Gender", "Male"));

            var employeesbyParm =  empFact.RetrieveByParameter(parms);

            Console.WriteLine("\nEmployees By Parm:\n");
            foreach (var item in empFact.PrintAll(employeesbyParm))
            {
                Console.WriteLine(item);
            }

            //Retrieve by Primary Key

            var empl = empFact.RetrieveByPrimaryKey(5);
            Console.WriteLine("\nEmployee By Primary Key:\n");
            Console.WriteLine("{0:###} {1,15} {2,15} {3,15:C}", empl.ID, empl.Name, empl.Gender, empl.AnnualSalary);

            
            // Countries
            var countryFact = DependencyFactory.Resolve<Factory<Country>>();
            var countries = countryFact.RetrieveAll();

            Console.WriteLine("\nCountries:\n");
            foreach (var item in countryFact.PrintAll(countries))
            {
                Console.WriteLine(item);
            }


            //Insert Employee
            Console.WriteLine("\n\nInput New Employee separated by Pipes:\n\n");
            string strEmp = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(strEmp))
            {
                string[] val = strEmp.Split('|');

                val = val.Select(x => x.Trim()).ToArray();

                var newEmp = new Employee()
                {
                    Name = val[0],
                    Gender = val[1],
                    DoB = Convert.ToDateTime(val[2]),
                    EmployeeType = int.Parse(val[3]),
                    AnnualSalary = decimal.Parse(val[4]),
                    HourlyPay = decimal.Parse(val[5]),
                    HoursWorked = int.Parse(val[6]),
                    City = val[7]
                };

                empFact.InsertNew(newEmp);
            }
           



            //Display Data Table

            var empDTFact = new EmployeeDataTableFactory();

            DataTable table = empDTFact.RetrieveAllAsDataTable();

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("{0,10} {1,15}", row["Id"], row["Name"]);
            }

        }


    }
}
