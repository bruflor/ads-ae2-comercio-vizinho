using System.ComponentModel.DataAnnotations.Schema;
using MVC.Components;

namespace MVC.Models;

public class Category : IWidth
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String? Description { get; set; }
    public String? Status { get; set; } = "draft";
    
    public List<Product> Products { get; } = []; // skip navigations
    [NotMapped] private String Width { get; set; }


    public void setWidth(string width)
    {
         Width= width;
    }

    public string? getWidth()
    {
        return Width;
    }
}