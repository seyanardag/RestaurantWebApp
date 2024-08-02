using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILaayoutComponents
{
    public class _UILayoutHeadVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
