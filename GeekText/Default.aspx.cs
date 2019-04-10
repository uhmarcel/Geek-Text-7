using GeekTextLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GeekText
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayBooksBestSellers();
            DisplayTopRated();
        }

        public void DisplayBooksBestSellers()
        {
            BookManager manager = new BookManager();
            List<Book> Books = manager.getlistofAllBooksInDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            Books.RemoveAll(o => o.bestSeller != "Best Seller");
            BestSeller_One.ImageUrl = "data:image;base64," + Convert.ToBase64String(Books[0].bookCover);
            Book_Name_One.Text = Books[0].price.ToString();
            Book_one_ISBN.Value = Books[0].ISBN.ToString();
            AuthorLabelOneBS.Text = Books[0].bookAuthor.authorName.ToString();
            BestSeller_Two.ImageUrl = "data:image;base64," + Convert.ToBase64String(Books[1].bookCover);
            Book_Name_Two.Text = Books[1].price.ToString();
            AuthorLabelTwoBS.Text = Books[1].bookAuthor.authorName.ToString();
            Book_two_ISBN.Value = Books[1].ISBN.ToString();
            BestSeller_Three.ImageUrl = "data:image;base64," + Convert.ToBase64String(Books[2].bookCover);
            AuthorLabelThreeBS.Text = Books[2].bookAuthor.authorName.ToString();
            Book_Name_Three.Text = Books[2].price.ToString();
            Book_three_ISBN.Value = Books[2].ISBN.ToString();
        }

        public void DisplayTopRated()
        {
            BookManager manager = new BookManager();
            List<Book> Books = manager.getlistofAllBooksInDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            Books.OrderByDescending(o => o.bookRating);
            Book BookOne = Books[0];
            BestSellerOneImg.ImageUrl = "data:image;base64," + Convert.ToBase64String(Books[0].bookCover);
            BestSellerOnePrice.Text = Books[0].price.ToString();
            BSOneHF.Value = BookOne.ISBN;
            AuthorNameTROne.Text = Books[0].bookAuthor.authorName.ToString();
            Book BookTwo = Books[1];
            BestSellerTwoPrice.Text = Books[1].price.ToString();
            BestSellerTwoImg.ImageUrl = "data:image;base64," + Convert.ToBase64String(Books[1].bookCover);
            AuthorNameTRTwo.Text = Books[1].bookAuthor.authorName.ToString();
            BSTwoHF.Value = BookTwo.ISBN;
            Book BookThree = Books[2];
            BestSellerThreePrice.Text = Books[2].price.ToString();
            AuthorNameTRThree.Text = Books[2].bookAuthor.authorName.ToString();
            BSThreeHF.Value = BookThree.ISBN;
            BestSellerThreeImg.ImageUrl = "data:image;base64," + Convert.ToBase64String(Books[2].bookCover);


        }

        protected void View_Book_one_Click(object sender, EventArgs e)
        {
            String ISBN = Book_one_ISBN.Value;
            Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
        }

        protected void View_Book_two_Click(object sender, EventArgs e)
        {
            String ISBN = Book_two_ISBN.Value;
            Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
        }

        protected void View_Book_three_Click(object sender, EventArgs e)
        {
            String ISBN = Book_three_ISBN.Value;
            Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
        }

        protected void ViewBSOne_Click(object sender, EventArgs e)
        {
            String ISBN = BSOneHF.Value;
            Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
        }

        protected void ViewBSTwo_Click(object sender, EventArgs e)
        {
            String ISBN = BSTwoHF.Value;
            Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
        }

        protected void ViewBSThree_Click(object sender, EventArgs e)
        {
            String ISBN = BSThreeHF.Value;
            Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["SearchString"] = TextBox1.Text;
            Response.Redirect("BookDetails");
        }
    }
}