using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketApi.Inbound.Products.Http;

[ApiController]
[ApiVersion("1")]
[Route("/v{version:apiVersion}/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all products", Description = "Retrieve a list of all products")]
    public string GetProducts()
    {
        return "this will be a list of products";
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Retrieve product by id", Description = "Retrieve a single product")]
    public string GetProduct(int id)
    {
        return "this will be a single";
    }
}