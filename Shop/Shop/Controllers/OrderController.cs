using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers;

public class OrderController : Controller
{
    private ProductContext _context;

    public OrderController(ProductContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        List<Order> orders = _context.Orders.ToList();
        return View(orders);
    }
}