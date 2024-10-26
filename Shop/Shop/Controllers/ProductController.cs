using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Services;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(SortProductState sortProductState = SortProductState.NameAsc, int page =1)
        {
            IEnumerable<Product> products = await _context.Products.Include(p => p.Brand).Include(p => p.Category).ToListAsync();
            ViewBag.NameSort = sortProductState == SortProductState.NameAsc ? SortProductState.NameDesc : SortProductState.NameAsc;
            ViewBag.DateCreationSort = sortProductState == SortProductState.DateCreationAsc ? SortProductState.DateCreationDesc : SortProductState.DateCreationAsc;
            ViewBag.CategorySort = sortProductState == SortProductState.CategoryAsc ? SortProductState.CategoryDesc : SortProductState.CategoryAsc;
            ViewBag.BrandSort = sortProductState == SortProductState.BrandAsc ? SortProductState.BrandDesc : SortProductState.BrandAsc;
            ViewBag.PriceSort = sortProductState == SortProductState.PriceAsc ? SortProductState.PriceDesc : SortProductState.PriceAsc;
            switch (sortProductState)
            {
                case SortProductState.NameAsc:
                    products = products.OrderBy(p => p.Name);
                    break;
                case SortProductState.NameDesc:
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case SortProductState.DateCreationAsc:
                    products = products.OrderBy(p => p.DateCreation);
                    break;
                case SortProductState.DateCreationDesc:
                    products = products.OrderByDescending(p => p.DateCreation);
                    break;
                case SortProductState.CategoryAsc:
                    products = products.OrderBy(p => p.Category.Name);
                    break;
                case SortProductState.CategoryDesc:
                    products = products.OrderByDescending(p => p.Category.Name);
                    break;
                case SortProductState.BrandAsc:
                    products = products.OrderBy(p => p.Brand.Name);
                    break;
                case SortProductState.BrandDesc:
                    products = products.OrderByDescending(p => p.Brand.Name);
                    break;
                case SortProductState.PriceAsc:
                    products = products.OrderBy(p => p.Price);
                    break;
                case SortProductState.PriceDesc:
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }

            int pageSize = 3;
            int count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pvm = new PageViewModel(products.Count(), page, pageSize);

            var pivm = new ProductIndexViewModel()
            {
                Products = items.ToList(),
                PageViewModel = pvm
            };
            
            return View(pivm);
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
