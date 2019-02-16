using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Data;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                DataSet ds = new BookManager().getAllBooksInDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                BookDetailsGridView.DataSource = ds.Tables[0];
                BookDetailsGridView.DataBind();
            }
        }

        protected void BookDetailsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onclick", "location.href=('bookpage?ISBN=" + e.Row.Cells[0].Text + "')");
        }

    }
}