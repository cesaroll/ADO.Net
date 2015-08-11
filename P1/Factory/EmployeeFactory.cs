using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using P1.Config;
using P1.Enity;
using P1.Interface.Config;
using P1.Interface.Factory;
using P1.Util;

namespace P1.Factory
{
    public class EmployeeFactory : Factory<Employee>, IEmployeeFactory
    {
        public EmployeeFactory() : this(DependencyFactory.Resolve<IConfig<Employee>>())
        {
            
        }
        public EmployeeFactory(IConfig<Employee> config) : base(config)
        {
        }

        public override Employee RetrieveByPrimaryKey(object value)
        {
            Employee entity = null;

            using (var conn = DBUtil.DbConnection)
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
    }
}