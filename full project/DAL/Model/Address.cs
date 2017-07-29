using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace full_project.DAL.Model
{
    public class Address
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string ContactNo { set; get; }
        public string DivisionName { set; get; }
        public string DistrictName { set; get; }
        public string AreaName { set; get; }
    }
}