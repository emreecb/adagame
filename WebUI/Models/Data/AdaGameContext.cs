using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.Models.Data
{
    public class AdaGameContext : DbContext
    {
        public DbSet<Kupon> Kupon { get; set; }
        public DbSet<Oneri> Oneri { get; set; }
        public DbSet<Konsol> Konsol { get; set; }
        public DbSet<Aksesuar> Aksesuar { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Urun> Urun { get; set; }
    }    
}