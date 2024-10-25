using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 3)]
    public string Name { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime? DateUpdate { get; set; }
    [Required]
    [Url]
    public string Image { get; set; }
    [Required]
    [Range(50, int.MaxValue, ErrorMessage = "Price cannot be less than 50$")]
    public int Price { get; set; }
    
    [Required]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required]
    public int? BrandId { get; set; }
    public Brand? Brand { get; set; }
}