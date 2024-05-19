using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Interface.Login;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Login;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using AllinOneWebApplication.Common;

namespace AllinOneWebApplication.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILogin ? _Login;
        public LoginController(ILogin Login)
        {
            _Login = Login;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginModel obj = new LoginModel();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Login(LoginModel objLoginModel)
        {
            Message objMessage = new Message();
            UserInfoModel ? _User = null; List<LoggedInFormRoleRightsModel> ? _formlist = null;
            objMessage= _Login.AuthenticateUser(objLoginModel, out _User, out _formlist);
            if(_User.AccountId>0 && _formlist.Count>0)
            {
                string strUserInfo = JsonConvert.SerializeObject(_User);
                HttpContext.Session.SetString("UserInfo", strUserInfo);//set session


                if (_formlist.Count > 0)
                {
                    string strFormInfo = JsonConvert.SerializeObject(_formlist);
                    HttpContext.Session.SetString("FormInfo", strFormInfo);//set session
                }
                if (_User.HomePage_Action != "" && _User.HomePage_Controller != "")
                {
                    return RedirectToAction(_User.HomePage_Action, _User.HomePage_Controller, new { Area = "" });
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                    ModelState.AddModelError("UserName", "Wrong User Name or Password. Please Try Again!");
            }
            return View(objLoginModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (HttpContext.Request.Cookies.Count > 0)
                {
                    var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                    foreach (var cookie in siteCookies)
                    {
                        Response.Cookies.Delete(cookie.Key);
                    }
                }
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
               
                return RedirectToAction("LogIn", "LogIn");

            }
            catch (Exception ex)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("LogIn", "LogIn");
            }
        }

    }
}
