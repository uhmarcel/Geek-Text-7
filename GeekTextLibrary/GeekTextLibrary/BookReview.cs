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
    }

}
