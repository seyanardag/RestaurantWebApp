using BusinessLayer.CustomServices.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Dtos.RegisterUserDto;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IFileUploadService _fileUploadService;


        public RegisterController(UserManager<CustomUser> userManager, IFileUploadService fileUploadService)
        {
            _userManager = userManager;
            _fileUploadService = fileUploadService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDtoUI registerUserDtoUI)
        {
            var newUser = new CustomUser()
            {
                Name = registerUserDtoUI.NameForRegister,
                Surname = registerUserDtoUI.SurnameForRegister,
                UserName = registerUserDtoUI.UserNameForRegister,
                Email = registerUserDtoUI.EmailForRegister,
                ImageUrl = registerUserDtoUI.ImageUrl

            };

            newUser.ImageUrl = await _fileUploadService.UploadFileAsync(registerUserDtoUI.ImageFile, "images/UserImages");
           

            var result = await _userManager.CreateAsync(newUser, registerUserDtoUI.PasswordForRegister);
            if(result.Succeeded)
            {
                return RedirectToAction("TablesRealtime", "RestaurantTable");
            }

            return View(registerUserDtoUI);
        }


	}
}
