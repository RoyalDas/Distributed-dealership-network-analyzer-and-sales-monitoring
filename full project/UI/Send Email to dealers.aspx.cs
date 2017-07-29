using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class Send_Email_to_dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            string str = CKEditor1.Text;
            string str1 = Server.HtmlEncode(str);
            string str2 = Server.HtmlDecode(str);
            string txt = CKEditor1.Text;
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Text = "<html><body>" + CKEditor1.Text + "</body></html>";
            string DownPath = @"c:\Files";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(DownPath + @"\" + "Filename" + ".Doc"))
            {
                file.Write(Text);
            }
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("spemail", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Address address = new Address();
                address.Name = reader["UserName"].ToString();
                address.Email = reader["Email"].ToString();
                string emailname = address.Email;
                string name = address.Name;
                Sendmail(emailname, name, Text);
            }

        }

        protected void Sendmail(string emailname, string name, string txt)
        {
            string email = null;
            string password = null;
            GetAdminEmailAndPassword(out email,out password);
            MailMessage message = new MailMessage(email, emailname);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Dear " + "" + name + ",<br/><br/>");
            stringBuilder.Append(txt + "<br/><br/>");
            message.IsBodyHtml = true;
            message.Subject = "newMessage";
            message.Body = stringBuilder.ToString();
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName =email,
                Password = password
            };
            if (CheckForInternetConnection())
            {
                client.Send(message);
                Messagelabel.Text = "Message send successfully";
            }
            else
            {
                Messagelabel.Text = "Network is not available";
            }

        }

        private void GetAdminEmailAndPassword(out string email,out string password)
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
                 person=new Person();
                person.Email = reader["Email"].ToString();
                person.PassWord = reader["Password"].ToString();
            }
            email = person.Email;
            password = person.PassWord;
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