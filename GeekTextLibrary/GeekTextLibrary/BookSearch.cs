using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GeekTextLibrary
{
    public class BookSearch
    {

        public List<Book> connectAndSendQuery(string query, string connectionString)
        {
            List<Book> books = new List<Book>();

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
                            curBook.genre = reader["bookGenre"].ToString();
                            if (Convert.ToInt32(reader["bestSeller"]) == 1)
                            {
                                curBook.bestSeller = "Best Seller";
                            }
                            else
                            {
                                curBook.bestSeller = "";
                            }
                            curBook.bookRating = (float)Convert.ToDouble(reader["userRating"]);
                            curBook.price = Convert.ToDouble(reader["bookPrice"]);
                            curBook.publishingInfo.publishingCompany = reader["publishingCompany"].ToString();
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

        public List<Book> getBooksByTitle(string bookTitle, string connectionString)
        {
            try
            {
                List<Book> books = new List<Book>();

                string query = "SELECT * FROM Book WHERE bookTitle LIKE '%" + bookTitle + "%';";

                books = connectAndSendQuery(query, connectionString);

                return books;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Book> getBooksByAllFilters(List<string> genresList, bool value, List<string> ratings, string sortingCriteria, string connectionString)
        {
            try
            {
                List<Book> books = new List<Book>();

                string query = "";

                if (genresList.Count != 0 || value || ratings.Count != 0)
                {
                    query = "SELECT * FROM Book WHERE ";

                    if (genresList.Count != 0)
                    {
                        query = query + "(bookGenre='" + genresList[0] + "'";

                        for (int i = 1; i < genresList.Count; i++)
                        {
                            query = query + " OR bookGenre='" + genresList[i] + "'";
                        }

                        query = query + ")";

                        if (value || ratings.Count != 0)
                        {
                            query = query + " AND ";
                        }
                    }

                    if (value)
                    {
                        query = query + "bestSeller=1";

                        if (ratings.Count != 0)
                        {
                            query = query + " AND ";
                        }
                    }

                    if (ratings.Count != 0)
                    {
                        string maxRange = (Convert.ToInt32(ratings[0]) + 1).ToString();
                        query = query + "((userRating>=" + ratings[0] + " AND userRating<" + maxRange + ")";

                        for (int i = 1; i < ratings.Count; i++)
                        {
                            maxRange = (Convert.ToInt32(ratings[i]) + 1).ToString();
                            query = query + " OR (userRating>=" + ratings[i] + " AND userRating<" + maxRange + ")";
                        }

                        query = query + ")";
                    }

                    if (sortingCriteria != null)
                    {
                        query = query + " ORDER BY ";

                        switch (sortingCriteria)
                        {
                            case "Title":
                                query = query + "bookTitle";
                                break;
                            case "Author":
                                query = query + "bookAuthor";
                                break;
                            case "Price":
                                query = query + "bookPrice";
                                break;
                            case "Rating":
                                query = query + "userRating";
                                break;
                            case "Release Date":
                                query = query + "publishingYear";
                                break;
                        }

                        //query = query + " ASC";
                    }

                    query = query + ";";

                    books = connectAndSendQuery(query, connectionString);
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