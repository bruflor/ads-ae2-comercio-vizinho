using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Components;

public class CategoryCardViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(User categories)
    {
        return View(categories);
    }
}