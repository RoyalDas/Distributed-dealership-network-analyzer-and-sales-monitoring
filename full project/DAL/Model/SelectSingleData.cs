using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace full_project.DAL.Model
{
    public class SelectSingleData
    {
        public int SingleData(string spname, List<SqlParameter> parameter)
        {
            string connectionsting = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionsting);
            SqlCommand command = new SqlCommand(spname, connection);
            command.CommandType = CommandType.StoredProcedure;
            if (parameter != null)
            {
                foreach (SqlParameter nparameter in parameter)
                {
                    command.Parameters.Add(nparameter);
                }
            }

            connection.Open();
            int roweffected = Convert.ToInt32(command.ExecuteScalar());
            return roweffected;

        }
    }
}