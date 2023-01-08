using MarketApi.Entities.Products;

namespace MarketApi.Ports.Inbound.Products;

public interface IProductServicePortInbound
{
    ICollection<Product> GetAllProducts();
}