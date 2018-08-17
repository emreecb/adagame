using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Data
{
    public class Kupon
    {
        [Key]
        public int ID { get; set; }
        public byte[] KuponFoto { get; set; }
        public string KuponAd { get; set; }
        public string KuponFiyat { get; set; }
        public string KuponIcerik { get; set; }
    }
}