using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class view_Todays_all__salesrecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            Product product = new Product();
            int totalsum;
            List<Product> products = SellingManager.TodaysRalesRecord(out totalsum);
            if (products.Count != 0)
            {
                ViewAllSalesRecordGridView.Visible = true;
                ViewAllSalesRecordGridView.DataSource = products;
                ViewAllSalesRecordGridView.DataBind();
                messagelabel.Text = messagelabel.Text = "total sold:" + totalsum + "Taka";
            }
            else
            {
                ViewAllSalesRecordGridView.Visible = false;
                messagelabel.Text = "No sales record found";
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }


        protected void ViewAllSalesRecordGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Product product = new Product();
            int totalsum;
            List<Product> products = SellingManager.TodaysRalesRecord(out totalsum);
            if (products.Count != 0)
            {
                ViewAllSalesRecordGridView.Visible = true;
                ViewAllSalesRecordGridView.DataSource = products;
                ViewAllSalesRecordGridView.DataBind();
                messagelabel.Text = messagelabel.Text = "total sold:" + totalsum + "Taka";
            }
            else
            {
                ViewAllSalesRecordGridView.Visible = false;
                messagelabel.Text = "No sales record found";
            }
        }
    }
}