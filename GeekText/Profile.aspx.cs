
using System;
using System.Configuration;
using GeekTextLibrary;

namespace GeekText
{
    public partial class Profile : System.Web.UI.Page
    {
        UserManager userMan = new UserManager();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["UserPass"] != null)
            {
                savedUserNameLabel.Text = Session["Username"].ToString();
                savedNickNameLabel.Text = userMan.getUserNickName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                savedFirstNameLabel.Text = userMan.getUserFirstName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                savedLastNameLabel.Text = userMan.getUserLastName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                savedEmailLabel.Text = userMan.getEmail(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }

           
            //Session["Username"] = user.userProfileName;
            //Session["UserPass"] = user.userPassword;
        }
        

        protected void NickNameButton_Click(object sender, EventArgs e)
        {
            if (newNickNameTextBox.Text.Trim() != null)
            {
                // make call to update nickname in DB
            }

        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            if (oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim()))
            {
                // make call to update password in DB
            }
        }

        protected void changeEmailButton_Click(object sender, EventArgs e)
        {
            if (EmailLabel1.Text.Trim() != null)
            {
                // make call to update old email in DB
            }
        }

        protected void changeFirstFirstButton_Click(object sender, EventArgs e)
        {
            if (newFirstNameTextBox.Text.Trim() != null)
            {
                // make call to update 
            }
        }

        protected void changeLastButton_Click(object sender, EventArgs e)
        {
            if (newLastNameTextBox.Text.Trim() != null)
            {
                // make call to update 
            }
        }
    }
}