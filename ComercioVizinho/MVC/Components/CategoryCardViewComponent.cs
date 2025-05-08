using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Components;

public class CategoryCardViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(Category categories)
    {
        return View(categories);
    }
}