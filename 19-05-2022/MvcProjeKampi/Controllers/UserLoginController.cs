using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
   [AllowAnonymous]
    public class UserLoginController : Controller
    {
        UserManager um = new UserManager(new EFUserDal());


        // GET: UserLogin

        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var UserInfo = um.GetBySession(user);


            if (UserInfo != null)
            {


                FormsAuthentication.SetAuthCookie(UserInfo.UserSystemName, false);

                Session["UserSystemName"] = UserInfo.UserSystemName;
              
                
              
                return RedirectToAction("UserWelcomePage", "UserHome");


            }
            else
            {
                TempData["AlertMessageStudent"] = "Giriş Yapılamadı ";
                return RedirectToAction("Index");
            }

           
        }

        public ActionResult UserLogOut()
        {


            FormsAuthentication.SignOut();
            Session.Abandon(); 

            return RedirectToAction("Index");
        }


    }
}