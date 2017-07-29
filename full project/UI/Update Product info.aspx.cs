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
    public partial class Update_Product_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessioControl();
            if (!IsPostBack)
            {
                ProductManager manager = new ProductManager();
                ProductDropDownList.DataSource = manager.GetAllProduct("spproductdetails", null);
                ProductDropDownList.DataTextField = "ProductName";
                ProductDropDownList.DataValueField = "Id";
                ProductDropDownList.DataBind();
                ListItem productlistItem = new ListItem("select Product", "-1");
                ProductDropDownList.Items.Insert(0, productlistItem);
                ImageDiv.Visible = false;
            }
        }

        private void SessioControl()
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


       
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string productname = ProductDropDownList.SelectedItem.Text;
            int price = Convert.ToInt32(UpadtePriceTextBox.Text);
            string connectionsting = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionsting);
            SqlCommand command = new SqlCommand("SpUpdateProductInfo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ProductName", productname);
            command.Parameters.AddWithValue("@Price", price);
            connection.Open();
            int roweffected = command.ExecuteNonQuery();
            if (roweffected > 0)
            {
                messagelabel.Text = "Updated successfully";
            }
            else
            {
                messagelabel.Text = "Update failed";
            }
        }

        protected void ProductDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductDropDownList.SelectedIndex == 0)
            {
                PreviousPriceTextBox.Text = String.Empty;
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
                    Value = ProductDropDownList.SelectedItem.Value
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
                    PreviousPriceTextBox.Text = product.Price.ToString();

                }


            }
        }

       
    }
}