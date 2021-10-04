using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
namespace WebApplication2.Models
{
    public class FirsatWebGelirDagilim
    {
        public int uyeID { get; set; }
        public string firmaAdi { get; set; }
        public string domain { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public int Yildizseviye { get; set; }
        public int webSatisGelir { get; set; }
        public int yildizKariyerGelir { get; set; }
        public int araciGelir { get; set; }
        public int paylasanGelir { get; set; }
        public int tavsiyeGelir { get; set; }
    }
}