using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
namespace WebApplication2.Models
{
    public class FaaliyetRapor
    {
        public int ay { get; set; }
        public int yil { get; set; }
        public int AlisverisAdet { get; set; }
        public int AlisverisUrunAdet { get; set; }
        public int kobiAlisvisAdet { get; set; }
        public int tutar { get; set; }
        public int kulPuan { get; set; }
        public int tedarikciOdeme { get; set; }
        public int paketAdet
        { get; set; }
        public int yenilemeAdet
        { get; set; }
        public double paketSatisGelir { get; set; }
        public double paketYenilemeGelir { get; set; }
        public int sistemGelir { get; set; }
    }
}