using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Data;

namespace WebUI.Controllers
{
    public class KurumsalController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda";

            return View();
        }
        public ActionResult KurumsalSatis()
        {
            ViewBag.Message = "Kurumsal Satış";

            return View();
        }
        public ActionResult InsanKaynaklari()
        {
            ViewBag.Message = "İnsan Kaynakları";

            return View();
        }

        public ActionResult AlisverisKlavuzu()
        {
            ViewBag.Message = "Alışveriş Klavuzu";

            return View();
        }
        public ActionResult UrunIadeSartlari()
        {
            ViewBag.Message = "Ürün İade Şartları";

            return View();
        }
        public ActionResult GizlilikTaahhudu()
        {
            ViewBag.Message = "Gizlilik Taahhüdü";

            return View();
        }
        public ActionResult KargoSorgulama()
        {
            ViewBag.Message = "Kargo Sorgulama";

            return View();
        }
        public ActionResult eTicaret()
        {
            ViewBag.Message = "E-Ticaret";

            return View();
        }
    }
}