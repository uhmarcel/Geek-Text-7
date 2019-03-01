using GeekText.Services;
using GeekTextLibrary;
using GeekTextLibrary.ModelsShoppingCart;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class AuthorDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AuthorName = Request.QueryString["AuthorName"];
                displaySelectedAuthorDetails(AuthorName);
                bindBookGridViewByAuthor(AuthorName);
            }
            
        }

        protected void displaySelectedAuthorDetails(string AuthorName)
        {
            AuthorManager manager = new AuthorManager();
            List<Author> allAuthors = manager.getAllAuthorsInDB((ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString));
            Author toDisplay = allAuthors.FirstOrDefault(o => o.authorName == AuthorName);
            AuthorName_lbl.Text = toDisplay.authorName;
            AuthorShortBio_lbl.Text = toDisplay.shortBio;

        }

        protected void bindBookGridViewByAuthor(string AuthorName)
        {
            BookManager manager = new BookManager();
            List<Book> allBooks = manager.getlistofAllBooksInDB((ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString));
            allBooks.RemoveAll(o=> o.bookAuthor.authorName != AuthorName);
            BookDetailsGridView.DataSource = allBooks;
            BookDetailsGridView.DataBind();
        }


        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                var closeLink = (Control)sender;
                GridViewRow row = (GridViewRow)closeLink.NamingContainer;
                string ISBN = row.Cells[0].Text;
                Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void AddButton_OnClick(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string ISBN = BookDetailsGridView.DataKeys[row.RowIndex].Values["ISBN"].ToString();
            string title = BookDetailsGridView.DataKeys[row.RowIndex].Values["title"].ToString();
            double price = double.Parse(BookDetailsGridView.DataKeys[row.RowIndex].Values["price"].ToString());
            BookItem myitem = new BookItem
            {
                ISBN = ISBN,
                quantity = 1,
                title = title,
                price = price
            };

            ServicesShoppingCart.AddItem(myitem);
            Response.Redirect("Shopping_Cart.aspx");
        }
    }
}
