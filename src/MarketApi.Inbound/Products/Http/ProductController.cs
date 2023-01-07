using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Inbound.Products.Http;

[ApiController]
[Route("v1/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public string GetProducts()
    {
        return "this will be a list of products";
    }
    
    [HttpGet("{id}")]
    public string GetProduct(int id)
    {
        return "this will be a single";
    }
}