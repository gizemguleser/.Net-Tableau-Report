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
    public class TeslimController : Controller
    {
        // GET: Teslim
        public ActionResult Index()
        {
            IData<Data> list = new XmlData<Data>("Data");
            var res = list.Get().List;

            List<Teslim> teslimList = new List<Teslim>();
            teslimList = (from n in res
                          group new { n } by new { n.SiparisAy } into grp
                          select new Teslim
                          {
                              Ay = (int)grp.Key.SiparisAy,
                              Teslimsuresi = grp.Where(x => x.n.TeslimSuresi != null).Count() == 0 ? null : grp.Sum(x => x.n.TeslimSuresi) / grp.Where(x => x.n.TeslimSuresi != null).Count()
                          }).OrderByDescending(x => x.Ay).ToList();
            return View(teslimList);
        }
    }
}