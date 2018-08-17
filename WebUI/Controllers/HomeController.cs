using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Data;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                AnaSayfaDTO anaSayfa = new AnaSayfaDTO();
                anaSayfa.slider = context.Slider.Where(x => (x.BaslangicTarih <= DateTime.Now && x.BitisTarih > DateTime.Now)).ToList();
                anaSayfa.yeniurunps4 = context.Urun.Where(x => x.Tip == 1).OrderByDescending(x => x.ID).Take(5).ToList();
                anaSayfa.yeniurunxbox = context.Urun.Where(x => x.Tip == 2).OrderByDescending(x => x.ID).Take(5).ToList();
                anaSayfa.yeniurunpc = context.Urun.Where(x => x.Tip == 3).OrderByDescending(x => x.ID).Take(5).ToList();
                anaSayfa.fiyatagoreps4 = context.Urun.Where(x => x.Tip == 1).OrderByDescending(x => x.Fiyat).Take(8).ToList();
                anaSayfa.fiyatagorexbox = context.Urun.Where(x => x.Tip == 2).OrderByDescending(x => x.Fiyat).Take(8).ToList();
                anaSayfa.fiyatagorepc = context.Urun.Where(x => x.Tip == 3).OrderByDescending(x => x.Fiyat).Take(8).ToList();

                return View(anaSayfa);
            }
        }
       
        public ActionResult PS4Oyun()
        {
            ViewBag.Message = "PS4 Oyun";
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Urun> Ps4Oyun = context.Urun.OrderBy(x => x.UrunAdi).ToList();
                return View(Ps4Oyun);
            }
        }

        public ActionResult OyunDetails(int UrunID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                Urun oyunDetails = context.Urun.FirstOrDefault(x => x.ID == UrunID);
                return View(oyunDetails);
            }
        }

        public ActionResult AksesuarDetails(int AksesuarID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                Aksesuar aksesuarDetails = context.Aksesuar.FirstOrDefault(x => x.ID == AksesuarID);
                return View(aksesuarDetails);
            }
        }
        public ActionResult KuponDetails(int KuponID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                Kupon kuponDetails = context.Kupon.FirstOrDefault(x => x.ID == KuponID);
                return View(kuponDetails);
            }
        }

        public ActionResult KonsolDetails(int KonsolID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                Konsol konsolDetails = context.Konsol.FirstOrDefault(x => x.ID == KonsolID);
                return View(konsolDetails);
            }
        }

        public ActionResult XBOneOyun()
        {
            ViewBag.Message = "XB ONE Oyun";
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Urun> XBOneOyun = context.Urun.OrderBy(x => x.UrunAdi).ToList();
                return View(XBOneOyun);
            }
        }
        public ActionResult PSKonsol()
        {
            ViewBag.Message = "PS Konsol";
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Konsol> PSKonsol = context.Konsol.OrderBy(x => x.KonsolAdi).ToList();
                return View(PSKonsol);
            }
        }
        public ActionResult XBKonsol()
        {
            ViewBag.Message = "XB Konsol";
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Konsol> XBKonsol = context.Konsol.OrderBy(x => x.KonsolAdi).ToList();
                return View(XBKonsol);
            }
        }
        public ActionResult PCOyun()
        {
            ViewBag.Message = "PC Oyun";
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Urun> PCOyun = context.Urun.OrderBy(x => x.UrunAdi).ToList();
                return View(PCOyun);
            }
        }

        public ActionResult Kupon()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Kupon> kupon = context.Kupon.OrderBy(x => x.KuponAd).ToList();
                return View(kupon);
            }
        }
        public ActionResult Aksesuar()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                List<Aksesuar> aksesuar = context.Aksesuar.OrderBy(x => x.AksesuarAd).ToList();
                return View(aksesuar);
            }
        }
        [HttpPost]
        public ActionResult Contact(Oneri iletisimform)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    Oneri _iletisimform = new Oneri();
                    _iletisimform.AdSoyad = iletisimform.AdSoyad;
                    _iletisimform.Telefon = iletisimform.Telefon;
                    _iletisimform.Eposta = iletisimform.Eposta;
                    _iletisimform.Mesaj = iletisimform.Mesaj;
                    _iletisimform.Tarih = DateTime.Now;
                    context.Oneri.Add(_iletisimform);
                    context.SaveChanges();
                    TempData["Mesaj"] = "Form Başarıyla gönderilmiştir.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        public ActionResult ChangeCulture(string dil, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(dil);
            return Redirect(returnUrl);
        }
    }
    public class AnaSayfaDTO
    {
        public List<Urun> yeniurunps4 { get; set; }
        public List<Urun> yeniurunxbox { get; set; }
        public List<Urun> yeniurunpc { get; set; }      
        public List<Urun> fiyatagoreps4 { get; set; }
        public List<Urun> fiyatagorexbox { get; set; }
        public List<Urun> fiyatagorepc { get; set; }
        public List<Slider> slider { get; set; }
                      
    }
}