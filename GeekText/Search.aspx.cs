using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using GeekText.Services;
using GeekTextLibrary.ModelsShoppingCart;

namespace GeekText
{
    public partial class Search : Page
    {
        static int currentSection = 1;
        static int range = 10;
        static List<Book> allBooks;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {               
                if(Session["SearchString"] != null)
                {
                    TextBox1.Text = Session["SearchString"].ToString();

                    Button1_Click(sender, e);

                    Session["SearchString"] = null;
                }
                else
                {
                    ExecuteSearchAndSorting();
                }              
            }        
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

        // Reset filters
        protected void Button6_Click(object sender, EventArgs e)
        {
            CheckBoxList1.ClearSelection();
            CheckBox1.Checked = false;
            CheckBoxList2.ClearSelection();
            ExecuteSearchAndSorting();
        }

        // Modified sorting criteria
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedItem.Text == "Default")
            {               
                RadioButtonList2.Visible = false;
            }
            else
            {
                RadioButtonList2.Visible = true;
                if (RadioButtonList2.SelectedItem == null)
                {
                    RadioButtonList2.Items.FindByText("Ascending").Selected = true;
                }
            }          
            ExecuteSearchAndSorting();
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExecuteSearchAndSorting();
        }

        // Modified pagination
        protected void Button2_Click(object sender, EventArgs e)
        {
            currentSection -= range;

            ShowResult();

            UpdatePaginationPanel(allBooks.Count);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            currentSection += range;

            ShowResult();

            UpdatePaginationPanel(allBooks.Count);
        }

        protected void ExecuteSearchAndSorting()
        {
            string bookTitle = CheckTitleSearchBar();
            List<string> genresList = CheckGenreFilter();
            bool isBestSeller = CheckBestSellerFilter();
            List<string> ratingsList = CheckRatingFilter();
            string sortingCriteria = CheckSortingCriteria();
            string sortingOrientation = CheckSortingOrientation();

            currentSection = 1;

            GetListOfBooks(bookTitle, genresList, isBestSeller, ratingsList, sortingCriteria, sortingOrientation);

            ShowResult();

            UpdatePaginationPanel(allBooks.Count);
        }

        protected string CheckTitleSearchBar()
        {
            return TextBox1.Text;
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
            return RadioButtonList1.SelectedItem.Text;
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

        protected void GetListOfBooks(string bookTitle, List<string> genresList, bool wantBestSeller, List<string> ratingsList, string sortingCriteria, string sortingOrientation)
        {
            var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            List<Book> books;

            if (bookTitle == "" && genresList.Count == 0 && !wantBestSeller && ratingsList.Count == 0 && sortingCriteria == "Default")
            {
                var searchManager = new BookManager();
                books = searchManager.getlistofAllBooksInDB(connection);                
            }
            else
            {             
                var searchManager = new BookSearch();
                books = searchManager.GetBooksByTitleAllFiltersAndSorted(bookTitle, genresList, wantBestSeller, ratingsList, sortingCriteria, sortingOrientation, connection);
            }

            allBooks = books;
        }

        protected void ShowResult()
        {
            if (allBooks.Count == 0)
            {
                Label16.Visible = true;
            }
            else
            {
                Label16.Visible = false;               
            }

            List<Book> currentBooksToShow = new List<Book>();

            for (int i = currentSection; (i <= allBooks.Count) && (i < currentSection + range); i++)
            {
                currentBooksToShow.Add(allBooks[i - 1]);
            }

            BookDetailsGridView.DataSource = currentBooksToShow;
            BookDetailsGridView.DataBind();
        }

        protected void UpdatePaginationPanel(int totalNumberOfRows)
        {
            if (allBooks.Count == 0)
            {
                Pagination1.Visible = false;
                Pagination2.Visible = false;
            }
            else
            {
                Pagination1.Visible = true;
                Pagination2.Visible = true;

                Label5.Text = currentSection.ToString();
                Label11.Text = currentSection.ToString();

                if ((currentSection - range) >= 1)
                {
                    Button2.Enabled = true;
                    Button4.Enabled = true;
                }
                else
                {
                    Button2.Enabled = false;
                    Button4.Enabled = false;
                }

                if ((currentSection + range - 1) < totalNumberOfRows)
                {
                    Button3.Enabled = true;
                    Button5.Enabled = true;
                    Label7.Text = (currentSection + range - 1).ToString();
                    Label13.Text = (currentSection + range - 1).ToString();
                }
                else
                {
                    Button3.Enabled = false;
                    Button5.Enabled = false;
                    Label7.Text = totalNumberOfRows.ToString();
                    Label13.Text = totalNumberOfRows.ToString();
                }

                Label9.Text = totalNumberOfRows.ToString();
                Label15.Text = totalNumberOfRows.ToString();
            }                     
        }
    }
}