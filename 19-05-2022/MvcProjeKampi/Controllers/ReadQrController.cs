using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class ReadQrController : Controller
    {
        // GET: ReadQr

        UserManager um = new UserManager(new EFUserDal());
        ContactManager cm = new ContactManager(new EFContactDal());
        MenuQrManager mqm = new MenuQrManager(new EFMenuQrDal());
        MenuQrCategoryManager mqcm = new MenuQrCategoryManager(new EFMenuQrCategoryDal());
        MenuQrHeadingManager mqhm = new MenuQrHeadingManager(new EFMenuQrHeadingDal());
        PetQRManager pqrm = new PetQRManager(new EFPetQRDal());


        public ActionResult Index()
        {
            return View();
        }

        public User SessionValue()
        {
            string p;
            p = (string)Session["UserSystemName"];
            var UserValue = um.GetSessionValue(p);
            return UserValue;
        }

        public static string MD5Create(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public ActionResult PublicRedirectMenu()
        {

            int id = SessionValue().UserID;

            return RedirectToAction("PublicMenuQr", new { id = id });

        }


        public ActionResult PublicRedirectPet()
        {

            int id = SessionValue().UserID;

            return RedirectToAction("PublicPetQr", new { id = id });

        }

    

        public ActionResult PublicPetQr(string id)
        {
          
            var viewpetqr = pqrm.GetByIDHash(id);
    

            return View(viewpetqr);
        }


        public ActionResult PublicMenuQr(int id)
        {
                        
                var ListCategories = mqcm.GetByUserID(id);

                return View(ListCategories);
            
           
        }

        public ActionResult PublicMenuContentQr(int id)
        {


            var ListCategories = mqhm.GetByIDListWithCat(id);

            return View(ListCategories);


        }



        public ActionResult PublicRedirectMyQrMenu()
        {

            int id = SessionValue().UserID;

            return RedirectToAction("MyQrCodeMenu", new { id = id });

        }

        [HttpGet]
        public ActionResult MyQrCodeMenu(int id)
        {
        
           
         


            string v = "https://Localhost:44329/ReadQr/PublicMenuQr/";
            string pageCode = v + id;
            
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator createQR = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCde = createQR.CreateQrCode(pageCode, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap qrPicture = qrCde.GetGraphic(20))
                {
                    qrPicture.Save(ms, ImageFormat.Png);
                    byte[] btteImage = ms.ToArray();
                    ViewBag.qrcodeImage = "data:image/png;base64," + Convert.ToBase64String(btteImage);
                    ViewBag.qrcodeLınk = pageCode;


                }
            }

           var userValue =   um.GetByID(id);
           

         

            return View(userValue);
        }



        public ActionResult PublicRedirectMyPetQr()
        {

            int id = SessionValue().UserID;

            return RedirectToAction("MyQrCodePet", new { id = id });

        }

        [HttpGet]
        public ActionResult MyQrCodePet(int id)
        {

            string STid = Convert.ToString(id);
            string Hashid = MD5Create(STid);
            string Hashid2 = MD5Create(Hashid);
            string Hashid3 = MD5Create(Hashid2);


            string v = "https://Localhost:44329/ReadQr/PublicPetQr/";


            string pageCode = v + Hashid3;

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator createQR = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCde = createQR.CreateQrCode(pageCode, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap qrPicture = qrCde.GetGraphic(20))
                {
                    qrPicture.Save(ms, ImageFormat.Png);
                    byte[] btteImage = ms.ToArray();
                    ViewBag.qrcodeImage = "data:image/png;base64," + Convert.ToBase64String(btteImage);
                    ViewBag.qrcodeLınk = pageCode;


                }
            }

            var userValue = um.GetByID(id);

            userValue.UserHash = Hashid3;
            um.Update(userValue);

            return View(userValue);
        }



    }
}