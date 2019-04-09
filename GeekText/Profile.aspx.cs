
using System;
using System.Configuration;
using System.Web.UI.WebControls;
using GeekTextLibrary;

namespace GeekText
{
    public partial class Profile : System.Web.UI.Page
    {
        UserManager userMan = new UserManager();
        User user = new User();

        // changed items
        bool changedNickName = false;
        bool changedFirstName = false;
        bool changedLastName = false;
        bool changedPassword = false;
        bool changedEmail = false;
        bool changedAddress = false;

        // user ID for changing credit cards and shipping address
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null && Session["UserPass"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["Username"] != null && Session["UserPass"] != null)
            {
                user = userMan.getUserInfo(Session["Username"].ToString().Trim(), Session["UserPass"].ToString().Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                userID = Convert.ToInt32(Session["UserID"]);
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
                currFirstNameLabel.Text = user.userFirstName;
                currLastNameLabel.Text = user.userLastName;
                currNickNameLabel.Text = user.userNickName;
                currEmailLabel.Text = user.eMailAddress;
                currCityLabel.Text = user.userCity;
                currStateLabel.Text = user.userState;
                currStreetAddressLabel.Text = user.userStreetAddress;
                currZipCodeLabel.Text = user.userZipCode;
            }

        }

        

        #region editing user profile information(does not include credit cards and shipping addresses) 

        protected void EditProfileBtn_Click(object sender, EventArgs e)
        {
            
            ProfilePanel.Visible = false;
            EditPanel.Visible = true;
            SuccessLabel.Text = "";
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

            currFirstNameLabel.Text = user.userFirstName;
            currLastNameLabel.Text = user.userLastName;
            currNickNameLabel.Text = user.userNickName;
            currEmailLabel.Text = user.eMailAddress;
            currCityLabel.Text = user.userCity;
            currStateLabel.Text = user.userState;
            currStreetAddressLabel.Text = user.userStreetAddress;
            currZipCodeLabel.Text = user.userZipCode;

            if (changedNickName || changedFirstName || changedLastName || changedPassword || changedEmail || changedAddress)
            {
                SuccessLabel.Text = "Changes Saved";
            }
            else
                SuccessLabel.Text = "No Changes Saved";
        }




        protected void changeNickName()
        {
            if (newNickNameTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserNickName(newNickNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                {
                    newNickNameTextBox.Text = "";
                    changedNickName = true;
                }
            }
        }

        protected void changeFirstName()
        {
            if (newFirstNameTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserFirstName(newFirstNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                {
                    newFirstNameTextBox.Text = "";
                    changedFirstName = true;
                }
            }
        }

        protected void changeLastName()
        {
            if (newLastNameTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserLastName(newLastNameTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString)) ;
                {
                    newLastNameTextBox.Text = "";
                    changedLastName = true;
                }
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
                    changedPassword = true;
                }
            }
        }

        protected void changeEmail()
        {
            if (newEmailTextBox.Text.Trim() != "")
            {
                // returns true if the changes are made on the SQL side
                if (userMan.changeUserEmail(newEmailTextBox.Text.Trim(), user.userID, ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString))
                {
                    newEmailTextBox.Text = "";
                    changedEmail = true;
                }
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
                    changedAddress = true;
                }
            }

        }

        protected void BackToProfile_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ProfilePanel.Visible = true;
        }
        #endregion

        #region showing credit cards and shipping addresses connected to user's profile

        protected void viewCreditCardBttn_Click(object sender, EventArgs e)
        {
            
            // see only credit cards
            CreditCardPanel.Visible = true;
            ProfilePanel.Visible = false;
        }

        protected void viewShipAddBttn_Click(object sender, EventArgs e)
        {
            ShippingPanel.Visible = true;
            ProfilePanel.Visible = false;
           
        }


        protected void backCardBttn_Click(object sender, EventArgs e)
        {
            // see only credit cards
            CreditCardPanel.Visible = false;
            ProfilePanel.Visible = true;
            savedCardLabel.Text = "";


        }

        protected void backAddBttn_Click(object sender, EventArgs e)
        {
            ShippingPanel.Visible = false;
            ProfilePanel.Visible = true;
            savedShipLabel.Text = "";
        }
        
        #endregion

        #region editing crecit cards and shipping addreses connected to user's profile

        

        protected void GridView3_RowUpdated(object sender, System.Web.UI.WebControls.GridViewUpdatedEventArgs e)
        {
            if (e.AffectedRows < 1)
            {
                e.KeepInEditMode = true;
                savedShipLabel.Text = "Row is not updated.";
                savedShipLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                savedShipLabel.Text = "Row updated successfully.";
                savedShipLabel.ForeColor = System.Drawing.Color.Navy;
            }
        }

        protected void ObjectDataSource1_Updated(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue is int && (int)e.ReturnValue > 0)
            {
                e.AffectedRows = (int)e.ReturnValue;
            }
        }

        protected void GridView4_RowUpdated(object sender, System.Web.UI.WebControls.GridViewUpdatedEventArgs e)
        {

            if (e.AffectedRows < 1)
            {
                e.KeepInEditMode = true;
                savedCardLabel.Text =  "Row is not updated.";
                savedCardLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                savedCardLabel.Text = "Row updated successfully.";
                savedCardLabel.ForeColor = System.Drawing.Color.Navy;
            }
        }

        protected void ObjectDataSource2_Updated(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue is int && (int)e.ReturnValue > 0)
            {
                e.AffectedRows = (int)e.ReturnValue;
            }
        }
        #endregion

        protected void GridView3_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            savedShipLabel.Text = "";
        }

        protected void GridView4_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            savedCardLabel.Text = "";
        }

    }
}