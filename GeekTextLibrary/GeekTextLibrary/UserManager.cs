using System;
using System.Data;
using System.Data.SqlClient;

namespace GeekTextLibrary
{
    public class UserManager
    {
        #region works correctly

        // for sign up validation make sure there is no existing username 
        public bool checkUsername(string username, string connectionString)
        {
            try
            {
                string query = "SELECT * FROM [User] WHERE [userProfileName]='" + username + "';";
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
                                if(reader.HasRows)
                                    return true; // if found return true
                                else
                                    return false; // means it wasn't found
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
        // for sign up validation, make sure there is no existing email 
        public bool checkEmail(string email, string connectionString)
        {
            try
            {
                string query = "SELECT * FROM [User] WHERE [email]='" + email + "';";
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
                                if (reader.HasRows)
                                    return true; // if found return true
                                else
                                    return false; // means it wasn't found
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
        // for sign up name, username/pass and email
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
        // for sign up, address
        public bool setUserAddress(string city, string state, string zipCode, string streetAddress, string connectionString)
        {

            try
            {
                string query = "INSERT INTO [User](userCity, userState, userZipCode, userStreetAddress) values('" + city + "','" + state + "','" + zipCode + "','" + streetAddress + "') ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userCity", city.Trim());
                        cmd.Parameters.AddWithValue("@userState", state.Trim());
                        cmd.Parameters.AddWithValue("@userZipCode", zipCode.Trim());
                        cmd.Parameters.AddWithValue("@userStreetAddress", streetAddress.Trim());
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

        // for login
        public bool checkUsernameAndPass(string username, string password, string connectionString)
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

        // for profile 
        public int getUserID(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName],[userProfilePassword],[userID] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userID = Convert.ToInt32(reader["userID"]);
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userID;
                                else
                                    return 0;
                            }
                        }
                        con.Close();
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // for profile
        public string getUserFirstName(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [userFirstName] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userFirstName = reader["userFirstName"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userFirstName;
                                else
                                    return "";
                            }
                        }
                        con.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // for profile
        public string getUserLastName(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [userLastName] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userLastName = reader["userLastName"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userLastName;
                                else
                                    return "";
                            }
                        }
                        con.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // for profile
        public string getUserNickName(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword],[userNickName] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userNickName = reader["userNickName"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userNickName;
                                else
                                    return "";
                            }
                        }
                        con.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // for profile
        public string getEmail(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [email] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.eMailAddress = reader["email"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.eMailAddress;
                                else
                                    return "";
                            }
                        }
                        con.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // for profile
        public string getUserProfileName(string username, string password, string connectionString)
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
                                    return curUser.userProfileName;
                                else
                                    return "";
                            }
                        }
                        con.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        // for profile...... NOPE for password change
        public string getUserPass(string username, string password, string connectionString)
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
                                    return curUser.userPassword;
                                else
                                    return "";
                            }
                        }
                        con.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       
        #endregion
        #region needs working/editing or haven't tested yet
        public bool addUserAddress(string city, string state, string zipCode, int userID,string streetAddress, string connectionString)
        {

            try
            {
                string query = "INSERT INTO [Address](City, State, ZipCode,StreetAddress) values('" + city + "','" + state + "','" + zipCode + "'," + userID + ",'" + streetAddress + "') ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@City", city.Trim());
                        cmd.Parameters.AddWithValue("@State", state.Trim());
                        cmd.Parameters.AddWithValue("@ZipCode", zipCode.Trim());
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@StreetAddress", streetAddress.Trim());
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

        // for profile first name change
        public bool changeUserFirstName(string name, int userID, string connectionString)
        {

            try
            {
                string query = "UPDATE [User] SET [userFirstName] = '"+ name +"' WHERE [userID] = "+ userID +" ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userFirstName", name.Trim());
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
        // for profile last name change
        public bool changeUserLastName(string name, int userID, string connectionString)
        {

            try
            {
                string query = "UPDATE [User] SET userLastName = '" + name + "' WHERE [userID] = " + userID + " ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userLastName", name.Trim());
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
        // for profile nickname change
        public bool changeUserNickName(string name, int userID, string connectionString)
        {

            try
            {
                string query = "UPDATE [User] SET userNickName = '" + name + "' WHERE [userID] = " + userID + " ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userNickName", name.Trim());
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
        // for profile email change
        public bool changeUserEmail(string email, int userID, string connectionString)
        {

            try
            {
                string query = "UPDATE [User] SET email = '" + email + "' WHERE [userID] = " + userID + " ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@email", email.Trim());
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
        // for profile pass change
        public bool changeUserPass(string pass, int userID, string connectionString)
        {

            try
            {
                string query = "UPDATE [User] SET userProfilePass = '" + pass + "' WHERE [userID] = " + userID + " ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userProfilePass", pass.Trim());
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

        // for profile address change
        public bool changeUserAddress(string city, string state, string zipCode, string streetAddress, int userID, string connectionString)
        {

            try
            {
                string query = "UPDATE [User] SET [userCity] = '" + city + "', [userState] = '" + state + "', [userZipCode] = '" + zipCode + "', [userStreetAddress] = '" + streetAddress + "' WHERE [userID] = " + userID +" ; ";
                User curUser = new User();
                int rowsChanged = 0;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@userCity", city.Trim());
                        cmd.Parameters.AddWithValue("@userState", state.Trim());
                        cmd.Parameters.AddWithValue("@userZipCode", zipCode.Trim());
                        cmd.Parameters.AddWithValue("@userStreetAddress", streetAddress.Trim());
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
    }
}
