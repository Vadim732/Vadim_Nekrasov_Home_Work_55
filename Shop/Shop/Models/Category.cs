using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 3)]
    [Remote(action: "CheckName", controller: "Category", ErrorMessage = "A category with this name already exists!")]
    public string Name { get; set; }
}