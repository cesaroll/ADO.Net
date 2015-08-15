using System.Data;

namespace P1.Factory
{
    /// <summary>
    /// This is an example of how to se Dtat Table
    /// </summary>
    public class EmployeeDataTableFactory : EmployeeFactory
    {
        public DataTable RetrieveAllAsDataTable()
        {
            DataColumn[] dataColumns = new DataColumn[]
            {
                new DataColumn("Id"), 
                new DataColumn("Name"), 
                new DataColumn("Gender"), 
                new DataColumn("DoB"), 
                new DataColumn("EmployeeType"), 
                new DataColumn("AnnualSalary"), 
                new DataColumn("HourlyPay"), 
                new DataColumn("HoursWorked"),
                new DataColumn("City") 
            };

            DataTable table = new DataTable();
            table.Columns.AddRange(dataColumns);

            using (var conn = DbUtil.DbConnection)
            {
                var cmd = DbUtil.DbCommand;
                cmd.CommandText = Config.SelectAllQuery;
                cmd.Connection = conn;

                conn.Open();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DataRow dr = table.NewRow();

                    dr["Id"] = rdr["Id"];
                    dr["Name"] = rdr["Name"];
                    dr["Gender"] = rdr["Gender"];
                    dr["DoB"] = rdr["DateOfBirth"];
                    dr["EmployeeType"] = rdr["EmployeeType"];
                    dr["AnnualSalary"] = rdr["AnnualSalary"];
                    dr["HourlyPay"] = rdr["HourlyPay"];
                    dr["HoursWorked"] = rdr["HoursWorked"];
                    dr["City"] = rdr["City"];

                    table.Rows.Add(dr);
                }

            }

            return table;

        }
    }
}