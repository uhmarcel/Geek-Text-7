using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Web.UI.WebControls;
using GeekText.Services;
using System.Security.Cryptography;
using System.Text;

namespace GeekText
{
    public partial class Contact : Page
    {
        private UserManager userMan = new UserManager();
        private User user = new User();
        private string hashedPassword;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["UserPass"] != null && Session["userID"]!= null)
            {
                Response.Redirect("Profile.aspx");
            }
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            hashedPassword = GetSwcSHA1(Login1.Password.Trim());
            if (userMan.checkUsernameAndPass(Login1.UserName.Trim(), hashedPassword, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString))
            {
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Incorrect username or password" + "');", true);
            }
        }

        // hashing for password
        protected static string GetSwcSHA1(string value)
        {
            SHA256 algorithm = SHA256.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            // getting user information from the DB
            user = userMan.getUserInfo(Login1.UserName.Trim(), hashedPassword, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);

            // put info into session ID and use UserManager methods to get the rest from these
            Session["UserID"] = user.userID;
            ServicesShoppingCart.LoadShoppingCartFromDB();
            Session["Username"] = user.userProfileName;
            Session["UserPass"] = user.userPassword;
            

            Response.Redirect("Profile.aspx");
        }
    }
}