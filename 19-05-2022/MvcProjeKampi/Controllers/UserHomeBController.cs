using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class UserHomeBController : Controller
    {

        UserManager um = new UserManager(new EFUserDal());
        ContactManager cm = new ContactManager(new EFContactDal());
        MenuQrManager mqm = new MenuQrManager(new EFMenuQrDal());
        MenuQrCategoryManager mqcm = new MenuQrCategoryManager(new EFMenuQrCategoryDal());
        MenuQrHeadingManager mqhm = new MenuQrHeadingManager(new EFMenuQrHeadingDal());
        // GET: UserHomeB



        public User SessionValue()
        {
            string p;
            p = (string)Session["UserSystemName"];
            var UserValue = um.GetSessionValue(p);
            return UserValue;
        }

        [Authorize(Roles = "B")]
        public ActionResult HowToUseMenu()
        {
           

            return View(SessionValue());
        }

        [Authorize(Roles = "B")]
        [HttpGet]
        public ActionResult MenuQrCategoryAdd()
        {
            
            return View(SessionValue());
        }
        [HttpPost]
        public ActionResult MenuQrCategoryAdd(MenuQrCategory MenuQrCategory)
        {
  
            MenuQrCategory.UserID = SessionValue().UserID;


            Random randm = new Random();

            if (Request.Files.Count > 0)
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                if (filename == "")
                {
                    MenuQrCategory.CategoryImage = "/Extra/images/fooddef.png";
                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));


                        MenuQrCategory.CategoryImage = "/ımage/" + filename + rdn + uzanti;
                       
                        
                    }
                }


            }

            
                mqcm.AddValue(MenuQrCategory);


            TempData["AlertMessage1"] = "Menü Qr Kategoriniz Eklendi.";
            return RedirectToAction("MenuQrCategoryAdd");
        }



        public ActionResult SeeMenuQrCategories()
        {
            ViewBag.uservalue = SessionValue();

            var ListCategories = mqcm.GetByUserID(SessionValue().UserID);

            return View(ListCategories);
        }


        public ActionResult SeeMenuQrList()
        {
            ViewBag.uservalue = SessionValue();

            var ListCategories = mqcm.GetByUserID(SessionValue().UserID);

            return View(ListCategories);
        }

        public ActionResult SeeMenuContentList(int id)
        {
            ViewBag.uservalue = SessionValue();

            var ListCategories = mqhm.GetByIDListWithCat(id);

            return View(ListCategories);
        }

        public ActionResult EditMenuContent(int id)
        {
            ViewBag.uservalue = SessionValue();

            var ListCategories = mqhm.GetByIDListWithCat(id);

            return View(ListCategories);
        }

        [HttpGet]
        public ActionResult EditMenuContentPage(int id)
        {
            

            var contentValue = mqhm.GetByID(id);

            return View(contentValue);
        }

        [HttpPost]
        public ActionResult EditMenuContentPage(MenuQrHeading menuQrHeading)
        {

            Random randm = new Random();

            if (Request.Files.Count > 0)
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                var getvalue = mqhm.GetByID(menuQrHeading.MenuQrHeadingID);

                if (filename == "")
                {
                    string valueımage = getvalue.HeadingImage;

                    menuQrHeading.HeadingImage = valueımage;
                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));


                        menuQrHeading.HeadingImage = "/ımage/" + filename + rdn + uzanti;


                    }
                }


            }



            mqhm.MenuQrHeadingUpdate(menuQrHeading);
            int id = menuQrHeading.MenuQrCategoryID;
            TempData["AlertMessageUpdate"] = "Seçilen İçerik Güncellendi.";
            return RedirectToAction("EditMenuContent", new { id = id });
        }


        public ActionResult DeleteMenuContent(int id)
        {
            var value = mqhm.GetByID(id);
            int Headingid = value.MenuQrCategoryID;
            mqhm.MenuQrHeadingDelete(value);


            TempData["AlertMessageDelete"] = "Seçilen İçerik Silindi.";
            return RedirectToAction("EditMenuContent", new { id = Headingid });
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
           

            var catupdatevalue = mqcm.GetByID(id);


            return View(catupdatevalue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(MenuQrCategory value)
        {
           

            Random randm = new Random();

            var valueforupdate = mqcm.GetByID(value.MenuQrCategoryID);

            if (Request.Files.Count > 0 || Request.PathInfo != "")
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;
               
                if (filename == "")
                {
                      
                   
                    string valueımage = valueforupdate.CategoryImage;

                    value.CategoryImage = valueımage;

                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));


                        value.CategoryImage = "/ımage/" + filename + rdn + uzanti;


                    }
                }


            }




            var valueid = valueforupdate.MenuQrCategoryID;


            mqcm.MenuQrCategoryNewUpdate(value, valueid);

            //mqcm.AddValue(value);

            TempData["AlertMessage3"] = "Seçilen Kategori Güncellendi.";
            return RedirectToAction("SeeMenuQrCategories");
        }


        public ActionResult DeleteCategory(int id)
        {
    

           var catdeletevalue =  mqcm.GetByID(id);
            mqcm.MenuQrCategoryDelete(catdeletevalue);
            TempData["AlertMessage1"] = "Seçilen Kategori Silindi.";
            return RedirectToAction("SeeMenuQrCategories");
        }


        [HttpGet]
        public ActionResult AddContent(int id)
        {
            var headingvalue = mqcm.GetByID(id);

          
                return View(headingvalue);
          
        
           
          
        }

        [HttpPost]
        public ActionResult AddContent(MenuQrHeading menuQrHeading)
        {

            try
            {

                Random randm = new Random();

            

                if (Request.Files.Count > 0 || Request.PathInfo != "")
                {
                    string rdn = Convert.ToString(randm.Next(0, 9999));
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/ımage/" + filename + rdn + uzanti;

                    var getvalue = mqcm.GetByID(menuQrHeading.MenuQrCategoryID);
                    if (filename == "")
                    {


                        string valueımage = getvalue.CategoryImage;

                        menuQrHeading.HeadingImage = valueımage;

                    }
                    else
                    {
                        if (yol == "~/ımage/")
                        {

                        }
                        else
                        {

                            Request.Files[0].SaveAs(Server.MapPath(yol));


                            menuQrHeading.HeadingImage = "/ımage/" + filename + rdn + uzanti;


                        }
                    }


                }





                mqhm.AddValue(menuQrHeading);


                TempData["AlertMessageContent1"] = "Yeni İçerik Eklendi.";
            }
            catch
            {
                TempData["AlertMessageContent2"] = "Ekleme tamamlanmadı.";
            }
        
            return RedirectToAction("AddContent",menuQrHeading.MenuQrCategoryID);
        }






    }
}