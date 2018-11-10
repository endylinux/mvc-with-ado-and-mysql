using MVCWithADO.Models;
using MVCWithADO.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADO.Controllers
{
	public class HomeController : Controller
	{

		[TraceFilter]
		public ActionResult Index()
		{
			
			return View();
		}

		[TraceFilter]
		public ActionResult About()
		{
			ViewBag.Message = "The application description page.";

			return View();
		}

		[TraceFilter]
		public ActionResult Contact()
		{
			ViewBag.Message = "My contact page.";

			return View();
		}

		public ActionResult TrackingList()
		{
			TrackingViewModel trackingModel = new TrackingViewModel();
			DataTable dt = trackingModel.GetAllTrackingStates();
			return View("TrackingList", dt);
		}
	}
}