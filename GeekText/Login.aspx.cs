using System;
using System.Web.UI;
using System.Configuration;
using GeekTextLibrary;
using System.Data;
using System.Web.UI.WebControls;

namespace GeekText
{
    public partial class Contact : Page
    {
        UserManager user = new UserManager();
        //string storedUserName;
        //string storedUserPass;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            if (user.getUserCreds(Login1.UserName.Trim(), Login1.Password.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString))
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
            Response.Redirect("Profile.aspx");
        }
    }
}