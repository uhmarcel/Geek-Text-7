using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTextLibrary
{
    public class UserManager
    {
        #region works correctly
        public bool getUserCreds(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                User curUser = new User();
                                curUser.userProfileName = reader["userProfileName"].ToString().Trim();
                                curUser.userPassword = reader["userProfilePassword"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return true;
                                else
                                    return false;
                            }
                        }
                        con.Close();
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool setUserCredentials(string userFirstName, string userLastName, string userNickName, string userName, string userPassword, string userEmail, string connectionString)
        {
            try
            {
                string query = "INSERT INTO [User](userFirstName, userLastName,userNickName,email,userProfileName,userProfilePassword) values('" + userFirstName + "','" + userLastName + "','" + userNickName + "','" + userName + "','" + userPassword + "','" + userEmail + "') ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userFirstName", userFirstName.Trim());
                        cmd.Parameters.AddWithValue("@userLastName", userLastName.Trim());
                        cmd.Parameters.AddWithValue("@userNickName", userNickName.Trim());
                        cmd.Parameters.AddWithValue("@userProfileName", userName.Trim());
                        cmd.Parameters.AddWithValue("@userProfilePassword", userPassword.Trim());
                        cmd.Parameters.AddWithValue("@email", userEmail.Trim());
                        rowsChanged = cmd.ExecuteNonQuery();
                    }

                    con.Close();
                    if (rowsChanged > 0)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region needs working/editing or haven't tested yet
        public bool getUserPass(string userPassword, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfilePassword] FROM [User] WHERE [userProfilePassword]='" + userPassword + "';";

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
                                User curUser = new User();
                                curUser.userPassword = reader["userProfilePassword"].ToString().Trim();
                                if (curUser.userPassword.Trim().Equals(userPassword.Trim()))
                                    return true;
                                else
                                    return false;
                            }
                        }
                        con.Close();
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet getUserNickName(string userNickName, string connectionString)
        {
            try
            {
                string query = "SELECT FROM [User] WHERE userNickName = '@userNickName';";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@userNickName", userNickName);
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
        public DataSet getUserEmail(string userEmail, string connectionString)
        {
            try
            {
                string query = "SELECT FROM [User] WHERE email = '@userEmail';";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.AddWithValue("@userEmail", userEmail);
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

        public void setUserPersonalInfo(string userFirstName, string userLastName, string connectionString)
        {
            try
            {
                User curUser = new User();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("User", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userFirstName", userFirstName.Trim());
                        cmd.Parameters.AddWithValue("@userLastName", userLastName.Trim());
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setUserAddress(string streetAddress, string city, string state, string zipCode, string connectionString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Address", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@streetAddress", streetAddress.Trim());
                        cmd.Parameters.AddWithValue("@City", city.Trim());
                        cmd.Parameters.AddWithValue("@State", state.Trim());
                        cmd.Parameters.AddWithValue("@ZipCode", zipCode.Trim());
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setUserCreditCard(string creditCardNum, int ccv, string expirationDate, string connectionString)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("CreditCard", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CreditCardNumber", creditCardNum.Trim());
                        cmd.Parameters.AddWithValue("@ccv", ccv);
                        cmd.Parameters.AddWithValue("@expirationDate", expirationDate.Trim());
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
