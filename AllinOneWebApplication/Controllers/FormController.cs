using AllinOneApiApplication.Interface;
using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Model;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;
using AllinOneWebApplication.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace AllinOneWebApplication.Controllers
{
    public class FormController : Controller
    {

        private readonly IForm _Form;
        public FormController(IForm Form)
        {
            _Form = Form;
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
        public PartialViewResult GetFormDetails()
        {
            List<FormModel> _List = new List<FormModel>();
            try
            {

                _List = _Form.GetFormDetails(0).ToList();

            }
            catch (Exception ex)
            {
                _List = new List<FormModel>();
                return PartialView("_GetFormDetails", _List);
            }

            return PartialView("_GetFormDetails", _List);
        }


        [HttpGet]
        public IActionResult AddEditForm(int Id = 0)
        {
            ViewBag.Status = new List<string>() { "Active", "InActive" };
          //  List<DropdownModel> _FormDropdownList = new List<DropdownModel>();
          //  _FormDropdownList = _FormBal.GetParentForm(Id).ToList();
           // ViewBag.FormList = _FormDropdownList;
            if (Id > 0)
            {
                List<FormModel> _FormList = new List<FormModel>();
                _FormList = _Form.GetFormDetails(Id).ToList();
                return View("AddEditForm", _FormList[0]);
            }
            else
            {
                FormModel objForm = new FormModel();
                return View(objForm);
            }

        }

        [HttpPost]
        public IActionResult AddEditForm(FormModel objFormModel)
        {
            ViewBag.Status = new List<string>() { "Active", "InActive" };
            if (!ModelState.IsValid)
            {
               
               // List<Dropdown> _FormDropdownList = new List<Dropdown>();
              //  _FormDropdownList = _FormBal.GetParentForm(objFormModel.PK_FormId).ToList();
              //  ViewBag.FormList = _FormDropdownList;
              //  return View(objFormModel);
            }
            Message objMessageModel = new Message();
            objFormModel.IsActive = objFormModel.Status == "Active" ? true : false;
            objMessageModel = _Form.AddEditFormDetails(objFormModel);
            ExtentionMethods.PutTemp(TempData, "Message", objMessageModel);

            return RedirectToAction("Index", "Form");

        }
        [HttpPost]
        public IActionResult DeleteForm(Int64 FormId = 0, Int64 UserId = 0)
        {

            Message objMessage = new Message();
            objMessage = _Form.DeleteFormsDetails(FormId, UserId);
            ExtentionMethods.PutTemp(TempData, "Message", objMessage);
            return RedirectToAction("Index", "Form");

        }
    }
}
