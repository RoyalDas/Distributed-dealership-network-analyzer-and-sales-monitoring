using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class Change_Password_manually : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Person person = new Person();
                person.UserName = UserNameTextBox.Text;
                person.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(CurrentPasswordTextBox.Text, "SHA1");
                person.Email = EmailTxtBox.Text;
                person.NewPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPasswordTextBox.Text, "SHA1");
                person.ConfirmPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(
                    ConfirmPasswordTextBox.Text, "SHA1");
                PersonManager manager = new PersonManager();
                string message = PersonManager.Changepassword(person);
                MessageLabel.Text = message;
            }
        }
    }
}