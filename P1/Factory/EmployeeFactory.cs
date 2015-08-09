using System;
using System.Collections.Generic;
using System.Linq;
using P1.Enity;
using P1.Util;

namespace P1.Factory
{
    public class EmployeeFactory : IFactory
    {
        #region Constants
        private const string SELECT_ALL = "SELECT * FROM Employee ORDER BY Id";
        #endregion

        #region Public Properties
        public IDbProxy DbProxy { get; set; }
        #endregion
        
        #region Constructors
        public EmployeeFactory() : this(new SQLProxy())
        {
        }

        public EmployeeFactory(IDbProxy dbProxy)
        {
            DbProxy = dbProxy;
        }

        #endregion


        #region Db Operations

        public IEnumerable<Employee> RetrieveAll()
        {
            //Employee Collection
            var employees = new List<Employee>();

            using (var conn = DbProxy.GetConnection())
            {
                var cmd = DbProxy.GetCommand();

                cmd.CommandText = SELECT_ALL;
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employees.Add(new Employee()
                    {
                        ID = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Gender = rdr["Gender"].ToString(),
                        AnnualSalary = Convert.ToDecimal(rdr["AnnualSalary"])
                    });

                }

                conn.Close();
            }

            return employees;

        }

        #endregion


    }
}