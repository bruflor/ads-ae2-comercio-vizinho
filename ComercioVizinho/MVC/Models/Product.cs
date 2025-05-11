namespace MVC.Models;

public class Product
{
    public Guid Id { get; init; }
    public String Name { get; set; }
    public Double? Price { get; set; } = 0.0; //price must not be float
    public int? StockLevel { get; set; } = 0;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool? IsAvailable { get; set; } = true;

    public ICollection<Category>? Categories { get; set; }
    
    public Guid ProducerId { get; set; }
    public User Producer { get; set; }

    public string? Description { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public string? Photo { get; set; }
    public string? EnvironmentalImpact { get; set; }
    public float? PromotionalPrice { get; set; }
}