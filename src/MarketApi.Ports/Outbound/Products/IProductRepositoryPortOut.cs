using MarketApi.Entities.Products;

namespace MarketApi.Ports.Outbound.Products;

public interface IProductRepositoryPortOut
{
    Task<ICollection<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
}