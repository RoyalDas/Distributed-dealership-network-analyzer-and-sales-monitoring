using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Person person = new Person();
                person.Email = EmailTextBox.Text;
                PersonManager manager = new PersonManager();
                Guid uniqueId;
                int returncode = 0;
                Person nPerson = manager.IsUserNameExist(person.Email, out uniqueId, out returncode);
                if (Convert.ToBoolean(returncode))
                {
                    if (CheckForInternetConnection())
                    {
                        SendPasswordResetMail(nPerson.Email, nPerson.UserName, uniqueId.ToString());
                        messageLabel.Text = "An Email With instruction is send to your email";
                    }
                    else
                    {
                        messageLabel.Text = "Network connection is not available";
                    }
                   
                }
                else
                {
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    messageLabel.Text = "Email is not valid";
                }
            }

        }
        private void SendPasswordResetMail(string toemail, string username, string uniqueid)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress("royalnstu@gmail.com");
                m.To.Add(toemail);
                m.Subject = "Reset your Password";
                m.IsBodyHtml = true;
                m.Body = "Dear-" + username + ",<br/><br/>" + "Plese click on the following link to reset Password " + "<br/><br/>" + "http://localhost:7888/UI/ChangePassword.aspx?uid=" + uniqueid + "<br/><BR/>";
                sc.Host = "smtp.gmail.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("royalnstu@gmail.com", "4796880178210");

                sc.EnableSsl = true;
                sc.Send(m);
                Response.Write("Email Send successfully");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            
            
           
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}