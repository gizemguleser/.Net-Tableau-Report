using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class SiparisDurum
    {
        public int ay { get; set; }
        public string durum { get; set; }
        public string tedarikci { get; set; }
        public bool sorunluMu
        {
            get
            {
                return
                    durum == "İade Talebi Oluşturuldu" ||
                    durum == "Üye İptal Etti" ||
                    durum == "Üye İş Yeri İptal Etti" ? true : false;
            }
        }
        public int sira
        {
            get
            {
                return sorunluMu ? 0 : 1;
            }
        }
    }
}