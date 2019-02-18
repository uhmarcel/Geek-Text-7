using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GeekTextLibrary
{
    public class BookSearch
    {

        public List<Book> getBooksByTitle(string bookTitle, string connectionString)
        {
            try
            {
                List<Book> books = new List<Book>();
                string query = "SELECT * FROM Book WHERE bookTitle LIKE '%" + bookTitle + "%';";

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
                                curBook.publishingInfo.publishingCompany = reader["publsihingCompany"].ToString();
                                curBook.publishingInfo.copyrightYear = Convert.ToInt32(reader["publishingYear"]);
                                curBook.publishingInfo.location = reader["publishingLocation"].ToString();

                                books.Add(curBook);

                            }
                        }
                    }
                    con.Close();
                }

                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
