using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using full_project.BBL;
using full_project.DAL.Model;

namespace full_project.UI
{
    public partial class Insert_New_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       

        protected void SaveButoon_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = ProductFileUpload.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileextension = Path.GetExtension(filename);
            int filesize = postedFile.ContentLength;
            if (fileextension.ToLower() == ".jpg" || fileextension.ToLower() == ".bmp" ||
                fileextension.ToLower() == "png" || fileextension.ToLower() == ".gif")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                Product product = new Product();
                product.ImageDataBytes = binaryReader.ReadBytes((int)stream.Length);
                product.ProductName = NameTextBox.Text;
                product.Price = Convert.ToInt32(PriceTextBox.Text);
                product.Quantity = Convert.ToInt32(QuantityTextBox.Text);
                ProductManager manager = new ProductManager();
                int roweffected = manager.SaveNewProduct(product);
                switch (roweffected)
                {
                    case  1:
                        Messagelabel.Text = "Saved Successfully";
                        break;
                    case 0:
                        Messagelabel.Text = "Product already exists";
                        break;
                }

            }
            else
            {
                Messagelabel.Text = "only .jpg,.bmp,.png,.gif files can be uploaded";
            }
        }
    }
}