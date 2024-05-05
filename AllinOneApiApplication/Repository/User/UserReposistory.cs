using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Model.UserModel;

namespace AllinOneApiApplication.Repository.User
{
    public class UserReposistory : IApplicationUser
    {
        public List<user> UserDetails()
        { 
        List<user> Details = new List<user>();
        user objuser = new user() { UserName = "Prince", UserPwd = "pwd" };
        Details.Add(objuser);
        return Details;
        }
    }
}
