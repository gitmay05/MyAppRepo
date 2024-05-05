using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AllinOneApiApplication.CommonDataAccess
{
    public class CheckParameters
    {
    
        internal static void ConvertNullToDBNull(List<SqlParameter> sqlParameters)
        {
            foreach (SqlParameter parm in sqlParameters)
            {
                if (parm.Value == null)
                    parm.Value = DBNull.Value;
            }
        }
        internal static void ConvertNullToDBNull(SqlParameter[] sqlParameters)
        {
            foreach (SqlParameter parm in sqlParameters)
            {
         
                if (parm.Value == null)
                    parm.Value = DBNull.Value;
            }
        }
    }
}
