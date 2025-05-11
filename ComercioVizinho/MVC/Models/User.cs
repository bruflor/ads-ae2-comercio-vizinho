namespace MVC.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Status { get; set; } = "pending";
    public List<string>? Role { get; set; } = ["consumer"];
    public string? PhoneNumber { get; set; }
}