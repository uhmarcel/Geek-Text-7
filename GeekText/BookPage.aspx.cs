using GeekTextLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class BookPageTemplate : System.Web.UI.Page
    {
        public DataSet pageBook; // this dont work

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataSet pageBook = new BookManager().getBookByISBN(Request.QueryString["ISBN"], ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }
        }
    }
}