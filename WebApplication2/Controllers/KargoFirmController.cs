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
    public class KargoFirmController : Controller
    {
        public class Sonuc2
        {
            public List<KargoFirm> KargoList { get; set; }
            public List<Kargofirmay> KargofirmList { get; set; }
        }
  
        // GET: KargoFirm
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<KargoFirm> kargolist = new List<KargoFirm>();
            kargolist = (from n in res
                         group new { n } by new { n.kargo } into grp
                         select new KargoFirm
                         {
                             Kargo = grp.Key.kargo,
                             Adet = grp.Count(),
                             Ciro = grp.Sum(x => x.n.tutar),
                             AdetbasiCiro = grp.Sum(x => x.n.tutar) / grp.Count(),
                             sira = grp.Key.kargo == "ptt (tekkart)" ? 0 :
                                    grp.Key.kargo == "sürat kargo(tekkart)" ? 1 :
                                    grp.Key.kargo == "yurt içi kargo" ? 2 :
                                    grp.Key.kargo == "aras kargo" ? 3 :
                                    grp.Key.kargo == "mng kargo" ? 4 :
                                    grp.Key.kargo == "sürat kargo" ? 5 :
                                    grp.Key.kargo == "ptt kargo" ? 6 :
                                    grp.Key.kargo == "ups kargo" ? 7 :
                                    grp.Key.kargo == "horoz lojistik" ? 8 :
                                    grp.Key.kargo == "Özel" ? 9 : 10
                         }).OrderBy(x => x.sira).ToList();

            List<Kargofirmay> kargoFirmList = new List<Kargofirmay>();
            kargoFirmList = (from n in res
                                select new Kargofirmay
                                {
                                    Kargo = n.kargo,
                                    Ay = (int)n.SiparisAy
                                }).ToList();

            Sonuc2 sonuc2 = new Sonuc2();
            sonuc2.KargoList = kargolist;
            sonuc2.KargofirmList = kargoFirmList;
            return View(sonuc2);
        }
    }
}