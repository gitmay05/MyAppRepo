using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Interface.Role;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;
using AllinOneApiApplication.Model.Role;
using AllinOneWebApplication.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace AllinOneWebApplication.Controllers
{
	public class RoleController : Controller
	{
        private readonly IRole _Role;
        public RoleController(IRole Role)
        {
            _Role = Role;
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
        public PartialViewResult GetRoleDetails()
        {
            List<RoleModel> _List = new List<RoleModel>();
            try
            {

                _List = _Role.GetRoleDetails(0).ToList();

            }
            catch (Exception ex)
            {
                _List = new List<RoleModel>();
                return PartialView("_GetRoleDetails", _List);
            }

            return PartialView("_GetRoleDetails", _List);
        }

       

        [HttpGet]
        public IActionResult AddEditRole(int Id = 0)
        {
       
            ViewBag.Status = new List<string>() { "Active", "InActive" };
             List<RoleRightsMappingModel> _FormDropdownList = new List<RoleRightsMappingModel>();
            _FormDropdownList = _Role.BindMenuFormsForRole(Id);
            ViewBag.FormList = _FormDropdownList;
            if (Id > 0)
            {
                List<RoleModel> _RoleList = new List<RoleModel>();
                _RoleList = _Role.GetRoleDetails(Id).ToList();

                _RoleList[0].Item = _FormDropdownList;
                return View("AddEditRole", _RoleList[0]);
            }
            else
            {
                RoleModel obj = new RoleModel();
                obj.Item = _FormDropdownList;

               // NewRoleModel objRole = new NewRoleModel();
                return View(obj);
            }

        }

        [HttpPost]
        public IActionResult AddEditRole(RoleModel obj)
        {
            string JsonData = "";string ? RoleName = obj.RoleName;
            Int64 RoleId = 0; Int64 HomePageId = obj.FK_HomePageFormId; Int64 SessionUserId = 1;
            ViewBag.Status = new List<string>() { "Active", "InActive" };
            if (!ModelState.IsValid)
            {
            }
            if(obj.Item.Count>0)
            {
                JsonData = JsonConvert.SerializeObject(obj.Item);
            }
            Message objMessageModel = new Message();
            obj.IsActive = obj.Status == "Active" ? true : false;
            objMessageModel = _Role.AddEditRoleDetails(JsonData, RoleName, RoleId, HomePageId, SessionUserId);
            ExtentionMethods.PutTemp(TempData, "Message", objMessageModel);

            return RedirectToAction("Index", "Role");

        }
         public IActionResult DeleteRole(Int64 RoleId = 0, Int64 UserId = 0)
        {

            Message objMessage = new Message();
            objMessage = _Role.DeleteRoleDetails(RoleId, UserId);
            ExtentionMethods.PutTemp(TempData, "Message", objMessage);
            return RedirectToAction("Index", "Role");

        }

        

    }
}
