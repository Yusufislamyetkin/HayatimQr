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
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin

        AdminManager am = new AdminManager(new EFAdminDal());

        [HttpGet]

        public ActionResult AdminLoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLoginIndex(Admin admin)
        {

            var AdminInfo = am.GetBySession(admin);


            if (AdminInfo != null)
            {


                FormsAuthentication.SetAuthCookie(AdminInfo.AdminSystemName, false);

                Session["AdminSystemName"] = AdminInfo.AdminSystemName;
                


                return RedirectToAction("AdminListUser", "AdminPanel");


            }
            else
            {
                TempData["AlertMessageStudent"] = "Giriş Yapılamadı ";
                return RedirectToAction("Index");
            }

         
        }


    }
}