using System;
using System.Configuration;
using System.Web.UI.WebControls;
using GeekTextLibrary;

namespace GeekText
{

    public partial class SignUp : System.Web.UI.Page
    {
        UserManager user = new UserManager();
        bool dbSavedInfo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {   // if the database says there is a successfully saved then you can send to the user a message saying sign up was successful.
                dbSavedInfo = user.setUserCredentials(FirstNameTextBox.Text.Trim(), LastNameTextBox.Text.Trim(), NickNameTextBox.Text.Trim(), UserNameTextBox.Text.Trim(), PasswordTextBox1.Text.Trim(), EmailTextBox1.Text.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                // need to add password validations and email validations later on.
                if (dbSavedInfo)
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Successful sign up! Now login!" + "');", true);
            }
        }

        public void CheckUsernameClient(object source, ServerValidateEventArgs args)
        {
            // user.checkUsername returns true if found, if its found than it is not valid.
            //args.IsValid = !user.checkUsername(args.Value.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            args.IsValid = false;
        }

        public void CheckEmailClient(object source, ServerValidateEventArgs args)
        {
           
            // user.checkEmail returns true if found, if its found than it is not valid.
            //args.IsValid = !user.checkEmail(args.Value.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
           
            args.IsValid = false;
            
        }

        protected void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Page.Validate();
        }

        protected void EmailTextBox1_TextChanged(object sender, EventArgs e)
        {
            Page.Validate();
        }
    }
}