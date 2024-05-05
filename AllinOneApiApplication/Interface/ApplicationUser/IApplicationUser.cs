using AllinOneApiApplication.ModelClass.UserModel;
using AllinOneApiApplication.ModelClass.UserModel;

namespace AllinOneApiApplication.Interface.ApplicationUser
{
    public interface IApplicationUser
    {
        List<ApplicationUser> UserDetails { get; set; }
    }
}
