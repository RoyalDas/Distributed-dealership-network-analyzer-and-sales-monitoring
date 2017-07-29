using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class ChangePassword : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string guidValue = Request.QueryString["uid"];
            if (guidValue != null)
            {
                PersonManager manager = new PersonManager();
                int userid = manager.IslinkValid(guidValue);
                if (!IsPostBack)
                {
                    if (userid != 0)
                    {
                        Label1.Visible = true;
                        Label2.Visible = true;
                        NewPasswordTextBox.Visible = true;
                        ConfirmTextBox.Visible = true;
                        ChangePasswordButton.Visible = true;
                    }
                    else
                    {
                        Messagelabel.Text = "password reset link was exired or invalid";
                    }
                }
            }
            else
            {
                Response.Redirect("ResetPassword.aspx");
            }

        }
        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Person person = new Person();
                person.NewPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPasswordTextBox.Text, "SHA1");
                string guidValue = Request.QueryString["uid"];
                PersonManager manager = new PersonManager();
                int returncode = manager.ResetPassWord(person, guidValue);
                if (Convert.ToBoolean(returncode))
                {
                    Messagelabel.Text = "Password Changed successfully";
                }
                else
                {
                    Messagelabel.ForeColor = System.Drawing.Color.Red;
                    Messagelabel.Text = "username is not valid";
                }
            }
        }

    }
}