using Microsoft.AspNetCore.Mvc;
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
}