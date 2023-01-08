using MarketApi.Databases.SqlServer;
using MarketApi.Entities.Products;
using MarketApi.Ports.Outbound.Products;

namespace MarketApi.Outbound.Database.Products;

public class ProductRepository : IProductRepositoryPortOut
{
    private readonly DatabaseContext _databaseContext;

    public ProductRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public ICollection<Product> GetAllProducts()
    {
       return _databaseContext.Products.ToList();
    }
}