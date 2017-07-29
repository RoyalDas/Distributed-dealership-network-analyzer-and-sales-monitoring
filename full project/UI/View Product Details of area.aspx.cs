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
    public partial class View_Product_Details : System.Web.UI.Page
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
        protected void areaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (areaDropDownList.SelectedIndex == 0)
            {
                ProductGridView.Visible = false;
            }
            else
            {
                ProductGridView.Visible = true;
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
                ProductGridView.DataSource = getdataSet("spproductdescription", parametersname);
                ProductGridView.DataBind();
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
    }
}