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
        public string ISBN { get; set; }
        public string reviewText { get; set; }
        public int reviewRating { get; set; }
        public int userID { get; set; }
        public string userNickname { get; set; }
        public string userFullname { get; set; }

        public void insertIntoDB(String connectionString)
        {
            try
            {
                string query = "INSERT INTO [bookReview] (ISBN, userID, reviewText, reviewRating) " +
                               "VALUES (@ISBN, @userID, @reviewText, @reviewRating);";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", this.ISBN);
                        cmd.Parameters.AddWithValue("@userID", this.userID);
                        cmd.Parameters.AddWithValue("@reviewText", this.reviewText);
                        cmd.Parameters.AddWithValue("@reviewRating", this.reviewRating);
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
