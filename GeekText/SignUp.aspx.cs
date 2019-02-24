using System;
using System.Configuration;
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
            // if the database says there is a successfully saved then you can send to the user a message saying sign up was successful.
            dbSavedInfo = user.setUserCredentials(FirstNameTextBox.Text.Trim(), LastNameTextBox.Text.Trim(), NickNameTextBox.Text.Trim(), UserNameTextBox.Text.Trim(), PasswordTextBox1.Text.Trim(),EmailTextBox1.Text.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
            // need to add password validations and email validations later on.
            if (dbSavedInfo)
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Successful sign up! Now login!" + "');", true);
        }
    }
}