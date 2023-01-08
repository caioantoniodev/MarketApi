using MarketApi.Entities.Products;
using MarketApi.Ports.Inbound.Products;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketApi.Inbound.Products.Http;

[ApiController]
[ApiVersion("1")]
[Route("/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductServicePortInbound _productServicePortInbound;

    public ProductsController(IProductServicePortInbound productServicePortInbound)
    {
        _productServicePortInbound = productServicePortInbound;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all products", Description = "Retrieve a list of all products")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ICollection<Product>))]
    public ICollection<Product> GetProducts()
    {
        return _productServicePortInbound.GetAllProducts();
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retrieve product by id", Description = "Retrieve a single product")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Product))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public string GetProduct(int id)
    {
        return "this will be a single";
    }
}