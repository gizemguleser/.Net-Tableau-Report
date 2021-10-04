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
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<Urun> urunList = new List<Urun>();
            urunList = (from n in res
                        group new { n } by new { n.urun } into grp
                        select new Urun
                        {
                            Urunler = grp.Key.urun,
                            Adet = grp.Count(),
                            Ciro = grp.Sum(x => x.n.tutar)

                        }).OrderByDescending(x => x.Ciro).ToList();

            return View(urunList);
        }
    }
}