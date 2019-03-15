using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using GeekText.Services;
using GeekTextLibrary.ModelsShoppingCart;

namespace GeekText
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindGridView();
            }
        }

        protected void bindGridView()
        {
            List<Book> allBooks = new BookManager().getlistofAllBooksInDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
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
                price= price
            };

            ServicesShoppingCart.AddItem(myitem);
            Response.Redirect("Shopping_Cart.aspx");
        }

        // Modified search by title
        protected void Button1_Click(object sender, EventArgs e)
        {
            string bookTitle = TextBox1.Text;
            bindGridViewByTitle(bookTitle);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                bindGridView();
            }
        }

        protected void bindGridViewByTitle(string bookTitle)
        {
            var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            var searchManager = new BookSearch();
            var books = searchManager.getBooksByTitle(bookTitle, connection);

            BookDetailsGridView.DataSource = books;
            BookDetailsGridView.DataBind();
        }

        // Modified genre filter
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();
            string sortingCriteria = sortByCriteria();

            // General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList, sortingCriteria);
        }

        // Modified best seller filter
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();
            string sortingCriteria = sortByCriteria();

            //General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList, sortingCriteria);
        }

        // Modified rating filter
        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();
            string sortingCriteria = sortByCriteria();

            //General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList, sortingCriteria);
        }

        // Modified sorting criteria
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();
            string sortingCriteria = sortByCriteria();

            //General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList, sortingCriteria);
        }

        protected List<string> searchByGenre()
        {
            List<string> genresList = new List<string>();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected == true)
                {
                    genresList.Add(li.Text);
                }
            }
            return genresList;
        }

        protected bool searchByBestSeller()
        {
            bool value;
            if (CheckBox1.Checked)
            {
                value = true;
            }
            else
            {
                value = false;
            }
            return value;
        }

        protected List<string> searchByRating()
        {
            List<string> ratingsList = new List<string>();
            foreach (ListItem li in CheckBoxList2.Items)
            {
                if (li.Selected == true)
                {
                    ratingsList.Add(li.Value);
                }
            }
            return ratingsList;
        }

        protected string sortByCriteria()
        {
            string sortingCriteria = RadioButtonList1.SelectedItem.Text;
            return sortingCriteria;
        }

        protected void bindGridViewByAllFilters(List<string> genresList, bool isBestSeller, List<string> ratingsList, string sortingCriteria)
        {
            if(genresList.Count == 0 && isBestSeller == false && ratingsList.Count == 0 && sortingCriteria == null)
            {
                bindGridView();
            }
            else
            {
                var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
                var searchManager = new BookSearch();
                var books = searchManager.getBooksByAllFilters(genresList, isBestSeller, ratingsList, sortingCriteria, connection);

                BookDetailsGridView.DataSource = books;
                BookDetailsGridView.DataBind();
            }            
        }
    }
}