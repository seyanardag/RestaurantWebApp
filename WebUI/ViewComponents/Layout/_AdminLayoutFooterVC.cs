using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layout
{
	public class _AdminLayoutFooterVC : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
