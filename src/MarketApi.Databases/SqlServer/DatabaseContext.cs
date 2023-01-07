using MarketApi.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Databases.SqlServer;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
}