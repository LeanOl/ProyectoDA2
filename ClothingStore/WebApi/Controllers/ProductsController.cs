using APIModels.InputModels;
using APIModels.OutputModels;
using Logic.Concrete;
using Logic.Interfaces;
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
    public IActionResult GetAllProducts()
    {
        var products = _productLogic.GetAllProducts();
        return Ok(products.Select(p => new ProductResponse(p)).ToList());
    }
}
