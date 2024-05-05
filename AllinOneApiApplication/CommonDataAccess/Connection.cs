using System;
using System.Data.SqlClient;
using System.Configuration;

namespace AllinOneApiApplication.CommonDataAccess
{
    public class Connection
    {
     
        public string connectionString
        {
            get
            {

                string ConString = System.Environment.GetEnvironmentVariable("connectionString");
                if (string.IsNullOrWhiteSpace(ConString))
                {
                    throw new ApplicationException("connection string not found in app setting");
                }

                return ConString;
            }
        }
             
        public SqlConnection getConnection
        {
            get
            {
                try
                {
                    new SqlConnection(connectionString);
                }
                catch (Exception Ex)
                {

                }
                return new SqlConnection(connectionString);
            }
        }
    }
}
