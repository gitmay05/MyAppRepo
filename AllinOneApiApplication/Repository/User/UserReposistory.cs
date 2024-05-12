using AllinOneApiApplication.CommonDataAccess;
using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Model.UserModel;
using System.Data.SqlClient;
using System.Data;

namespace AllinOneApiApplication.Repository.User
{
    public class UserReposistory : IApplicationUser
    {
        #region
        static DataFunctions objDataFunctions = null;
        System.Data.DataSet objDataSet = null;
        List<user> objuserList = null;
        static string _commandText = string.Empty;
        #endregion
        public UserReposistory()
        {
            objDataFunctions = new DataFunctions();
        }

        public  List<user> UserDetails()
        { 
 
            var result = objuserList;
            objuserList = new List<user>();

            System.Data.DataSet objDataSet = null;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {

                    new SqlParameter("@id","1"),
                    
                };

                _commandText = "[dbo].[USP_yourproc]";
                objDataSet =  (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    if (objDataSet.Tables[0].Rows[0].Field<int>("Message_Id") == 1)
                    {
                        objuserList = objDataSet.Tables[1].AsEnumerable().Select(dr => new user()
                        {
                            UserName = dr.Field<string>("CaseID"),
                            UserPwd = dr.Field<string>("RatingCount"),
                          
                        }).ToList();
                        objDataSet.Dispose();
                        result = objuserList;
                    }
                    else
                    {
                        result = null;
                    }
                }

            }
            catch (Exception e)
            {
                result = null;
            }
            return result;

        }

        public user UserDetailsById(int i)
        {
            throw new NotImplementedException();
        }
    }
}
