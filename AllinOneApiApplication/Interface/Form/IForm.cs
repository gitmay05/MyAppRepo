using AllinOneApiApplication.Model.Form;
using AllinOneApiApplication.Model.UserModel;

namespace AllinOneApiApplication.Interface.Form
{
    public interface IForm
    {
        List<form> formDetails();
        List<form> UserAdd();
        List<form> UserUpdate();
    }
}
