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

    // Your existing category setup
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

    var producerUser = new User()
    {
        Id = Guid.Parse("92D6E7B8-A4E0-43A1-B0D7-50921E851CC4"),
        Name = "Rui Couves",
        Email = "rcouves@meuemail.com",
        Password = "Couves2025@"
    };

    // Get the ID of the second category ("Legumes")
    var legumesCategoryId = categories[1].Id;

    var products = new List<Product>
    {
        new Product
        {
            Id = Guid.Parse("FD5E3535-5A7C-4294-ABDE-49E869D77957"),
            Name = "Couve Lombarda",
            Producer = producerUser, // Reference to the user
            
        }
    };

    // For many-to-many relationship, we need to create the join table data
    var productCategories = new List<object> // Using object as we don't have your join entity
    {
        new 
        {
            ProductsId = products[0].Id,
            CategoriesId = legumesCategoryId
        }
    };

    modelBuilder.Entity<Category>().HasData(categories);
    modelBuilder.Entity<User>().HasData(producerUser);
    modelBuilder.Entity<Product>().HasData(products);
    
    // Configure the many-to-many relationship seeding
    modelBuilder.Entity("ProductCategory") // Use the name of your join table/entity
        .HasData(productCategories);
}
}