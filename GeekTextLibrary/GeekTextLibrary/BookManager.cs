using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekTextLibrary;

namespace GeekTextLibrary
{
    public class BookManager
    {
        public DataSet getAllBooksInDB(string connectionString)
        {

            try
            {
                string query = "Select * from Book;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds);
                                return ds;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Book> getlistofAllBooksInDB(string connectionString)
        {
            try
            {
                List<Book> allBooks = new List<Book>();
                string query = "Select * from Book;";

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
                                curBook.bookCover = (byte[])reader["bookCover"];
                                curBook.publishingInfo.publishingCompany = reader["publsihingCompany"].ToString();
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



        public DataSet getBookByISBN(string bookISBN, string connectionString)
        {
            try
            {
                string query = "SELECT * FROM Book WHERE ISBN = '@bookISBN';";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@bookISBN", bookISBN);
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds);
                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
  
