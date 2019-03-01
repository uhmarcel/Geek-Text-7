
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
            // don't want to load the edit panel until needed.
            EditPanel.Visible = false;
            if (Session["Username"] != null && Session["UserPass"] != null)
            {
                // get from DB
                user.userID = Convert.ToInt32(Session["UserID"].ToString());
                user.userProfileName = Session["Username"].ToString();
                user.userFirstName = userMan.getUserFirstName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userLastName = userMan.getUserLastName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userNickName = userMan.getUserNickName(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.eMailAddress = userMan.getEmail(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userCity = userMan.getUserCity(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userState = userMan.getUserState(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userStreetAddress = userMan.getUserStreet(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                user.userZipCode = userMan.getUserZip(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            }
            // put in labels on profile panel
            savedUserNameLabel.Text = user.userProfileName;
            savedFirstNameLabel.Text = user.userFirstName;
            savedLastNameLabel.Text = user.userLastName;
            savedNickNameLabel.Text = user.userNickName;
            savedEmailLabel.Text = user.eMailAddress;
            savedCityLabel.Text = user.userCity;
            savedStateLabel.Text = user.userState;
            savedStateLabel.Text = user.userStreetAddress;
            savedZipCodeLabel.Text= user.userZipCode;


            // put in labels on edit panel
            currFirstNameLabel.Text = user.userProfileName;
            currLastNameLabel.Text = user.userLastName;
            currNickNameLabel.Text = user.userNickName;
            currEmailLabel.Text = user.eMailAddress;
            currCityLabel.Text = user.userCity;
            currStateLabel.Text = user.userState;
            currStateLabel.Text = user.userStreetAddress;
            currZipCodeLabel.Text = user.userZipCode;


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

            if (newNickNameTextBox.Text.Trim() != null && newFirstNameTextBox.Text.Trim() != null && newLastNameTextBox.Text.Trim() != null
                && oldPasswordTextBox.Text.Trim() != null && oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim())
                && newEmailTextBox.Text.Trim() != null
                && newStreetAddressTextBox.Text.Trim() != null && newCityTextBox.Text.Trim() != null && DropDownList.Text != "Select a State" && newZipCodeTextBox.Text.Trim() != null)
            {
                SuccesLabel.Text = "No Changes Made";
            }
            else
                SuccesLabel.Text = "Changes Saved";

            // refreshes page client side to show changes
            Response.Redirect(Request.RawUrl);
        }


        protected void changeNickName()
        {
            if (newNickNameTextBox.Text.Trim() != null)
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
            if (newLastNameTextBox.Text.Trim() != null)
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserLastName(newLastNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                    newLastNameTextBox.Text = "";
            }
        }

        protected void changePassword()
        {
            if (oldPasswordTextBox.Text.Trim() != null && oldPasswordTextBox.Text.Trim().Equals(Session["UserPass"].ToString().Trim()))
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
            if (newEmailTextBox.Text.Trim() != null)
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserEmail(newEmailTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) 
                    newEmailTextBox.Text = "";
            }
        
        }

        protected void changeAddress()
        {
            if (newStreetAddressTextBox.Text.Trim() != null && newCityTextBox.Text.Trim() != null && DropDownList.Text != "Select a State" && newZipCodeTextBox.Text.Trim() != null)
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