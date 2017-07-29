using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UserNameTextBox.Text = Request.Cookies["UserName"].Value;
                    PasswordTextBox.Attributes["value"] = Request.Cookies["Password"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            PersonManager aPersonManager = new PersonManager();
            Person nPerson = new Person();
            nPerson.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordTextBox.Text, "SHA1");
            nPerson.UserName = UserNameTextBox.Text;
            Person aPerson = aPersonManager.GetData(nPerson);
            switch (aPerson.Id)
            {
                case -1:
                    MessageLabel.Text = "Username and/or password is incorrect.";
                    break;
                case -2:
                    MessageLabel.Text = "Account has not been activated.";
                    break;
                default:
                    if (CheckBox1.Checked)
                    {
                        HttpCookie myCookie=new HttpCookie("Login");
                        myCookie["UserName"] = UserNameTextBox.Text;
                        myCookie["Password"] = PasswordTextBox.Text;
                        myCookie["RoleId"] = aPerson.RoleId.ToString();
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1); 
                        //Session.Remove("UserName");
                        //HttpCookie myCookie = new HttpCookie("Login");
                        //myCookie.Expires = DateTime.Now.AddDays(-30d);
                        //Response.Cookies.Add(myCookie);
                        //Response.Cookies["UserName"].Value = null;
                        //Response.Cookies["Password"].Value = null;
                    }
                   
                    Session["UserName"] = UserNameTextBox.Text;
                    Session["RoleId"] = aPerson.RoleId;
                    Response.Redirect("Home.aspx");
                    break;
            }
           
            
        }


    }
}