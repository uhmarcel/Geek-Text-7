using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeekTextLibrary.Author;

namespace GeekTextLibrary
{
   public class AuthorManager
    {
        public List<Author> getAllAuthorsInDB(string connectionString)
        {
            try
            {
                List<Author> allAuthors = new List<Author>();
                string query = "Select * from Author;";

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
                                Author currAuthor = new Author();
                                currAuthor.authorId = Convert.ToInt32(reader["AuthorID"]);
                                currAuthor.authorName = reader["AuthorName"].ToString();
                                currAuthor.shortBio = reader["AuthorBio"].ToString();
                                currAuthor.ISBN = reader["ISBN"].ToString();                           
                                allAuthors.Add(currAuthor);

                            }
                        }
                    }
                    con.Close();
                }

                return allAuthors;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
