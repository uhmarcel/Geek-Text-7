using GeekTextLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;

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

                    string ISBN = Request.QueryString["ISBN"];
                    DisplayBookDetails(ISBN);
                }
            }
            catch (Exception ex)
            {
                throw ex; ;
            }
        }


        //Display Book Details by ISBN
        //Getting all books and selecting by requested ISBN
        protected void DisplayBookDetails(string ISBN)
        {
            try
            {
                Book bookToBeDisplayed = new Book();
                List<Book> allBooks = new BookManager().getlistofAllBooksInDB((ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString));
                bookToBeDisplayed = allBooks.FirstOrDefault(o => o.ISBN == ISBN);
                Book_Name.Text = bookToBeDisplayed.title;
                Book_Author.Text = bookToBeDisplayed.bookAuthor.authorName;
                Book_description.Text = bookToBeDisplayed.description;
                Book_Genre.Text = bookToBeDisplayed.genre;

                //Convert Byte Array to image
                Book_Cover.ImageUrl = "data:image;base64," + Convert.ToBase64String(bookToBeDisplayed.bookCover);

                Publishing_Company.Text = bookToBeDisplayed.publishingInfo.publishingCompany;
                Publishing_Location.Text = bookToBeDisplayed.publishingInfo.location;
                Publishing_Year.Text = bookToBeDisplayed.publishingInfo.copyrightYear.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}