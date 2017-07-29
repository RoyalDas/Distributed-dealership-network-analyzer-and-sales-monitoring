using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using full_project.DAL.Model;

namespace full_project.DAL.GateWay
{
    public class AddressGateWay
    {
        public List<Address> GetDivision()
        {
            GetDataSet getDataSet=new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata("spdivision", null);
            List<Address> addresses=new List<Address>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Address nAddress=new Address();
                    nAddress.DivisionName = dr["Divisionname"].ToString();
                    nAddress.Id = Convert.ToInt32(dr["Id"]);
                    addresses.Add(nAddress);
                }
            }
            return addresses;
        }

        public List<Address> GetAllDistrict(string spname, List<SqlParameter> parameter)
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata(spname,parameter);
            List<Address> addresses = new List<Address>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Address nAddress = new Address();
                    nAddress.DistrictName= dr["Zillaname"].ToString();
                    nAddress.Id = Convert.ToInt32(dr["Id"]);
                    addresses.Add(nAddress);
                }
            }
            return addresses;
        }

        public List<Address> GetAllArea(string spareabyzillaid, List<SqlParameter> parameters)
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata(spareabyzillaid, parameters);
            List<Address> addresses = new List<Address>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Address nAddress = new Address();
                    nAddress.AreaName= dr["Areaname"].ToString();
                    nAddress.Id = Convert.ToInt32(dr["Id"]);
                    addresses.Add(nAddress);
                }
            }
            return addresses;
        }

        public List<Address> GetDealerinfos()
        {
            GetDataSet getDataSet = new GetDataSet();
            DataSet dataSet = getDataSet.GetAlldata("SpGetDealerinfo", null);
            List<Address> addresses = new List<Address>();
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    Address nAddress = new Address();
                    nAddress.Name = dr["UserName"].ToString();
                    nAddress.Email = dr["Email"].ToString();
                    nAddress.ContactNo = dr["ContactNo"].ToString();
                    nAddress.DivisionName = dr["DivisionName"].ToString();
                    nAddress.DistrictName = dr["DistrictName"].ToString();
                    nAddress.AreaName = dr["AreaName"].ToString();
                    addresses.Add(nAddress);
                }
            }
            return addresses;
        }
    }
}