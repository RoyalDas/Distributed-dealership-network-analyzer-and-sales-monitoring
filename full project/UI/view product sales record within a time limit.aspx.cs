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
    public partial class view_product_sales_record_within_a_time_limit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void SearchButoon_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AllRecordwithDate date = new AllRecordwithDate();
                date.StartDate = StartTextBox.Text;
                date.EndDate = EndTextBox.Text;
                SellingManager sellingManager = new SellingManager();
                List<AllRecordwithDate> allRecordwithDates = sellingManager.SalesRecordWithinTimeLimit(date);

                ProductGridView.DataSource = allRecordwithDates;
                ProductGridView.DataBind();
                if (allRecordwithDates.Count != 0)
                {
                    ProductGridView.Visible = true;
                    ProductGridView.DataSource = allRecordwithDates;
                    ProductGridView.DataBind();
                    messagelabel.Text = String.Empty;
                }
                else
                {
                    ProductGridView.Visible = false;
                    messagelabel.Text = "No sales record found";
                }
            }


        }
    }
}