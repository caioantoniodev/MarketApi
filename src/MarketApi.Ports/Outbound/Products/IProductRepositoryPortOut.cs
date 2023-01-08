using MarketApi.Entities.Products;

namespace MarketApi.Ports.Outbound.Products;

public interface IProductRepositoryPortOut
{
    ICollection<Product> GetAllProducts();
}