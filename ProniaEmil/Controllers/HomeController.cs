using Microsoft.AspNetCore.Mvc;

namespace ProniaEmil.Controllers
{
    public class HomeController : Controller
    {
        public async Task <IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Shop()
        {
            return View();
        }
        public async Task<IActionResult> Blog()
        {
            return View();
        }
        public async Task<IActionResult> AboutUs()
        {
            return View();
        }
        public async Task<IActionResult> Pages()
        {
            return View();
        }
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }
    }
}
