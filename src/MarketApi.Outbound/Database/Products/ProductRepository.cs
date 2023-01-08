using MarketApi.Databases.SqlServer;
using MarketApi.Entities.Products;
using MarketApi.Ports.Outbound.Products;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Outbound.Database.Products;

public class ProductRepository : IProductRepositoryPortOut
{
    private readonly DatabaseContext _databaseContext;

    public ProductRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<ICollection<Product>> GetProductsAsync()
    {
       return await _databaseContext.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _databaseContext.Products.FindAsync(id);
    }
}