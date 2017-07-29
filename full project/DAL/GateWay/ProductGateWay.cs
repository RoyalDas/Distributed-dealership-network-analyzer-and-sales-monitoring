using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using full_project.DAL.Model;

namespace full_project.DAL.GateWay
{
    public class ProductGateWay
    {
        public Product GetProductInfo(string spselectimage, List<SqlParameter> parameters)
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata(spselectimage, parameters);
            Product ppProduct = null;
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                ppProduct = new Product();
                byte[] bytes = (byte[])dataSet.Tables[0].Rows[0]["imagedata"];
                string strbase64 = Convert.ToBase64String(bytes);
                ppProduct.ImageData = "data:Image/png;base64," + strbase64;
                ppProduct.ProductName = dataSet.Tables[0].Rows[0]["name"].ToString();
                ppProduct.Price = Convert.ToInt32(dataSet.Tables[0].Rows[0]["price"]);

            }
            return ppProduct;
        }

        public List<Product> GetAllProduct(string spname, List<SqlParameter> parameters)
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata(spname, null);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product = new Product();
                    product.ProductName = dr["name"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.Available = Convert.ToInt32(dr["available"]);
                    product.Id = Convert.ToInt32(dr["id"]);
                    products.Add(product);
                }
            }
            return products;
        }


        public int DistributeProducts(Product nProduct)
        {
            SaveAllData saveAllData = new SaveAllData();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@Name",
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
                    ParameterName ="@divisionName",
                    Value =nProduct.DivisionName
                },
                new SqlParameter()
                {
                    ParameterName ="@districtName",
                    Value =nProduct.DistrictName
                },
                new SqlParameter()
                {
                    ParameterName ="@areaname",
                    Value =nProduct.AreaName
                }
            };
            int roweffected = saveAllData.SaveData("spDistributedProduct", parameters);
            return roweffected;
        }

        public List<Product> UpdateProAndShow(Product nProduct)
        {
            GetDataSet getDataSet = new GetDataSet();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@ProductName",
                    Value =nProduct.ProductName
                },
                  new SqlParameter()
                {
                    ParameterName ="@quantity",
                    Value =nProduct.Available
                }
                
            };
            DataSet dataSet = getDataSet.GetAlldata("SpUpdateProductTbl", parameters);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product = new Product();
                    product.ProductName = dr["name"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.Available = Convert.ToInt32(dr["available"]);
                    products.Add(product);
                }
            }
            return products;
        }

        public List<Product> GetAllAreaProduct(string spproductdescription, List<SqlParameter> parametersname)
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata(spproductdescription, parametersname);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product = new Product();
                    product.ProductName = dr["name"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.Available = Convert.ToInt32(dr["available"]);
                    product.DivisionName = dr["divisionname"].ToString();
                    product.DistrictName = dr["districtname"].ToString();
                    product.AreaName = dr["areaname"].ToString();
                    products.Add(product);
                }
            }
            return products;
        }


        public List<Product> UpdateAreaProductInfo(Product nProduct)
        {

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@ProductName",
                    Value =nProduct.ProductName
                },
                  new SqlParameter()
                {
                    ParameterName ="@quantity",
                    Value =nProduct.Available
                },
                new SqlParameter()
                {
                    ParameterName ="@DivisionName",
                    Value =nProduct.DivisionName
                },
                new SqlParameter()
                {
                    ParameterName ="@districtname",
                    Value =nProduct.DistrictName
                },
                new SqlParameter()
                {
                    ParameterName ="@areaname",
                    Value =nProduct.AreaName
                }
            };
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata("spproductinfo", parameters);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product = new Product();
                    product.ProductName = dr["ProductName"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.Available = Convert.ToInt32(dr["quantity"]);
                    product.DivisionName = dr["divisionname"].ToString();
                    product.DistrictName = dr["districtname"].ToString();
                    product.AreaName = dr["areaname"].ToString();
                    products.Add(product);
                }
            }
            return products;
        }

        public int SaveNewProduct(Product product)
        {
            SelectSingleData data=new SelectSingleData();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@Name",
                    Value =product.ProductName
                },
                  new SqlParameter()
                {
                    ParameterName ="@imagedata",
                    Value =product.ImageDataBytes
                },
                new SqlParameter()
                {
                    ParameterName ="@Price",
                    Value =product.Price
                },
                new SqlParameter()
                {
                    ParameterName ="@quantity",
                    Value =product.Quantity
                }
            };
            int roweffected = data.SingleData("spInsertTblProduct", parameters);
            return roweffected;
        }

        public int AddProductToStock(Product nProduct)
        {
            SaveAllData saveAllData = new SaveAllData();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@Name",
                    Value =nProduct.ProductName
                },
                  new SqlParameter()
                {
                    ParameterName ="@quantity",
                    Value =nProduct.Quantity
                }
            };
            int roweffected = saveAllData.SaveData("AddNewExistingProduct", parameters);
            return roweffected;
        }


        public List<Product> GetAllRecordByProductName(Product product)
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
                }
            };
            DataSet dataSet = getDataSet.GetAlldata("TodaysfixedProductSalesRecordbyArea", parameters);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                if (dataSet.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        Product nproduct = new Product();
                        nproduct.ProductName = dr["Product"].ToString();
                        nproduct.Price = Convert.ToInt32(dr["price"]);
                        nproduct.Quantity = Convert.ToInt32(dr["quantity"]);
                        nproduct.DivisionName = dr["divisionname"].ToString();
                        nproduct.DistrictName = dr["districtname"].ToString();
                        nproduct.AreaName = dr["areaname"].ToString();
                        products.Add(nproduct);
                    }
                }
            }
            return products;
        }

        public List<Product> CompanyStockCenter()
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata("SpCompanyStockCenter", null);
            List<Product> products = new List<Product>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Product product = new Product();
                    byte[] bytes = (byte[])dr["imagedata"];
                    string strbase64 = Convert.ToBase64String(bytes);
                    product.ImageData = "data:Image/png;base64," + strbase64;
                    product.ProductName = dr["name"].ToString();
                    product.Price = Convert.ToInt32(dr["price"]);
                    product.Available = Convert.ToInt32(dr["available"]);
                    products.Add(product);
                }
            }
            return products;
        }
    }
}