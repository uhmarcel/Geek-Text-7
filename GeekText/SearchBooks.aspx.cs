using System;
using System.Collections.Generic;
using GeekTextLibrary;
using System.Configuration;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class SearchBooks : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Modified search by title
        protected void Button1_Click(object sender, EventArgs e)
        {
            string bookTitle = TextBox1.Text;
            bindGridViewByTitle(bookTitle);
        }

        protected void bindGridViewByTitle(string bookTitle)
        {
            var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            var searchManager = new BookSearch();
            var books = searchManager.getBooksByTitle(bookTitle, connection);

            GridView1.DataSource = books;
            GridView1.DataBind();
        }

        // Modified genre filter
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();

            // General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList);
        }

        // Modified best seller filter
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();

            //General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList);
        }

        // Modified rating filter
        protected void CheckBoxList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> genresList = searchByGenre();
            bool isBestSeller = searchByBestSeller();
            List<string> ratingsList = searchByRating();

            //General bindGridView
            bindGridViewByAllFilters(genresList, isBestSeller, ratingsList);
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

        protected void bindGridViewByAllFilters(List<string> genresList, bool isBestSeller, List<string> ratingsList)
        {
            var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            var searchManager = new BookSearch();
            string tmp = " ";
            var books = searchManager.getBooksByAllFilters(genresList, isBestSeller, ratingsList, tmp, connection);

            GridView1.DataSource = books;
            GridView1.DataBind();
        }
    }
}
