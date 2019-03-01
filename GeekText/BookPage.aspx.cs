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
        public bool currentUserOwnsBook = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    User currentUser = getSessionUser();
                    string ISBN = Request.QueryString["ISBN"];

                    DisplayBookDetails(ISBN);
                    DisplayBookReviews(ISBN);
                    DisplayCreateReview(currentUser, ISBN);
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
                // Book_Cover.ImageUrl = "data:image;base64," + Convert.ToBase64String(bookToBeDisplayed.bookCover);   commented for now to run without the images

                Publishing_Company.Text = bookToBeDisplayed.publishingInfo.publishingCompany;
                Publishing_Location.Text = bookToBeDisplayed.publishingInfo.location;
                Publishing_Year.Text = bookToBeDisplayed.publishingInfo.copyrightYear.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DisplayBookReviews(string ISBN)
        {
            List<BookReview> BookReviews = new BookManager().getBookReviewsByISBN(ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            reviewsRepeater.DataSource = BookReviews;
            reviewsRepeater.DataBind();
        }

        protected void DisplayCreateReview(User currentUser, string ISBN)
        {
            this.currentUserOwnsBook = UserPurchases.hasUserPurchasedBook(currentUser.userID, ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            createReview_Name.Text = currentUser.userFirstName;
            radioFullname.InnerHtml = currentUser.userFirstName + " " + currentUser.userLastName;
            radioNickname.InnerHtml = currentUser.userNickName;
        }

        protected void submitUserReview(object sender, EventArgs e)
        {
            BookReview userReview = new BookReview();
            userReview.reviewText = createReviewTextarea.Value;
            userReview.reviewRating = Convert.ToInt32(createReviewRating.Value);
            userReview.ISBN = Request.QueryString["ISBN"];
            userReview.displayAs = Convert.ToInt32(createReviewDisplay.Value);
            userReview.userID = Convert.ToInt32(Session["UserID"].ToString());
            userReview.insertIntoDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            Response.Redirect(Request.RawUrl);
        }

        protected User getSessionUser()
        {
            UserManager userMan = new UserManager();
            User user = new User();
            if (Session["Username"] != null && Session["UserPass"] != null)
            {
                user.userID = Convert.ToInt32(Session["UserID"].ToString());
                user.userProfileName = Session["Username"].ToString();
                user.userFirstName = userMan.getUserFirstName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userLastName = userMan.getUserLastName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userNickName = userMan.getUserNickName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.eMailAddress = userMan.getEmail(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }
            return user;
        }


    }

}