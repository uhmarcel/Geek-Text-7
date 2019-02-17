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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    Book bookToBeDisplayed = new Book();
                    string ISBN = Request.QueryString["ISBN"];
                    List<Book> allBooks = new BookManager().getlistofAllBooksInDB((ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString));
                    bookToBeDisplayed = allBooks.FirstOrDefault(o => o.ISBN == ISBN);
                    Book_Name.Text = bookToBeDisplayed.title;
                    Book_Author.Text = bookToBeDisplayed.bookAuthor.authorName;
                    Book_description.Text = bookToBeDisplayed.description;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}