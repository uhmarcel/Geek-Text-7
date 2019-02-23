using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace GeekText
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if(!this.IsPostBack)
=======
            if (!this.IsPostBack)
>>>>>>> master
            {
                bindGridView();
            }
        }

        protected void bindGridView()
        {
<<<<<<< HEAD
            List<Book> allBooks = new BookManager().getlistofAllBooksInDB((ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString));
            BookDetailsGridView.DataSource =allBooks;
            BookDetailsGridView.DataBind();
        }

        
=======
            List<Book> allBooks = new BookManager().getlistofAllBooksInDB(ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            BookDetailsGridView.DataSource = allBooks;
            BookDetailsGridView.DataBind();
        }


>>>>>>> master
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
<<<<<<< HEAD

                var closeLink = (Control)sender;
                GridViewRow row = (GridViewRow)closeLink.NamingContainer;
                string ISBN = row.Cells[0].Text;
                Response.Redirect("bookPage.aspx?ISBN=" + ISBN );
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
=======
                var closeLink = (Control)sender;
                GridViewRow row = (GridViewRow)closeLink.NamingContainer;
                string ISBN = row.Cells[0].Text;
                Response.Redirect("bookPage.aspx?ISBN=" + ISBN);
            }
            catch (Exception ex)
            {
                throw ex;
            }

>>>>>>> master
        }
    }
}