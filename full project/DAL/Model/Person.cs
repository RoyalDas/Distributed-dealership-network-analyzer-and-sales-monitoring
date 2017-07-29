using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace full_project.DAL.Model
{
    public class Person:Address
    {
        public int RoleId { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
        public string NewPassword { set; get; }
        public string ConfirmPassword { set; get; }
    }
}