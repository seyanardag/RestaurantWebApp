using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layout
{
	public class _AdminLayoutTopHeaderVC : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
