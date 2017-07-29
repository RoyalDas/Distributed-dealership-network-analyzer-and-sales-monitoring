using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using full_project.DAL.GateWay;
using full_project.DAL.Model;

namespace full_project.BBL
{
    public class ProductManager
    {
        ProductGateWay productGateWay = new ProductGateWay();
        public Product GetProductInfo(string spselectimage, List<SqlParameter> parameters)
        {
            return productGateWay.GetProductInfo(spselectimage, parameters);
        }


        public List<Product> GetAllProduct(string spname, List<SqlParameter> parameters)
        {
            return productGateWay.GetAllProduct(spname,parameters);
        }

        public int DistributeProducts(Product nProduct)
        {
            int roweffected = productGateWay.DistributeProducts(nProduct);
            return roweffected;
        }

        public List<Product> UpdateProAndShow(Product nProduct)
        {
            
            return productGateWay.UpdateProAndShow(nProduct);
        }

        public List<Product> GetAllAreaProduct(string spproductdescription, List<SqlParameter> parametersname)
        {
           
            return productGateWay.GetAllAreaProduct(spproductdescription, parametersname);
        }

        public List<Product> UpdateAreaProductInfo(Product nProduct)
        {
            return productGateWay.UpdateAreaProductInfo(nProduct);
        }

        public int SaveNewProduct(Product product)
        {
            int roweffected = productGateWay.SaveNewProduct(product);
            return roweffected;

        }

        public string AddProductToStock(Product nProduct)
        {
            int roweffected = productGateWay.AddProductToStock(nProduct);
            if (roweffected > 0)
            {
                return "Saved Successfully";
            }
            else
            {
                return "Saved Failed";
            }
        }

        public List<Product> GetAllRecordByProductName(Product product)
        {
            return productGateWay.GetAllRecordByProductName(product);
        }

        public List<Product> CompanyStockCenter()
        {

            return productGateWay.CompanyStockCenter();
        }
    }
}