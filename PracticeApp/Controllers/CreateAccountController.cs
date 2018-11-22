using PracticeAppBusiness.BusinessLogic;
using PracticeAppBusiness.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeApp.Controllers
{
    public class CreateAccountController : Controller
    {
        CreateAccountLogic cl = new CreateAccountLogic();

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetAccountType()
        {
            var retItem = cl.GetAccountType();
            return Json(new { retItem });
        }

        public JsonResult GetAccountNo(int aId)
        {
            var retItem = cl.GenerateAccountNumber(aId);
            return Json(new { retItem });
        }
        public JsonResult CreateNewAccount(CreateAccountViewModel submitData)
        {
            var retItem = cl.CreateNewAccount(submitData);
            return Json(new { retItem });
        }
    }
}