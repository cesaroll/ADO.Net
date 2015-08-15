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
    public partial class DataAdapter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var conn = DBUtil.Instance.DbConnection)
            {
                var adapter = new SqlDataAdapter("Select * FROM Employee", conn);

                var dataSet = new DataSet();

                // Fill automatically opens the conection, reads the data, sets it in data set and closes the conection
                adapter.Fill(dataSet);

                GridView1.DataSource = dataSet;
                GridView1.DataBind();


            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (var conn = DBUtil.Instance.DbConnection)
            {
                var adapter = new SqlDataAdapter("spGetEmployee", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Id", TextBox1.Text);

                var dataSet = new DataSet();

                // Fill automatically opens the conection, reads the data, sets it in data set and closes the conection
                adapter.Fill(dataSet);

                GridView1.DataSource = dataSet;
                GridView1.DataBind();


            }
        }
    }
}