﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layout
{
	public class _AdminLayoutScriptVC : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}