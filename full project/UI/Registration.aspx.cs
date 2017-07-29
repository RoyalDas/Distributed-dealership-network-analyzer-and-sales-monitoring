using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SessionContro();
        }

        private void SessionContro()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnection())
            {
                Person person = new Person();
                person.UserName = UserNameTextBox.Text;
                person.Email = EmailTextBox.Text;
                person.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordTextBox.Text, "SHA1");
                person.ContactNo = ContactNoTextBox.Text;
                person.DivisionName = DivisionNameTextBox.Text;
                person.DistrictName = DistrictNameTextBox.Text;
                person.AreaName = AreaNameTextBox.Text;
                PersonManager manager = new PersonManager();
                int userId = manager.Registration(person);
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        MessageLabel.ForeColor = Color.Red;
                        MessageLabel.Text = "Username already exists.Please choose a different username.";
                        break;
                    case -2:
                        MessageLabel.ForeColor = Color.Red;
                        MessageLabel.Text = "Supplied email address has already been used.";
                        break;
                    default:
                        MessageLabel.ForeColor = Color.Green;
                        MessageLabel.Text = "Please check your email to activate your account.";
                        SendActivationEmail(userId);
                        break;
                }
                
            }
            else
            {
                MessageLabel.Text = "Network is not available";
            }

        }
        private void SendActivationEmail(int userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            string email = null;
            string password = null;
            GetAdminEmailAndPassword(out email, out password);
            using (MailMessage mm = new MailMessage(email,EmailTextBox.Text))
            {
                mm.Subject = "Account Activation";
                 
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dear " + "" + UserNameTextBox.Text + ",<br/><br/>");
            stringBuilder.Append("click on the following link to verify your email" + "<br/><br/>");
            stringBuilder.Append("http://localhost:7888/UI/Welcome.aspx?ActivationCode=" + activationCode);
            mm.IsBodyHtml = true;
            mm.Subject = "Verify Email";
            mm.Body = stringBuilder.ToString();
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = email,
                Password = password
            };
            client.Send(mm);

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
        private void GetAdminEmailAndPassword(out string email, out string password)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("SpAdminEmailAndPassword", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Person person = null;
            if (reader.HasRows)
            {
                reader.Read();
                person = new Person();
                person.Email = reader["Email"].ToString();
                person.PassWord = reader["Password"].ToString();
            }
            email = person.Email;
            password = person.PassWord;
        }
    }
}