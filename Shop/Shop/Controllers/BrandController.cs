using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class BrandController : Controller
    {
        private readonly ProductContext _context;

        public BrandController(ProductContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();
            return View(brands);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(brand);
        }

        public async Task<IActionResult> Delete(int brandId)
        {
            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == brandId);
            if (brand != null)
            {
                _context.Remove(brand);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        
        public async Task<bool> CheckName(string name)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
            return brand == null;
        }
    }
}