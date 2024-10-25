using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 3)]
    public string Name { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 3)]
    public string Surname { get; set; }
    [Required]
    [StringLength(62, MinimumLength = 12)]
    public string Address { get; set; }
    [Required]
    [StringLength(24, MinimumLength = 9)]
    public string ContactPhone { get; set; }
    
    [Required]
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
}