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
            ExecuteSearchAndSorting();
        }

        // Search bar cleaned
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                ExecuteSearchAndSorting();
            }
        }

        // Modified genre filter
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndSorting();
        }

        // Modified best seller filter
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndSorting();
        }

        // Modified rating filter
        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndSorting();
        }

        // Modified sorting criteria
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Text == "Default")
            {               
                RadioButtonList2.ClearSelection();
            }
            else if (RadioButtonList2.SelectedItem == null)
            {
                RadioButtonList2.Items.FindByText("Ascending").Selected = true;
            }
            ExecuteSearchAndSorting();
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndSorting();
        }

        protected void ExecuteSearchAndSorting()
        {
            string bookTitle = CheckTitleSearchBar();
            List<string> genresList = CheckGenreFilter();
            bool isBestSeller = CheckBestSellerFilter();
            List<string> ratingsList = CheckRatingFilter();
            string sortingCriteria = CheckSortingCriteria();
            string sortingOrientation = CheckSortingOrientation();

            BindGridViewByTitleAllFiltersAndSorted(bookTitle, genresList, isBestSeller, ratingsList, sortingCriteria, sortingOrientation);
        }

        protected string CheckTitleSearchBar()
        {
            string bookTitle = TextBox1.Text;
            return bookTitle;
        }

            protected List<string> CheckGenreFilter()
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

        protected bool CheckBestSellerFilter()
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

        protected List<string> CheckRatingFilter()
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

        protected string CheckSortingCriteria()
        {
            string sortingCriteria = RadioButtonList1.SelectedItem.Text;
            return sortingCriteria;
        }

        protected string CheckSortingOrientation()
        {
            string sortingOrientation;
            if (RadioButtonList1.SelectedItem.Text == "Default")
            {
                sortingOrientation = "";
            }
            else
            {
                sortingOrientation = RadioButtonList2.SelectedItem.Text;
            }
            return sortingOrientation;
        }

        protected void BindGridViewByTitleAllFiltersAndSorted(string bookTitle, List<string> genresList, bool wantBestSeller, List<string> ratingsList, string sortingCriteria, string sortingOrientation)
        {
            if (bookTitle == "" && genresList.Count == 0 && !wantBestSeller && ratingsList.Count == 0 && sortingCriteria == "Default")
            {       
                bindGridView();                
            }           
            else
            {
                var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
                var searchManager = new BookSearch();
                var books = searchManager.GetBooksByTitleAllFiltersAndSorted(bookTitle, genresList, wantBestSeller, ratingsList, sortingCriteria, sortingOrientation, connection);

                BookDetailsGridView.DataSource = books;
                BookDetailsGridView.DataBind();
            }            
        }
    }
}