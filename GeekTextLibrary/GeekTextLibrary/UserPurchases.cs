using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTextLibrary
{
    public class UserPurchases
    {
        public int userID { get; set; }
        public string ISBN { get; set; }


        public static bool hasUserPurchasedBook(int userID, string ISBN, string connectionString)
        {
            try
            {
                string query = "SELECT 1 FROM [UserPurchases] WHERE userID=@userID AND ISBN=@ISBN";
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
