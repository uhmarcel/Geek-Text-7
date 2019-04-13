using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeekTextLibrary;
using System.Security.Cryptography;
using System.Text;

namespace GeekText
{

    public partial class SignUp : System.Web.UI.Page
    {
        private UserManager userMan = new UserManager();
        private bool dbSavedPersonalInfo;
        private string hashedPassword;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                hashedPassword = GetSwcSHA1(PasswordTextBox1.Text.Trim());
               // if the database says there is a successfully saved then you can send to the user a message saying sign up was successful.
                dbSavedPersonalInfo = userMan.setUserCredentials(FirstNameTextBox.Text.Trim(), LastNameTextBox.Text.Trim(), NickNameTextBox.Text.Trim(), UserNameTextBox.Text.Trim(), hashedPassword, EmailTextBox1.Text.Trim(), CityTextBox.Text.Trim(), DropDownList.Text.Trim(), ZipTextBox.Text.Trim(), StreetAddressTextBox.Text.Trim(), ConfigurationManager.ConnectionStrings["GeekTextConnection"].ConnectionString);
                
                // need to add password validations and email validations later on.
                if (dbSavedPersonalInfo)
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Successful sign up! Now login!" + "');", true);

                Response.Redirect("Profile.aspx");
            }
        }

        // hashing for password
        public static string GetSwcSHA1(string value)
        {
            SHA256 algorithm = SHA256.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
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