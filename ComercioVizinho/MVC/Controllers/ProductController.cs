using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Controllers;

public class ProductController: Controller
{
    private readonly ComercioVizinhoDbContext _context;

    public ProductController(ComercioVizinhoDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Products"] = await _context.Products.Include(p => p.Producer).ToListAsync();
        return View();
    }
    public async Task<IActionResult> Detail(Guid id)
    {
        ViewData["Product"] = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return View();
    }
}