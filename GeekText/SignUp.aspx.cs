using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekTextLibrary;

namespace GeekText
{

    public partial class SignUp : System.Web.UI.Page
    {
        UserManager userMan = new UserManager();
        bool dbSavedPersonalInfo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {   // if the database says there is a successfully saved then you can send to the user a message saying sign up was successful.
                dbSavedPersonalInfo = userMan.setUserCredentials(FirstNameTextBox.Text.Trim(), LastNameTextBox.Text.Trim(), NickNameTextBox.Text.Trim(), UserNameTextBox.Text.Trim(), PasswordTextBox1.Text.Trim(), EmailTextBox1.Text.Trim(), CityTextBox.Text.Trim(), DropDownList.Text.Trim(), ZipTextBox.Text.Trim(), StreetAddressTextBox.Text.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                
                // need to add password validations and email validations later on.
                if (dbSavedPersonalInfo)
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Successful sign up! Now login!" + "');", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Successful sign up! Now login!" + "');", true);
            }
        }

        public void CheckUsernameClient(object source, ServerValidateEventArgs args)
        {
            // userMan.checkUsername returns true if found, if its found than it is not valid.
            args.IsValid = !userMan.checkUsername(args.Value.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
        }

        public void CheckEmailClient(object source, ServerValidateEventArgs args)
        {
            // userMan.checkEmail returns true if found, if its found than it is not valid.
            args.IsValid = !userMan.checkEmail(args.Value.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
        }

    }
}