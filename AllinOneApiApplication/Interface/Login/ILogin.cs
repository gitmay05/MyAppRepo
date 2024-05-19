using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Login;

namespace AllinOneApiApplication.Interface.Login
{
    public interface ILogin
    {
        Message AuthenticateUser(LoginModel ObjLoginModel, out UserInfoModel _User, out List<LoggedInFormRoleRightsModel> _formlist);
    }
}
