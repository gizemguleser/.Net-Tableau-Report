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
    public class DomainTopAlisverisController : Controller
    {
        // GET: DomainTopAlisveris
        public ActionResult Index()
        {
            IData<DomainTopAlisveris> list = new XmlData<DomainTopAlisveris>("DomainTopAlisveris");
            var res = list.Get();
            var data = res.List.ToList();
            return View(data);
            //         IData<Data> list = new XmlData<Data>("Data");
            //var res = list.Get().List;


            //         List<DomainTopAlisveris> domainList = new List<DomainTopAlisveris>();

            //         domainList = (from n in res
            //                       where n.iptalTarih != "" &&
            //                       ( n.odemeTarih!=null)
            //                       group n by new { n.domain,n.domainUye } into grp
            //                       select new DomainTopAlisveris
            //                       {
            //                           uye=grp.Key.domainUye,
            //                           domain = grp.Key.domain,
            //                           topCiro = grp.Sum(x => x.tutar),
            //                           son6 = grp.Where(x => DateTime.Parse(x.odemeTarih).Year== DateTime.Now.AddMonths(-6).Year && DateTime.Parse(x.odemeTarih).Month == DateTime.Now.AddMonths(-6).Month).Sum(x => x.tutar),
            //                           son5 = grp.Where(x => DateTime.Parse(x.odemeTarih).Year == DateTime.Now.AddMonths(-5).Year && DateTime.Parse(x.odemeTarih).Month == DateTime.Now.AddMonths(-5).Month).Sum(x => x.tutar),
            //                           son4 = grp.Where(x => DateTime.Parse(x.odemeTarih).Year == DateTime.Now.AddMonths(-4).Year && DateTime.Parse(x.odemeTarih).Month == DateTime.Now.AddMonths(-4).Month).Sum(x => x.tutar),
            //                           son3 = grp.Where(x => DateTime.Parse(x.odemeTarih).Year == DateTime.Now.AddMonths(-3).Year && DateTime.Parse(x.odemeTarih).Month == DateTime.Now.AddMonths(-3).Month).Sum(x => x.tutar),
            //                           son2 = grp.Where(x => DateTime.Parse(x.odemeTarih).Year == DateTime.Now.AddMonths(-2).Year && DateTime.Parse(x.odemeTarih).Month == DateTime.Now.AddMonths(-2).Month).Sum(x => x.tutar),
            //                           son1 = grp.Where(x => DateTime.Parse(x.odemeTarih).Year == DateTime.Now.AddMonths(-1).Year && DateTime.Parse(x.odemeTarih).Month == DateTime.Now.AddMonths(-1).Month).Sum(x => x.tutar),
            //                           buay = grp.Where(x => DateTime.Parse(x.odemeTarih) >= DateTime.Now).Sum(x => x.tutar)
            //                       }).ToList();
            //         return View(domainList);
        }

	}
}

