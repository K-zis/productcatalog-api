using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApi.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
}
