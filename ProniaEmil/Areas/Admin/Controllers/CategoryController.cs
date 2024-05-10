using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.ViewModels.Categories;


namespace ProniaEmil.Areas.Admin.Controllers
{
    public class CategoryController(ProniaEContext _context) : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.Where(x => !x.IsDeleted).Select(s => new GetCategoryVM
            {
                Name = s.Name,
                Id = s.Id,

            }).ToListAsync();
            return View(data);




        }










    }
}
