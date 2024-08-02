using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILaayoutComponents
{
    public class _UILayoutScriptVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
