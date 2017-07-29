using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace full_project.UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           SessionControl();
        }

        private void SessionControl()
        {
            if (Session["UserName"]== null)
            {
                HttpCookie cookie = Request.Cookies["Login"];
                if (cookie != null)
                {
                    Session["UserName"] = cookie["UserName"];
                    Session["RoleId"] = cookie["RoleId"];
                }
                else
                {
                    Response.Redirect("LogIn.aspx");
                }
            }
           
        }
    }
}