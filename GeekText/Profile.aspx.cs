
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
                user = userMan.getUserInfo(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }

            if (user != null)
            {
                // put in labels on profile panel
                savedUserNameLabel.Text = user.userProfileName;
                savedFirstNameLabel.Text = user.userFirstName;
                savedLastNameLabel.Text = user.userLastName;
                savedNickNameLabel.Text = user.userNickName;
                savedEmailLabel.Text = user.eMailAddress;
                savedCityLabel.Text = user.userCity;
                savedStateLabel.Text = user.userState;
                savedStreetAddressLabel.Text = user.userStreetAddress;
                savedZipCodeLabel.Text = user.userZipCode;


                // put in labels on edit panel
                currFirstNameLabel.Text = user.userProfileName;
                currLastNameLabel.Text = user.userLastName;
                currNickNameLabel.Text = user.userNickName;
                currEmailLabel.Text = user.eMailAddress;
                currCityLabel.Text = user.userCity;
                currStateLabel.Text = user.userState;
                currStreetAddressLabel.Text = user.userStreetAddress;
                currZipCodeLabel.Text = user.userZipCode;
            }

        }

        protected void EditProfileBtn_Click(object sender, EventArgs e)
        {
            ProfilePanel.Visible = false;
            EditPanel.Visible = true;
            SuccesLabel.Text = "";
        }

        protected void SubmitEditBtn_Click(object sender, EventArgs e)
        {

            changeNickName();
            changeFirstName();
            changeLastName();
            changePassword();
            changeEmail();
            changeAddress();

            // need this to reload info back to panel
            if (Session["Username"] != null && Session["UserPass"] != null)
            {
                user = userMan.getUserInfo(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }
 
            currFirstNameLabel.Text = user.userProfileName;
            currLastNameLabel.Text = user.userLastName;
            currNickNameLabel.Text = user.userNickName;
            currEmailLabel.Text = user.eMailAddress;
            currCityLabel.Text = user.userCity;
            currStateLabel.Text = user.userState;
            currStreetAddressLabel.Text = user.userStreetAddress;
            currZipCodeLabel.Text = user.userZipCode;

            if (newNickNameTextBox.Text.Trim() != "" && newFirstNameTextBox.Text.Trim() != "" && newLastNameTextBox.Text.Trim() != ""
                && oldPasswordTextBox.Text.Trim() != "" && oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim())
                && newEmailTextBox.Text.Trim() != ""
                && newStreetAddressTextBox.Text.Trim() != "" && newCityTextBox.Text.Trim() != "" && DropDownList.Text != "Select a State" && newZipCodeTextBox.Text.Trim() != "")
            {
                SuccesLabel.Text = "Changes Saved";
            }
            else if ((newNickNameTextBox.Text.Trim() != "" || newFirstNameTextBox.Text.Trim() != "" || newLastNameTextBox.Text.Trim() != ""
                || oldPasswordTextBox.Text.Trim() != "" || oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim())
                || newEmailTextBox.Text.Trim() != ""
                || newStreetAddressTextBox.Text.Trim() != "" || newCityTextBox.Text.Trim() != "" || DropDownList.Text != "Select a State" || newZipCodeTextBox.Text.Trim() != ""))
            {
                SuccesLabel.Text = "Changes Saved";
            }
            else
                SuccesLabel.Text = "No Changes Saved";

            //Page.AutoPostBackControl();

        }


        protected void changeNickName()
        {
            if (newNickNameTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserNickName(newNickNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newNickNameTextBox.Text = "";
            }
        }

        protected void changeFirstName()
        {
            if (newFirstNameTextBox.Text.Trim() != null)
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserFirstName(newFirstNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newFirstNameTextBox.Text = "";
            }
        }

        protected void changeLastName()
        {
            if (newLastNameTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserLastName(newLastNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newLastNameTextBox.Text = "";
            }
        }

        protected void changePassword()
        {
            if (oldPasswordTextBox.Text.Trim() != "" && oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim()))
            {

                // returns true if the changes are made on the SQL side
                if (userMan.changeUserPass(newPasswordTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                {
                    oldPasswordTextBox.Text = "";
                    newPasswordTextBox.Text = "";
                }
            }
        }
            
        protected void changeEmail()
        {
            if (newEmailTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserEmail(newEmailTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) 
                    newEmailTextBox.Text = "";
            }
        
        }

        protected void changeAddress()
        {
            if (newStreetAddressTextBox.Text.Trim() != "" && newCityTextBox.Text.Trim() != "" && DropDownList.Text != "Select a State" && newZipCodeTextBox.Text.Trim() != "")
            {
                if (userMan.changeUserAddress(newCityTextBox.Text.Trim(), DropDownList.Text.Trim(), newZipCodeTextBox.Text.Trim(), newStreetAddressTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString))
                {
                    newCityTextBox.Text = "";
                    DropDownList.Text = "Select a State";
                    newZipCodeTextBox.Text = "";
                    newStreetAddressTextBox.Text = "";

                }
            }

        }


        protected void BackToProfile_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ProfilePanel.Visible = true;
        }
    }
}