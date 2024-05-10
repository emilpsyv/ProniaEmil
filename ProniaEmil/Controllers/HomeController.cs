using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.ViewModels.Categories;
using ProniaEmil.ViewModels.Sliders;

namespace ProniaEmil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaEContext _context;

        public HomeController(ProniaEContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {
            var data = await _context.Sliders.Where(x => !x.IsDeleted).Select(s => new GetSliderVM
            {
                Discount = s.Discount,
                Id = s.Id,
                ImgUrl = s.ImgUrl,

                SubTitle = s.SubTitle,
                Title = s.Title
            }).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> DeleteTest(int ? id)
        {
            if (id == null||id<1) return BadRequest();
            var categor = await _context.Categories.FindAsync(id);
            if (categor == null) return BadRequest();
            _context.Categories.Remove(categor);
            await _context.SaveChangesAsync();
            return Content(categor.Name);
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
