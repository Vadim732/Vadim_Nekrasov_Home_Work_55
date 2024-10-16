namespace Shop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}