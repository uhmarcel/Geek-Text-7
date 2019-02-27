using System;
using GeekTextLibrary;

namespace GeekText
{
    public partial class Profile : System.Web.UI.Page
    {
        User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
                savedUserNameLabel.Text = Session["Username"].ToString();
            savedNickNameLabel.Text = user.userNickName;
            savedEmailLabel.Text = user.eMailAddress;

           
            //Session["Username"] = user.userProfileName;
            //Session["UserPass"] = user.userPassword;
        }
        

        protected void NickNameButton_Click(object sender, EventArgs e)
        {
            if (newNickNameTextBox.Text != null)
            {
                // make call to update nickname in DB
            }

        }

        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            if (oldPasswordTextBox.Text.Equals(user.userPassword))
            {
                // make call to update password in DB
            }
        }

        protected void changeEmailButton_Click(object sender, EventArgs e)
        {
            if (EmailLabel1.Text != null)
            {
                // make call to update old email in DB
            }
        }

        protected void changeFirstFirstButton_Click(object sender, EventArgs e)
        {

        }

        protected void changeLastButton_Click(object sender, EventArgs e)
        {

        }
    }
}