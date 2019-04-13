using System;
using System.Collections.Generic;
using System.Configuration;
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
        public bool setUserCredentials(string userFirstName, string userLastName, string userNickName, string userName, string userPassword, string userEmail, string userCity, string userState, string userZipCode, string userStreetAddress, string connectionString)
        {
            try
            {
                string query = "INSERT INTO [User](userFirstName, userLastName,userNickName,email,userProfileName,userProfilePassword, userCity, userState, userZipCode, userStreetAddress) values('" + userFirstName + "','" + userLastName + "','" + userNickName + "','" + userEmail + "','" + userName + "','" + userPassword + "','" + userCity + "','" + userState + "','" + userZipCode + "','" + userStreetAddress + "') ; ";
                
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
                        cmd.Parameters.AddWithValue("@userCity", userCity.Trim());
                        cmd.Parameters.AddWithValue("@userState", userState.Trim());
                        cmd.Parameters.AddWithValue("@userZipCode", userZipCode.Trim());
                        cmd.Parameters.AddWithValue("@userStreetAddress", userStreetAddress.Trim());
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
                string query = "INSERT INTO [User]() values('" + city + "','" + state + "','" + zipCode + "','" + streetAddress + "') ; ";
                
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

        // for reviews
        public User getUserInfo(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT * FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userFirstName = reader["userFirstName"].ToString().Trim();
                                curUser.userLastName = reader["userLastName"].ToString().Trim();
                                curUser.userNickName = reader["userNickName"].ToString().Trim();
                                curUser.eMailAddress = reader["email"].ToString().Trim();
                                curUser.userProfileName = reader["userProfileName"].ToString().Trim();
                                curUser.userPassword = reader["userProfilePassword"].ToString().Trim();
                                curUser.userID = Convert.ToInt32(reader["userID"]);
                                curUser.userCity = reader["userCity"].ToString().Trim();
                                curUser.userState = reader["userState"].ToString().Trim();
                                curUser.userZipCode = reader["userZipCode"].ToString().Trim();
                                curUser.userStreetAddress = reader["userStreetAddress"].ToString().Trim();
                                //curUser.userCreditCard = reader["userCreditCard"]; 
                                curUser.userComment = reader["userZipCode"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser;
                                else
                                    return null;
                            }
                        }
                        con.Close();
                    }
                }
                return null;
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
                string query = "UPDATE [User] SET [userFirstName] = '" + name + "' WHERE [userID] = " + userID + " ; ";
                
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
                string query = "UPDATE [User] SET [userCity] = '" + city + "', [userState] = '" + state + "', [userZipCode] = '" + zipCode + "', [userStreetAddress] = '" + streetAddress + "' WHERE [userID] = " + userID + " ; ";
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

        // for profile viewing all credit cards connected to user
        public List<CreditCard> getCardsByID(string userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;

            try
            {
                List<CreditCard> cards = new List<CreditCard>();
                string query = "SELECT [cardFirstName], [cardLastName], [CreditCardNumber], [cvv], [expirationDate], [cardIndex]" +
                               "FROM [User], [CreditCard]" +
                               "WHERE [User].[userID] =  " + Convert.ToInt32(userID.Trim()) + " AND [User].[userID] = [CreditCard].[userID];";

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

                                CreditCard curCreditCard = new CreditCard();
                                curCreditCard.CreditCardNumber = reader["CreditCardNumber"].ToString().Trim();
                                curCreditCard.cvv = Convert.ToInt32(reader["cvv"].ToString().Trim());
                                curCreditCard.expirationDate = reader["expirationDate"].ToString().Trim();
                                curCreditCard.cardFirstName = reader["cardFirstName"].ToString();
                                curCreditCard.cardLastName = reader["cardLastName"].ToString();
                                curCreditCard.cardIndex = Convert.ToInt32(reader["cardIndex"].ToString().Trim());

                                cards.Add(curCreditCard);
                            }
                        }
                    }
                    con.Close();
                }

                return cards;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // for profile viewing all shipping addresses connected to user
        public List<Address> getAddressByID(string userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            try
            {
                List<Address> addresses = new List<Address>();
                string query = "SELECT [City], [State], [ZipCode], [streetAddress], [index]" +
                               "FROM [User], [Address]" +
                               "WHERE [User].[userID] =  " + Convert.ToInt32(userID.Trim()) + " AND [User].[userID] = [Address].[UserID];";

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

                                Address curShipAddress = new Address();
                                curShipAddress.city = reader["City"].ToString().Trim();                                
                                curShipAddress.state = reader["State"].ToString().Trim();
                                curShipAddress.zipCode = Convert.ToInt32(reader["ZipCode"].ToString().Trim());
                                curShipAddress.streetAddress = reader["streetAddress"].ToString().Trim();
                                curShipAddress.index = Convert.ToInt32(reader["index"].ToString().Trim());

                                addresses.Add(curShipAddress);
                            }
                        }
                    }
                    con.Close();
                }

                return addresses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region needs working/editing or haven't tested yet

        public int updateCreditcard(string cardFirstName, string cardLastName, string CreditCardNumber, int cvv, string expirationDate, int cardIndex, string userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;

            int rowsChanged = 0;
            try
            {
                string query = "UPDATE [CreditCard] SET [cardFirstName] = '" + cardFirstName.Trim() + "', [cardLastName] = '" + cardLastName.Trim() + "', [CreditCardNumber] = '" + CreditCardNumber.Trim() + "', [cvv] = '" + cvv + "', [expirationDate] = '" + expirationDate + "' WHERE [userID] = " + Convert.ToInt32(userID.Trim()) + " AND [cardIndex] = " + cardIndex + " ; ";
                
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@cardIndex", cardIndex);
                        cmd.Parameters.AddWithValue("@cardFirstName", cardFirstName.Trim());
                        cmd.Parameters.AddWithValue("@cardLastName", cardLastName.Trim());
                        cmd.Parameters.AddWithValue("@CreditCardNumber", CreditCardNumber.Trim());
                        cmd.Parameters.AddWithValue("@cvv", cvv);
                        cmd.Parameters.AddWithValue("@expirationDate", expirationDate.Trim());
                        cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userID.Trim()));
                        rowsChanged = cmd.ExecuteNonQuery();
                        
                    }

                    con.Close();
                    return rowsChanged;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateShipAddress(string streetAddress, string city, string state, string zipCode, int index, string userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            int rowsChanged = 0;
            try
            {
                string query = "UPDATE [Address] SET [City] = '" + city + "', [State] = '" + state + "', [ZipCode] = '" + zipCode + "', [streetAddress] = '" + streetAddress + "' WHERE [UserID] = " + Convert.ToInt32(userID.Trim()) + " AND [index] = " + index + "; ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@index", index);
                        cmd.Parameters.AddWithValue("@City", city.Trim());
                        cmd.Parameters.AddWithValue("@State", state.Trim());
                        cmd.Parameters.AddWithValue("@ZipCode", zipCode.Trim());
                        cmd.Parameters.AddWithValue("@streetAddress", streetAddress.Trim());
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Trim()));
                        rowsChanged = cmd.ExecuteNonQuery();
                    }

                    con.Close();
                    return rowsChanged;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteCard(int cardIndex, string userID)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;

            
            try
            {
                string query = "DELETE FROM [CreditCard] WHERE [userID] = " + Convert.ToInt32(userID.Trim()) +" AND [cardIndex] = " + cardIndex + "; ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@cardIndex", cardIndex);
                        cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userID.Trim()));
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

        public void deleteAddress(int index, string userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;
            
            try
            {
                string query = "DELETE FROM [Address] WHERE [UserID] = " + Convert.ToInt32(userID.Trim()) + " AND [index] = " + index + "; ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@index", index);
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Trim()));
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

        public void addUserCard(string cardFirstName, string cardLastName, string creditCardNumber, int cvv, string expirationDate, string userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;

            try
            {
                string query = "INSERT INTO [CreditCard](cardFirstName, cardLastName, CreditCardNumber, cvv, expirationDate, userID) values('" + cardFirstName + "','" + cardLastName + "','" + creditCardNumber + "',"+ cvv + ",'" + expirationDate + "'," + Convert.ToInt32(userID.Trim()) + ") ; ";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@cardFirstName", cardFirstName.Trim());
                        cmd.Parameters.AddWithValue("@cardLastName", cardLastName.Trim());
                        cmd.Parameters.AddWithValue("@CreditCardNumber", creditCardNumber.Trim());
                        cmd.Parameters.AddWithValue("@cvv", cvv);
                        cmd.Parameters.AddWithValue("@expirationDate", expirationDate.Trim());
                        cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(userID.Trim()));
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

        public void addUserAddress(string city, string state, string zipCode, string userID, string streetAddress)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString;

            try
            {
                string query = "INSERT INTO [Address](City, State, ZipCode, UserID, streetAddress) values('" + city + "','" + state + "','" + zipCode + "'," + Convert.ToInt32(userID.Trim()) + ",'" + streetAddress + "') ; ";
                
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("@City", city.Trim());
                        cmd.Parameters.AddWithValue("@State", state.Trim());
                        cmd.Parameters.AddWithValue("@ZipCode", zipCode.Trim());
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(userID.Trim()));
                        cmd.Parameters.AddWithValue("@StreetAddress", streetAddress.Trim());
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
        // for profile
        public string getUserCity(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [userCity] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userCity = reader["userCity"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userCity;
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
        public string getUserState(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [userState] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userState = reader["userState"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userState;
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
        public string getUserZip(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [userZipCode] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userZipCode = reader["userZipCode"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userZipCode;
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
        public string getUserStreet(string username, string password, string connectionString)
        {
            try
            {
                string query = "SELECT [userProfileName], [userProfilePassword], [userStreetAddress] FROM [User] WHERE [userProfileName]='" + username + "' AND [userProfilePassword]='" + password + "';";
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
                                curUser.userStreetAddress = reader["userStreetAddress"].ToString().Trim();
                                // checking username and passwords together make it more secure
                                if (curUser.userProfileName.Trim().Equals(username.Trim()) && curUser.userPassword.Trim().Equals(password.Trim()))
                                    return curUser.userStreetAddress;
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

        #endregion
    }
}
