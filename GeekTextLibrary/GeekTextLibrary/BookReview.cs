using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTextLibrary
{
    public class BookReview
    {
        public const int DISPLAY_FULLNAME = 1;
        public const int DISPLAY_NICKNAME = 2;
        public const int DISPLAY_ANONYMOUS = 3;

        public string ISBN { get; set; }
        public int userID { get; set; }
        public string reviewText { get; set; }
        public int reviewRating { get; set; }
        public int displayAs { get; set; }
        public string userChosenDisplay { get; private set; }

        public void setUserDisplay(string fn, string nn)
        {
            if (displayAs == DISPLAY_FULLNAME) userChosenDisplay = fn;
            else if (displayAs == DISPLAY_NICKNAME) userChosenDisplay = nn;
            else if (displayAs == DISPLAY_ANONYMOUS) userChosenDisplay = "Anonymous";
            else throw new Exception("Invalid displayAs state");
        }

        public void insertIntoDB(String connectionString)
        {
            try
            {
                string query = "INSERT INTO [bookReview] (ISBN, userID, reviewText, reviewRating, displayAs) " +
                               "VALUES (@ISBN, @userID, @reviewText, @reviewRating, @displayAs);";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", this.ISBN);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.Parameters.AddWithValue("@reviewText", this.reviewText);
                        cmd.Parameters.AddWithValue("@reviewRating", this.reviewRating);
                        cmd.Parameters.AddWithValue("@displayAs", this.displayAs);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateIntoDB(String connectionString)
        {
            try
            {
                string query = "UPDATE [bookReview] " +
                               "SET reviewText=@reviewText, reviewRating=@reviewRating, displayAs=@displayAs " +
                               "WHERE ISBN=@ISBN AND userID=@userID ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", this.ISBN);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.Parameters.AddWithValue("@reviewText", this.reviewText);
                        cmd.Parameters.AddWithValue("@reviewRating", this.reviewRating);
                        cmd.Parameters.AddWithValue("@displayAs", this.displayAs);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BookReview> getBookReviewsByISBN(string bookISBN, string connectionString)
        {
            try
            {
                List<BookReview> bookReviews = new List<BookReview>();
                string query = "SELECT [userFirstName], [userLastName], [userNickName], [reviewText], [reviewRating], [displayAs] " +
                               "FROM [User], [BookReview] " +
                               "WHERE [ISBN] = @bookISBN AND [User].[userID] = [BookReview].[userID]; ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@bookISBN", bookISBN);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["userFirstName"].ToString() + " " + reader["userLastName"].ToString();
                                string nick = reader["userNickname"].ToString();

                                BookReview curBookReview = new BookReview();
                                curBookReview.reviewText = reader["reviewText"].ToString();
                                curBookReview.reviewRating = Convert.ToInt32(reader["reviewRating"]);
                                curBookReview.displayAs = Convert.ToInt32(reader["displayAs"]);
                                curBookReview.setUserDisplay(name, nick);

                                bookReviews.Add(curBookReview);
                            }
                        }
                    }
                    con.Close();
                }

                return bookReviews;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BookReview getBookReviewsByUserAndISBN(int userID, string bookISBN, string connectionString)
        {
            try
            {
                BookReview bookReview = new BookReview();
                string query = "SELECT [userFirstName], [userLastName], [userNickName], [reviewText], [reviewRating], [displayAs]" +
                               "FROM [User], [BookReview]" +
                               "WHERE [ISBN] = @bookISBN AND [User].[userID] = [BookReview].[userID] AND [User].[userID] = @userID;";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@bookISBN", bookISBN);
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();

                            string name = reader["userFirstName"].ToString() + " " + reader["userLastName"].ToString();
                            string nick = reader["userNickname"].ToString();

                            bookReview.ISBN = bookISBN;
                            bookReview.userID = userID;
                            bookReview.reviewText = reader["reviewText"].ToString();
                            bookReview.reviewRating = Convert.ToInt32(reader["reviewRating"]);
                            bookReview.displayAs = Convert.ToInt32(reader["displayAs"]);
                            bookReview.setUserDisplay(name, nick);
                        }
                    }
                    con.Close();
                }
                return bookReview;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Boolean existsUserComment(int userID, string ISBN, String connectionString)
        {
            try
            {
                string query = "SELECT 1 FROM [BookReview] WHERE userID=@userID AND ISBN=@ISBN";
                bool output = false;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@ISBN", ISBN);
                        cmd.Connection = con;
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                output = true;
                            con.Close();
                            return output;
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

