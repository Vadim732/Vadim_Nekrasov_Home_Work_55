using Shop.Models;

namespace Shop.ViewModels;

public class ProductIndexViewModel
{
    public List<Product> Products { get; set; }
    public PageViewModel PageViewModel { get; set; }
}