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
        base.OnModelCreating(modelBuilder);

        List<string> categoriesNames = new List<string>
        {
            "Frutas",
            "Legumes",
            "Grãos e Cereais",
            "Laticínios",
            "Carnes e Ovos",
            "Produtos Orgânicos",
            "Produtos Sustentáveis",
            "Geleias e Doces",
            "Farinhas e Massas",
            "Bebidas",
            "Produtos Sazonais",
            "Produtos Regionais",
            "Excedentes Agrícolas"
        };
        var categories = new List<Category>();
        int counter = 1;

        foreach (var categoryName in categoriesNames)
        {
            categories.Add(new Category
            {
                Id = Guid.Parse($"00000000-0000-0000-0000-{counter.ToString().PadLeft(12, '0')}"),
                Name = categoryName,
                Description = null,
                Status = "draft"
            });
            counter++;
        }

        modelBuilder.Entity<Category>().HasData(categories);
    }
}