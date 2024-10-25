using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers;

public class BrandController : Controller
{
    private ProductContext _context;

    public BrandController(ProductContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Brand> brands = _context.Brands.ToList();
        return View(brands);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Brand brand)
    {
        if (brand != null)
        {
            bool brandName = _context.Brands.Any(b => b.Name.ToLower() == brand.Name.ToLower());
            if (brandName)
            {
                ModelState.AddModelError("Name", "Error: A brand with this name already exists!");
                return View(brand);
            }
            
            _context.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        return View(brand);
    }

    public IActionResult Delete(int brandId)
    {
        Brand brand = _context.Brands.FirstOrDefault(b => b.Id == brandId);
        if (brand != null)
        {
            _context.Remove(brand);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}