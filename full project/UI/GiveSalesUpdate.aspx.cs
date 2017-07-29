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
    public partial class GiveSalesUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void areaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (areaDropDownList.SelectedIndex == 0)
            {
                ProductGridView.Visible = false;
            }
            else
            {
                ProductGridView.Visible = true;
                ProductManager manager = new ProductManager();
                List<SqlParameter> parametersname = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@divisionname",
                    Value = divisionDropDownList.SelectedItem.Text 
                },
                new SqlParameter()
                {
                    ParameterName = "@districtname",
                    Value =zillaDropDownList.SelectedItem.Text
                },
                new SqlParameter()
                {
                    ParameterName = "@areaname",
                    Value =areaDropDownList.SelectedItem.Text
                }
            };
                List<Product> allProducts = manager.GetAllAreaProduct("spproductdescription", parametersname);
                ProductGridView.DataSource = allProducts;
                ProductGridView.DataBind();
            }
        }
        protected void ProductNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductNameDropDownList.SelectedIndex == 0)
            {
                valueTextBox.Text = String.Empty;
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
                    valueTextBox.Text = product.Price.ToString();

                }


            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Product nProduct = new Product();
                nProduct.ProductName = ProductNameDropDownList.SelectedItem.Text;
                nProduct.DivisionName = divisionDropDownList.SelectedItem.Text;
                nProduct.DistrictName = zillaDropDownList.SelectedItem.Text;
                nProduct.AreaName = areaDropDownList.SelectedItem.Text;
                nProduct.Available = Convert.ToInt32(QuantityTextBox.Text);
                nProduct.Price = Convert.ToInt32(valueTextBox.Text);
                SellingManager manager = new SellingManager();
                int nroweffected = manager.SalesRecord(nProduct);
                if (nroweffected > 0)
                {
                    ProductManager productmanager = new ProductManager();
                    List<Product> allProducts = productmanager.UpdateAreaProductInfo(nProduct);
                    ProductGridView.DataSource = allProducts;
                    ProductGridView.DataBind();
                    MessageLabel.Text = "Saved successfully";
                }
                else
                {
                    MessageLabel.Text = "saved Failed";
                }
            }
        }

    }
}