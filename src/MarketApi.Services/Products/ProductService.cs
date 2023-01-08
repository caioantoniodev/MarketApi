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

    public  async Task<ICollection<Product>> GetAllProductsAsync()
    {
        return await _productRepositoryPortOut.GetProductsAsync();
    }

    public async Task<Product> GetOneProductAsync(int id)
    {
        return await _productRepositoryPortOut.GetProductByIdAsync(id);
    }
}