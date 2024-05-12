using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaEmil.DataAccesLayer;
using ProniaEmil.Extentions;
using ProniaEmil.ViewModels.Products;
using ProniaEmil.ViewModels.Sliders;

namespace ProniaEmil.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(ProniaEContext _context,IWebHostEnvironment _env) : Controller
    {
        public async Task< IActionResult> Index()
        {
            var data = await _context.Products.Where(x => !x.IsDeleted).Select(s => new GetProductAdminVM
            {
                CostPrice = s.CostPrice,
                SellPrice = s.SellPrice,
                Discount = s.Discount,
                Id = s.Id,
                Name = s.Name,
                ImgUrl = s.ImgUrl,
                Raiting= s.Raiting,
                StockCount= s.StockCount

            }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task <IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM data)
        {
            if (!data.ImageFile.IsValidType("image"))
                ModelState.AddModelError("ImageFile", "Fayl sekil olmalidir");
            if (!data.ImageFile.IsValidLength(200))
                ModelState.AddModelError("ImageFile", "Filenin olcusu 200kbdan cox olmamalidir");          
            if(!ModelState.IsValid) 
            {
                return View(data);
            }
            string fileName = await data.ImageFile.SaveFileAsync( Path.Combine(_env.WebRootPath,"imgs", "products"));
         
          await _context.Products.AddAsync(new Models.Product 
          { 
             CostPrice= data.CostPrice,
             SellPrice= data.SellPrice,
             Discount= data.Discount,
             ImgUrl= Path.Combine("imgs", "products", fileName),
             IsDeleted=false,
             Name= data.Name,
             Raiting=data.Raiting,
             StockCount= data.StockCount,
             CreatedTime=DateTime.Now             
          }
          );
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
 
        }
    }
}
