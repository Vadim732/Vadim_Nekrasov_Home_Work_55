using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers;

public class CategoryController : Controller
{
    private ProductContext _context;

    public CategoryController(ProductContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Category> categories = _context.Categories.ToList();
        return View(categories);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category != null)
        {
            bool categoryName = _context.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
            if (categoryName)
            {
                ModelState.AddModelError("Name", "Error: A category with this name already exists!");
                return View(category);
            }
            
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        return View(category);
    }

    public IActionResult Delete(int categoryId)
    {
        Category category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
        if (category != null)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}