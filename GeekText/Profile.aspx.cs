using System;
using GeekTextLibrary;

namespace GeekText
{
    public partial class Profile : System.Web.UI.Page
    {
        User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            savedUserNameLabel.Text = user.userProfileName;
            savedNickNameLabel.Text = user.userNickName;
            savedEmailLabel.Text = user.eMailAddress;
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
    }
}