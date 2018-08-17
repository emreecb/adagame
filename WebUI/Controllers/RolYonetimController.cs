using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RolYonetimController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: RolYonetim
        public ActionResult Index()
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var model = roleManager.Roles.ToList();

            return View(model);
        }

        public ActionResult RolEkle()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult RolEkle(RolEkle rol)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (roleManager.RoleExists(rol.RolAdi) == false)
            {
                roleManager.Create(new IdentityRole(rol.RolAdi));
            }
            return RedirectToAction("Index");
        }
        public ActionResult RolKullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RolKullaniciEkle(RolKullaniciEkle model)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var kullanici = userManager.FindByName(model.KullaniciAdi);

            if(!userManager.IsInRole(kullanici.Id, model.RolAdi))
            { 
                userManager.AddToRole(kullanici.Id, model.RolAdi);
            }
            return RedirectToAction("Index");
        }        


    }
}