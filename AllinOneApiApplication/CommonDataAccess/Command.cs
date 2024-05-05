using System.Data.SqlClient;

namespace AllinOneApiApplication.CommonDataAccess
{

    public class Command
    {
    
        public SqlCommand getCommand
        {
            get
            {
                Connection con = new Connection();
                return con.getConnection.CreateCommand();
            }
        }

    }
}
