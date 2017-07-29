using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using full_project.DAL.GateWay;
using full_project.DAL.Model;

namespace full_project.BBL
{
    public class PersonManager
    {
        public Person GetData(Person nPerson)
        {
            PersonGateWay aPersonGateWay = new PersonGateWay();
            return aPersonGateWay.GetData(nPerson);
        }

        public static string Changepassword(Person person)
        {
            PersonGateWay aPersonGateWay = new PersonGateWay();
            int roweffected = aPersonGateWay.Changepassword(person);
            if (roweffected > 0)
            {
                return "Password Changed Successfull";
            }
            else
            {
                return "Your UserNmae or Password or Email is not correct";
            }
        }

        public Person IsUserNameExist(string userEmail, out Guid uniqueId, out int returncode)
        {
            PersonGateWay aPersonGateWay = new PersonGateWay();
            return aPersonGateWay.IsUserNameExist(userEmail, out uniqueId, out returncode);
        }

        public int IslinkValid(string guidValue)
        {
            PersonGateWay aPersonGateWay = new PersonGateWay();
            return aPersonGateWay.IslinkValid(guidValue);
        }

        public int ResetPassWord(Person person, string guidvalue)
        {
            PersonGateWay aPersonGateWay = new PersonGateWay();
            return aPersonGateWay.ResetPassWord(person, guidvalue);
        }

        public int Registration(Person person)
        {
            PersonGateWay aPersonGateWay = new PersonGateWay();
            return aPersonGateWay.Registration(person);

        }
    }
}