using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GeekTextLibrary;
using GeekTextLibrary.ModelsShoppingCart;

namespace GeekText.Services
{
    public static class ServicesShoppingCart
    {
        const string SessionCar = "ShoopingCarName";

        const string SaveForLater = "SaveForLater";


        public static void AddItem(BookItem products)
        {
            ShoppingCart temp = GetShoopingCart();
            bool isInside = false;

            foreach (var item in temp.Items)
            {
                if (item.ISBN == products.ISBN)
                {
                    item.Add(products.quantity);
                    isInside = true;
                }
            }
            if (!isInside)
            {
                temp.Items.Add(products);
            }
            List<BookItem> tempItems = new List<BookItem>();

            foreach (var item in temp.Items)
            {
                if (item.quantity > 0)
                {
                    tempItems.Add(item);
                }

            }

            temp.Items = tempItems;
            SaveShoopingCart(temp);
        }


        public static void SaveShoopingCart(ShoppingCart mycar)
        {
            HttpContext.Current.Session[SessionCar] = mycar;
        }
        public static ShoppingCart GetShoopingCart()
        {
            ShoppingCart result;
            try
            {
                result = (ShoppingCart)HttpContext.Current.Session[SessionCar];
            }
            catch (Exception e)
            {
                result = new ShoppingCart();
                SaveShoopingCart(result);
            }

            return result;
        }

        public static void SaveWishProduct(string ISBN)
        {
            List<string> wishList = GetWishList();
            if (!wishList.Exists(p => p == ISBN))
            {
                wishList.Add(ISBN);
            }

            ShoppingCart mycar = GetShoopingCart();
            mycar.Items.RemoveAll(p => p.ISBN == ISBN);
            SaveShoopingCart(mycar);
            HttpContext.Current.Session[SaveForLater] = wishList;
        }

        public static List<string> GetWishList()
        {
            List<string> result;
            try
            {
                if (HttpContext.Current.Session[SaveForLater] == null)
                {
                    return new List<string>();
                }
                result = (List<string>)HttpContext.Current.Session[SaveForLater];

            }
            catch (Exception)
            {
                result = new List<string>();
            }

            return result;
        }

        public static List<BookItem> GetItemDetails(List<BookItem> myItems)
        {
            List<Book> bookList = getbookList();
            //List<BookItem> result = new List<BookItem>();

            List<BookItem> result = (from p in bookList
                          from r in myItems
                          where p.ISBN == r.ISBN
                          select new BookItem
                          {
                              ISBN = p.ISBN,
                              quantity = r.quantity,
                              price = p.price,
                              description = p.description,
                              title = p.title
                          }).ToList();



            return result;
        }
        private static List<Book> getbookList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            try
            {
                List<Book> allBooks = new List<Book>();
                string query = "Select ISBN,bookTitle,bookDescription,bookAuthor,bookPrice,bookGenre,publishingCompany,publishingYear,publishingLocation  from Book;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Book curBook = new Book();
                                curBook.publishingInfo = new PublishingInfo();
                                curBook.bookAuthor = new Author();
                                curBook.ISBN = reader["ISBN"].ToString();
                                curBook.title = reader["bookTitle"].ToString();
                                curBook.description = reader["bookDescription"].ToString();
                                curBook.bookAuthor.authorName = reader["bookAuthor"].ToString();
                                curBook.price = Convert.ToDouble(reader["bookPrice"]);
                                curBook.genre = reader["bookGenre"].ToString();
                                curBook.publishingInfo.publishingCompany = reader["publishingCompany"].ToString();
                                curBook.publishingInfo.copyrightYear = Convert.ToInt32(reader["publishingYear"]);
                                curBook.publishingInfo.location = reader["publishingLocation"].ToString();

                                allBooks.Add(curBook);

                            }
                        }
                    }
                    con.Close();
                }

                return allBooks;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}