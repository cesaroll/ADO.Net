using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P1.Config;
using P1.Util;

namespace P9
{
    public partial class NextResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var conn = DBUtil.Instance.DbConnection)
            {
                var cmd = DBUtil.Instance.DbCommand;
                cmd.CommandText = EmployeeConfig.Instance.SelectAllQuery + ";" + CountryConfig.Instance.SelectAllQuery;
                cmd.Connection = conn;

                conn.Open();

                using (var rdr = cmd.ExecuteReader())
                {
                    gridEmployees.DataSource = rdr;
                    gridEmployees.DataBind();

                    rdr.NextResult();

                    gridCountries.DataSource = rdr;
                    gridCountries.DataBind();
                }

            }
        }
    }
}