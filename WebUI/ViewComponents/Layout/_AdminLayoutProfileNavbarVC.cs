using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Layout
{
    public class _AdminLayoutProfileNavbarVC : ViewComponent
    {
        private readonly UserManager<CustomUser> _userManager;

        public _AdminLayoutProfileNavbarVC(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(currentUser);
        }
    }
}
