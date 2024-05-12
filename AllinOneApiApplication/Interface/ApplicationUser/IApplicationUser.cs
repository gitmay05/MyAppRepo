

using AllinOneApiApplication.Model.UserModel;

namespace AllinOneApiApplication.Interface.ApplicationUser
{
    public interface IApplicationUser
    {
        List<user> UserDetails();
        user UserDetailsById(int id);
    }
}
