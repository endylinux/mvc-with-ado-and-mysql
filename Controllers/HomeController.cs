﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADO.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "The application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "My contact page.";

			return View();
		}
	}
}