using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        List<Order> orders = _context.Orders.Include(o => o.Product).ToList();
        return View(orders);
    }

    public IActionResult Create(int productId)
    {
        Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
        return View(new Order() { Product = product });
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (order != null)
        {
            _context.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return NotFound();
    }
    
    public IActionResult Delete(int orderId)
    {
        Order order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}