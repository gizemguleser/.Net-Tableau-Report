using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Sorunlu
    {
        public string sonDurum { get; set; }
        public int Adet { get; set; }
        public double toplamTutar { get; set; }
        public double adetYuzde { get; set; }
        public string tedarikci { get; set; }
        public int sipAy { get; set; }
        public bool sorunluMu {
            get
            {
                return
                    sonDurum == "İade Talebi Oluşturuldu" ||
                    sonDurum == "Üye İptal Etti" ||
                    sonDurum == "Üye İş Yeri İptal Etti" ? true : false;
            }
        }

        public int sira {
            get {
                return sorunluMu ? 0 : 1;
            } 
        }

    }
}