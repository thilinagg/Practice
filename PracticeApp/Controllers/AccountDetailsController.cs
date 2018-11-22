using Newtonsoft.Json.Linq;
using PracticeAppBusiness.BusinessLogic;
using PracticeAppBusiness.ViewModel;
using PracticeAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeApp.Controllers
{
    public class AccountDetailsController : Controller
    {

        CreateAccountLogic cl = new CreateAccountLogic();

        public ActionResult Index()
        {
            var list = cl.AccountList();
            return View(list);
        }

        [HttpPost]
        public ActionResult saveuser(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update data to database 
            using (PracticeDBEntities dc = new PracticeDBEntities())
            {
                var user = dc.CreateAccounts.Find(id);
                if (user != null)
                {
                    dc.Entry(user).Property(propertyName).CurrentValue = value;
                    dc.SaveChanges();
                    status = true;
                }
                else
                {
                    message = "Error!";
                }
            }

            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            return Content(o.ToString());
        }


    }
}