using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithADO.Models;

namespace MVCWithADO.Controllers
{
	public class NavigationController : Controller
	{
		// GET: Navigation
		public ActionResult Menu()
		{
			IList<MenuViewModel> menuViewModel = new List<MenuViewModel>();

			var menu = new MenuViewModel();
			menu = new MenuViewModel() { MenuId = 1, Action = "Index", Controller = "Home", IsAction = true, Class = "nav-link", SubMenu = null, Title = "Home" };
			menuViewModel.Add(menu);
			
			menu = new MenuViewModel() { MenuId = 2, IsAction = false, Class = "nav-link dropdown-toggle", Title = "Projects",  };
			menuViewModel.Add(menu);
			menu.SubMenu = new List<MenuViewModel>();
			MenuViewModel subMenu = new MenuViewModel() { Action = "Index", Controller = "Student", IsAction = true, Class = "dropdown-item", SubMenu = null, Title = "Student-List" };
			menu.SubMenu.Add(subMenu);

			subMenu = new MenuViewModel() { Action = "Index", Controller = "Video", IsAction = true, Class = "dropdown-item", SubMenu = null, Title = "Youtube-List" };
			menu.SubMenu.Add(subMenu);

			menu = new MenuViewModel() { MenuId = 3, Action = "About", Controller = "Home", IsAction = true, Class = "nav-link", SubMenu = null, Title = "About Me" };
			menuViewModel.Add(menu);

			menu = new MenuViewModel() { MenuId = 4, Action = "Contact", Controller = "Home", IsAction = true, Class = "nav-link", SubMenu = null, Title = "Contact" };
			menuViewModel.Add(menu);

			return PartialView("_Navigation", menuViewModel);
		}
	}
}