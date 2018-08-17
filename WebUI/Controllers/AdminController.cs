using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Data;

namespace WebUI.Controllers
{
    [Authorize(Roles ="Admin, SuperAdmin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region // Slider

        public ActionResult Slider()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var slider = context.Slider.ToList();
                return View(slider);
            }
        }
        public ActionResult SlideEkle()
        {
            return View();
        }
        public ActionResult SlideDuzenle(int SlideID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var _slideDuzenle = context.Slider.Where(x => x.ID == SlideID).FirstOrDefault();
                return View(_slideDuzenle);
            }
        }
        public ActionResult SlideSil(int SlideID)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    context.Slider.Remove(context.Slider.First(d => d.ID == SlideID));
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult SlideEkle(Slider s, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    Slider _slide = new Slider();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slide.SliderFoto = memoryStream.ToArray();
                    }
                    _slide.SliderText = s.SliderText;
                    _slide.BaslangicTarih = s.BaslangicTarih;
                    _slide.BitisTarih = s.BitisTarih;
                    context.Slider.Add(_slide);
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult SlideDuzenle(Slider slide, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    var _slideDuzenle = context.Slider.Where(x => x.ID == slide.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slideDuzenle.SliderFoto = memoryStream.ToArray();
                    }
                    _slideDuzenle.SliderText = slide.SliderText;
                    _slideDuzenle.BaslangicTarih = slide.BaslangicTarih;
                    _slideDuzenle.BitisTarih = slide.BitisTarih;
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Kupon

        public ActionResult Kupon()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var kupon = context.Kupon.ToList();
                return View(kupon);
            }
        }
        public ActionResult KuponEkle()
        {
            return View();
        }
        public ActionResult KuponDuzenle(int KuponID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var _kuponDuzenle = context.Kupon.Where(x => x.ID == KuponID).FirstOrDefault();
                return View(_kuponDuzenle);
            }
        }
        public ActionResult KuponSil(int KuponID)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    context.Kupon.Remove(context.Kupon.First(d => d.ID == KuponID));
                    context.SaveChanges();
                    return RedirectToAction("Kupon", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult KuponEkle(Kupon b, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    Kupon _kupon = new Kupon();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _kupon.KuponFoto = memoryStream.ToArray();
                    }
                    _kupon.KuponAd = b.KuponAd;
                    _kupon.KuponIcerik = b.KuponIcerik;
                    _kupon.KuponFiyat = b.KuponFiyat;
                    context.Kupon.Add(_kupon);
                    context.SaveChanges();
                    return RedirectToAction("Kupon", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult KuponDuzenle(Kupon b, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    var _kuponDuzenle = context.Kupon.Where(x => x.ID == b.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _kuponDuzenle.KuponFoto = memoryStream.ToArray();
                    }
                    _kuponDuzenle.KuponAd = b.KuponAd;
                    _kuponDuzenle.KuponIcerik = b.KuponIcerik;
                    _kuponDuzenle.KuponFiyat = b.KuponFiyat;
                    context.SaveChanges();
                    return RedirectToAction("Kupon", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Aksesuar

        public ActionResult Aksesuar()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var aksesuar = context.Aksesuar.ToList();
                return View(aksesuar);
            }
        }
        public ActionResult AksesuarEkle()
        {
            return View();
        }
        public ActionResult AksesuarDuzenle(int AksesuarID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var _aksesuarDuzenle = context.Aksesuar.Where(x => x.ID == AksesuarID).FirstOrDefault();
                return View(_aksesuarDuzenle);
            }
        }
        public ActionResult AksesuarSil(int AksesuarID)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    context.Aksesuar.Remove(context.Aksesuar.First(d => d.ID == AksesuarID));
                    context.SaveChanges();
                    return RedirectToAction("Aksesuar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult AksesuarEkle(Aksesuar b, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    Aksesuar _aksesuar = new Aksesuar();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _aksesuar.AksesuarFoto = memoryStream.ToArray();
                    }
                    _aksesuar.AksesuarAd = b.AksesuarAd;
                    _aksesuar.AksesuarIcerik = b.AksesuarIcerik;
                    _aksesuar.AksesuarFiyat = b.AksesuarFiyat;
                    context.Aksesuar.Add(_aksesuar);
                    context.SaveChanges();
                    return RedirectToAction("Aksesuar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult AksesuarDuzenle(Aksesuar b, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    var _aksesuarDuzenle = context.Aksesuar.Where(x => x.ID == b.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _aksesuarDuzenle.AksesuarFoto = memoryStream.ToArray();
                    }
                    _aksesuarDuzenle.AksesuarAd = b.AksesuarAd;
                    _aksesuarDuzenle.AksesuarIcerik = b.AksesuarIcerik;
                    _aksesuarDuzenle.AksesuarFiyat = b.AksesuarFiyat;
                    context.SaveChanges();
                    return RedirectToAction("Aksesuar", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Urun

        public ActionResult Urun()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var urun = context.Urun.ToList();
                return View(urun);
            }
        }
        public ActionResult UrunEkle()
        {
            return View();
        }
        public ActionResult UrunDuzenle(int UrunID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var _urunDuzenle = context.Urun.Where(x => x.ID == UrunID).FirstOrDefault();
                return View(_urunDuzenle);
            }
        }
        public ActionResult UrunSil(int UrunID)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    context.Urun.Remove(context.Urun.First(d => d.ID == UrunID));
                    context.SaveChanges();
                    return RedirectToAction("Urun", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun t, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    Urun _urun = new Urun();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _urun.Foto = memoryStream.ToArray();
                    }
                    _urun.UrunAdi = t.UrunAdi;
                    _urun.Fiyat = t.Fiyat;
                    _urun.UrunIcerik = t.UrunIcerik;
                    _urun.Tip = t.Tip;
                    context.Urun.Add(_urun);
                    context.SaveChanges();
                    return RedirectToAction("Urun", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult UrunDuzenle(Urun t, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    var _urunDuzenle = context.Urun.Where(x => x.ID == t.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _urunDuzenle.Foto = memoryStream.ToArray();
                    }
                    _urunDuzenle.UrunAdi = t.UrunAdi;
                    _urunDuzenle.UrunIcerik = t.UrunIcerik;
                    _urunDuzenle.Fiyat = t.Fiyat;
                    _urunDuzenle.Tip = t.Tip;
                    context.SaveChanges();
                    return RedirectToAction("Urun", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        #region // Konsol

        public ActionResult Konsol()
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var konsol = context.Konsol.ToList();
                return View(konsol);
            }
        }
        public ActionResult KonsolEkle()
        {
            return View();
        }
        public ActionResult KonsolDuzenle(int KonsolID)
        {
            using (AdaGameContext context = new AdaGameContext())
            {
                var _konsolDuzenle = context.Konsol.Where(x => x.ID == KonsolID).FirstOrDefault();
                return View(_konsolDuzenle);
            }
        }
        public ActionResult KonsolSil(int KonsolID)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    context.Konsol.Remove(context.Konsol.First(d => d.ID == KonsolID));
                    context.SaveChanges();
                    return RedirectToAction("Konsol", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [HttpPost]
        public ActionResult KonsolEkle(Konsol t, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    Konsol _konsol = new Konsol();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _konsol.KonsolFoto = memoryStream.ToArray();
                    }
                    _konsol.KonsolAdi = t.KonsolAdi;
                    _konsol.Fiyat = t.Fiyat;
                    _konsol.Tip = t.Tip;
                    context.Konsol.Add(_konsol);
                    context.SaveChanges();
                    return RedirectToAction("Konsol", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu");
            }
        }
        [HttpPost]
        public ActionResult KonsolDuzenle(Konsol t, HttpPostedFileBase file)
        {
            try
            {
                using (AdaGameContext context = new AdaGameContext())
                {
                    var _konsolDuzenle = context.Konsol.Where(x => x.ID == t.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _konsolDuzenle.KonsolFoto = memoryStream.ToArray();
                    }
                    _konsolDuzenle.KonsolAdi = t.KonsolAdi;
                    _konsolDuzenle.Fiyat = t.Fiyat;
                    _konsolDuzenle.Tip = t.Tip;
                    context.SaveChanges();
                    return RedirectToAction("Konsol", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion
        }
}