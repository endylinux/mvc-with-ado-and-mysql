using MVCWithADO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWithADO.Utilities
{
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	public sealed class TraceFilterAttribute : ActionFilterAttribute
	{
		private string Parameter { get; set; }
		private ActionDescriptor CurrentAction { get; set; }
		//private DateTime start_time;
		private Stopwatch stopwatch;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//start_time = DateTime.Now;
			stopwatch = new Stopwatch();
			stopwatch.Start();
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			stopwatch.Stop();
			string hostName = Dns.GetHostName();
			string ipAddress = HttpContext.Current.Request.UserHostAddress.ToString();
			RouteData routeData = filterContext.RouteData;
			long duration = stopwatch.ElapsedMilliseconds;
			string controller = (string)routeData.Values["controller"];
			string action = (string)routeData.Values["action"];
			var createdAt = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

			TrackingViewModel trackingModel = new TrackingViewModel();
			trackingModel.InsertTrackingStates(ipAddress, duration, controller, action, createdAt);
		}
	}
}