namespace Shop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateUpdate { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
}