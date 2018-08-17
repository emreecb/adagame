using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.Data
{
    public class Aksesuar
    {
        [Key]
        public int ID { get; set; }
        public byte[] AksesuarFoto { get; set; }
        public string AksesuarAd { get; set; }
        public string AksesuarFiyat { get; set; }
        public string AksesuarIcerik { get; set; }
       
    }
}