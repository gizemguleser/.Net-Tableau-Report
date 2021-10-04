using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication2.Models
{
    public class SiparisRaporgenel
    {
        public string sipNo { get; set; }
        public string kargoSatisKod { get; set; }
        public string odemeTarih{ get; set; }
        public string kargolamaTarih{ get; set; }
        public string onaylamaTarih{ get; set; }
        public string kobi{ get; set; }
        public string uye { get; set; }
        public string urun { get; set; }
        public double tutar { get; set; }
        public string tip { get; set; }
        public string kargo { get; set; }
        public string sonDurum { get; set; }
        public string kobiDurum { get; set; }
        public int SiparisAy { get; set; }
        public int SiparisYil { get; set; }
        public string TeslimSuresi { get; set; }
        public string yorumVarmi { get; set; }

    }
}