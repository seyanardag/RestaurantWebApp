using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.RegisterUserDto;

namespace WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;

        public ProfileController(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDtoUI userEditDtoUI= new UserEditDtoUI()
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                //Password = user.PasswordHash
            };
            return View(userEditDtoUI);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UserEditDtoUI userEditDtoUI)
        {

            CustomUser user = await _userManager.FindByNameAsync(User.Identity.Name);
    
           

            if (!ModelState.IsValid)
            {
                return View(userEditDtoUI);
            }


            if (userEditDtoUI.ImageFile != null)
            {
                string resource = Directory.GetCurrentDirectory() + "/wwwroot/images/UserImages/";
                string extension = Path.GetExtension(userEditDtoUI.ImageFile.FileName);

                string imageName = Guid.NewGuid().ToString() + extension;

                var saveLocation = resource + imageName;

                using var stream = new FileStream(saveLocation, FileMode.Create);

                await userEditDtoUI.ImageFile.CopyToAsync(stream);
                user.ImageUrl = "/images/UserImages/" + imageName; ;

            }
            user.Surname = userEditDtoUI.Surname;
            user.Name = userEditDtoUI.Name;
            user.Email = userEditDtoUI.Email;

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDtoUI.Password);

            //Kullanıcı Username i değiştirdiyse;
            if (userEditDtoUI.UserName != user.UserName)
            {
                user.UserName = userEditDtoUI.UserName;
                var result1 = await _userManager.UpdateAsync(user);

                if (result1.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(userEditDtoUI);

            }

            //Kullanıcı Username i değiştirmediyse;
            user.UserName = userEditDtoUI.UserName;
            var result2 = await _userManager.UpdateAsync(user);

            if (result2.Succeeded)
            {
                return RedirectToAction("Index", "Statistic");
            }

            return View(userEditDtoUI);
        }
    }
}
