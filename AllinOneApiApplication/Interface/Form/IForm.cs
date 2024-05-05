using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Model.Form;

namespace AllinOneApiApplication.Interface.Form
{
    public interface IForm
    {
        Task<List<Form>> UserDetails();
        Task<List<user>> UserDetails();
        Task<List<user>> UserDetails();
    }
}
