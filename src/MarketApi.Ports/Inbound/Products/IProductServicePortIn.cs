using MarketApi.Entities.Products;

namespace MarketApi.Ports.Inbound.Products;

public interface IProductServicePortInbound
{
    Task<ICollection<Product>> GetAllProductsAsync();
    Task<Product> GetOneProductAsync(int id);
}