using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace full_project.UI
{
    public partial class Log_Out : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            HttpCookie myCookie = new HttpCookie("Login");
            myCookie.Expires = DateTime.Now.AddDays(-30d);
            Response.Cookies.Add(myCookie);

            Response.Redirect("LogIn.aspx");
        }
    }
}