using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data;

public class ComercioVizinhoDbContext : DbContext
{
    public ComercioVizinhoDbContext(DbContextOptions<ComercioVizinhoDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Products);
    }
}