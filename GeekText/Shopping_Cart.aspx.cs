using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using GeekText.Services;
using GeekTextLibrary.ModelsShoppingCart;

namespace GeekText
{
    public partial class Cart : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //string constr = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
                //string query = "Select * from shoppingCart;";

                //using (SqlConnection con = new SqlConnection(constr))
                //{
                //    using (SqlCommand cmd = new SqlCommand(query))
                //    {
                //        using (SqlDataAdapter sda = new SqlDataAdapter())
                //        {
                //            cmd.Connection = con;
                //            sda.SelectCommand = cmd;
                //            using (DataSet ds = new DataSet())
                //            {
                //                sda.Fill(ds);
                //                CartGridView.DataSource = ds.Tables[0];
                //                CartGridView.DataBind();
                //            }
                //        }
                //    }
                //}
                RenderGrid();
            }
        }

        private void RenderGrid()
        {
            var itemlist = ServicesShoppingCart.GetShoopingCart().BookList;
            CartGridView.DataSource = ServicesShoppingCart.GetItemDetails(itemlist);
            CartGridView.DataBind();

            var WishList = (from p in ServicesShoppingCart.GetWishList()
                            select new BookItem { ISBN = p }).ToList();
            WishGridView.DataSource = ServicesShoppingCart.GetItemDetails(WishList);
            WishGridView.DataBind();
        }

        protected void AddItem_OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string ISBN = CartGridView.DataKeys[row.RowIndex].Values["ISBN"].ToString();

            BookItem myitem = new BookItem
            {
                ISBN = ISBN,
                quantity = 1
            };

            ServicesShoppingCart.AddItem(myitem);
            RenderGrid();
        }

        protected void RemoveItem_OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string ISBN = CartGridView.DataKeys[row.RowIndex].Values["ISBN"].ToString();

            BookItem myitem = new BookItem
            {
                ISBN = ISBN,
                quantity = -1
            };

            ServicesShoppingCart.AddItem(myitem);
            RenderGrid();

        }

        protected void SaveItem_OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string ISBN = CartGridView.DataKeys[row.RowIndex].Values["ISBN"].ToString();


            ServicesShoppingCart.SaveWishProduct(ISBN);
            ServicesShoppingCart.DeleteIteminDB(ISBN);
            RenderGrid();
        }
        double sumFooterValue = 0;
        protected void CartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int quantity = int.Parse(CartGridView.DataKeys[e.Row.RowIndex].Values["quantity"].ToString());
                double price = double.Parse(CartGridView.DataKeys[e.Row.RowIndex].Values["price"].ToString());

                double totalvalue = quantity * price;
                e.Row.Cells[6].Text = totalvalue.ToString();
                sumFooterValue += totalvalue;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //Label lbl = (Label)e.Row.FindControl("lblTotal");
                //lbl.Text = sumFooterValue.ToString();

                e.Row.Cells[6].Text = sumFooterValue.ToString();
            }
        }

        protected void AddItemtoCar_OnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string ISBN = WishGridView.DataKeys[row.RowIndex].Values["ISBN"].ToString();


            ServicesShoppingCart.AddItem(new BookItem
            {
                ISBN = ISBN,
                quantity = 1
            });
            ServicesShoppingCart.RemoveWishItem(ISBN);
            RenderGrid();
        }
    }
}