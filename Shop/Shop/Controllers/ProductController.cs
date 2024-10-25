using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers;

public class ProductController : Controller
{
    private ProductContext _context;

    public ProductController(ProductContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Product> products = _context.Products.ToList();
        return View(products);
    }
    
    public IActionResult Create()
    {
        ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            product.DateCreation = DateTime.UtcNow;
            product.DateUpdate = null;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(product);
    }

    public IActionResult Details(int productId)
    {
        Product product = _context.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            return View(product);
        }

        return NotFound();
    }

    public IActionResult Edit(int productId)
    {
        Product product = _context.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefault(p => p.Id == productId);
        ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
        ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
        if (product != null)
        {
            return View(product);
        }
        
        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            product.DateUpdate = DateTime.UtcNow;

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(product);
    }

    public IActionResult Delete(int productId)
    {
        Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}