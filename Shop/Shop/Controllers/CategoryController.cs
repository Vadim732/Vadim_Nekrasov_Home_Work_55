using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductContext _context;

        public CategoryController(ProductContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(category);
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category != null)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        
        public async Task<bool> CheckName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
            return category == null;
        }
    }
}