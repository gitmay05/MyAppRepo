using AllinOneApiApplication.Interface.ApplicationUser;
using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.User;
using AllinOneWebApplication.Common;
using Microsoft.AspNetCore.Mvc;

namespace AllinOneWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationUser _User;
        public UserController(IApplicationUser User)
        {
            _User = User;
        }
        public IActionResult Index()
        {
            ViewBag.Message = null;

            var TempDatavalue = ExtentionMethods.GetTemp<Message>(TempData, "Message");
            if (TempDatavalue != null)
            {
                Message objMessage = new Message();
                ViewBag.Message = TempDatavalue;
                ExtentionMethods.PutTemp(TempData, "Message", objMessage);

            }
            return View();
        }
        [HttpGet]
        public PartialViewResult GetUserDetails()
        {
            List<UserModel> _List = new List<UserModel>();
            try
            {

                _List = _User.GetUserDetails(0).ToList();

            }
            catch (Exception ex)
            {
                _List = new List<UserModel>();
                return PartialView("_GetUserDetails", _List);
            }

            return PartialView("_GetUserDetails", _List);
        }


        [HttpGet]
        public IActionResult AddEditUser(int Id = 0)
        {
            ViewBag.Status = new List<string>() { "Active", "InActive" };
            List<Dropdown> _AccountDropdownList = new List<Dropdown>();
            _AccountDropdownList.Add(new Dropdown { Id = 1, Value = "Company" });
            _AccountDropdownList.Add(new Dropdown { Id = 2, Value = "Customer" });
           
            ViewBag.AccountList = _AccountDropdownList;


            List<Dropdown> _RoleDropdownList = new List<Dropdown>();
            _RoleDropdownList.Add(new Dropdown { Id = 1, Value = "Admin" });
            _RoleDropdownList.Add(new Dropdown { Id = 2, Value = "User" });
            ViewBag.RoleList = _RoleDropdownList;

            if (Id > 0)
            {
                List<UserModel> _UserList = new List<UserModel>();
                _UserList = _User.GetUserDetails(Id).ToList();

              //  _UserList[0].Password = _UserList[0].Password.Decrypt();// Decript Password
                return View("AddEditUser", _UserList[0]);
            }
            else
            {
                UserModel objUserModel = new UserModel();
                return View(objUserModel);
            }

        }

        [HttpPost]
        public IActionResult AddEditUser(UserModel objUserModel)
        {
            //if (objUserModel.FK_RoleId == 0)
            //{
            //    ModelState.AddModelError("FK_RoleId", "Please Select Role");
            //}
            //if (objUserModel.FK_AccountId == 0)
            //{
            //    ModelState.AddModelError("FK_PracticeId", "Please Select Account");
            //}
            if (!ModelState.IsValid)
            {
                ViewBag.Status = new List<string>() { "Active", "InActive" };
                ViewBag.Status = new List<string>() { "Active", "InActive" };
                List<Dropdown> _AccountDropdownList = new List<Dropdown>();
                _AccountDropdownList.Add(new Dropdown { Id = 1, Value = "Company" });
                _AccountDropdownList.Add(new Dropdown { Id = 2, Value = "Customer" });

                ViewBag.AccountList = _AccountDropdownList;


                List<Dropdown> _RoleDropdownList = new List<Dropdown>();
                _RoleDropdownList.Add(new Dropdown { Id = 1, Value = "Admin" });
                _RoleDropdownList.Add(new Dropdown { Id = 2, Value = "User" });
                ViewBag.RoleList = _RoleDropdownList;

                return View(objUserModel);
            }
            Message objMessageModel = new Message();
            objUserModel.IsActive = objUserModel.Status == "Active" ? true : false;
          //  objUserModel.Password = objUserModel.Password.Encrypt();// Encript Password
            objMessageModel = _User.AddEditUserDetails(objUserModel);
            ExtentionMethods.PutTemp(TempData, "Message", objMessageModel);

            return RedirectToAction("Index", "User");
        }

        public IActionResult DeleteUser(Int64 UserId = 0, Int64 UserSessionId = 0)
        {
            Message objMessageModel = new Message();
            objMessageModel = _User.DeleteUserDetails(UserId, UserSessionId);
            ExtentionMethods.PutTemp(TempData, "Message", objMessageModel);
            return RedirectToAction("Index", "User");

        }
    }
}
