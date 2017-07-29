using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class View_dealers_information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            if (!IsPostBack)
            {
                AddressManager manager = new AddressManager();
                List<Address> addresses = manager.GetDealerinfos();
                DealersinfoGridView.DataSource = addresses;
                DealersinfoGridView.DataBind();
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void DealersinfoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AddressManager manager = new AddressManager();
            DealersinfoGridView.PageIndex = e.NewPageIndex;
            DealersinfoGridView.DataSource = manager.GetDealerinfos();
            DealersinfoGridView.DataBind();
        }
    }
}