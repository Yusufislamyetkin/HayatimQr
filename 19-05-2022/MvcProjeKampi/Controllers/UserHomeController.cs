using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{

    public class UserHomeController : Controller
    {
        // GET: UserHome
        PetQRManager pqrm = new PetQRManager(new EFPetQRDal());
        UserManager um = new UserManager(new EFUserDal());
        ContactManager cm = new ContactManager(new EFContactDal());


        public User SessionValue()
        {
            string p;
            p = (string)Session["UserSystemName"];
            var UserValue = um.GetSessionValue(p);
            return UserValue;
        }

        public ActionResult UserWelcomePage()
        {


            return View();
        }


     
        [Authorize(Roles = "A")]
        public ActionResult HowToUse()
        {
           

            return View(SessionValue());
        }

    



        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult QRUpdate()
        {
            ViewBag.userValue = SessionValue();
          var petqrValue =  pqrm.GetByID(SessionValue().UserID);
            return View(petqrValue);
        }


        [HttpPost]
        public ActionResult QRUpdate(PetQR petQR)
        {


            //try
            //{
            Random randm = new Random();

            if (Request.Files.Count > 0)
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                if (filename == "")
                {
                    
                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));
                        petQR.PetImage = "/ımage/" + filename + rdn + uzanti;
                    }
                }


            }

           
            var petqrValue = pqrm.GetByID(SessionValue().UserID);

            petqrValue.PetAge = petQR.PetAge;
            petqrValue.PetImage = petQR.PetImage;
            petqrValue.PetName = petQR.PetName;
            petqrValue.PetOwnerName = petQR.PetOwnerName;
            petqrValue.PetOwnerPhone = petQR.PetOwnerPhone;
            petqrValue.PetOwnerSurName = petQR.PetOwnerSurName;
            petqrValue.PetWarning = petQR.PetWarning;
            petqrValue.PetWarning2 = petQR.PetWarning2;
            petqrValue.SpecialNote = petQR.SpecialNote;
            


            pqrm.PetQRUpdate(petqrValue);

            TempData["AlertMessage1"] = "PetQr Sayfanız Güncellendi.";
            return RedirectToAction("QRUpdate");

    



        }

        [Authorize(Roles = "A")]
        public ActionResult QRView()
        {
    
           var viewpetqr = pqrm.GetByID(SessionValue().UserID);
           ViewBag.UserName = SessionValue().UserName;
           ViewBag.UserSurname = SessionValue().UserSurname;
           ViewBag.UserImage = SessionValue().UserImage;

            return View(viewpetqr);
        }



        [HttpGet]
        public ActionResult Contact()
        {

            

            return View(SessionValue());
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
          
            contact.UserID = SessionValue().UserID;

            cm.AddValue(contact);

            TempData["AlertMessage1"] = "Destek Talebi Gönderildi.";
            return RedirectToAction("Contact");
        }

        public ActionResult ContactFollow()
        {
          

            ViewBag.uservalue = SessionValue();
            int userid = SessionValue().UserID;


            var requestList = cm.GetByUserID(userid);

            return View(requestList);
        }


        [HttpGet]
        public ActionResult ProfilSetting()
        {
         




            return View(SessionValue());
        }

        [HttpPost]
        public ActionResult ProfilSetting(User user)
        {
            string p;
            p = (string)Session["UserSystemName"];
            var userValue = um.GetSessionValue(p);



            Random randm = new Random();

            if (Request.Files.Count > 0)
            {
                string rdn = Convert.ToString(randm.Next(0, 9999));
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + rdn + uzanti;

                if (filename == "")
                {

                }
                else
                {
                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {

                        Request.Files[0].SaveAs(Server.MapPath(yol));
                        user.UserImage = "/ımage/" + filename + rdn + uzanti;
                    }
                }


            }



            if (user.UserPasswordOld == userValue.UserPassword)
            {

                user.UserPasswordOld = null;
                userValue.UserPassword = user.UserPassword;
                userValue.UserImage = user.UserImage;
                TempData["AlertMessage1"] = "Güncelleme Yapıldı ";
                um.Update(userValue);
                return RedirectToAction("ProfilSetting");
            }
            else
            {
                TempData["AlertMessage2"] = "Güncelleme Yapılamadı ";
                return RedirectToAction("ProfilSetting");
            }


        }

    }
}