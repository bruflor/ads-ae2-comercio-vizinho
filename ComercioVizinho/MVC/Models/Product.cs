namespace MVC.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int StockLevel { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsAvailable { get; set; } = true;

    public List<Category> Categories { get; set; }
    public User Producer { get; set; }

    public string? Description { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public string? Photo { get; set; }
    public string? EnvironmentalImpact { get; set; }
    public float? PromotionalPrice { get; set; }
}