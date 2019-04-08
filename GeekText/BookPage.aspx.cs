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
        public bool hasAlreadyCommented = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    User currentUser = new User();
                    string ISBN = Request.QueryString["ISBN"];

                    if (Session["Username"] != null && Session["UserPass"] != null)
                        currentUser = new UserManager().getUserInfo(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);

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
                Book_Author_Button.Text = bookToBeDisplayed.bookAuthor.authorName;
                Book_description.Text = bookToBeDisplayed.description;
                Book_Genre.Text = bookToBeDisplayed.genre;
                User_Rating.Text = bookToBeDisplayed.bookRating.ToString();

                // Convert Byte Array to image
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

        protected void DisplayBookReviews(string ISBN)
        {
            List<BookReview> BookReviews = BookReview.getBookReviewsByISBN(ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            reviewsRepeater.DataSource = BookReviews;
            reviewsRepeater.DataBind();
        }

        protected void DisplayCreateReview(User currentUser, string ISBN)
        {
            this.currentUserOwnsBook = UserPurchases.hasUserPurchasedBook(currentUser.userID, ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            this.hasAlreadyCommented = BookReview.existsUserComment(currentUser.userID, ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            createReview_Name.Text = currentUser.userFirstName;
            radioFullname.InnerText = currentUser.userFirstName + " " + currentUser.userLastName;
            radioNickname.InnerText = currentUser.userNickName;
            reviewWelcomeMessage.InnerText = hasAlreadyCommented ? "Edit your review of this book" : "Add a review for this book";
            textAreaTitle.InnerText = hasAlreadyCommented ? "Modify your review" : "Write a review of the book";

            if (hasAlreadyCommented)
            {
                BookReview lastReview = BookReview.getBookReviewsByUserAndISBN(currentUser.userID, ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                prefillReviewDisplay(lastReview);
            }
        }

        protected void prefillReviewDisplay(BookReview review)
        {
            createReviewTextarea.Value = review.reviewText;
            createReviewRating.Value = review.reviewRating.ToString();
            createReviewDisplay.Value = review.displayAs.ToString();
            //Page.ClientScript.RegisterStartupScript(
            //    GetType(),
            //    "updateDisplay",
            //    "window.onload = function () {" +                              
            //    "document.getElementById('ratingStar" + review.reviewRating + "').click();" +
            //    "alert('testu2');}",
            //    true
            //    );
        }

        protected void submitUserReview(object sender, EventArgs e)
        {
            BookReview userReview = new BookReview();
            userReview.reviewText = createReviewTextarea.Value;
            userReview.reviewRating = Convert.ToInt32(createReviewRating.Value);
            userReview.ISBN = Request.QueryString["ISBN"];
            userReview.displayAs = Convert.ToInt32(createReviewDisplay.Value);
            userReview.userID = Convert.ToInt32(Session["UserID"].ToString());
            bool commentExists = BookReview.existsUserComment(userReview.userID, userReview.ISBN, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);

            if (commentExists)
                userReview.updateIntoDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            else
                userReview.insertIntoDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            Response.Redirect(Request.RawUrl);
        }

        protected void Book_Author_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorDetailsPage.aspx?AuthorName=" + Book_Author_Button.Text.ToString());
        }
    }

}