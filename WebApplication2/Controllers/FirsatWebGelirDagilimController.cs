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
    public class FirsatWebGelirDagilimController : Controller
    {
        // GET: FirsatWebGelirDagilim
        public ActionResult Index()
		{

			return View();
		}
		[HttpPost]
		public JsonResult List()
		{
			int draw = Convert.ToInt32(Request.Form["draw"]);// etkin sayfa numarası
			int start = Convert.ToInt32(Request["start"]);//listenen ilk kayıtın  index numarası
			int length = Convert.ToInt32(Request["length"]);//sayfadaki toplam listelenecek kayit sayısı
			string search = Request["search[value]"];//arama
			string sortColumnName = Request["columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]"];//Sıralama yapılacak column adı
			string sortDirection = Request["order[0][dir]"];//sıralama türü


			IData<FirsatWebGelirDagilim> list = new XmlData<FirsatWebGelirDagilim>("FirsatWebGelirDagilim");
			var res = list.Get();
			var data = res.List.OrderByDescending(x=>x.Yildizseviye).Skip(start).Take(length).ToList();
			return Json(new { data = data, draw = Request["draw"], recordsTotal = res.TotalCount, recordsFiltered = res.TotalCount });
		}

	}
}