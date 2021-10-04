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
    public class TedarikciController : Controller
    {
        public class Sonuc
        {
            public List<Tedarikci> tedarikcilist { get; set; }


        }
        // GET: Tedarikci
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<Tedarikci> TedarikciList = new List<Tedarikci>();

            TedarikciList = (from n in res
                             select new Tedarikci
                             {
                                 Kobi = n.kobi,
                                 Ay = (int)n.SiparisAy
                             }).ToList();


            Sonuc sonuc = new Sonuc();
            sonuc.tedarikcilist = TedarikciList;
            return View(sonuc);
        }
    }
}