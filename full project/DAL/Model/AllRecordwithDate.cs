using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace full_project.DAL.Model
{
    public class AllRecordwithDate:Product
    {
        public string SpecificDate { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
    }
}