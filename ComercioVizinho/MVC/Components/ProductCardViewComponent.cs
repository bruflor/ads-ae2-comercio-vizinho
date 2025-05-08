using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Components;

public class ProductCardViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Product products)
    {
        return View(products);
    }
}