using AllinOneApiApplication.CommonDataAccess;
using AllinOneApiApplication.Model.Form;
using AllinOneApiApplication.Model.User;
using System.Data.SqlClient;
using System.Data;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Login;
using AllinOneApiApplication.Model.Role;
using AllinOneApiApplication.Interface.Login;

namespace AllinOneApiApplication.Repository.Login
{
    public class LoginReposistory: ILogin
    {
        #region
        static DataFunctions objDataFunctions = null;
        System.Data.DataSet objDataSet = null;
        List<UserModel> objuserList = null;
        static string _commandText = string.Empty;
        #endregion

        public LoginReposistory()
        {
            objDataFunctions = new DataFunctions();
        }
        public Message AuthenticateUser(LoginModel ObjLoginModel, out UserInfoModel _User, out List<LoggedInFormRoleRightsModel> _formlist)
        {
            Message objMessage = new Message();
            _User = new UserInfoModel();

            _formlist = new List<LoggedInFormRoleRightsModel>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>()
            {
                new SqlParameter("@cUserName",ObjLoginModel.UserName),
                new SqlParameter("@cPassword",ObjLoginModel.Password)
            };

                CheckParameters.ConvertNullToDBNull(parms);
                _commandText = "[USP_AuthenticateUser]";
                objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objMessage.MsgId = objDataSet.Tables[0].Rows[0].Field<int>("Message_Id");
                    objMessage.Msg = objDataSet.Tables[0].Rows[0].Field<string>("Message");

                    DataRow _dr = objDataSet.Tables[1].Rows[0];

                    _User = new UserInfoModel()
                    {
                        UserId = WrapDbNull.WrapDbNullValue<Int64>(_dr.Field<Int64?>("UserId")),
                        UserName = _dr.Field<string>("UserName"),
                        UserPassword =_dr.Field<string>("UserPassword"),
                        RoleName = _dr.Field<string>("RoleName"),
                        AccountId = WrapDbNull.WrapDbNullValue<Int64>(_dr.Field<Int64?>("FK_AccountId")),
                        HomePage = _dr.Field<string>("FormName"),
                        HomePage_Action = _dr.Field<string>("ActionName"),
                        HomePage_Controller = _dr.Field<string>("ControllerName"),
                        HomePage_Area = _dr.Field<string>("AreaName"),


                    };
                    _formlist = objDataSet.Tables[2].AsEnumerable().Select(dr => new LoggedInFormRoleRightsModel()
                    {
                        PK_FormId = WrapDbNull.WrapDbNullValue<Int64>(dr.Field<Int64?>("PK_FormId")),
                        FormName = dr.Field<string>("FormName"),
                        ControllerName = dr.Field<string>("ControllerName"),
                        ActionName = dr.Field<string>("ActionName"),
                        FK_ParentId = dr.Field<Int64>("ParentId"),
                        CanAdd = WrapDbNull.WrapDbNullValue<bool>(dr.Field<bool?>("CanAdd")),
                        CanEdit = WrapDbNull.WrapDbNullValue<bool>(dr.Field<bool?>("CanEdit")),
                        CanDelete = WrapDbNull.WrapDbNullValue<bool>(dr.Field<bool?>("CanDelete")),
                        CanView = WrapDbNull.WrapDbNullValue<bool>(dr.Field<bool?>("CanView")),
                       // ClassName = dr.Field<string>("ClassName"),
                        HomePage = dr.Field<Int64>("HomePageId"),
                       // Area = dr.Field<string>("Area"),
                    }).ToList();
                }

            }
            catch (Exception ex)
            {

            }

            return objMessage;
        }

    }
}
