using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Models;

public class Brand
{
    public int Id { get; set; }
    [Required]
    [StringLength(26, MinimumLength = 3)]
    [Remote(action:"CheckName", controller:"Brand", ErrorMessage = "A brand with this name already exists!")]
    public string Name { get; set; }
}