using System;
using System.Collections.Generic;
using GeekTextLibrary;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class SearchBooks : System.Web.UI.Page
    {
        private string bookTitle;



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.bookTitle = TextBox1.Text;
            this.bindGridView();
        }

        protected void bindGridView()
        {
            var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            var searchManager = new BookSearch();
            var books = searchManager.getBooksByTitle(this.bookTitle, connection);

            GridView1.DataSource = books;
            GridView1.DataBind();
        }
    }
}
