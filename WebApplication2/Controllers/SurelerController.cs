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
    public class SurelerController : Controller
    {
        public class Sonuc
        {
            public List<Sureler> surelerlist { get; set; }
        }
        // GET: Sureler
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<Sureler> sureList = new List<Sureler>();

            sureList = (from n in res
                            select new Sureler
                            {
                                Ay = (int)n.SiparisAy,
                                Teslimsuresi = n.TeslimSuresi
                            }).ToList();

            Sonuc sonuc = new Sonuc();
            sonuc.surelerlist = sureList;
            return View(sonuc);
        }
    }
}