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
    public class AylikController : Controller
    {
        // GET: Aylik
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<Aylik> ayList = new List<Aylik>();
            ayList = (from n in res
                      group new { n } by new { n.SiparisAy } into grp
                      select new Aylik
                      {
                          Ay = (int)grp.Key.SiparisAy,
                          Adet = grp.Count(),
                          Ciro = grp.Sum(x => x.n.tutar),
                          AdetbasiCiro = grp.Sum(x => x.n.tutar) / grp.Count()
                      }).ToList();

            return View(ayList);
        }
    }
}