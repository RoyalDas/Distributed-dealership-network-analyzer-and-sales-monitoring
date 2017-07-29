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
    public partial class View_Company_Stock_Center : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            ProductManager manager=new ProductManager();
            List<Product> products = manager.CompanyStockCenter();
            if (products.Count != 0)
            {
                ProductGridview.Visible = true;
                ProductGridview.DataSource = products;
                ProductGridview.DataBind();
                messagelabel.Text = String.Empty;
            }
            else
            {
                ProductGridview.Visible = false;
                messagelabel.Text = "No  record found";
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}