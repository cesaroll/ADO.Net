using System;
using System.Data;
using System.Data.SqlClient;
using Base.Factory;
using Base.Interface.Config;
using Base.Interface.Util;
using DB.Entity;
using DB.Interface.Factory;


namespace DB.Factory
{
    public class EmployeeFactory : Factory<Employee>, IEmployeeFactory
    {
        public EmployeeFactory() : this(DependencyFactory.Resolve<IConfig<Employee>>(), DependencyFactory.Resolve<IDBUtil>())
        {
            
        }
        public EmployeeFactory(IConfig<Employee> config, IDBUtil dbutil) : base(config, dbutil)
        {
        }

        public override Employee RetrieveByPrimaryKey(object value)
        {
            Employee entity = null;

            using (var conn = DbUtil.DbConnection)
            {
                var cmd = new SqlCommand("spGetEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", value);

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    entity = Config.EntityFromReader(rdr);
                    break;
                }
            }

            return entity;
        }

        public override bool InsertNew(Employee entity)
        {
            using (var conn = DbUtil.DbConnection)
            {
                var cmd = new SqlCommand("spAddEmployee", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", entity.DoB);
                cmd.Parameters.AddWithValue("@EmployeeType", entity.EmployeeType);
                cmd.Parameters.AddWithValue("@AnnualSalary", entity.AnnualSalary);
                cmd.Parameters.AddWithValue("@HourlyPay", entity.HourlyPay);
                cmd.Parameters.AddWithValue("@HoursWorked", entity.HoursWorked);
                cmd.Parameters.AddWithValue("@City", entity.City);

                SqlParameter outId = new SqlParameter("@EmployeeID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(outId);

                conn.Open();

                cmd.ExecuteNonQuery();

                int empId = Convert.ToInt32(outId.Value);

                if (empId > 0)
                {
                    entity.ID = empId;
                    return true;
                }


            }

            return false;
        }
    }
}