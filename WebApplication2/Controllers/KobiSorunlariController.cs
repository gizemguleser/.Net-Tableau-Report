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
    public class KobiSorunlariController : Controller
    {
        public class Sonuc
        {
           
            public List<KobiSorunlari> KobiSorunList { get; set; }

        }
        // GET: KobiSorunlari
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<KobiSorunlari> kobisorunList = new List<KobiSorunlari>();
            kobisorunList = (from n in res
                                select new KobiSorunlari
                                {
                                    ay = (int)n.SiparisAy,
                                    durum = n.sonDurum,
                                    tedarikci = n.kobi
                                }).ToList();

            Sonuc sonuc = new Sonuc();

            sonuc.KobiSorunList = kobisorunList;
            return View(sonuc);
        }
    }
}