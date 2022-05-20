using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminPanelController : Controller
    {
        public ActionResult AdminPanelHomePage()
        {
            return View();
        }

        public ActionResult AdminListUser()
        {
            return View();
        }
    }
}