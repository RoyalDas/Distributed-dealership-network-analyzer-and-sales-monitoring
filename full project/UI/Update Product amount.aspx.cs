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
    public partial class Update_Product_amount : System.Web.UI.Page
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
                Image1.Visible = false;
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

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Product nProduct = new Product();
                nProduct.ProductName = ProductNameDropDownList.SelectedItem.Text;
                nProduct.Quantity = Convert.ToInt32(QuantityTextbox.Text);
                ProductManager manager = new ProductManager();
                string message = manager.AddProductToStock(nProduct);
                MessageLabel.Text = message;
            }

        }


        protected void ProductNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductNameDropDownList.SelectedIndex == 0)
            {
                ImageDiv.Visible = false;
                Image1.Visible = false;
                ProducNamelabel.Visible = false;
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

    }
}