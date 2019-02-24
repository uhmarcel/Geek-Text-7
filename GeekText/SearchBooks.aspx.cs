using System;
using System.Collections.Generic;
using GeekTextLibrary;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class SearchBooks : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> genresList = new List<string>();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected == true)
                {
                    genresList.Add(li.Text);
                }
            }
            bindGridViewByGenre(genresList);
        }

        protected void bindGridViewByGenre(List<string> genresList)
        {
            var connection = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            var searchManager = new BookSearch();
            var books = searchManager.getBooksByGenre(genresList, connection);

            GridView1.DataSource = books;
            GridView1.DataBind();
        }

    }
}
