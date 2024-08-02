using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
	[AllowAnonymous]

	public class HomeController : Controller
    {

        public IActionResult UILayout()
        {
            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }
        
        public IActionResult MenuPage()
        {
            return View();
        }
        
        public IActionResult AboutPage()
        {
            return View();
        }
           
        public IActionResult BookTable()
        {
            return View();
        }

      


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
