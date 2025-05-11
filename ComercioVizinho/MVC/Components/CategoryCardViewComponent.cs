using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Components;

public class CategoryCardViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Category categories)
    {
        Console.WriteLine(categories);
        return View(categories);
    }
}

public class CategoryChipViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Category categories)
    {
        return View(categories);
    }
}

public interface IWidth
{
    void setWidth(string width);
    String? getWidth ();
    
}