using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using full_project.DAL.GateWay;
using full_project.DAL.Model;

namespace full_project.BBL
{
    public class AddressManager
    {
        AddressGateWay addressGateWay = new AddressGateWay();
        public List<Address> GetDivision()
        {
            return addressGateWay.GetDivision();
        }



        public List<Address> GetAllDistrict(string spname, List<SqlParameter> parameter)
        {
            return addressGateWay.GetAllDistrict(spname,parameter);
        }

        public List<Address> GetAllArea(string spareabyzillaid, List<SqlParameter> parameters)
        {
          
            return addressGateWay.GetAllArea(spareabyzillaid, parameters);
        }

        public List<Address> GetDealerinfos()
        {
            return addressGateWay.GetDealerinfos();
        }
    }
}