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
        if (ModelState.IsValid)
        {
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
    
    public bool CheckName(string name)
    {
        var brand = _context.Brands.FirstOrDefault(b => b.Name.ToLower() == name.ToLower());
        return brand == null;
    }
}