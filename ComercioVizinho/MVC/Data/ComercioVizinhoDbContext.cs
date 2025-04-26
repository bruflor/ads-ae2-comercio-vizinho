using Microsoft.EntityFrameworkCore;

namespace MVC.Data;

public class ComercioVizinhoDbContext:DbContext
{
    public ComercioVizinhoDbContext(DbContextOptions<ComercioVizinhoDbContext> options) : base(options)
    {
    }
}