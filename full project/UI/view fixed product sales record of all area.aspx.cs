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
    public partial class view_fixed_product_sales_record_of_all_area : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            if (!IsPostBack)
            {
                ProductManager manager = new ProductManager();
                ProductNameDropDownList.DataSource = manager.GetAllProduct("spproductdetails", null);
                ProductNameDropDownList.DataTextField = "ProductName";
                ProductNameDropDownList.DataValueField = "Id";
                ProductNameDropDownList.DataBind();
                ListItem productlistItem = new ListItem("select Product", "-1");
                ProductNameDropDownList.Items.Insert(0, productlistItem);
            }

        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        private DataSet getdataSet(string spname, List<SqlParameter> parameter)
        {
            string connectionsting = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionsting);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(spname, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parameter != null)
            {
                foreach (SqlParameter nparameter in parameter)
                {
                    dataAdapter.SelectCommand.Parameters.Add(nparameter);
                }
            }

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Name = ProductNameDropDownList.SelectedItem.Text;
            List<Product> products = SellingManager.GetFixedProductOfAllArea(product.Name);
            if (products.Count != 0)
            {
                fixedproductGridView.Visible = true;
                fixedproductGridView.DataSource = products;
                fixedproductGridView.DataBind();
                messagelabel.Text = String.Empty;
            }
            else
            {
                fixedproductGridView.Visible = false;
                messagelabel.Text = "No sales record found";
            }

        }
    }
}