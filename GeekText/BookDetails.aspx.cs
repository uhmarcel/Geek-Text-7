using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GeekText
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
                string query = "Select * from dbo.Book;";

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds);
                                BookDetailsGridView.DataSource = ds.Tables[0];
                                BookDetailsGridView.DataBind();
                            }
                        }
                    }
                }
            }
        }

        
    }
}