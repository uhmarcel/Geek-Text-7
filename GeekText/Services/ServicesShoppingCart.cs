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
        public static string GetUserId()
        {
            try
            {
                return HttpContext.Current.Session["UserID"].ToString();
            }
            catch
            {
                return "";
            }
        }

        const string SessionCar = "ShoopingCarName";

        const string SaveForLater = "SaveForLater";

        static string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
        private static void SaveCarToDb(ShoppingCart shoppingCart)
        {
            string userID = GetUserId();
            if (userID != "")
            {
                bool exist;

                foreach (var book in shoppingCart.BookList)
                {
                    exist = IsinDB(userID, book.ISBN);


                    if (exist)
                    {
                        UpdateCarinDB(userID, book);
                    }
                    else
                    {
                        SaveCarinDB(userID, book);
                    }

                }
            }
        }
        private static void SaveWishListToDb(List<string> wishList)
        {
            string userID = GetUserId();
            if (userID != "")
            {
                bool exist;

                foreach (var isbn in wishList)
                {
                    exist = WishItemIsinDB(userID, isbn);


                    if (exist)
                    {
                        // UpdateWishInDB(userID, isbn);
                    }
                    else
                    {
                        SaveWishinDB(userID, isbn);
                    }

                }
            }
        }
        private static bool UpdateCarinDB(string userID, BookItem book)
        {
            bool result;

            string sqlText = @"UPDATE shoppingCart SET qty=@parameterQTY  where UserId= @parameterUserId AND bookId= @parameterbookId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sqlText))
                {
                    cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                    cmd.Parameters.Add(new SqlParameter("@parameterbookId", book.ISBN));
                    cmd.Parameters.Add(new SqlParameter("@parameterQTY", book.quantity));

                    cmd.Connection = con;
                    con.Open();
                    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                    result = (count > 0);
                }
                con.Close();
            }

            return result;
        }


        private static bool SaveCarinDB(string userID, BookItem book)
        {
            bool result = false;

            if (userID != "")
            {
                string sqlText =
                    @"INSERT INTO  shoppingCart ( userId, bookId,qty ) VALUES( @parameterUserId, @parameterBookId, @parameterQTY );";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                        cmd.Parameters.Add(new SqlParameter("@parameterBookId", book.ISBN));
                        cmd.Parameters.Add(new SqlParameter("@parameterQTY", book.quantity));

                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        result = (count > 0);
                    }

                    con.Close();
                }
            }

            return result;
        }

        public static bool DeleteIteminDB(string ISBN)
        {
            string userID = GetUserId();
            bool result = false;
            if (userID != "")
            {
                //DELETE FROM table_name WHERE condition;
                string sqlText =
                    @"DELETE FROM  shoppingCart WHERE  userId = @parameterUserId AND  bookId=@parameterBookId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                        cmd.Parameters.Add(new SqlParameter("@parameterBookId", ISBN));
                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        result = (count > 0);
                    }

                    con.Close();
                }
            }

            return result;
        }


        public static bool RemoveWishItem(string ISBN)
        {
            string userID = GetUserId();
            bool result = false;
            if (userID != "")
            {

                string sqlText =
                    @"DELETE FROM  wishList WHERE  userId = @parameterUserId AND  bookId=@parameterBookId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                        cmd.Parameters.Add(new SqlParameter("@parameterBookId", ISBN));
                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        result = (count > 0);
                    }

                    con.Close();
                }
            }

            return result;
        }
        private static bool UpdateWishInDB(string userID, string ISBN)
        {
            bool result;

            string sqlText = @"UPDATE wishList SET   where UserId= @parameterUserId AND bookId= @parameterbookId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sqlText))
                {
                    cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                    cmd.Parameters.Add(new SqlParameter("@parameterbookId", ISBN));


                    cmd.Connection = con;
                    con.Open();
                    Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                    result = (count > 0);
                }
                con.Close();
            }

            return result;
        }

        private static bool SaveWishinDB(string userID, string isbn)
        {
            bool result = false;

            if (userID != "")
            {
                string sqlText =
                    @"INSERT INTO  wishList ( userId, bookId) VALUES( @parameterUserId, @parameterBookId );";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                        cmd.Parameters.Add(new SqlParameter("@parameterBookId", isbn));


                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        result = (count > 0);
                    }

                    con.Close();
                }
            }

            return result;
        }


        private static bool IsinDB(string userID, string ISBN)
        {
            bool result = false;

            if (userID != "")
            {
                string sqlText =
                    @"Select COUNT(userID) from shoppingCart where userID= @parameterUserId AND bookId= @parameterbookId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                        cmd.Parameters.Add(new SqlParameter("@parameterbookId", ISBN));
                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        result = (count > 0);
                    }

                    con.Close();
                }
            }

            return result;
        }


        private static bool WishItemIsinDB(string userID, string ISBN)
        {
            bool result = false;

            if (userID != "")
            {
                string sqlText =
                    @"Select COUNT(userID) from wishList where userID= @parameterUserId AND bookId= @parameterbookId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));
                        cmd.Parameters.Add(new SqlParameter("@parameterbookId", ISBN));
                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                        result = (count > 0);
                    }

                    con.Close();
                }
            }

            return result;
        }

        public static ShoppingCart LoadShoppingCartFromDB()
        {
            ShoppingCart myCart = new ShoppingCart();
            string userID = GetUserId();
            if (userID != "")
            {
                string sqlText = @"Select userID, bookID, qty from shoppingCart where userID= @parameterUserId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));

                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            myCart.BookList = new List<BookItem>();

                            while (reader.Read())
                            {
                                BookItem item = new BookItem();

                                item.ISBN = reader["bookId"].ToString();
                                item.quantity = Convert.ToInt32(reader["qty"].ToString());
                                myCart.BookList.Add(item);

                            }
                        }

                    }

                    con.Close();
                }
            }
            HttpContext.Current.Session[SessionCar] = myCart;
            return myCart;
        }


        public static List<string> LoadWishListFromDB()
        {
            List<string> myWishList = new List<string>();
            string userID = GetUserId();
            if (userID != "")
            {
                string sqlText = @"Select userID, bookID  from wishList where userID= @parameterUserId";
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(sqlText))
                    {
                        cmd.Parameters.Add(new SqlParameter("@parameterUserId", userID));

                        cmd.Connection = con;
                        con.Open();
                        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                                myWishList.Add(reader["bookId"].ToString());
                            }
                        }

                    }

                    con.Close();
                }
            }

            HttpContext.Current.Session[SaveForLater] = myWishList;
            return myWishList;
        }
        public static void AddItem(BookItem products)
        {
            ShoppingCart temp = GetShoopingCart();
            bool isInside = false;

            foreach (var item in temp.BookList)
            {
                if (item.ISBN == products.ISBN)
                {
                    item.Add(products.quantity);
                    isInside = true;
                }
            }
            if (!isInside)
            {
                temp.BookList.Add(products);
            }
            List<BookItem> bookListTemp = new List<BookItem>();

            foreach (var bookTemp in temp.BookList)
            {
                if (bookTemp.quantity > 0)
                {
                    bookListTemp.Add(bookTemp);
                }
                else
                {
                    string userId = GetUserId();
                    if (userId != "")
                    {
                        DeleteIteminDB(bookTemp.ISBN);
                    }
                }

            }

            temp.BookList = bookListTemp;
            SaveShoopingCart(temp);
        }


        public static void SaveShoopingCart(ShoppingCart mycar)
        {
            SaveCarToDb(mycar);
            HttpContext.Current.Session[SessionCar] = mycar;
        }
        public static ShoppingCart GetShoopingCart()
        {
            ShoppingCart result;
            try
            {
                result = (ShoppingCart)HttpContext.Current.Session[SessionCar];
            }
            catch (Exception)
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
            mycar.BookList.RemoveAll(p => p.ISBN == ISBN);
            SaveShoopingCart(mycar);
            SaveWishListToDb(wishList);
            HttpContext.Current.Session[SaveForLater] = wishList;
        }

        public static List<string> GetWishList()
        {
            LoadWishListFromDB();
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