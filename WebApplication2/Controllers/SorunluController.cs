using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication2.Controllers
{
    public class SorunluController : Controller
    {
        public class Sonuc
        {
            public List<Sorunlu> SorunluList { get; set; }
            public List<SiparisDurum> SiparisDurumList { get; set; }

        }
        // GET: Sorunlu
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<Sorunlu> sorunList = new List<Sorunlu>();
            sorunList = (from n in res
                         group new { n } by new { n.sonDurum } into grp
                         select new Sorunlu
                         {
                             sonDurum = grp.Key.sonDurum,
                             Adet = grp.Count(),
                             toplamTutar = grp.Sum(x => x.n.tutar)
                         }).OrderBy(x=>x.sira).ToList();



            List<SiparisDurum> siparisDurumList = new List<SiparisDurum>();
            siparisDurumList = (from n in res
                                select new SiparisDurum
                                {
                                    ay = (int)n.SiparisAy,
                                    durum = n.sonDurum,
                                    tedarikci = n.kobi
                                }).ToList();

            Sonuc sonuc = new Sonuc();
            sonuc.SorunluList = sorunList;
            sonuc.SiparisDurumList = siparisDurumList;
            return View(sonuc);
        }
    }
}