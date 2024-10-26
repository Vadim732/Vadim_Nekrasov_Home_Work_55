using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = new SelectList(await _context.Brands.ToListAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.DateCreation = DateTime.UtcNow;
                product.DateUpdate = null;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public async Task<IActionResult> Details(int productId)
        {
            Product product = await _context.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == productId);
            if (product != null)
            {
                return View(product);
            }

            return NotFound();
        }

        public async Task<IActionResult> Edit(int productId)
        {
            Product product = await _context.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == productId);
            ViewBag.Brands = new SelectList(await _context.Brands.ToListAsync(), "Id", "Name");
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            if (product != null)
            {
                return View(product);
            }
            
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                product.DateUpdate = DateTime.UtcNow;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int productId)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
