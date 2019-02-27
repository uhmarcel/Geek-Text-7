
using System;
using System.Configuration;
using GeekTextLibrary;

namespace GeekText
{
    public partial class Profile : System.Web.UI.Page
    {
        UserManager userMan = new UserManager();
        User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["UserPass"] != null)
            {
                // get from DB
                user.userID = Convert.ToInt32(Session["UserID"].ToString());
                user.userProfileName = Session["Username"].ToString();
                user.userFirstName = userMan.getUserFirstName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userLastName = userMan.getUserLastName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userNickName = userMan.getUserNickName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.eMailAddress = userMan.getEmail(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }
            // put in labels on profile page
            savedUserNameLabel.Text = user.userProfileName;
            savedFirstNameLabel.Text = user.userFirstName;
            savedLastNameLabel.Text = user.userLastName;
            savedNickNameLabel.Text = user.userNickName;
            savedEmailLabel.Text = user.eMailAddress;
            
        }


        protected void NickNameButton_Click(object sender, EventArgs e)
        {
            if (newNickNameTextBox.Text.Trim() != null)
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserNickName(newNickNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newNickNameTextBox.Text = "";

                // refreshes page client side to show changes
                Response.Redirect(Request.RawUrl);
            }

        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            if (oldPasswordTextBox.Text.Trim() != null && oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim()))
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserPass(newPasswordTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                {
                    oldPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";

                    // refreshes page client side to show changes
                    Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void changeEmailButton_Click(object sender, EventArgs e)
        {
            // returns true if the changes are made on the SQL side
            if (newEmailTextBox.Text.Trim() != null)
            {
                if (userMan.changeUserEmail(newEmailTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newEmailTextBox.Text = "";

                // refreshes page client side to show changes
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void changeLastButton_Click(object sender, EventArgs e)
        {
            // returns true if the changes are made on the SQL side
            if (newLastNameTextBox.Text.Trim() != null)
            {
                if (userMan.changeUserLastName(newLastNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newLastNameTextBox.Text = "";

                // refreshes page client side to show changes
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void changeFirstNameButton_Click(object sender, EventArgs e)
        {
            // returns true if the changes are made on the SQL side
            if (newFirstNameTextBox.Text.Trim() != null)
            {
                if (userMan.changeUserFirstName(newFirstNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newFirstNameTextBox.Text = "";
                // refreshes page client side to show changes
                Response.Redirect(Request.RawUrl);
            }
        }

        // need to add the edit address part.
    }
}