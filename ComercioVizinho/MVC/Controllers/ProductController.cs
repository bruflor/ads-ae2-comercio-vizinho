using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers;

public class ProductController : Controller
{
    private readonly ComercioVizinhoDbContext _context;

    public ProductController(ComercioVizinhoDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(Guid? categoryId, int? pageNumber=1)
    {
        var products = from p in _context.Products select p;

        if (categoryId == null)
        {
            products = _context.Products
                .Include(p => p.Producer);
        }
        else
        {
            products = _context.Products
                .Where(p => p.Categories.Any(c => c.Id == categoryId))
                .Include(p => p.Producer);
        }

        int pageSize = 3;

        ViewData["Categories"] = await _context.Categories.OrderBy(c => c.Name).ToArrayAsync();
        // ViewData["Products"] = ;
        ViewData["CurrentCategoryId"] = categoryId;

        return View(await PaginatedList<Product>.CreateAsync(products, pageNumber ?? 1, pageSize));
    }

    public async Task<IActionResult> Detail(Guid id)
    {
        var product = await _context.Products
            .Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
        {
            // TODO: HERE WOULD BE NICE TO REDIRECT TO OUR PAGE "NOT FOUND" AND NOT TO A NOT FOUND
            // TODO: CREATE THE NOT FOUND PAGE
            return NotFound();
        }

        return View(product);
    }
}