using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace full_project.DAL.Model
{
    public class GetDataSet
    {
        public DataSet GetAlldata(string spname, List<SqlParameter> parameter)
        {
            string connectionsting = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionsting);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(spname, connection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parameter != null)
            {
                foreach (SqlParameter nparameter in parameter)
                {
                    dataAdapter.SelectCommand.Parameters.Add(nparameter);
                }
            }

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;

        }
    }
}