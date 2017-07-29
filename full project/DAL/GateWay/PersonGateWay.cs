using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using full_project.DAL.Model;

namespace full_project.DAL.GateWay
{
    public class PersonGateWay
    {
        public Person GetData(Person nPerson)
        {
            int userId = 0;
            string roles = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", nPerson.UserName);
                    cmd.Parameters.AddWithValue("@Password", nPerson.PassWord);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Person aPerson = new Person();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        aPerson.Id = Convert.ToInt32(reader["UserId"]);
                        if (reader["Roles"] != DBNull.Value)
                        {
                            aPerson.RoleId = Convert.ToInt32(reader["Roles"]);
                        }
                        con.Close();
                    }
                  
                    return aPerson;
                }

            }
        }

        public int Changepassword(Person person)
        {
            SaveAllData saveAllData = new SaveAllData();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@UserName",
                    Value =person.UserName
                },
                  new SqlParameter()
                {
                    ParameterName ="@Email",
                    Value =person.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@CurrentPassword",
                    Value =person.PassWord
                },
                new SqlParameter()
                {
                    ParameterName ="@NewPassword",
                    Value =person.NewPassword
                }
                
            };
            int roweffected = saveAllData.SaveData("spchangepasswordManually", parameters);
            return roweffected;
        }

        public Person IsUserNameExist(string userEmail, out Guid uniqueId, out int returncode)
        {
            GetDataSet getDataSet = new GetDataSet();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@UserEmail",
                    Value =userEmail
                }
            };
            DataSet dataSet = getDataSet.GetAlldata("spresetpasswordRequest", parameters);
            Guid returnvalue1 = Guid.Empty;
            int returnvalue2 = 0;
            Person aPerson = null;
            if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["returncode"]) != 0)
            {
                aPerson = new Person();
                aPerson.UserName = dataSet.Tables[0].Rows[0]["Uname"].ToString();
                returnvalue1 = (Guid)dataSet.Tables[0].Rows[0]["uniqueid"];
                returnvalue2 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["returncode"]);
                aPerson.Email = dataSet.Tables[0].Rows[0]["email"].ToString();
            }
            uniqueId = returnvalue1;
            returncode = returnvalue2;
            return aPerson;
        }

        public int IslinkValid(string guidValue)
        {
            GetDataSet getDataSet = new GetDataSet();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@GUID",
                    Value =guidValue
                }
            };
            DataSet dataSet = getDataSet.GetAlldata("spIsLinkValid", parameters);
            int returnvalue = 0;
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                returnvalue = Convert.ToInt32(dataSet.Tables[0].Rows[0]["UserId"]);
            }
            return returnvalue;
        }

        public int ResetPassWord(Person person, string guidvalue)
        {
            SaveAllData saveAllData = new SaveAllData();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@GUID",
                    Value = guidvalue
                },
                new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = person.NewPassword
                }
            };
            int roweffected = execute("spchangepassword", parameters);
            return roweffected;
        }
        private int execute(string spname, List<SqlParameter> parameters)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlCommand command = new SqlCommand(spname, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter nparameter in parameters)
                {
                    command.Parameters.Add(nparameter);
                }

                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }

        }

        public int Registration(Person person)
        {
             SelectSingleData data=new SelectSingleData();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName ="@username",
                    Value =person.UserName
                },
                  new SqlParameter()
                {
                    ParameterName ="@Email",
                    Value =person.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@npassword",
                    Value =person.PassWord
                },
                new SqlParameter()
                {
                    ParameterName ="@contactno",
                    Value =person.ContactNo
                },
                  new SqlParameter()
                {
                    ParameterName ="@divisioname",
                    Value =person.DivisionName
                },
                new SqlParameter()
                {
                    ParameterName = "@districtname",
                    Value =person.DistrictName
                },
                new SqlParameter()
                {
                    ParameterName ="@areaname",
                    Value =person.AreaName
                }
                
            };
            int roweffected = data.SingleData("Insert_User", parameters);
            return roweffected;
        }
    }
}