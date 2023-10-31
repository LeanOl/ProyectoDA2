using APIModels.InputModels;
using APIModels.OutputModels;
using ILogic;
using Logic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

[Route("api/products")]
[ExceptionFilter]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductLogic _productLogic;

    public ProductsController(IProductLogic productLogic)
    {
        _productLogic = productLogic;
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdProduct = _productLogic.CreateProduct(request.ToEntity());
        return CreatedAtAction(nameof(CreateProduct), new { id = createdProduct.Id }, new ProductResponse(createdProduct));
    }

    [HttpGet]
    public IActionResult GetFilteredProducts([FromQuery]string? filter = "")
    {
        var products = _productLogic.GetFilteredProducts(filter);
        return Ok(products.Select(p => new ProductResponse(p)).ToList());
    }
}
