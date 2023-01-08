using MarketApi.Entities.Products;
using MarketApi.Ports.Inbound.Products;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketApi.Inbound.Products.Http;

[ApiController]
[ApiVersion("1")]
[Route("/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
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
    public async Task<ActionResult<ICollection<Product>>> GetProducts()
    {
        var products = await _productServicePortInbound.GetAllProductsAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retrieve product by id", Description = "Retrieve a single product")]
    [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Product))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productServicePortInbound.GetOneProductAsync(id);
        return Ok(product);
    }
}