

using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;
using AllinOneApiApplication.Model.User;
using AllinOneApiApplication.Model.UserModel;

namespace AllinOneApiApplication.Interface.ApplicationUser
{
    public interface IApplicationUser
    {
        List<Dropdown> GetRoleForUser(Int64 SessionAccountId);
        List<UserModel> GetUserDetails(Int64 FormId);
        Message AddEditUserDetails(UserModel UserDetails);
        Message DeleteUserDetails(Int64 UserId, Int64 SessionUserId);
    }
}
