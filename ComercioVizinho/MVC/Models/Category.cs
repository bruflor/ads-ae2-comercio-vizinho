using System.ComponentModel.DataAnnotations.Schema;
using MVC.Components;

namespace MVC.Models;

public class Category : IWidth
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; } = "draft";
    
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