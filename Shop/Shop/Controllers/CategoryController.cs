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
        if (ModelState.IsValid)
        {
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
    
    public bool CheckName(string name)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        return category == null;
    }
}