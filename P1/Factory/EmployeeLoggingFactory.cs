﻿using System.Collections.Generic;
using P1.Config;
using P1.Enity;
using P1.Interface.Factory;
using P1.Interface.Util;

namespace P1.Factory
{
                
    public class EmployeeLoggingFactory : IEmployeeFactory
    {
        private readonly IEmployeeFactory employeeFact;
        private readonly ILogger logger;
        public EmployeeLoggingFactory(IEmployeeFactory empFact, ILogger logr)
        {
            employeeFact = empFact;
            logger = logr;
        }

        public IEnumerable<Employee> RetrieveAll()
        {
            return employeeFact.RetrieveAll();
        }

        public Employee RetrieveByPrimaryKey(object value)
        {
            logger.WriteLogMsg("Retrieving Employee by primary key.");
            return employeeFact.RetrieveByPrimaryKey(value);
        }

        public IEnumerable<Employee> RetrieveByParameter(IEnumerable<KeyValuePair<string, object>> parms)
        {
            logger.WriteLogMsg("Retrieving Employee by parameter collection.");
            return employeeFact.RetrieveByParameter(parms);
        }

        public bool InsertNew(Employee entity)
        {
            logger.WriteLogMsg(string.Format("Inserting Employee: [{0}]", entity.Name));
            return employeeFact.InsertNew(entity);
        }

        public IEnumerable<string> PrintAll(IEnumerable<Employee> items)
        {
            logger.WriteLogMsg("Printing All Employees");
            return employeeFact.PrintAll(items);
        }
    }
}