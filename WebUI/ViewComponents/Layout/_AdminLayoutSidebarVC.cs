﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layout
{
	public class _AdminLayoutSidebarVC : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
