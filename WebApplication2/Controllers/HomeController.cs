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
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			IData<FaaliyetRapor> list = new XmlData<FaaliyetRapor>("FaaliyetRapor");
			var res = list.Get();
			var data = res.List.ToList();

			return View(data);
		}

	}


}
