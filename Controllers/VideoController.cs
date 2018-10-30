using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADO.Controllers
{
	public class VideoController : Controller
	{
		// GET: Video
		public ActionResult Index()
		{
			return View();
		}
	}
}