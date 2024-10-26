using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductContext _context;

        public OrderController(ProductContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            List<Order> orders = await _context.Orders.Include(o => o.Product).ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Create(int productId)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return View(new Order() { Product = product });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(order);
        }
        
        public async Task<IActionResult> Delete(int orderId)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}