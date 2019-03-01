using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Web.UI.WebControls;
using GeekText.Services;

namespace GeekText
{
    public partial class Contact : Page
    {
        public UserManager userMan = new UserManager();
        public User user = new User();
        //string storedUserName;
        //string storedUserPass;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            if (userMan.checkUsernameAndPass(Login1.UserName.Trim(), Login1.Password.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString))
            {
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Incorrect username or password" + "');", true);
            }
        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            // getting user information from the DB
            user.userID = userMan.getUserID(Login1.UserName.Trim(), Login1.Password.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            user.userProfileName = userMan.getUserProfileName(Login1.UserName.Trim(), Login1.Password.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            user.userPassword = userMan.getUserPass(Login1.UserName.Trim(), Login1.Password.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);

            // put info into session ID and use UserManager methods to get the rest from these
            Session["UserID"] = user.userID;
            ServicesShoppingCart.LoadShoppingCartFromDB();
            Session["Username"] = user.userProfileName;
            Session["UserPass"] = user.userPassword;
            

            Response.Redirect("Profile.aspx");
        }
    }
}