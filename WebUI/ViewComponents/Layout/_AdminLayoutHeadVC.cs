using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layout
{
	public class _AdminLayoutHeadVC : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
