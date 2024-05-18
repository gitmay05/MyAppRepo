using AllinOneApiApplication.CommonDataAccess;
using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Model.UserModel;
using System.Data.SqlClient;
using System.Data;
using AllinOneApiApplication.Model.User;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;

namespace AllinOneApiApplication.Repository.User
{
    public class UserReposistory : IApplicationUser
    {
        #region
        static DataFunctions objDataFunctions = null;
        System.Data.DataSet objDataSet = null;
        List<UserModel> objuserList = null;
        static string _commandText = string.Empty;
        #endregion
        public UserReposistory()
        {
            objDataFunctions = new DataFunctions();
        }

        public List<Dropdown> GetRoleForUser(Int64 SessionAccountId)
        {
            List<Dropdown> _List = new List<Dropdown>();
            var result = _List;
           

            System.Data.DataSet? objDataSet = null;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {

                    new SqlParameter("@iAccountId",SessionAccountId),

                };

                _commandText = "[dbo].[USP_GetRoleForUser]";
                objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    if (objDataSet.Tables[0].Rows[0].Field<int>("Message_Id") == 1)
                    {
                        _List = objDataSet.Tables[1].AsEnumerable().Select(dr => new Dropdown()
                        {
                            Id = dr.Field<Int64>("PK_RoleId"),
                            Value = dr.Field<string>("RoleName")
                        }).ToList();
                        objDataSet.Dispose();
                        result = _List;
                    }
                    else
                    {
                        result = _List;
                    }
                }

            }
            catch (Exception e)
            {
                result = _List;
            }
            return result;

        }


        public List<UserModel> GetUserDetails(Int64 UserId)
        {

            var result = objuserList;
            objuserList = new List<UserModel>();

            System.Data.DataSet objDataSet = null;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {

                    new SqlParameter("@iPK_UserId",UserId),
                    
                };

                _commandText = "[dbo].[USP_GetUserDetails]";
                objDataSet =  (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    if (objDataSet.Tables[0].Rows[0].Field<int>("Message_Id") == 1)
                    {
                        objuserList = objDataSet.Tables[1].AsEnumerable().Select(dr => new UserModel()
                        {
                            UserId= dr.Field<Int64>("UserId"),
                            FK_AccountId= dr.Field<Int64>("FK_AccountId"),
                            FK_RoleId = dr.Field<Int64>("FK_RoleId"),
                            UserName = dr.Field<string>("UserName"),
                            Password = dr.Field<string>("Password"),
                            RoleName = dr.Field<string>("RoleName"),
                            CreatedBy = dr.Field<string>("CreatedBy"),
                            CreatedDate = dr.Field<string>("CreatedDate"),
                            Email = dr.Field<string>("Email"),
                            Status = dr.Field<string>("Status")

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


        public Message AddEditUserDetails(UserModel UserDetails)
        {
            Message objMessages = new Message();
            try
            {
                _commandText = "[dbo].[usp_AddEditUser]";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter("@iPK_UserId",UserDetails.UserId),
                    new SqlParameter("@iFK_AccountId",UserDetails.FK_AccountId),
                    new SqlParameter("@cUserName",UserDetails.UserName==null?"":UserDetails.UserName.Trim()),
                    new SqlParameter("@cPassword",UserDetails.Password==null?"":UserDetails.Password.Trim()),
                    new SqlParameter("@iFK_RoleId",UserDetails.FK_RoleId),
                    new SqlParameter("@cEmail", UserDetails.Email==null?"":UserDetails.Email.Trim()),
                    new SqlParameter("@iCreatedBy",UserDetails.SessionUserId),
                    new SqlParameter("@bIsActive",UserDetails.IsActive)
           ,

                };
                CheckParameters.ConvertNullToDBNull(parms);
                objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objMessages.MsgId = objDataSet.Tables[0].Rows[0].Field<int>("Message_Id");
                    objMessages.Msg = objDataSet.Tables[0].Rows[0].Field<string>("Message");
                }
                else
                {
                    objMessages.MsgId = 0;
                    objMessages.Msg = "ProcessFailed";
                }
            }
            catch (Exception ex)
            {
                var objBase = System.Reflection.MethodBase.GetCurrentMethod();
            }
            return objMessages;
        }
        public Message DeleteUserDetails(Int64 UserId, Int64 SessionuserId)
        {
            Message objMessages = new Message();
            _commandText = "[dbo].[USP_DeleteForm]";
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter("@iUserId",UserId),
                    new SqlParameter ("@iSessionUserId",SessionuserId),

                };
                CheckParameters.ConvertNullToDBNull(parms);
                objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objMessages.MsgId = objDataSet.Tables[0].Rows[0].Field<int>("Message_Id");
                    objMessages.Msg = objDataSet.Tables[0].Rows[0].Field<string>("Message");
                }
                else
                {
                    objMessages.MsgId = 0;
                    objMessages.Msg = "Process Failed";
                }
            }
            catch (Exception ex)
            {
                var objBase = System.Reflection.MethodBase.GetCurrentMethod();
            }

            return objMessages;
        }
    }
}
