using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.ViewModels.Categories;

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
            var data = await _context.Categories
                .Where(x => !x.IsDeleted)
                .Select(x => new GetCategoryVM
                 {
                    Id=x.Id,
                    Name=x.Name
                 }
                )
                .OrderByDescending(x => x.Id)
                .Take(4).ToListAsync();

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
