using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using P1.Util;

namespace P9
{
    public partial class CachingDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {

                using (var conn = DBUtil.Instance.DbConnection)
                {
                    var adapter = new SqlDataAdapter("spGetAllEmployees", conn);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    var dataSet = new DataSet();

                    adapter.Fill(dataSet);

                    Cache["Data"] = dataSet;

                    gvEmployees.DataSource = dataSet;
                    gvEmployees.DataBind();
                    
                    lblMsg.Text = "Data loaded from the DataBase";
                }
            }
            else
            {
                gvEmployees.DataSource = Cache["Data"];
                gvEmployees.DataBind();

                lblMsg.Text = "Data loaded from the Cache";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                lblMsg.Text = "DataSet removed from the Cache";
            }
            else
            {
                lblMsg.Text = "There is nothing in the Cache to be removed";
            }
        }
    }
}