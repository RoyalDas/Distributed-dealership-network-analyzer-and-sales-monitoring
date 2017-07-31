using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                person.UserName = UsernameTextBox.Text;
                PersonManager manager = new PersonManager();
                Guid uniqueId;
                int returncode = 0;
                Person nPerson = manager.IsUserNameExist(person.UserName, out uniqueId, out returncode);
                if (Convert.ToBoolean(returncode))
                {
                    SendPasswordResetMail(nPerson.Email, nPerson.UserName, uniqueId.ToString());
                    messageLabel.Text = "An Email With instruction is send to your email";
                }
                else
                {
                    messageLabel.ForeColor = System.Drawing.Color.Red;
                    messageLabel.Text = "username is not valid";
                }
            }
           
            }
        private void SendPasswordResetMail(string toemail, string username, string uniqueid)
        {
            MailMessage mailMessage = new MailMessage("your email", toemail);
            StringBuilder sbemailbody = new StringBuilder();
            sbemailbody.Append("Dear-" + username + ",<br/><br/>");
            sbemailbody.Append("Plese click on the following link to reset Password ");
            sbemailbody.Append("http://localhost:7888/UI/ChangePassword.aspx?uid=" + uniqueid);
            sbemailbody.Append("<br/><BR/>");
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = sbemailbody.ToString();
            mailMessage.Subject = "Reset your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "royalnstu@gmail.com",
                Password = "password"

            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}