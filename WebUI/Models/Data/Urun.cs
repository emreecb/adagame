using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Data
{
    public class Urun
    {
        [Key]
        public int ID { get; set; }
        public byte[] Foto { get; set; }
        public string UrunAdi { get; set; }
        public string Fiyat { get; set; }
        public string UrunIcerik { get; set; }
        public int Tip { get; set; }
    }
}