using AllinOneApiApplication.Model;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;

namespace AllinOneApiApplication.Interface.Form
{
    public interface IForm
    {
        List<FormModel> GetFormDetails(Int64 FormId);
        Message AddEditFormDetails(FormModel formDetails);
        Message DeleteFormsDetails(Int64 formID, Int64 userId);
    }
}
