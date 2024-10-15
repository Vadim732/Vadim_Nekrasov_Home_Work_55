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
}