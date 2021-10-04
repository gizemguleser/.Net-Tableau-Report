using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Data
    {
        public string sipNo { get; set; }
        public string kargoSatisKod { get; set; }
        public string odemeTarih { get; set; }
        public string kargolamaTarih { get; set; }
        public string onaylamaTarih { get; set; }
        public string iptalTarih { get; set; }
        public string kobi { get; set; }
        public string kobiUye { get; set; }
        public string domain { get; set; }
        public string domainUye { get; set; }
        public string uye { get; set; }
        public string urun { get; set; }
        public double tutar { get; set; }
        public string tip { get; set; }
        public string kargo { get; set; }
        public string sonDurum { get; set; }
        public string kobiDurum { get; set; }
        public int? SiparisAy { get; set; }
        public int? SiparisYil { get; set; }
        public double? TeslimSuresi { get; set; }

    }
}