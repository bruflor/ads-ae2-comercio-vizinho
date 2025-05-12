using Microsoft.EntityFrameworkCore;

namespace MVC.Models;

public class Product
{
    public Guid Id { get; init; }
    public String Name { get; set; }
    public Double? Price { get; set; } = 0.0;
    public int? StockLevel { get; set; } = 0;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool? IsAvailable { get; set; } = true;

    public List<Category> Categories { get; } = [];  // skip navigations
    
    public Guid ProducerId { get; set; }
    public User Producer { get; set; }

    public String? Description { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public String? Photo { get; set; }
    public String? EnvironmentalImpact { get; set; }
    public Double? PromotionalPrice { get; set; }
}