using PracticeAppBusiness.BusinessLogic;
using PracticeAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PracticeApp.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        PracticeDBEntities db = new PracticeDBEntities();
        UserLogic ul = new UserLogic();

        public JsonResult Register(User submitData)
        {
            submitData.hashedPassword = Crypto.HashPassword(submitData.hashedPassword);

            var saveUser = ul.UserRegistation(submitData);

            return Json(new { saveUser });
        }

        [HttpPost]
        public JsonResult SignIn(User submitData)
        {
            
            var verify = false;
            var user = db.Users.Where(x => x.email == submitData.email).FirstOrDefault();

            verify = Crypto.VerifyHashedPassword(user.hashedPassword, submitData.hashedPassword);
            return Json(new { verify });
        }


        //check user email there or not
        public JsonResult CheckEmail(string email)
        {
            bool check = db.Users.Any(x => x.email == email);
            return Json(new { check });
        }

    }
}