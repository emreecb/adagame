using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Data
{
    public class Konsol
    {
        public int ID { get; set; }
        public byte[] KonsolFoto { get; set; }
        public string KonsolAdi { get; set; }
        public string Fiyat { get; set; }
        public int Tip { get; set; }
    }
}