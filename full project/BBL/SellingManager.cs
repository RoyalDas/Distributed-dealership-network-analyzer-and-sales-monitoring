using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using full_project.DAL.GateWay;
using full_project.DAL.Model;

namespace full_project.BBL
{
    public class SellingManager
    {
        public int SalesRecord(Product nProduct)
        {
            SellingGateWay gateWay=new SellingGateWay();
            return gateWay.SalesRecord(nProduct);
        }

        public static List<Product> GetFixedProductOfAllArea(string name)
        {
            SellingGateWay gateWay = new SellingGateWay();
            return gateWay.GetFixedProductOfAllArea(name);
        }

        public static List<Product> GetPreviousSalesRecordOfArea(Product product, string date)
        {
            SellingGateWay gateWay = new SellingGateWay();
            return gateWay.GetPreviousSalesRecordOfArea(product, date);
        }

        public List<AllRecordwithDate> SalesRecordWithinTimeLimit(AllRecordwithDate date)
        {
            SellingGateWay gateWay = new SellingGateWay();
            return gateWay.SalesRecordWithinTimeLimit(date);


        }

        public static List<Product> TodaysRalesRecord(out int totalsum)
        {
            SellingGateWay gateWay = new SellingGateWay();
            return gateWay.TodaysRalesRecord(out totalsum);

        }
    }
}