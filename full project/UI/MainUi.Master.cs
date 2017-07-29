using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace full_project.UI
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void SessionControl()
        {
            string name = Session["UserName"].ToString();
            int roleId = Convert.ToInt32(Session["RoleId"]);
            MymenuControl(roleId);
        }

        private void MymenuControl(int roleId)
        {
            if (roleId == 2)
            {
                AdminActivityLi.Visible = false;
            }
        }
    }
}