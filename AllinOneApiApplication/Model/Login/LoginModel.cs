using System.ComponentModel.DataAnnotations;

namespace AllinOneApiApplication.Model.Login
{
    public class LoginModel
    {
        [Display(Name = "User Name")]
        [Required( ErrorMessage= "User Name Required!")]
        public string ? UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required!")]
        public string ? Password { get; set; }
    }
}
