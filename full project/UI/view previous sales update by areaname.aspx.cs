using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class view_previous_sales_update_by_areaname : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionControl();
            if (!IsPostBack)
            {

                AddressManager addressManager = new AddressManager();
                List<Address> addresses = addressManager.GetDivision();
                divisionDropDownList.DataSource = addresses;
                divisionDropDownList.DataTextField = "DivisionName";
                divisionDropDownList.DataValueField = "Id";
                divisionDropDownList.DataBind();
                ListItem listItem = new ListItem("select division", "-1");
                divisionDropDownList.Items.Insert(0, listItem);
                ListItem zillalistItem = new ListItem("select zilla", "-1");
                zillaDropDownList.Items.Insert(0, zillalistItem);
                ListItem arealistItem = new ListItem("select area", "-1");
                areaDropDownList.Items.Insert(0, arealistItem);
                zillaDropDownList.Enabled = false;
                areaDropDownList.Enabled = false;
                ProductManager manager = new ProductManager();
                ProductNameDropDownList.DataSource = manager.GetAllProduct("spproductdetails", null);
                ProductNameDropDownList.DataTextField = "ProductName";
                ProductNameDropDownList.DataValueField = "Id";
                ProductNameDropDownList.DataBind();
                ListItem productlistItem = new ListItem("select Product", "-1");
                ProductNameDropDownList.Items.Insert(0, productlistItem);
                ImageDiv.Visible = false;
            }
        }

        private void SessionControl()
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void divisionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (divisionDropDownList.SelectedIndex == 0)
            {
                zillaDropDownList.SelectedIndex = 0;
                zillaDropDownList.Enabled = false;
                areaDropDownList.SelectedIndex = 0;
                areaDropDownList.Enabled = false;
            }
            else
            {
                zillaDropDownList.Enabled = true;

                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@DivisionID",
                    Value = divisionDropDownList.SelectedItem.Text
                }
            };
                AddressManager addressManager = new AddressManager();
                List<Address> addresses = addressManager.GetAllDistrict("spzillabydivisionid", parameters);
                zillaDropDownList.DataSource = addresses;
                zillaDropDownList.DataTextField = "DistrictName";
                zillaDropDownList.DataValueField = "Id";
                zillaDropDownList.DataBind();
                ListItem zillalistItem = new ListItem("select zilla", "-1");
                zillaDropDownList.Items.Insert(0, zillalistItem);
                areaDropDownList.SelectedIndex = 0;
                areaDropDownList.Enabled = false;
            }
        }
        protected void zillaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zillaDropDownList.SelectedIndex == 0)
            {
                areaDropDownList.SelectedIndex = 0;
                areaDropDownList.Enabled = false;

            }
            else
            {
                areaDropDownList.Enabled = true;
                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@zillaid",
                    Value = zillaDropDownList.SelectedItem.Text
                }
            };
                AddressManager addressManager = new AddressManager();
                List<Address> addresses = addressManager.GetAllArea("spareabyzillaId", parameters);
                areaDropDownList.DataSource = addresses;
                areaDropDownList.DataTextField = "Areaname";
                areaDropDownList.DataValueField = "Id";
                areaDropDownList.DataBind();
                ListItem arealistItem = new ListItem("select area", "-1");
                areaDropDownList.Items.Insert(0, arealistItem);

            }
        }

        protected void ProductNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductNameDropDownList.SelectedIndex == 0)
            {
                Image1.Visible = false;
                ProducNamelabel.Visible = false;
                ImageDiv.Visible = false;
            }
            else
            {
                ProductManager productManager = new ProductManager();
                List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@id",
                    Value = ProductNameDropDownList.SelectedItem.Value
                }
            };
                Product product = productManager.GetProductInfo("spselectimage", parameters);

                if (product != null)
                {
                    ImageDiv.Visible = true;
                    Image1.Visible = true;
                    Image1.ImageUrl = product.ImageData;
                    ProducNamelabel.Visible = true;
                    ProducNamelabel.Text = product.ProductName;
                    ProducNamelabel.ForeColor = Color.Green;


                }


            }
        }
        protected void ViewButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Product product = new Product();
                product.ProductName = ProductNameDropDownList.SelectedItem.Text;
                product.DivisionName = divisionDropDownList.SelectedItem.Text;
                product.DistrictName = zillaDropDownList.SelectedItem.Text;
                product.AreaName = areaDropDownList.SelectedItem.Text;
                string date = DateTextBox.Text;
                List<Product> products = SellingManager.GetPreviousSalesRecordOfArea(product, date);
                if (products.Count != 0)
                {
                    ProductGridView.Visible = true;
                    ProductGridView.DataSource = products;
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