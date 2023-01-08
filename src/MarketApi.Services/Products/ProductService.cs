using MarketApi.Entities.Products;
using MarketApi.Ports.Inbound.Products;
using MarketApi.Ports.Outbound.Products;

namespace MarketApi.Services.Products;

public class ProductService : IProductServicePortInbound
{
    private readonly IProductRepositoryPortOut _productRepositoryPortOut;

    public ProductService(IProductRepositoryPortOut productRepositoryPortOut)
    {
        _productRepositoryPortOut = productRepositoryPortOut;
    }

    public ICollection<Product> GetAllProducts()
    {
        return _productRepositoryPortOut.GetAllProducts();
    }
}