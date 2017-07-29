using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using full_project.DAL.Model;

namespace full_project.DAL.GateWay
{
    public class SellingGateWay
    {
        public int SalesRecord(Product nProduct)
        {
            SaveAllData saveAllData=new SaveAllData();
              List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@proname",
                    Value =nProduct.ProductName
                },
                  new SqlParameter()
                {
                    ParameterName ="@quantity",
                    Value =nProduct.Available
                },
                new SqlParameter()
                {
                    ParameterName = "@Price",
                    Value =nProduct.Price
                },
                new SqlParameter()
                {
                    ParameterName ="@divisionname",
                    Value =nProduct.DivisionName
                },
                new SqlParameter()
                {
                    ParameterName ="@districname",
                    Value =nProduct.DistrictName
                },
                new SqlParameter()
                {
                    ParameterName ="@area",
                    Value =nProduct.AreaName
                }
            };
            int roweffected=saveAllData.SaveData("spinsertsalesinfm", parameters);
            return roweffected;
        }

        public List<Product> GetFixedProductOfAllArea(string name)
        {
            GetDataSet getDataSet = new GetDataSet();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                 new SqlParameter()
                {
                    ParameterName ="@productname",
                    Value =name
                }
            };
            DataSet dataSet = getDataSet.GetAlldata("fixedProductSalesRecord", parameters);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product = new Product();
                    product.ProductName = dr["Product"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.Quantity = Convert.ToInt32(dr["quantity"]);
                    product.DivisionName = dr["divisionname"].ToString();
                    product.DistrictName = dr["districtname"].ToString();
                    product.AreaName = dr["areaname"].ToString();
                    products.Add(product);
                }
            }
            return products;
        }

        public List<Product> GetPreviousSalesRecordOfArea(Product product, string date)
        {
            GetDataSet getDataSet = new GetDataSet();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                  new SqlParameter()
                {
                    ParameterName ="@proname",
                    Value =product.ProductName
                },              
                new SqlParameter()
                {
                    ParameterName ="@divisionname",
                    Value =product.DivisionName
                },
                new SqlParameter()
                {
                    ParameterName ="@districname",
                    Value =product.DistrictName
                },
                new SqlParameter()
                {
                    ParameterName ="@area",
                    Value =product.AreaName
                },
                  new SqlParameter()
                {
                    ParameterName ="@date",
                    Value =date
                }
            };
            DataSet dataSet = getDataSet.GetAlldata("fixedproductSalesRecordbyArea", parameters);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product nProduct = new Product();
                    nProduct.ProductName = dr["Product"].ToString();
                    nProduct.Price = Convert.ToInt32(dr["price"]);
                    nProduct.Quantity = Convert.ToInt32(dr["quantity"]);
                    nProduct.DivisionName = dr["divisionname"].ToString();
                    nProduct.DistrictName = dr["districtname"].ToString();
                    nProduct.AreaName = dr["areaname"].ToString();
                    products.Add(nProduct);
                }
            }
            return products; 
        }

        public List<AllRecordwithDate> SalesRecordWithinTimeLimit(AllRecordwithDate date)
        {
            GetDataSet getDataSet = new GetDataSet();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                  new SqlParameter()
                {
                    ParameterName ="@startdate",
                    Value =date.StartDate
                },              
                new SqlParameter()
                {
                    ParameterName ="@endadte", 
                    Value =date.EndDate
                }
            };
            DataSet dataSet = getDataSet.GetAlldata("spSalesRecordWithinTimeLimit", parameters);
            List<AllRecordwithDate> allRecordwithDates=new List<AllRecordwithDate>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    AllRecordwithDate allRecordwithDate=new AllRecordwithDate();
                    allRecordwithDate.SpecificDate = dr["Date"].ToString();
                    allRecordwithDate.ProductName = dr["Product"].ToString();
                    allRecordwithDate.Price = Convert.ToInt32(dr["price"]);
                    allRecordwithDate.Quantity = Convert.ToInt32(dr["quantity"]);
                    allRecordwithDate.DivisionName = dr["divisionname"].ToString();
                    allRecordwithDate.DistrictName = dr["districtname"].ToString();
                    allRecordwithDate.AreaName = dr["areaname"].ToString();
                    allRecordwithDates.Add(allRecordwithDate);
                }
            }
            return allRecordwithDates;
        }

        public List<Product> TodaysRalesRecord(out int totalsum)
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata("todaysalesupdate",null);
            List<Product> products = new List<Product>();
            int sum = 0;
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product=new Product();
                    product.ProductName = dr["Product"].ToString();
                    product.Quantity= Convert.ToInt32(dr["quantity"]);
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.DivisionName = dr["divisionname"].ToString();
                    product.DistrictName = dr["districtname"].ToString();
                    product.AreaName = dr["areaname"].ToString();
                    products.Add(product);
                    sum = sum + product.Price;
                }
            }
            totalsum = sum;
            return products;

        }
    }
}