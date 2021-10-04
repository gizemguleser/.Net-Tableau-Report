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
    public class TedarikciKargoController : Controller
    {
        public class Sonuc
        {
            public List<TedarikciKargo> tedarikciKargolist { get; set; }


        }
        // GET: TedarikciKargo
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<TedarikciKargo> tedKargolist = new List<TedarikciKargo>();

            tedKargolist = (from n in res
                             select new TedarikciKargo
                             {
                                 Kobi = n.kobi,
                                 Kargo = n.kargo
                             }).ToList();

            Sonuc sonuc = new Sonuc();
            sonuc.tedarikciKargolist = tedKargolist;
            return View(sonuc);
        }
    }
}