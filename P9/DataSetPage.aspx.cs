using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using P1.Util;

namespace P9
{
    public partial class DataSetPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var conn = DBUtil.Instance.DbConnection)
            {

                var adapter = new SqlDataAdapter("spGetData", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                dataSet.Tables[0].TableName = "Employees";
                dataSet.Tables[1].TableName = "Countries";

                GridView1.DataSource = dataSet.Tables["Employees"];
                GridView1.DataBind();

                GridView2.DataSource = dataSet.Tables["Countries"];
                GridView2.DataBind();

            }
        }
    }
}